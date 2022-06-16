//-------------------------------------------------------------------------------
//-------------------------------------------------------------------------------
// 2019.04.15, BM CHOI
//-------------------------------------------------------------------------------
//-------------------------------------------------------------------------------
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
//-------------------------------------
// 멀티미디어 타이머
// Multimedia.dll
using Multimedia; 

//-------------------------------------
// 시리얼 포트
using System.IO.Ports;
//-------------------------------------
//using System.Diagnostics;

using System.Threading;

namespace SerialTest
{
    public partial class Form1 : Form
    {
        static readonly byte NEW_LINE = 1;
        //--------------------------------------------
        public string g_csRecevData = "";
        public int g_iRecevDataSize = 0;
        public bool g_bRecevChk = false;
        public int g_iDisplayCnt = 0;
        public bool g_bSerialOpenChk = false;
        public int g_iTestCnt = 0;

        public bool g_bRecevStart = false;
        public bool g_bRecevStop = false;

        public int g_iRecevErrorCnt = 0;
        public bool g_bAutoRun = false;

        public int g_iAdcMax = 0;
        public int g_iAdcMax2 = 0;

        public bool g_bSend = false;

        public int g_iSetPulse = 1000;
        public int g_iSetRpm = 15;

        //--------------------------------------------

        static readonly int AZ_RIGHT_LIMIT = 2800; //MAX: 150도(2677) 이상 
        static readonly int AZ_LEFT_LIMIT = 3600; //MAX:-150도(3733) 이상 
        static readonly int EL_UP_LIMIT = 894;  //구동범위(889,50도), +5mil, 18.08.18	
        static readonly int EL_DN_LIMIT = 5506;//구동범위(5511,-50도) +5mil, 18.08.18

        static readonly byte OFF = 0;
        static readonly byte ON = 1;
        static readonly byte OK = 2;
        static readonly byte NG = 3;

        // ICD Msg ID Define[Host --> PanTilt]
        static readonly byte ICD_MsgID_CMD = 0x71;//0x61;
        static readonly byte ICD_MsgID_JOY_DATA = 0x72;//0x62;
        static readonly byte ICD_MsgID_POS_DATA = 0x73;//0x63;
        static readonly byte ICD_MsgID_SCAN_DATA = 0x64;

        static readonly byte ICD_MsgID_BIT = 0x76; //BIT ERROR 요구
        static readonly byte ICD_MsgID_TEST_MODE =0xff;

        //static readonly byte ICD_MsgID_TEST_MODE = 0x6F;		//Function Test(정비장비 포함)
        //static readonly byte ICD_MsgID_RCV_ERROR = 0xFF;        //수신 바이트 에러 전송.

        static readonly byte ICD_MsgID_SEARCH_MODE = 0x78;

        //-----------------------------------------------------------------
        static readonly byte ICD_MsgID_PERIOD_RESPONSE_ACK = 0x76;
        static readonly byte ICD_MsgID_TEST_RESPONSE_ACK = 0x81;

        static readonly byte ICD_MsgID_PBIT_ACK = 0x77;
        static readonly byte ICD_MsgID_IBIT_ACK = 0x78;

        static readonly byte ICD_MAINT_AZ_ORG_SET = 0x80;
        static readonly byte ICD_MAINT_EL_ORG_SET = 0x81;
        //-----------------------------------------------------------------

        //MODE  DATA1
        static readonly byte ICD_MODE_JOY = 0x01;
        static readonly byte ICD_MODE_POS = 0x02;
        static readonly byte ICD_MODE_SCAN = 0x04;
        static readonly byte ICD_MODE_STOP = 0x0B;

        static readonly byte ICD_MODE_AZ_DRIVE_OFF = 0x06;
        static readonly byte ICD_MODE_EL_DRIVE_OFF = 0x08;

        static readonly byte ICD_MODE_REQUEST = 0x09;

        //static readonly byte ICD_MODE_EMG_STOP = 0x10;
        //static readonly byte ICD_MODE_COMMD_RESET = 0x20;

        // ICD Define
        static readonly byte ICD_STX = 0x7e;     // tx start
        static readonly byte ICD_SrID = 0x17;//0x26;    // source id
        static readonly byte ICD_ETX = 0x7f;     // tx end
        static readonly byte ICD_ID_HOST = 0x27;//0x36; //My -- >  Host
        static readonly byte ICD_DATA_MAX = 255; //256 // data max length
        static readonly byte ICD_SEND_DATA_MAX = 8;
        
        // ICD Feild Length
        static readonly byte LENGTH_CMD = 4;
        static readonly byte LENGTH_JOY = 6;
        static readonly byte LENGTH_POS = 11; //10+1 Sr/De 부터 데이터 끝까지

        static readonly byte LENGTH_BIT_REQ = 3;
        //static readonly byte LENGTH_PBIT_REQ = 4;
        static readonly byte LENGTH_PBIT_ACK = 7;  //0x65, 4Hz 데이터 상시 출력
        static readonly byte LENGTH_RESPONSE = 11; //0x66, 디버강용 데이터(자체 수락시험용)
        static readonly byte LENGTH_TEST_MODE_REQ = 4;
        static readonly byte LENGTH_TEST_MODE_ACK = 3;
        static readonly byte LENGTH_RCV_ERROR_ACK = 3;

        static readonly byte ICD_DIR_RIGHT = 0x7F;
        static readonly byte ICD_DIR_LEFT =  0x80;

        static readonly byte ICD_DIR_UP = 0x7F;
        static readonly byte ICD_DIR_DN = 0x80;
       

        public byte g_TestCnt = 0;

        byte[] g_byteData = new byte[ICD_DATA_MAX];
        byte[] gSendMultiPos = new byte[ICD_DATA_MAX];

        public byte g_RecevCnt = 0;
        public int g_RunTestCnt = 0;
        public int g_RecevChk = 1;
        //----------------------------------
        public string g_csSaveData = "";
        public int g_iSaveNo = 0;
        public int g_iSaveStepNo = 0;
        public string g_csOldTime = "";

        public int g_iSaveSubStep= 0;
        public int g_iSaveTime1 = 0;
        public int g_iSaveTime2 = 0;

        public int g_iRpmChgVal = 0;
        public int g_iSendSec = 0;
        public int g_iSendmSec = 0;
        //----------------------------------
        public int g_iAutoMode = 0;

        public int g_iAutoStep = 0;

        public int g_iRpmStep = 120;
        public int g_iRpmStep2 = 10;
        public int g_DirMode = 0;
        public int g_DirMode2 = 0;

        public int g_iTestStepCnt = 0;

        //----------------------------------
        double[] ecg = new double[100000];
        double[] ppg = new double[100000];
        int gChartDisCnt1 = 0;
        int gChartDisCnt2 = 0;

        float gAzAddMovePos = 0;
        float gElAddMovePos = 0;

        bool gTxDataDisChk = false;
        int  gTimerCnt = 0;
        int  gTimerOld = 0;
        int  gTimerCnt25Hz = 0;
        int  gTimerDelay1ms = 0;

        byte gSendBusyFlg = 0;

        bool gTxSendEnd = false;
        int  gAutoSendTime = 0;
        bool gTxSendStart = false;

        bool gAutoDecreasePosChk = false;
        bool gAutoStepIncreasePosChk = true;
        bool gAutoSinePosChk = false;
        bool gAutoSeekPosModeChk = false;
        bool gAutoRepeatMoveMode = false;

        bool gGrapDisChk = true;
        bool gListDisChk = true;

        byte gTxSendSeekDataNo = 0;

        int gAzSeekSineDatCnt = 0;
        int gElSeekSineDatCnt = 0;

        int gAutoMoveCnt = 0;
        bool gAutoMoveChk = false;

        string[] g_BitMessage = new string[16];

        //#region param
      
        public int Xaxis; // X-axis movement
        public int Yaxis; //Y-axis movement
        private IntPtr hWnd;
        public bool[] buttons;
        //#endregion

        float gAzPresentPos = 0;
        float gElPresentPos = 0;

        int gAzAutoRepeatMoveCnt = 0;
        int gElAutoRepeatMoveCnt = 0;

        public bool gAccelMove = false;
        public bool gDecelMove = false;

        public int gGrapeSaveCnt = 0;

        public float g_AzAddSetp = 0;
        public float g_AzAddSetpVal = 0;

        public float g_ElAddSetp = 0;
        public float g_ElAddSetpVal = 0;

        //-----------------------------------
        public float gSendDataRatio = 1.0f;   //10.f 64000,  1.0f 6400
        //-----------------------------------

