using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class View
    {
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        private int width;
        private int height;

        public View(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
