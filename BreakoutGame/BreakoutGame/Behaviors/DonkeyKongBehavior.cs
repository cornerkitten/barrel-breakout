using Mabv.Breakout.Collisions;
using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public class DonkeyKongBehavior : Behavior
    {
        DonkeyKong donkeyKong;

        public DonkeyKongBehavior(DonkeyKong donkeyKong)
        {
            this.donkeyKong = donkeyKong;
        }

        override public void OnCollisionEnter(ICollision collision)
        {
            Console.WriteLine("DonkeyKongBehavior.OnCollisionEnter");

            if (collision.Collider.AttachedGameEntity is Paddle)
            {
                Paddle paddle = (Paddle)(collision.Collider.AttachedGameEntity);
                if (donkeyKong.Transform.Location.X < paddle.Transform.Location.X)
                {
                    donkeyKong.PaddleBounce(-1);
                }
                else
                {
                    donkeyKong.PaddleBounce(1);
                }
            }
            else
            {
                donkeyKong.Bounce();
            }
        }
    }
}
