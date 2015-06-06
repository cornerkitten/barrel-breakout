using Mabv.Breakout.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class Player
    {
        public int Score { get { return score; } }
        public int Lives { get { return lives; } }
        public IHud Hud { get; set; }
        private const int ScoreIncrement = 10;
        private int score;
        private int lives;

        public Player()
        {
            this.score = 0;
            this.lives = 3;
        }

        public void IncreaseScore()
        {
            score += ScoreIncrement;

            if (Hud != null)
            {
                Hud.IncreaseScore(ScoreIncrement);
            }
        }

        public void LoseLife()
        {
            if (lives > 0)
            {
                this.lives--;

                if (Hud != null)
                {
                    Hud.LoseLife();
                }
            }
        }
    }
}
