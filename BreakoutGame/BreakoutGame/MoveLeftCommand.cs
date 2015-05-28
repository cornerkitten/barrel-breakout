using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class MoveLeftCommand : ICommand
    {
        private Paddle paddle;

        public MoveLeftCommand(Paddle paddle)
        {
            this.paddle = paddle;
        }

        public void Execute()
        {
            paddle.MoveLeft();
        }
    }
}
