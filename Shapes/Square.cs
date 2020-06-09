using System;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public class Square : RectangleBased
    {
        public double SideLength 
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


        public Square
            (Point first, Point second,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            SideLength = Math.Abs(first.X - second.X);

            TopLeft = new Point(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y));

            BottomRight = new Point(
                first.X + (int)SideLength,
                first.Y + (int)SideLength);

            CenterPoint = new Point(
                (first.X + second.X) / 2,
                (first.Y + second.Y) / 2);

            Type = ShapeType.Square;
        }

        public Square
            (Point topLeft, double side,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            CenterPoint = new Point(
                (topLeft.X + (int)side) / 2,
                (topLeft.Y + (int)side) / 2);

            TopLeft = topLeft;
            BottomRight = new Point(
                topLeft.X + (int)side, 
                topLeft.Y + (int)side);

            SideLength = side;

            Type = ShapeType.Square;
        }

        public override string ToString()
        {
            return $"Shape: Square, " +
                   $"Area: {Math.Round(this.Area, 2)}, " +
                   $"Circumference: {Math.Round(this.Circumference, 2)}";
        }
    }
}
