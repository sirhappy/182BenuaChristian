using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace task5
{
    public class CircleViewModel
    {

        private Circle _circle;

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Drawing.Pen pen;

        public System.Drawing.Color penColor
        {
            get => pen.Color;

            set
            {
                pen.Color = value;
                Refresh();
            }
        }

        public CircleViewModel(System.Windows.Forms.PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            this._circle = new Circle(1);
            _circle.OnRadiusChanged += Refresh;
            pen = new Pen(Brushes.Black);
        }

        private void Draw()
        {
            PointF centerPoint = new PointF(pictureBox.Size.Width / 2, pictureBox.Size.Height / 2);
            PointF upperleftPoint = new PointF(centerPoint.X - (float)_circle.Radius, centerPoint.Y - (float)_circle.Radius);
            using (Graphics graphics = Graphics.FromImage(pictureBox.Image))
            {
                graphics.DrawEllipse(pen, new RectangleF(upperleftPoint, new SizeF((float)_circle.Radius * 2, (float)_circle.Radius * 2)));
            }
        }

        public void Refresh()
        {
            pictureBox.Image?.Dispose();
            pictureBox.Image = new Bitmap(width: (int)pictureBox.Width, height: (int)pictureBox.Height);
            this.Draw();
        }

        public void SetCircleRadius(double radius)
        {
            this._circle.Radius = radius;
        }

    }
}
