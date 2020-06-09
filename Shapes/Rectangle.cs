using System;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public class Rectangle : RectangleBased
    {
        public double Width
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

        public double Height
        {
            get
            {
                return sides[1];
            }
            private set
            {
                if (value < 0)
                    throw new InvalidValueExcepion("Length can't be a negative number.");

                sides[1] = value;
            }
        }

        public bool Solid { get; set; }

        public Rectangle
            (Point first, Point second,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            CenterPoint = new Point(
                (first.X + second.X) / 2,
                (first.Y + second.Y) / 2);

            TopLeft = new Point(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y));

            BottomRight = new Point(
                Math.Max(first.X, second.X),
                Math.Max(first.Y, second.Y));

            Width = Math.Abs(first.X - second.X);
            Height = Math.Abs(first.Y - second.Y);

            Solid = true;

            Type = ShapeType.Rectangle;
        }

        public Rectangle
            (Point topLeft,
             double width, double height,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            CenterPoint = new Point(
                topLeft.X + ((int)width / 2),
                topLeft.Y + ((int)height / 2));

            TopLeft = topLeft;
            BottomRight = new Point(
                topLeft.X + (int)width,
                topLeft.Y + (int)height);

            Width = width;
            Height = height;

            Solid = true;

            Type = ShapeType.Rectangle;
        }

        public override string ToString()
        {
            return $"Shape: Rectangle, " +
                   $"Area: {Math.Round(this.Area, 2)}, " +
                   $"Circumference: {Math.Round(this.Circumference, 2)}";
        }
    }
}
