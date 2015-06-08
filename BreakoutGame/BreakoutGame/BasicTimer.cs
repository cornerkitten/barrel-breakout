using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class BasicTimer
    {
        private int targetSteps;
        private int stepCounter;
        private bool isTiming;
        private bool isRinging;

        public BasicTimer(int targetSteps)
        {
            this.targetSteps = targetSteps;
            this.stepCounter = 0;
            this.isTiming = false;
            this.isRinging = false;
        }

        public void Update()
        {
            isRinging = false;

            if (isTiming)
            {
                stepCounter++;
                if (stepCounter == targetSteps)
                {
                    startRinging();
                }
            }
        }

        public void Start()
        {
            stepCounter = 0;
            isTiming = true;
        }

        public bool IsRinging()
        {
            return isRinging;
        }

        public bool IsTiming()
        {
            return isTiming;
        }

        private void startRinging()
        {
            isRinging = true;
            isTiming = false;
        }
    }
}
