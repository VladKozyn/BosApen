using System;
using System.Collections.Generic;
using System.Text;

namespace BosApen
{
    public class Bitmap
    {
        int width { get; set; }
        int height { get; set; }
        public Bitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
