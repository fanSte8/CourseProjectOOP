using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Shapes;

namespace KP_Figures
{
    public partial class SaveAsForm : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private int width;
        private int height;

        public SaveAsForm(List<Shape> s, int w, int h)
        {
            shapes = s;
            width = w;
            height = h;

            foreach (var sh in shapes)
                sh.IsSelect = false;

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ShapeSerializer.Save(shapes);
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                foreach (var s in shapes)
                    s.DrawShape(g);
            }

            var sfd = new SaveFileDialog();
            sfd.DefaultExt = ".jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            this.Close();
        }
    }
}
