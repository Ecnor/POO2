using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace POO2.Core
{
    static class Environment
    {
        public static Vector2 gravity;
        public static Cursor cursor;

        public static void UpdateObjectPosition(List<GameObject> objectList, float deltaTime)
        {
            for(int i = 0; i < objectList.Count; i++)
            {
                objectList[i].Move(deltaTime);
                cursor.Update();
            }
        }

        public static void DrawEnvironment(List<GameObject> objectList, SpriteBatch spriteBatch)
        {
            for(int i = 0; i < objectList.Count; i++)
            {
                spriteBatch.Begin();
                objectList[i].Draw(spriteBatch);
                cursor.Draw(spriteBatch);
                spriteBatch.End();
            }       
        }

        public static void AddGround(List<GameObject> objectList, Game1 game)
        {         
            objectList.Add(new Brick(new Vector2(0, 146), game.Content.Load<Texture2D>("ground_512_64"), 0, GameObject.Material.Grass));
            objectList.Add(new Brick(new Vector2(250, 350), game.Content.Load<Texture2D>("ground_512_64"), 0, GameObject.Material.Grass));
            objectList.Add(new Brick(new Vector2(50, 500), game.Content.Load<Texture2D>("ground_512_64"), 0, GameObject.Material.Grass));
        }

        public static void AddRandomObject(List<GameObject> objectList)
        {
            /*Random rnd = new Random();
            Vector2 objectPosition = new Vector2(rnd.Next(-256, 544), rnd.Next(264, 546));
            objectList.Add(new Brick(objectPosition, game.Content.Load<Texture2D>("ground_512_64"), 0, GameObject.Material.Grass));*/
        }
    }
}
