using Mabv.Breakout.Behaviors;
using Mabv.Breakout.Collisions;
using Mabv.Breakout.Levels;
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
    public class DonkeyKong : IEntity
    {
        public ITransform Transform { get { return transform; } }
        private ITransform transform;
        private Player player;
        private ILevel level;
        private CollisionController collisionController;
        private ISprite sprite;
        private IPhysics physics;
        private ICollider collider;
        private IBehavior behavior;

        public DonkeyKong(Vector2 location, Player player, ILevel level, CollisionController collisionController)
        {
            this.transform = new Transform(location);
            this.player = player;
            this.level = level;
            this.collisionController = collisionController;
            this.physics = new RigidBodyPhysics(this.transform);
            this.physics.Velocity = new Vector2(3, -3);
            this.sprite = new AnimatedSprite(Textures.RotatingDonkeyKong, 1, 16, 2);
            this.behavior = new DonkeyKongBehavior(this);
            this.collider = new BoxCollider(this.sprite.Width, this.sprite.Height, this.physics, this.behavior, this);
            this.collisionController.AddCollider(this.collider);
        }

        public void Update()
        {
            physics.Update();
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, transform.Location);
        }

        public void Destroy()
        {
            collisionController.RemoveCollider(collider);
        }

        // TODO Not sure if this would be better fit in a bevior, or not
        public void Bounce(bool isHorizontalBounce, bool isVerticalBounce, float scale = 1)
        {
            if (scale != 1)
            {
                Console.WriteLine("scale by " + scale);
            }

            Vector2 newVelocity = physics.Velocity;
            if (isHorizontalBounce)
            {
                newVelocity.X *= -1f * scale;
            }
            
            if (isVerticalBounce)
            {
                newVelocity.Y *= -1f * scale;
            }

            physics.Velocity = newVelocity;
        }

        public void Bounce(float horizontalScale, float verticalScale)
        {
            if (horizontalScale != 1.0f || verticalScale != 1.0f)
            {
                Console.WriteLine("scale by " + horizontalScale + ", " + verticalScale);
            }

            float newVelocityMagnitude = physics.Velocity.Length();
            Vector2 newVelocityDirection = physics.Velocity;

            newVelocityDirection.X *= horizontalScale;
            newVelocityDirection.Y *= verticalScale;
            newVelocityDirection.Normalize();

            physics.Velocity = newVelocityDirection * newVelocityMagnitude;
        }

        public void Perish()
        {
            player.LoseLife();
            level.Restart();
        }

        public bool IsMovingLeft()
        {
            return (physics.Velocity.X < 0);
        }

        public bool IsMovingRight()
        {
            return (physics.Velocity.X > 0);
        }
    }
}
