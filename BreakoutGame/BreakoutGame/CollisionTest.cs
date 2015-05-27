using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class CollisionTest : ICollisionTest
    {
        public ICollision Collision
        {
            get { return collision; }
        }
        public ICollision OtherCollision
        {
            get { return otherCollision; }
        }
        private ICollision collision;
        private ICollision otherCollision;

        public CollisionTest(ICollider collider, ICollider otherCollider)
        {
            if (collider is BoxCollider && otherCollider is BoxCollider)
            {
                if (((BoxCollider)collider).CollidesWith((BoxCollider)otherCollider))
                {
                    collision = new Collision(otherCollider);
                    otherCollision = new Collision(collider);
                }
            }
        }

        public bool HasCollision()
        {
            return (collision != null);
        }
    }
}
