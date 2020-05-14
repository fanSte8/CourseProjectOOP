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
                CenterPoint.X - (int)sides[0], CenterPoint.Y - (int)sides[0],
                2 * (float)sides[0], 2 * (float)sides[0]);

            brush.Dispose();

            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawEllipse(pen,
                    CenterPoint.X - (int)sides[0], CenterPoint.Y - (int)sides[0],
                    2 * (float)sides[0], 2 * (float)sides[0]);
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
