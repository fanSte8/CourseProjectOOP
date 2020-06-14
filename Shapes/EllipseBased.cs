using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    [Serializable]
    public class EllipseBased : Shape
    {
        protected EllipseBased(Point center, Color fill, Color line, int w)
            :base(fill, line, w) 
        {
            CenterPoint = center;
        }

        public override double Area
        {
            get => sides[0] * sides[1] * Math.PI;
        }

        public override double Circumference
        {
            get => 2 * Math.PI * Math.Sqrt((
                        Math.Pow(sides[0], 2) +
                        Math.Pow(sides[1], 2)) / 2);
        }

        public override bool ContainsPoint(Point p)
        {
            return
                Math.Pow(p.X - CenterPoint.X, 2) / Math.Pow(sides[0], 2) +
                Math.Pow(p.Y - CenterPoint.Y, 2) / Math.Pow(sides[1], 2) <= 1;
        }


        public override void Move(int changeX, int changeY)
        {
            CenterPoint = new Point
                (CenterPoint.X + changeX,
                 CenterPoint.Y + changeY);
        }
    }
}
