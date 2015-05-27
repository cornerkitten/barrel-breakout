using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class DonkeyKong : IGameEntity
    {
        private ISprite sprite;
        private IPhysics physics;
        private ICollider collider;
        private ITransform transform;
        private IBehavior behavior;

        public DonkeyKong(BreakoutGame game, Vector2 location)
        {
            this.transform = new Transform(location);
            this.physics = new DonkeyKongPhysics(this.transform, new Vector2(5, 5));
            this.sprite = new AnimatedSprite(Textures.RotatingDonkeyKong, 1, 16, 2);
            this.behavior = new DonkeyKongBehavior(this);
            this.collider = new BoxCollider(32, 32, this.physics, this.behavior);
            game.CollisionController.AddCollider(this.collider);
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

        // TODO Not sure if this would be better fit in a bevior, or not
        public void Bounce()
        {
            physics.Velocity *= -1;
        }
    }
}
