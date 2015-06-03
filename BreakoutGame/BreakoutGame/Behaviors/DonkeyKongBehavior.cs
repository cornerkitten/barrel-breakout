using Mabv.Breakout.Collisions;
using Mabv.Breakout.GameEntities;
using Mabv.Breakout.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public class DonkeyKongBehavior : Behavior
    {
        private static Random random = new Random();
        private DonkeyKong donkeyKong;

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
                SoundEffects.BarrelBounce.Play(1.0f, 1.0f, 0.0f);
            }
            else if (collision.Collider.AttachedGameEntity is LevelBoundary)
            {
                SoundEffects.BarrelBounce.Play(0.75f, 0.0f, 0.0f);
            }

            if (collision.Collider.AttachedGameEntity is Paddle)
            {
                Paddle paddle = (Paddle)(collision.Collider.AttachedGameEntity);
                
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
                    //float horizontalScale = 0.5f + Math.Abs( (collision.ReactingCollider.Centroid.X - collision.Collider.Centroid.X) / (collision.Collider.Width / 2) );

                    int partition = 0;
                    ICollider dkCollider = collision.ReactingCollider;
                    ICollider paddleCollider = collision.Collider;

                    //if (dkCollider.Centroid.X < paddleCollider.Centroid.X - paddleCollider.Width / 2)

                    if (collision.Collider.Centroid.X > collision.ReactingCollider.Centroid.X && donkeyKong.IsMovingRight())
                    {
                        donkeyKong.Bounce(-1, -1);
                    }
                    else if (collision.Collider.Centroid.X < collision.ReactingCollider.Centroid.X && donkeyKong.IsMovingLeft())
                    {
                        donkeyKong.Bounce(-1, -1);
                    }
                    else if (dkCollider.Centroid.X > paddleCollider.Centroid.X - paddleCollider.Width / 2 && dkCollider.Centroid.X < paddleCollider.Centroid.X + paddleCollider.Width / 2)
                    {
                        /*
                        int randomNumber = random.Next(0, 2);
                        if (randomNumber == 0)
                        {
                            donkeyKong.Bounce(0.5f, -1);
                        }
                        else
                        {
                            donkeyKong.Bounce(2.0f, -1);
                        }
                         */
                        Vector2 dkVelocity = dkCollider.Physics.Velocity;
 
                        if (Math.Abs(dkVelocity.X) > Math.Abs(dkVelocity.Y))
                        {
                            donkeyKong.Bounce(0.5f, -1);
                        }
                        else
                        {
                            donkeyKong.Bounce(2.0f, -1);
                        }
                    }
                    else
                    {
                        donkeyKong.Bounce(1, -1);
                    }
                }
            }
            else if (!(collision.Collider.AttachedGameEntity is BananaBunch))
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
