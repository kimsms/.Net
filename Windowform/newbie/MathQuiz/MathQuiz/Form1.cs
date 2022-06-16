using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {


        Random randomizer = new Random();

        int testValue;
        int testValue2;

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int timesed;
        int timesed2;

        int nanu;
        int nanu2;

        int timeLeft;

        int mode;

        int pogi;


        public void StartTheQuiz()
        {

            if (mode == 0)
            {
                addend1 = randomizer.Next(51);
                addend2 = randomizer.Next(51);

                plusLeftLabel.Text = addend1.ToString();
                plusRightLabel.Text = addend2.ToString();

                sum.Value = 0;

                minuend = randomizer.Next(1, 101);
                subtrahend = randomizer.Next(1, minuend);

                minusLeftLabel.Text = minuend.ToString();
                minusRightLabel.Text = subtrahend.ToString();
                difference.Value = 0;

                timesed = randomizer.Next(1, 11);
                timesed2 = randomizer.Next(1, 11);

                timesLeftLabel.Text = timesed.ToString();
                timesRightLabel.Text = timesed2.ToString();

                product.Value = 0;

                nanu = randomizer.Next(51);
                nanu2 = randomizer.Next(2, nanu);

                dividedLeftLabel.Text = nanu.ToString();
                dividedRightLabel.Text = nanu2.ToString();


                quotient.Value = 0;

                test3.Visible = true;
                timeLeft = 30 + testValue - testValue2;
                timeLabel.Text = 30 + testValue - testValue2 + "seconds";
                timer1.Start();
            }
            else if (mode == 1)
            {
                addend1 = randomizer.Next(101);
                addend2 = randomizer.Next(101);

                plusLeftLabel.Text = addend1.ToString();
                plusRightLabel.Text = addend2.ToString();

                sum.Value = 0;

                minuend = randomizer.Next(1, 1001);
                subtrahend = randomizer.Next(1, minuend);

                minusLeftLabel.Text = minuend.ToString();
                minusRightLabel.Text = subtrahend.ToString();
                difference.Value = 0;

                timesed = randomizer.Next(1, 101);
                timesed2 = randomizer.Next(1, 101);

                timesLeftLabel.Text = timesed.ToString();
                timesRightLabel.Text = timesed2.ToString();

                product.Value = 0;

                nanu = randomizer.Next(101);
                nanu2 = randomizer.Next(1, nanu);

                dividedLeftLabel.Text = nanu.ToString();
                dividedRightLabel.Text = nanu2.ToString();


                quotient.Value = 0;

                pogi = 1;
                test3.Visible = true;
                test3.Text = "포기";
                timeLeft = 30;
                timeLabel.Text = "하드모드";
                timer1.Start();
            }
            //addend1 = randomizer.Next(51);
            //addend2 = randomizer.Next(51);

            //plusLeftLabel.Text = addend1.ToString();
            //plusRightLabel.Text = addend2.ToString();

            //sum.Value = 0;

            //minuend = randomizer.Next(1, 101);
            //subtrahend = randomizer.Next(1, minuend);

            //minusLeftLabel.Text = minuend.ToString();
            //minusRightLabel.Text = subtrahend.ToString();
            //difference.Value = 0;

            //timesed = randomizer.Next(1, 11);
            //timesed2 = randomizer.Next(1, 11);

            //timesLeftLabel.Text = timesed.ToString();
            //timesRightLabel.Text = timesed2.ToString();

            //product.Value = 0;

            //nanu = randomizer.Next(51);
            //nanu2 = randomizer.Next(1, 11);

            //dividedLeftLabel.Text = nanu.ToString();
            //dividedRightLabel.Text = nanu2.ToString();


            //quotient.Value = 0;

            //timeLeft = 30 + testValue - testValue2;
            //timeLabel.Text = 30 + testValue - testValue2 + "seconds";
            //timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
            test3.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
            test.Enabled = false;
            test2.Enabled = false;
            test3.Enabled = true;
            remode.Enabled = false;
            test.Visible = false;
            test2.Visible = false;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("모든 문제를 맞추었습니다!", "승리!");
                startButton.Enabled = true;
                test.Enabled = true;
                test2.Enabled = true;
                timeLabel.Text = "30 seconds";
                testValue = 0;
                testValue2 = 0;
                test3.Enabled = false;
                remode.Enabled = true;
                pogi = 0;
                test3.Text = "5초 추가";
                test3.Visible = false;

                if (mode == 0)
                {
                    test.Visible = true;
                    test2.Visible = true;
                }
            }
            else if (timeLeft > 0)
            {
                //if (mode == 0)
                //{
                //    timeLeft = timeLeft - 1;
                //    timeLabel.Text = timeLeft + "seconds";
                //}
                //else if (mode == 1)
                //{
                //    timeLeft = timeLeft - 2;
                //    timeLabel.Text = timeLeft + "seconds";
                //}
                if (mode == 0)
                {
                    timeLeft = timeLeft - 1;
                    timeLabel.Text = timeLeft + "seconds";
                }
                else if (mode == 1)
                {
                    timeLeft = timeLeft - 1;
                    timeLabel.Text = "하드모드";
                }




            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "시간초과!";
                MessageBox.Show("시간내에 맞추지 못하였습니다.", "패배");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = timesed * timesed2;
                quotient.Value = nanu / nanu2;
                startButton.Enabled = true;
                test.Enabled = true;
                test2.Enabled = true;
                timeLabel.Text = "30 seconds";
                testValue = 0;
                testValue2 = 0;
                test3.Enabled = false;
                remode.Enabled = true;
                pogi = 0;
                test3.Text = "5초 추가";

                if (mode == 0)
                {
                    test.Visible = true;
                    test2.Visible = true;
                }

            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value) && (timesed * timesed2 == product.Value) && (nanu / nanu2 == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthofAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthofAnswer);
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            testValue = testValue + 1;
            timeLabel.Text = (30 + testValue - testValue2) + "seconds";
        }

        private void test2_Click(object sender, EventArgs e)
        {
            testValue2 = testValue2 + 1;
            timeLabel.Text = (30 + testValue - testValue2) + "seconds";
        }

        private void test3_Click(object sender, EventArgs e)
        {
            pogi += 1;
            if (pogi == 1)
            {
                timeLeft = timeLeft + 5;
                test3.Text = "포기";
                timeLabel.Text = " 5초 추가";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "포기";
                MessageBox.Show("게임을 포기했습니다.", "패배");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = timesed * timesed2;
                quotient.Value = nanu / nanu2;
                startButton.Enabled = true;
                test.Enabled = true;
                test2.Enabled = true;
                timeLabel.Text = "30 seconds";
                testValue = 0;
                testValue2 = 0;
                test3.Enabled = false;
                remode.Enabled = true;
                pogi = 0;
                test3.Text = "5초 추가";

                if (mode == 0)
                {
                    test.Visible = true;
                    test2.Visible = true;
                }

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                remode.Text = "Easy mode";
                mode = 1;
                nanido.Text = "Hard Mode";
                BackColor = Color.OrangeRed;
                timeLeft = 30;
                timeLabel.Text = 30 + "seconds";
                test.Visible = false;
                test2.Visible = false;
                test3.Visible = false;
            }
            else
            {
                remode.Text = "Hard mode";
                mode = 0;
                nanido.Text = "";
                BackColor = Color.LightGray;
                test.Visible = true;
                test2.Visible = true;
                timeLeft = 30 + testValue - testValue2;
                timeLabel.Text = 30 + testValue - testValue2 + "seconds";
                test3.Visible = false;

            }

        }

        private void hidebutton_Click(object sender, EventArgs e)
        {



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            hideLabel.Visible = false;
            okButton.Visible = false;
        }
    }
}
