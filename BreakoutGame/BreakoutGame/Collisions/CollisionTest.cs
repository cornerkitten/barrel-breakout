using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Collisions
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
                Vector2 overlap = ((BoxCollider)collider).CollidesWith((BoxCollider)otherCollider);
                if (overlap != Vector2.Zero)
                {
                    collision = new Collision(otherCollider, overlap, collider);
                    otherCollision = new Collision(collider, overlap * -1, otherCollider);
                }
            }
        }

        public bool HasCollision()
        {
            return (collision != null);
        }
    }
}
