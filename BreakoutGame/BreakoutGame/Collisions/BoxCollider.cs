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

        public Vector2 CollidesWith(BoxCollider boxCollider)
        {
            Rectangle rectangle = new Rectangle((int)physics.Transform.Location.X, (int)physics.Transform.Location.Y, Width, Height);
            Rectangle otherRectangle = new Rectangle((int)boxCollider.Physics.Transform.Location.X, (int)boxCollider.Physics.Transform.Location.Y, boxCollider.Width, boxCollider.Height);

            if (rectangle.Intersects(otherRectangle))
            {
                return minimumOverlap(rectangle, otherRectangle);
            }
            return Vector2.Zero;
        }

        private Vector2 minimumOverlap(Rectangle rectangle, Rectangle otherRectangle)
        {
            int horizontalMin = 0;
            int verticalMin = 0;
            
            if (rectangle.Center.X < otherRectangle.Center.X)
            {
                horizontalMin = otherRectangle.Left - rectangle.Right;
            }
            else
            {
                horizontalMin = otherRectangle.Right - rectangle.Left;
            }

            if (rectangle.Center.Y < otherRectangle.Center.Y)
            {
                verticalMin = otherRectangle.Top - rectangle.Bottom;
            }
            else
            {
                verticalMin = otherRectangle.Bottom - rectangle.Top;
            }

            if (Math.Abs(horizontalMin) < Math.Abs(verticalMin))
            {
                return new Vector2(horizontalMin, 0);
            }
            else
            {
                return new Vector2(0, verticalMin);
            }
        }
    }
}
