using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class Circl
    {


        public Vector2 velocity = Vector2.zero;

        public Vector2 Center
        {
            get => _center;

            set
            {
                _center = value;
            }
        }



        Vector2 _center;
        public float Radius;
        
        
        public Pen pen;

        public Boundings bounds
        {
            get
            {
                var b0 = _center - Vector2.one * Radius;
                var b1 = _center + Vector2.one * Radius;
                return new Boundings
                {
                    Max = { x = Math.Max(b0.x, b1.x), y = Math.Max(b0.y, b1.y)},
                    Min = { x = Math.Min(b0.x, b1.x), y = Math.Min(b0.y, b1.y) }
                };
            }
            
        }





        public Circl(Vector2 center, float radius, Pen pen)
        {
            _center = center;
            Radius = radius;
            this.pen = pen;
        }

        

        public void Render()
        {
            var gfx = Program.graphics;
                var boundsBrush = new Pen(new SolidBrush(Color.GreenYellow),1);

                gfx.DrawLine(boundsBrush, bounds.Max, new PointF(bounds.Max.x, bounds.Min.y));
                gfx.DrawLine(boundsBrush, bounds.Min, new PointF(bounds.Max.x, bounds.Min.y));
                gfx.DrawLine(boundsBrush, bounds.Max, new PointF(bounds.Min.x, bounds.Max.y));
                gfx.DrawLine(boundsBrush, bounds.Min, new PointF(bounds.Min.x, bounds.Max.y));
                gfx.DrawEllipse(pen,bounds);
            

        }

    }
}
