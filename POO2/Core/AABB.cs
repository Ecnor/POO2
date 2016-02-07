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
            Vector2 n = B.m_position - A.m_position;

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
                    Vector2 fixNormal;
                    // Find out which axis is axis of least penetration
                    if (x_overlap > y_overlap)
                    {
                        // Point towards B knowing that n points from A to B
                        if (n.X < 0)
                            fixNormal = -Vector2.UnitX;
                        else
                            fixNormal = Vector2.UnitX;

                        M.m_normal = Vector2.Normalize(n) * fixNormal.X;
                        M.m_penetration = x_overlap;

                        return true;
                    }
                    else
                    {
                        // Point toward B knowing that n points from A to B
                        if (n.Y < 0)
                            fixNormal = -Vector2.UnitY;
                        else
                            fixNormal = Vector2.UnitY;

                        M.m_normal = Vector2.Normalize(n) * fixNormal.Y;
                        M.m_penetration = y_overlap;

                        return true;
                    }               
                }            
            }

            return false;
        }
    }
}
