using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Physics
{
    public interface IPhysics
    {
        ITransform Transform { get; }
        Vector2 Velocity { get; set; }

        void Update();
    }
}
