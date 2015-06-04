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
    public class BananaBunch : IGameEntity
    {
        private BreakoutGame game;
        private Player player;
        private ISprite sprite;
        private ITransform transform;
        private ICollider collider;
        private IPhysics physics;
        private IBehavior behavior;

        public BananaBunch(BreakoutGame game, Player player, Vector2 location)
        {
            this.game = game;
            this.player = player;
            this.transform = new Transform(location);
            this.sprite = new AnimatedSprite(Textures.BananaBunch, 1, 10, 3, null, false);
            this.physics = new RigidBodyPhysics(this.transform);
            this.behavior = new BananaBunchBehavior(this);
            this.collider = new BoxCollider(this.sprite.Width, this.sprite.Height, this.physics, this.behavior, this);
            this.game.CollisionController.AddCollider(this.collider);
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
            SoundEffects.CollectBananaBunch.Play(0.8f, 0.2f, 0.0f);
            player.IncreaseScore();

            game.CollisionController.RemoveCollider(collider);
            game.GameEntityController.RemoveGameEntity(this);
        }
    }
}
