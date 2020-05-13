using System;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public abstract class Shape
    {
        protected double[] sides = new double[3];

        protected Point[] points = new Point[3];

        public ShapeType Type;

        public Point CenterPoint;

        public int Order { get; set; }

        public Color LineColor { get; set; }

        public Color FillColor { get; set; }

        public int LineWidth { get; set; }

        public bool IsSelect { get; set; }

        protected Shape()
        {
            FillColor = Color.LightGray;
            LineColor = Color.LightGray;
            IsSelect = false;
        }

        public abstract double Area { get; }

        public abstract double Circumference { get; }

        public abstract void DrawShape(Graphics g);

        public abstract bool ContainsPoint(Point p);

        public abstract void Move(int changeX, int changeY);
    }
}
