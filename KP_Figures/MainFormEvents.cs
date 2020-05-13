using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Shapes;
using Rectangle = Shapes.Rectangle;

namespace KP_Figures
{
    public partial class MainForm
    {
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (selectTool)
            {
                case Tool.NotSelected:
                    break;

                case Tool.DrawTriangle:

                    canvasTrackingMouse = true;

                    trianglePoints.Add(e.Location);

                    if (trianglePoints.Count == 3)
                    {
                        canvasTrackingMouse = false;

                        tempShape = new Triangle(
                                trianglePoints[0].X, trianglePoints[0].Y,
                                trianglePoints[1].X, trianglePoints[1].Y,
                                trianglePoints[2].X, trianglePoints[2].Y);

                        tempShape.LineColor = lineColor;
                        tempShape.FillColor = fillColor;
                        tempShape.LineWidth = lineWidth;
                        AddShape(tempShape);
                        tempShape = null;

                        trianglePoints.Clear();
                    }

                    break;

                case Tool.SelectSingle:

                    foreach (var s in selectShapes)
                        s.IsSelect = false;
                    selectShapes.Clear();

                    var selectShape = shapes
                        .Where(c => c.ContainsPoint(e.Location))
                        .OrderBy(o => o.Order)
                        .LastOrDefault();

                    if (selectShape != null)
                    {
                        selectShape.IsSelect = true;
                        selectShapes.Add(selectShape);
                    }

                    break;

                case Tool.MoveShape:

                    if (selectShapes.Any(c => c.ContainsPoint(e.Location)))
                        goto default;

                    break;

                default:

                    canvasTrackingMouse = true;
                    startPoint = e.Location;
                    break;

            }

            UpdateForm();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!canvasTrackingMouse)
                return;

            Canvas.Refresh();

            switch (selectTool)
            {
                case Tool.NotSelected:
                    break;

                case Tool.DrawSquare:

                    tempShape = new Square(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y);
                    break;

                case Tool.DrawRectangle:

                    tempShape = new Rectangle(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y);
                    break;

                case Tool.DrawCircle:

                    tempShape = new Circle(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y);
                    break;

                case Tool.DrawEllipse:

                    tempShape = new Ellipse(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y);
                    break;

                case Tool.DrawTriangle:

                    using (var g = Canvas.CreateGraphics())
                    {
                        if (trianglePoints.Count == 1)
                        {
                            using (var pen = new Pen(Color.Gray, 2))
                                g.DrawLine(pen,
                                    trianglePoints[0].X, trianglePoints[0].Y,
                                    e.Location.X, e.Location.Y);
                        }
                        else if (trianglePoints.Count == 2)
                        {
                            using (var brush = new SolidBrush(Color.LightGray))
                                g.FillPolygon(brush, new Point[]
                                {
                                    trianglePoints[0],
                                    trianglePoints[1],
                                    e.Location
                                });
                        }
                    }

                    break;

                case Tool.SelectMultiple:

                    var frame = new Rectangle(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y)
                    { Solid = false };

                    foreach (var s in shapes)
                        s.IsSelect = frame.ContainsPoint(s.CenterPoint);

                    using (var g = Canvas.CreateGraphics())
                        frame.DrawShape(g);

                    break;

                case Tool.MoveShape:

                    foreach (var s in selectShapes)
                        s.Move(e.Location.X - startPoint.X,
                               e.Location.Y - startPoint.Y);
                    startPoint = e.Location;

                    break;
            }

            using (var g = Canvas.CreateGraphics())
                tempShape?.DrawShape(g);
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (selectTool)
            {
                case Tool.NotSelected:
                    break;

                case Tool.DrawTriangle:
                    break;

                case Tool.SelectSingle:
                    break;

                case Tool.SelectMultiple:

                    selectShapes = shapes
                        .Where(c => c.IsSelect)
                        .ToList();

                    canvasTrackingMouse = false;

                    break;

                default:

                    canvasTrackingMouse = false;

                    if (tempShape != null)
                    {
                        tempShape.LineColor = lineColor;
                        tempShape.FillColor = fillColor;
                        tempShape.LineWidth = lineWidth;
                        AddShape(tempShape);
                        tempShape = null;
                    }

                    break;
            }

            UpdateForm();
        }
    }
}
