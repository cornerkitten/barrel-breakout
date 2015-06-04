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
        public Hud Hud { get; set; }
        private const int ScoreIncrement = 10;
        private int score;

        public Player()
        {
            this.score = 0;
        }

        public void IncreaseScore()
        {
            score += ScoreIncrement;

            if (Hud != null)
            {
                Hud.IncreaseScore(ScoreIncrement);
            }
        }
    }
}
