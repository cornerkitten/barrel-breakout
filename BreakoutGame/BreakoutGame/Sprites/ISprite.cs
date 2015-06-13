using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Sprites
{
    public interface ISprite
    {
        int Height { get; }
        int Width { get; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location, float rotation);
    }
}
