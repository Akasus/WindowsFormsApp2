using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Boundings
    {
        public Vector2 Max;
        public Vector2 Min;

        public static implicit operator RectangleF(Boundings b) => new RectangleF(b.Min.x,b.Min.y,Math.Abs( b.Min.x - b.Max.x),Math.Abs(b.Min.y - b.Max.y));
    }
}
