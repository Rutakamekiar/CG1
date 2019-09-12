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
            Draw();
        }

        private void Draw()
        {
            var count = 10;
            var bmp = new Bitmap(Picture.Width, Picture.Height);
            var graph = Graphics.FromImage(bmp);
            var rectangle = new Rectangle(new Point(500, 500), new Size(700, 700));
            graph.DrawRectangle(new Pen(Color.Red), rectangle);
            graph.DrawFigure(GetCenter(rectangle));
            var fi = 360 / count;

            var r = rectangle.Size.Width/2;
            for (var i = 0; i < count; i++)
            {
                var x = (int)(r * Math.Cos(i * fi)/2 + rectangle.Location.X);
                var y = (int)(r * Math.Sin(i * fi)/2 + rectangle.Location.X);
                var rectangle2 = new Rectangle(new Point(x, y),
                    new Size(rectangle.Size.Width / 2, rectangle.Size.Height / 2));
                graph.DrawFigure(GetCenter(rectangle2));
            }

            Picture.Image = bmp;
        }

        private Rectangle GetCenter(Rectangle rect)
        {
            rect.Location = new Point(rect.Location.X - rect.Size.Width / 2, rect.Location.Y - rect.Size.Height / 2);
            return rect;
        }
        
    }

    public static class Extensions
    {
        public static void DrawFigure(this Graphics graph, Rectangle rect)
        {
            var pen = new Pen(Color.Blue);
            graph.DrawEllipse(pen, rect);

            var rectSizeW = (int)(rect.Size.Width / Math.Sqrt(2));
            var rectSizeH = (int)(rect.Size.Height / Math.Sqrt(2));
            var rectLocationX = (rect.Width - rectSizeW) / 2 + rect.Location.X;
            var rectLocationY = (rect.Height - rectSizeH) / 2 + rect.Location.Y;
            rect.Size = new Size(rectSizeW, rectSizeH);
            rect.Location = new Point(rectLocationX, rectLocationY);
            graph.DrawRectangle(pen, rect);
        }
    }
}
