using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class Transform : ITransform
    {
        public Vector2 Location { get; set; }

        public Transform(Vector2 location)
        {
            this.Location = location;
        }
    }
}
