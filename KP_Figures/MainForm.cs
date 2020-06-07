using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Shapes;
using Rectangle = Shapes.Rectangle;

namespace KP_Figures
{
    public partial class MainForm : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private List<Shape> selectShapes = new List<Shape>();
        private List<Point> trianglePoints = new List<Point>();
        private List<Point> shapePoints = new List<Point>();
        private Tool selectTool = Tool.Select;
        private bool canvasTrackingMouse = false;
        private bool selectMultiple = false;
        private Point startPoint;
        private Shape tempShape = null;
        private Color fillColor = Color.White;
        private Color lineColor = Color.Black;
        private int lineWidth = 1;

        public MainForm()
        {
            InitializeComponent();

            if (!System.IO.Directory.Exists(@"D:/Shapes saves"))
                System.IO.Directory.CreateDirectory(@"D:/Shapes saves");

            typeof(Panel)
                .GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(Canvas, true);
        }

        private void AddShape(Shape shape)
        {
            shape.IsSelect = true;

            shape.Order = shapes.Count == 0 ? 0 : shapes.Max(m => m.Order) + 1;

            foreach (var s in selectShapes)
                s.IsSelect = false;
            selectShapes.Clear();

            shapes.Add(shape);
            selectShapes.Add(shape); 
            UpdateForm();
        }
        private void UpdateStatusStrip()
        {
            if (selectShapes.Count != 1)
                SelectShapeInfo.Text = "";
            else
                SelectShapeInfo.Text = selectShapes[0].ToString();
        }

        private void UpdateForm()
        {
            Canvas.Refresh();

            UpdateStatusStrip();

            moveToolStripMenuItem.Enabled = selectShapes.Count == 0 ? false : true;

            editToolStripMenuItem.Enabled = selectShapes.Count == 1 ? true : false;
        }

