using Mabv.Breakout.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Commands
{
    public class RestartLevelCommand : ICommand
    {
        private ILevel level;

        public RestartLevelCommand(ILevel level)
        {
            this.level = level;
        }

        public void Execute()
        {
            level.Restart();
        }
    }
}
