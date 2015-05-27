using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class Collision : ICollision
    {
        private ICollider incomingCollider;
        public ICollider Collider {
            get { return incomingCollider; }
        }
        // public IGameEntity attachedGameEntity;

        public Collision(ICollider incomingCollider)
        {
            this.incomingCollider = incomingCollider;
        }
    }
}
