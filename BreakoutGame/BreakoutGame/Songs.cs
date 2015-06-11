using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class Songs
    {
        public static Song IslandSwing { get { return islandSwing; } }
        public static Song GameOver { get { return gameOver; } }
        private static Song islandSwing;
        private static Song gameOver;

        public static void LoadContent(ContentManager content)
        {
            islandSwing = content.Load<Song>("songs/dkc-island-swing");
            gameOver = content.Load<Song>("songs/dkc2-game-over");
        }
    }
}
