using Mabv.Breakout.Collisions;
using Mabv.Breakout.Entities;
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

            if (collision.Collider.AttachedGameEntity is DonkeyKong)
            {
                float wobbleMagnitude = (collision.ReactingCollider.Centroid.X - collision.Collider.Centroid.X) / (collision.ReactingCollider.Width / 2);

                paddle.Wobble(-wobbleMagnitude * 10.0f * (float)(Math.PI / 60.0f));
            }
        }
    }
}
