using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Physics
{
    public class RigidBodyPhysics : IPhysics
    {
        public ITransform Transform { get { return transform; } }
        public Vector2 Velocity { get; set; }
        private ITransform transform;

        public RigidBodyPhysics(ITransform transform)
        {
            this.transform = transform;
            this.Velocity = new Vector2(0, 0);
        }

        public void Update()
        {
            transform.Location += Velocity;
        }
    }
}
