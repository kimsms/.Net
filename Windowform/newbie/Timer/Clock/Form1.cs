using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net;
using System.IO;

namespace Clock
{
    public partial class Form1 : Form
    {
        // 타이머 변수
        public int skip1min;
        int TimerH;
        int TImerM;
        int TImerS;
        int TimerHBU;
        int TImerMBU;
        int TimerSBU;
        bool TImerONOFF = false;
        // 타이머 변수/

        
        public Form1()
        {
            InitializeComponent();
            
        }

        // 타이머 함수
        private void TimerStartStopButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TimerHH.Text == "0" && TimerMM.Text == "0" && TimerSS.Text == "0") || (TimerHH.Text == "" && TimerMM.Text == "" && TimerSS.Text == ""))
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("올바른 숫자를 입력하세요");

                }
                else
                {

                    if (TImerONOFF == false)
                    {
                        TimerH = int.Parse(TimerHH.Text);
                        TImerM = int.Parse(TimerMM.Text);
                        TImerS = int.Parse(TimerSS.Text);
                        TimerStartStopButton.Text = "정지";
                        TImerONOFF = true;
                        TimerHBU = int.Parse(TimerHH.Text);
                        TImerMBU = int.Parse(TimerMM.Text);
                        TimerSBU = int.Parse(TimerSS.Text);
                        TimerTimer.Start();
                    }
                    else if (TImerONOFF == true)
                    {
                        TimerH = int.Parse(TimerHH.Text);
                        TImerM = int.Parse(TimerMM.Text);
                        TImerS = int.Parse(TimerSS.Text);
                        TimerStartStopButton.Text = "시작";
                        TImerONOFF = false;
                        TimerTimer.Stop();
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("타이머 작동오류");
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show(ex.ToString());
            }


        }
        private void TimerResetButton_Click(object sender, EventArgs e)
        {
            TimerH = TimerHBU;
            TImerM = TImerMBU;
            TImerS = TimerSBU;
            TimerHH.Text = TimerH.ToString();
            TimerMM.Text = TImerM.ToString();
            TimerSS.Text = TImerS.ToString();
            skip1min = 0;
            TimerTimer.Interval = 1;
        }

        private void TimerTimer_Tick(object sender, EventArgs e)
        {
            if (skip1min == 1)
            {
                TimerTimer.Interval = 1000;
            }
            try
            {
                TimerHH.Text = TimerH.ToString();
                TimerMM.Text = TImerM.ToString();
                TimerSS.Text = TImerS.ToString();

                if (TimerH >= 1 && TImerM == 0 && TImerS == 0)
                {
                    TimerH--;
                    TImerM = 59;
                    TImerS = 59;
                }
                else if (TImerM >= 1 && TImerS == 0)
                {
                    TImerM--;
                    TImerS = 59;

                }
                else if (TImerS > 0)
                {
                    TImerS--;
                }
                else
                {
                    TimerTimer.Stop();
                    MessageBox.Show("시간이 종료되었습니다");
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show(ex.ToString());
            }
            skip1min++;

        }

        // 타이머 함수/

        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

        // 스톱워치 변수
        int SWh;
        int SWm;
        int SWs;
        int SWms;
        int i;
        // 스톱워치 변수/

        // 스톱워치 함수
        private void SWstartbutton_Click(object sender, EventArgs e)
        {
            if(SWstartbutton.Text == "시작")
            {
                SWtimer.Start();
                SWstartbutton.Text = "정지";
            }
            else
            {
                SWtimer.Stop();
                SWstartbutton.Text = "시작";
            }

        }

        private void SWtimer_Tick(object sender, EventArgs e)
        {
            SWMMSS.Text = SWms.ToString();
            SWSS.Text = SWs.ToString();
            SWMM.Text = SWm.ToString();
            SWHH.Text = SWh.ToString();
            if(i == 1)
                {
                    SWtimer.Interval = 1000;
                }


            SWs++;
            if(SWms == 70)
            {
                SWms = 0;
                SWs++;
            }
            if (SWs == 60)
            {
                SWs = 0;
                SWm++;
            }
            if(SWm == 60)
            {
                SWm = 0;
                SWs++;
            }
            i++;
        }

        private void SWresetButton_Click(object sender, EventArgs e)
        {
            SWtimer.Stop();
            SWstartbutton.Text = "시작";
            SWMMSS.Text = "0";
            SWSS.Text = "0";
            SWMM.Text = "0";
            SWHH.Text = "0";
            SWh = 0;
            SWm = 0;
            SWs = 0;
            SWms = 0;
            i = 0;

        }

        // 스톱워치 함수/

        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

        // 알람 변수
        bool Ojun;
        String ziparm;
        // 알람 변수/

        // 알람 함수
        private void armStartbutton_Click(object sender, EventArgs e)
        {
            if(Ojun == false)
            {
                if (armHH.TextLength == 1)
                {
                    ziparm = 0 + armHH.Text + "-" + 0 + armMM.Text;
                }
                else if (armMM.TextLength == 1)
                {
                    ziparm = armHH.Text + "-" + 0 + armMM.Text;
                }
                else if (armHH.TextLength == 1 && armMM.TextLength == 1)
                {
                    ziparm = 0 + armHH.Text + "-" + 0 + armMM.Text;
                }
                else
                {
                    ziparm = armHH.Text + "-" + armMM.Text;
                }
            }
            else if(Ojun == true)
            {
                
                if (armMM.TextLength == 1)
                {
                    ziparm = (int.Parse(armHH.Text) + 12) + "-"+0 + armMM.Text;
                }
                else
                {
                    ziparm = (int.Parse(armHH.Text) + 12) + "-" + armMM.Text;
                }
                    
            }
            if(armStartbutton.Text == "시작")
            {
                armStartbutton.Text = "종료";
                armTimer.Start();
                MessageBox.Show("알람이 예약되었습니다");
            }
            else
            {
                armStartbutton.Text = "시작";
                armTimer.Stop();
                MessageBox.Show("알람이 취소되었습니다");
            }
            
            
        }

        private void armTimer_Tick(object sender, EventArgs e)
        {
            if(DateTime.Now.ToString("HH-mm") == ziparm)
            {
                armTimer.Stop();
                MessageBox.Show("알람이 울리고 있습니다");
            }

        }

        private void OjunorOhu_Click(object sender, EventArgs e)
        {
            if(OjunorOhu.Text == "오전")
            {
                Ojun = true;
                OjunorOhu.Text = "오후";
            }
            else
            {
                Ojun = false;
                OjunorOhu.Text = "오전";
            }
        }


        // 알람 함수/

        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

        // 세계시간 변수

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = WebImageView(textBox1.Text);
                WebImageView(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Bitmap WebImageView(string URL)

        {

            try

            {

                WebClient Downloader = new WebClient();

                Stream ImageStream = Downloader.OpenRead(URL);

                Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;

                return DownloadImage;

            }

            catch (Exception)

            {

                return null;

            }

        }
    }
}
