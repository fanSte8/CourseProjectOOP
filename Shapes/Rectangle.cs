using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Rectangle : Shape
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

        public Point TopLeftPoint
        {
            get => points[0];
            private set => points[0] = value;
        }
        public Point BottomRightPoint
        {
            get => points[1];
            private set => points[1] = value;
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

            TopLeftPoint = new Point(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y));

            BottomRightPoint = new Point(
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

            TopLeftPoint = topLeft;
            BottomRightPoint = new Point(
                topLeft.X + (int)width,
                topLeft.Y + (int)height);

            Width = width;
            Height = height;

            Solid = true;

            Type = ShapeType.Rectangle;
        }

        public override double Area
        {
            get => sides[0] * sides[1];
        }

        public override double Circumference
        {
            get => 2 * (sides[0] + sides[1]);
        }
        public override bool ContainsPoint(Point p)
        {
            return p.X > points[0].X &&
                   p.Y > points[0].Y &&
                   p.X < points[1].X &&
                   p.Y < points[1].Y;
        }

        public override string ToString()
        {
            return $"Shape: Rectangle, " +
                   $"Area: {Math.Round(this.Area, 2)}, " +
                   $"Circumference: {Math.Round(this.Circumference, 2)}";
        }

        public override void Move(int changeX, int changeY)
        {
            CenterPoint = new Point
                (CenterPoint.X + changeX,
                 CenterPoint.Y + changeY);
            points[0].X += changeX;
            points[0].Y += changeY;
            points[1].X += changeX;
            points[1].Y += changeY;
        }
    }
}
