using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootbalTime
{
    public partial class Form1 : Form
    {
        Timer timer;
        int x, y = 0;
        int speedX = 25;
        int speedY = 25;
        int delta = 25;
        Bitmap field;
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
            field = new Bitmap(Properties.Resources._1);
            image = new Bitmap(Properties.Resources._2);
            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            x += speedX;
            y += speedY;

            if (x < 0)
            {
                speedX = delta;
            }
            if (y < 0)
            {
                speedY = delta;
            } 
            if (x > ClientRectangle.Width - 50)
            {
                speedX = -delta;
            }
            if (y > ClientRectangle.Height - 50)
            {
                speedY = -delta;
            }
            Draw();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();

        }
        private void Draw()
        {
            var sc = new Bitmap(field, ClientRectangle.Width, ClientRectangle.Height);
            var img2 = Graphics.FromImage(sc);
            img2.DrawImage(image, new Rectangle(x,y,50, 50));


            var gr = this.CreateGraphics();
            gr.DrawImage(sc, 0, 0);
        }
    }
}
