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
using EasyModbus;
using System.Threading;
using System.Timers;

namespace DiskUsed
{
    //Modbus TCP Master 모드 프로그램.
    public partial class Form1 : Form
    {
        ModbusClient m_Modbus; // Modbus 동작을 위한 전역 변수 설정 

        string Drive1St = string.Empty;
        string Drive2Nd = string.Empty;
        string IpAddress = string.Empty;


        public Form1()
        {
            InitializeComponent();
            string filePath = Application.StartupPath + @"\Setup.ini";
            string[] Readini = System.IO.File.ReadAllLines(filePath);

            Drive1St = Readini[0].Trim();
            Drive2Nd = Readini[1].Trim();
            IpAddress = Readini[2].Trim();

            m_Modbus = new ModbusClient();

            System.Timers.Timer timer = new System.Timers.Timer(); // 타이머 선언
            timer.Interval = 60 * 1000; // 1 분
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed); // 타이머 동작 함수 연결
            timer.Start(); // 타이머 시작

            SendDataFunc();

            this.WindowState = FormWindowState.Minimized; // 시작시 최소화 모드로
            this.ShowInTaskbar = false; //테스크바 사용 안함.
            this.Visible = false; // 메인폼 숨김
            this.notifyIcon1.Visible = true; // 노티 아이콘 등록
            notifyIcon1.ContextMenuStrip = contextMenuStrip1; //메뉴 스트립 연결
            this.notifyIcon1.DoubleClick += notifyIcon1_DoubleClick; // 노티 아이콘 더블클릭시 동작 

        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SendDataFunc();
        }

        void SendDataFunc()
        {
            DriveInfo drv1 = new DriveInfo(Drive1St);     //체크할 디스크 선택

            long Tot1 = ((drv1.TotalSize / 1024) / 1024) / 1024;          //메가 단위 전체용량
            long Tof1 = ((drv1.AvailableFreeSpace / 1024) / 1024) / 1024; // 메가 단위 사용 가능 용량

            DriveInfo drv2 = new DriveInfo(Drive2Nd);     //체크할 디스크 선택

            long Tot2 = ((drv2.TotalSize / 1024) / 1024) / 1024;       //메가 단위 전체용량
            long Tof2 = ((drv2.AvailableFreeSpace / 1024) / 1024) / 1024; // 메가 단위 사용 가능 용량

            try
            {
                m_Modbus.Connect(IpAddress, 502); //접속할 아이피, 포트
            }
            catch (Exception) { } // 문제 상황시 처리할 구문... empty....


            if (m_Modbus.Connected == false) //모드버스 미연결시 재 연결
            {
                try
                {
                    m_Modbus.Connect(IpAddress, 502);
                }
                catch (Exception) { }
            }
            else
            {
                CreateBitSend(Tot1, 24600);
                CreateBitSend(Tof1, 24601);

                CreateBitSend(Tot2, 24602);
                CreateBitSend(Tof2, 24603);
            }
        }
        void CreateBitSend(long Data, int UAddress)
        {
            m_Modbus.WriteSingleRegister(UAddress, (int)Data); 
        }

        //void CreateBitSend(long Data, int UAddress)
        //{
        //    string Data32BitConv = Convert.ToString(Data, 2).PadLeft(32, '0'); // 데이터 비트화
        //    string HighBit = Data32BitConv.Substring(0, 16); //상위 비트
        //    string LowBit = Data32BitConv.Substring(16, 16); // 하위비트

        //    m_Modbus.WriteSingleRegister(UAddress, Convert.ToInt16(HighBit, 2));
        //    m_Modbus.WriteSingleRegister(UAddress + 1, Convert.ToInt16(LowBit, 2));
        //}

        private void Button1_Click(object sender, EventArgs e)
        {
            DriveInfo drv = new DriveInfo("C"); //체크할 디스크 선택

            long Tot1 = ((drv.TotalSize / 1024) / 1024) / 1024;          //메가 단위 전체용량
            long Tof1 = ((drv.AvailableFreeSpace / 1024) / 1024) / 1024; // 메가 단위 사용 가능 용량


            textBox1.Text = Tot1.ToString();
            textBox2.Text = Tof1.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button1_Click(sender, e);

            this.WindowState = FormWindowState.Normal;
            var WindowSize_W = (int)SystemInformation.PrimaryMonitorMaximizedWindowSize.Width / 2;
            var WindowSize_H = (int)SystemInformation.PrimaryMonitorMaximizedWindowSize.Height / 2;

            this.Location = new System.Drawing.Point(WindowSize_W - this.Size.Width / 2, WindowSize_H - this.Size.Height / 2);

            this.Visible = true;
            this.TopMost = true;
        }

        bool ExitRun = false;
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitRun = true;

            this.Close();
        }
        void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Button1_Click(sender, e);

            this.WindowState = FormWindowState.Normal;
            var WindowSize_W = (int)SystemInformation.PrimaryMonitorMaximizedWindowSize.Width / 2;
            var WindowSize_H = (int)SystemInformation.PrimaryMonitorMaximizedWindowSize.Height / 2;

            this.Location = new System.Drawing.Point(WindowSize_W - this.Size.Width / 2, WindowSize_H - this.Size.Height / 2);

            this.Visible = true;
            this.TopMost = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitRun == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                this.TopMost = false;
            }
        }
    }
}
