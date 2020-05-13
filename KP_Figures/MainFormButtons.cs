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
    public partial class MainForm
    {
        private void singleShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTool = Tool.SelectSingle;
        }

        private void multipleShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTool = Tool.SelectMultiple;
        }
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTool = Tool.MoveShape;
        }
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
                var newShape = ShapeEditor.CreateShape(ShapeType.Square);

                if (newShape != null)
                    AddShape(newShape);
            }
        }

        private void drawRectangle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawRectangle;
            else if (e.Button == MouseButtons.Right)
            {
                var newShape = ShapeEditor.CreateShape(ShapeType.Rectangle);

                if (newShape != null)
                    AddShape(newShape);
            }
        }

        private void drawCircle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawCircle;
            else if (e.Button == MouseButtons.Right)
            {
                var newShape = ShapeEditor.CreateShape(ShapeType.Circle);

                if (newShape != null)
                    AddShape(newShape);
            }
        }

        private void drawEllipse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                selectTool = Tool.DrawEllipse;
            else if (e.Button == MouseButtons.Right)
            {
                var newShape = ShapeEditor.CreateShape(ShapeType.Ellipse);

                if (newShape != null)
                    AddShape(newShape);
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
                var newShape = ShapeEditor.CreateShape(ShapeType.Triangle);

                if (newShape != null)
                    AddShape(newShape);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editedShape = ShapeEditor.EditShape(selectShapes[0]);

            if (editedShape != null)
            {
                shapes.Remove(selectShapes[0]);
                selectShapes.Clear();
                shapes.Add(editedShape);
            }

            UpdateForm();
        }
    }
}
