using Mabv.Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class HudCounter : IEntity
    {
        public int Count
        {
            get { return count; }
            set {
                displayedCount = count;
                count = value;
            }
        }
        public ISprite IconSprite
        {
            get { return iconSprite; }
            set { iconSprite = value; }
        }
        private ITransform transform;
        private LinearTween locationTween;
        private int count;
        private ISprite iconSprite;
        private int displayedCount;
        private BasicTimer timer;

        public HudCounter(Vector2 location, Vector2 hiddenLocation, int initialCount, ISprite iconSprite)
        {
            this.transform = new Transform(location);
            this.locationTween = new LinearTween(this.transform, 0.1f, location, hiddenLocation);
            this.count = initialCount;
            this.iconSprite = iconSprite;
            this.displayedCount = this.count;

            this.locationTween.Init();
            this.timer = new BasicTimer(3);
        }

        public void Update()
        {
            if (timer.IsRinging())
            {
                countTowardScore();
            }

            if (displayedCount != count && !timer.IsTiming())
            {
                timer.Start();
            }

            locationTween.Update();
            iconSprite.Update();
            timer.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.Banana, displayedCount.ToString(), transform.Location + new Vector2(iconSprite.Width + 6, 0), Color.White);
            spriteBatch.End();

            iconSprite.Draw(spriteBatch, transform.Location + new Vector2(0, -4));
        }

        public void Destroy()
        {

        }

        public void Show()
        {
            locationTween.MoveToStart();
        }

        public void Hide()
        {
            locationTween.MoveToEnd();
        }

        private void countTowardScore()
        {
            if (displayedCount < count)
            {
                displayedCount++;
            }
            else if (displayedCount > count)
            {
                displayedCount--;
            }
        }
    }
}
