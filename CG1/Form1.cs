using System;
using System.Drawing;
using System.Windows.Forms;

namespace CG1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ////DrawLab1();
            DrawLab2();

        }

        private void DrawLab2(int n = 8, int r = 100)
        {
            var bmp = new Bitmap(Picture.Width, Picture.Height);
            var graph = Graphics.FromImage(bmp);
            var pen = new Pen(Color.Red);
            var pen2 = new Pen(Color.CornflowerBlue);
            var center = new Point(ClientSize.Width / 2,ClientSize.Height/2);
            graph.DrawRectangle(pen, new Rectangle(center, new Size(20,20)));
            graph.DrawFigureLab2(pen, center, r, n, 40);
            graph.DrawFigureLab2(pen2, center, r, n);

            Picture.Image = bmp;
        }

        private void DrawLab1(int count = 10)
        {
            var bmp = new Bitmap(Picture.Width, Picture.Height);
            var graph = Graphics.FromImage(bmp);
            var rectangle = new Rectangle(new Point(500, 500), new Size(700, 700));
            graph.DrawRectangle(new Pen(Color.Red), rectangle);
            graph.DrawFigureLab1(Extensions.DrawByCenter(rectangle));
            var fi = 360 / count;

            var r = rectangle.Size.Width / 2;
            for (var i = 0; i < count; i++)
            {
                var x = (int) (r * Math.Cos(i * fi) / 2 + rectangle.Location.X);
                var y = (int) (r * Math.Sin(i * fi) / 2 + rectangle.Location.X);
                var rectangle2 = new Rectangle(new Point(x, y),
                    new Size(rectangle.Size.Width / 2, rectangle.Size.Height / 2));
                graph.DrawFigureLab1(Extensions.DrawByCenter(rectangle2));
            }

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
            graph.DrawEllipse(pen, rect);

            var rectSizeW = (int) (rect.Size.Width / Math.Sqrt(2));
            var rectSizeH = (int) (rect.Size.Height / Math.Sqrt(2));
            var rectLocationX = (rect.Width - rectSizeW) / 2 + rect.Location.X;
            var rectLocationY = (rect.Height - rectSizeH) / 2 + rect.Location.Y;
            rect.Size = new Size(rectSizeW, rectSizeH);
            rect.Location = new Point(rectLocationX, rectLocationY);
            graph.DrawRectangle(pen, rect);
        }

        public static void DrawFigureLab2(this Graphics graph, Pen pen, Point center, int r = 100, int n = 10, int angle = 0)
        {
            var angleRadian = angle * Math.PI / 180;
            for (var t = 0d; t < n * Math.PI; t += 0.01)
            {
                var x = r * (Math.Cos(t) - Math.Cos(n * t) / n);
                var y = r * (Math.Sin(t) - Math.Sin(n * t) / n);
                x = x * Math.Cos(angleRadian) - y * Math.Sin(angleRadian);
                y = x * Math.Sin(angleRadian) + y * Math.Cos(angleRadian);

                var rectangle = new Rectangle(new Point((int) x + center.X, (int) y + center.Y), new Size(1, 1));
                
                graph.DrawEllipse(pen, rectangle);
            }
            graph.ResetTransform();
        }
    }
}
