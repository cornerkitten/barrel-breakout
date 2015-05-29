using Mabv.Breakout.Collisions;
using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public class PaddleBehavior : Behavior
    {
        private Paddle paddle;

        public PaddleBehavior(Paddle paddle)
        {
            this.paddle = paddle;
        }

        override public void OnCollisionEnter(ICollision collision)
        {
            //Console.WriteLine("PaddleBehavior.OnCollisionEnter");
            
            if (collision.Collider.AttachedGameEntity is LevelBoundary)
            {
                paddle.Transform.Location += collision.Overlap;
                paddle.StopMoving();
            }
        }
    }
}
