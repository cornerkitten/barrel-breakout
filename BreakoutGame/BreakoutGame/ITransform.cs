using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public interface ITransform
    {
        Vector2 Location { get; set; }
        float Rotation { get; set; }
    }
}
