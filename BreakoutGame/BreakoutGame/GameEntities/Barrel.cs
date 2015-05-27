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
    public class Barrel : IGameEntity
    {
        private IPhysics physics;
        private ISprite sprite;
        private ICollider collider;
        private ITransform transform;
        private IBehavior behavior;
        private BreakoutGame game;

        public Barrel(BreakoutGame game, Vector2 location)
        {
            this.game = game;
            this.transform = new Transform(location);
            this.physics = new BarrelPhysics(this.transform);
            this.behavior = new BarrelBehavior(this);
            this.sprite = new AnimatedSprite(Textures.RotatingBarrel, 1, 5, 5);
            this.collider = new BoxCollider(32, 32, this.physics, this.behavior);
            this.game.CollisionController.AddCollider(this.collider);
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
            sprite = new AnimatedSprite(Textures.SmokeExplosion, 1, 8, 3, behavior);
            game.CollisionController.RemoveCollider(collider);
        }

        public void Destroy()
        {
            game.GameEntityController.RemoveGameEntity(this);
        }
    }
}
