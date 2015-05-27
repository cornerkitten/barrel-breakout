using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Physics
{
    public class DonkeyKongPhysics : IPhysics
    {
        public Vector2 Velocity { get; set; }
        private Rectangle locationBoundary;
        //private SpriteEffects spriteEffect;
        //private Rectangle boundingBox;
        private ITransform transform;
        public ITransform Transform { get { return transform; } }

        public DonkeyKongPhysics(ITransform transform, Vector2 velocity)
        {
            this.transform = transform;
            this.Velocity = velocity;
            this.locationBoundary = new Rectangle(0, 0, 640, 480);
            //this.spriteEffect = SpriteEffects.None;
            //this.boundingBox = new Rectangle(0, 0, 45, 45);
        }

        public void Update()
        {
            // TODO remove
            Rectangle boundingBox = new Rectangle(0, 0, 45, 45);

            transform.Location += Velocity;

            if (transform.Location.X < locationBoundary.Left)
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
                //spriteEffect = spriteEffect ^ SpriteEffects.FlipHorizontally;
            }
            if (transform.Location.X + boundingBox.Width > locationBoundary.Right)
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
                //spriteEffect = spriteEffect ^ SpriteEffects.FlipHorizontally;
            }
            if (transform.Location.Y < locationBoundary.Top)
            {
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
                //spriteEffect = spriteEffect ^ SpriteEffects.FlipVertically;
            }
            if (transform.Location.Y + boundingBox.Height > locationBoundary.Bottom)
            {
                Velocity = new Vector2(Velocity.X, -this.Velocity.Y);
                //spriteEffect = spriteEffect ^ SpriteEffects.FlipVertically;
            }
        }
    }
}
