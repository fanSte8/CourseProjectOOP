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
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in shapes)
                item.DrawShape(e.Graphics);
        }

        private void drawSquare_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawRectangle(pen,
                        4, 4, drawSquare.Width - 9, drawSquare.Height - 9);
        }

        private void drawRectangle_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawRectangle(pen,
                        4, 6, drawSquare.Width - 9, drawSquare.Height - 13);
        }

        private void drawCircle_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawEllipse(pen,
                    4, 4, drawSquare.Width - 9, drawSquare.Height - 9);
        }

        private void drawEllipse_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawEllipse(pen,
                        3, 6, drawSquare.Width - 7, drawSquare.Height - 13);
        }

        private void drawTriangle_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 1))
                e.Graphics.DrawPolygon(pen,
                        new Point[]
                        {
                        new Point(drawTriangle.Width / 2, 4),
                        new Point(4, drawTriangle.Height - 4),
                        new Point(drawTriangle.Width - 4, drawTriangle.Height - 4)
                        });
        }
    }
}
