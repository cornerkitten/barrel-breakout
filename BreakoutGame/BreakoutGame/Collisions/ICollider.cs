using Mabv.Breakout.Behaviors;
using Mabv.Breakout.GameEntities;
using Mabv.Breakout.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Collisions
{
    public interface ICollider
    {
        // TODO consider treating and naming this as AttachedPhysics, rather than Physics
        IPhysics Physics { get; }
        IBehavior AttachedBehavior { get; }
        IGameEntity AttachedGameEntity { get; }
    }
}
