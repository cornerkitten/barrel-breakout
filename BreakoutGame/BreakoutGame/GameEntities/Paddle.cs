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
        private IPhysics physics;
        private ISprite sprite;
        private ICollider collider;
        private ITransform transform;
        private BreakoutGame game;

        public Paddle(BreakoutGame game, Vector2 location)
        {
            this.game = game;
            this.transform = new Transform(location);
            this.physics = new RigidBodyPhysics(this.transform);
            this.sprite = new AnimatedSprite(Textures.PlatformUp, 1, 1);
            this.collider = new BoxCollider(this.sprite.Width, this.sprite.Height, this.physics);
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
    }
}
