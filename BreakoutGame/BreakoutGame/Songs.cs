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
        private static Song islandSwing;

        public static void LoadContent(ContentManager content)
        {
            islandSwing = content.Load<Song>("songs/dkc-island-swing");
        }
    }
}
