using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class CollisionController : IController
    {
        List<ICollider> colliders;
        Queue<ICollider> removalQueue;

        public CollisionController()
        {
            this.colliders = new List<ICollider>();
            this.removalQueue = new Queue<ICollider>();
        }

        public void Update()
        {
            List<ICollider> newColliders = new List<ICollider>();

            while (colliders.Count > 0)
            {
                ICollider collider = colliders.ElementAt(0);
                colliders.RemoveAt(0);
                newColliders.Add(collider);

                foreach (ICollider otherCollider in colliders)
                {
                    ICollisionTest collisionTest = new CollisionTest(collider, otherCollider);

                    if (collisionTest.HasCollision())
                    {
                        if (collider.AttachedBehavior != null)
                        {
                            collider.AttachedBehavior.OnCollisionEnter(collisionTest.Collision);
                        }
                        if (otherCollider.AttachedBehavior != null)
                        {
                            otherCollider.AttachedBehavior.OnCollisionEnter(collisionTest.OtherCollision);
                        }
                    }
                }
            }

            colliders = newColliders;

            while (removalQueue.Count > 0)
            {
                ICollider collider = removalQueue.Dequeue();
                colliders.Remove(collider);
            }
        }

        public void AddCollider(ICollider collider)
        {
            colliders.Add(collider);
        }

        public void RemoveCollider(ICollider collider)
        {
            removalQueue.Enqueue(collider);
        }
    }
}
