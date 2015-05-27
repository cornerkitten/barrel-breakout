using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.GameEntities
{
    public interface IGameEntity
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
