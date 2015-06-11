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
        public static Texture2D RotatingBarrel { get { return rotatingBarrel; } }
        public static Texture2D RotatingDonkeyKong { get { return rotatingDonkeyKong; } }
        public static Texture2D SmokeExplosion { get { return smokeExplosion; } }
        public static Texture2D PlatformUp { get { return platformUp; } }
        public static Texture2D BananaBunch { get { return bananaBunch; } }
        public static Texture2D LivesBalloon { get { return livesBalloon; } }
        public static Texture2D LivesBalloonPopping { get { return livesBalloonPopping; } }
        public static Texture2D RotatingBanana { get { return rotatingBanana; } }
        public static Texture2D JungleBackground { get { return jungleBackground; } }
        public static Texture2D GameOverBackground { get { return gameOverBackground; } }
        private static Texture2D rotatingBarrel;
        private static Texture2D rotatingDonkeyKong;
        private static Texture2D smokeExplosion;
        private static Texture2D platformUp;
        private static Texture2D bananaBunch;
        private static Texture2D livesBalloon;
        private static Texture2D livesBalloonPopping;
        private static Texture2D rotatingBanana;
        private static Texture2D jungleBackground;
        private static Texture2D gameOverBackground;

        public static void LoadContent(ContentManager content)
        {
            rotatingBarrel = content.Load<Texture2D>("textures/dkc-barrel-rotation");
            rotatingDonkeyKong = content.Load<Texture2D>("textures/dkc-donkey-kong-rotation-bordered");
            smokeExplosion = content.Load<Texture2D>("textures/dkc-smoke-explosion");
            //PlatformUp = content.Load<Texture2D>("textures/dkc-platform-up");
            platformUp = content.Load<Texture2D>("textures/barrel-paddle");
            bananaBunch = content.Load<Texture2D>("textures/dkc-banana-bunch");
            livesBalloon = content.Load<Texture2D>("textures/dkc-dk-lives-balloon");
            livesBalloonPopping = content.Load<Texture2D>("textures/dkc-dk-lives-balloon-popping");
            rotatingBanana = content.Load<Texture2D>("textures/dkc-rotating-banana");
            jungleBackground = content.Load<Texture2D>("textures/backgrounds/dkc-jungle");
            gameOverBackground = content.Load<Texture2D>("textures/backgrounds/dkc-game-over");
        }
    }
}
