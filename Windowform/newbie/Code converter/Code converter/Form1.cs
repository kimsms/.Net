using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                jinsu();            
        }

        public void jinsu()
        {
            long i = 0;
            string s = textBox1.Text;
            bool result = long.TryParse(s, out i);
            
            if (result == true)
            {
                long a = long.Parse(textBox1.Text);
                textBox2.Text = Convert.ToString(a, 2);
                textBox3.Text = Convert.ToString(a, 8);
                textBox4.Text = Convert.ToString(a, 16);
            }
            else if(textBox1.Text.Length < 1)
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("올바른 숫자를 입력하세요.");
                textBox1.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            jinsu();
        }
    }
}
