using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AimMaster
{
    public partial class Form1 : Form
    {
        Random ran = new Random();  //  변수 선언
        int ranval;
        int Fcount;
        bool gameStop;
        int score;
        int playTIme;
        int playTimeS;

        public Form1()
        {
            InitializeComponent();
            timer2.Start();
            timer3.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)    // 랜덤 타이밍에 버튼 표시
        {
            timer1.Interval = ran.Next(100, 1001);
            timer1.Start();
            timer2.Stop();
        }
        private void timer3_Tick(object sender, EventArgs e)    // 플레이 타임 저장
        {
            playTimeS++;
            if (playTimeS > 60)
            {
                playTIme++;
                playTimeS -= 60;
            }
        }

        public void falseCount()    // 패배 조건
        {
            if (Fcount > 4)
            {
                gameStop = true;
            }
        }
        public void restart()   // 재시작
        {
            Application.Restart();
        }
        public void stopmessage()   // 패배 화면
        {
            MessageBox.Show("점수 : " + score + "점\n플레이 타임 : " + playTIme + "분 " + playTimeS + "초", "게임오버");
            button61.Visible = true;
            button61.BackColor = Color.White;
            button61.Text = "다시하기";
        }

        //--------------------------------------------
        //--------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)    //랜덤으로 표시
        {
            falseCount();
            ranval = ran.Next(1, 122);
            if (ranval == 1 && button1.Visible == false)
            {

                button1.Visible = true;
                Fcount++;


            }
            else if (ranval == 2 && button2.Visible == false)
            {

                button2.Visible = true;
                Fcount++;
            }
            else if (ranval == 3 && button3.Visible == false)
            {

                button3.Visible = true;
                Fcount++;

            }
            else if (ranval == 4 && button4.Visible == false)
            {

                button4.Visible = true;
                Fcount++;

            }
            else if (ranval == 5 && button5.Visible == false)
            {

                button5.Visible = true;
                Fcount++;

            }
            else if (ranval == 6 && button6.Visible == false)
            {

                button6.Visible = true;
                Fcount++;

            }
            else if (ranval == 7 && button7.Visible == false)
            {

                button7.Visible = true;
                Fcount++;

            }
            else if (ranval == 8 && button8.Visible == false)
            {

                button8.Visible = true;
                Fcount++;

            }
            else if (ranval == 9 && button9.Visible == false)
            {

                button9.Visible = true;
                Fcount++;

            }
            else if (ranval == 10 && button10.Visible == false)
            {

                button10.Visible = true;
                Fcount++;

            }
            else if (ranval == 11 && button11.Visible == false)
            {

                button11.Visible = true;
                Fcount++;

            }
            else if (ranval == 12 && button12.Visible == false)
            {

                button12.Visible = true;
                Fcount++;

            }
            else if (ranval == 13 && button13.Visible == false)
            {

                button13.Visible = true;
                Fcount++;

            }
            else if (ranval == 14 && button14.Visible == false)
            {

                button14.Visible = true;
                Fcount++;

            }
            else if (ranval == 15 && button15.Visible == false)
            {

                button15.Visible = true;
                Fcount++;

            }
            else if (ranval == 16 && button16.Visible == false)
            {

                button16.Visible = true;
                Fcount++;

            }
            else if (ranval == 17 && button17.Visible == false)
            {

                button17.Visible = true;
                Fcount++;

            }
            else if (ranval == 18 && button18.Visible == false)
            {

                button18.Visible = true;
                Fcount++;

            }
            else if (ranval == 19 && button18.Visible == false)
            {

                button19.Visible = true;
                Fcount++;

            }
            else if (ranval == 20 && button20.Visible == false)
            {

                button20.Visible = true;
                Fcount++;

            }
            else if (ranval == 21 && button21.Visible == false)
            {

                button21.Visible = true;
                Fcount++;

            }
            else if (ranval == 22 && button22.Visible == false)
            {

                button22.Visible = true;
                Fcount++;

            }
            else if (ranval == 23 && button23.Visible == false)
            {

                button23.Visible = true;
                Fcount++;

            }
            else if (ranval == 24 && button24.Visible == false)
            {

                button24.Visible = true;
                Fcount++;

            }
            else if (ranval == 25 && button25.Visible == false)
            {

                button25.Visible = true;
                Fcount++;

            }
            else if (ranval == 26 && button26.Visible == false)
            {

                button26.Visible = true;
                Fcount++;

            }
            else if (ranval == 27 && button27.Visible == false)
            {

                button27.Visible = true;
                Fcount++;

            }
            else if (ranval == 28 && button28.Visible == false)
            {

                button28.Visible = true;
                Fcount++;

            }
            else if (ranval == 29 && button29.Visible == false)
            {

                button29.Visible = true;
                Fcount++;

            }
            else if (ranval == 30 && button30.Visible == false)
            {

                button30.Visible = true;
                Fcount++;

            }
            else if (ranval == 31 && button31.Visible == false)
            {

                button31.Visible = true;
                Fcount++;

            }
            else if (ranval == 32 && button32.Visible == false)
            {

                button32.Visible = true;
                Fcount++;

            }
            else if (ranval == 33 && button33.Visible == false)
            {

                button33.Visible = true;
                Fcount++;

            }
            else if (ranval == 34 && button34.Visible == false)
            {

                button34.Visible = true;
                Fcount++;

            }
            else if (ranval == 35 && button35.Visible == false)
            {

                button35.Visible = true;
                Fcount++;

            }
            else if (ranval == 36 && button36.Visible == false)
            {

                button36.Visible = true;
                Fcount++;

            }
            else if (ranval == 37 && button37.Visible == false)
            {

                button37.Visible = true;
                Fcount++;

            }
            else if (ranval == 38 && button38.Visible == false)
            {

                button38.Visible = true;
                Fcount++;

            }
            else if (ranval == 39 && button39.Visible == false)
            {

                button39.Visible = true;
                Fcount++;

            }
            else if (ranval == 40 && button40.Visible == false)
            {

                button40.Visible = true;
                Fcount++;

            }
            else if (ranval == 41 && button41.Visible == false)
            {

                button41.Visible = true;
                Fcount++;

            }
            else if (ranval == 42 && button42.Visible == false)
            {

                button42.Visible = true;
                Fcount++;

            }
            else if (ranval == 43 && button43.Visible == false)
            {

                button43.Visible = true;
                Fcount++;

            }
            else if (ranval == 44 && button44.Visible == false)
            {

                button44.Visible = true;
                Fcount++;

            }
            else if (ranval == 45 && button45.Visible == false)
            {

                button45.Visible = true;
                Fcount++;

            }
            else if (ranval == 46 && button46.Visible == false)
            {

                button46.Visible = true;
                Fcount++;

            }
            else if (ranval == 47 && button47.Visible == false)
            {

                button47.Visible = true;
                Fcount++;

            }
            else if (ranval == 48 && button48.Visible == false)
            {

                button48.Visible = true;
                Fcount++;

            }
            else if (ranval == 49 && button49.Visible == false)
            {

                button49.Visible = true;
                Fcount++;

            }
            else if (ranval == 50 && button50.Visible == false)
            {

                button50.Visible = true;
                Fcount++;

            }
            else if (ranval == 51 && button51.Visible == false)
            {

                button51.Visible = true;
                Fcount++;

            }
            else if (ranval == 52 && button52.Visible == false)
            {

                button52.Visible = true;
                Fcount++;

            }
            else if (ranval == 53 && button53.Visible == false)
            {

                button53.Visible = true;
                Fcount++;

            }
            else if (ranval == 54 && button54.Visible == false)
            {

                button54.Visible = true;
                Fcount++;

            }
            else if (ranval == 55 && button55.Visible == false)
            {

                button55.Visible = true;
                Fcount++;

            }
            else if (ranval == 56 && button56.Visible == false)
            {

                button56.Visible = true;
                Fcount++;

            }
            else if (ranval == 57 && button57.Visible == false)
            {

                button57.Visible = true;
                Fcount++;

            }
            else if (ranval == 58 && button58.Visible == false)
            {

                button58.Visible = true;
                Fcount++;

            }
            else if (ranval == 59 && button59.Visible == false)
            {

                button59.Visible = true;
                Fcount++;

            }
            else if (ranval == 60 && button60.Visible == false)
            {

                button60.Visible = true;
                Fcount++;

            }
            else if (ranval == 61 && button61.Visible == false)
            {

                button61.Visible = true;
                Fcount++;

            }
            else if (ranval == 62 && button62.Visible == false)
            {

                button62.Visible = true;
                Fcount++;

            }
            else if (ranval == 63 && button63.Visible == false)
            {

                button63.Visible = true;
                Fcount++;

            }
            else if (ranval == 64 && button64.Visible == false)
            {

                button64.Visible = true;
                Fcount++;

            }
            else if (ranval == 65 && button65.Visible == false)
            {

                button65.Visible = true;
                Fcount++;

            }
            else if (ranval == 66 && button66.Visible == false)
            {

                button66.Visible = true;
                Fcount++;

            }
            else if (ranval == 67 && button67.Visible == false)
            {

                button67.Visible = true;
                Fcount++;

            }
            else if (ranval == 68 && button68.Visible == false)
            {

                button68.Visible = true;
                Fcount++;

            }
            else if (ranval == 69 && button69.Visible == false)
            {

                button69.Visible = true;
                Fcount++;

            }
            else if (ranval == 70 && button70.Visible == false)
            {

                button70.Visible = true;
                Fcount++;

            }
            else if (ranval == 71 && button71.Visible == false)
            {

                button71.Visible = true;
                Fcount++;

            }
            else if (ranval == 72 && button72.Visible == false)
            {

                button72.Visible = true;
                Fcount++;

            }
            else if (ranval == 73 && button73.Visible == false)
            {

                button73.Visible = true;
                Fcount++;

            }
            else if (ranval == 74 && button74.Visible == false)
            {

                button74.Visible = true;
                Fcount++;

            }
            else if (ranval == 75 && button75.Visible == false)
            {

                button75.Visible = true;
                Fcount++;

            }
            else if (ranval == 76 && button76.Visible == false)
            {

                button76.Visible = true;
                Fcount++;

            }
            else if (ranval == 77 && button77.Visible == false)
            {

                button77.Visible = true;
                Fcount++;

            }
            else if (ranval == 78 && button78.Visible == false)
            {

                button78.Visible = true;
                Fcount++;

            }
            else if (ranval == 79 && button79.Visible == false)
            {

                button79.Visible = true;
                Fcount++;

            }
            else if (ranval == 80 && button80.Visible == false)
            {

                button80.Visible = true;
                Fcount++;

            }
            else if (ranval == 81 && button81.Visible == false)
            {

                button81.Visible = true;
                Fcount++;

            }
            else if (ranval == 82 && button82.Visible == false)
            {

                button82.Visible = true;
                Fcount++;

            }
            else if (ranval == 83 && button83.Visible == false)
            {

                button83.Visible = true;
                Fcount++;

            }
            else if (ranval == 84 && button84.Visible == false)
            {

                button84.Visible = true;
                Fcount++;

            }
            else if (ranval == 85 && button85.Visible == false)
            {

                button85.Visible = true;
                Fcount++;

            }
            else if (ranval == 86 && button86.Visible == false)
            {

                button86.Visible = true;
                Fcount++;

            }
            else if (ranval == 87 && button87.Visible == false)
            {

                button87.Visible = true;
                Fcount++;

            }
            else if (ranval == 88 && button88.Visible == false)
            {

                button88.Visible = true;
                Fcount++;

            }
            else if (ranval == 89 && button89.Visible == false)
            {

                button89.Visible = true;
                Fcount++;

            }
            else if (ranval == 90 && button90.Visible == false)
            {

                button90.Visible = true;
                Fcount++;

            }
            else if (ranval == 91 && button91.Visible == false)
            {

                button91.Visible = true;
                Fcount++;

            }
            else if (ranval == 92 && button92.Visible == false)
            {

                button92.Visible = true;
                Fcount++;

            }
            else if (ranval == 93 && button93.Visible == false)
            {

                button93.Visible = true;
                Fcount++;

            }
            else if (ranval == 94 && button94.Visible == false)
            {

                button94.Visible = true;
                Fcount++;

            }
            else if (ranval == 95 && button95.Visible == false)
            {

                button95.Visible = true;
                Fcount++;

            }
            else if (ranval == 96 && button96.Visible == false)
            {

                button96.Visible = true;
                Fcount++;

            }
            else if (ranval == 97 && button97.Visible == false)
            {

                button97.Visible = true;
                Fcount++;

            }
            else if (ranval == 98 && button98.Visible == false)
            {

                button98.Visible = true;
                Fcount++;

            }
            else if (ranval == 99 && button99.Visible == false)
            {

                button99.Visible = true;
                Fcount++;

            }
            else if (ranval == 100 && button100.Visible == false)
            {

                button100.Visible = true;
                Fcount++;

            }
            else if (ranval == 101 && button101.Visible == false)
            {

                button101.Visible = true;
                Fcount++;

            }
            else if (ranval == 102 && button102.Visible == false)
            {

                button102.Visible = true;
                Fcount++;

            }
            else if (ranval == 103 && button103.Visible == false)
            {

                button103.Visible = true;
                Fcount++;

            }
            else if (ranval == 104 && button104.Visible == false)
            {

                button104.Visible = true;
                Fcount++;

            }
            else if (ranval == 105 && button105.Visible == false)
            {

                button105.Visible = true;
                Fcount++;

            }
            else if (ranval == 106 && button106.Visible == false)
            {

                button106.Visible = true;
                Fcount++;

            }
            else if (ranval == 107 && button107.Visible == false)
            {

                button107.Visible = true;
                Fcount++;

            }
            else if (ranval == 108 && button108.Visible == false)
            {

                button108.Visible = true;
                Fcount++;

            }
            else if (ranval == 109 && button109.Visible == false)
            {

                button109.Visible = true;
                Fcount++;

            }
            else if (ranval == 110 && button110.Visible == false)
            {

                button110.Visible = true;
                Fcount++;

            }
            else if (ranval == 111 && button111.Visible == false)
            {

                button111.Visible = true;
                Fcount++;

            }
            else if (ranval == 112 && button112.Visible == false)
            {

                button112.Visible = true;
                Fcount++;

            }
            else if (ranval == 113 && button113.Visible == false)
            {

                button113.Visible = true;
                Fcount++;

            }
            else if (ranval == 114 && button114.Visible == false)
            {

                button114.Visible = true;
                Fcount++;

            }
            else if (ranval == 115 && button115.Visible == false)
            {

                button115.Visible = true;
                Fcount++;

            }
            else if (ranval == 116 && button116.Visible == false)
            {

                button116.Visible = true;
                Fcount++;

            }
            else if (ranval == 117 && button117.Visible == false)
            {

                button117.Visible = true;
                Fcount++;

            }
            else if (ranval == 118 && button118.Visible == false)
            {

                button118.Visible = true;
                Fcount++;

            }
            else if (ranval == 119 && button119.Visible == false)
            {

                button119.Visible = true;
                Fcount++;

            }
            else if (ranval == 120 && button120.Visible == false)
            {

                button120.Visible = true;
                Fcount++;

            }
            else if (ranval == 121 && button121.Visible == false)
            {

                button121.Visible = true;
                Fcount++;

            }

            //--------------------------------------------
            //--------------------------------------------

            if (gameStop == true)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                stopmessage();
            }
            else
            {
                timer2.Start();
                timer1.Stop();
            }

        } 


        //--------------------------------------------
        //--------------------------------------------


        private void button1_Click(object sender, EventArgs e)  // 버튼 클릭시 실행
        {
            button1.Visible = false;
            Fcount--; score++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            Fcount--; score++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            Fcount--; score++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            Fcount--; score++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            Fcount--; score++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            Fcount--; score++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Visible = false;
            Fcount--; score++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            Fcount--; score++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            Fcount--; score++;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            Fcount--; score++;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Visible = false;
            Fcount--; score++;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            Fcount--; score++;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.Visible = false;
            Fcount--; score++;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            Fcount--; score++;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.Visible = false;
            Fcount--; score++;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.Visible = false;
            Fcount--; score++;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button17.Visible = false;
            Fcount--; score++;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button18.Visible = false;
            Fcount--; score++;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button19.Visible = false;
            Fcount--; score++;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            button20.Visible = false;
            Fcount--; score++;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            Fcount--; score++;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button22.Visible = false;
            Fcount--; score++;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Visible = false;
            Fcount--; score++;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button24.Visible = false;
            Fcount--; score++;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            button25.Visible = false;
            Fcount--; score++;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            button26.Visible = false;
            Fcount--; score++;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button27.Visible = false;
            Fcount--; score++;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            button28.Visible = false;
            Fcount--; score++;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            button29.Visible = false;
            Fcount--; score++;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            button30.Visible = false;
            Fcount--; score++;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            button31.Visible = false;
            Fcount--; score++;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            button32.Visible = false;
            Fcount--; score++;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            button33.Visible = false;
            Fcount--; score++;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            button34.Visible = false;
            Fcount--; score++;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            button35.Visible = false;
            Fcount--; score++;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            button36.Visible = false;
            Fcount--; score++;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            button37.Visible = false;
            Fcount--; score++;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            button38.Visible = false;
            Fcount--; score++;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            button39.Visible = false;
            Fcount--; score++;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            button40.Visible = false;
            Fcount--; score++;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            button41.Visible = false;
            Fcount--; score++;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            button42.Visible = false;
            Fcount--; score++;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            button43.Visible = false;
            Fcount--; score++;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            button44.Visible = false;
            Fcount--; score++;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            button45.Visible = false;
            Fcount--; score++;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            button46.Visible = false;
            Fcount--; score++;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            button47.Visible = false;
            Fcount--; score++;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            button48.Visible = false;
            Fcount--; score++;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            button49.Visible = false;
            Fcount--; score++;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            button50.Visible = false;
            Fcount--; score++;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            button51.Visible = false;
            Fcount--; score++;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            button52.Visible = false;
            Fcount--; score++;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            button53.Visible = false;
            Fcount--; score++;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            button54.Visible = false;
            Fcount--; score++;
        }

        private void button55_Click(object sender, EventArgs e)
        {
            button55.Visible = false;
            Fcount--; score++;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            button56.Visible = false;
            Fcount--; score++;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            button57.Visible = false;
            Fcount--; score++;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            button58.Visible = false;
            Fcount--; score++;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            button59.Visible = false;
            Fcount--; score++;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            button60.Visible = false;
            Fcount--; score++;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            button61.Visible = false;
            Fcount--; score++;
            if(gameStop == true)
            {
                restart();
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            button62.Visible = false;
            Fcount--; score++;
        }

        private void button63_Click(object sender, EventArgs e)
        {
            button63.Visible = false;
            Fcount--; score++;
        }

        private void button64_Click(object sender, EventArgs e)
        {
            button64.Visible = false;
            Fcount--; score++;
        }

        private void button65_Click(object sender, EventArgs e)
        {
            button65.Visible = false;
            Fcount--; score++;
        }

        private void button66_Click(object sender, EventArgs e)
        {
            button66.Visible = false;
            Fcount--; score++;
        }

        private void button67_Click(object sender, EventArgs e)
        {
            button67.Visible = false;
            Fcount--; score++;
        }

        private void button68_Click(object sender, EventArgs e)
        {
            button68.Visible = false;
            Fcount--; score++;
        }

        private void button69_Click(object sender, EventArgs e)
        {
            button69.Visible = false;
            Fcount--; score++;
        }

        private void button70_Click(object sender, EventArgs e)
        {
            button70.Visible = false;
            Fcount--; score++;
        }

        private void button71_Click(object sender, EventArgs e)
        {
            button71.Visible = false;
            Fcount--; score++;
        }

        private void button72_Click(object sender, EventArgs e)
        {
            button72.Visible = false;
            Fcount--; score++;
        }

        private void button73_Click(object sender, EventArgs e)
        {
            button73.Visible = false;
            Fcount--; score++;
        }

        private void button74_Click(object sender, EventArgs e)
        {
            button74.Visible = false;
            Fcount--; score++;
        }

        private void button75_Click(object sender, EventArgs e)
        {
            button75.Visible = false;
            Fcount--; score++;
        }

        private void button76_Click(object sender, EventArgs e)
        {
            button76.Visible = false;
            Fcount--; score++;
        }

        private void button77_Click(object sender, EventArgs e)
        {
            button77.Visible = false;
            Fcount--; score++;
        }

        private void button78_Click(object sender, EventArgs e)
        {
            button78.Visible = false;
            Fcount--; score++;
        }

        private void button79_Click(object sender, EventArgs e)
        {
            button79.Visible = false;
            Fcount--; score++;
        }

        private void button80_Click(object sender, EventArgs e)
        {
            button80.Visible = false;
            Fcount--; score++;
        }

        private void button81_Click(object sender, EventArgs e)
        {
            button81.Visible = false;
            Fcount--; score++;
        }

        private void button82_Click(object sender, EventArgs e)
        {
            button82.Visible = false;
            Fcount--; score++;
        }

        private void button83_Click(object sender, EventArgs e)
        {
            button83.Visible = false;
            Fcount--; score++;
        }

        private void button84_Click(object sender, EventArgs e)
        {
            button84.Visible = false;
            Fcount--; score++;
        }

        private void button85_Click(object sender, EventArgs e)
        {
            button85.Visible = false;
            Fcount--; score++;
        }

        private void button86_Click(object sender, EventArgs e)
        {
            button86.Visible = false;
            Fcount--; score++;
        }

        private void button87_Click(object sender, EventArgs e)
        {
            button87.Visible = false;
            Fcount--; score++;
        }

        private void button88_Click(object sender, EventArgs e)
        {
            button88.Visible = false;
            Fcount--; score++;
        }

        private void button89_Click(object sender, EventArgs e)
        {
            button89.Visible = false;
            Fcount--; score++;
        }

        private void button90_Click(object sender, EventArgs e)
        {
            button90.Visible = false;
            Fcount--; score++;
        }

        private void button91_Click(object sender, EventArgs e)
        {
            button91.Visible = false;
            Fcount--; score++;
        }

        private void button92_Click(object sender, EventArgs e)
        {
            button92.Visible = false;
            Fcount--; score++;
        }

        private void button93_Click(object sender, EventArgs e)
        {
            button93.Visible = false;
            Fcount--; score++;
        }

        private void button94_Click(object sender, EventArgs e)
        {
            button94.Visible = false;
            Fcount--; score++;
        }

        private void button95_Click(object sender, EventArgs e)
        {
            button95.Visible = false;
            Fcount--; score++;
        }

        private void button96_Click(object sender, EventArgs e)
        {
            button96.Visible = false;
            Fcount--; score++;
        }

        private void button97_Click(object sender, EventArgs e)
        {
            button97.Visible = false;
            Fcount--; score++;
        }

        private void button98_Click(object sender, EventArgs e)
        {
            button98.Visible = false;
            Fcount--; score++;
        }

        private void button99_Click(object sender, EventArgs e)
        {
            button99.Visible = false;
            Fcount--; score++;
        }

        private void button100_Click(object sender, EventArgs e)
        {
            button100.Visible = false;
            Fcount--; score++;
        }

        private void button101_Click(object sender, EventArgs e)
        {
            button101.Visible = false;
            Fcount--; score++;
        }

        private void button102_Click(object sender, EventArgs e)
        {
            button102.Visible = false;
            Fcount--; score++;
        }

        private void button103_Click(object sender, EventArgs e)
        {
            button103.Visible = false;
            Fcount--; score++;
        }

        private void button104_Click(object sender, EventArgs e)
        {
            button104.Visible = false;
            Fcount--; score++;
        }

        private void button105_Click(object sender, EventArgs e)
        {
            button105.Visible = false;
            Fcount--; score++;
        }

        private void button106_Click(object sender, EventArgs e)
        {
            button106.Visible = false;
            Fcount--; score++;

        }

        private void button107_Click(object sender, EventArgs e)
        {
            button107.Visible = false;
            Fcount--; score++;

        }

        private void button108_Click(object sender, EventArgs e)
        {
            button108.Visible = false;
            Fcount--; score++;

        }

        private void button109_Click(object sender, EventArgs e)
        {
            button109.Visible = false;
            Fcount--; score++;

        }

        private void button110_Click(object sender, EventArgs e)
        {
            button110.Visible = false;
            Fcount--; score++;

        }

        private void button111_Click(object sender, EventArgs e)
        {
            button111.Visible = false;
            Fcount--; score++;
        }

        private void button112_Click(object sender, EventArgs e)
        {
            button112.Visible = false;
            Fcount--; score++;
        }

        private void button113_Click(object sender, EventArgs e)
        {
            button113.Visible = false;
            Fcount--; score++;
        }

        private void button114_Click(object sender, EventArgs e)
        {
            button114.Visible = false;
            Fcount--; score++;
        }

        private void button115_Click(object sender, EventArgs e)
        {
            button115.Visible = false;
            Fcount--; score++;
        }

        private void button116_Click(object sender, EventArgs e)
        {
            button116.Visible = false;
            Fcount--; score++;
        }

        private void button117_Click(object sender, EventArgs e)
        {
            button117.Visible = false;
            Fcount--; score++;
        }

        private void button118_Click(object sender, EventArgs e)
        {
            button118.Visible = false;
            Fcount--; score++;
        }

        private void button119_Click(object sender, EventArgs e)
        {
            button119.Visible = false;
            Fcount--; score++;
        }

        private void button120_Click(object sender, EventArgs e)
        {
            button120.Visible = false;
            Fcount--; score++;

        }

        private void button121_Click(object sender, EventArgs e)
        {
            button121.Visible = false;
            Fcount--; score++;
        }

        //---------------------------
        //---------------------------


    }
}
