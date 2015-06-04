using Mabv.Breakout.Collisions;
using Mabv.Breakout.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public class BananaBunchBehavior : Behavior
    {
        private BananaBunch bananaBunch;

        public BananaBunchBehavior(BananaBunch bananaBunch)
        {
            this.bananaBunch = bananaBunch;
        }

        override public void OnCollisionEnter(ICollision collision)
        {
            if (collision.Collider.AttachedGameEntity is DonkeyKong)
            {
                bananaBunch.Destroy();

                base.OnCollisionEnter(collision);
            }
        }
    }
}
