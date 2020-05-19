using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Shapes;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace KP_Figures
{
    class ShapeDetector
    {
        public static (ShapeType, List<Point>) Check(List<Point> polygonPoints, int canvasWidth, int canvasHeigth)
        {
            if (!ClosedContour(polygonPoints))
                return (ShapeType.None, null);

            if (!CreateBitmap(canvasWidth, canvasHeigth, polygonPoints))
                return (ShapeType.None, null);

            Image<Bgr, byte> img = new Image<Bgr, byte>("IMAGE");
            Image<Gray, byte> gray = img
                .Convert<Gray, byte>()
                .SmoothGaussian(5)
                .ThresholdBinaryInv(new Gray(240), new Gray(255));

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat m = new Mat();

            CvInvoke.FindContours(gray, contours, m, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            double perimeter = CvInvoke.ArcLength(contours[0], true);
            var approx = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(contours[0], approx, 0.04 * perimeter, true);

            var moments = CvInvoke.Moments(contours[0]);
            int x = (int)(moments.M10 / moments.M00);
            int y = (int)(moments.M01 / moments.M00);
            Point center = new Point(x, y);

            List<Point> points = new List<Point>();

            for (int i = 0; i < approx.Size; i++)
                points.Add(new Point(approx[i].X, approx[i].Y));

            if (points.Count == 3)
                return (ShapeType.Triangle, points);
            else if (points.Count == 4)
                return RectangleOrSquare(points, center);
            else if (points.Count > 4)
            {
                int r = (int)(perimeter / (2 * Math.PI));
                return CircleOrEllipse(center, r, perimeter, points);
            }

            return (ShapeType.None, null);
        }

        private static bool CreateBitmap(int w, int h, List<Point> points)
        {
            if (points.Count <= 1)
                return false;

            Bitmap bmp = new Bitmap(w, h);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                using (var p = new SolidBrush(Color.Black))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    g.FillPolygon(p, points.ToArray());
                }
            }

            bmp.Save("IMAGE", System.Drawing.Imaging.ImageFormat.Bmp);
            return true;
        }

        private static bool ClosedContour(List<Point> points)
        {
            int last = points.Count - 1;
            double distance = Math.Sqrt(
                Math.Pow(points[0].X - points[last].X, 2) +
                Math.Pow(points[0].Y - points[last].Y, 2));

            return distance < 10;
        }

        private static (ShapeType, List<Point>) CircleOrEllipse(Point center, int radius, double perimeter, List<Point> points)
        {
            double circleThreshold = 0.1;
            double maxDistance = 0;
            Point BRPoint = new Point(-1, -1);

            foreach (var p in points)
            {
                double d = Math.Sqrt(
                    Math.Pow(center.X - p.X, 2) +
                    Math.Pow(center.Y - p.Y, 2));

                if (maxDistance < d)
                    maxDistance = d;
            }

            if (Math.Abs(maxDistance - radius) < circleThreshold  * radius)
            {
                List<Point> circlePoints = new List<Point>()
                {
                    center,
                    new Point(center.X + radius, center.Y)
                };

                return (ShapeType.Circle, circlePoints);
            }
            else
            {
                foreach (var p in points)
                {
                    if (p.X > BRPoint.X)
                        BRPoint.X = p.X;
                    if (p.Y > BRPoint.Y)
                        BRPoint.Y = p.Y;
                }

                List<Point> ellipsePoints = new List<Point>()
                {
                    center,
                    BRPoint
                };

                return (ShapeType.Ellipse, ellipsePoints);
            }
        }

        private static (ShapeType, List<Point>) RectangleOrSquare(List<Point> points, Point center)
        {
            int percision = 20;
            double squareThreshold = 0.1;

            List<double> sides = new List<double>()
            {
                Math.Sqrt(
                    Math.Pow(points[0].X - points[3].X, 2) +
                    Math.Pow(points[0].X - points[3].X, 2))
            };

            for (int i = 0; i < 3; i++)
            {
                sides.Add(Math.Sqrt(
                    Math.Pow(points[i].X - points[i + 1].X, 2) +
                    Math.Pow(points[i].X - points[i + 1].X, 2)));
            }

            List<Point> sortedPoints = new List<Point>()
            {
                new Point(-1, -1),
                new Point(-1, -1),
                new Point(-1, -1),
                new Point(-1, -1)
            };

            foreach (var p in points)
            {
                if (center.X - p.X > 0 && center.Y - p.Y > 0)
                    sortedPoints[0] = p;
                else if (center.X - p.X > 0 && center.Y - p.Y < 0)
                    sortedPoints[1] = p;
                else if (center.X - p.X < 0 && center.Y - p.Y > 0)
                    sortedPoints[2] = p;
                else if (center.X - p.X < 0 && center.Y - p.Y < 0)
                    sortedPoints[3] = p;
            }

            if (sortedPoints.Any(c => c == new Point(-1, -1)))
                return (ShapeType.None, null);

            if (Math.Abs(sortedPoints[0].X - sortedPoints[1].X) > percision ||
                Math.Abs(sortedPoints[2].X - sortedPoints[3].X) > percision ||
                Math.Abs(sortedPoints[0].Y - sortedPoints[2].Y) > percision ||
                Math.Abs(sortedPoints[1].Y - sortedPoints[3].Y) > percision)
                return (ShapeType.None, null);

            List<Point> rectanglePoints = new List<Point>() { sortedPoints[0], sortedPoints[3] };

            double sideOne = Math.Abs(rectanglePoints[0].X - rectanglePoints[1].X);
            double sideTwo = Math.Abs(rectanglePoints[0].Y - rectanglePoints[1].Y);

            if (sideTwo < sideOne)
            {
                double temp = sideTwo;
                sideTwo = sideOne;
                sideOne = temp;
            }
            

            if (sideOne / sideTwo < 1 + squareThreshold &&
                sideOne / sideTwo > 1 - squareThreshold)
            {
                return (ShapeType.Square, rectanglePoints);
            }
            else
            {
                return (ShapeType.Rectangle, rectanglePoints);
            }
        }
    }
}
