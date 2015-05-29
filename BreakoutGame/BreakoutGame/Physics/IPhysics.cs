using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Physics
{
    // TODO consider naming this IPhysicsBody, rather than IPhysics
    public interface IPhysics
    {
        // TODO consider not exposing this property
        ITransform Transform { get; }
        Vector2 Velocity { get; set; }

        void Update();
    }
}
