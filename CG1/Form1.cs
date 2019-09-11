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
            var bmp = new Bitmap(Picture.Width, Picture.Height);
            var graph = Graphics.FromImage(bmp);
            var rectangle = new Rectangle(new Point(50, 50), new Size(100, 100));
            graph.DrawRectangle(new Pen(Color.Red), rectangle);
            graph.DrawFigure(rectangle);
            rectangle.Size = new Size(50,50);
            graph.DrawFigure(rectangle);
            ////for (var i = 0; i < 10; i++)
            ////{
            ////    var rectangle2 = new Rectangle(new Point(i * 20, i * 20), new Size(50, 50));
            ////    graph.DrawFigure(rectangle2);

            ////}

            Picture.Image = bmp;
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
