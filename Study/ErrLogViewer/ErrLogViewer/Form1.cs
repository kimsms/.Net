using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrLogViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;

                dataGridView1.Rows.Clear();
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(' ', (char)StringSplitOptions.None);
                        string[] result = new string[3];
                        for (int i = 0; i < 2; i++)
                        {
                            result[0] += data[i];
                        }
                        result[1] = data[3];
                        for (int i = 0; i < data.Length - 4; i++)
                        {
                            result[2] += data[i + 4];
                            result[2] += " ";
                        }
                        dataGridView1.Rows.Add(result[0], result[1], result[2]);
                    }

                    sr.Close();
                }
            }
        }
    }
}
