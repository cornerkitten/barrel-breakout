using Mabv.Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class JungleBackground : IEntity
    {
        private ISprite sprite;

        public JungleBackground()
        {
            this.sprite = new AnimatedSprite(Textures.JungleBackground, 1, 1);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch, Vector2.Zero);
        }
    }
}
