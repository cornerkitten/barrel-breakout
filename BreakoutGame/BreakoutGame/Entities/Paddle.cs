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

namespace Mabv.Breakout.Entities
{
    public class Paddle : IEntity
    {
        public ITransform Transform { get { return transform; } }
        private ITransform transform;
        private CollisionController collisionController;
        private IPhysics physics;
        private ISprite sprite;
        private ICollider collider;
        private IBehavior behavior;
        private Vector2 spriteOrigin;
        private int wobbleCounter;
        private int wobbleEnd;
        private bool isWobbling;
        private Vector2 wobbleOffset;

        public Paddle(Vector2 location, CollisionController collisionController)
        {
            this.transform = new Transform(location);
            this.collisionController = collisionController;
            this.physics = new RigidBodyPhysics(this.transform);
            this.sprite = new AnimatedSprite(Textures.PlatformUp, 1, 1);
            this.behavior = new PaddleBehavior(this);
            this.spriteOrigin = new Vector2(0, -this.sprite.Height * .75f);
            this.collider = new BoxCollider(this.sprite.Width, (int)(this.sprite.Height * .75f), this.physics, this.behavior, this);
            this.collisionController.AddCollider(this.collider);

            this.wobbleCounter = 0;
            this.wobbleEnd = 8;
            this.isWobbling = false;
            this.wobbleOffset = new Vector2();
        }

        public void Update()
        {
            physics.Update();
            sprite.Update();

            if (isWobbling)
            {
                wobbleCounter++;
                
                if (wobbleCounter < wobbleEnd / 2)
                {
                    wobbleOffset.Y += 1.5f;
                }
                else if (wobbleCounter < wobbleEnd)
                {
                    wobbleOffset.Y -= 1.5f;
                }
                else
                {
                    wobbleOffset = Vector2.Zero;
                    isWobbling = false;
                    wobbleCounter = 0;
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, transform.Location + spriteOrigin + wobbleOffset);
        }

        public void Destroy()
        {
            collisionController.RemoveCollider(collider);
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

        public bool IsMovingLeft()
        {
            return (this.physics.Velocity.X < 0);
        }

        public bool IsMovingRight()
        {
            return (this.physics.Velocity.X > 0);
        }

        public void Wobble()
        {
            isWobbling = true;
        }
    }
}
