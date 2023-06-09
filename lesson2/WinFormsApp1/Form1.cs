using System.Security.Cryptography.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        Color color;
        Pen pen;

        Color black = Color.FromArgb(255, 0, 0, 0);
        Color green = Color.FromArgb(255, 0, 255, 0);
        Color blue = Color.FromArgb(255, 0, 0, 255);
        Color red = Color.FromArgb(255, 255, 0, 0);

        void SetColor(Color color) { this.color = color; }
        void SetPen(Pen pen) { this.pen = pen; }

        void UseColor(Color color, int width)
        {
            this.pen = new Pen(color);
            this.pen.Width = width;
        }

        void d(int x1, int y1, int x2, int y2)
        {
            e.Graphics.DrawLine(pen, x1, y1, x2, y2);
        }

       
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

        void d(int x, int y)
        {
            if (penDown)
            {
                d(lastX, lastY, x, y);
            }
            lastX = x;
            lastY = y;
        }

        int angle = 0;

        void rt(int val) { angle += val; }
        void lt(int val) { angle -= val; }

        void fd(int n)
        {
            double angleRad = angle * Math.PI / 180;
            int x2 = (int)(lastX + n * Math.Cos(angleRad));
            int y2 = (int)(lastY + n * Math.Sin(angleRad));

            if (penDown)
            {
                d(lastX, lastY, x2, y2);
            }

            lastX = x2;
            lastY = y2;
        }

        void bk(int n)
        {
            double angleRad = angle * Math.PI / 180;
            int x2 = (int)(lastX - n * Math.Cos(angleRad));
            int y2 = (int)(lastY - n * Math.Sin(angleRad));

            if (penDown)
            {
                d(lastX, lastY, x2, y2);
            }

            lastX = x2;
            lastY = y2;
        }

        PaintEventArgs e = null;

        void SetPaint(PaintEventArgs e) { this.e = e; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            count++;
        }

        int count = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            angle = 0;
            SetPaint(e);
            angle = angle + count;

            /////////////////////////////////////////////////////////
            UseColor(blue, 3);
            pu();
            d(300, 300);
            pd();

            //apply rotation
            rt(angle);

            //move to edge
            pu();
            fd(25);
            rt(90);
            bk(25);
            pd();

            //draw box
            for (int i = 0; i < 4; i++)
            {
                int width = 10; // count % 10;

                if (i == 0)
                    UseColor(blue, width);
                else if (i == 1)
                    UseColor(green, width);
                else if (i == 2)
                    UseColor(red, width);
                else UseColor(black, width);

                fd(50);
                rt(90);
            }


            //Clock Hand
            pu();
            d(500, 300);
            pd();
            rt(angle);
            fd(50);


            //draw circle
            int backupAngle = angle;
            UseColor(black, 2);
            pu();
            d(600, 300);
            pd();
            angle = 0;
            for (int i=0; i < 19; i++)
            {
                fd(25);
                rt(20);
            }



            angle = backupAngle;

            //////////////////////////////////////////////
        }

    }
}