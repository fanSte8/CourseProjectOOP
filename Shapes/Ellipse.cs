using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes
{
    [Serializable]
    public class Ellipse : Shape
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
            get => throw new Exception("You are trying to access a non-existant property.");
            set => throw new Exception("You are trying to access a non-existant property.");
        }

        public override Point SecondPoint
        {
            get => throw new Exception("You are trying to access a non-existant property.");
            set => throw new Exception("You are trying to access a non-existant property.");
        }

        public override Point ThirdPoint
        {
            get => throw new Exception("You are trying to access a non-existant property.");
            set => throw new Exception("You are trying to access a non-existant property.");
        }

        public Ellipse
            (int centerX, int centerY,
             int perimeterX, int perimeterY,
             Color line, Color fill)
            : base(line, fill)
        {
            sides[0] = Math.Abs(centerX - perimeterX);
            sides[1] = Math.Abs(centerY - perimeterY);

            CenterPoint = new Point(centerX, centerY);
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
            return $"Shape: Ellipse, Area: {Math.Round(this.Area, 2)}, Circumference: {Math.Round(this.Circumference, 2)}";
        }

        public override void Move(int changeX, int changeY)
        {
            CenterPoint.X += changeX;
            CenterPoint.Y += changeY;
        }
    }
}
