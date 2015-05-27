using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public static class Textures
    {
        public static Texture2D RotatingBarrel { get; set; }
        public static Texture2D RotatingDonkeyKong { get; set; }
        public static Texture2D SmokeExplosion { get; set; }

        public static void LoadContent(ContentManager content)
        {
            RotatingBarrel = content.Load<Texture2D>("dkc-barrel-rotation");
            RotatingDonkeyKong = content.Load<Texture2D>("dkc-donkey-kong-rotation");
            SmokeExplosion = content.Load<Texture2D>("dkc-smoke-explosion");
        }
    }
}
