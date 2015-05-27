using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public interface ICollisionTest
    {
        bool HasCollision();
        ICollision Collision { get; }
        ICollision OtherCollision { get; }
    }
}
