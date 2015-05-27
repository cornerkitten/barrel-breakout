using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class GameEntityController : IController
    {
        private List<IGameEntity> gameEntities;
        private Queue<IGameEntity> removalQueue;

        public GameEntityController()
        {
            this.gameEntities = new List<IGameEntity>();
            this.removalQueue = new Queue<IGameEntity>();
        }

        public void Update()
        {
            foreach (IGameEntity gameEntity in gameEntities)
            {
                gameEntity.Update();
            }

            while (removalQueue.Count > 0)
            {
                IGameEntity gameEntity = removalQueue.Dequeue();
                gameEntities.Remove(gameEntity);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameEntity gameEntity in gameEntities)
            {
                gameEntity.Draw(spriteBatch);
            }
        }

        public void AddGameEntity(IGameEntity gameEntity)
        {
            gameEntities.Add(gameEntity);
        }

        public void RemoveGameEntity(IGameEntity gameEntity)
        {
            removalQueue.Enqueue(gameEntity);
        }
    }
}
