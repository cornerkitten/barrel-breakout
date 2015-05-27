﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class AnimatedSprite : ISprite
    {
        private int currentFrame;
        private int totalFrames;
        private int nextFrameCounter;
        private int nextFrameThreshold;
        private int textureRows;
        private int textureColumns;
        private Texture2D texture;
        private IBehavior attachedBehavior;

        public AnimatedSprite(Texture2D texture, int textureRows, int textureColumns, int nextFrameThreshold = 5, IBehavior attachedBehavior = null)
        {
            this.texture = texture;
            this.currentFrame = 0;
            this.nextFrameCounter = 0;
            this.nextFrameThreshold = nextFrameThreshold;
            this.textureRows = textureRows;
            this.textureColumns = textureColumns;
            this.totalFrames = this.textureColumns;
            this.attachedBehavior = attachedBehavior;
        }

        public void Update()
        {
            nextFrameCounter++;
            if (nextFrameCounter == nextFrameThreshold)
            {
                currentFrame++;
                nextFrameCounter = 0;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                if (attachedBehavior != null)
                {
                    attachedBehavior.OnAnimationEnd();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = texture.Width / textureColumns;
            int height = texture.Height / textureRows;
            int row = (int)((float)currentFrame / (float)textureColumns);
            int column = currentFrame % textureColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}