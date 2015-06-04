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
    public class BananaBunch : IEntity
    {
        private Player player;
        private EntityController entityController;
        private CollisionController collisionController;
        private ISprite sprite;
        private ITransform transform;
        private ICollider collider;
        private IPhysics physics;
        private IBehavior behavior;

        public BananaBunch(Vector2 location, Player player, EntityController entityController, CollisionController collisionController)
        {
            this.transform = new Transform(location);
            this.player = player;
            this.entityController = entityController;
            this.collisionController = collisionController;
            this.sprite = new AnimatedSprite(Textures.BananaBunch, 1, 10, 3, null, false);
            this.physics = new RigidBodyPhysics(this.transform);
            this.behavior = new BananaBunchBehavior(this);
            this.collider = new BoxCollider(this.sprite.Width, this.sprite.Height, this.physics, this.behavior, this);
            collisionController.AddCollider(this.collider);
        }

        public void Update()
        {
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

        public void BecomeCollected()
        {
            SoundEffects.CollectBananaBunch.Play(0.8f, 0.2f, 0.0f);
            player.IncreaseScore();
            Destroy();
            entityController.RemoveEntity(this);
        }
    }
}
