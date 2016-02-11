﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace POO2.Core
{
    static class Environment
    {
        public static Vector2 gravity;

        public static void UpdateObjectPosition(List<GameObject> objectList, float deltaTime)
        {
            for(int i = 0; i < objectList.Count; i++)
            {
                objectList[i].Move(deltaTime);
            }
        }

        public static void DrawEnvironment(List<GameObject> objectList, SpriteBatch spriteBatch)
        {
            for(int i = 0; i < objectList.Count; i++)
            {
                spriteBatch.Begin();
                objectList[i].Draw(spriteBatch);
                spriteBatch.End();
            }       
        }
    }
}
