using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shapes;
using Rectangle = Shapes.Rectangle;

namespace KP_Figures
{
    public partial class ReadWriteShapes : Form
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        private int operationCode;
        private List<Shape> shapes;
        private ReadWriteShapes()
        {
            InitializeComponent();
        }

        public static void SaveShapes(List<Shape> shapes)
        {
            ReadWriteShapes rws = new ReadWriteShapes();
            rws.operationCode = 0;
            rws.shapes = shapes;

            if (rws.ShowDialog() == DialogResult.OK)
                MessageBox.Show("File saved");
        }

        public static List<Shape> LoadShapes()
        {
            ReadWriteShapes rws = new ReadWriteShapes();
            rws.operationCode = 1;

            if (rws.ShowDialog() == DialogResult.OK)
                return rws.shapes;
            return null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxFileName.Text == string.Empty)
            {
                MessageBox.Show("Please enter file name first.");
                return;
            }

            if (operationCode == 0)
            {
                if (File.Exists(textBoxFileName.Text))
                {
                    if (MessageBox.Show("File already exitsts. Would you like to replace it?",
                        "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }

                using (var file = new FileStream(textBoxFileName.Text,
                    FileMode.OpenOrCreate, FileAccess.Write))
                    formatter.Serialize(file, shapes);
            }
            else if (operationCode == 1)
            {
                if (!File.Exists(textBoxFileName.Text))
                {
                    MessageBox.Show("File not found");
                    return;
                }

                using (var file = new FileStream(textBoxFileName.Text,
                    FileMode.Open, FileAccess.Read))
                    shapes = (List<Shape>)formatter.Deserialize(file);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
