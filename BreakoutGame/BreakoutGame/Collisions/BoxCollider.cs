using Mabv.Breakout.Behaviors;
using Mabv.Breakout.GameEntities;
using Mabv.Breakout.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Collisions
{
    public class BoxCollider : ICollider
    {
        public IPhysics Physics { get { return physics; } }
        public IBehavior AttachedBehavior { get { return attachedBehavior; } }
        public IGameEntity AttachedGameEntity { get { return gameEntity; } }
        public int Width { get; set; }
        public int Height { get; set; }
        private IPhysics physics;
        private IBehavior attachedBehavior;
        private IGameEntity gameEntity;
        
        public BoxCollider(int width, int height, IPhysics physics, IBehavior attachedBehavior = null, IGameEntity gameEntity = null)
        {
            this.Width = width;
            this.Height = height;
            this.physics = physics;
            this.attachedBehavior = attachedBehavior;
            this.gameEntity = gameEntity;
        }

        public bool CollidesWith(BoxCollider boxCollider)
        {
            Rectangle rectangle = new Rectangle((int)physics.Transform.Location.X, (int)physics.Transform.Location.Y, Width, Height);
            Rectangle otherRectangle = new Rectangle((int)boxCollider.Physics.Transform.Location.X, (int)boxCollider.Physics.Transform.Location.Y, boxCollider.Width, boxCollider.Height);
            return rectangle.Intersects(otherRectangle);
        }
    }
}
