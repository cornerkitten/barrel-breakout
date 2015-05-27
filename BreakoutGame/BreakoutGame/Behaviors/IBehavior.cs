using Mabv.Breakout.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public interface IBehavior
    {
        void OnCollisionEnter(ICollision collision);
        void OnAnimationEnd();
    }
}
