using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
    public class DonkeyKongBehavior : Behavior
    {
        DonkeyKong donkeyKong;

        public DonkeyKongBehavior(DonkeyKong donkeyKong)
        {
            this.donkeyKong = donkeyKong;
        }

        override public void OnCollisionEnter(ICollision collision)
        {
            Console.WriteLine("DonkeyKongBehavior.OnCollisionEnter");
            donkeyKong.Bounce();
        }
    }
}
