using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using POO2.Core;

namespace POO2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;

        List<GameObject> objectList = new List<GameObject>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Environment.gravity = new Vector2(0, 100);

            objectList.Add(new Brick(new Vector2(200, 468), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));
            objectList.Add(new Brick(new Vector2(235, 468), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));
            objectList.Add(new Brick(new Vector2(215, 436), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));

            objectList.Add(new Brick(new Vector2(100, 160), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));
            objectList.Add(new Brick(new Vector2(150, 20), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));
            objectList.Add(new Brick(new Vector2(200, 80), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));
            objectList.Add(new Brick(new Vector2(250, 120), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));
            objectList.Add(new Brick(new Vector2(300, 100), Content.Load<Texture2D>("wooden_crate_32_32"), 1, GameObject.Material.Wood));

            objectList.Add(new Brick(new Vector2(300, 436), Content.Load<Texture2D>("wooden_crate_64_64"), 10, GameObject.Material.Wood));

            objectList.Add(new Brick(new Vector2(100, 500), Content.Load<Texture2D>("ground_512_64"), 0, GameObject.Material.Grass));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here          
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Collisions.CheckCollisions(objectList);
            Environment.UpdateObjectPosition(objectList, deltaTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Environment.DrawEnvironment(objectList, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
