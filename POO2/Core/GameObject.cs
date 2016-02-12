﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace POO2.Core
{
    class GameObject
    {
        public Vector2 m_position;
        public Vector2 m_velocity;

        public Texture2D m_texture;
        
        public float m_invMass;
        public float m_restitution;
        public float m_staticFriction = 0.2f;
        public float m_dynamicFriction = 0.2f;

        public Hitbox m_hitbox;

        public GameObject(Vector2 position, Texture2D texture, float mass, float restitution)
        {
            m_position = position;
            m_texture = texture;

            if(mass <= 0)
                m_invMass = 0;
            else
                m_invMass = 1 / mass;

            m_restitution = restitution;

        }

        public virtual void Move(float deltaTime)
        {
            m_velocity.X += (m_invMass * Environment.gravity.X) * deltaTime;
            m_position.X += m_velocity.X * deltaTime;

            m_velocity.Y += (m_invMass * Environment.gravity.Y) * deltaTime;
            m_position.Y += m_velocity.Y * deltaTime;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_texture, m_position, Color.White);
        }
    }
}
