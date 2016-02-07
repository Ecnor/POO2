using System;

using Microsoft.Xna.Framework;

using System.Diagnostics;

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
            Vector2 n = B.m_position - A.m_position;

            // Closest point on A to center B
            Vector2 closest = n;

            // Calculate half extents along each axis          
            float x_extent = (((AABB)A.m_hitbox).m_max.X - ((AABB)A.m_hitbox).m_min.X) / 2;
            float y_extent = (((AABB)A.m_hitbox).m_max.Y - ((AABB)A.m_hitbox).m_min.Y) / 2;
            Vector2 extent = new Vector2(x_extent, y_extent);

            // Clamp point to edges of the AABB
            closest = Vector2.Clamp(closest, -extent, extent);
            //closest = Vector2.Clamp(-extent, extent, closest);
            //closest.X = Math.Min(-extent.X, extent.X);
            //closest.Y = Math.Min(-extent.Y, extent.Y);

            bool inside = false;

            // Circle is inside the AABB, so we need to clamp the circle's center
            // to the closest edge
            Debug.WriteLine("***");

            Debug.WriteLine("c: " + closest);
            Debug.WriteLine("n: " + n);

            if (n == closest)
            {
                Debug.WriteLine("dans n = closest");
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
            {
                Debug.WriteLine("2eme if");
                return false;
            }

            // Avoided sqrt until we need
            d = (float)Math.Sqrt(d);

            // Collision normal needs to be flipped to point outside if circle was
            // inside the AABB
            if(inside)
            {
                Debug.WriteLine("inside");
                M.m_normal = -n;
                M.m_penetration = r - d;
            }
            else
            {
                Debug.WriteLine("!inside");
                M.m_normal = n;
                M.m_penetration = r - d;
            }

            Debug.WriteLine("true");
            Debug.WriteLine("***");
            return true;
        }
    }
}
