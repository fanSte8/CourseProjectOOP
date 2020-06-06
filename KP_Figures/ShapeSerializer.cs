using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Shapes;



namespace KP_Figures
{
    class ShapeSerializer
    {
        public static void Save(List<Shape> shapes)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = @"D:\Images";
            sfd.DefaultExt = ".shps";
            sfd.Filter = "Shapes file|*.shps";
            sfd.Title = "Save shapes file";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var f = sfd.OpenFile())
                    formatter.Serialize(f, shapes);
            }
        }

        public static List<Shape> Open()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            OpenFileDialog ofd = new OpenFileDialog();
            List<Shape> load;

            ofd.InitialDirectory = @"D:\Images";
            ofd.Filter = "Shapes file|*.shps";
            ofd.DefaultExt = "*.shps";
            ofd.Title = "Open shapes file";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var f = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    load = (List<Shape>)formatter.Deserialize(f);
                }
            }
            else
            {
                load = null;
            }

            return load;
        }
    }
}
