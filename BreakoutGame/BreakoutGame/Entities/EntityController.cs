using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class EntityController : IController
    {
        public List<IEntity> Entities { get { return new List<IEntity>(entities); } }
        private List<IEntity> entities;
        private Queue<IEntity> removalQueue;

        public EntityController()
        {
            this.entities = new List<IEntity>();
            this.removalQueue = new Queue<IEntity>();
        }

        public void Update()
        {
            foreach (IEntity entity in entities)
            {
                entity.Update();
            }

            Flush();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEntity entity in entities)
            {
                entity.Draw(spriteBatch);
            }
        }

        public void AddEntity(IEntity entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            removalQueue.Enqueue(entity);
        }

        public void RemoveAll()
        {
            removalQueue = new Queue<IEntity>(this.entities);
        }

        public void Flush()
        {
            while (removalQueue.Count > 0)
            {
                IEntity entity = removalQueue.Dequeue();
                entities.Remove(entity);
            }
        }
    }
}
