using System;

using Microsoft.Xna.Framework;

namespace POO2.Core
{
    class Circle : Hitbox
    {
        public float m_radius;
        public Vector2 m_position;

        public Circle(float radius, Vector2 position)
        {
            m_radius = radius;
            m_position = position;
        }

        public static bool CirclevsCircle(Manifold M)
        {
            // Setup manifold object
            Circle A = (Circle)((Ball)M.m_A).m_hitbox;
            Circle B = (Circle)((Ball)M.m_B).m_hitbox;

            // Vector from A to B
            Vector2 n = B.m_position - A.m_position;

            float r = A.m_radius + B.m_radius;
            r *= r;

            if(n.LengthSquared() > r)
                return false;

            // Compute manifold
            float d = n.Length();

            if(d != 0)
            {
                M.m_penetration = r - d;
                M.m_normal = n / d;
            }
            else
            {
                M.m_penetration = A.m_radius;
                M.m_normal = new Vector2(1, 0);
            }

            return true;
        }
    }
}
