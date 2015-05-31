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
            //Console.WriteLine("DonkeyKongBehavior.OnCollisionEnter");
            donkeyKong.Transform.Location += collision.Overlap;

            if (collision.Collider.AttachedGameEntity is Paddle)
            {
                Paddle paddle = (Paddle)(collision.Collider.AttachedGameEntity);
                if (donkeyKong.Transform.Location.X < paddle.Transform.Location.X)
                {
                    //donkeyKong.PaddleBounce(-1);
                }
                else
                {
                    //donkeyKong.PaddleBounce(1);
                }


                if (collision.Overlap.X != 0 && collision.Overlap.Y != 0)
                {
                    //donkeyKong.PaddleBounce(-1, -1);
                    donkeyKong.Bounce(true, true);
                }
                else if (collision.Overlap.X != 0)
                {
                    //donkeyKong.PaddleBounce(-1, 0);
                    donkeyKong.Bounce(true, false);
                }
                else
                {
                    if (collision.Collider.Centroid.X > collision.ReactingCollider.Centroid.X && donkeyKong.IsMovingRight())
                    {
                        donkeyKong.Bounce(true, true);
                    }
                    else if (collision.Collider.Centroid.X < collision.ReactingCollider.Centroid.X && donkeyKong.IsMovingLeft())
                    {
                        donkeyKong.Bounce(true, true);
                    }
                    else
                    {
                        //donkeyKong.PaddleBounce(0, -1);
                        donkeyKong.Bounce(false, true);
                    }
                }
            }
            else
            {
                Console.WriteLine(collision.Collider.AttachedGameEntity);
                float scale = 1;
                if (collision.Collider.AttachedGameEntity is Barrel)
                {

                    Console.WriteLine("Barrel");
                    scale = 1.05f;
                }

                if (collision.Overlap.X != 0 && collision.Overlap.Y != 0)
                {
                    donkeyKong.Bounce(true, true, scale);
                }
                else if (collision.Overlap.X != 0)
                {
                    donkeyKong.Bounce(true, false, scale);
                }
                else
                {
                    donkeyKong.Bounce(false, true, scale);
                }
            }
        }
    }
}
