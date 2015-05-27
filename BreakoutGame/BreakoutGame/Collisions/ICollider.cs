using Mabv.Breakout.Behaviors;
using Mabv.Breakout.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Collisions
{
    public interface ICollider
    {
        IPhysics Physics { get; }
        IBehavior AttachedBehavior { get; }
    }
}
