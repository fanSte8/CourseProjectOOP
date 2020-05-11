using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Shapes
{
    [Serializable]
    public abstract class Shape
    {
        protected double[] sides = new double[3];

        protected Point[] points = new Point[3];

        public ShapeType Type;

        public Point CenterPoint;

        public abstract double FirstSide { get; set; }

        public abstract double SecondSide { get; set; }

        public abstract double ThirdSide { get; set; }

        public abstract Point FirstPoint { get; set; }

        public abstract Point SecondPoint { get; set; }

        public abstract Point ThirdPoint { get; set; }

        public int Order { get; set; }

        public Color LineColor { get; set; }

        public Color FillColor { get; set; }

        public int LineWidth { get; set; }

        public bool IsSelect { get; set; }

        protected Shape(Color line, Color fill)
        {
            LineColor = line;
            FillColor = fill;
            IsSelect = false;
        }

        public abstract double Area { get; }

        public abstract double Circumference { get; }

        public abstract void DrawShape(Graphics g);

        public abstract bool ContainsPoint(Point p);

        public abstract void Move(int changeX, int changeY);
    }
}
