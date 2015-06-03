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
                    donkeyKong.Bounce(-1, -1);
                }
                else if (collision.Overlap.X != 0)
                {
                    donkeyKong.Bounce(-1, 1);
                }
                else
                {
                    ICollider dkCollider = collision.ReactingCollider;
                    ICollider paddleCollider = collision.Collider;
                    float xScale = 1;
                    float yScale = -1;

                    if (paddleCollider.Centroid.X > dkCollider.Centroid.X && donkeyKong.IsMovingRight())
                    {
                        xScale *= -1;
                    }
                    else if (paddleCollider.Centroid.X < dkCollider.Centroid.X && donkeyKong.IsMovingLeft())
                    {
                        xScale *= -1;
                    }

                    if (dkCollider.Centroid.X > paddleCollider.Centroid.X - paddleCollider.Width / 2 && dkCollider.Centroid.X < paddleCollider.Centroid.X + paddleCollider.Width / 2)
                    {
                        Vector2 dkVelocity = dkCollider.Physics.Velocity;

                        if (Math.Abs(dkVelocity.X) > Math.Abs(dkVelocity.Y))
                        {
                            xScale *= 0.5f;
                        }
                        else
                        {
                            xScale *= 2.0f;
                        }
                    }

                    donkeyKong.Bounce(xScale, yScale);
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
