using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class Fonts
    {
        public static SpriteFont Banana { get { return banana; } }
        private static SpriteFont banana;

        public static void LoadContent(ContentManager content)
        {
            banana = content.Load<SpriteFont>("dkc-banana-font");
        }
    }
}
