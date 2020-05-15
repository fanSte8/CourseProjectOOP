using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Circle : Shape
    {
        public double Radius
        {
            get
            {
                return sides[0];
            }
            private set
            {
                if (value < 0)
                    throw new InvalidValueExcepion("Length can't be a negative number.");

                sides[0] = value;
            }
        }

        public Circle
            (Point center, Point perimeter,
             Color fill, Color line, int w)
            :base(fill, line, w)
        {
            Radius = Math.Sqrt(
                Math.Pow(center.X - perimeter.X, 2) +
                Math.Pow(center.Y - perimeter.Y, 2));

            CenterPoint = center;

            Type = ShapeType.Circle;
        }
        
        public Circle(
            Point center, double radius,
            Color fill, Color line, int w)
            :base(fill, line, w)
        {
            Radius = radius;
            CenterPoint = center;

            Type = ShapeType.Circle;
        }

        public override double Area
        {
            get => sides[0] * sides[0] * Math.PI;
        }

        public override double Circumference
        {
            get => 2 * sides[0] * Math.PI;
        }

        public override bool ContainsPoint(Point p)
        {
            double distance = Math.Sqrt(
                Math.Pow(CenterPoint.X - p.X, 2) +
                Math.Pow(CenterPoint.Y - p.Y, 2));

            return distance < sides[0];
        }

        public override string ToString()
        {
            return $"Shape: Circle, " +
                   $"Area: {Math.Round(this.Area, 2)}, " +
                   $"Circumference: {Math.Round(this.Circumference, 2)}";
        }
        public override void Move(int changeX, int changeY)
        {
            CenterPoint = new Point
                (CenterPoint.X + changeX,
                 CenterPoint.Y + changeY);
        }

    }
}
