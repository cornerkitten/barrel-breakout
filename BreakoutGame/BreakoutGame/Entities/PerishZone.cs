using Mabv.Breakout.Collisions;
using Mabv.Breakout.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class PerishZone : IEntity
    {
        private CollisionController collisionController;
        ICollider collider;

        public PerishZone(View view, CollisionController collisionController)
        {
            this.collisionController = collisionController;

            int levelWidth = view.Width;
            int levelHeight = view.Height;
            int boundarySize = 64;
            
            IPhysics physics = new RigidBodyPhysics(new Transform(new Vector2(-boundarySize, levelHeight + boundarySize / 2)));
            collider = new BoxCollider(levelWidth + 2 * boundarySize, boundarySize, physics, null, this);

            this.collisionController.AddCollider(collider);
        }

        public void Update()
        {
            // do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // do nothing
        }

        public void Destroy()
        {
            collisionController.RemoveCollider(collider);
        }
    }
}
