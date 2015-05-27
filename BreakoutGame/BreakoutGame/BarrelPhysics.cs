using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class BarrelPhysics : IPhysics
    {
        public Vector2 Velocity { get; set; }
        //private Rectangle boundingBox;
        private ITransform transform;
        public ITransform Transform { get { return transform; } }

        public BarrelPhysics(ITransform transform)
        {
            this.transform = transform;
            this.Velocity = new Vector2(0, 0);
            //this.boundingBox = new Rectangle(0, 0, 32, 32);
        }

        public void Update()
        {
            transform.Location += Velocity;
        }
    }
}
