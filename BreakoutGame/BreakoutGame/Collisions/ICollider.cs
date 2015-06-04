using Mabv.Breakout.Behaviors;
using Mabv.Breakout.Entities;
using Mabv.Breakout.Physics;
using Microsoft.Xna.Framework;
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
        IEntity AttachedGameEntity { get; }
        // TODO determine if sensible to have this exposed by ICollider
        Vector2 Centroid { get; }
        // TODO determine if sensible to have this exposed by ICollider
        int Width { get; }
        // TODO determine if sensible to have this exposed by ICollider
        int Height { get; }
    }
}
