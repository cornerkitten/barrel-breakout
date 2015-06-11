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
        public static SoundEffect CollectBananaBunch { get { return collectBananaBunch; } }
        public static SoundEffect BarrelBounce { get { return barrelBounce; } }
        public static SoundEffect BalloonPop { get { return balloonPop; } }
        private static SoundEffect barrelBreak;
        private static SoundEffect collectBananaBunch;
        private static SoundEffect barrelBounce;
        private static SoundEffect balloonPop;

        public static void LoadContent(ContentManager content)
        {
            barrelBreak = content.Load<SoundEffect>("sfx/dkc-barrel-blast-barrel");
            collectBananaBunch = content.Load<SoundEffect>("sfx/dkc2-collect-banana-bunch");
            barrelBounce = content.Load<SoundEffect>("sfx/dkc-barrel-bounce");
            balloonPop = content.Load<SoundEffect>("sfx/balloon-pop");
        }
    }
}
