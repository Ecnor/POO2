
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace POO2.Core
{
    class Brick : GameObject
    {
        public Brick(Vector2 position, Texture2D texture, float mass, float restitution) : base(position, texture, mass, restitution)
        {
            Vector2 v1 = new Vector2(m_position.X, m_position.Y);
            Vector2 v2 = new Vector2(m_position.X + m_texture.Width, m_position.Y + m_texture.Height);
            m_hitbox = new AABB(v1, v2);
        }

        public override void Move(float deltaTime)
        {
            base.Move(deltaTime);

            ((AABB)m_hitbox).m_min.X = m_position.X;
            ((AABB)m_hitbox).m_min.Y = m_position.Y;
            ((AABB)m_hitbox).m_max.X = m_position.X + m_texture.Width;
            ((AABB)m_hitbox).m_max.Y = m_position.Y + m_texture.Height;
        }
    }
}
