using System.Security.Cryptography.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Color color;
        Pen pen;

        Color black = Color.FromArgb(255, 0, 0, 0);
        Color green = Color.FromArgb(255, 0, 255, 0);
        Color blue = Color.FromArgb(255, 0, 0, 255);
        Color red = Color.FromArgb(255, 255, 0, 0);

        void SetColor(Color color) { this.color = color; }
        void SetPen(Pen pen) { this.pen = pen; }

        void UseColor(Color color)
        {
            this.pen = new Pen(color);
            this.pen.Width = 5;
        }

        void d(PaintEventArgs e, int x1, int y1, int x2, int y2)
        {
            e.Graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        /*
         * UseColor(blue);
                       
            Draw(e, 100, 100, 100, 200);
            Draw(e, 100, 200, 200, 200);
            Draw(e, 200, 200, 200, 100);
            Draw(e, 200, 100, 100, 100);


            UseColor(green);

            Draw(e, 150, 950, 150, 250);
            Draw(e, 150, 250, 250, 250);
            Draw(e, 250, 250, 250, 150);
            Draw(e, 250, 150, 150, 150);
        */

        bool penDown = true;
        void pu()
        {
            penDown = false;
        }

        void pd()
        {
            penDown = true;
        }

        int lastX, lastY;

        void d(PaintEventArgs e, int x, int y)
        {
            if (penDown)
            {
                d(e, lastX, lastY, x, y);
            }
            lastX = x;
            lastY = y;
        }

        int angle = 0;

        void rt(int val) { angle += val; }
        void lt(int val) { angle -= val; }

        void fd(PaintEventArgs e, int n)
        {
            double angleRad = angle * Math.PI / 180;
            int x2 = (int)(lastX + n * Math.Cos(angleRad));
            int y2 = (int)(lastY + n * Math.Sin(angleRad));

            if (penDown)
            {
                d(e, lastX, lastY, x2, y2);
            }

            lastX = x2;
            lastY = y2;
        }

        void bk(PaintEventArgs e, int n)
        {
            double angleRad = angle * Math.PI / 180;
            int x2 = (int)(lastX - n * Math.Cos(angleRad));
            int y2 = (int)(lastY - n * Math.Sin(angleRad));

            if (penDown)
            {
                d(e, lastX, lastY, x2, y2);
            }

            lastX = x2;
            lastY = y2;
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /////////////////////////////////////////////////////////
            UseColor(blue);
            pu();
            d(e, 300, 300);
            pd();
            for (int i = 0; i < 100; i++)
            {

                for (int p = 0; p < 12; p++)
                { fd(e, 10); bk(e, 10); lt(30); }
                rt(30); fd(e, 20);
            }


            //////////////////////////////////////////////
        }

    }
}