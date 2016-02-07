using System.Collections.Generic;

using System.Diagnostics;

namespace POO2.Core
{
    class Collisions
    {
        public static void CheckCollisions(List<GameObject> objectList)
        {
            for(int i = 0; i < objectList.Count - 1; i++)
            {
                for(int j = i + 1; j < objectList.Count; j++)
                {
                    if(objectList[i] is Ball && objectList[j] is Ball)
                    {
                        Ball b1 = (Ball)objectList[i];
                        Ball b2 = (Ball)objectList[j];

                        Manifold m = new Manifold(b1, b2);

                        if(Circle.CirclevsCircle(m))
                        {
                            m.ResolveCollision();
                        }
                    }
                    else if(objectList[i] is Brick && objectList[j] is Brick)
                    {
                        Brick b1 = (Brick)objectList[i];
                        Brick b2 = (Brick)objectList[j];

                        Manifold m = new Manifold(b1, b2);

                        if(AABB.AABBvsAABB(m))
                        {
                            m.ResolveCollision();
                        }
                    }
                    else if(objectList[i] is Brick && objectList[j] is Ball)
                    {
                        Brick b1 = (Brick)objectList[i];
                        Ball b2 = (Ball)objectList[j];

                        Manifold m = new Manifold(b1, b2);

                        if(Hitbox.AABBvsCircle(m))
                        {
                            m.ResolveCollision();
                        }                       
                    }
                    else if(objectList[i] is Ball && objectList[j] is Brick)
                    {
                        Ball b1 = (Ball)objectList[i];
                        Brick b2 = (Brick)objectList[j];

                        Manifold m = new Manifold(b2, b1);

                        if(Hitbox.AABBvsCircle(m))
                        {
                            Debug.WriteLine("Collision");
                            m.ResolveCollision();
                        }
                    }
                    else
                    {
                        Debug.WriteLine("UH c'est quoi tes objets ?!");
                    }
                }
            }
        }
    }
}
