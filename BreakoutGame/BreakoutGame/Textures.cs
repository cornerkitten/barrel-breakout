using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public static class Textures
    {
        public static Texture2D RotatingBarrel { get; set; }
        public static Texture2D RotatingDonkeyKong { get; set; }
        public static Texture2D SmokeExplosion { get; set; }
        public static Texture2D PlatformUp { get; set; }
        public static Texture2D BananaBunch { get; set; }
        public static Texture2D JungleBackground { get; set; }

        public static void LoadContent(ContentManager content)
        {
            RotatingBarrel = content.Load<Texture2D>("textures/dkc-barrel-rotation");
            RotatingDonkeyKong = content.Load<Texture2D>("textures/dkc-donkey-kong-rotation");
            SmokeExplosion = content.Load<Texture2D>("textures/dkc-smoke-explosion");
            PlatformUp = content.Load<Texture2D>("textures/dkc-platform-up");
            BananaBunch = content.Load<Texture2D>("textures/dkc-banana-bunch");
            JungleBackground = content.Load<Texture2D>("textures/backgrounds/dkc-jungle");
        }
    }
}
