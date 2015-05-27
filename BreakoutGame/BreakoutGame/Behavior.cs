using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public abstract class Behavior : IBehavior
    {
        virtual public void OnCollisionEnter(ICollision collision)
        {
            Console.WriteLine("Behavior.OnCollisionEnter");
            // do nothing
        }

        virtual public void OnAnimationEnd()
        {
            // do nothing
        }
    }
}
