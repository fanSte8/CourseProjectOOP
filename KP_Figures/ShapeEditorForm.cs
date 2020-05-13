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

namespace KP_Figures
{
    public partial class ShapeEditorForm : Form
    {
        private Color fillColor = Color.White;
        private Color lineColor = Color.Black;
        private int lineWidth = 1;
        public ShapeEditorForm(ShapeType shapeType)
        {
            InitializeComponent();

            switch (shapeType)
            {
                case ShapeType.Circle:

                    panelCircle.BringToFront();
                    break;

                case ShapeType.Square:

                    panelSquare.BringToFront();
                    break;

                case ShapeType.Rectangle:

                    panelRectangle.BringToFront();
                    break;

                case ShapeType.Ellipse:

                    panelEllipse.BringToFront();
                    break;

                case ShapeType.Triangle:

                    panelTriangle.BringToFront();
                    break;
            }
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialogFill.ShowDialog() == DialogResult.OK)
                fillColor = colorDialogFill.Color;
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialogLine.ShowDialog() == DialogResult.OK)
                lineColor = colorDialogLine.Color;
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
    }
}
