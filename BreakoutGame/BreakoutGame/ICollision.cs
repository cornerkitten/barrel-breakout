using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public interface ICollision
    {
        ICollider Collider { get; }
    }
}
