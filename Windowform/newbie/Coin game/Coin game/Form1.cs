using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Coin_game
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        int price = 100;    //가격
        int Best_price = 100; //최고가
        int possesion = 1;  //보유 개수
        int funds = 200;    //자금
        public Form1()
        {
            InitializeComponent();
            define();
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Variance = ran.Next(0, 51); //변화
            int increase = ran.Next(0, 2);  //증감
            if (increase == 0)
            {
                if (price > 0)
                {
                    price = price + (-1 * Variance);
                    if (price <= 0)
                    {
                        possesion = 0;
                        define();
                        timer1.Stop();
                        MessageBox.Show("상장폐지가 되어 보유한 모든 증권이 사라졌습니다.", "상장폐지");
                        price = Best_price / 2;
                        Create_Chart();
                        timer1.Start();
                    }
                }

            }
            else
            {
                price = price + Variance;
            }
            if (price >= Best_price)
            {
                Best_price = price;
                label2.Text = "최고가 : " + Best_price;
            }
            label1.Text = "가격 : " + price;
            Chart_change();
            bank_transfer();

        }
        public void Create_Chart()
        {
            chart1.Series.Clear();  //차트 삭제후 생성
            chart1.Series.Add("Price graph");
            chart1.Series["Price graph"].ChartType = SeriesChartType.Line;
            chart1.Series["Price graph"].Color = Color.Red;
        }
        public void Chart_change()
        {
            chart1.Series["Price graph"].Points.Add(price);
        }
        public void define()
        {
            label1.Text = "가격 : " + price;
            label2.Text = "최고가 : " + Best_price;
            label4.Text = "보유 개수 : " + possesion;
            label5.Text = "자금 : " + funds;
        }
        public void bank_transfer()
        {
            if (Best_price >= 1000 && funds <= 100 && possesion == 0)
            {
                button6.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (funds >= numericUpDown1.Value * price)
            {
                funds = (int)(funds - (numericUpDown1.Value * price));
                possesion = (int)(possesion + numericUpDown1.Value);
                define();
            }
            else
            {
                MessageBox.Show("자금이 부족합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (possesion > 0)
            {
                funds = (int)(funds + (numericUpDown1.Value * price));
                possesion = (int)(possesion - numericUpDown1.Value);
                define();
            }
            else
            {
                MessageBox.Show("보유하고 있는 코인이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (funds / price > 0)
            {
                int maxbuying = funds / price;
                funds = (int)(funds - (maxbuying * price));
                possesion = (int)(possesion + maxbuying);
                define();
                MessageBox.Show(maxbuying + "개를 구매하였습니다.", "구매", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("자금이 부족합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (possesion > 0)
            {
                funds = (int)(funds + (possesion * price));
                MessageBox.Show(possesion + "개를 판매하여 " + possesion * price + "를 얻었습니다.", "판매", MessageBoxButtons.OK, MessageBoxIcon.Information);
                possesion = 0;
                define();
            }
            else
            {
                MessageBox.Show("보유하고 있는 코인이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Create_Chart();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)(1000 / numericUpDown2.Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            price = 100;    //가격
            Best_price = 100; //최고가
            possesion = 1;  //보유 개수
            funds = 200;    //자금
            define();
            DialogResult re = MessageBox.Show("파산하였습니다.\n다시 도전하시겠습니까?", "파산", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                timer1.Start();
                Create_Chart();
            }
            else if (re == DialogResult.No)
            {
                DialogResult exre = MessageBox.Show("게임을 종료할까요?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (exre == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult closere = MessageBox.Show("정말로 종료하시겠습니까?", "종로", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (closere == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }
    }
}
