using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace POO2.Core
{
    class Ball : GameObject
    {
        public Ball(Vector2 position, Texture2D texture, float mass, float restitution) : base(position, texture, mass, restitution)
        {
            Vector2 v = new Vector2(m_position.X + (m_texture.Width / 2), m_position.Y + (m_texture.Height / 2));
            m_hitbox = new Circle(m_texture.Width / 2, v);
        }

        public override void Move(float deltaTime)
        {
            base.Move(deltaTime);

            ((Circle)m_hitbox).m_position.X = m_position.X + (m_texture.Width / 2);
            ((Circle)m_hitbox).m_position.Y = m_position.Y + (m_texture.Height / 2);
        }
    }
}
