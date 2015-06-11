using Mabv.Breakout.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Commands
{
    public class GameOverCommand : ICommand
    {
        private ILevel level;

        public GameOverCommand(ILevel level)
        {
            this.level = level;
        }

        public void Execute()
        {
            level.ChangeToGameOver();
        }
    }
}
