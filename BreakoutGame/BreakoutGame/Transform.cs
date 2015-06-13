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
        public float Rotation { get; set; }

        public Transform(Vector2 location)
        {
            this.Location = location;
        }

        public Transform(Vector2 location, float rotation)
        {
            this.Location = location;
            this.Rotation = rotation;
        }
    }
}
