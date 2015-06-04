using Mabv.Breakout.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Commands
{
    public class MoveUpCommand : ICommand
    {
        private Paddle paddle;

        public MoveUpCommand(Paddle paddle)
        {
            this.paddle = paddle;
        }

        public void Execute()
        {
            paddle.MoveUp();
        }
    }
}
