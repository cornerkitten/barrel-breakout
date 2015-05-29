using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Commands
{
    public class MoveRightCommand : ICommand
    {
        private Paddle paddle;

        public MoveRightCommand(Paddle paddle)
        {
            this.paddle = paddle;
        }

        public void Execute()
        {
            paddle.MoveRight();
        }
    }
}
