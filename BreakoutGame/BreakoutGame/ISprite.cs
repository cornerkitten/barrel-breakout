using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
