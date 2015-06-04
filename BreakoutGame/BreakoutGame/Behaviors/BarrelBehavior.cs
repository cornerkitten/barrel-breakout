using Mabv.Breakout.Collisions;
using Mabv.Breakout.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public class BarrelBehavior : Behavior
    {
        private Barrel barrel;

        public BarrelBehavior(Barrel barrel)
        {
            this.barrel = barrel;
        }

        override public void OnCollisionEnter(ICollision collision)
        {
            if (collision.Collider.AttachedGameEntity is DonkeyKong)
            {
                barrel.Explode();

                base.OnCollisionEnter(collision);
            }
        }

        public override void OnAnimationEnd()
        {
            Console.WriteLine("BarrelBehavior.OnAnimationEnd");
            barrel.Destroy();

            base.OnAnimationEnd();
        }
    }
}
