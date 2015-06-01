using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.GameEntities
{
    public class Hud : IGameEntity
    {
        private BreakoutGame game;
        private int score;
        private int displayedScore;
        private int displayUpdateCounter;
        private int nextDisplayUpdateThreshold;
        private Vector2 scoreLocation;
        private Vector2 visibleScoreLocation;
        private Vector2 hiddenScoreLocation;
        private bool isBecomingVisible;
        private bool isBecomingHidden;
        private int hideCounter;

        public Hud(BreakoutGame game)
        {
            this.game = game;
            this.score = 0;
            this.displayUpdateCounter = 0;
            this.nextDisplayUpdateThreshold = 3;
            this.visibleScoreLocation = new Vector2(100 + 16, 600 - 48);
            this.hiddenScoreLocation = new Vector2(100 + 16, 600 + 8);
            this.isBecomingVisible = false;
            this.isBecomingHidden = false;
            this.hideCounter = 0;
            this.displayedScore = this.score;
            this.scoreLocation = this.hiddenScoreLocation;
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.Banana, displayedScore.ToString(), scoreLocation, Color.White);
            spriteBatch.End();
        }

        public void IncreaseScore(int scoreIncrement)
        {
            displayedScore = score;
            score += scoreIncrement;
            isBecomingVisible = true;
        }
    }
}
