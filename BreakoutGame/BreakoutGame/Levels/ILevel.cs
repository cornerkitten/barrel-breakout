using Mabv.Breakout.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Levels
{
    public interface ILevel
    {
        Hud Hud { get; }
        void Start();
    }
}
