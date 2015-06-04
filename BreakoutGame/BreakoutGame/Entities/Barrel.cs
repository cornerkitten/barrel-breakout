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
    public class Barrel : IEntity
    {
        private IPhysics physics;
        private ISprite sprite;
        private ICollider collider;
        private ITransform transform;
        private IBehavior behavior;
        private EntityController entityController;
        private CollisionController collisionController;

        public Barrel(Vector2 location, EntityController entityController, CollisionController collisionController)
        {
            this.transform = new Transform(location);
            this.entityController = entityController;
            this.collisionController = collisionController;
            this.physics = new RigidBodyPhysics(this.transform);
            this.behavior = new BarrelBehavior(this);
            this.sprite = new AnimatedSprite(Textures.RotatingBarrel, 1, 5, 4, null, true);
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

        public void Explode()
        {
            sprite = new AnimatedSprite(Textures.SmokeExplosion, 1, 8, 2, behavior);
            SoundEffects.BarrelBreak.Play();
            //game.IncreaseScore();
            collisionController.RemoveCollider(collider);
        }

        public void Destroy()
        {
            entityController.RemoveEntity(this);
        }
    }
}
