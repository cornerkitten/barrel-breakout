using Mabv.Breakout.Collisions;
using Mabv.Breakout.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.GameEntities
{
    public class LevelBoundary : IGameEntity
    {
        public LevelBoundary(BreakoutGame game)
        {
            int levelWidth = 800;
            int levelHeight = 600;
            int boundarySize = 64;
            
            IPhysics topWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(-boundarySize, -boundarySize)));
            IPhysics leftWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(-boundarySize + 90, -boundarySize)));
            IPhysics rightWallPhysics = new RigidBodyPhysics(new Transform(new Vector2(levelWidth - 90, -boundarySize)));

            ICollider topWallCollider = new BoxCollider(levelWidth + 2 * boundarySize, boundarySize, topWallPhysics, null, this);
            ICollider leftWallCollider = new BoxCollider(boundarySize, levelHeight + 2 * boundarySize, leftWallPhysics, null, this);
            ICollider rightWallCollider = new BoxCollider(boundarySize, levelHeight + 2 * boundarySize, rightWallPhysics, null, this);
            
            game.CollisionController.AddCollider(topWallCollider);
            game.CollisionController.AddCollider(leftWallCollider);
            game.CollisionController.AddCollider(rightWallCollider);
        }

        public void Update()
        {
            // do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // do nothing
        }
    }
}
