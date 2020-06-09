using System;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public class Circle : EllipseBased
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
                sides[1] = value;
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

        public override string ToString()
        {
            return $"Shape: Circle, " +
                   $"Area: {Math.Round(this.Area, 2)}, " +
                   $"Circumference: {Math.Round(this.Circumference, 2)}";
        }
    }
}
