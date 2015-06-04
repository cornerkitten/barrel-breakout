using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class Player
    {
        private const int ScoreIncrement = 10;
        public Hud Hud { get; set; }
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
