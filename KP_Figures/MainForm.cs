using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shapes;
using Rectangle = Shapes.Rectangle;

namespace KP_Figures
{
    public partial class MainForm : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private List<Shape> selectShapes = new List<Shape>();
        private Tool selectTool = Tool.NotSelected;
        private bool canvasTrackingMouse = false;
        private Point startPoint;
        private List<Point> trianglePoints = new List<Point>();
        private Shape tempShape = null;
        private Color fillColor = Color.White;
        private Color lineColor = Color.Black;
        private int lineWidth = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddShape(Shape shape)
        {
            shape.LineColor = lineColor;
            shape.FillColor = fillColor;
            shape.LineWidth = lineWidth;
            shape.IsSelect = true;

            shape.Order = shapes
                .Select(s => s.Order)
                .OrderBy(o => o)
                .LastOrDefault() + 1;

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
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in shapes)
                item.DrawShape(e.Graphics);
        }

        private void drawSquare_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawRectangle(pen,
                        8, 8, drawSquare.Width - 16, drawSquare.Height - 16);
        }

        private void drawRectangle_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawRectangle(pen,
                        8, 12, drawSquare.Width - 16, drawSquare.Height - 24);
        }

        private void drawCircle_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawEllipse(pen,
                    8, 8, drawSquare.Width - 16, drawSquare.Height - 16);
        }

        private void drawEllipse_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawEllipse(pen,
                        6, 10, drawSquare.Width - 12, drawSquare.Height - 20);
        }

        private void drawTriangle_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawPolygon(pen,
                        new Point[]
                        {
                        new Point(drawTriangle.Width / 2, 8),
                        new Point(8, drawTriangle.Height - 8),
                        new Point(drawTriangle.Width - 8, drawTriangle.Height - 8)
                        });
        }

        

        private void singleShapeToolStripMenuItem_Click(object sender, EventArgs e) => selectTool = Tool.SelectSingle;

        private void multipleShapesToolStripMenuItem_Click(object sender, EventArgs e) => selectTool = Tool.SelectMultiple;

        private void moveToolStripMenuItem_Click(object sender, EventArgs e) => selectTool = Tool.MoveShape;

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            selectShapes.Clear();

            SelectShapeInfo.Text = "";

            UpdateForm();
            selectTool = Tool.NotSelected;
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
                lineWidth = w;
            else
                MessageBox.Show("Invalid input");
        }

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
                                trianglePoints[2].X, trianglePoints[2].Y,
                                lineColor, fillColor);

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

            Canvas.Refresh();
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
                        e.Location.X, e.Location.Y,
                        Color.Gray, Color.LightGray);
                    break;

                case Tool.DrawRectangle:

                    tempShape = new Rectangle(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y,
                        Color.Gray, Color.LightGray);
                    break;

                case Tool.DrawCircle:

                    tempShape = new Circle(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y,
                        Color.Gray, Color.LightGray);
                    break;

                case Tool.DrawEllipse:

                    tempShape = new Ellipse(
                        startPoint.X, startPoint.Y,
                        e.Location.X, e.Location.Y,
                        Color.Gray, Color.LightGray);
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
                        e.Location.X, e.Location.Y,
                        Color.Gray, Color.Gray)
                    { Solid = false };

                    foreach (var s in shapes)
                        s.IsSelect = frame.ContainsPoint(s.CenterPoint);

                    Canvas.Refresh();
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
                    Canvas.Refresh();

                    break;

                default:

                    canvasTrackingMouse = false;
                    Canvas.Refresh();

                    if (tempShape != null)
                    {
                        AddShape(tempShape);
                        tempShape = null;
                    }

                    Canvas.Refresh();

                    break;
            }

            UpdateForm();
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var s in shapes)
                s.IsSelect = false;
            selectShapes.Clear();

            ReadWriteShapes.SaveShapes(shapes);

            Canvas.Refresh();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Shape> load = ReadWriteShapes.LoadShapes();

            if (load != null)
                shapes = load; 
            UpdateForm();
        }

        private void drawSquare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawSquare;
            else if (e.Button == MouseButtons.Right)
            {
                ShapeEditorForm sef = new ShapeEditorForm(ShapeType.Square);
                sef.ShowDialog();
            }
        }

        private void drawRectangle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawRectangle;
            else if (e.Button == MouseButtons.Right)
            {
                ShapeEditorForm sef = new ShapeEditorForm(ShapeType.Rectangle);
                sef.ShowDialog();
            }
        }

        private void drawCircle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawCircle;
            else if (e.Button == MouseButtons.Right)
            {
                ShapeEditorForm sef = new ShapeEditorForm(ShapeType.Circle);
                sef.ShowDialog();
            }
        }

        private void drawEllipse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawEllipse;
            else if (e.Button == MouseButtons.Right)
            {
                ShapeEditorForm sef = new ShapeEditorForm(ShapeType.Ellipse);
                sef.ShowDialog();
            }
        }

        private void drawTriangle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                trianglePoints.Clear();
                selectTool = Tool.DrawTriangle;
            }
            else if (e.Button == MouseButtons.Right)
            {
                ShapeEditorForm sef = new ShapeEditorForm(ShapeType.Triangle);
                sef.ShowDialog();
            }
        }
    }
}
