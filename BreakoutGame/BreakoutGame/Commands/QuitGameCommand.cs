using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Commands
{
    public class QuitGameCommand : ICommand
    {
        private Game game;

        public QuitGameCommand(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
