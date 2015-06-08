using Mabv.Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class Hud : IHud
    {
        HudCounter bananaHudCounter;
        HudCounter livesHudCounter;
        BasicTimer timer;

        public Hud(int initialScore, int initialLives, View view)
        {
            ISprite bananaSprite = new AnimatedSprite(Textures.RotatingBanana, 1, 8);
            ISprite balloonSprite = new AnimatedSprite(Textures.LivesBalloon, 1, 14);
            this.bananaHudCounter = new HudCounter(new Vector2(100 + 16, view.Height - 48), new Vector2(100 + 16, view.Height + 8), initialScore, bananaSprite);
            this.livesHudCounter = new HudCounter(new Vector2(view.Width - 100 - 72, view.Height - 48), new Vector2(view.Width - 100 - 72, view.Height + 8), initialLives, balloonSprite);

            this.timer = new BasicTimer(60);
            this.timer.Start();
        }

        public void Update()
        {
            if (timer.IsRinging())
            {
                bananaHudCounter.Hide();
                livesHudCounter.Hide();
            }
            
            bananaHudCounter.Update();
            livesHudCounter.Update();
            timer.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bananaHudCounter.Draw(spriteBatch);
            livesHudCounter.Draw(spriteBatch);
        }

        public void Destroy()
        {
            // no-op
        }

        public void IncreaseScore(int scoreIncrement)
        {
            bananaHudCounter.Count += scoreIncrement;
            bananaHudCounter.Show();
            timer.Start();
        }

        public void LoseLife()
        {
            livesHudCounter.Count++;
            livesHudCounter.Show();
            timer.Start();
        }
    }
}
