using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Collisions
{
    public interface ICollision
    {
        ICollider Collider { get; }
        Vector2 Overlap { get; }
    }
}
