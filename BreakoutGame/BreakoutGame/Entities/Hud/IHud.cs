using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public interface IHud : IEntity
    {
        void IncreaseScore(int scoreIncrement);
        void LoseLife();
    }
}
