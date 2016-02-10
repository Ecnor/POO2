using System;

using Microsoft.Xna.Framework;

namespace POO2.Core
{
    abstract class Hitbox
    {
        public static bool AABBvsCircle(Manifold M)
        {
            // Setup a couple pointers to each object
            Brick A = (Brick)M.m_A;
            Ball B = (Ball)M.m_B;

            // Vector from A to B
            Vector2 posA = new Vector2((A.m_position.X + (A.m_texture.Width / 2)), (A.m_position.Y + (A.m_texture.Height / 2)));
            Vector2 posB = new Vector2((B.m_position.X + (B.m_texture.Width / 2)), (B.m_position.Y + (B.m_texture.Height / 2)));
            Vector2 n = posB - posA;

            // Closest point on A to center B
            Vector2 closest = n;

            // Calculate half extents along each axis
            float x_extent = (((AABB)A.m_hitbox).m_max.X - ((AABB)A.m_hitbox).m_min.X) / 2;
            float y_extent = (((AABB)A.m_hitbox).m_max.Y - ((AABB)A.m_hitbox).m_min.Y) / 2;
            Vector2 extent = new Vector2(x_extent, y_extent);

            // Clamp point to edges of the AABB
            closest = Vector2.Clamp(closest, -extent, extent);

            bool inside = false;

            // Circle is inside the AABB, so we need to clamp the circle's center
            // to the closest edge
            if (n == closest)
            {
                inside = true;

                // Find closest axis
                if(Math.Abs(n.X) > Math.Abs(n.Y))
                {
                    // Clamp to closest extent X
                    if(closest.X > 0)
                        closest.X = extent.X;
                    else
                        closest.X = -extent.X;
                }
                else
                {
                    // Clamp to closest extent Y
                    if (closest.Y > 0)
                        closest.Y = extent.Y;
                    else
                        closest.Y = -extent.Y;
                }
            }

            Vector2 normal = n - closest;
            float d = normal.LengthSquared();
            float r = ((Circle)B.m_hitbox).m_radius;

            // Early out of the radius is shorter than distance to closest point and
            // Circle not inside the AABB
            if (d > (r * r) && !inside)
                return false;

            // Avoided sqrt until we need
            d = (float)Math.Sqrt(d);

            // Collision normal needs to be flipped to point outside if circle was
            // inside the AABB
            if(inside)
            {
                M.m_normal = -Vector2.Normalize(normal);
                M.m_penetration = r - d;
            }
            else
            {
                M.m_normal = Vector2.Normalize(normal);
                M.m_penetration = r - d;
            }

            return true;
        }
    }
}
