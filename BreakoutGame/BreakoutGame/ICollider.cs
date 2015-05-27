using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public interface ICollider
    {
        IPhysics Physics { get; }
        IBehavior AttachedBehavior { get; }
    }
}
