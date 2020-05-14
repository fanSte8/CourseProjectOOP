using System;
using System.Drawing;
using System.Windows.Forms;
using Shapes;
using Rectangle = Shapes.Rectangle;

namespace KP_Figures
{
    public partial class ShapeEditor : Form
    {
        ShapeType shapeType;
        Color fillColor = Color.White;
        Color lineColor = Color.Black;
        int lineWidth = 1;
        private Shape shape;
        private ShapeEditor(ShapeType shapeType)
        {
            InitializeComponent();

            this.shapeType = shapeType;

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

        public Shape Shape
        {
            get
            {
                return shape;
            }

            set
            {
                fillColor = value.FillColor;
                buttonFillColor.BackColor = value.FillColor;

                lineColor = value.LineColor;
                buttonLineColor.BackColor = value.LineColor;

                textBoxLineWidth.Text = value.LineWidth.ToString();

                switch (shapeType)
                {
                    case ShapeType.Square:

                        textBoxSquareSide.Text = ((Square)value).SideLength.ToString();
                        textBoxXSquare.Text = ((Square)value).TopLeftPoint.X.ToString();
                        textBoxYSquare.Text = ((Square)value).TopLeftPoint.Y.ToString();

                        break;

                    case ShapeType.Rectangle:

                        textBoxRectangleWidth.Text = ((Rectangle)value).Width.ToString();
                        textBoxRectangleHeight.Text = ((Rectangle)value).Height.ToString();
                        textBoxXRectangle.Text = ((Rectangle)value).TopLeftPoint.X.ToString();
                        textBoxYRectangle.Text = ((Rectangle)value).TopLeftPoint.Y.ToString();

                        break;

                    case ShapeType.Circle:

                        textBoxCircleRadius.Text = ((Circle)value).Radius.ToString();
                        textBoxXCircle.Text = ((Circle)value).CenterPoint.X.ToString();
                        textBoxYCircle.Text = ((Circle)value).CenterPoint.Y.ToString();

                        break;

                    case ShapeType.Ellipse:

                        textBoxEllipseWidth.Text = (((Ellipse)value).SemiXAxis * 2).ToString();
                        textBoxEllipseHeight.Text = (((Ellipse)value).SemiYAxis * 2).ToString();
                        textBoxXEllipse.Text = ((Ellipse)value).CenterPoint.X.ToString();
                        textBoxYEllipse.Text = ((Ellipse)value).CenterPoint.Y.ToString();

                        break;

                    case ShapeType.Triangle:

                        textBoxXTriangleFirst.Text = ((Triangle)value).PointA.X.ToString();
                        textBoxYTriangleFirst.Text = ((Triangle)value).PointA.Y.ToString();
                        textBoxXTriangleSecond.Text = ((Triangle)value).PointB.X.ToString();
                        textBoxYTriangleSecond.Text = ((Triangle)value).PointB.Y.ToString();
                        textBoxXTriangleThird.Text = ((Triangle)value).PointC.X.ToString();
                        textBoxYTriangleThird.Text = ((Triangle)value).PointC.Y.ToString();

                        break;
                }
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            switch (shapeType)
            {
                case ShapeType.Square:

                    int sqx = int.Parse(textBoxXSquare.Text);
                    int sqy = int.Parse(textBoxYSquare.Text);
                    int side = int.Parse(textBoxSquareSide.Text);

                    shape = new Square(
                        sqx, sqy, sqx + side, sqy + side);

                    break;

                case ShapeType.Rectangle:

                    int recw = int.Parse(textBoxRectangleWidth.Text);
                    int rech = int.Parse(textBoxRectangleHeight.Text);
                    int recx = int.Parse(textBoxXRectangle.Text);
                    int recy = int.Parse(textBoxYRectangle.Text);

                    shape = new Rectangle(
                        recx, recy, recx + recw, recy + rech);

                    break;

                case ShapeType.Circle:

                    int r = int.Parse(textBoxCircleRadius.Text);
                    int ccx = int.Parse(textBoxXCircle.Text);
                    int ccy = int.Parse(textBoxYCircle.Text);

                    shape = new Circle(
                        ccx, ccy, ccx + r, ccy);

                    break;

                case ShapeType.Ellipse:

                    int ecx = int.Parse(textBoxXEllipse.Text);
                    int ecy = int.Parse(textBoxYEllipse.Text);
                    int eh = int.Parse(textBoxEllipseHeight.Text) / 2;
                    int ew = int.Parse(textBoxEllipseWidth.Text) / 2;

                    shape = new Ellipse(
                        ecx, ecy, ecx + ew, ecy + eh);

                    break;

                case ShapeType.Triangle:

                    int ax = int.Parse(textBoxXTriangleFirst.Text);
                    int ay = int.Parse(textBoxYTriangleFirst.Text);
                    int bx = int.Parse(textBoxXTriangleSecond.Text);
                    int by = int.Parse(textBoxYTriangleSecond.Text);
                    int cx = int.Parse(textBoxXTriangleThird.Text);
                    int cy = int.Parse(textBoxYTriangleThird.Text);

                    shape = new Triangle(
                        ax, ay, bx, by, cx, cy);

                    break;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ButtonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialogLine.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialogLine.Color;
                buttonLineColor.BackColor = colorDialogLine.Color;
            }
        }

        private void ButtonFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialogFill.ShowDialog() == DialogResult.OK)
            {
                fillColor = colorDialogFill.Color;
                buttonFillColor.BackColor = colorDialogFill.Color;
            }
        }

        private void ButtonSetWidth_Click(object sender, EventArgs e)
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

        public static Shape CreateShape(ShapeType st)
        {
            ShapeEditor se = new ShapeEditor(st);

            if (se.ShowDialog() == DialogResult.OK)
            {
                se.Shape.LineColor = se.lineColor;
                se.Shape.FillColor = se.fillColor;
                se.Shape.LineWidth = se.lineWidth;

                return se.Shape;
            }

            return null;
        }

        public static Shape EditShape(Shape s)
        {
            int ord = s.Order;

            ShapeEditor se = new ShapeEditor(s.Type);
            se.Shape = s;

            if (se.ShowDialog() == DialogResult.OK)
            {
                se.Shape.LineWidth = se.lineWidth;
                se.Shape.LineColor = se.lineColor;
                se.Shape.FillColor = se.fillColor;
                se.Shape.Order = ord;

                return se.Shape;
            }

            return null;
        }
    }
}
