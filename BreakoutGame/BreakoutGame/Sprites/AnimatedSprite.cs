using Mabv.Breakout.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Sprites
{
    public class AnimatedSprite : ISprite
    {
        private static Random random;
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        private int currentFrame;
        private int totalFrames;
        private int nextFrameCounter;
        private int nextFrameThreshold;
        private int textureRows;
        private int textureColumns;
        private Texture2D texture;
        private IBehavior attachedBehavior;
        private bool isLooping;
        private bool isAnimating;
        private int width;
        private int height;

        public AnimatedSprite(Texture2D texture, int textureRows, int textureColumns, int nextFrameThreshold = 5, IBehavior attachedBehavior = null, bool hasRandomStartFrame = false, bool isLooping = true)
        {
            this.texture = texture;
            this.currentFrame = 0;
            this.nextFrameCounter = 0;
            this.nextFrameThreshold = nextFrameThreshold;
            this.textureRows = textureRows;
            this.textureColumns = textureColumns;
            this.totalFrames = this.textureColumns;
            this.attachedBehavior = attachedBehavior;
            this.isLooping = isLooping;
            this.isAnimating = true;
            this.width = texture.Width / textureColumns;
            this.height = texture.Height / textureRows;

            if (AnimatedSprite.random == null)
            {
                AnimatedSprite.random = new Random();
            }

            if (hasRandomStartFrame)
            {
                this.currentFrame = AnimatedSprite.random.Next(0, this.totalFrames);
            }
        }

        public void Update()
        {
            if (isAnimating)
            {
                nextFrameCounter++;
            }
            
            if (nextFrameCounter == nextFrameThreshold)
            {
                currentFrame++;
                nextFrameCounter = 0;
            }

            if (currentFrame == totalFrames)
            {
                if (isLooping)
                {
                    currentFrame = 0;
                }
                else
                {
                    currentFrame--;
                    isAnimating = false;
                }

                if (attachedBehavior != null)
                {
                    attachedBehavior.OnAnimationEnd();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)textureColumns);
            int column = currentFrame % textureColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float rotation)
        {
            int row = (int)((float)currentFrame / (float)textureColumns);
            int column = currentFrame % textureColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            Vector2 origin = new Vector2(destinationRectangle.Width / 2, destinationRectangle.Height / 2);
            destinationRectangle.X += (int)origin.X;
            destinationRectangle.Y += (int)origin.Y;

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, rotation, origin, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
