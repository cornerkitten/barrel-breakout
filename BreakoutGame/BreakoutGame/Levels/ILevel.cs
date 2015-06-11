using Mabv.Breakout.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Levels
{
    public interface ILevel
    {
        void Start();
        void Restart();
        void Quit();
        void ChangeToGameOver();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