        public bool gAutoTestMode = false;
        public Form1()
        {
            InitializeComponent();
            
            try
            {
                //string csFile = @"d:\Tester\SetupData\SerialPort.txt";

                string csFile = @"SetupData\SerialPort.txt";
                SerialPortFileOpen(csFile);
                ///SerialPortOpen();
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer4.Enabled = true;

                //g_csSaveData = "";11
                g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                              "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                              "AZ GAP" + "," + "EL GAP";
                //g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                //              "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                //              "AZ GAP" + "," + "EL GAP" + "," + "AZ SPEED" + "," + "EL SPEED" + "," + "AZ RPM";

                g_csSaveData += "\r\n";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            //---------------------------------------------
            TimerCaps caps = Multimedia.Timer.Capabilities;
            SerialPortOpen();
            GrapeInit();
            //---------------------------------------------

            //TxDataDisChkBox.Checked = true;
            ChkBox_AutoStepIncreasePos.Checked = true;
            ChkBox_AutoSeekPos.Checked = true;
            GrapDisChkBox.Checked = true;
            ListDisChkBox.Checked = true;

            gAutoStepIncreasePosChk = true;
            gAutoSeekPosModeChk = true;
       
            g_BitMessage[0] = "0x01 : EL Increment Encoder Fault";
            g_BitMessage[1] = "0x02 : AZ Increment Encoder Fault";
            g_BitMessage[2] = "0x04 : EL Over Current Fault";
            g_BitMessage[3] = "0x08 : AZ Over Current Fault";

            g_BitMessage[4] = "0x10 : Power Over Voltage Fault(Vdc > 36[V]), 자/수 공통";
            g_BitMessage[5] = "0x20 : Power Low Voltage Fault(Vdc > 18[V]), 자/수 공통";
            g_BitMessage[6] = "0x40 : EL Over Temperature Fault(Temp > 100[℃])";
            g_BitMessage[7] = "0x80 : AZ Over Temperature Fault(Temp > 100[℃])";

            g_BitMessage[8] = "0x01 : EL Hall Sensor Fault";
            g_BitMessage[9] = "0x02 : AZ Hall Sensor Fault";
            g_BitMessage[10] = "0x04 : EL Over Speed Fault";
            g_BitMessage[11] = "0x08 : AZ Over Speed Fault";

            g_BitMessage[12] = "0x10 : EL Board Fault";
            g_BitMessage[13] = "0x20 : AZ Board Fault";
            g_BitMessage[14] = "0x40 : EL Absolute Encoder Fault, 자/수 공통";
            g_BitMessage[15] = "0x80 : AZ Absolute Encoder Fault, 자/수 공통";
            //--------------------------------------------------------------
            //Key Board 입력
            //this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(Jotstick_KeyDown);
            //this.KeyUp += new KeyEventHandler(Jotstick_KeyUp);
            //X-사용 않함 : this.KeyPress += new KeyPressEventHandler(Keytest_KeyPress);
            //--------------------------------------------------------------

            //joystick = new Joystick(this.Handle);
            //connectToJoystick(joystick);

            //JoystickInit();
        }

        //--------------------------------------------------------
        //--------------------------------------------------------
        void TimeDelay(int msec)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(msec);
                return 42;
            });
            t.Wait();
        }
             

        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate ()
                {
                  
                }));
            }
         
        }
        //--------------------------------------------------------------
        public async void GrapeInit()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            //chartB.Series[0].ChartType = SeriesChartType.Pie;
            //chart1.Series[0].ChartType = SeriesChartType.Line;
            //chartB.Series[0].ChartType = SeriesChartType.Bar;
            //chart1.Series[0].ChartType = SeriesChartType.SplineArea;
            //timer4.Stop();
            //timer4.Start();
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[1].Color = Color.Blue;

            chart1.Series[0].Points.AddXY(0, 1);
            chart1.Series[1].Points.AddXY(0, 2);
            //------------------------------------

            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            //chartB.Series[0].ChartType = SeriesChartType.Pie;
            //chart1.Series[0].ChartType = SeriesChartType.Line;
            //chartB.Series[0].ChartType = SeriesChartType.Bar;
            //chart1.Series[0].ChartType = SeriesChartType.SplineArea;
            //timer4.Stop();
            //timer4.Start();
            chart2.Series[0].BorderWidth = 2;
            chart2.Series[0].Color = Color.Red;
            chart2.Series[1].BorderWidth = 2;
            chart2.Series[1].Color = Color.Blue;
            chart2.Series[2].BorderWidth = 2;
            chart2.Series[2].Color = Color.Green;

            chart2.Series[0].Points.AddXY(0, 1);
            chart2.Series[1].Points.AddXY(0, 2);
            chart2.Series[2].Points.AddXY(0, 3);
        }
        //=======================================================================================
        //=======================================================================================
        public async void LogDis(String cs, int rt)
        {
            //디버깅 모드에서는 에러, 작업 표시줄에 표시후 실행!!
            //if (LogDisList.Lines.Length > 30)
            //if (LogDisList.Lines.Length > 20)
            //   LogDisList.Clear();


            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    if (LogDisList.Lines.Length > 25) //
                    {
                        LogDisList.Clear();
                    }

                    LogDisList.Text += cs;
                    if (rt == ON)
                        LogDisList.Text += "\r\n";
                }));
            }

            //if (LogDisList.Lines.Length > 30)

            
        }

        //=======================================================================================
        //=======================================================================================
        private void btnSerialOpen_Click(object sender, EventArgs e)
        {
            string file = @"D:\Tester\SetupData\SerialPort.txt";
            SerialPortFileSave(file);
            SerialPortOpen();
            if (g_bSerialOpenChk)
                System.Windows.Forms.MessageBox.Show("Serial Port를 정상 Open 하였습니다!");
            else
                System.Windows.Forms.MessageBox.Show("Error!! Serial Port를 Open 하지 못했습니다!");
        }
        //--------------------------------------------------------------
        private void SerialPortOpen()
        {
            //Port name can be identified by checking the ports
            // section in Device Manager after connecting your device
            if (serialPort1.IsOpen) serialPort1.Close();

            string csPort = txtSerialPortName.Text;
            int bps = Convert.ToInt32(txtSerialPortBps.Text);
            serialPort1.PortName = csPort;  //"COM3"
            //Provide the name of port to which device is connected

            //default values of hardware[check with device specification document]
            serialPort1.BaudRate =  bps;  // 9600
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;

            try
            {
                serialPort1.Open(); //opens the port
                serialPort1.ReadTimeout = 200;
                if (serialPort1.IsOpen)//정상 Open true
                {
                    //DispString = "";
                    //System.Windows.Forms.MessageBox.Show("COM3을 Open 하였습니다!");
                    //IconDisplay(OK);
                    g_bSerialOpenChk = true;
                }
            }
            catch
            {
                //IconDisplay(NG);
                g_bSerialOpenChk = false;
            }
            if(g_bSerialOpenChk)
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
            /*
            SerialPort mySerialPort = new SerialPort("COM3");
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.Open();
            mySerialPort.Close();
            */
        }
        //--------------------------------------------------------------
        public void SerialPortFileOpen(string file)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(file);
                int max = 0;
                max = lines.GetLength(0);
                //txtIpFilePath.Text = file;
                //------------------------------
                //if (max > 0 && max < LAYER_MAX) m_DrawMax = max;
                //------------------------------
                for (int i = 0; i < max; i++)//LAYER_MAX
                {
                    string[] ps;
                    ps = lines[i].Split(',');
                    //txtUnitSpaceIpDis = ps[0];
                    txtSerialPortName.Text = ps[0];
                    txtSerialPortBps.Text = ps[1];
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("", file + " : 위치 정보 파일을 찾지 못하겠습니다.!");
            }
        }
        //--------------------------------------------------------------
        public void SerialPortFileSave(string file)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(file);
                int max = 0;
                max = lines.GetLength(0);

                string uspaceName = "";
                string[] csIp = new string[2];

                //------------------------------
                //if (max > 0 && max < LAYER_MAX) m_DrawMax = max;
                //------------------------------
                string cs = "";// string.Empty;
                for (int i = 0; i < max; i++)//LAYER_MAX
                {
                    //uspaceName = listUnitSpace.Items[i].ToString();

                    string[] ps;
                    ps = lines[i].Split(',');
                    csIp[0] = txtSerialPortName.Text;
                    csIp[1] = txtSerialPortBps.Text;

                    cs += string.Format("{0},{1}", csIp[0], csIp[1]) + "\r\n";
                }
                System.IO.File.WriteAllText(file, cs);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("", file + "파일을 저장하지 못하겠습니다.!");
            }
        }
        //=======================================================================================
        //=======================================================================================
        //public static Byte[] ByteToBitGet(byte[] by, int StartBit, int BitSize)
        public static Byte ByteToBitGet(byte[] by, int StartBit, int BitSize)
        {
            byte[] data = new byte[1];
            int r = 0;
            int buf = 0;
            int cnt = 0;

            for (int i = 0; i < 8; i++)
            {
                Boolean bit = false;
                if (i >= StartBit)
                {
                    if (i == 0) bit = (by[0] & 1) != 0;
                    else bit = (by[0] >> i & 1) != 0;

                    //Boolean bit = (by[0] << i & 0x80) != 0;
                    if (cnt < BitSize)
                    {
                        //상하위 비트가 뒤바뀜
                        buf = buf << 1;
                        if (bit)
                        {
                            buf |= 1;
                            // LogDis("[1],", Flg.OFF);
                        }
                        else
                        {
                            // LogDis("[0],", Flg.OFF);
                        }
                    }
                    else break;
                    cnt++;
                }
            }
            by[0] = (Byte)buf;
            //LogDis(by[0].ToString(), Flg.ON);

            //위에서 뒤집힌 Bit 뒤집기
            for (int i = 0; i < BitSize; i++)
            {
                r = r << 1;
                Boolean bit = (by[0] >> i & 1) != 0;
                if (bit) r |= 1;
            }
            // LogDis(by[0].ToString(), Flg.ON);
            data[0] = (byte)r;
            return data[0];
        }
        //--------------------------------------------------------------
        private string HextoAsc(byte ascnum)
        {
           // string hex = "123456789ABCDEF";
            var hex = new List<string> { "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F" };
            string data = "";

            if (ascnum < 16)
            { data = hex[ascnum]; }
            return data;
        }
        //--------------------------------------------------------------
        private byte AsctoHex2(byte ascnum)
        {
            byte[] hex = new byte[16] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70 };
            byte i = 0;

            do
            {
                if (hex[i] == ascnum)
                {
                    return i;
                }
                i++;
            } while (i < 16);
            return 0;
        }

        //=======================================================================================
        //=======================================================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeDis.Text = DateTime.Now.ToString();
            if (g_bAutoRun)
            {
                ///if (g_bSend != true)
                {
                    /// AdcDataRead();
                    //RpmAutoChg();
                    //AutoPosRun();
                    //AzGoStep();
                    g_iTestStepCnt++;

                    if (g_iTestStepCnt == 1)
                    {         
                    }

                    if (g_iTestStepCnt >= 2)
                    {
                        g_iTestStepCnt = 0;
                    }
                }
            }
        }
        //--------------------------------------------------------------
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Error          
            if (g_bSend)
            {
                g_iRecevErrorCnt++;
                if (g_iRecevErrorCnt >=2)
                {
                    g_iRecevErrorCnt = 0;
                    g_bRecevStart = false;
                    g_bRecevStop = false;
                   // g_csRecevData = "";
                    g_bSend = false;
                }
            }
        }
        //--------------------------------------------------------------
        private void mmTimer_Tick(object sender, System.EventArgs e)
        {
            // http://www.codeproject.com/KB/miscctrl/lescsmultimediatimer.aspx
            //------------------------------------------------
            gTimerCnt++; if (gTimerCnt > 65535) gTimerCnt = 0;
            //------------------------------------------------

            ///lblTimerVal.Text = gTimerCnt.ToString();
            ///
            //int cnt = gTimerCnt- gTimerOld;
            //lblTimerDis.Text = cnt.ToString();

            if (gSloopChkAcecel)
            {
                gTimerCnt25Hz++;
                if (gTimerCnt25Hz >= gAutoSendTime - 1) //40: 40ms, 25Hz gTimerDelay1ms 2번에 한번 전송
                {
                    GrapeSlopeTest();
                    gTimerCnt25Hz = 0;
                }
                return;
            }

            if (gTxSendStart)
            {

                //----------------------------------
                //1ms 동안 설정된 Step(증가수mil)으로 증가 
                g_AzAddSetpVal += g_AzAddSetp;
                g_ElAddSetpVal += g_ElAddSetp;
                //----------------------------------

                if (gAutoTestMode)
                {
                    TestDataMake();
                    ElVelCmdSlope();
                }

                //-----------------------------------------
                //설정 시간에 한번 씩 데이터 전송 
                gTimerCnt25Hz++;
                if (gTimerCnt25Hz >= gAutoSendTime-1) //40: 40ms, 25Hz gTimerDelay1ms 2번에 한번 전송
                {

                    if (gAutoTestMode)
                    {                     
                        ElVelLoop();
                        GrapeDis();
                        gTimerCnt25Hz = 0;
                    }
                    else
                    {
                       
                            if (gAutoSinePosChk)
                                SeekSinePosMoveSend();
                            else
                            {
                                SeekPosAutoTimeMove();
                                g_AzAddSetpVal = 0;
                                g_ElAddSetpVal = 0;
                            }
                       
                        //if (gTxSendEnd)
                        {
                            gTimerCnt25Hz = 0;
                            gTxSendEnd = false;
                        }
                    }
                }
            }

            /*
            if(gSendBusyFlg==0)
            {
                gTimerCnt25Hz++;
                if(gTimerCnt25Hz>=10) //40: 40ms, 25Hz gTimerDelay1ms 2번에 한번 전송
                {
                    gTimerCnt25Hz = 0;
                    PosIncreaseMove2();
                }
            }
            */
        }
        //--------------------------------------------------------------
        public void SerialTextSend()
        {
            //string cs = txtElSpeed.Text;
            //serialPort1.Write(cs);
        }
        //=======================================================================================
        //
        //   serialPort1_DataReceived
        //    
        //=======================================================================================     
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {          
            int i = 0;
            string csBuf = "";
            bool bReadChk = false;

            float dsValue1 = 0;
            float dsValue2 = 0;

            float azErrorPos = 0;
            float elErrorPos = 0;
            float AxisSpeed = 0;
            float SloopSpeed = 0;
            float TestSpeed = 0;

            float DisplayData1 = 0;
            float DisplayData2 = 0;
            float DisplayData3 = 0;
            float DisplayData4 = 0;
            float DisplayData5 = 0;

            float Value1 = 0;
            int cnt = 0;
            string csData1 = "";
            string csData2 = "";
            string csData3 = "";
            string csData4 = "";
            string csData5 = "";
            string csData6 = "";
            string csData7 = "";
            string csData8 = "";
            string csData9 = "";
            string csData10 = "";
            string csData11 = "";

            string csDis = "";

            byte[] byteBuf = new byte[1];
            try
            {
                int nLength = 0;
                //g_iRecevErrorCnt++;
                SerialPort sp = (SerialPort)sender;
                nLength = sp.BytesToRead;
                if (nLength > 0)
                {
                       byte[] btTemp = new byte[nLength];
                       sp.Read(btTemp, 0, nLength);
                       //------------------------------------------
                       //IconDisplay(OFF);
                       g_bRecevChk = false;
                       //------------------------------------------
                      if (nLength > 0)
                      {
                        string cs = Encoding.UTF8.GetString(btTemp, 0, btTemp.Length);
                        ///g_csRecevData += cs;
                        //LogDis(dis, NEW_LINE);

                        for (i = 0; i < nLength; i++)
                        {
                            csBuf  += btTemp[i].ToString() + " : ";

                            if (g_RecevCnt < ICD_DATA_MAX)
                            {
                                g_byteData[g_RecevCnt++] = btTemp[i];
                            }
                        }



                        //-----------------------
                        //-----------------------
                        //LogDis(csBuf, NEW_LINE);
                        LogDis(cs, NEW_LINE);
                        //-----------------------
                        //-----------------------


                        for (i = 0; i < nLength; i++)
                        {
                            if (btTemp[i] == ICD_STX) {g_bRecevStart = true;}
                            if (btTemp[i] == ICD_ETX) {g_bRecevStop = true;}
                        }

                        //LogDis(":" + nLength.ToString() + ":", NEW_LINE);
                        //if (g_bRecevStart == true && g_bRecevStop == true)
                        if (g_bRecevStop == true)
                        {
                            ///LogDis("READ: " + g_csRecevData, NEW_LINE);
                            g_bRecevStart = false;
                            g_bRecevStop = false;
                            //g_csRecevData = "";
                            bReadChk = true;
                        }
                    }
















                    if(bReadChk)
                    {
                        int Length = g_csRecevData.Length;
                        string csHex = "";
                        string csData = g_csRecevData;
                        int GrapeSize = 0;

                        string time = "'"+DateTime.Now.Minute.ToString() + ":"+ DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + ",   "; ;

                        //=================================================================================================================
                        if(g_byteData[3]== ICD_MsgID_PERIOD_RESPONSE_ACK || g_byteData[3] == ICD_MsgID_TEST_RESPONSE_ACK) //주기적 ACK 메세지
                        {
                            //time = DateTime.Now.Second.ToString() + "초:" + DateTime.Now.Millisecond.ToString();
                            //csHex += DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + ",";
                            csHex += time;

                            dsValue1 += g_byteData[4] << 8;
                            dsValue1 += g_byteData[5];

                            //byte[] buf = new byte[2];
                            //buf[0] = g_byteData[4];
                            //buf[1] = g_byteData[5];
                            //uint buf2 = 0;
                            //buf2 = System.BitConverter.ToUInt16(buf, 0);

                            //int buf3 = System.BitConverter.ToInt16(BitConverter.GetBytes(buf2), 0);
                            //dsValue1 = (float)buf3;

                            //------------------------
                            //------------------------
                            ///만단위 소수점 표현
                            dsValue1 = dsValue1 * 0.1f;
                            if (dsValue1 > 6399.9) dsValue1 = 0.0f;
                            csDis = String.Format("{0:F1}", dsValue1);

                            gAzPresentPos = dsValue1;
                            //천단위 정수값 표현
                            //csDis = String.Format("{0}", dsValue1);
                            //------------------------
                            //------------------------
                            //csHex += Value1.ToString() + ",  ";
                            //----------------------------------
                            //방위각 위치값
                            lblAzimuth.Text = csDis + " ";// dsValue1.ToString();
                            //----------------------------------
                            
                            //----------------------------------
                            dsValue2 = 0;
                            dsValue2 += g_byteData[6] << 8;
                            dsValue2 += g_byteData[7];
                            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            
                            // -값 디스플레이
                            //0xff00 : 65,280
                            //g_byteData[6] = 255;
                            //g_byteData[7] = 0;
                            //buf[0] = g_byteData[7];
                            //buf[1] = g_byteData[6];
                            //buf2 = 0;
                            //buf2 = System.BitConverter.ToUInt16(buf, 0);

                            //buf3 = System.BitConverter.ToInt16(BitConverter.GetBytes(buf2), 0);
                            //dsValue2 = (float)buf3;
                            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            //-------------------------------------
                            //만단위, 소수점
                            dsValue2 = dsValue2 * 0.1f;
                            if (dsValue2 > 6399.9) dsValue2 = 0.0f;
                            //-------------------------------------
                            //csHex += Value2.ToString() + ",  ";
                            //만단위, 소수점 표시
                            csDis = String.Format("{0:F1}", dsValue2);
                            gElPresentPos = dsValue2;
                            ///
                            //천단위 정수값 표시
                            ///csDis = String.Format("{0}", dsValue2);
                            //----------------------------------
                            //////

                            //고조각 위치값
                            lblElevation.Text = csDis+ " ";// dsValue2.ToString();

                            //----------------------------------
                            //수신 데이터 번호
                            lblRecvDataNoDis.Text = g_byteData[8].ToString();
                            //RUN(SEEK) 진행 여부
                            lblRecvRunDis.Text = g_byteData[9].ToString();
                            //----------------------------------
                            //----------------------------------
                            //----------------------------------
                            //---------------------------------------------
                            //AZ 위치 지령
                            if (gAzAddMovePos < 0)//감소 모드
                            {
                                Value1 = 6400 + gAzAddMovePos;
                            }
                            else
                                Value1 = gAzAddMovePos;
                            //---------------------------------------------
                            csData1 = Value1.ToString() + ",  ";

                            //AZ 구동 위치 데이터
                            Value1 = 0;
                            Value1 += g_byteData[4] << 8;
                            Value1 += g_byteData[5];

                            //buf[0] = g_byteData[4];
                            //buf[1] = g_byteData[5];
                            //buf2 = 0;
                            //buf2 = System.BitConverter.ToUInt16(buf, 0);

                            //buf3 = System.BitConverter.ToInt16(BitConverter.GetBytes(buf2), 0);
                            //Value1 = (float)buf3;

                            //------------------------
                            //------------------------
                            //엔코더 만단위 소수점 데이터 표시시 사용
                            Value1 = Value1 * 0.1f;
                            if (Value1 > 6399.9) Value1 =  0.0f;
                            //------------------------
                            //------------------------

                            //천단위 저장
                            //csData2 = Value1.ToString() + ",  ";
                            //만단위 저장
                            csData2 = String.Format("{0:F1}, ", Value1);
                            //azErrorPos = gAzAddMovePos - (Value1);
                            //---------------------------------------------
                            //AZ 위치 Gap
                            if (gAzAddMovePos < 0)//감소 모드
                            {
                                azErrorPos = (6400 + gAzAddMovePos) - Value1;
                            }
                            else
                                azErrorPos = gAzAddMovePos - Value1;
                            //---------------------------------------------


                            //---------------------------------------------
                            //EL 위치 지령
                            if (gElAddMovePos < 0)//감소 모드
                            {
                                Value1 = 6400+gElAddMovePos;
                            }
                            else
                            Value1 = gElAddMovePos;
                            //---------------------------------------------

                            // if (g_byteData[9] == 1)
                            csData3 = Value1.ToString() + ",  ";
                           // else
                           //     csData3 = "0" + ",  ";

                            //EL 구동 위치 데이터 
                            Value1 = 0;
                            Value1 += g_byteData[6] << 8;
                            Value1 += g_byteData[7];

                            //buf[0] = g_byteData[4];
                            //buf[1] = g_byteData[5];
                            //buf2 = 0;
                            //buf2 = System.BitConverter.ToUInt16(buf, 0);

                            //buf3 = System.BitConverter.ToInt16(BitConverter.GetBytes(buf2), 0);
                            //Value1 = (float)buf3;

                            //++++++++++++++++++++++++++++++++++++++++++++
                            //Value1 = buf3;/////// 테스트 데이터 - 디스플레이
                            //++++++++++++++++++++++++++++++++++++++++++++

                            ///lblElEncodeDis.Text = Value1.ToString(); //엔코더 1000단위데이터

                            //------------------------
                            //------------------------
                            //엔코더 만단위 소수점 데이터 표시시 사용
                            Value1 = Value1 * 0.1f;
                            if (Value1 > 6399.9) Value1 =  0.0f;
                            //------------------------
                            //------------------------

                            //천단위 저장 
                            //csData4 = Value1.ToString() + ",  ";

                            //만단위 저장
                            csData4 = String.Format("{0:F1}, ", Value1);

                            //---------------------------------------------
                            //EL 위치 Gap
                            if (gElAddMovePos < 0)//감소 모드
                            {
                                elErrorPos = (6400 + gElAddMovePos) - Value1;
                            }
                            else
                                elErrorPos = gElAddMovePos - Value1;
                            //---------------------------------------------
                           
                            //Data No : 0~255
                            Value1 = g_byteData[8];
                            csData5 = Value1.ToString() + ",  ";

                            //Run 상태 : 1 - Run
                            Value1 = g_byteData[9];
                            csData6 = Value1.ToString() + ",  ";
                            /*  
                           //데이터 간격 cnt
                           cnt = gTimerCnt - gTimerOld;
                           csData7 = cnt.ToString();
                           lblTimerDis.Text = csData7;
                           //gTimerOld = gTimerCnt;
                           */

                            //-------------------------------------------------------------
                            
                            //csData7 = azErrorPos.ToString() + ",  ";  //AZ 데이터 차이 (Gap)
                            //csData8 = elErrorPos.ToString() + ",  ";  //EL 데이터 차이 (Gap)
                            csData7 = String.Format("{0:F1}", azErrorPos) + ",  ";
                            csData8 = String.Format("{0:F1}", elErrorPos) + ",  "; 
                            //-------------------------------------------------------------

                            if (g_byteData[3] == ICD_MsgID_TEST_RESPONSE_ACK) //테스트 모드시 주기적 ACK 메세지
                            {
                                //수신 상태시만 데이터 저장
                                //=========================================  
                                //Data1
                                //AZ Speed 
                                Value1 = 0;
                                Value1 += g_byteData[10] << 8;
                                Value1 += g_byteData[11];

                                if (Value1 > 32767)
                                {
                                    Value1 = (65535 - Value1)* -1;
                                    Value1 *= 0.1f;
                                }
                                else
                                    Value1 *= 0.1f;

                                csData9 = String.Format("{0:F1}", Value1) + ",  ";
                                lblDataDisplay1.Text = Value1.ToString();
                                //--------------------------------
                                DisplayData1 = Value1;
                                //--------------------------------
                                //=========================================  
                                //Data2
                                //El Speed / Test용 값, 속도
                                Value1 = 0;
                                Value1 += g_byteData[12] << 8;
                                Value1 += g_byteData[13];

                                Value1 *= 0.1f;
                                //--------------------------------
                                DisplayData2 = Value1;
                                //--------------------------------
                                //csData10 = Value1.ToString() + ",  ";
                                //csData10= csData2; //AZ Encode Data
                                csData10 = String.Format("{0:F1}", Value1) + ",  "; 

                                lblDataDisplay2.Text = Value1.ToString();
                                //=========================================  
                                //Data3
                                //AZ RPM
                                //double Val = 0;
                                Value1 = 0;
                                Value1 += g_byteData[14] << 8;
                                Value1 += g_byteData[15];

                                //Value1 = Value1 / 10; //Test용 값(Az Pos)
                                //--------------------------------
                                DisplayData3 = Value1*0.1f;
                                //--------------------------------

                                csData11 = String.Format("{0:F1}", DisplayData3) + ",  ";
                                lblDataDisplay3.Text = DisplayData3.ToString();
                                //=========================================
                            }

                            //=============================================================
                            //=============================================================
                            //Grape 데이터 보기 RUN(SEEK) 진행 여부,                           
                            if (g_byteData[9] == 1) //자방기 구동중 상태 byte
                            {
                                try
                                {
                                    if (gGrapDisChk)
                                    {
                                        GrapeSize = Convert.ToUInt16(txtGrapeDataMax.Text);
                                        gChartDisCnt1++;
                                        if (gChartDisCnt1 <= GrapeSize)
                                        {
                                            dsValue1 = gAzPresentPos;

                                            if (dsValue1 > 3200) dsValue1 = 6400 - dsValue1;
                                            if (dsValue1 < 6500 && dsValue1 >= 0)
                                            {
                                                //0청색
                                                //////////////////
                                                chart1.Series[0].Points.AddXY(gChartDisCnt1, dsValue1);
                                                //////////////////
                                            }
                                                //1적색
                                                /////////////////
                                                //chart1.Series[1].Points.AddXY(gChartDisCnt1, DisplayData1);////////
                                                /////////////////

                                        }
                                        else
                                        {
                                            gChartDisCnt1 = 0;
                                            chart1.Series[0].Points.Clear();
                                            chart1.Series[1].Points.Clear();
                                        }
                                        //---------------------------------
                                       
                                        gChartDisCnt2++;
                                        if (gChartDisCnt2 <= GrapeSize)
                                        {


                                            dsValue1 = gElPresentPos;

                                            if (dsValue1 > 3200) dsValue1 = 6400 - dsValue1;
                                            if (dsValue1 < 6500 && dsValue1 >= 0)
                                            {
                                                //0청색
                                                //////////////////
                                                chart2.Series[0].Points.AddXY(gChartDisCnt2, dsValue1);
                                                //////////////////

                                            }
                                            /*
                                            if (g_byteData[3] == ICD_MsgID_TEST_RESPONSE_ACK) //테스트 모드시 주기적 ACK 메세지
                                            {
                                                dsValue2 = SloopSpeed;
                                                //0청색 &&&&&&&&&&&&&&&&&&&&&&&&&&&
                                                ////////////////
                                               /// if (DisplayData1 < 2000)
                                               ///     chart2.Series[0].Points.AddXY(gChartDisCnt2, DisplayData1);////////
                                               ///     &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&7
                                                ////////////////
                                                ////////////////
                                                if(DisplayData1<2000)
                                                    //녹색
                                                    //chart2.Series[1].Points.AddXY(gChartDisCnt2, DisplayData2);////////
                                                  
                                                ////////////////
                                            }
                                            else
                                                dsValue2 = gElPresentPos;

                                            /// if (dsValue2 > 3200) dsValue2 = 6400 - dsValue2;/////
                                            /// if (dsValue2 < 6500 && dsValue2 >= 0) ////
                                            //1적색
                                            ///////////////////
                                            if (DisplayData3 < 2000)
                                                chart2.Series[2].Points.AddXY(gChartDisCnt2, DisplayData3);
                                               ////////////////////////
                                               */
                                        }
                                        else
                                        {
                                            gChartDisCnt2 = 0;
                                            chart2.Series[0].Points.Clear();////
                                            chart2.Series[1].Points.Clear();
                                            chart2.Series[2].Points.Clear();
                                        }
                                    }                              

                                    float fTime = 0;
                                    fTime = (DateTime.Now.Minute * 60 * 1000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;

                                    fTime = fTime - gStartTime;
                                    lblTimeDisplay.Text = fTime.ToString();                             
                                }
                                catch { }
                            }
                            //=============================================================
                            //=============================================================



                            csHex += csData1 + csData2 + csData3 + csData4 + csData5 + csData6 + csData7 
                                + csData8 + csData9 + csData10 +csData11;

                            g_csSaveData += csHex + "\r\n";

                           /// if(gListDisChk)
                           ///  LogDis(csHex, NEW_LINE);
                        }
                        //=================================================================================================================
                        //=================================================================================================================
                        else if (g_byteData[3] == ICD_MsgID_PBIT_ACK || g_byteData[3] == ICD_MsgID_IBIT_ACK) //주기적 ACK 메세지
                        {
                            //if (g_byteData[4] != 0 || g_byteData[5] != 0) //PBIT(4), IBIT(5)
                            //{ }
/*
                            g_BitMessage[0] = "0x01 : EL Increment Encoder Fault";
                            g_BitMessage[1] = "0x02 : AZ Increment Encoder Fault";
                            g_BitMessage[2] = "0x04 : EL Over Current Fault";
                            g_BitMessage[3] = "0x08 : AZ Over Current Fault";

                            g_BitMessage[4] = "0x10 : Power Over Voltage Fault(Vdc > 36[V]), 자/수 공통";
                            g_BitMessage[5] = "0x20 : Power Low Voltage Fault(Vdc > 18[V]), 자/수 공통";
                            g_BitMessage[6] = "0x40 : EL Over Temperature Fault(Temp > 100[℃])";
                            g_BitMessage[7] = "0x80 : AZ Over Temperature Fault(Temp > 100[℃])";


                            g_BitMessage[8] = "0x01 : EL Hall Sensor Fault";
                            g_BitMessage[9] = "0x02 : AZ Hall Sensor Fault";
                            g_BitMessage[10] = "0x04 : EL Over Speed Fault";
                            g_BitMessage[11] = "0x08 : AZ Over Speed Fault";

                            g_BitMessage[12] = "0x10 : EL Board Fault";
                            g_BitMessage[13] = "0x20 : AZ Board Fault";
                            g_BitMessage[14] = "0x40 : EL Absolute Encoder Fault, 자/수 공통";
                            g_BitMessage[15] = "0x80 : AZ Absolute Encoder Fault, 자/수 공통";
*/

                            /*
                            string csBitDis = "";
                            int bit = 0;
                            int no = 0;

                            for (no = 0; no < 8; no++)
                            {
                                bit = g_byteData[4] >> no & 0x01;
                                if (bit == 0) csBitDis += g_BitMessage[no] + " :  (OK)" + "\r\n";
                                else csBitDis += g_BitMessage[no] + " :  (NG)" + "\r\n";
                            }

                            csBitDis += "      " + "\r\n";

                            for (no = 0; no < 8; no++)
                            {
                                bit = g_byteData[5] >> no & 0x01;

                                if (no == 2 || no == 3)//OverSpeed 제외
                                {
                                   
                                }
                                else
                                {
                                    if (bit == 0) csBitDis += g_BitMessage[no + 8] + " :  (OK)" + "\r\n";
                                    else csBitDis += g_BitMessage[no + 8] + " :  (NG)" + "\r\n";
                                }

                            }


                            // csBitDis = g_byteData[4].ToString() + ",    " + g_byteData[5].ToString();
                            MessageBox.Show(csBitDis, "BIT 상태 정보");
                            */

                        }
                        //=================================================================================================================
                        //=================================================================================================================
                        else
                        {
                            if (gTxDataDisChk)
                            {
                                csHex = "RX:    ";
                                if (nLength > 0)
                                {
                                    for (i = 0; i < nLength; i++)
                                    {
                                        // buf += csData[i] + ",";
                                        // byteBuf[0] = DataBytes[i];
                                        // buf += Encoding.UTF8.GetString(byteBuf, 0, byteBuf.Length) +",";
                                        //buf += DataBytes[i].ToString() + " : ";
                                        csHex += HextoAsc((byte)(g_byteData[i] >> 4));
                                        csHex += HextoAsc((byte)(g_byteData[i] & 0x0f));
                                        csHex += " ";
                                    }
                                    if (gTxDataDisChk)
                                        g_csSaveData += csHex + "\r\n";
                                    ///LogDis(csHex, NEW_LINE);
                                }
                            }
                        }
                        
                        for (i = 0; i < ICD_DATA_MAX; i++)
                        {
                            g_byteData[i] = 0;
                        }
                        g_csRecevData = "";
                        g_iRecevErrorCnt = 0;
                        g_RecevCnt = 0;
                    }
                }
                g_iRecevErrorCnt =0;
                g_bSend = false;
            }
            catch (Exception ex)
            {
                if (serialPort1.IsOpen)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                g_iRecevErrorCnt = 0;
                g_bRecevStart = false;
                g_bRecevStop = false;
                g_csRecevData = "";
            }
        }
        //=======================================================================================
        //=======================================================================================
        //=======================================================================================
        void JoyElUp()
        {
            timer4.Stop();
            mmTimer.Stop();

            g_bSend = true;
            byte dir = ICD_DIR_UP;// 255; //-1
            string csTmp = txtElSpeed.Text;
            byte Speed = Convert.ToByte(csTmp);
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);
            SendDataJoy(0, Speed, dir, Speed); //EL
        }
        void JoyElDn()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            byte dir = ICD_DIR_DN; //1;//1
            string csTmp = txtElSpeed.Text;
            byte Speed = Convert.ToByte(csTmp);
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);
            SendDataJoy(0, Speed, dir, Speed); //EL
        }
        void JoyStop()
        {
            LogDis("Jog Stop!!", ON);
            g_bSend = true;
            SendDataJoy(0, 0, 0, 0);
            
        }

        void JoyAzLeft()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            //--------------------------------
            //자방기 반대
            byte dir = ICD_DIR_LEFT; //1 0x80
            //--------------------------------

            string csTmp = txtAzSpeed.Text;
            byte Speed = Convert.ToByte(csTmp);
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);
            SendDataJoy(dir, Speed, 0, Speed); //AZ
            //----------------------------------------
            //SendDataJoy(dir, Speed, dir, Speed); //EL
        }
        void JoyAzRight()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            //--------------------------------
            byte dir = ICD_DIR_RIGHT; //1; //1
            //--------------------------------

            string csTmp = txtAzSpeed.Text;
            byte Speed = Convert.ToByte(csTmp);
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);
            SendDataJoy(dir, Speed, 0, Speed); //AZ
            //----------------------------------------
            //SendDataJoy(dir, Speed, dir, Speed); //EL
        }

        void JoyAzLeftElDn()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            //--------------------------------
            //자방기 반대
            byte dir = ICD_DIR_LEFT; //0x80,ICD_DIR_DN
            //--------------------------------

            string csTmp = txtAzSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);

            SendDataJoy(ICD_DIR_LEFT, SpeedAz, ICD_DIR_DN, SpeedEl); //AZ
            //----------------------------------------
        }

        void JoyAzRightElDn()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            //--------------------------------
            //자방기 반대
            byte dir = 0; //0x80,ICD_DIR_DN
            //--------------------------------

            string csTmp = txtAzSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);

            SendDataJoy(ICD_DIR_RIGHT, SpeedAz, ICD_DIR_DN, SpeedEl); //AZ
            //----------------------------------------
        }

        void JoyAzRightElUp()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            //--------------------------------
            //자방기 반대
            byte dir = ICD_DIR_RIGHT; //0x80,ICD_DIR_DN
            //--------------------------------

            string csTmp = txtAzSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);

            SendDataJoy(ICD_DIR_RIGHT, SpeedAz, ICD_DIR_UP, SpeedEl); //AZ
            //----------------------------------------
        }

        void JoyAzLeftElUp()
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            //--------------------------------
            //자방기 반대
            byte dir = 0; //0x80,ICD_DIR_DN
            //--------------------------------

            string csTmp = txtAzSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_JOY, LENGTH_CMD, 1);
            TimeDelay(1);

            SendDataJoy(ICD_DIR_LEFT, SpeedAz, ICD_DIR_UP, SpeedEl); //AZ
            //----------------------------------------
        }
        ///--------------------------------------------------------------
        //Joy AZ Left/Right
        // << 
        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            JoyAzLeft();
        }
        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            JoyStop();
        }
        //--------------------------------------------------------------
        // >>
        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            JoyAzRight();
        }
        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            JoyStop();
        }
        //=======================================================================================
        //Joy EL Up/Dn 
        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            JoyElUp();
            
        }
        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            JoyStop();
        }
        //-Dn------------------------------------------------------------
        private void btnDn_MouseDown(object sender, MouseEventArgs e)
        {
            JoyElDn();
        }
        private void btnDn_MouseUp(object sender, MouseEventArgs e)
        {
            JoyStop();
        }
        //=======================================================================================
        //=======================================================================================
        private void btnEmergency_Click(object sender, EventArgs e)
        {
            timer4.Stop();
            mmTimer.Stop();
            g_bSend = true;
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD,1);
        }
        //--------------------------------------------------------------
        private void ZogElUpchkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZogElUpchkBox.Checked == true)
            {
                JoyElUp();
            }
            else
            {
                JoyStop();
            }
        }
        //--------------------------------------------------------------
        private void ZogElDnchkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZogElDnchkBox.Checked == true)
            {
                JoyElDn();
            }
            else
            {
                JoyStop();
            }
        }
        //--------------------------------------------------------------
        private void ZogAzLeftchkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZogAzLeftchkBox.Checked == true)
            {
                JoyAzLeft();
            }
            else
            {
                JoyStop();
            }
        }
        //--------------------------------------------------------------
        private void ZogAzRightchkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZogAzRightchkBox.Checked == true)
            {
                JoyAzRight();
            }
            else
            {
                JoyStop();
            }
        }
        //--------------------------------------------------------------
        private void TxDataDisChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(TxDataDisChkBox.Checked)
            {
                gTxDataDisChk = true;
            }
            else
            {
                gTxDataDisChk = false;
            }
        }
        
        //--------------------------------------------------------------
        private void ChkBox_AutoDecreasePos_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_AutoDecreasePos.Checked)
            {
                gAutoDecreasePosChk = true;
            }
            else
                gAutoDecreasePosChk = false;
        }
        //--------------------------------------------------------------
        private void ChkBox_AutoStepIncreasePos_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_AutoStepIncreasePos.Checked)
            {
                gAutoStepIncreasePosChk = true;
            }
            else
                gAutoStepIncreasePosChk = false;
        }
        //--------------------------------------------------------------
        private void ChkBox_AutoSinePos_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_AutoSinePos.Checked)
            {
                gAutoSinePosChk = true;
            }
            else
                gAutoSinePosChk = false;
        }
        //--------------------------------------------------------------
        private void ChkBox_AutoSeekPos_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkBox_AutoSeekPos.Checked)
            {
                gAutoSeekPosModeChk = true;

                gAutoRepeatMoveMode = false;
                ChkBox_PointRepeatMove.Checked = false;
            }
            else
                gAutoSeekPosModeChk = false;
        }
        //--------------------------------------------------------------
        private void GrapDisChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GrapDisChkBox.Checked)
            {
                gGrapDisChk = true;
            }
            else
                gGrapDisChk = false;        
        }
        //--------------------------------------------------------------
        private void ListDisChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ListDisChkBox.Checked)
            {
                gListDisChk = true;
            }
            else
                gListDisChk = false;
        }
        //---------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------
        private void btStop_Click(object sender, EventArgs e)
        {
            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();

            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_STOP, LENGTH_CMD, 1);
            //TimeDelay(30);
            //SendDataJoy(0, 0, 0, 0);
        }
        //--------------------------------------------------------------
        private void btnPosSingleSend_Click(object sender, EventArgs e)
        {
            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();
            SinglePosMoveSend();
        }
        //--------------------------------------------------------------
        private void btnMultiPosSend_Click(object sender, EventArgs e)
        {
            gTxSendStart = false;
            timer4.Stop();
            mmTimer.Stop();
            MultiPosMoveSend();
        }
       
        private void btnSeekOn_Click(object sender, EventArgs e)
        {
            float fTime = (DateTime.Now.Minute * 60 * 1000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
            gStartTime = fTime;

            gChartDisCnt1 = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            gChartDisCnt2 = 0;
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();

            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();
            SeekIncreasePosMoveSend(1);
        }
        //--------------------------------------------------------------
        private void btnSeekStop_Click(object sender, EventArgs e)
        {
            float fTime = (DateTime.Now.Minute * 60 * 1000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
            gStartTime = fTime;
           /// txtElAddPos.Text = "0.0";///////////////////////////
            gChartDisCnt1 = 0;
            chart1.Series[0].Points.Clear();//////
            chart1.Series[1].Points.Clear();

            gChartDisCnt2 = 0;
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();///////
            chart2.Series[2].Points.Clear();///////

            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();
            // SeekDecreasePosMoveSend(1);
            SeekIncreasePosMoveSend2(1);
        }

        private void btnZeroPosMove_Click(object sender, EventArgs e)
        {
            PosMoveOrigin();
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //=======================================================================================
        //=======================================================================================
        //=======================================================================================

        public void PosMoveOrigin()
        {
            //string cs = "";
            //cs= String.Format("{0:#,#.##}", 100.01);
            //cs = String.Format("{0:F1}", 100.1);
            //MessageBox.Show(cs); return;

            //--------------------------------
            //txtAzAddPos.Text = "0";
            //txtElAddPos.Text = "0";
            //gAzJoystickPos = 0;
            //gElJoystickPos = 0;
            //--------------------------------

            //g_bSend = true;
            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();

            string csTmp = txtOriginSpeed.Text;
            byte Speed = Convert.ToByte(csTmp);

            ///SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
            ///TimeDelay(1);
            //SendDataPos(int AzPos, byte Azspeed, int ElPos, byte Elspeed, byte PosSeq)
            SendDataPos(0, Speed, 0, Speed, 1);
        }

        public void SendDataCmd(byte MsgId, byte ModeCmd, byte length, byte SeqMax)
        {
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            Buffer[0] = ICD_STX;
            Buffer[1] = length;
            lenCmd = (byte)(length + 3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = MsgId;
            Buffer[4] = ModeCmd;
            Buffer[5] = SeqMax;

            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (int i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }

            Buffer[lenCmd] = ICD_ETX;

            if (g_bSerialOpenChk)// if (serialPort1.IsOpen)
                serialPort1.Write(Buffer, 0, lenCmd + 1);

            //g_iSendSec = DateTime.Now.Second;
            //g_iSendmSec = DateTime.Now.Millisecond;
        }
        public void SendDataTestMode(byte MsgId, byte ModeCmd, byte length, byte SeqMax)
        {
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            Buffer[0] = ICD_STX;
            Buffer[1] = length;
            lenCmd = (byte)(length + 3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = MsgId;
            Buffer[4] = ModeCmd;
            Buffer[5] = SeqMax;

            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (int i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }

            Buffer[lenCmd] = ICD_ETX;

            if (g_bSerialOpenChk)// if (serialPort1.IsOpen)
                serialPort1.Write(Buffer, 0, lenCmd + 1);

            //g_iSendSec = DateTime.Now.Second;
            //g_iSendmSec = DateTime.Now.Millisecond;
        }
        //--------------------------------------------------------------
        // Bit Error 체크 
        public void SendDataBitRequest(byte MsgId, byte bit, byte length)
        {
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            Buffer[0] = ICD_STX;
            Buffer[1] = length;
            lenCmd = (byte)(length + 3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = MsgId;
            Buffer[4] = bit;

            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (int i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }

            Buffer[lenCmd] = ICD_ETX;

            if (g_bSerialOpenChk)// if (serialPort1.IsOpen)
                serialPort1.Write(Buffer, 0, lenCmd + 1);

            //g_iSendSec = DateTime.Now.Second;
            //g_iSendmSec = DateTime.Now.Millisecond;
        }
        //--------------------------------------------------------------
        public void SendDataJoy(byte Azdir, byte Azspeed, byte Eldir, byte Elspeed)
        {
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            Buffer[0] = ICD_STX;
            Buffer[1] = LENGTH_JOY;
            lenCmd = (byte)(LENGTH_JOY + 3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = ICD_MsgID_JOY_DATA;
            Buffer[4] = Azdir;
            Buffer[5] = Azspeed;
            Buffer[6] = Eldir;
            Buffer[7] = Elspeed;

            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (int i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }
            Buffer[lenCmd] = ICD_ETX;

            if (g_bSerialOpenChk)// if (serialPort1.IsOpen)
                serialPort1.Write(Buffer, 0, lenCmd + 1);
            //g_iSendSec = DateTime.Now.Second;
            //g_iSendmSec = DateTime.Now.Millisecond;
        }
        //--------------------------------------------------------------
        public void SendDataPos(float AzPos, byte Azspeed, float ElPos, byte Elspeed, byte PosSeq)
        {
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            byte i = 0;
            int cnt = 0;
            string csTmp = "";

            //-----------------------------------
            //-----------------------------------
            //64000
            AzPos *= 10;
            ElPos *= 10;
            //-----------------------------------


            csTmp = txtMessageAckTime.Text;
            byte ackTime = Convert.ToByte(csTmp);

            Buffer[0] = ICD_STX;
            Buffer[1] = LENGTH_POS;
            lenCmd = (byte)(LENGTH_POS + 3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = ICD_MsgID_POS_DATA;

            Buffer[4] = (byte)((int)(AzPos) >> 8);
            Buffer[5] = (byte)((int)(AzPos) & 0xff);
            Buffer[6] = Azspeed;

            Buffer[7] = (byte)((int)(ElPos) >> 8);
            Buffer[8] = (byte)((int)ElPos & 0xff);
            Buffer[9] = Elspeed;

            Buffer[10] = PosSeq; //DATA NO
            Buffer[11] = 0x01;   //RUN
            Buffer[12] = ackTime;//ACK TIME

            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }

            Buffer[lenCmd] = ICD_ETX;

            if (g_bSerialOpenChk)// if (serialPort1.IsOpen)
                serialPort1.Write(Buffer, 0, lenCmd + 1);

            //g_iSendSec = DateTime.Now.Second;
            //g_iSendmSec = DateTime.Now.Millisecond;
            //--------------------------------------------------------------------
            string csHex = "TX:    ";
            byte Length = lenCmd;
            string csTest = "TX    ,";

            //디스플레이 6400단위로 변경
            AzPos *= (float)0.1;
            ElPos *= (float)0.1;

            if (gTxDataDisChk)
            {
                //------------------------
                ///cnt = gTimerCnt - gTimerOld;
                ///lblTimerDis.Text = cnt.ToString();
                ///gTimerOld = gTimerCnt;

                csHex = "TX(0x73):   ,";
                csHex += AzPos.ToString() + "," + "=====," + ElPos.ToString() + "," + "=====," + "," + cnt.ToString();
                //------------------------
                g_csSaveData += csHex + "\r\n";
            }
            else
            {
                for (i = 0; i <= Length; i++)
                {
                    // buf += csData[i] + ",";
                    // byteBuf[0] = DataBytes[i];
                    // buf += Encoding.UTF8.GetString(byteBuf, 0, byteBuf.Length) +",";
                    //buf += DataBytes[i].ToString() + " : ";
                    //csbuf += Buffer[i].ToString() + " ";
                    csHex += HextoAsc((byte)(Buffer[i] >> 4));
                    csHex += HextoAsc((byte)(Buffer[i] & 0x0f));
                    csHex += " ";
                }
            }

            if (gListDisChk)
                LogDis(csHex, NEW_LINE);

            lblCmdAzimuth.Text = AzPos.ToString();
            lblCmdElevation.Text = ElPos.ToString();

            //MessageBox.Show(csHex);
            //--------------------------------------------------------------------
        }
        public void SendDataSeekPos(float AzPos, byte Azspeed, float ElPos, byte Elspeed, byte PosSeq, byte On)
        {
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            byte i = 0;

            string csTmp = "";
            csTmp = txtMessageAckTime.Text;
            byte ackTime = Convert.ToByte(csTmp);

            //-----------------------------------
            //-----------------------------------
            //64000 단위로 변경
            AzPos *= 10;
            ElPos *= 10;
            //-----------------------------------

            Buffer[0] = ICD_STX;
            Buffer[1] = LENGTH_POS;
            lenCmd = (byte)(LENGTH_POS + 3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = ICD_MsgID_SEARCH_MODE;

            Buffer[4] = (byte)((int)AzPos >> 8);
            Buffer[5] = (byte)((int)AzPos & 0xff);
            Buffer[6] = Azspeed;

            Buffer[7] = (byte)((int)ElPos >> 8);
            Buffer[8] = (byte)((int)ElPos & 0xff);
            Buffer[9] = Elspeed;

            Buffer[10] = PosSeq; //DATA NO
            Buffer[11] = 0x01;   //RUN
            Buffer[12] = ackTime;//ACK TIME

            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }

            Buffer[lenCmd] = ICD_ETX;

            if (g_bSerialOpenChk)// if (serialPort1.IsOpen)
                serialPort1.Write(Buffer, 0, lenCmd + 1);

            //g_iSendSec = DateTime.Now.Second;
            //g_iSendmSec = DateTime.Now.Millisecond;
            //--------------------------------------------------------------------
            string csHex = "TX:    ";
            byte Length = lenCmd;
            string csTest = "TX    ,";

            //디스플레이 6400단위로 변경
            AzPos *= (float)0.1;
            ElPos *= (float)0.1;

            if (gTxDataDisChk)
            {
                //------------------------
                //cnt = gTimerCnt - gTimerOld;
                //lblTimerDis.Text = cnt.ToString();
                //gTimerOld = gTimerCnt;

                csHex = "TX(0x78):   ,";
                csHex += AzPos.ToString() + "," + "=====," + ElPos.ToString() + "=====" + "," + "," + On.ToString();
                //------------------------
                g_csSaveData += csHex + "\r\n";
            }
            else
            {
                for (i = 0; i <= Length; i++)
                {
                    // buf += csData[i] + ",";
                    // byteBuf[0] = DataBytes[i];
                    // buf += Encoding.UTF8.GetString(byteBuf, 0, byteBuf.Length) +",";
                    //buf += DataBytes[i].ToString() + " : ";
                    //csbuf += Buffer[i].ToString() + " ";
                    csHex += HextoAsc((byte)(Buffer[i] >> 4));
                    csHex += HextoAsc((byte)(Buffer[i] & 0x0f));
                    csHex += " ";
                }
            }

            if (gListDisChk)
                LogDis(csHex, NEW_LINE);

            lblCmdAzimuth.Text = AzPos.ToString();
            lblCmdElevation.Text = ElPos.ToString();
        }

        public void SendDataMultiPos(byte MaxPos)
        {
            /*         
            byte lenCmd = 0;
            byte[] Buffer = new byte[20];
            byte i = 0;
            Buffer[0] = ICD_STX;
            Buffer[1] = (byte)(LENGTH_POS + ((MaxPos-1) * 6));
            lenCmd = (byte)(LENGTH_POS + ((MaxPos - 1) * 6)+3);
            Buffer[2] = ICD_SrID;
            Buffer[3] = ICD_MsgID_POS_DATA;

            for (i = 4; i < lenCmd - 3; i++)
            {
                Buffer[i] = gSendMultiPos[i-4];
            }

            Buffer[lenCmd - 3] = MaxPos;
            Buffer[lenCmd - 2] = 0x01;
            Buffer[lenCmd - 1] = Buffer[1];  //CRC
            for (i = 2; i < lenCmd - 1; i++)
            {
                Buffer[lenCmd - 1] = (byte)(Buffer[lenCmd - 1] ^ Buffer[i]);
            }
            Buffer[lenCmd] = ICD_ETX;
            serialPort1.Write(Buffer, 0, lenCmd + 1);
            //--------------------------------------------------------------------
            byte Length = lenCmd;
            string csHex = "TX:    ";
            for (i = 0; i <= Length; i++)
            {
                // buf += csData[i] + ",";
                // byteBuf[0] = DataBytes[i];
                // buf += Encoding.UTF8.GetString(byteBuf, 0, byteBuf.Length) +",";
                //buf += DataBytes[i].ToString() + " : ";
                //csbuf += Buffer[i].ToString() + " ";
                csHex += HextoAsc((byte)(Buffer[i] >> 4));
                csHex += HextoAsc((byte)(Buffer[i] & 0x0f));
                csHex += " ";
            }
            g_csSaveData += csHex + "\r\n";
            LogDis(csHex, NEW_LINE);
            MessageBox.Show(csHex);
            //--------------------------------------------------------------------
            */
        }
        //----------------------------------------
        public void SeekIncreasePosMoveSend(byte on)
        {
            string csTmp = "";
            float pos = 0;
            //int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int addEl = Convert.ToUInt16(txtElAddStepPos.Text);

            pos = Convert.ToSingle(txtAzAddStepPos.Text);
            float addAz = Convert.ToSingle(pos);
            pos = Convert.ToSingle(txtElAddStepPos.Text);
            float addEl = Convert.ToSingle(pos);

            gAzAddMovePos = Convert.ToSingle(txtAzAddPos.Text);
            gElAddMovePos = Convert.ToSingle(txtElAddPos.Text);

            if (gAzAddMovePos == 6400)
            {
                gAzAddMovePos = 0;
            }
            if (gElAddMovePos == 6400)
            {
                gElAddMovePos = 0;
            }

            if (gAzAddMovePos < 6400)
                gAzAddMovePos += addAz;
            if (gElAddMovePos < 6400)
                gElAddMovePos += addEl;

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            float fpos = Convert.ToSingle(gAzAddMovePos) * gSendDataRatio;
            txtAzAddPos.Text = Convert.ToString(fpos/ gSendDataRatio);
            float PosAz = fpos;// Convert.ToUInt16(fpos);

            fpos = Convert.ToSingle(gElAddMovePos) * gSendDataRatio;
            txtElAddPos.Text = Convert.ToString(fpos / gSendDataRatio);
            float PosEl = fpos;// Convert.ToUInt16(fpos);

            SendDataSeekPos(PosAz, SpeedAz, PosEl, SpeedEl, 1, on);
            
        }
        public void SeekDecreasePosMoveSend(byte on)
        {
            string csTmp = "";
            //int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int addEl = Convert.ToUInt16(txtElAddStepPos.Text);
            float pos;
            pos = Convert.ToSingle(txtAzAddStepPos.Text);
            int addAz = Convert.ToUInt16(pos);
            pos = Convert.ToSingle(txtElAddStepPos.Text);
            int addEl = Convert.ToUInt16(pos);

            gAzAddMovePos = Convert.ToUInt16(txtAzAddPos.Text);
            gElAddMovePos = Convert.ToUInt16(txtElAddPos.Text);

            if (gAzAddMovePos == 0)
            {
                gAzAddMovePos = 6400;
            }
            if (gElAddMovePos == 0)
            {
                gElAddMovePos = 6400;
            }

            gAzAddMovePos -= addAz;
            gElAddMovePos -= addEl;

            if (gAzAddMovePos < 0) gAzAddMovePos = 0;
            if (gElAddMovePos < 0) gElAddMovePos = 0;

            if (gAzAddMovePos > 6400) gAzAddMovePos = 6400;
            if (gElAddMovePos > 6400) gElAddMovePos = 6400;

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);


            float fpos = Convert.ToSingle(gAzAddMovePos) * gSendDataRatio;
            txtAzAddPos.Text = Convert.ToString(fpos / gSendDataRatio);
            float PosAz = fpos;// Convert.ToUInt16(fpos);

            fpos = Convert.ToSingle(gElAddMovePos) * gSendDataRatio;
            txtElAddPos.Text = Convert.ToString(fpos / gSendDataRatio);
            float PosEl = fpos;// Convert.ToUInt16(fpos);

            SendDataSeekPos(PosAz, SpeedAz, PosEl, SpeedEl, 1, on);
        }

        public void SeekIncreasePosMoveSend2(byte on)
        {
            string csTmp = "";
            //int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int addEl = Convert.ToUInt16(txtElAddStepPos.Text);

            float pos;
            pos = Convert.ToSingle(txtAzAddStepPos.Text);
            float addAz = Convert.ToSingle(pos);
            pos = Convert.ToSingle(txtElAddStepPos.Text);
            float addEl = Convert.ToSingle(pos);

            gAzAddMovePos = Convert.ToUInt16(txtAzAddPos2.Text);
            gElAddMovePos = Convert.ToUInt16(txtElAddPos2.Text);

            if (gAzAddMovePos == 6400)
            {
                gAzAddMovePos = 0;
            }
            if (gElAddMovePos == 6400)
            {
                gElAddMovePos = 0;
            }

            ///if (gAzAddMovePos < 6400)
            ///    gAzAddMovePos += addAz;
            ///if (gElAddMovePos < 6400)
            ///    gElAddMovePos += addEl;

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);


            float fpos = Convert.ToSingle(gAzAddMovePos) * gSendDataRatio;
            txtAzAddPos2.Text = Convert.ToString(fpos / gSendDataRatio);
            int PosAz = Convert.ToUInt16(fpos);

            fpos = Convert.ToSingle(gElAddMovePos) * gSendDataRatio;
            txtElAddPos2.Text = Convert.ToString(fpos / gSendDataRatio);
            int PosEl = Convert.ToUInt16(fpos);

            SendDataSeekPos(PosAz, SpeedAz, PosEl, SpeedEl, 1, on);
        }

        public void SeekPosAutoTimeMove()
        {
            //string csTmp = "";
            //int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int addEl = Convert.ToUInt16(txtElAddStepPos.Text);

            //gAzAddMovePos = Convert.ToUInt16(txtAzAddPos.Text);
            //gElAddMovePos = Convert.ToUInt16(txtElAddPos.Text);

            string csTmp = "";
            //int StepAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int StepEl = Convert.ToUInt16(txtElAddStepPos.Text);

            float StepAz = g_AzAddSetpVal;
            float StepEl = g_ElAddSetpVal;

            float addAz = Convert.ToSingle(txtAzAddPos.Text);
            float addEl = Convert.ToSingle(txtElAddPos.Text);
       

            if (gAutoRepeatMoveMode)
            {
                AutoRepeatMove();
                return;
            }
            else
            {
                if (gAutoDecreasePosChk)
                {
                    if (gAutoStepIncreasePosChk)
                    {
                        gAzAddMovePos -= StepAz;
                        //3600 = 6400-(AZ_LEFT_LIMIT-800)   //100mil 추가, 제어기 Limit 안전제어 여부 확인 
                        if (gAzAddMovePos < (6400 - (AZ_LEFT_LIMIT)) * -1) gAzAddMovePos = (6400 - (AZ_LEFT_LIMIT)) * -1;  //gAzJoystickPos = (6400 - (AZ_LEFT_LIMIT-100)) * -1;  
                        if (gAzAddMovePos < 0) addAz = 6400 + Convert.ToSingle(gAzAddMovePos);
                        else addAz = Convert.ToSingle(gAzAddMovePos);
                        txtAzAddPos.Text = String.Format("{0:F1}", addAz); //addAz.ToString();

                        gElAddMovePos -= StepEl;
                        //3600 = 6400-(AZ_LEFT_LIMIT-800)   //100mil 추가, 제어기 Limit 안전제어 여부 확인 
                        if (gElAddMovePos < (6400 - (EL_DN_LIMIT)) * -1) gElAddMovePos = (6400 - (EL_DN_LIMIT)) * -1;//gElJoystickPos = (6400 - (EL_DN_LIMIT-100)) * -1;
                        if (gElAddMovePos < 0) addEl = 6400 + Convert.ToSingle(gElAddMovePos);
                        else addEl = Convert.ToSingle(gElAddMovePos);
                        txtElAddPos.Text = String.Format("{0:F1}", addEl);//addEl.ToString();

                        /*
                        if (gAzAddMovePos < 0) gAzAddMovePos = 0;
                        if (gElAddMovePos < 0) gElAddMovePos = 0;

                        if (gAzAddMovePos > 6400) gAzAddMovePos = 6400;
                        if (gElAddMovePos > 6400) gElAddMovePos = 6400;

                        if (gAzAddMovePos == 0)
                        {
                            gAzAddMovePos = 6400;
                        }
                        if (gElAddMovePos == 0)
                        {
                            gElAddMovePos = 6400;
                        }

                        gAzAddMovePos -= addAz;
                        gElAddMovePos -= addEl;
                        */
                    }
                }
                else
                {
                    if (gAutoStepIncreasePosChk)
                    {
                        gAzAddMovePos += StepAz;
                        if (gAzAddMovePos > AZ_RIGHT_LIMIT) gAzAddMovePos = AZ_RIGHT_LIMIT;// +100; //100mil 추가, 제어기 Limit 안전제어 여부 확인 
                        if (gAzAddMovePos < 0) addAz = 6400 + Convert.ToSingle(gAzAddMovePos);
                        else addAz = Convert.ToSingle(gAzAddMovePos);

                        txtAzAddPos.Text = String.Format("{0:F1}", addAz); //addAz.ToString();

                        gElAddMovePos += StepEl;
                        if (gElAddMovePos > EL_UP_LIMIT) gElAddMovePos = EL_UP_LIMIT;// +100;//100mil 추가, 제어기 Limit 안전제어 여부 확인 
                        if (gElAddMovePos < 0) addEl = 6400 + Convert.ToSingle(gElAddMovePos);
                        else addEl = Convert.ToSingle(gElAddMovePos);

                        txtElAddPos.Text = String.Format("{0:F1}", addEl); //addEl.ToString();


                        //csTmp = txtAzAddSpeed.Text;
                        //byte SpeedAz = Convert.ToByte(csTmp);

                        //csTmp = txtElAddSpeed.Text;
                        //byte SpeedEl = Convert.ToByte(csTmp);

                        //txtAzAddPos.Text = gAzAddMovePos.ToString();
                        //int PosAz = gAzAddMovePos;

                        //txtElAddPos.Text = gElAddMovePos.ToString();
                        //int PosEl = gElAddMovePos;
                        //----------------------------------------------

                        /*
                        if (gAzAddMovePos == 6400)
                        {
                            gAzAddMovePos = 0;
                        }
                        if (gElAddMovePos == 6400)
                        {
                            gElAddMovePos = 0;
                        }

                        if (gAzAddMovePos < 6400)
                            gAzAddMovePos += addAz;
                        if (gElAddMovePos < 6400)
                            gElAddMovePos += addEl;
                       */
                    }
                }
            }

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            //txtAzAddPos.Text = gAzAddMovePos.ToString();
            txtAzAddPos.Text = String.Format("{0:F1}", addAz); //addAz.ToString();
            float fpos = Convert.ToSingle(addAz) * gSendDataRatio;
            int PosAz = Convert.ToUInt16(fpos);

            //txtElAddPos.Text = gElAddMovePos.ToString();
            txtElAddPos.Text = String.Format("{0:F1}", addEl); //addEl.ToString();
            fpos = Convert.ToSingle(addEl) * gSendDataRatio;
            int PosEl = Convert.ToUInt16(fpos);


            //if (gAzAddMovePos < 0) PosAz = gAzAddMovePos * -1;
            //if (gElAddMovePos < 0) PosEl = gElAddMovePos * -1;

            //txtAzAddPos.Text = PosAz.ToString();
            //txtElAddPos.Text = PosEl.ToString();

            //TimeDelay(10);
            byte posNo = gTxSendSeekDataNo++;
            if (gTxSendSeekDataNo > 255) gTxSendSeekDataNo = 0;

            if (gAutoSeekPosModeChk)
            {
                SendDataSeekPos(PosAz, SpeedAz, PosEl, SpeedEl, posNo, 1);
            }
            else
            {
                ///SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
                ///TimeDelay(5);
                //SendDataPos(int AzPos, byte Azspeed, int ElPos, byte Elspeed, byte PosSeq)
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, 1);
            }
            
            gTxSendEnd = true;
           
        }

        public void AutoRepeatMove()
        {
            string csTmp = "";
            //int StepAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int StepEl = Convert.ToUInt16(txtElAddStepPos.Text);

            int addAz = 0;
            int addEl = 0;

            int AzBuf = 0;
            int ElBuf = 0;

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            //txtAzAddPos.Text = gAzAddMovePos.ToString();
            //lblCmdAzimuth.Text = addAz.ToString();
            //label_Axis1.Text = gAzAutoRepeatMoveCnt.ToString();
            //label_Axis2.Text = gAzPresentPos.ToString();

            if (gAzAutoRepeatMoveCnt == 0)
            {
                AzBuf = Convert.ToUInt16(txtAzAddPos.Text);
                if (gAzPresentPos < AzBuf +1 && gAzPresentPos > AzBuf - 1)
                {
                    gAzAutoRepeatMoveCnt = 1;
                    //return;
                }
                else addAz = AzBuf;
            }
            else
            {
                AzBuf = Convert.ToUInt16(txtAzAddPos2.Text);

                if (gAzPresentPos < AzBuf + 1 && gAzPresentPos > AzBuf - 1)
                {
                    gAzAutoRepeatMoveCnt = 0;
                    //return;
                }
                else addAz = AzBuf;
            }
            //--------------------------------------------------------
            if (gElAutoRepeatMoveCnt == 0)
            {
                ElBuf = Convert.ToUInt16(txtElAddPos.Text);
                if (gElPresentPos < ElBuf + 1 && gElPresentPos > ElBuf - 1)
                {
                    gElAutoRepeatMoveCnt = 1;
                   // return;
                }
                else addEl = ElBuf;
            }
            else
            {
                ElBuf = Convert.ToUInt16(txtElAddPos2.Text);

                if (gElPresentPos < ElBuf + 1 && gElPresentPos > ElBuf - 1)
                {
                    gElAutoRepeatMoveCnt = 0;
                    //return;
                }
                else addEl = ElBuf;
            }

            int PosAz = addAz;

            //txtElAddPos.Text = gElAddMovePos.ToString();
            //lblCmdElevation.Text = addEl.ToString();
            int PosEl = addEl;

            byte posNo = gTxSendSeekDataNo++;
            if (gTxSendSeekDataNo > 255) gTxSendSeekDataNo = 0;

            //-------------------------------------------------------------
            //-------------------------------------------------------------
            SendDataSeekPos(PosAz, SpeedAz, PosEl, SpeedEl, posNo, 1);
            ///SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, 1);
            //-------------------------------------------------------------
            //-------------------------------------------------------------

            gTxSendEnd = true;
        }
        //----------------------------------------------------------------
        public void SeekSinePosMoveSend()
        {
            float gtemp = 0;
            float SineData = 0;
            int pos = 0;
            int dataMax = 500;
            int PosAz = 0;
            int PosEl = 0;
            string csTmp = "";

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            if (gAzSeekSineDatCnt == 0) gAzSeekSineDatCnt = 1;// 최소 1: 0~6400 경계 그래프 튀는 현상 방지
             pos = gAzSeekSineDatCnt; //gAzSeekSineDatCnt++;
            gtemp = (float)pos / dataMax * 360;
            //SineData = (float)(2 * Math.Sin(gtemp * Math.PI / 180));
            SineData = (float)((dataMax/2) * Math.Sin(gtemp * Math.PI / 180));
            PosAz = (int)SineData+ (dataMax / 2);

            if (PosAz <= 2) PosAz = 2;

             gAzSeekSineDatCnt++;
            if (gAzSeekSineDatCnt > dataMax)
            {
                gAzSeekSineDatCnt = 0;
                //chart1.Series[0].Points.Clear();
            }
            else
            {
                //chart1.Series[0].Points.AddXY(gAzSeekSineDatCnt, PosAz);
            }

            if (gElSeekSineDatCnt == 0) gElSeekSineDatCnt = 1;// 최소 1: 0~6400 경계 그래프 튀는현상 방지
            pos = gElSeekSineDatCnt; //gAzSeekSineDatCnt++;
            gtemp = (float)pos / dataMax * 360;
            //SineData = (float)(2 * Math.Sin(gtemp * Math.PI / 180));
            SineData = (float)((dataMax / 2) * Math.Sin(gtemp * Math.PI / 180));
            PosEl = (int)SineData + (dataMax / 2);
            if (PosEl <= 2) PosEl = 2;

            gElSeekSineDatCnt++;
            if (gElSeekSineDatCnt > dataMax)
            {
                gElSeekSineDatCnt = 0;
                //chart2.Series[1].Points.Clear();
            }
            else
            {
                //chart2.Series[1].Points.AddXY(gAzSeekSineDatCnt, PosAz);
            }       
             //TimeDelay(10);
             byte posNo = gTxSendSeekDataNo++;
             if (gTxSendSeekDataNo > 255) gTxSendSeekDataNo = 0;

            gAzAddMovePos = PosAz;
            gElAddMovePos = PosEl;

            SendDataSeekPos(PosAz, SpeedAz, PosEl, SpeedEl, posNo, 1);
            gTxSendEnd = true;
        }
        //--------------------------------------------------------------------------
        public void SinglePosMoveSend()
        {
            g_bSend = true;

            string csTmp = txtAzSpeedData.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElSpeedData.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            csTmp = txtAzPosData.Text;
            ///int PosAz = Convert.ToInt16(csTmp);
            float PosAz = Convert.ToSingle(csTmp);

            csTmp = txtElPosData.Text;
            // int PosEl = Convert.ToInt16(csTmp);
            float PosEl = Convert.ToSingle(csTmp);

            // SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
            // TimeDelay(1);
            ///
            //SendDataPos(int AzPos, byte Azspeed, int ElPos, byte Elspeed, byte PosSeq)
            SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, 1);
        }

        public void SingleNoPosMoveSend(int no)
        {
            //int[] azPos = new int[4];
            //int[] elPos = new int[4];

            float[] azPos = new float[4];
            float[] elPos = new float[4];

            byte[] azSpeed = new byte[4];
            byte[] elSpeed = new byte[4];
           // byte MaxPos = 0;
            byte i = 0;
            //int PosAz = 0;
            //int PosEl = 0;

            float PosAz = 0;
            float PosEl = 0;

            byte SpeedAz = 0;
            byte SpeedEl = 0;

            //MaxPos = Convert.ToByte(txtMultiSeqNo.Text);
            //if (MaxPos == 0) return;


            //azPos[0] = Convert.ToInt16(AzPos1.Text);
            //azPos[1] = Convert.ToInt16(AzPos2.Text);
            //azPos[2] = Convert.ToInt16(AzPos3.Text);
            //azPos[3] = Convert.ToInt16(AzPos4.Text);

            azPos[0] = Convert.ToSingle(AzPos1.Text);
            azPos[1] = Convert.ToSingle(AzPos2.Text);
            azPos[2] = Convert.ToSingle(AzPos3.Text);
            azPos[3] = Convert.ToSingle(AzPos4.Text);


            //elPos[0] = Convert.ToInt16(ElPos1.Text);
            //elPos[1] = Convert.ToInt16(ElPos2.Text);
            //elPos[2] = Convert.ToInt16(ElPos3.Text);
            //elPos[3] = Convert.ToInt16(ElPos4.Text);

            elPos[0] = Convert.ToSingle(ElPos1.Text);
            elPos[1] = Convert.ToSingle(ElPos2.Text);
            elPos[2] = Convert.ToSingle(ElPos3.Text);
            elPos[3] = Convert.ToSingle(ElPos4.Text);

            azSpeed[0] = Convert.ToByte(AzSpeed1.Text);
            azSpeed[1] = Convert.ToByte(AzSpeed2.Text);
            azSpeed[2] = Convert.ToByte(AzSpeed3.Text);
            azSpeed[3] = Convert.ToByte(AzSpeed4.Text);

            elSpeed[0] = Convert.ToByte(ElSpeed1.Text);
            elSpeed[1] = Convert.ToByte(ElSpeed2.Text);
            elSpeed[2] = Convert.ToByte(ElSpeed3.Text);
            elSpeed[3] = Convert.ToByte(ElSpeed4.Text);


            if (no == 1)
            {
                PosAz = azPos[0];
                PosEl = elPos[0];
                SpeedAz = azSpeed[0];
                SpeedEl = elSpeed[0];
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, (byte)(1));
            }

            if (no == 2)
            {
                PosAz = azPos[1];
                PosEl = elPos[1];
                SpeedAz = azSpeed[1];
                SpeedEl = elSpeed[1];
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, (byte)(1));
            }

        }

        public void MultiPosMoveSend()
        {
            int[] azPos = new int[4];
            int[] elPos = new int[4];
            byte[] azSpeed = new byte[4];
            byte[] elSpeed = new byte[4];
            byte MaxPos = 0;
            byte i = 0;
            int PosAz = 0;
            int PosEl = 0;
            byte SpeedAz = 0;
            byte SpeedEl = 0;

            MaxPos = Convert.ToByte(txtMultiSeqNo.Text);
            if (MaxPos == 0) return;


            azPos[0] = Convert.ToInt16(AzPos1.Text);
            azPos[1] = Convert.ToInt16(AzPos2.Text);
            azPos[2] = Convert.ToInt16(AzPos3.Text);
            azPos[3] = Convert.ToInt16(AzPos4.Text);

            elPos[0] = Convert.ToInt16(ElPos1.Text);
            elPos[1] = Convert.ToInt16(ElPos2.Text);
            elPos[2] = Convert.ToInt16(ElPos3.Text);
            elPos[3] = Convert.ToInt16(ElPos4.Text);

            azSpeed[0] = Convert.ToByte(AzSpeed1.Text);
            azSpeed[1] = Convert.ToByte(AzSpeed2.Text);
            azSpeed[2] = Convert.ToByte(AzSpeed3.Text);
            azSpeed[3] = Convert.ToByte(AzSpeed4.Text);

            elSpeed[0] = Convert.ToByte(ElSpeed1.Text);
            elSpeed[1] = Convert.ToByte(ElSpeed2.Text);
            elSpeed[2] = Convert.ToByte(ElSpeed3.Text);
            elSpeed[3] = Convert.ToByte(ElSpeed4.Text);


            if (MaxPos == 1)
            {
                PosAz = azPos[2];
                PosEl = elPos[2];
                SpeedAz = azSpeed[2];
                SpeedEl = elSpeed[2];
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, (byte)(1));
            }

            if (MaxPos == 2)
            {
                PosAz = azPos[3];
                PosEl = elPos[3];
                SpeedAz = azSpeed[3];
                SpeedEl = elSpeed[3];
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, (byte)(1));
            }

            /*
            azPos[0] = Convert.ToInt16(AzPos1.Text);
            azPos[1] = Convert.ToInt16(AzPos2.Text);
            azPos[2] = Convert.ToInt16(AzPos3.Text);
            azPos[3] = Convert.ToInt16(AzPos4.Text);

            elPos[0] = Convert.ToInt16(ElPos1.Text);
            elPos[1] = Convert.ToInt16(ElPos2.Text);
            elPos[2] = Convert.ToInt16(ElPos3.Text);
            elPos[3] = Convert.ToInt16(ElPos4.Text);

            azSpeed[0] = Convert.ToByte(AzSpeed1.Text);
            azSpeed[1] = Convert.ToByte(AzSpeed2.Text);
            azSpeed[2] = Convert.ToByte(AzSpeed3.Text);
            azSpeed[3] = Convert.ToByte(AzSpeed4.Text);

            elSpeed[0] = Convert.ToByte(ElSpeed1.Text);
            elSpeed[1] = Convert.ToByte(ElSpeed2.Text);
            elSpeed[2] = Convert.ToByte(ElSpeed3.Text);
            elSpeed[3] = Convert.ToByte(ElSpeed4.Text);

           /// SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, MaxPos);
           /// TimeDelay(1);

            for (i = 0; i < MaxPos; i++)
            {
                PosAz = azPos[i];
                PosEl = elPos[i];
                SpeedAz = azSpeed[i];
                SpeedEl = elSpeed[i];
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, (byte)(i + 1));
                TimeDelay(1);
            }
            */


            /*
            String data = "";
            for (i = 0; i < MaxPos; i++)
            {
                gSendMultiPos[pos] = (byte)(azPos[i] >> 8); pos++;
                //data += gSendMultiPos[pos].ToString() + "\r\n"; pos++;
                gSendMultiPos[pos] = (byte)(azPos[i] & 0xff); pos++;
                //data += gSendMultiPos[pos].ToString() + "\r\n"; pos++;
                gSendMultiPos[pos] = (byte)(azSpeed[i]); pos++;
                //data += gSendMultiPos[pos].ToString() + "\r\n"; pos++;
                gSendMultiPos[pos] = (byte)(elPos[i] >> 8); pos++;
                //data += gSendMultiPos[pos].ToString() + "\r\n"; pos++;
                gSendMultiPos[pos] = (byte)(elPos[i] & 0xff); pos++;
                //data += gSendMultiPos[pos].ToString() + "\r\n"; pos++;
                gSendMultiPos[pos] = (byte)(elSpeed[i]); pos++;
                //data += gSendMultiPos[pos].ToString() + "\r\n"; pos++;
            }
            //for (i = 0; i < MaxPos*6; i++)
            //{
            //    data += gSendMultiPos[i].ToString() +"\r\n";
            //}
            //MessageBox.Show(data);
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, MaxPos);
            TimeDelay(30);
            SendDataMultiPos(MaxPos);
            */
        }

        public void PosIncreaseMove()
        {
            string csTmp = "";
            //int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int addEl = Convert.ToUInt16(txtElAddStepPos.Text);
            float pos;
            pos = Convert.ToSingle(txtAzAddStepPos.Text);
            int addAz = Convert.ToUInt16(pos);
            pos = Convert.ToSingle(txtElAddStepPos.Text);
            int addEl = Convert.ToUInt16(pos);

            gAzAddMovePos = Convert.ToUInt16(txtAzAddPos.Text);
            gElAddMovePos = Convert.ToUInt16(txtElAddPos.Text);

            if (gAzAddMovePos == 6400)
            {
                gAzAddMovePos = 0;
            }
            if (gElAddMovePos == 6400)
            {
                gElAddMovePos = 0;
            }

            if (gAzAddMovePos < 6400)
                gAzAddMovePos += addAz;

            if (gElAddMovePos < 6400)
                gElAddMovePos += addEl;

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            txtAzAddPos.Text = gAzAddMovePos.ToString();
            int PosAz = Convert.ToUInt16(gAzAddMovePos);

            txtElAddPos.Text = gElAddMovePos.ToString();
            int PosEl = Convert.ToUInt16(gElAddMovePos);

            //SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
            //TimeDelay(10);
            //SendDataPos(int AzPos, byte Azspeed, int ElPos, byte Elspeed, byte PosSeq)
            SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, 1);
        }
        //--------------------------------------------------------------
        public void PosIncreaseMove2()
        {
            /*
            if (gTimerDelay1ms == 0)
            {
                SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
                gTimerDelay1ms = 1;
            }
            else
            {
                gTimerDelay1ms = 0;

                string csTmp = "";
                int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
                int addEl = Convert.ToUInt16(txtElAddStepPos.Text);

                gAzAddMovePos = Convert.ToUInt16(txtAzAddPos.Text);
                gElAddMovePos = Convert.ToUInt16(txtElAddPos.Text);

                if (gAutoDecreasePosChk)
                {
                    if (gAzAddMovePos > 0)
                        gAzAddMovePos -= addAz;

                    if (gElAddMovePos > 0)
                        gElAddMovePos -= addEl;
                }
                else
                {
                    if (gAzAddMovePos < 6400)
                        gAzAddMovePos += addAz;
                    if (gElAddMovePos < 6400)
                        gElAddMovePos += addEl;
                }

                csTmp = txtAzAddSpeed.Text;
                byte SpeedAz = Convert.ToByte(csTmp);

                csTmp = txtElAddSpeed.Text;
                byte SpeedEl = Convert.ToByte(csTmp);

                txtAzAddPos.Text = gAzAddMovePos.ToString();
                int PosAz = gAzAddMovePos;

                txtElAddPos.Text = gElAddMovePos.ToString();
                int PosEl = gElAddMovePos;
                //TimeDelay(10);
                SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, 1);
                gTxSendEnd = true;
            }
            */
        }
        public void PosDecreaseMove()
        {
            string csTmp = "";
            //int addAz = Convert.ToUInt16(txtAzAddStepPos.Text);
            //int addEl = Convert.ToUInt16(txtElAddStepPos.Text);

            float pos;
            pos = Convert.ToUInt16(txtAzAddStepPos.Text);
            int addAz = Convert.ToUInt16(pos);
            pos = Convert.ToUInt16(txtElAddStepPos.Text);
            int addEl = Convert.ToUInt16(pos);

            gAzAddMovePos = Convert.ToUInt16(txtAzAddPos.Text);
            gElAddMovePos = Convert.ToUInt16(txtElAddPos.Text);

            if (gAzAddMovePos == 0)
            {
                gAzAddMovePos = 6400;
            }
            if (gElAddMovePos == 0)
            {
                gElAddMovePos = 6400;
            }

            gAzAddMovePos -= addAz;
            gElAddMovePos -= addEl;

            if (gAzAddMovePos < 0) gAzAddMovePos = 0;
            if (gElAddMovePos < 0) gElAddMovePos = 0;

            if (gAzAddMovePos > 6400) gAzAddMovePos = 6400;
            if (gElAddMovePos > 6400) gElAddMovePos = 6400;

            csTmp = txtAzAddSpeed.Text;
            byte SpeedAz = Convert.ToByte(csTmp);

            csTmp = txtElAddSpeed.Text;
            byte SpeedEl = Convert.ToByte(csTmp);

            txtAzAddPos.Text = gAzAddMovePos.ToString();
            int PosAz = Convert.ToUInt16(gAzAddMovePos);

            txtElAddPos.Text = gElAddMovePos.ToString();
            int PosEl = Convert.ToUInt16(gElAddMovePos);

            //SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
            //TimeDelay(10);
            //SendDataPos(int AzPos, byte Azspeed, int ElPos, byte Elspeed, byte PosSeq)
            SendDataPos(PosAz, SpeedAz, PosEl, SpeedEl, 1);
        }


        //=======================================================================================
        //=======================================================================================
        private void btnClear_Click(object sender, EventArgs e)
        {

            g_iAdcMax = 0;
            g_iAdcMax2 = 0;
            LogDisList.Clear();
    
            lblAzimuth.Text = "";
            lblElevation.Text = "";
            lblAzimuth.Text = "";

            gChartDisCnt1 = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            gChartDisCnt2 = 0;
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            //----------------------
            //g_csSaveData = "";
            g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                              "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                              "AZ GAP" + "," + "EL GAP";

           // g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
           //                  "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
           //                  "AZ GAP" + "," + "EL GAP" + "," + "AZ SPEED" + "," + "EL SPEED" + "," + "AZ RPM";

            g_csSaveData += "\r\n";

            g_csOldTime = "";
            g_iSaveStepNo = 0;
            g_csSaveData += "\r\n";
            g_iSaveSubStep = 0;
            g_iSaveTime2 = g_iSaveTime1 = 0;

            gTimerCnt = 0;
            gTimerOld = 0;
            lblTimerDis.Text = "0";

            //gAzAddMovePos =0;
            //gElAddMovePos =0;
            //gTxSendSeekDataNo = 0;
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void btFileSave_Click(object sender, EventArgs e)
        {
            //int Length = g_csRecevData.Length;
            //string time = DateTime.Now.Second.ToString() + "초:" + DateTime.Now.Millisecond.ToString();
            //string file = DateTime.Now.Second.ToString() + "초:" + DateTime.Now.Millisecond.ToString();
            string time= DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "#" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            //string file = (@"C:\Tester\Data\data.csv");
            //string file = (@"D:\Tester\Data\")+"LogData-"+time+".csv";
            string file = (@"Data\") + "LogData-" + time + ".csv";
            //csHex += " (" + time + ")";//////
            //csHex = " (" + time + ")"; //HEX 무 표시 
            //csHex += "(" + Value1.ToString() + "," + Value2.ToString() + "," + Value3.ToString() + ")" + "\r";
            try
            {
                //string[] lines = System.IO.File.ReadAllLines(file);
                int Length = g_csSaveData.Length;
                int max = 0;
                //max = lines.GetLength(0);
                //------------------------------
                //if (max > 0 && max < DEV_MAX) m_DrawMax = max;
                //------------------------------
                string cs = g_csSaveData;// string.Empty;

                //for (int i = 0; i < max; i++)//DEV_MAX
                //{
                   // string[] ps;
                   // ps = lines[i].Split(',');
                   
                //    cs += string.Format("{0},{1},{2},{3},{4}", "", "", "", "") + "\r\n";
                //}
                System.IO.File.WriteAllText(file, cs);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("", file + "파일을 저장하지 못하겠습니다.!");
            }
            g_csSaveData = "";
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------   
        public void SineDataGrap()
        {
            //int gSineOutCnt = 0;
            //static readonly double = 3.14;
            /*
            float gtemp = (float)gSineOutCnt / 40000 * 360;
            float SineData = 0;
            //-------------------------------------------
            //자이로 sin 테스트 데이터 출력
            SineData = (float)(2 * Math.Sin(gtemp * Math.PI / 180));
            gSineOutCnt++;
            if (gSineOutCnt > 40000)//5000
            {
                gSineOutCnt = 0;
                timer4.Stop();
            }
            chart1.Series[0].Points.Add(SineData);
            */
            float gtemp = 0;
            float SineData = 0;
            //-------------------------------------------
            //자이로 sin 테스트 데이터 출력
            for (int i = 0; i < 400; i++)
            {
                gtemp = (float)i / 400 * 360;
                SineData = (float)(2 * Math.Sin(gtemp * Math.PI / 180));
                //chart1.Series[0].Points.Add(SineData);
                
                chart1.Series[0].Points.AddXY(i,SineData);
                chart1.Series[1].Points.AddXY(i,SineData+10);
            }
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            int hz = 0;
            try
            {
                //------------------------
                ///txtAzAddPos.Text = "0";
                ///txtElAddPos.Text = "0";
                //------------------------
                /// gAutoTestMode = true; ///
                gSloopChkAcecel = false;

                gAzAddMovePos = Convert.ToSingle(txtAzAddPos.Text);
                gElAddMovePos = Convert.ToSingle(txtElAddPos.Text);

                g_AzAddSetp = Convert.ToSingle(txtAzAddStepPos.Text); ;
                g_AzAddSetpVal = 0;

                g_ElAddSetp = Convert.ToSingle(txtElAddStepPos.Text); ;
                g_ElAddSetpVal = 0;

                gTimerCnt = 0;
                gTxSendStart = true;
                gAutoSendTime = Convert.ToInt16(txtTimerVal.Text);
                //MessageBox.Show(gAutoSendTime.ToString());
                timer4.Stop();
                mmTimer.Start();
                gAzSeekSineDatCnt = 0;
                gElSeekSineDatCnt = 0;

                hz= (int)(1000 / gAutoSendTime);
                lblHzDis.Text = "ms("+hz.ToString()+"hz)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        private void btnAutoStop_Click(object sender, EventArgs e)
        {
            gAutoTestMode = false;
            gTxSendStart = false;
            mmTimer.Stop();
        }

        private void AzVelCmdSlope()
        {
            if (gAzVelRef >= 0.0 && gAzVelRef < gAzVelCmd)
            {
                gAzVelRef = (gAzVelRef > gAzVelCmd - gAzAcc) ? gAzVelCmd : (gAzVelRef + gAzAcc);
            }
            else if (gAzVelRef >= 0.0 && gAzVelRef > gAzVelCmd)
            {
                gAzVelRef = (gAzVelRef < gAzVelCmd + gAzDec) ? gAzVelCmd : (gAzVelRef - gAzDec);
                if (gAzVelRef < 0) gAzVelRef = 0;
            }
            else
            {
                gAzVelRef = gAzVelCmd;
                if (gAzVelRef < 0) gAzVelRef = 0;
            }
        }

        public float gSlopeAccelStep = 0;
        public int gSloopDelayCnt = 0;
        public bool  gSloopChkAcecel = false;

        public float gAzVelRef = 0;
        public float gAzVelCmd = 0;
        public float gAzAcc = 1;
        public float gAzDec = 1;
        public float gTestSpec = 1800;
        public float gDecelGradientRatio = 9; //7
        public float gAccelGradientRatio = 12;

        public float gAxixDecel = 0.82f;

        float gSpeedOffset1 = 9.0f;
        float gSpeedOffset2 = 5.0f;  //최저 거리 시작 지점 
        float gSpeedOffset3 = 0.03f; //accel, 0.03  2.5
        float gSpeedOffset4 = 0.5f;  //decel, 0.2, 10, 
        float gSpeedOffset5 = 0.5f;  //decel, 0.2  
        float gSpeedOffset6 = 7.0f;  //7.0 최저 속도 

        //public float gSpeedOffset4 = 0.03f;
        //public float gSpeedOffset5 = 0.05f;

        public float gStartTime =0.0f;

        public int gAzTarketDistance = 0;

        private void GrapeSlopeTest()
        {
            //fdata2 = Convert.ToInt32(fdata2 * 0.82);   ///1560 : 6.117  1200:6.0
            //fdata3 = Convert.ToInt32(fdata2 * ((fdata2 * DecelRatio))); //0.03 곡선 기울기  0.0395   ///
            int   Direction = 1;
            float Speed = 0;

            float fSpeed = 0;
            float fDecelRatio = 0;
            float Gradient = 0;

            float axisDecel = gAxixDecel; //18% 감속       
            float Tarket = 0;

            String csData = "";

            float local_dist = 0;
            float PosStep = 0;
            float PosAddStep = 0;
            float LowLimitPos = 0;

            float DecelKp = 0.0f;

            float fTime = 0;
            fTime = (DateTime.Now.Minute * 60 * 1000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
            //gStartTime = fTime;

            //gDecelGradientRatio = Convert.ToSingle(txtTestLabel1.Text);
            //fDecelRatio = Convert.ToSingle(txtTestLabel2.Text);
            //gAxixDecel = Convert.ToSingle(txtTestLabel3.Text);
            //gTestSpec = Convert.ToSingle(txtTestLabel4.Text);

            LowLimitPos = Convert.ToSingle(txtTestLabel5.Text);

            PosAddStep = Convert.ToSingle(txtTestLabel6.Text);
            Tarket = Convert.ToSingle(txtTestLabel7.Text);

            gAccelGradientRatio = Convert.ToSingle(txtTestLabel8.Text);

            local_dist = Tarket - gSlopeAccelStep;

            if (gAzVelRef >= 0.0 && gAzVelRef <= gAzVelCmd) //Accel
            {
                if (gAzTarketDistance < gSpeedOffset2) //최저 거리시 가속 높이 조절
                    DecelKp = gDecelGradientRatio;
                else
                    DecelKp = 7.0f;
            }
            else //Decel
            {
                DecelKp = gDecelGradientRatio;   //12.0  0.9,   15.0  1.5
            }


            /*
            //if (gAzVelRef >= 0.0 && gAzVelRef < gAzVelCmd)
            //{
            //    if(local_dist< LowLimitPos)
            //        Speed = local_dist * gDecelGradientRatio;   //12.0  0.9,   15.0  1.5
            //    else
            //        Speed = local_dist * 7.0f;
            //}
            if (gAzVelRef >= 0.0 && gAzVelRef <= gAzVelCmd)  //Accel
            {
                // if (Tarket < LowLimitPos)
                //     Speed = local_dist * gAccelGradientRatio;   //12.0  0.9,   15.0  1.5
                // else
                //    Speed = local_dist * gDecelGradientRatio;   //12.0  0.9,   15.0  1.5

                Speed = (local_dist * 7.0f);  // 7~1.1 : 0.05
            }
            else //Decel
            {
                // if (Tarket < LowLimitPos)
                //     Speed = local_dist * gAccelGradientRatio;   //12.0  0.9,   15.0  1.5
                // else
                //     Speed = (local_dist * 7.0f);  // 7~1.1 : 0.05

                Speed = local_dist * gDecelGradientRatio;   //12.0  0.9,   15.0  1.5
            }
            */

            Speed = local_dist * DecelKp;   //12.0  0.9,   15.0  1.5

            //Speed = local_dist * gDecelGradientRatio;
            // Speed = gSlopeAccelStep * gDecelGradientRatio;

            if (Speed <= 0)
            {
                gSlopeAccelStep = 0;
                gSloopChkAcecel = false;
                gAccelMove = false;
                // g_csSaveData
                return;
            }
            AccelMoveGrape(Speed, 1);

            //gGrapeSaveCnt++;
            //csData = gGrapeSaveCnt.ToString() + "," + Speed.ToString() + ",";
            //g_csSaveData += csData + "\r\n";

            gSlopeAccelStep += PosAddStep;

            fTime = fTime - gStartTime;
            lblTimeDisplay.Text = fTime.ToString();
        }


        public void AccelMoveGrape(float Speed, int Direction)
        {
            byte SPPED_MAX = 255;
            float fSpeed = 0;
            float fDecelRatio = 0;
            float axisDecel = gAxixDecel; //18% 감속
            float gTestSpec = 1800;
            float fCmdSpeed = 0;

            float LowLimitPos = 0;

            String csData = "";


            gDecelGradientRatio = Convert.ToSingle(txtTestLabel1.Text);

            fDecelRatio = Convert.ToSingle(txtTestLabel2.Text);
            gSpeedOffset4 = fDecelRatio;
            gSpeedOffset5 = fDecelRatio;

            gAxixDecel = Convert.ToSingle(txtTestLabel3.Text);
            gTestSpec = Convert.ToSingle(txtTestLabel4.Text);

            LowLimitPos = Convert.ToSingle(txtTestLabel5.Text);
            gSpeedOffset2 = LowLimitPos;

           // float SpeedMax = Convert.ToSingle(txtTestLabel6.Text);
            float testStep = Convert.ToSingle(txtTestLabel7.Text);

            float  AccelOffset = Convert.ToSingle(txtTestLabel9.Text);
            gSpeedOffset3 = AccelOffset;

            //A7, 1.0 ~ 0.03, 1800

            //------------------------------------------------------------------------------
            Speed = Convert.ToInt16(Speed * 0.88f); //0.88, 12% 감속 30Kg 기구하중 진동
            //Speed = (uint16)(Speed * SPEED_DECEL_RATIO); //12% 더 감속, 30Kg 기구하중 진동

            //6 : 4.6464  , 0.139392
            //3 : 2.3232  , 0.069696
            //------------------------------------------------------------------------------

            if (Speed < 0) Speed *= -1; //abs(Speed): 소수점 표현 않됨

            if (Speed > SPPED_MAX) Speed = SPPED_MAX;   //속도	

            gGrapeSaveCnt++;
            csData += gGrapeSaveCnt.ToString() + "," + Speed.ToString() + ",";


            //g_csSaveData += csData + "\r\n";
            //gAzCurrentDir = Direction;
            //----------------------------------------------------------------
            // Max 7.65,  7.65(DecelKp)/255(Speed) = 0.03(Accel,Decel)
            //gAzAcc = Speed * 0.03f;//MAX:7.65(속도 255 x 0.03) 속도에 따라 가속 차등 적용
            //gAzAcc = Speed * fDecelRatio;//MAX:7.65(속도 255 x 0.03) 속도에 따라 가속 차등 적용

            //gAzAcc = Speed * gSpeedOffset4; //0.03
            //gAzAcc = Speed * AccelOffset;



            if (gAzTarketDistance < gSpeedOffset2) //최저 거리시 가속 높이 조절
                gAzAcc = Speed * gSpeedOffset3;//12:2.5, 9: 0.5, 9~7:0.03   0.03 MAX:7.65(속도 255 x 0.03) 속도에 따라 가속 차등 적용
            else
                gAzAcc = Speed * 0.03f;// gSpeedOffset4;//12:2.5



            //gAzAcc = Speed * fDecelRatio;

            //if (gAzAcc < 1)gAzAcc = 1;

            //위치제어 속도 개선 : 가감속율 증가, 오버슈트 범위 이내
            //if (Speed <= 3 && Speed > 0)gAzAcc = gAccelOffset;//0.5;  속도 6: gAzAcc가 0.139392 정도
            //----------------------------------------------------------------
            //-------------------------	
            //if (Speed > 1)
            //	gAzDec = Speed * 0.03;//MAX: 7.65(속도 255 x 0.03) 속도에 따라 가속 차등 적용, 7.65는 Kp
            //gAzDec = Speed * fDecelRatio;

            //if(gDecelGradientRatio- Speed <= LowLimitPos)
            //gAzDec = Speed * fDecelRatio;  //0.3



            if (gAzTarketDistance < gSpeedOffset2) //최저 거리시 가속 높이 조절
                gAzDec = Speed * gSpeedOffset4; //0.2  12:10, 9:2.5,  9~0.2
            else
                gAzDec = Speed * gSpeedOffset5; //0.2


            //else
            //    gAzDec = Speed * gSpeedOffset5;  //0.05

            //gAzDec = Speed * fDecelRatio;  //7: 0.05    12.0: 1.2

            //7. 0.1, 1600 : 1568
            //6.5, 0.05, 1500  : 1456
            //6, 0.032, 1400 : 1344

            //if (gAzDec < 1)gAzDec = 1;

            //TarketSpeed : 1 = Speed : 5.8 (( 1*7.65) * 0.88)*0.88
            //gTestSpeed1 = Speed *10;
            //-------------------------
            //if (abs(gAzTarketDistance) <= 1)
            {
                if (Direction != 0) //Stop 아니고 Tarket 값이 1일 경우 Speed 1 이하 구동 못함 보완 
                {
                    if (Speed <= 1)
                    {
                       // Speed += 1;
                       // gAzAcc = 1;
                       // gAzDec = 1;
                    }
                }
            }
            //------------------------------------------------------------------------------
            ///CMD_Data2.SpeedSet = (uint16)(Speed * SPEED_TO_RPM);
            ///if (CMD_Data2.SpeedSet > RPM_MAX)CMD_Data2.SpeedSet = RPM_MAX;	
            ///gAzVelCmd = CMD_Data2.SpeedSet;
            ///Speed = (uint16)(Speed * SPEED_TO_RPM);
            //Speed = (Speed * gDecelGradientRatio);

            fCmdSpeed = (Speed * 7.0f);  // 7~1.1 : 0.05 
            if (fSpeed > gTestSpec) fSpeed = gTestSpec;
            fCmdSpeed = fSpeed;

            //-----------------------------------------------------------------------------------
            if (gAzVelRef >= 0.0 && gAzVelRef <= fCmdSpeed)  //Accel
            {
                // if (testStep < LowLimitPos)
                //     fSpeed = (Speed * gAccelGradientRatio);
                // else
                //     fSpeed = (Speed * gDecelGradientRatio);

                fSpeed = (Speed * 7.0f); // 7~1.1 : 0.0           
            }
            else //Decel
            {
                fSpeed = (Speed * gDecelGradientRatio);
                //fSpeed = (Speed * 7.0f);  // 7~1.1 : 0.05
            }
            //*AccelOffset;


            if (fSpeed > gTestSpec) fSpeed = gTestSpec;
            gAzVelCmd = fSpeed;

            //최소 구동 7.85 = 1(speed) x 7.85
            //gAzTxSpeed = Speed;
            //가속 및 감속
            AzVelCmdSlope();
            ///    
            //-----------------------------------------------------------------------------------
            Speed = gAzVelRef;

            csData += Speed.ToString() + ",";
            g_csSaveData += csData + "\r\n";

            //적색
            //chart2.Series[0].Points.AddXY(i, fdata2 * DecelRatio2); //6.0 사선 기울기 
            //청색 
            chart2.Series[1].Points.AddXY(gSlopeAccelStep, Speed);  //곡선 기울기 

        } 
        //+ 증가 
        private void btnTest_Click(object sender, EventArgs e)
        {
            //int hz = 0;
            float fTime = 0.0f;
            try
            {
                gSloopChkAcecel = true;
                gSlopeAccelStep = 0;

                gAccelMove = true;
                gDecelMove = false;

                gGrapeSaveCnt = 0;
                gSloopDelayCnt = 0;

                fTime = (DateTime.Now.Minute*60*1000) + (DateTime.Now.Second*1000) + DateTime.Now.Millisecond;
                gStartTime = fTime;
                //string time = "'" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + ",   "; ;

                //g_csSaveData = "";
                g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                                  "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                                  "AZ GAP" + "," + "EL GAP";

                // g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                //                  "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                //                  "AZ GAP" + "," + "EL GAP" + "," + "AZ SPEED" + "," + "EL SPEED" + "," + "AZ RPM";

                g_csSaveData += "\r\n";

                gAzVelRef = 0;
                gAzVelCmd = 0;

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart2.Series[0].Points.Clear();///
                chart2.Series[1].Points.Clear();///
                chart2.Series[2].Points.Clear();///

                gTimerCnt = 0;
                //gTxSendStart = true;
                gAutoSendTime = Convert.ToInt16(txtTimerVal.Text);
                //MessageBox.Show(gAutoSendTime.ToString());
                timer4.Stop();
                mmTimer.Start();
                gAzSeekSineDatCnt = 0;
                gElSeekSineDatCnt = 0;
                //hz = (int)(1000 / gAutoSendTime);
                //lblHzDis.Text = "ms(" + hz.ToString() + "hz)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        // - 감소
        private void btnTest2_Click(object sender, EventArgs e)
        {
            int hz = 0;
            try
            {
                gSloopChkAcecel = true;
                gSlopeAccelStep = 255;
                gAccelMove = false;
                gDecelMove = true;

                gGrapeSaveCnt = 0;
                gSloopDelayCnt = 0;

                //g_csSaveData = "";
                g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                                  "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                                  "AZ GAP" + "," + "EL GAP";

                // g_csSaveData = "TIME" + "," + "AZ SET" + "," + "AZ MOVE" + "," + "EL SET" + "," +
                //                  "EL MOVE" + "," + "DATA NO" + "," + "RUN" + "," +
                //                  "AZ GAP" + "," + "EL GAP" + "," + "AZ SPEED" + "," + "EL SPEED" + "," + "AZ RPM";

                g_csSaveData += "\r\n";

                float DecelGradientRatio = Convert.ToSingle(txtTestLabel1.Text);
                float testStep = Convert.ToSingle(txtTestLabel6.Text);

                //gAzVelRef = 255 * DecelGradientRatio;
                //gAzVelCmd = 255*  DecelGradientRatio;


                //gAzVelRef = 255 * 7.65f;
                gAzVelRef = testStep * 7.0f;
                //gAzVelRef = 0;// testStep;
                gAzVelCmd = 0;

                gSlopeAccelStep = testStep;
                //gSlopeAccelStep;


                //gAzVelCmd = 255*  DecelGradientRatio;

                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();
                chart2.Series[2].Points.Clear();

                gAzAddMovePos = Convert.ToInt32(txtAzAddPos.Text);
                gElAddMovePos = Convert.ToInt32(txtElAddPos.Text);

                gTimerCnt = 0;
                //gTxSendStart = true;
                gAutoSendTime = Convert.ToInt16(txtTimerVal.Text);
                //MessageBox.Show(gAutoSendTime.ToString());
                timer4.Stop();
                mmTimer.Start();
                gAzSeekSineDatCnt = 0;
                gElSeekSineDatCnt = 0;

                //hz = (int)(1000 / gAutoSendTime);
                //lblHzDis.Text = "ms(" + hz.ToString() + "hz)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        private void btnAutoMove_Click(object sender, EventArgs e)
        {
            int time = 0;
            //timer4.Enabled = true;           
            time = Convert.ToInt16(txtAutoTimerVal.Text);
            timer4.Interval = time *1000;
            timer4.Start();

            SeekIncreasePosMoveSend(1);

            gAutoMoveCnt = 0;
            gAutoMoveChk = true;
        }
        private void btnAutoMoveStop_Click(object sender, EventArgs e)
        {
            timer4.Stop();
            gAutoMoveChk = false;

            string csTmp = txtOriginSpeed.Text;
            byte Speed = Convert.ToByte(csTmp);
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_POS, LENGTH_CMD, 1);
            TimeDelay(30);
            //SendDataPos(int AzPos, byte Azspeed, int ElPos, byte Elspeed, byte PosSeq)
            SendDataPos(0, Speed, 0, Speed, 1);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (gAutoMoveChk)
            {
                gAutoMoveCnt++;
                if (gAutoMoveCnt > 1)
                {
                    gAutoMoveCnt = 0;
                    //SeekIncreasePosMoveSend(1);
                    SeekIncreasePosMoveSend2(1);
                }
                else
                {
                    //SeekIncreasePosMoveSend2(1);
                    SeekIncreasePosMoveSend(1);
                }
            }
        }

        private void btnBitTest_Click(object sender, EventArgs e)
        {
            SendDataCmd(ICD_MsgID_CMD, ICD_MODE_REQUEST, LENGTH_CMD, 1);
            TimeDelay(1);
            //P BIT ACK : 0x01, I BIT ACK : 0x02
            SendDataBitRequest(ICD_MsgID_BIT, 0x02, LENGTH_BIT_REQ);
        }

        private void btnElZeroSet_Click(object sender, EventArgs e)
        {
            String message = "고저각을 0점으로 설정 하시겠습니까?";
            String caption = "0점 설정";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SendDataCmd(ICD_MsgID_CMD, ICD_MODE_EL_DRIVE_OFF, LENGTH_CMD, 1);
                TimeDelay(1);
                SendDataTestMode(ICD_MsgID_TEST_MODE, ICD_MAINT_EL_ORG_SET, LENGTH_CMD, 1);
            }
        }

        private void btnAzZeroSet_Click(object sender, EventArgs e)
        {
            String message = "방위각을 0점으로 설정 하시겠습니까?";
            String caption = "0점 설정";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SendDataCmd(ICD_MsgID_CMD, ICD_MODE_AZ_DRIVE_OFF, LENGTH_CMD, 1);
                TimeDelay(1);
                SendDataTestMode(ICD_MsgID_TEST_MODE, ICD_MAINT_AZ_ORG_SET, LENGTH_CMD, 1);
            }
        }

        private void btnPosSend1_Click(object sender, EventArgs e)
        {
            //g_bSend = true;
            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();

            SingleNoPosMoveSend(1);
        }

        private void btnPosSend2_Click(object sender, EventArgs e)
        {
            //g_bSend = true;
            gTxSendStart = false;
            mmTimer.Stop();
            timer4.Stop();

            SingleNoPosMoveSend(2);
        }


        //--------------------------------------------------------------
        private void btnAddPosMove_Click(object sender, EventArgs e)
        {
            //PosIncreaseMove();    
            gElVelCmd += Convert.ToInt16(txtTimerVal.Text);
        }
        //--------------------------------------------------------------
        private void btnDecreasePosMove_Click(object sender, EventArgs e)
        {

            gElVelCmd -= Convert.ToInt16(txtTimerVal.Text);
            //PosDecreaseMove();
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------  

        float PID_saturate(float input, float min, float max)
        {
            float saturated_value = input;
            if (input < min)
            {
                saturated_value = min;
            }
            else if (max < input)
            {
                saturated_value = max;
            }
            return saturated_value;
        }


        float gAzTorqeCmd = 0.0f, gElTorqeCmd = 0.0f; //-- Current Reference(Torque Command)
        float gAzMotVelLpf = 0.0f, gElMotVelLpf = 0.0f;

        bool gElSeekStopRun=false;
        float i16VqeRef_1 = 0;
        //float gElMotVelLpf = 0;
        float gElVelUi_Old = 0;
        float gElVelUi_OldOffset = 1;

        float gAzPrevError = 0;
        float gElPrevError = 0;

        float gMaxMotorSpeed = 1600;  // 1500;
        float TS_2 = 0.1f;// 0.001;// 0.002000;// 0.000050;//0.000050, 0.002;

        float gElVelKp = 1.20f;
        float gElVelKi = 1.20f;
        float gElVelKd = 0.02f;// 0.0001;//1.15

        uint  gErrDistGapStart = 5;//10
        uint gTarketChkMin = 50;


        uint gAzIcdRecvClearCnt = 0;
        uint gElIcdRecvClearCnt = 0;
        uint gClearCnt = 500;

        //float  gOldFilterData_x = 0;
        //float  gOldFilterData_y = 0;
        //float  LpTau = 0.0005;

        float gErrLpfOffset = 1.0f; //5.0
        float gErrLpfOffset2 = 2.0f; //50.0
        uint gErrAverageMax = 30; //20
        uint gErrAverageMax2 = 50;

        //float  gLpfErrOffset = 3.14;
        //float  gLpfErrMax = 2.0;
        //float  gLpfMin = 20;

        //float gSpeedToLpfOffset = 0.1;// 0.0001;/////
        //float gSpeedToLpfMin = 0;/////

        float gRpmToSpeed = 0.85f;
        float gSpeedToRpm = 1.5f;// 2.56;

        float gAzSpeedErrLpf = 0;
        float gElSpeedErrLpf = 0;

        float gTestOffset1 = 6.0f;
        float gTestOffset2 = 600;
        float gTestOffset3 = 650;
        float gTestOffset4 = 1000;
        float gTestOffset5 = 2;
        float gTestOffset6 = 0;
        float gPidStopSpeed = 600;

        float fDisplayVal1 = 0;
        float fDisplayVal2 = 0;
        float fDisplayVal3 = 0;

        bool gAzPidSpeedMode = false;
        bool gElPidSpeedMode = false;

        float gErrDataClearVal = 0;

        float gElVelRef = 0.0f;
        float gElVelCmd = 0.0f;
        float gElAcc = 0.1f;
        float gElDec = 1.0f;

        float gTestCnt = 0;
        void TestDataMake()
        {
            gTestCnt++;
            if(gTestCnt > Convert.ToUInt16(txtTestLabel1.Text)) gTestCnt = 0;

            gElVelCmd= gTestCnt;
            i16VqeRef_1 = gTestCnt + Convert.ToUInt16(txtTestLabel1.Text);

            //if (gElVelCmd > 100) gElVelCmd = 0;
        }

        void ElVelCmdSlope()
        {
            //if (gElSeekEndChk == 0 || gElSeekStopRun == 1)
            {
                if (gElVelRef >= 0.0 && gElVelRef < gElVelCmd)
                {
                    gElVelRef = (gElVelRef > gElVelCmd - gElAcc) ? gElVelCmd : (gElVelRef + gElAcc);
                }
                else if (gElVelRef >= 0.0 && gElVelRef > gElVelCmd)
                {
                    gElVelRef = (gElVelRef < gElVelCmd + gElDec) ? gElVelCmd : (gElVelRef - gElDec);
                    if (gElVelRef < 0) gElVelRef = 0;
                }
                else
                {
                    gElVelRef = gElVelCmd;
                    if (gElVelRef < 0) gElVelRef = 0;
                }
            }
        }

        private void ElVelLoop()
        {
            // output term
            float output = 0.0f;
            //PID environment variable
            float Kp = gElVelKp;
            float Ki = gElVelKi;
            float Kd = gElVelKd;
            float dT = TS_2; //make sure not 0
            float min = 0;
            float max = gMaxMotorSpeed;
            //PID calculate term
            float P_term = 0.0f;
            float I_term = 0.0f;
            float D_term = 0.0f;
            float error = 0.0f; //P
            float error_prev = gElPrevError; //D

            //float err = gAzSpeedErrLpf*gErrLpfOffset;
            //err = AverageOne(err);
            //if (err > gErrAverageMax)err = gErrAverageMax;
            //target_value += err;
            //fDisplayVal1 = err * 10; //////////////////

            float CurLpf = 0;

            float AddErr = 0;
            AddErr = gElSpeedErrLpf * gErrLpfOffset;
            //AddErr = AverageOne(AddErr);
            if (AddErr > gErrAverageMax) AddErr = gErrAverageMax;

            if (gElSeekStopRun)
            {
                return;
            }
            AddErr = 0;//////////

            //입력 속도 값은 뺴주고 출력 속 값은 높여줌
            if (i16VqeRef_1 < 0)
                gElMotVelLpf = (i16VqeRef_1 * -1) * gSpeedToRpm - AddErr;
            else
                gElMotVelLpf = i16VqeRef_1 * gSpeedToRpm - AddErr; ///

            //CurLpf = fabs(u32Mot2RPM);
            //gAzMotVelLpf = fabs((CurLpf*gSpeedToLpfOffset) - gSpeedToLpfMin); //gSpeedToLpfOffset: 0.1

            //if (fabs(i16VqeRef_2) < gLowSpeedMin)
            //gAzMotVelLpf = 0;
            //else
            //gAzMotVelLpf = fabs(i16VqeRef_2)*gRpmToSpeed;

            //fDisplayVal1 = gAzMotVelLpf * 10; //////////////////

            error = gElVelRef - gElMotVelLpf;//gAzMotVelLpf Motor Velocity Measured
            //error = fabs(gAzVelCmd - gAzMotVelLpf);//gAzMotVelLpf Motor Velocity Measured
            // calculate error
            //error = fabs(target_value - current_value)*gErrLpfOffset;
            I_term = gElVelUi_Old * gElVelUi_OldOffset;

    
            // calculate PID term
            P_term = Kp * error;
            I_term += Ki * error * dT;
            D_term = Kd * System.Math.Abs(error - error_prev) / dT;
            I_term = PID_saturate(I_term, min, max);

            //-------------------------------------------------------------------
            //fDisplayVal1 = fabs(i16VqeRef_1*gSpeedToRpm) * 10; //////////////////
            //fDisplayVal2 = gElVelCmd * 10;
            //-------------------------------------------------------------------

            gElVelUi_Old = I_term;
            // prepare for next call
            gElPrevError = System.Math.Abs(error);
            AddErr = gElSpeedErrLpf * gErrLpfOffset2;////////////
            AddErr = 0;//////////
            if (AddErr > gErrAverageMax2) AddErr = gErrAverageMax2;

            output = P_term + I_term + D_term + AddErr;

            fDisplayVal1 = P_term * 10;
            fDisplayVal2 = I_term * 10;
            //fDisplayVal3 = D_term * 10;

            output = PID_saturate(output, min, max);
            //output *= gRpmToSpeed;//0.85///////////////

            gElTorqeCmd = System.Math.Abs(output);
            //-----------------------------------------------------------------
            //fDisplayVal3 = gElTorqeCmd * 10;
            fDisplayVal3 = gElVelRef * 10;
            //-----------------------------------------------------------------
            //if (fabs(gAzVelRef) < gAzAcc)
            if (System.Math.Abs(gElVelRef) < gErrDataClearVal)
            {
                gElPrevError = 0.0f;
                gElVelUi_Old = 0.0f;
                //gAzVelUi = 0.0;
                //gAzSpeedErrLpf = 0;
            }
            //return output;
        }

        private void GrapeDis()
        {
            int Length = g_csRecevData.Length;
            string csHex = "";
            string csData = g_csRecevData;
            int GrapeSize = 0;

            float DisplayData1 = 0;
            float DisplayData2 = 0;
            float DisplayData3 = 0;
            float DisplayData4 = 0;
            float DisplayData5 = 0;

            float dsValue1 = 0;
            float dsValue2 = 0;

            float azErrorPos = 0;
            float elErrorPos = 0;
            float AxisSpeed = 0;
            float SloopSpeed = 0;
            float TestSpeed = 0;

            DisplayData1 = fDisplayVal1;
            DisplayData2 = fDisplayVal2;
            DisplayData3 = fDisplayVal3;

            try
            {
                if (gGrapDisChk)
                {
                    GrapeSize = Convert.ToUInt16(txtGrapeDataMax.Text);
                    gChartDisCnt1++;
                    if (gChartDisCnt1 <= GrapeSize)
                    {
                    }
                    else
                    {
                        gChartDisCnt1 = 0;
                        chart1.Series[0].Points.Clear();
                        chart1.Series[1].Points.Clear();
                    }
                    //---------------------------------

                    gChartDisCnt2++;
                    if (gChartDisCnt2 <= GrapeSize)
                    {

                        //0청색
                        ////////////////       
                        chart2.Series[0].Points.AddXY(gChartDisCnt2, DisplayData1/10);////////                                                                                                   
                        //녹색
                        chart2.Series[1].Points.AddXY(gChartDisCnt2, DisplayData2/10);////////
                        chart2.Series[2].Points.AddXY(gChartDisCnt2, DisplayData3/10);
                    
                    }
                    else
                    {
                        gChartDisCnt2 = 0;
                        //chart2.Series[0].Points.Clear();////
                        //chart2.Series[1].Points.Clear();
                        //chart2.Series[2].Points.Clear();
                    }
                }

                float fTime = 0;
                fTime = (DateTime.Now.Minute * 60 * 1000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;

                fTime = fTime - gStartTime;
                lblTimeDisplay.Text = fTime.ToString();
            }
            catch { }
        }
    }
}
