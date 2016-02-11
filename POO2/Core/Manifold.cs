using System;

using Microsoft.Xna.Framework;

namespace POO2.Core
{
    class Manifold
    {
        public GameObject m_A;
        public GameObject m_B;

        public float m_penetration;

        public Vector2 m_normal;

        public Manifold(GameObject A, GameObject B)
        {
            m_A = A;
            m_B = B;
        }

        public void ResolveCollision()
        {
            // Calculate relative velocity
            Vector2 relativeVelocity = m_B.m_velocity - m_A.m_velocity;

            // Calculate relative velocity in terms of the normal direction
            float velocityAlongNormal = Vector2.Dot(relativeVelocity, m_normal);

            // Do not resolve if velocities are separating
            if (velocityAlongNormal > 0)
                return;

            // Calculate restitution
            float e = Math.Min(m_A.m_restitution, m_B.m_restitution);

            // Calculate impulse scalar
            float j = -(1 + e) * velocityAlongNormal;
            float massSum = m_A.m_invMass + m_B.m_invMass;
            if(massSum == 0)
            {
                j = 0;
                massSum = 1;
            }
            else
            {
                j /= massSum;
            }
            
            // Apply impulse
            Vector2 impulse = j * m_normal;
            m_A.m_velocity -= m_A.m_invMass * impulse;
            m_B.m_velocity += m_B.m_invMass * impulse;

            float PERCENT;
            const float SLOP = 0.01f;

            if (m_A.m_invMass == 0 || m_B.m_invMass == 0)
            {
                // Apply correction          
                PERCENT = 0.2f; // usually 20% to 80%

                Vector2 correction = (Math.Max(m_penetration - SLOP, 0.0f) / massSum) * PERCENT * Vector2.Normalize(m_normal);

                m_A.m_position -= m_A.m_invMass * correction;
                m_B.m_position += m_B.m_invMass * correction;
            }
            else
            {
                // Apply correction          
                PERCENT = 0.0007f; // usually 20% to 80%

                Vector2 correction = (Math.Max(m_penetration - SLOP, 0.0f) / massSum) * PERCENT * Vector2.Normalize(m_normal);

                m_A.m_position -= m_A.m_invMass * correction;
                m_B.m_position += m_B.m_invMass * correction;
            }
        }
    }
}
