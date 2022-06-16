using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CopyProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void load_image_Click(object sender, EventArgs e)
        {
            String file_path = null;
            openFileDialog1.InitialDirectory = "C:\\Users\\user\\Desktop\\";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;
                pictureBox1.Load(file_path);
            }
        }

        private void saveImage_Button_Click(object sender, EventArgs e)
        {
            string save_route = @"C:\testFolder";

            if (!System.IO.Directory.Exists(save_route))
            {
                //System.IO.Directory.CreateDirectory(save_route);

                pictureBox1.Image.Save(save_route + "\\test.png",System.Drawing.Imaging.ImageFormat.Png);

            }
        }
    }
}
