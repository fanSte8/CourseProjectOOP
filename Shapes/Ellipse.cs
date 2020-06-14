using System;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public class Ellipse : EllipseBased
    {
        public double SemiXAxis
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

        public double SemiYAxis
        {
            get
            {
                return sides[1];
            }
            private set
            {
                if (value < 0)
                    throw new Exception("Length can't be a negative number.");

                sides[1] = value;
            }
        }

        public Ellipse
            (Point center, Point bottomRight,
             Color fill, Color line, int w)
            : base(center, fill, line, w)
        {
            SemiXAxis = Math.Abs(bottomRight.X - center.X);
            SemiYAxis = Math.Abs(bottomRight.Y - center.Y);

            Type = ShapeType.Ellipse;
        }

        public Ellipse
            (Point center,
             double width, double heigth,
             Color fill, Color line, int w)
            : base(center, fill, line, w)
        {
            SemiXAxis = width / 2;
            SemiYAxis = heigth / 2;

            Type = ShapeType.Ellipse;
        }

        public override string ToString()
        {
            return $"Shape: Ellipse, " +
                   $"Area: {Math.Round(this.Area, 2)}, " +
                   $"Circumference: {Math.Round(this.Circumference, 2)}";
        }
    }
}
