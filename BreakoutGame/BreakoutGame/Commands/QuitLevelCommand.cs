using Mabv.Breakout.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Commands
{
    public class QuitLevelCommand : ICommand
    {
        private ILevel level;

        public QuitLevelCommand(ILevel level)
        {
            this.level = level;
        }

        public void Execute()
        {
            level.Quit();
        }
    }
}
