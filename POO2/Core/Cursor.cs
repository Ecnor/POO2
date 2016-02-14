using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace POO2.Core
{
    class Cursor
    {
        public Texture2D m_texture;
        public Vector2 m_position;

        public Cursor(Texture2D texture)
        {
            m_texture = texture;
        }

        public void Update()
        {
            m_position.X = Mouse.GetState().Position.X;
            m_position.Y = Mouse.GetState().Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_texture, m_position, Color.White);
        }
    }
}
