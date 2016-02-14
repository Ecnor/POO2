using System;

using Microsoft.Xna.Framework;

namespace POO2.Core
{
    class AABB : Hitbox
    {
        public Vector2 m_min;
        public Vector2 m_max;

        public AABB(Vector2 min, Vector2 max)
        {
            m_min = min;
            m_max = max;
        }

        public static bool AABBvsAABB(Manifold M)
        {
            // Setup manifold object
            Brick A = (Brick)M.m_A;
            Brick B = (Brick)M.m_B;

            // Vector from A to B
            //Vector2 n = B.m_position - A.m_position;
            Vector2 posA = new Vector2((A.m_position.X + (A.m_texture.Width / 2)), (A.m_position.Y + (A.m_texture.Height / 2)));
            Vector2 posB = new Vector2((B.m_position.X + (B.m_texture.Width / 2)), (B.m_position.Y + (B.m_texture.Height / 2)));
            Vector2 n = posB - posA;

            AABB abox = (AABB)A.m_hitbox;
            AABB bbox = (AABB)B.m_hitbox;

            // Calculate half extents along x axis for each object
            float a_extent = (abox.m_max.X - abox.m_min.X) / 2;
            float b_extent = (bbox.m_max.X - bbox.m_min.X) / 2;

            // Calculate overlap on x axis
            float x_overlap = a_extent + b_extent - Math.Abs(n.X);      

            // SAT test on x axis
            if (x_overlap > 0)
            {
                // Calculate half extents along x axis for each object
                a_extent = (abox.m_max.Y - abox.m_min.Y) / 2;
                b_extent = (bbox.m_max.Y - bbox.m_min.Y) / 2;

                // Calculate overlap on y axis
                float y_overlap = a_extent + b_extent - Math.Abs(n.Y);

                // SAT test on y axis
                if (y_overlap > 0)
                {
                    // Find out which axis is axis of least penetration
                    if (x_overlap < y_overlap)
                    {
                        // Point towards B knowing that n points from A to B
                        if (n.X < 0)
                            M.m_normal = new Vector2(-1, 0);
                        else
                            M.m_normal = new Vector2(1, 0);

                        M.m_penetration = x_overlap;

                        return true;
                    }
                    else
                    {
                        // Point toward B knowing that n points from A to B
                        if (n.Y < 0)
                            M.m_normal = new Vector2(0, -1);
                        else
                            M.m_normal = new Vector2(0, 1);
                        
                        M.m_penetration = y_overlap;

                        return true;
                    }               
                }            
            }

            return false;
        }
    }
}
