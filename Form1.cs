using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.Enumerations;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        
        Vector2 Center = new Vector2(Program.Screen.Width / 2, Program.Screen.Height / 2);
        Pen p = new Pen(new SolidBrush(Color.Blue), 2);
        Circl c;
        public Form1()
        {
            c = new Circl(Center - (Vector2.up * (Center.y - 50)),50,p);

            InitializeComponent();
        }
        

        double i = 0;

        float FixedDeltaTime = 0.02f;
        float DeltaTime = 0;


        double RealDelata = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }



        private async Task Runner()
        {
            var sw = new Stopwatch();

            while (true)
            {
                sw.Restart();
                FixedUpdate();
                sw.Stop();
                var t = 20 - sw.Elapsed.TotalMilliseconds;
                await Task.Delay(TimeSpan.FromMilliseconds(20 - sw.Elapsed.TotalMilliseconds));
                label3.Text = "FixedDeltatime" +  (t + sw.Elapsed.TotalMilliseconds) + "ms";
                label2.Text = "FPS : " + (1/ DeltaTime).ToString("N3");
            }

        }


        private async Task Runner2()
        {
            var sw = new Stopwatch();

            while (true)
            {
                sw.Restart();
                ScreenUpdate();
                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
                sw.Stop();
                DeltaTime = (float)sw.Elapsed.TotalSeconds;
                
            }

        }


        private void FixedUpdate()
        {
           
            Program.graphics.Clear(Color.Black);
            label1.Text = ((double)GC.GetTotalMemory(false)/ 1024 / 1024).ToString("N3") + "MB";
            c.velocity += FixedDeltaTime * (Vector2.down * 15f);
            if (c.Center.y > Center.y * 2 + c.Radius) c.Center = new Vector2(c.Center.x, -c.Radius * 2);

        }

        private void ScreenUpdate()
        {
            
            // pictureBox1.Image?.Dispose();
            c.Center -= DeltaTime * c.velocity;
            c.Render();
            pictureBox1.Image = (Bitmap)Program.Screen.Clone();
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Runner();
            Runner2();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            var gl = openGLControl1.OpenGL;


            gl.PolygonMode(FaceMode.Front,PolygonMode.Filled);
        }
    }
}
