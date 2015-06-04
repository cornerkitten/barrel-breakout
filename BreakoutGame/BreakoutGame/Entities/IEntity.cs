using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public interface IEntity
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void Destroy();
    }
}
