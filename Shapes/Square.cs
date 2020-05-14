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
            set
            {
                if (value < 0)
                    throw new InvalidValueExcepion("This value can't be a negative number.");

                sides[0] = value;
            }
        }

        public Point TopLeftPoint 
        {
            get => points[0];
            set => points[0] = value;
        }

        public Square
            (Point first, Point second,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            CenterPoint = new Point(
                (first.X + second.X) / 2,
                (first.Y + second.Y) / 2);

            points[0] = new Point(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y));

            points[1] = new Point(
                Math.Max(first.X, second.X),
                Math.Max(first.Y, second.Y));

            sides[0] = Math.Abs(first.X - second.X);
            
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

            TopLeftPoint = new Point(topLeft.X, topLeft.Y);

            SideLength = side;

            Type = ShapeType.Square;
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

            g.FillRectangle(brush,
                points[0].X, points[0].Y,
                (float)sides[0], (float)sides[0]);

            brush.Dispose();

            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawRectangle(pen,
                    points[0].X, points[0].Y,
                    (float)sides[0], (float)sides[0]);
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
            CenterPoint.X += changeX;
            CenterPoint.Y += changeY;
            points[0].X += changeX;
            points[0].Y += changeY;
            points[1].X += changeX;
            points[1].Y += changeY;
        }
    }
}
