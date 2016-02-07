using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace POO2.Core
{
    static class Environment
    {
        public static void UpdateObjectPosition(List<GameObject> objectList, float deltaTime)
        {
            for(int i = 0; i < objectList.Count; i++)
            {
                if(objectList[i].m_isAffectedByGravity)
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
