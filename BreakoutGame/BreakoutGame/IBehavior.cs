using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public interface IBehavior
    {
        void OnCollisionEnter(ICollision collision);
        void OnAnimationEnd();
    }
}
