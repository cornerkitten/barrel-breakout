using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class MoveDownCommand : ICommand
    {
        private Paddle paddle;

        public MoveDownCommand(Paddle paddle)
        {
            this.paddle = paddle;
        }

        public void Execute()
        {
            paddle.MoveDown();
        }
    }
}
