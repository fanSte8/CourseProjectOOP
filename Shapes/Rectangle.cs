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
            set
            {
                if (value < 0)
                    throw new InvalidValueExcepion("This value can't be a negative number.");

                sides[0] = value;
            }
        }

        public double Height
        {
            get
            {
                return sides[1];
            }
            set
            {
                if (value < 0)
                    throw new InvalidValueExcepion("This value can't be a negative number.");

                sides[1] = value;
            }
        }

        public Point TopLeftPoint
        {
            get => points[0];
            set => points[0] = value;
        }

        public bool Solid { get; set; }

        public Rectangle
            (Point first, Point second,
             Color fill, Color line, int w)
            : base(fill, line, w)
        {
            CenterPoint = new Point(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y));

            points[0] = new Point(
                Math.Min(first.X, second.X),
                Math.Min(first.Y, second.Y));

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

            TopLeftPoint = new Point(topLeft.X, topLeft.Y);

            Width = width;
            Height = height;

            Solid = true;

            Type = ShapeType.Rectangle;
        }

        public override void DrawShape(Graphics g)
        {
            if (Solid)
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
                    (float)sides[0], (float)sides[1]);

                brush.Dispose();
            }

            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawRectangle(pen,
                    points[0].X, points[0].Y,
                    (float)sides[0], (float)sides[1]);
            
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
            CenterPoint.X += changeX;
            CenterPoint.Y += changeY;
            points[0].X += changeX;
            points[0].Y += changeY;
            points[1].X += changeX;
            points[1].Y += changeY;
        }
    }
}
