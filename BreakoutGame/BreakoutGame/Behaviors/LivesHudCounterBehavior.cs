using Mabv.Breakout.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Behaviors
{
    public class LivesHudCounterBehavior : Behavior
    {
        private HudCounter livesHudCounter;

        public LivesHudCounterBehavior(HudCounter livesHudCounter)
        {
            this.livesHudCounter = livesHudCounter;
        }

        public override void OnAnimationEnd()
        {
            livesHudCounter.Count--;

            base.OnAnimationEnd();
        }
    }
}
