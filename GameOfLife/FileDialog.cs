using System;
using System.Windows.Forms;

namespace Life
{
    public static class FileDialog
    {
        public static string SelectFile(string initial = null, string filter = null)
        {
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (initial != null)
                {
                    openFileDialog.InitialDirectory = initial;
                }
                if (filter != null)
                {
                    openFileDialog.Filter = filter;
                }
                //openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                
            }
            return (filePath);
        }
    }
}
