using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Triangle : Shape
    {
        public double FirstSide
        {
            get
            {
                return sides[0];
            }
            private set
            {
                if (value <= 0)
                    throw new InvalidValueExcepion("Length can't be a negative number.");

                sides[0] = value;
            }
        }

        public double SecondSide
        {
            get
            {
                return sides[1];
            }
            private set
            {
                if (value <= 0)
                    throw new InvalidValueExcepion("Length can't be a negative number.");

                sides[1] = value;
            }
        }
        public double ThirdSide
        {
            get
            {
                return sides[2];
            }
            private set
            {
                if (value <= 0)
                    throw new InvalidValueExcepion("Length can't be a negative number.");

                sides[2] = value;
            }
        }

        public Point PointA
        {
            get => points[0];
            private set => points[0] = value;
        }

        public Point PointB
        {
            get => points[1];
            private set => points[1] = value;
        }

        public Point PointC
        {
            get => points[2];
            private set => points[2] = value;
        }

        public Triangle
            (Point A, Point B, Point C,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            points[0] = A;
            points[1] = B;
            points[2] = C;

            CenterPoint = new Point(
                (A.X + B.X + C.X) / 3,
                (A.Y + B.Y + C.Y) / 3);

            FirstSide = Math.Sqrt(
                Math.Pow(B.X - C.X, 2) +
                Math.Pow(B.Y - C.Y, 2));

            SecondSide = Math.Sqrt(
                Math.Pow(C.X - A.X, 2) +
                Math.Pow(C.Y - A.Y, 2));

            ThirdSide = Math.Sqrt(
                Math.Pow(B.X - A.X, 2) +
                Math.Pow(B.Y - A.Y, 2));

            Type = ShapeType.Triangle;
        }

        public override double Area
        {
            get
            {
                double s = (sides[0] + sides[1] + sides[2]) / 2;
                return Math.Sqrt(s * (s - sides[0]) * (s - sides[1]) * (s - sides[2]));
            }
        }

        public override double Circumference
        {
            get => sides[0] + sides[1] + sides[2];
        }

        public override bool ContainsPoint(Point p)
        {
            double GetAngle(Point basePoint, Point first, Point second)
            {
                Point firstVector = new Point(
                    first.X - basePoint.X,
                    first.Y - basePoint.Y);

                Point secondVector = new Point(
                    second.X - basePoint.X,
                    second.Y - basePoint.Y);

                double firstLength = Math.Sqrt(
                    Math.Pow(basePoint.X - first.X, 2) +
                    Math.Pow(basePoint.Y - first.Y, 2));

                double secondLength = Math.Sqrt(
                    Math.Pow(basePoint.X - second.X, 2) +
                    Math.Pow(basePoint.Y - second.Y, 2));

                return Math.Acos(
                    (firstVector.X * secondVector.X + firstVector.Y * secondVector.Y) /
                    (firstLength * secondLength));
            }

            double sumAngles = Math.Round(
                GetAngle(p, points[0], points[1]) +
                GetAngle(p, points[0], points[2]) +
                GetAngle(p, points[1], points[2]), 2);

            return sumAngles == 6.28;
        }

        public override string ToString()
        {
            return $"Shape: Triangle, " +
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
            points[2].X += changeX;
            points[2].Y += changeY;
        }
    }
}
