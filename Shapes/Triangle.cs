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
    public class Triangle : Shape
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
            get
            {
                return sides[2];
            }
            set
            {
                if (value <= 0)
                    throw new Exception("This value can't be a negative number.");

                sides[2] = value;
            }
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
            get => points[2];
            set => points[2] = value;
        }

        public Triangle
            (int AX, int AY, int BX, int BY,
             int CX, int CY, Color line, Color fill)
            :base(line, fill)
        {
            FirstPoint = new Point(AX, AY);
            SecondPoint = new Point(BX, BY);
            ThirdPoint = new Point(CX, CY);

            CenterPoint = new Point(
                (points[0].X + points[1].X + points[2].X) / 3,
                (points[0].Y + points[1].Y + points[2].Y) / 3);

            sides[0] = Math.Sqrt(
                Math.Pow(BX - CX, 2) +
                Math.Pow(BY - CY, 2));

            sides[1] = Math.Sqrt(
                Math.Pow(CX - AX, 2) +
                Math.Pow(CY - AY, 2));

            sides[2] = Math.Sqrt(
                Math.Pow(BX - AX, 2) +
                Math.Pow(BY - AY, 2));

            Type = ShapeType.Triangle;
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

            g.FillPolygon(brush, new Point[]
            {
                points[0],
                points[1],
                points[2]
            });

            brush.Dispose();

            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawPolygon(pen, new Point[]
                {
                    points[0],
                    points[1],
                    points[2]
                });
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
            return $"Shape: Triangle, Area: {Math.Round(this.Area, 2)}, Circumference: {Math.Round(this.Circumference, 2)}";
        }

        public override void Move(int changeX, int changeY)
        {
            CenterPoint.X += changeX;
            CenterPoint.Y += changeY;
            points[0].X += changeX;
            points[0].Y += changeY;
            points[1].X += changeX;
            points[1].Y += changeY;
            points[2].X += changeX;
            points[2].Y += changeY;
        }
    }
}