        private void CreateAndAddShape(ShapeType st)
        {
            var newShape = ShapeEditor.CreateShape(st);

            if (newShape != null)
                AddShape(newShape);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in shapes.OrderBy(o => o.Order))
                item.DrawShape(e.Graphics);
        }

        //Buttons

        private void drawSquare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawSquare;
            else if (e.Button == MouseButtons.Right)
                CreateAndAddShape(ShapeType.Square);
        }

        private void drawRectangle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawRectangle;
            else if (e.Button == MouseButtons.Right)
                CreateAndAddShape(ShapeType.Rectangle);
        }

        private void drawCircle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawCircle;
            else if (e.Button == MouseButtons.Right)
                CreateAndAddShape(ShapeType.Circle);
        }

        private void drawEllipse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawEllipse;
            else if (e.Button == MouseButtons.Right)
                CreateAndAddShape(ShapeType.Ellipse);
        }

        private void drawTriangle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                trianglePoints.Clear();
                selectTool = Tool.DrawTriangle;
            }
            else if (e.Button == MouseButtons.Right)
                CreateAndAddShape(ShapeType.Triangle);
        }
        private void ButtonPencil_Click(object sender, EventArgs e)
        {
            selectTool = Tool.PencilDraw;
        }
        private void buttonSetWidth_Click(object sender, EventArgs e)
        {
            int w;

            if (textBoxLineWidth.Text == string.Empty)
            {
                MessageBox.Show("Please enter a value first.");
                return;
            }

            if (int.TryParse(textBoxLineWidth.Text, out w))
            {
                if (w <= 0)
                    MessageBox.Show("Width can't be a negative number!");
                else
                    lineWidth = w;
            }
            else
                MessageBox.Show("Invalid input");
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (selectColorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = selectColorDialog.Color;
                buttonLineColor.BackColor = selectColorDialog.Color;
            }
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            if (selectColorDialog.ShowDialog() == DialogResult.OK)
            {
                fillColor = selectColorDialog.Color;
                buttonFillColor.BackColor = selectColorDialog.Color;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            foreach (var s in selectShapes)
            {
                s.IsSelect = false;
                shapes.Remove(s);
            }

            selectShapes.Clear();
            Canvas.Refresh();
            UpdateForm();
        }

        //Tool strip menu items

        private void SelectShpaeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTool = Tool.Select;
        }
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTool = Tool.MoveShape;
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            selectShapes.Clear();
            UpdateForm();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saf = new SaveAsForm(shapes, this.Width, this.Height);
            saf.Show();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var load = ShapeSerializer.Open();

            if (load != null)
                shapes = load;

            UpdateForm();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editedShape = ShapeEditor.EditShape(selectShapes[0]);

            if (editedShape != null)
            {
                shapes.Remove(selectShapes[0]);
                selectShapes.Clear();

                shapes.Add(editedShape);
                editedShape.IsSelect = true;
                selectShapes.Add(editedShape);
            }

            UpdateForm();
        }

        //Events

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            switch (selectTool)
            {
                case Tool.DrawTriangle:

                    canvasTrackingMouse = true;

                    trianglePoints.Add(e.Location);

                    if (trianglePoints.Count == 3)
                    {
                        canvasTrackingMouse = false;

                        tempShape = new Triangle(
                                trianglePoints[0],
                                trianglePoints[1],
                                trianglePoints[2],
                                fillColor, lineColor, lineWidth);

                        AddShape(tempShape);
                        tempShape = null;

                        trianglePoints.Clear();
                    }

                    break;

                case Tool.Select:

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
                    else
                    {
                        selectMultiple = true;
                        goto default;
                    }

                    break;

                case Tool.MoveShape:

                    if (selectShapes.Any(c => c.ContainsPoint(e.Location)))
                        goto default;

                    break;

                case Tool.PencilDraw:

                    shapePoints.Clear();
                    shapePoints.Add(e.Location);
                    goto default;

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

            if (selectTool != Tool.PencilDraw)
                Canvas.Refresh();

            switch (selectTool)
            {
                case Tool.DrawSquare:

                    tempShape = new Square(
                        startPoint, e.Location,
                        fillColor, lineColor, lineWidth);
                    break;

                case Tool.DrawRectangle:

                    tempShape = new Rectangle(
                        startPoint, e.Location,
                        fillColor, lineColor, lineWidth);
                    break;

                case Tool.DrawCircle:

                    tempShape = new Circle(
                        startPoint, e.Location,
                        fillColor, lineColor, lineWidth);
                    break;

                case Tool.DrawEllipse:

                    tempShape = new Ellipse(
                        startPoint, e.Location,
                        fillColor, lineColor, lineWidth);
                    break;

                case Tool.DrawTriangle:

                    using (var g = Canvas.CreateGraphics())
                    {
                        if (trianglePoints.Count == 1)
                        {
                            using (var pen = new Pen(lineColor, lineWidth))
                                g.DrawLine(pen,
                                    trianglePoints[0].X, trianglePoints[0].Y,
                                    e.Location.X, e.Location.Y);
                        }
                        else if (trianglePoints.Count == 2)
                        {
                            using (var brush = new SolidBrush(fillColor))
                                g.FillPolygon(brush, new Point[]
                                {
                                    trianglePoints[0],
                                    trianglePoints[1],
                                    e.Location
                                });
                            using (var pen = new Pen(lineColor, lineWidth))
                                g.DrawPolygon(pen, new Point[]
                                {
                                    trianglePoints[0],
                                    trianglePoints[1],
                                    e.Location
                                });
                        }
                    }

                    break;

                case Tool.Select:

                    var frame = new Rectangle(
                        startPoint, e.Location,
                        Color.LightGray, Color.LightGray, 1)
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

                case Tool.PencilDraw:

                    using (var g = Canvas.CreateGraphics())
                    {
                        using (var p = new Pen(Color.Black, 3))
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                            g.DrawLine(p, startPoint, e.Location);
                        }
                    }

                    shapePoints.Add(e.Location);
                    startPoint = e.Location;

                    break;
            }

            using (var g = Canvas.CreateGraphics())
                tempShape?.DrawShape(g);
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            switch (selectTool)
            {
                case Tool.DrawTriangle:
                    break;

                case Tool.Select:

                    if (!selectMultiple)
                        break;

                    selectShapes = shapes
                        .Where(c => c.IsSelect)
                        .ToList();

                    canvasTrackingMouse = false;
                    selectMultiple = false;

                    break;

                case Tool.PencilDraw:

                    (ShapeType type, List<Point> points) result = 
                        ShapeDetector.Check(shapePoints, Canvas.Width, Canvas.Height);

                    switch (result.type)
                    {
                        case ShapeType.Triangle:

                            tempShape = new Triangle(
                                result.points[0],
                                result.points[1],
                                result.points[2],
                                fillColor, lineColor, lineWidth);

                            break;

                        case ShapeType.Circle:

                            tempShape = new Circle(
                                    result.points[0],
                                    result.points[1],
                                    fillColor, lineColor, lineWidth);

                            break;

                        case ShapeType.Ellipse:

                            tempShape = new Ellipse(
                                result.points[0],
                                result.points[1],
                                fillColor, lineColor, lineWidth);

                            break;

                        case ShapeType.Square:

                            tempShape = new Square(
                                result.points[0],
                                result.points[1],
                                fillColor, lineColor, lineWidth);

                            break;

                        case ShapeType.Rectangle:

                            tempShape = new Rectangle(
                                result.points[0],
                                result.points[1],
                                fillColor, lineColor, lineWidth);

                            break;
                    }

                    goto default;

                default:

                    canvasTrackingMouse = false;

                    if (tempShape != null)
                    {
                        AddShape(tempShape);
                        tempShape = null;
                    }
                    

                    break;
            }

            UpdateForm();
        }
    }
}
