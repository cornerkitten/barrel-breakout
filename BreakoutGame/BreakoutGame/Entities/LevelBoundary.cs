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
    public class LevelBoundary : IEntity
    {
        private CollisionController collisionController;
        ICollider topWallCollider;
        //ICollider bottomWallCollider;
        ICollider leftWallCollider;
        ICollider rightWallCollider;

        public LevelBoundary(CollisionController collisionController)
        {
            this.collisionController = collisionController;

            int levelWidth = 800;
            int levelHeight = 600;
            int boundarySize = 64;
            
            IPhysics topWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(-boundarySize, -boundarySize)));
            //IPhysics bottomWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(-boundarySize, levelHeight)));
            IPhysics leftWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(-boundarySize + 90, -boundarySize)));
            IPhysics rightWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(levelWidth - 90, -boundarySize)));

            topWallCollider = new BoxCollider(levelWidth + 2 * boundarySize, boundarySize, topWallPhysics, null, this);
            //bottomWallCollider = new BoxCollider(levelWidth + 2 * boundarySize, boundarySize, bottomWallPhysics, null, this);
            leftWallCollider = new BoxCollider(boundarySize, levelHeight + 2 * boundarySize, leftWallPhysics, null, this);
            rightWallCollider = new BoxCollider(boundarySize, levelHeight + 2 * boundarySize, rightWallPhysics, null, this);

            this.collisionController.AddCollider(topWallCollider);
            //this.collisionController.AddCollider(bottomWallCollider);
            this.collisionController.AddCollider(leftWallCollider);
            this.collisionController.AddCollider(rightWallCollider);
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
            collisionController.RemoveCollider(topWallCollider);
            //collisionController.RemoveCollider(bottomWallCollider);
            collisionController.RemoveCollider(leftWallCollider);
            collisionController.RemoveCollider(rightWallCollider);
        }
    }
}
