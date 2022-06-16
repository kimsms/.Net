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

namespace openfileStudy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void showOpenFileDialog(string File)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Title = "Browse For Folder";

            OFD.Filter = "기마ㅉㄴ희All file | *.*";

            if(OFD.ShowDialog() == DialogResult.OK)
            {
                File = OFD.FileName;
                textBox1.Text = File;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showOpenFileDialog("");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox2.Text);

        }
    }
}
