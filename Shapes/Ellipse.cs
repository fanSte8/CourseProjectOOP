using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Ellipse : Shape
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
            (Point center, Point perimeter,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            SemiXAxis = Math.Abs(perimeter.X - center.X);
            SemiYAxis = Math.Abs(perimeter.Y - center.Y);

            CenterPoint = center;

            Type = ShapeType.Ellipse;
        }

        public Ellipse
            (Point center,
             double width, double heigth,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            SemiXAxis = width / 2;
            SemiYAxis = heigth / 2;

            CenterPoint = center;

            Type = ShapeType.Ellipse;
        }
        public override void DrawShape(Graphics g)
        {
            Brush brush;

            if (IsSelect)
                brush = new HatchBrush(
                    HatchStyle.BackwardDiagonal,
                    Color.FromArgb(
                        FillColor.R > 125 ? 0 : 255,
                        FillColor.G > 125 ? 0 : 255,
                        FillColor.B > 125 ? 0 : 255),
                    FillColor);
            else
                brush = new SolidBrush(FillColor);      

            g.FillEllipse(brush,
                CenterPoint.X - (int)sides[0], CenterPoint.Y - (int)sides[1],
                2 * (float)sides[0], 2 * (float)sides[1]);

            brush.Dispose();

            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawEllipse(pen,
                    CenterPoint.X - (int)sides[0], CenterPoint.Y - (int)sides[1],
                    2 * (float)sides[0], 2 * (float)sides[1]);
        }

        public override double Area
        {
            get => sides[0] * sides[1] * Math.PI;
        }

        public override double Circumference
        {
            get =>  2 * Math.PI * Math.Sqrt((
                        Math.Pow(sides[0], 2) +
                        Math.Pow(sides[1], 2)) / 2);
        }

        public override bool ContainsPoint(Point p)
        {
            return
                Math.Pow(p.X - CenterPoint.X, 2) / Math.Pow(sides[0], 2) +
                Math.Pow(p.Y - CenterPoint.Y, 2) / Math.Pow(sides[1], 2) <= 1;
        }

        public override string ToString()
        {
            return $"Shape: Ellipse, " +
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
