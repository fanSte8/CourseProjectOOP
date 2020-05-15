using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Square : Shape
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
            }
        }

        public Point TopLeft 
        {
            get => points[0];
            private set => points[0] = value;
        }

        public Point BottomRight
        {
            get => points[1];
            private set => points[1] = value;
        }

        public Square
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

            SideLength = Math.Abs(first.X - second.X);
            
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

        public override double Area
        {
            get => sides[0] * sides[0];
        }

        public override double Circumference 
        { 
            get => 4 * sides[0]; 
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
            return $"Shape: Square, " +
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
