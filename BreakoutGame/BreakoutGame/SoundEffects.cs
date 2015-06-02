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
        public static SoundEffect CollectBananaBunch { get { return collectBananaBunch; } }
        private static SoundEffect collectBananaBunch;
        public static SoundEffect BarrelBounce { get { return barrelBounce; } }
        private static SoundEffect barrelBounce;

        public static void LoadContent(ContentManager content)
        {
            barrelBreak = content.Load<SoundEffect>("sfx/dkc-barrel-blast-barrel");
            collectBananaBunch = content.Load<SoundEffect>("sfx/dkc2-collect-banana-bunch");
            barrelBounce = content.Load<SoundEffect>("sfx/dkc-barrel-bounce");
        }
    }
}
