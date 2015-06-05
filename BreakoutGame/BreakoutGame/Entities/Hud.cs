using Mabv.Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class Hud : IEntity
    {
        private int score;
        private int displayedScore;
        private int displayedLives;
        private int displayUpdateCounter;
        private int nextDisplayUpdateThreshold;
        private Vector2 scoreLocation;
        private Vector2 visibleScoreLocation;
        private Vector2 hiddenScoreLocation;
        private bool isBecomingVisible;
        private bool isBecomingHidden;
        private int hideCounter;
        private ISprite livesBalloonSprite;

        public Hud(int initialScore)
        {
            this.score = initialScore;
            this.displayUpdateCounter = 0;
            this.nextDisplayUpdateThreshold = 3;
            this.visibleScoreLocation = new Vector2(100 + 16, 600 - 48);
            this.hiddenScoreLocation = new Vector2(100 + 16, 600 + 8);
            this.isBecomingVisible = true;
            this.isBecomingHidden = false;
            this.hideCounter = 0;
            this.displayedScore = this.score;
            this.scoreLocation = this.hiddenScoreLocation;
            this.livesBalloonSprite = new AnimatedSprite(Textures.LivesBalloon, 1, 14);

            this.displayedLives = 3;
        }

        public void Update()
        {
            if (displayUpdateCounter == nextDisplayUpdateThreshold)
            {
                if (displayedScore < score)
                {
                    displayedScore++;
                }
                else if (displayedScore > score)
                {
                    displayedScore--;
                }

                displayUpdateCounter = 0;
            }
            else
            {
                displayUpdateCounter++;
            }

            if (isBecomingVisible)
            {
                hideCounter = 0;
                scoreLocation += (visibleScoreLocation - hiddenScoreLocation) * .2f;
                if (scoreLocation.Y < visibleScoreLocation.Y)
                {
                    scoreLocation = visibleScoreLocation;
                    isBecomingVisible = false;
                    hideCounter = 90;
                }
            }

            if (hideCounter > 0)
            {
                hideCounter--;
                if (hideCounter == 0)
                {
                    isBecomingHidden = true;
                }
            }

            if (isBecomingHidden)
            {
                scoreLocation -= (visibleScoreLocation - hiddenScoreLocation) * .1f;
                if (scoreLocation.Y > hiddenScoreLocation.Y)
                {
                    scoreLocation = hiddenScoreLocation;
                    isBecomingHidden = false;
                }
            }

            livesBalloonSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.Banana, displayedScore.ToString(), scoreLocation, Color.White);
            spriteBatch.DrawString(Fonts.Banana, displayedLives.ToString(), new Vector2(800 - 100 - 48, scoreLocation.Y), Color.White);
            spriteBatch.End();

            livesBalloonSprite.Draw(spriteBatch, new Vector2(800 - 100 - 48 - livesBalloonSprite.Width - 8, scoreLocation.Y - 4));
        }

        public void Destroy()
        {
            // no-op
        }

        public void IncreaseScore(int scoreIncrement)
        {
            displayedScore = score;
            score += scoreIncrement;
            isBecomingVisible = true;
        }
    }
}
