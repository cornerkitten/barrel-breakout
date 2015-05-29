using Mabv.Breakout.Behaviors;
using Mabv.Breakout.Collisions;
using Mabv.Breakout.Physics;
using Mabv.Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.GameEntities
{
    public class Paddle : IGameEntity
    {
        public ITransform Transform { get { return transform; } }
        private IPhysics physics;
        private ISprite sprite;
        private ICollider collider;
        private ITransform transform;
        private BreakoutGame game;
        private IBehavior behavior; 

        public Paddle(BreakoutGame game, Vector2 location)
        {
            this.game = game;
            this.transform = new Transform(location);
            this.physics = new RigidBodyPhysics(this.transform);
            this.sprite = new AnimatedSprite(Textures.PlatformUp, 1, 1);
            this.behavior = new PaddleBehavior(this);
            this.collider = new BoxCollider(this.sprite.Width, this.sprite.Height, this.physics, this.behavior, this);
            this.game.CollisionController.AddCollider(this.collider);
        }

        public void Update()
        {
            physics.Update();
            sprite.Update();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.transform.Location);
        }

        public void MoveLeft()
        {
            this.physics.Velocity = new Vector2(-12, 0);
            //this.physics.Velocity = new Vector2(-3, 0);
        }

        public void MoveRight()
        {
            this.physics.Velocity = new Vector2(12, 0);
            //this.physics.Velocity = new Vector2(3, 0);
        }

        public void MoveUp()
        {
            this.physics.Velocity = new Vector2(0, -3);
        }

        public void MoveDown()
        {
            this.physics.Velocity = new Vector2(0, 3);
        }

        public void StopMoving()
        {
            this.physics.Velocity = new Vector2(0, 0);
        }
    }
}
