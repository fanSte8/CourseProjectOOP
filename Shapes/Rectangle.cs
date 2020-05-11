using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Rectangle : Shape
    {
        public override double FirstSide
        {
            get
            {
                return sides[0];
            }
            set
            {
                if (value <= 0)
                    throw new Exception("This value can't be a negative number.");

                sides[0] = value;
            }
        }

        public override double SecondSide
        {
            get
            {
                return sides[1];
            }
            set
            {
                if (value <= 0)
                    throw new Exception("This value can't be a negative number.");

                sides[1] = value;
            }
        }
        public override double ThirdSide
        {
            get => throw new Exception("You are trying to access a non-existant property.");
            set => throw new Exception("You are trying to access a non-existant property.");
        }

        public override Point FirstPoint
        {
            get => points[0];
            set => points[0] = value;
        }
        public override Point SecondPoint
        {
            get => points[1];
            set => points[1] = value;
        }
        public override Point ThirdPoint
        {
            get => throw new Exception("You are trying to access a non-existant property.");
            set => throw new Exception("You are trying to access a non-existant property.");
        }

        public bool Solid { get; set; }

        public Rectangle
            (int firstX, int firstY,
             int secondX, int secondY, 
             Color line, Color fill)
            : base(line, fill)
        {
            CenterPoint = new Point(
                Math.Min(firstX, secondX),
                Math.Min(firstY, secondY));

            FirstPoint = new Point(
                Math.Min(firstX, secondX),
                Math.Min(firstY, secondY));

            SecondPoint = new Point(
                Math.Max(firstX, secondX),
                Math.Max(firstY, secondY));

            sides[0] = Math.Abs(firstX - secondX);
            sides[1] = Math.Abs(firstY - secondY);

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
            return $"Shape: Rectangle, Area: {Math.Round(this.Area, 2)}, Circumference: {Math.Round(this.Circumference, 2)}";
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
