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
        public static Texture2D JungleBackground { get; set; }

        public static void LoadContent(ContentManager content)
        {
            RotatingBarrel = content.Load<Texture2D>("dkc-barrel-rotation");
            RotatingDonkeyKong = content.Load<Texture2D>("dkc-donkey-kong-rotation");
            SmokeExplosion = content.Load<Texture2D>("dkc-smoke-explosion");
            PlatformUp = content.Load<Texture2D>("dkc-platform-up");
            JungleBackground = content.Load<Texture2D>("dkc-background-jungle-800_600");
        }
    }
}
