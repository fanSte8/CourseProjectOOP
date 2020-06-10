using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public class RectangleBased : Shape
    {
        protected RectangleBased(Color fill, Color line, int width)
            :base(fill, line, width) { }

        public Point TopLeft
        {
            get => points[0];
            protected set => points[0] = value;
        }

        public Point BottomRight
        {
            get => points[1];
            protected set => points[1] = value;
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
