using System;
using System.Drawing;
using System.Windows.Forms;

namespace CG1
{
    public partial class Form1 : Form
    {
        private static Graphics _graph;
        private static Bitmap bmp;
        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(Picture.Width, Picture.Height);
            _graph = Graphics.FromImage(bmp);
            _graph.Clear(Color.White);
            Picture.Image = bmp;
            DrawLab2();
        }

        private void DrawLab2(int count = 100, int n = 8, int r = 300)
        {

            var pen = new Pen(Color.Red);
            var pen2 = new Pen(Color.CornflowerBlue);
            var center = new Point(400, 350);

            _graph.TranslateTransform(center.X, center.Y);
            _graph.DrawFigureLab2(pen, r, n);
            _graph.RotateTransform(26);
            _graph.DrawFigureLab2(pen2, r, n);
            _graph.RotateTransform(-26);

            if (count != 0)
            {
                var fi = 360 / count;

                r /= 2;
                _graph.DrawOrnamentLab2(pen, count, r, fi, n);

                _graph.RotateTransform(26);
                _graph.DrawOrnamentLab2(pen2, count, r, fi, n);
                _graph.RotateTransform(-26);
            }
        }

        private void DrawLab1(int count = 100)
        {
            var rectangle = new Rectangle(new Point(350, 350), new Size(700, 700));
            _graph.DrawFigureLab1(Extensions.DrawByCenter(rectangle));
            if (count !=0 )
            {
                var fi = 360 / count;

                var r = rectangle.Size.Width / 2;
                for (var i = 0; i < count; i++)
                {
                    var x = (int)(r * Math.Cos(i * fi) / 2 + rectangle.Location.X);
                    var y = (int)(r * Math.Sin(i * fi) / 2 + rectangle.Location.X);
                    var rectangle2 = new Rectangle(new Point(x, y),
                                                   new Size(rectangle.Size.Width / 2, rectangle.Size.Height / 2));
                    _graph.DrawFigureLab1(Extensions.DrawByCenter(rectangle2));
                }
            }
        }

        private void RunButton(object sender, EventArgs e)
        {
            var timer = new Timer { Interval = 30 };
            var count = 0;
            var min = 0;
            var max = 180;
            var isRight = true;
            var point = 10;
            _graph.Clear(Color.Black);
            DrawLab1();
            _graph.TranslateTransform(point, 0);
            Picture.Image = bmp;
            var value = 1;
            _graph.ResetTransform();

            timer.Tick += (o, ev) =>
            {
                if (isRight)
                    point += 5;
                else point -= 5;
                
                _graph.TranslateTransform(point, 0);
                _graph.Clear(Color.Black);
                DrawLab1();
                Picture.Image = bmp;
                _graph.ResetTransform();

                count += value;
                if (count > max)
                {
                    isRight = false;
                    value = -1;
                }
                else if (count < min)
                {
                    isRight = true;
                    value = 1;
                }

                //if (count > max)
                //{
                //    var t = o as Timer;
                //    t.Stop();
                //}
            };
            timer.Start();
        }

        private void Lab1_Click(object sender, EventArgs e)
        {
            _graph.ResetTransform();
            _graph.Clear(Color.White);
            DrawLab1(100);
            _graph.TranslateTransform(800,0);
            DrawLab1(10);
            Picture.Image = bmp;
        }

        private void Lab2_Click(object sender, EventArgs e)
        {
            _graph.ResetTransform();
            _graph.Clear(Color.Black);
            DrawLab2(100);
            _graph.ResetTransform();

            _graph.TranslateTransform(800, 0);
            DrawLab2(10);
            Picture.Image = bmp;
        }
    }

    public static class Extensions
    {
        public static Rectangle DrawByCenter(Rectangle rect)
        {
            rect.Location = new Point(rect.Location.X - rect.Size.Width / 2, rect.Location.Y - rect.Size.Height / 2);
            return rect;
        }


        public static void DrawFigureLab1(this Graphics graph, Rectangle rect)
        {
            var pen = new Pen(Color.Blue);
            var pen2 = new Pen(Color.Red);
            graph.DrawEllipse(pen, rect);

            var rectSizeW = (int) (rect.Size.Width / Math.Sqrt(2));
            var rectSizeH = (int) (rect.Size.Height / Math.Sqrt(2));
            var rectLocationX = (rect.Width - rectSizeW) / 2 + rect.Location.X;
            var rectLocationY = (rect.Height - rectSizeH) / 2 + rect.Location.Y;
            rect.Size = new Size(rectSizeW, rectSizeH);
            rect.Location = new Point(rectLocationX, rectLocationY);
            graph.DrawRectangle(pen2, rect);
        }

        public static void DrawFigureLab2(this Graphics graph, Pen pen, int r = 100, int n = 10)
        {
            for (var t = 0d; t < n * Math.PI; t += 0.01)
            {
                var x = r * (Math.Cos(t) - Math.Cos(n * t) / n);
                var y = r * (Math.Sin(t) - Math.Sin(n * t) / n);
                var rectangle = new Rectangle(new Point((int) x, (int) y), new Size(1, 1));
                graph.DrawEllipse(pen, rectangle);
            }
        }

        public static void DrawOrnamentLab2(this Graphics graph, Pen pen, int count, int r, int fi, int n)
        {
            for (var i = 0; i < count; i++)
            {
                var x = (int)(r * Math.Cos(i * fi));
                var y = (int)(r * Math.Sin(i * fi));
                graph.TranslateTransform(x, y);
                graph.DrawFigureLab2(pen, r, n);
                graph.TranslateTransform(-x, -y);
            }
        }
    }
}
