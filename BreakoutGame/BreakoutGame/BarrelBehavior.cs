using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
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
            barrel.Explode();

            base.OnCollisionEnter(collision);
        }

        public override void OnAnimationEnd()
        {
            Console.WriteLine("BarrelBehavior.OnAnimationEnd");
            barrel.Destroy();

            base.OnAnimationEnd();
        }
    }
}
