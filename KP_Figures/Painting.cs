using System.Drawing;
using System.Drawing.Drawing2D;
using Shapes;
using Rectangle = Shapes.Rectangle;

namespace KP_Figures
{
    public static class Painting
    {
        private static HatchBrush CreateHatchBrush(Color c)
        {
            return new HatchBrush(
                    HatchStyle.BackwardDiagonal, 
                    Color.FromArgb(
                        c.R > 125 ? 0 : 255, 
                        c.G > 125 ? 0 : 255, 
                        c.B > 125 ? 0 : 255), c);
        }
        public static void DrawShape(this Shape s, Graphics g)
        {
            switch (s.Type)
            {
                case ShapeType.Square:

                    DrawSquare(g, (Square)s);
                    break;

                case ShapeType.Rectangle:

                    DrawRectangle(g, (Rectangle)s);
                    break;

                case ShapeType.Circle:

                    DrawCircle(g, (Circle)s);
                    break;

                case ShapeType.Ellipse:

                    DrawEllipse(g, (Ellipse)s);
                    break;

                case ShapeType.Triangle:

                    DrawTriangle(g, (Triangle)s);
                    break;
            }
        }
        private static void DrawSquare(Graphics g, Square s)
        {
            Brush brush;

            if (s.IsSelect)
                brush = CreateHatchBrush(s.FillColor); 
            else
                brush = new SolidBrush(s.FillColor);

            g.FillRectangle(brush,
                s.TopLeft.X, s.TopLeft.Y,
                (float)s.SideLength, (float)s.SideLength);

            brush.Dispose();

            using (var pen = new Pen(s.LineColor, s.LineWidth))
                g.DrawRectangle(pen,
                s.TopLeft.X, s.TopLeft.Y,
                (float)s.SideLength, (float)s.SideLength);
        }
        private static void DrawRectangle(Graphics g, Rectangle r)
        {
            if (r.Solid)
            {
                Brush brush;

                if (r.IsSelect)
                    brush = CreateHatchBrush(r.FillColor);
                else
                    brush = new SolidBrush(r.FillColor);

                g.FillRectangle(brush,
                    r.TopLeft.X, r.TopLeft.Y,
                    (float)r.Width, (float)r.Height);

                brush.Dispose();
            }

            using (var pen = new Pen(r.LineColor, r.LineWidth))
                g.DrawRectangle(pen,
                    r.TopLeft.X, r.TopLeft.Y,
                    (float)r.Width, (float)r.Height);
        }

        private static void DrawCircle(Graphics g, Circle c)
        {
            Brush brush;

            if (c.IsSelect)
                brush = CreateHatchBrush(c.FillColor);
            else
                brush = new SolidBrush(c.FillColor);


            g.FillEllipse(brush,
                c.CenterPoint.X - (float)c.Radius, c.CenterPoint.Y - (float)c.Radius,
                2 * (float)c.Radius, 2 * (float)c.Radius);

            brush.Dispose();

            using (var pen = new Pen(c.LineColor, c.LineWidth))
                g.DrawEllipse(pen,
                    c.CenterPoint.X - (float)c.Radius, c.CenterPoint.Y - (float)c.Radius,
                    2 * (float)c.Radius, 2 * (float)c.Radius);
        }

        private static void DrawEllipse(Graphics g, Ellipse e)
        {
            Brush brush;

            if (e.IsSelect)
                brush = CreateHatchBrush(e.FillColor);
            else
                brush = new SolidBrush(e.FillColor);

            g.FillEllipse(brush,
                e.CenterPoint.X - (float)e.SemiXAxis, e.CenterPoint.Y - (float)e.SemiYAxis,
                2 * (float)e.SemiXAxis, 2 * (float)e.SemiYAxis);

            brush.Dispose();

            using (var pen = new Pen(e.LineColor, e.LineWidth))
                g.DrawEllipse(pen,
                    e.CenterPoint.X - (float)e.SemiXAxis, e.CenterPoint.Y - (float)e.SemiYAxis,
                    2 * (float)e.SemiXAxis, 2 * (float)e.SemiYAxis);
        }

        private static void DrawTriangle(Graphics g, Triangle t)
        {
            Brush brush;

            if (t.IsSelect)
                brush = CreateHatchBrush(t.FillColor);
            else
                brush = new SolidBrush(t.FillColor);

            g.FillPolygon(brush, new Point[]
            {
                t.PointA,
                t.PointB,
                t.PointC
            });

            brush.Dispose();

            using (var pen = new Pen(t.LineColor, t.LineWidth))
                g.DrawPolygon(pen, new Point[]
                {
                    t.PointA,
                    t.PointB,
                    t.PointC
                });
        }
    }
}
