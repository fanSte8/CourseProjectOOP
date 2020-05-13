using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
