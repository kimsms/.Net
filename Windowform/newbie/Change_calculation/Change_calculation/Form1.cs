using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Change_calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long Remoney = long.Parse(textBox1.Text);
            long count = 0;

            long[] coins = { 500, 100, 50, 10 };
            long[] countcoin = new long[4];

            for(int i = 0; i<coins.Length; i++)
            {
                long coin = coins[i];
                count = count + (Remoney / coin);
                countcoin[i] = (Remoney / coin);
                Remoney = Remoney % coin;
            }

            val500.Text = countcoin[0].ToString();
            val100.Text = countcoin[1].ToString();
            val50.Text = countcoin[2].ToString();
            val10.Text = countcoin[3].ToString();
            Total.Text = count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
                textBox1.Text = "0";
            button1_Click(sender, e);
        }
    }
}
