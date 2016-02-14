using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace POO2.Core
{
    class GameObject
    {
        public enum Material { Aluminium, Wood, Copper, Diamond, Glass,
            Graphite, Ice, Grass};

        public Vector2 m_position;
        public Vector2 m_velocity;

        public Texture2D m_texture;
        
        public float m_invMass;
        public float m_restitution;
        public float m_staticFriction;
        public float m_dynamicFriction;

        public Hitbox m_hitbox;

        public GameObject(Vector2 position, Texture2D texture, float mass, Material material)
        {
            m_position = position;
            m_texture = texture;

            if(mass <= 0)
                m_invMass = 0;
            else
                m_invMass = 1 / mass;

            ComputeMaterial(material);
        }

        private void ComputeMaterial(Material material)
        {
            switch((int)material)
            {
                // Aluminium
                case 0:
                    m_staticFriction = 0.42f;
                    m_dynamicFriction = 0.34f;
                    m_restitution = 0.597f;
                    break;
                
                // Wood
                case 1:
                    m_staticFriction = 0.25f;
                    m_dynamicFriction = 0.129f;
                    m_restitution = 0.5f;
                    break;

                // Copper
                case 2:
                    m_staticFriction = 0.55f;
                    m_dynamicFriction = 0.25f;
                    m_restitution = 0.828f;
                    break;

                // Diamond
                case 3:
                    m_staticFriction = 0.1f;
                    m_dynamicFriction = 0.05f;
                    m_restitution = 0.6f;
                    break;
                
                // Glass
                case 4:
                    m_staticFriction = 0.95f;
                    m_dynamicFriction = 0.19f;
                    m_restitution = 0.658f;
                    break;
    
                // Graphite
                case 5:
                    m_staticFriction = 0.18f;
                    m_dynamicFriction = 0.14f;
                    m_restitution = 0.828f;
                    break;
                
                // Ice
                case 6:
                    m_staticFriction = 0.01f;
                    m_dynamicFriction = 0.01f;
                    m_restitution = 0.4f;
                    break;

                // Grass
                case 7:
                    m_staticFriction = 0.35f;
                    m_dynamicFriction = 0.3f;
                    m_restitution = 0.2f;
                    break;

                // Default (no friction)
                default:
                    m_staticFriction = 0;
                    m_dynamicFriction = 0;
                    m_restitution = 1;
                    break;
            }
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
