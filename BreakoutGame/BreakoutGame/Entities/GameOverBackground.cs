using Mabv.Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class GameOverBackground : IEntity
    {
        private ISprite sprite;

        public GameOverBackground()
        {
            this.sprite = new AnimatedSprite(Textures.GameOverBackground, 1, 1);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch, Vector2.Zero);
        }

        public void Destroy()
        {
            // no-op
        }
    }
}
