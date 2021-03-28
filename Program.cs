using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        public static Bitmap Screen = new Bitmap(351,576, PixelFormat.Format32bppPArgb);
        public static Graphics graphics = Graphics.FromImage(Screen);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            graphics.Clear(Color.Black);

            graphics.SmoothingMode = SmoothingMode.HighSpeed;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
