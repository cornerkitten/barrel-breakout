using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class SoundEffects
    {
        public static SoundEffect BarrelBreak { get { return barrelBreak; } }
        private static SoundEffect barrelBreak;

        public static void LoadContent(ContentManager content)
        {
            barrelBreak = content.Load<SoundEffect>("dkc-barrel-blast-barrel");
        }
    }
}
