
using Multimedia;

namespace SerialTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ZogAzLeftchkBox = new System.Windows.Forms.CheckBox();
            this.ZogAzRightchkBox = new System.Windows.Forms.CheckBox();
            this.btFileSave = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDn = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.ZogElUpchkBox = new System.Windows.Forms.CheckBox();
            this.ZogElDnchkBox = new System.Windows.Forms.CheckBox();
            this.lblAzimuth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblElevation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtElSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAzSpeed = new System.Windows.Forms.TextBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPosSingleSend = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtElSpeedData = new System.Windows.Forms.TextBox();
            this.txtElPosData = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAzSpeedData = new System.Windows.Forms.TextBox();
            this.txtAzPosData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSerialOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialPortBps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerialPortName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOriginSpeed = new System.Windows.Forms.TextBox();
            this.btnZeroPosMove = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ElSpeed2 = new System.Windows.Forms.TextBox();
            this.ElPos2 = new System.Windows.Forms.TextBox();
            this.AzSpeed2 = new System.Windows.Forms.TextBox();
            this.AzPos2 = new System.Windows.Forms.TextBox();
            this.ElSpeed1 = new System.Windows.Forms.TextBox();
            this.ElPos1 = new System.Windows.Forms.TextBox();
            this.AzSpeed1 = new System.Windows.Forms.TextBox();
            this.AzPos1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnAddPosMove = new System.Windows.Forms.Button();
            this.txtElAddPos = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtElAddSpeed = new System.Windows.Forms.TextBox();
            this.txtAzAddSpeed = new System.Windows.Forms.TextBox();
            this.txtAzAddPos = new System.Windows.Forms.TextBox();
            this.txtElAddStepPos = new System.Windows.Forms.TextBox();
            this.txtAzAddStepPos = new System.Windows.Forms.TextBox();
            this.btnDecreasePosMove = new System.Windows.Forms.Button();
            this.TxDataDisChkBox = new System.Windows.Forms.CheckBox();
            this.lblTimeDis = new System.Windows.Forms.Label();
            this.mmTimer = new Multimedia.Timer(this.components);
            this.btnAutoStart = new System.Windows.Forms.Button();
            this.btnAutoStop = new System.Windows.Forms.Button();
            this.lblTimerDis = new System.Windows.Forms.Label();
            this.txtTimerVal = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.ChkBox_AutoDecreasePos = new System.Windows.Forms.CheckBox();
            this.btnSeekOn = new System.Windows.Forms.Button();
            this.btnSeekStop = new System.Windows.Forms.Button();
            this.ChkBox_AutoStepIncreasePos = new System.Windows.Forms.CheckBox();
            this.lblRecvDataNoDis = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblRecvRunDis = new System.Windows.Forms.TextBox();
            this.ChkBox_AutoSinePos = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblHzDis = new System.Windows.Forms.Label();
            this.ChkBox_AutoSeekPos = new System.Windows.Forms.CheckBox();
            this.GrapDisChkBox = new System.Windows.Forms.CheckBox();
            this.lblDataDisplay1 = new System.Windows.Forms.Label();
            this.lblDataDisplay2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtElAddPos2 = new System.Windows.Forms.TextBox();
            this.txtAzAddPos2 = new System.Windows.Forms.TextBox();
            this.ListDisChkBox = new System.Windows.Forms.CheckBox();
            this.btnAutoMove = new System.Windows.Forms.Button();
            this.btnAutoMoveStop = new System.Windows.Forms.Button();
            this.txtAutoTimerVal = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtMessageAckTime = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtPosOnCode = new System.Windows.Forms.TextBox();
            this.btnBitTest = new System.Windows.Forms.Button();
            this.btnElZeroSet = new System.Windows.Forms.Button();
            this.btnAzZeroSet = new System.Windows.Forms.Button();
            this.lblDataDisplay3 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMultiSeqNo = new System.Windows.Forms.TextBox();
            this.btnMultiPosSend = new System.Windows.Forms.Button();
            this.ElSpeed4 = new System.Windows.Forms.TextBox();
            this.ElPos4 = new System.Windows.Forms.TextBox();
            this.AzSpeed4 = new System.Windows.Forms.TextBox();
            this.AzPos4 = new System.Windows.Forms.TextBox();
            this.ElSpeed3 = new System.Windows.Forms.TextBox();
            this.ElPos3 = new System.Windows.Forms.TextBox();
            this.AzSpeed3 = new System.Windows.Forms.TextBox();
            this.AzPos3 = new System.Windows.Forms.TextBox();
            this.btnPosSend1 = new System.Windows.Forms.Button();
            this.btnPosSend2 = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtPosJoystickAdd = new System.Windows.Forms.TextBox();
            this.lblCmdElevation = new System.Windows.Forms.TextBox();
            this.lblCmdAzimuth = new System.Windows.Forms.TextBox();
            this.ChkBox_PointRepeatMove = new System.Windows.Forms.CheckBox();
            this.txtTestLabel1 = new System.Windows.Forms.TextBox();
            this.txtTestLabel2 = new System.Windows.Forms.TextBox();
            this.txtTestLabel3 = new System.Windows.Forms.TextBox();
            this.txtTestLabel4 = new System.Windows.Forms.TextBox();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.txtGrapeDataMax = new System.Windows.Forms.TextBox();
            this.txtTestLabel5 = new System.Windows.Forms.TextBox();
            this.txtTestLabel6 = new System.Windows.Forms.TextBox();
            this.lblTimeDisplay = new System.Windows.Forms.TextBox();
            this.txtTestLabel7 = new System.Windows.Forms.TextBox();
            this.txtTestLabel8 = new System.Windows.Forms.TextBox();
            this.txtTestLabel9 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.LogDisList = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(355, 467);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 38);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 4500;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 347);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // ZogAzLeftchkBox
            // 
            this.ZogAzLeftchkBox.AutoSize = true;
            this.ZogAzLeftchkBox.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ZogAzLeftchkBox.Location = new System.Drawing.Point(150, 471);
            this.ZogAzLeftchkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZogAzLeftchkBox.Name = "ZogAzLeftchkBox";
            this.ZogAzLeftchkBox.Size = new System.Drawing.Size(86, 18);
            this.ZogAzLeftchkBox.TabIndex = 83;
            this.ZogAzLeftchkBox.Text = "연속동작";
            this.ZogAzLeftchkBox.UseVisualStyleBackColor = true;
            this.ZogAzLeftchkBox.CheckedChanged += new System.EventHandler(this.ZogAzLeftchkBox_CheckedChanged);
            // 
            // ZogAzRightchkBox
            // 
            this.ZogAzRightchkBox.AutoSize = true;
            this.ZogAzRightchkBox.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ZogAzRightchkBox.Location = new System.Drawing.Point(252, 470);
            this.ZogAzRightchkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZogAzRightchkBox.Name = "ZogAzRightchkBox";
            this.ZogAzRightchkBox.Size = new System.Drawing.Size(86, 18);
            this.ZogAzRightchkBox.TabIndex = 84;
            this.ZogAzRightchkBox.Text = "연속동작";
            this.ZogAzRightchkBox.UseVisualStyleBackColor = true;
            this.ZogAzRightchkBox.CheckedChanged += new System.EventHandler(this.ZogAzRightchkBox_CheckedChanged);
            // 
            // btFileSave
            // 
            this.btFileSave.Location = new System.Drawing.Point(413, 466);
            this.btFileSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btFileSave.Name = "btFileSave";
            this.btFileSave.Size = new System.Drawing.Size(54, 39);
            this.btFileSave.TabIndex = 88;
            this.btFileSave.Text = "SAVE";
            this.btFileSave.UseVisualStyleBackColor = true;
            this.btFileSave.Click += new System.EventHandler(this.btFileSave_Click);
            // 
            // chart1
            // 
            this.chart1.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(5, 507);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "-";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "AZ";
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(593, 326);
            this.chart1.TabIndex = 91;
            this.chart1.Text = "chart1";
            // 
            // timer4
            // 
            this.timer4.Interval = 4000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUp.Location = new System.Drawing.Point(346, 114);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(90, 40);
            this.btnUp.TabIndex = 94;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // btnDn
            // 
            this.btnDn.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDn.Location = new System.Drawing.Point(343, 184);
            this.btnDn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDn.Name = "btnDn";
            this.btnDn.Size = new System.Drawing.Size(90, 43);
            this.btnDn.TabIndex = 95;
            this.btnDn.Text = "DOWN";
            this.btnDn.UseVisualStyleBackColor = true;
            this.btnDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDn_MouseDown);
            this.btnDn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDn_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeft.Location = new System.Drawing.Point(148, 419);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(94, 44);
            this.btnLeft.TabIndex = 96;
            this.btnLeft.Text = "LEFT";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRight.Location = new System.Drawing.Point(249, 419);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(94, 44);
            this.btnRight.TabIndex = 97;
            this.btnRight.Text = "RIGHT";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // ZogElUpchkBox
            // 
            this.ZogElUpchkBox.AutoSize = true;
            this.ZogElUpchkBox.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ZogElUpchkBox.Location = new System.Drawing.Point(346, 157);
            this.ZogElUpchkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZogElUpchkBox.Name = "ZogElUpchkBox";
            this.ZogElUpchkBox.Size = new System.Drawing.Size(86, 18);
            this.ZogElUpchkBox.TabIndex = 98;
            this.ZogElUpchkBox.Text = "연속동작";
            this.ZogElUpchkBox.UseVisualStyleBackColor = true;
            this.ZogElUpchkBox.CheckedChanged += new System.EventHandler(this.ZogElUpchkBox_CheckedChanged);
            // 
            // ZogElDnchkBox
            // 
            this.ZogElDnchkBox.AutoSize = true;
            this.ZogElDnchkBox.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ZogElDnchkBox.Location = new System.Drawing.Point(343, 233);
            this.ZogElDnchkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZogElDnchkBox.Name = "ZogElDnchkBox";
            this.ZogElDnchkBox.Size = new System.Drawing.Size(86, 18);
            this.ZogElDnchkBox.TabIndex = 99;
            this.ZogElDnchkBox.Text = "연속동작";
            this.ZogElDnchkBox.UseVisualStyleBackColor = true;
            this.ZogElDnchkBox.CheckedChanged += new System.EventHandler(this.ZogElDnchkBox_CheckedChanged);
            // 
            // lblAzimuth
            // 
            this.lblAzimuth.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblAzimuth.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAzimuth.ForeColor = System.Drawing.Color.Lime;
            this.lblAzimuth.Location = new System.Drawing.Point(346, 418);
            this.lblAzimuth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblAzimuth.Name = "lblAzimuth";
            this.lblAzimuth.Size = new System.Drawing.Size(121, 45);
            this.lblAzimuth.TabIndex = 100;
            this.lblAzimuth.Text = "0";
            this.lblAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(41, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 101;
            this.label6.Text = "방위각";
            // 
            // lblElevation
            // 
            this.lblElevation.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblElevation.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElevation.ForeColor = System.Drawing.Color.Lime;
            this.lblElevation.Location = new System.Drawing.Point(326, 10);
            this.lblElevation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblElevation.Name = "lblElevation";
            this.lblElevation.Size = new System.Drawing.Size(123, 45);
            this.lblElevation.TabIndex = 102;
            this.lblElevation.Text = "0";
            this.lblElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(179, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 103;
            this.label7.Text = "고저각";
            // 
            // txtElSpeed
            // 
            this.txtElSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtElSpeed.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElSpeed.Location = new System.Drawing.Point(381, 62);
            this.txtElSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElSpeed.Name = "txtElSpeed";
            this.txtElSpeed.Size = new System.Drawing.Size(53, 26);
            this.txtElSpeed.TabIndex = 104;
            this.txtElSpeed.Text = "150";
            this.txtElSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 105;
            this.label4.Text = "속도입력";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 476);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 107;
            this.label12.Text = "속도입력";
            // 
            // txtAzSpeed
            // 
            this.txtAzSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAzSpeed.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzSpeed.Location = new System.Drawing.Point(79, 470);
            this.txtAzSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzSpeed.Name = "txtAzSpeed";
            this.txtAzSpeed.Size = new System.Drawing.Size(53, 26);
            this.txtAzSpeed.TabIndex = 106;
            this.txtAzSpeed.Text = "150";
            this.txtAzSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chart2
            // 
            this.chart2.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderlineWidth = 2;
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(493, 507);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "CH 0";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "CH 1";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "CH 2";
            this.chart2.Series.Add(series8);
            this.chart2.Series.Add(series9);
            this.chart2.Series.Add(series10);
            this.chart2.Size = new System.Drawing.Size(650, 326);
            this.chart2.TabIndex = 114;
            this.chart2.Text = "chart2";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(479, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 105);
            this.label3.TabIndex = 115;
            // 
            // btnPosSingleSend
            // 
            this.btnPosSingleSend.BackColor = System.Drawing.Color.Silver;
            this.btnPosSingleSend.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosSingleSend.Location = new System.Drawing.Point(704, 106);
            this.btnPosSingleSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPosSingleSend.Name = "btnPosSingleSend";
            this.btnPosSingleSend.Size = new System.Drawing.Size(112, 57);
            this.btnPosSingleSend.TabIndex = 124;
            this.btnPosSingleSend.Text = "이동";
            this.btnPosSingleSend.UseVisualStyleBackColor = false;
            this.btnPosSingleSend.Click += new System.EventHandler(this.btnPosSingleSend_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(632, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 123;
            this.label14.Text = "속도";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 122;
            this.label5.Text = "위치";
            // 
            // txtElSpeedData
            // 
            this.txtElSpeedData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtElSpeedData.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElSpeedData.Location = new System.Drawing.Point(622, 106);
            this.txtElSpeedData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElSpeedData.Name = "txtElSpeedData";
            this.txtElSpeedData.Size = new System.Drawing.Size(56, 26);
            this.txtElSpeedData.TabIndex = 121;
            this.txtElSpeedData.Text = "150";
            this.txtElSpeedData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtElPosData
            // 
            this.txtElPosData.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElPosData.Location = new System.Drawing.Point(548, 106);
            this.txtElPosData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElPosData.Name = "txtElPosData";
            this.txtElPosData.Size = new System.Drawing.Size(60, 26);
            this.txtElPosData.TabIndex = 120;
            this.txtElPosData.Text = "0";
            this.txtElPosData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(509, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 14);
            this.label11.TabIndex = 119;
            this.label11.Text = "EL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(509, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 14);
            this.label10.TabIndex = 118;
            this.label10.Text = "AZ";
            // 
            // txtAzSpeedData
            // 
            this.txtAzSpeedData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAzSpeedData.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzSpeedData.Location = new System.Drawing.Point(622, 133);
            this.txtAzSpeedData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzSpeedData.Name = "txtAzSpeedData";
            this.txtAzSpeedData.Size = new System.Drawing.Size(56, 26);
            this.txtAzSpeedData.TabIndex = 117;
            this.txtAzSpeedData.Text = "150";
            this.txtAzSpeedData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAzPosData
            // 
            this.txtAzPosData.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzPosData.Location = new System.Drawing.Point(548, 133);
            this.txtAzPosData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzPosData.Name = "txtAzPosData";
            this.txtAzPosData.Size = new System.Drawing.Size(60, 26);
            this.txtAzPosData.TabIndex = 116;
            this.txtAzPosData.Text = "0";
            this.txtAzPosData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(898, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(244, 103);
            this.label8.TabIndex = 125;
            // 
            // btnSerialOpen
            // 
            this.btnSerialOpen.Location = new System.Drawing.Point(939, 146);
            this.btnSerialOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSerialOpen.Name = "btnSerialOpen";
            this.btnSerialOpen.Size = new System.Drawing.Size(152, 22);
            this.btnSerialOpen.TabIndex = 130;
            this.btnSerialOpen.Text = "OPEN";
            this.btnSerialOpen.UseVisualStyleBackColor = true;
            this.btnSerialOpen.Click += new System.EventHandler(this.btnSerialOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(939, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 129;
            this.label2.Text = "Bps";
            // 
            // txtSerialPortBps
            // 
            this.txtSerialPortBps.Location = new System.Drawing.Point(973, 118);
            this.txtSerialPortBps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSerialPortBps.Name = "txtSerialPortBps";
            this.txtSerialPortBps.Size = new System.Drawing.Size(119, 21);
            this.txtSerialPortBps.TabIndex = 128;
            this.txtSerialPortBps.Text = "115200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(938, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 127;
            this.label1.Text = "Port";
            // 
            // txtSerialPortName
            // 
            this.txtSerialPortName.Location = new System.Drawing.Point(973, 93);
            this.txtSerialPortName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSerialPortName.Name = "txtSerialPortName";
            this.txtSerialPortName.Size = new System.Drawing.Size(119, 21);
            this.txtSerialPortName.TabIndex = 126;
            this.txtSerialPortName.Text = "COM1";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(479, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(409, 93);
            this.label9.TabIndex = 131;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(760, 218);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 134;
            this.label18.Text = "속도";
            // 
            // txtOriginSpeed
            // 
            this.txtOriginSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOriginSpeed.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOriginSpeed.Location = new System.Drawing.Point(751, 235);
            this.txtOriginSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOriginSpeed.Name = "txtOriginSpeed";
            this.txtOriginSpeed.Size = new System.Drawing.Size(56, 26);
            this.txtOriginSpeed.TabIndex = 133;
            this.txtOriginSpeed.Text = "255";
            this.txtOriginSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnZeroPosMove
            // 
            this.btnZeroPosMove.BackColor = System.Drawing.Color.Silver;
            this.btnZeroPosMove.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZeroPosMove.Location = new System.Drawing.Point(512, 209);
            this.btnZeroPosMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZeroPosMove.Name = "btnZeroPosMove";
            this.btnZeroPosMove.Size = new System.Drawing.Size(209, 62);
            this.btnZeroPosMove.TabIndex = 132;
            this.btnZeroPosMove.Text = "영점이동";
            this.btnZeroPosMove.UseVisualStyleBackColor = false;
            this.btnZeroPosMove.Click += new System.EventHandler(this.btnZeroPosMove_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(311, 507);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 14);
            this.label13.TabIndex = 135;
            this.label13.Text = "AZ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(865, 507);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 14);
            this.label15.TabIndex = 136;
            this.label15.Text = "EL";
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(479, 290);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(409, 84);
            this.label16.TabIndex = 154;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(486, 314);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 14);
            this.label20.TabIndex = 179;
            this.label20.Text = "EL";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(486, 343);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 14);
            this.label19.TabIndex = 178;
            this.label19.Text = "AZ";
            // 
            // ElSpeed2
            // 
            this.ElSpeed2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ElSpeed2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElSpeed2.Location = new System.Drawing.Point(768, 310);
            this.ElSpeed2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElSpeed2.Name = "ElSpeed2";
            this.ElSpeed2.Size = new System.Drawing.Size(46, 26);
            this.ElSpeed2.TabIndex = 166;
            this.ElSpeed2.Text = "255";
            this.ElSpeed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElPos2
            // 
            this.ElPos2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElPos2.Location = new System.Drawing.Point(708, 310);
            this.ElPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElPos2.Name = "ElPos2";
            this.ElPos2.Size = new System.Drawing.Size(60, 26);
            this.ElPos2.TabIndex = 165;
            this.ElPos2.Text = "0";
            this.ElPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzSpeed2
            // 
            this.AzSpeed2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AzSpeed2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzSpeed2.Location = new System.Drawing.Point(768, 338);
            this.AzSpeed2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzSpeed2.Name = "AzSpeed2";
            this.AzSpeed2.Size = new System.Drawing.Size(46, 26);
            this.AzSpeed2.TabIndex = 164;
            this.AzSpeed2.Text = "255";
            this.AzSpeed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzPos2
            // 
            this.AzPos2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzPos2.Location = new System.Drawing.Point(708, 338);
            this.AzPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzPos2.Name = "AzPos2";
            this.AzPos2.Size = new System.Drawing.Size(60, 26);
            this.AzPos2.TabIndex = 163;
            this.AzPos2.Text = "0";
            this.AzPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElSpeed1
            // 
            this.ElSpeed1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ElSpeed1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElSpeed1.Location = new System.Drawing.Point(578, 310);
            this.ElSpeed1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElSpeed1.Name = "ElSpeed1";
            this.ElSpeed1.Size = new System.Drawing.Size(46, 26);
            this.ElSpeed1.TabIndex = 162;
            this.ElSpeed1.Text = "255";
            this.ElSpeed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElPos1
            // 
            this.ElPos1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElPos1.Location = new System.Drawing.Point(518, 310);
            this.ElPos1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElPos1.Name = "ElPos1";
            this.ElPos1.Size = new System.Drawing.Size(60, 26);
            this.ElPos1.TabIndex = 161;
            this.ElPos1.Text = "200";
            this.ElPos1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzSpeed1
            // 
            this.AzSpeed1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AzSpeed1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzSpeed1.Location = new System.Drawing.Point(578, 338);
            this.AzSpeed1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzSpeed1.Name = "AzSpeed1";
            this.AzSpeed1.Size = new System.Drawing.Size(46, 26);
            this.AzSpeed1.TabIndex = 160;
            this.AzSpeed1.Text = "255";
            this.AzSpeed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzPos1
            // 
            this.AzPos1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzPos1.Location = new System.Drawing.Point(518, 338);
            this.AzPos1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzPos1.Name = "AzPos1";
            this.AzPos1.Size = new System.Drawing.Size(60, 26);
            this.AzPos1.TabIndex = 159;
            this.AzPos1.Text = "200";
            this.AzPos1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(898, 193);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(244, 93);
            this.label21.TabIndex = 180;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Silver;
            this.btnStop.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStop.Location = new System.Drawing.Point(916, 206);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(209, 65);
            this.btnStop.TabIndex = 181;
            this.btnStop.Text = "구동정지";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(25, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 26);
            this.label22.TabIndex = 183;
            this.label22.Text = "시리얼테스트";
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(479, 378);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(664, 122);
            this.label25.TabIndex = 191;
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAddPosMove
            // 
            this.btnAddPosMove.BackColor = System.Drawing.Color.Silver;
            this.btnAddPosMove.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddPosMove.Location = new System.Drawing.Point(1064, 818);
            this.btnAddPosMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPosMove.Name = "btnAddPosMove";
            this.btnAddPosMove.Size = new System.Drawing.Size(90, 24);
            this.btnAddPosMove.TabIndex = 198;
            this.btnAddPosMove.Text = "증가이동(0x73)";
            this.btnAddPosMove.UseVisualStyleBackColor = false;
            this.btnAddPosMove.Click += new System.EventHandler(this.btnAddPosMove_Click);
            // 
            // txtElAddPos
            // 
            this.txtElAddPos.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElAddPos.Location = new System.Drawing.Point(706, 439);
            this.txtElAddPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElAddPos.Name = "txtElAddPos";
            this.txtElAddPos.Size = new System.Drawing.Size(60, 26);
            this.txtElAddPos.TabIndex = 197;
            this.txtElAddPos.Text = "0";
            this.txtElAddPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(606, 445);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 14);
            this.label23.TabIndex = 196;
            this.label23.Text = "EL";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(607, 472);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 14);
            this.label24.TabIndex = 195;
            this.label24.Text = "AZ";
            // 
            // txtElAddSpeed
            // 
            this.txtElAddSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtElAddSpeed.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElAddSpeed.Location = new System.Drawing.Point(832, 439);
            this.txtElAddSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElAddSpeed.Name = "txtElAddSpeed";
            this.txtElAddSpeed.Size = new System.Drawing.Size(56, 26);
            this.txtElAddSpeed.TabIndex = 194;
            this.txtElAddSpeed.Text = "255";
            this.txtElAddSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAzAddSpeed
            // 
            this.txtAzAddSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAzAddSpeed.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzAddSpeed.Location = new System.Drawing.Point(832, 468);
            this.txtAzAddSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzAddSpeed.Name = "txtAzAddSpeed";
            this.txtAzAddSpeed.Size = new System.Drawing.Size(56, 26);
            this.txtAzAddSpeed.TabIndex = 193;
            this.txtAzAddSpeed.Text = "255";
            this.txtAzAddSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAzAddPos
            // 
            this.txtAzAddPos.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzAddPos.Location = new System.Drawing.Point(706, 468);
            this.txtAzAddPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzAddPos.Name = "txtAzAddPos";
            this.txtAzAddPos.Size = new System.Drawing.Size(60, 26);
            this.txtAzAddPos.TabIndex = 192;
            this.txtAzAddPos.Text = "0";
            this.txtAzAddPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtElAddStepPos
            // 
            this.txtElAddStepPos.BackColor = System.Drawing.Color.White;
            this.txtElAddStepPos.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElAddStepPos.ForeColor = System.Drawing.Color.Black;
            this.txtElAddStepPos.Location = new System.Drawing.Point(634, 439);
            this.txtElAddStepPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElAddStepPos.Name = "txtElAddStepPos";
            this.txtElAddStepPos.Size = new System.Drawing.Size(66, 26);
            this.txtElAddStepPos.TabIndex = 199;
            this.txtElAddStepPos.Text = "0.01";
            this.txtElAddStepPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAzAddStepPos
            // 
            this.txtAzAddStepPos.BackColor = System.Drawing.Color.White;
            this.txtAzAddStepPos.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzAddStepPos.ForeColor = System.Drawing.Color.Black;
            this.txtAzAddStepPos.Location = new System.Drawing.Point(634, 468);
            this.txtAzAddStepPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzAddStepPos.Name = "txtAzAddStepPos";
            this.txtAzAddStepPos.Size = new System.Drawing.Size(66, 26);
            this.txtAzAddStepPos.TabIndex = 200;
            this.txtAzAddStepPos.Text = "0.01";
            this.txtAzAddStepPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDecreasePosMove
            // 
            this.btnDecreasePosMove.BackColor = System.Drawing.Color.Silver;
            this.btnDecreasePosMove.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDecreasePosMove.Location = new System.Drawing.Point(1062, 842);
            this.btnDecreasePosMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecreasePosMove.Name = "btnDecreasePosMove";
            this.btnDecreasePosMove.Size = new System.Drawing.Size(99, 25);
            this.btnDecreasePosMove.TabIndex = 201;
            this.btnDecreasePosMove.Text = "감소이동(0x73)";
            this.btnDecreasePosMove.UseVisualStyleBackColor = false;
            this.btnDecreasePosMove.Click += new System.EventHandler(this.btnDecreasePosMove_Click);
            // 
            // TxDataDisChkBox
            // 
            this.TxDataDisChkBox.AutoSize = true;
            this.TxDataDisChkBox.Location = new System.Drawing.Point(8, 328);
            this.TxDataDisChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxDataDisChkBox.Name = "TxDataDisChkBox";
            this.TxDataDisChkBox.Size = new System.Drawing.Size(96, 16);
            this.TxDataDisChkBox.TabIndex = 202;
            this.TxDataDisChkBox.Text = "TX 표기 여부";
            this.TxDataDisChkBox.UseVisualStyleBackColor = true;
            this.TxDataDisChkBox.CheckedChanged += new System.EventHandler(this.TxDataDisChkBox_CheckedChanged);
            // 
            // lblTimeDis
            // 
            this.lblTimeDis.AutoSize = true;
            this.lblTimeDis.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimeDis.Location = new System.Drawing.Point(919, 57);
            this.lblTimeDis.Name = "lblTimeDis";
            this.lblTimeDis.Size = new System.Drawing.Size(202, 14);
            this.lblTimeDis.TabIndex = 203;
            this.lblTimeDis.Text = "2018.08.09 오후  4: 00:00";
            // 
            // mmTimer
            // 
            this.mmTimer.Mode = Multimedia.TimerMode.Periodic;
            this.mmTimer.Period = 1;
            this.mmTimer.Resolution = 1;
            this.mmTimer.SynchronizingObject = this;
            this.mmTimer.Tick += new System.EventHandler(this.mmTimer_Tick);
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.BackColor = System.Drawing.Color.Silver;
            this.btnAutoStart.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAutoStart.ForeColor = System.Drawing.Color.Blue;
            this.btnAutoStart.Location = new System.Drawing.Point(493, 448);
            this.btnAutoStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Size = new System.Drawing.Size(50, 42);
            this.btnAutoStart.TabIndex = 204;
            this.btnAutoStart.Text = "자동 시작";
            this.btnAutoStart.UseVisualStyleBackColor = false;
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // btnAutoStop
            // 
            this.btnAutoStop.BackColor = System.Drawing.Color.Silver;
            this.btnAutoStop.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAutoStop.ForeColor = System.Drawing.Color.Red;
            this.btnAutoStop.Location = new System.Drawing.Point(548, 448);
            this.btnAutoStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAutoStop.Name = "btnAutoStop";
            this.btnAutoStop.Size = new System.Drawing.Size(50, 42);
            this.btnAutoStop.TabIndex = 205;
            this.btnAutoStop.Text = "자동 중지";
            this.btnAutoStop.UseVisualStyleBackColor = false;
            this.btnAutoStop.Click += new System.EventHandler(this.btnAutoStop_Click);
            // 
            // lblTimerDis
            // 
            this.lblTimerDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimerDis.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimerDis.Location = new System.Drawing.Point(5, 445);
            this.lblTimerDis.Name = "lblTimerDis";
            this.lblTimerDis.Size = new System.Drawing.Size(48, 24);
            this.lblTimerDis.TabIndex = 206;
            this.lblTimerDis.Text = "0";
            this.lblTimerDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimerVal
            // 
            this.txtTimerVal.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTimerVal.Location = new System.Drawing.Point(493, 419);
            this.txtTimerVal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimerVal.Name = "txtTimerVal";
            this.txtTimerVal.Size = new System.Drawing.Size(50, 26);
            this.txtTimerVal.TabIndex = 208;
            this.txtTimerVal.Text = "10";
            this.txtTimerVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(622, 422);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(98, 12);
            this.label26.TabIndex = 209;
            this.label26.Text = "증가수(mil)/1ms";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(717, 422);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 12);
            this.label28.TabIndex = 211;
            this.label28.Text = "위치1";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(844, 421);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 212;
            this.label29.Text = "속도";
            // 
            // ChkBox_AutoDecreasePos
            // 
            this.ChkBox_AutoDecreasePos.AutoSize = true;
            this.ChkBox_AutoDecreasePos.Location = new System.Drawing.Point(497, 385);
            this.ChkBox_AutoDecreasePos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBox_AutoDecreasePos.Name = "ChkBox_AutoDecreasePos";
            this.ChkBox_AutoDecreasePos.Size = new System.Drawing.Size(88, 16);
            this.ChkBox_AutoDecreasePos.TabIndex = 213;
            this.ChkBox_AutoDecreasePos.Text = "역 감소모드";
            this.ChkBox_AutoDecreasePos.UseVisualStyleBackColor = true;
            this.ChkBox_AutoDecreasePos.CheckedChanged += new System.EventHandler(this.ChkBox_AutoDecreasePos_CheckedChanged);
            // 
            // btnSeekOn
            // 
            this.btnSeekOn.BackColor = System.Drawing.Color.Silver;
            this.btnSeekOn.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSeekOn.ForeColor = System.Drawing.Color.Blue;
            this.btnSeekOn.Location = new System.Drawing.Point(898, 444);
            this.btnSeekOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeekOn.Name = "btnSeekOn";
            this.btnSeekOn.Size = new System.Drawing.Size(115, 42);
            this.btnSeekOn.TabIndex = 214;
            this.btnSeekOn.Text = "추적위치1 (0x78)";
            this.btnSeekOn.UseVisualStyleBackColor = false;
            this.btnSeekOn.Click += new System.EventHandler(this.btnSeekOn_Click);
            // 
            // btnSeekStop
            // 
            this.btnSeekStop.BackColor = System.Drawing.Color.Silver;
            this.btnSeekStop.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSeekStop.ForeColor = System.Drawing.Color.Blue;
            this.btnSeekStop.Location = new System.Drawing.Point(1018, 444);
            this.btnSeekStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeekStop.Name = "btnSeekStop";
            this.btnSeekStop.Size = new System.Drawing.Size(115, 42);
            this.btnSeekStop.TabIndex = 215;
            this.btnSeekStop.Text = "추적위치2 (0X78)";
            this.btnSeekStop.UseVisualStyleBackColor = false;
            this.btnSeekStop.Click += new System.EventHandler(this.btnSeekStop_Click);
            // 
            // ChkBox_AutoStepIncreasePos
            // 
            this.ChkBox_AutoStepIncreasePos.AutoSize = true;
            this.ChkBox_AutoStepIncreasePos.Location = new System.Drawing.Point(598, 385);
            this.ChkBox_AutoStepIncreasePos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBox_AutoStepIncreasePos.Name = "ChkBox_AutoStepIncreasePos";
            this.ChkBox_AutoStepIncreasePos.Size = new System.Drawing.Size(72, 16);
            this.ChkBox_AutoStepIncreasePos.TabIndex = 216;
            this.ChkBox_AutoStepIncreasePos.Text = "스탭증가";
            this.ChkBox_AutoStepIncreasePos.UseVisualStyleBackColor = true;
            this.ChkBox_AutoStepIncreasePos.CheckedChanged += new System.EventHandler(this.ChkBox_AutoStepIncreasePos_CheckedChanged);
            // 
            // lblRecvDataNoDis
            // 
            this.lblRecvDataNoDis.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblRecvDataNoDis.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecvDataNoDis.ForeColor = System.Drawing.Color.Lime;
            this.lblRecvDataNoDis.Location = new System.Drawing.Point(248, 158);
            this.lblRecvDataNoDis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRecvDataNoDis.Name = "lblRecvDataNoDis";
            this.lblRecvDataNoDis.Size = new System.Drawing.Size(44, 24);
            this.lblRecvDataNoDis.TabIndex = 217;
            this.lblRecvDataNoDis.Text = "0";
            this.lblRecvDataNoDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.Location = new System.Drawing.Point(252, 111);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(33, 12);
            this.label30.TabIndex = 218;
            this.label30.Text = "RUN";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.Location = new System.Drawing.Point(246, 147);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(51, 12);
            this.label31.TabIndex = 220;
            this.label31.Text = "수신NO";
            // 
            // lblRecvRunDis
            // 
            this.lblRecvRunDis.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblRecvRunDis.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecvRunDis.ForeColor = System.Drawing.Color.Yellow;
            this.lblRecvRunDis.Location = new System.Drawing.Point(248, 124);
            this.lblRecvRunDis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRecvRunDis.Name = "lblRecvRunDis";
            this.lblRecvRunDis.Size = new System.Drawing.Size(44, 24);
            this.lblRecvRunDis.TabIndex = 219;
            this.lblRecvRunDis.Text = "0";
            this.lblRecvRunDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChkBox_AutoSinePos
            // 
            this.ChkBox_AutoSinePos.AutoSize = true;
            this.ChkBox_AutoSinePos.Location = new System.Drawing.Point(678, 385);
            this.ChkBox_AutoSinePos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBox_AutoSinePos.Name = "ChkBox_AutoSinePos";
            this.ChkBox_AutoSinePos.Size = new System.Drawing.Size(77, 16);
            this.ChkBox_AutoSinePos.TabIndex = 221;
            this.ChkBox_AutoSinePos.Text = "Sine 출력";
            this.ChkBox_AutoSinePos.UseVisualStyleBackColor = true;
            this.ChkBox_AutoSinePos.CheckedChanged += new System.EventHandler(this.ChkBox_AutoSinePos_CheckedChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(970, 833);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(88, 34);
            this.btnTest.TabIndex = 222;
            this.btnTest.Text = "+TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblHzDis
            // 
            this.lblHzDis.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHzDis.Location = new System.Drawing.Point(544, 420);
            this.lblHzDis.Name = "lblHzDis";
            this.lblHzDis.Size = new System.Drawing.Size(80, 24);
            this.lblHzDis.TabIndex = 223;
            this.lblHzDis.Text = "ms(5hz)";
            this.lblHzDis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkBox_AutoSeekPos
            // 
            this.ChkBox_AutoSeekPos.AutoSize = true;
            this.ChkBox_AutoSeekPos.Location = new System.Drawing.Point(763, 385);
            this.ChkBox_AutoSeekPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBox_AutoSeekPos.Name = "ChkBox_AutoSeekPos";
            this.ChkBox_AutoSeekPos.Size = new System.Drawing.Size(101, 16);
            this.ChkBox_AutoSeekPos.TabIndex = 224;
            this.ChkBox_AutoSeekPos.Text = "0x78 추적모드";
            this.ChkBox_AutoSeekPos.UseVisualStyleBackColor = true;
            this.ChkBox_AutoSeekPos.CheckedChanged += new System.EventHandler(this.ChkBox_AutoSeekPos_CheckedChanged);
            // 
            // GrapDisChkBox
            // 
            this.GrapDisChkBox.AutoSize = true;
            this.GrapDisChkBox.Location = new System.Drawing.Point(110, 328);
            this.GrapDisChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrapDisChkBox.Name = "GrapDisChkBox";
            this.GrapDisChkBox.Size = new System.Drawing.Size(60, 16);
            this.GrapDisChkBox.TabIndex = 225;
            this.GrapDisChkBox.Text = "그래프";
            this.GrapDisChkBox.UseVisualStyleBackColor = true;
            this.GrapDisChkBox.CheckedChanged += new System.EventHandler(this.GrapDisChkBox_CheckedChanged);
            // 
            // lblDataDisplay1
            // 
            this.lblDataDisplay1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDataDisplay1.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataDisplay1.ForeColor = System.Drawing.Color.Yellow;
            this.lblDataDisplay1.Location = new System.Drawing.Point(63, 503);
            this.lblDataDisplay1.Name = "lblDataDisplay1";
            this.lblDataDisplay1.Size = new System.Drawing.Size(69, 18);
            this.lblDataDisplay1.TabIndex = 227;
            this.lblDataDisplay1.Text = "0";
            this.lblDataDisplay1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataDisplay2
            // 
            this.lblDataDisplay2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDataDisplay2.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataDisplay2.ForeColor = System.Drawing.Color.Yellow;
            this.lblDataDisplay2.Location = new System.Drawing.Point(138, 503);
            this.lblDataDisplay2.Name = "lblDataDisplay2";
            this.lblDataDisplay2.Size = new System.Drawing.Size(69, 18);
            this.lblDataDisplay2.TabIndex = 229;
            this.lblDataDisplay2.Text = "0";
            this.lblDataDisplay2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(778, 422);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 12);
            this.label27.TabIndex = 232;
            this.label27.Text = "위치2";
            // 
            // txtElAddPos2
            // 
            this.txtElAddPos2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtElAddPos2.Location = new System.Drawing.Point(767, 439);
            this.txtElAddPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtElAddPos2.Name = "txtElAddPos2";
            this.txtElAddPos2.Size = new System.Drawing.Size(60, 26);
            this.txtElAddPos2.TabIndex = 231;
            this.txtElAddPos2.Text = "0";
            this.txtElAddPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAzAddPos2
            // 
            this.txtAzAddPos2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAzAddPos2.Location = new System.Drawing.Point(767, 468);
            this.txtAzAddPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAzAddPos2.Name = "txtAzAddPos2";
            this.txtAzAddPos2.Size = new System.Drawing.Size(60, 26);
            this.txtAzAddPos2.TabIndex = 230;
            this.txtAzAddPos2.Text = "0";
            this.txtAzAddPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ListDisChkBox
            // 
            this.ListDisChkBox.AutoSize = true;
            this.ListDisChkBox.Location = new System.Drawing.Point(178, 324);
            this.ListDisChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListDisChkBox.Name = "ListDisChkBox";
            this.ListDisChkBox.Size = new System.Drawing.Size(60, 16);
            this.ListDisChkBox.TabIndex = 233;
            this.ListDisChkBox.Text = "리스트";
            this.ListDisChkBox.UseVisualStyleBackColor = true;
            this.ListDisChkBox.CheckedChanged += new System.EventHandler(this.ListDisChkBox_CheckedChanged);
            // 
            // btnAutoMove
            // 
            this.btnAutoMove.BackColor = System.Drawing.Color.Silver;
            this.btnAutoMove.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAutoMove.Location = new System.Drawing.Point(948, 407);
            this.btnAutoMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAutoMove.Name = "btnAutoMove";
            this.btnAutoMove.Size = new System.Drawing.Size(90, 24);
            this.btnAutoMove.TabIndex = 234;
            this.btnAutoMove.Text = "연속반복";
            this.btnAutoMove.UseVisualStyleBackColor = false;
            this.btnAutoMove.Click += new System.EventHandler(this.btnAutoMove_Click);
            // 
            // btnAutoMoveStop
            // 
            this.btnAutoMoveStop.BackColor = System.Drawing.Color.Silver;
            this.btnAutoMoveStop.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAutoMoveStop.Location = new System.Drawing.Point(1044, 407);
            this.btnAutoMoveStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAutoMoveStop.Name = "btnAutoMoveStop";
            this.btnAutoMoveStop.Size = new System.Drawing.Size(88, 24);
            this.btnAutoMoveStop.TabIndex = 235;
            this.btnAutoMoveStop.Text = "연속중지";
            this.btnAutoMoveStop.UseVisualStyleBackColor = false;
            this.btnAutoMoveStop.Click += new System.EventHandler(this.btnAutoMoveStop_Click);
            // 
            // txtAutoTimerVal
            // 
            this.txtAutoTimerVal.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAutoTimerVal.Location = new System.Drawing.Point(893, 409);
            this.txtAutoTimerVal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAutoTimerVal.Name = "txtAutoTimerVal";
            this.txtAutoTimerVal.Size = new System.Drawing.Size(30, 24);
            this.txtAutoTimerVal.TabIndex = 236;
            this.txtAutoTimerVal.Text = "2";
            this.txtAutoTimerVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label32.Location = new System.Drawing.Point(923, 407);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(23, 24);
            this.label32.TabIndex = 237;
            this.label32.Text = "초";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.Location = new System.Drawing.Point(294, 318);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 24);
            this.label33.TabIndex = 239;
            this.label33.Text = "hz";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessageAckTime
            // 
            this.txtMessageAckTime.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMessageAckTime.Location = new System.Drawing.Point(248, 318);
            this.txtMessageAckTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessageAckTime.Name = "txtMessageAckTime";
            this.txtMessageAckTime.Size = new System.Drawing.Size(44, 24);
            this.txtMessageAckTime.TabIndex = 238;
            this.txtMessageAckTime.Text = "10";
            this.txtMessageAckTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.Location = new System.Drawing.Point(245, 294);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(105, 24);
            this.label35.TabIndex = 240;
            this.label35.Text = "메세지응답시간";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPosOnCode
            // 
            this.txtPosOnCode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPosOnCode.Location = new System.Drawing.Point(321, 318);
            this.txtPosOnCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPosOnCode.Name = "txtPosOnCode";
            this.txtPosOnCode.Size = new System.Drawing.Size(27, 26);
            this.txtPosOnCode.TabIndex = 241;
            this.txtPosOnCode.Text = "1";
            this.txtPosOnCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPosOnCode.Visible = false;
            // 
            // btnBitTest
            // 
            this.btnBitTest.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBitTest.Location = new System.Drawing.Point(761, 36);
            this.btnBitTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBitTest.Name = "btnBitTest";
            this.btnBitTest.Size = new System.Drawing.Size(90, 23);
            this.btnBitTest.TabIndex = 242;
            this.btnBitTest.Text = "BIT-시험";
            this.btnBitTest.UseVisualStyleBackColor = true;
            this.btnBitTest.Click += new System.EventHandler(this.btnBitTest_Click);
            // 
            // btnElZeroSet
            // 
            this.btnElZeroSet.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnElZeroSet.Location = new System.Drawing.Point(479, 36);
            this.btnElZeroSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnElZeroSet.Name = "btnElZeroSet";
            this.btnElZeroSet.Size = new System.Drawing.Size(134, 23);
            this.btnElZeroSet.TabIndex = 243;
            this.btnElZeroSet.Text = "고저각 영점설정";
            this.btnElZeroSet.UseVisualStyleBackColor = true;
            this.btnElZeroSet.Click += new System.EventHandler(this.btnElZeroSet_Click);
            // 
            // btnAzZeroSet
            // 
            this.btnAzZeroSet.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAzZeroSet.Location = new System.Drawing.Point(618, 36);
            this.btnAzZeroSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAzZeroSet.Name = "btnAzZeroSet";
            this.btnAzZeroSet.Size = new System.Drawing.Size(134, 23);
            this.btnAzZeroSet.TabIndex = 244;
            this.btnAzZeroSet.Text = "방위각 영점설정";
            this.btnAzZeroSet.UseVisualStyleBackColor = true;
            this.btnAzZeroSet.Click += new System.EventHandler(this.btnAzZeroSet_Click);
            // 
            // lblDataDisplay3
            // 
            this.lblDataDisplay3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDataDisplay3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataDisplay3.ForeColor = System.Drawing.Color.Yellow;
            this.lblDataDisplay3.Location = new System.Drawing.Point(216, 503);
            this.lblDataDisplay3.Name = "lblDataDisplay3";
            this.lblDataDisplay3.Size = new System.Drawing.Size(69, 18);
            this.lblDataDisplay3.TabIndex = 245;
            this.lblDataDisplay3.Text = "0";
            this.lblDataDisplay3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Location = new System.Drawing.Point(898, 290);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(244, 84);
            this.label36.TabIndex = 246;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(1080, 294);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 11);
            this.label17.TabIndex = 257;
            this.label17.Text = "관측번호";
            // 
            // txtMultiSeqNo
            // 
            this.txtMultiSeqNo.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMultiSeqNo.Location = new System.Drawing.Point(1092, 306);
            this.txtMultiSeqNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMultiSeqNo.Name = "txtMultiSeqNo";
            this.txtMultiSeqNo.Size = new System.Drawing.Size(34, 23);
            this.txtMultiSeqNo.TabIndex = 256;
            this.txtMultiSeqNo.Text = "1";
            this.txtMultiSeqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMultiPosSend
            // 
            this.btnMultiPosSend.BackColor = System.Drawing.Color.Silver;
            this.btnMultiPosSend.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMultiPosSend.Location = new System.Drawing.Point(1084, 330);
            this.btnMultiPosSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMultiPosSend.Name = "btnMultiPosSend";
            this.btnMultiPosSend.Size = new System.Drawing.Size(52, 40);
            this.btnMultiPosSend.TabIndex = 255;
            this.btnMultiPosSend.Text = "지점이동";
            this.btnMultiPosSend.UseVisualStyleBackColor = false;
            this.btnMultiPosSend.Click += new System.EventHandler(this.btnMultiPosSend_Click);
            // 
            // ElSpeed4
            // 
            this.ElSpeed4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ElSpeed4.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElSpeed4.Location = new System.Drawing.Point(1038, 311);
            this.ElSpeed4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElSpeed4.Name = "ElSpeed4";
            this.ElSpeed4.Size = new System.Drawing.Size(42, 23);
            this.ElSpeed4.TabIndex = 254;
            this.ElSpeed4.Text = "150";
            this.ElSpeed4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElPos4
            // 
            this.ElPos4.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElPos4.Location = new System.Drawing.Point(995, 311);
            this.ElPos4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElPos4.Name = "ElPos4";
            this.ElPos4.Size = new System.Drawing.Size(38, 23);
            this.ElPos4.TabIndex = 253;
            this.ElPos4.Text = "0";
            this.ElPos4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzSpeed4
            // 
            this.AzSpeed4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AzSpeed4.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzSpeed4.Location = new System.Drawing.Point(1038, 339);
            this.AzSpeed4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzSpeed4.Name = "AzSpeed4";
            this.AzSpeed4.Size = new System.Drawing.Size(42, 23);
            this.AzSpeed4.TabIndex = 252;
            this.AzSpeed4.Text = "150";
            this.AzSpeed4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzPos4
            // 
            this.AzPos4.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzPos4.Location = new System.Drawing.Point(995, 339);
            this.AzPos4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzPos4.Name = "AzPos4";
            this.AzPos4.Size = new System.Drawing.Size(38, 23);
            this.AzPos4.TabIndex = 251;
            this.AzPos4.Text = "0";
            this.AzPos4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElSpeed3
            // 
            this.ElSpeed3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ElSpeed3.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElSpeed3.Location = new System.Drawing.Point(948, 311);
            this.ElSpeed3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElSpeed3.Name = "ElSpeed3";
            this.ElSpeed3.Size = new System.Drawing.Size(42, 23);
            this.ElSpeed3.TabIndex = 250;
            this.ElSpeed3.Text = "0";
            this.ElSpeed3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElPos3
            // 
            this.ElPos3.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ElPos3.Location = new System.Drawing.Point(907, 311);
            this.ElPos3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElPos3.Name = "ElPos3";
            this.ElPos3.Size = new System.Drawing.Size(38, 23);
            this.ElPos3.TabIndex = 249;
            this.ElPos3.Text = "0";
            this.ElPos3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzSpeed3
            // 
            this.AzSpeed3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AzSpeed3.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzSpeed3.Location = new System.Drawing.Point(948, 339);
            this.AzSpeed3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzSpeed3.Name = "AzSpeed3";
            this.AzSpeed3.Size = new System.Drawing.Size(42, 23);
            this.AzSpeed3.TabIndex = 248;
            this.AzSpeed3.Text = "150";
            this.AzSpeed3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AzPos3
            // 
            this.AzPos3.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AzPos3.Location = new System.Drawing.Point(907, 339);
            this.AzPos3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AzPos3.Name = "AzPos3";
            this.AzPos3.Size = new System.Drawing.Size(38, 23);
            this.AzPos3.TabIndex = 247;
            this.AzPos3.Text = "0";
            this.AzPos3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPosSend1
            // 
            this.btnPosSend1.BackColor = System.Drawing.Color.Silver;
            this.btnPosSend1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosSend1.Location = new System.Drawing.Point(631, 305);
            this.btnPosSend1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPosSend1.Name = "btnPosSend1";
            this.btnPosSend1.Size = new System.Drawing.Size(57, 57);
            this.btnPosSend1.TabIndex = 258;
            this.btnPosSend1.Text = "이동";
            this.btnPosSend1.UseVisualStyleBackColor = false;
            this.btnPosSend1.Click += new System.EventHandler(this.btnPosSend1_Click);
            // 
            // btnPosSend2
            // 
            this.btnPosSend2.BackColor = System.Drawing.Color.Silver;
            this.btnPosSend2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosSend2.Location = new System.Drawing.Point(822, 306);
            this.btnPosSend2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPosSend2.Name = "btnPosSend2";
            this.btnPosSend2.Size = new System.Drawing.Size(57, 57);
            this.btnPosSend2.TabIndex = 259;
            this.btnPosSend2.Text = "이동";
            this.btnPosSend2.UseVisualStyleBackColor = false;
            this.btnPosSend2.Click += new System.EventHandler(this.btnPosSend2_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(585, 292);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 12);
            this.label37.TabIndex = 261;
            this.label37.Text = "속도";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(530, 293);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 12);
            this.label38.TabIndex = 260;
            this.label38.Text = "위치";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(774, 292);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 12);
            this.label39.TabIndex = 263;
            this.label39.Text = "속도";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(724, 293);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 12);
            this.label40.TabIndex = 262;
            this.label40.Text = "위치";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(953, 294);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 12);
            this.label41.TabIndex = 265;
            this.label41.Text = "속도";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(912, 295);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 12);
            this.label42.TabIndex = 264;
            this.label42.Text = "위치";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(1040, 294);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 12);
            this.label43.TabIndex = 267;
            this.label43.Text = "속도";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(999, 295);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 12);
            this.label44.TabIndex = 266;
            this.label44.Text = "위치";
            // 
            // txtPosJoystickAdd
            // 
            this.txtPosJoystickAdd.BackColor = System.Drawing.Color.White;
            this.txtPosJoystickAdd.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPosJoystickAdd.ForeColor = System.Drawing.Color.Black;
            this.txtPosJoystickAdd.Location = new System.Drawing.Point(1106, 381);
            this.txtPosJoystickAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPosJoystickAdd.Name = "txtPosJoystickAdd";
            this.txtPosJoystickAdd.Size = new System.Drawing.Size(27, 23);
            this.txtPosJoystickAdd.TabIndex = 274;
            this.txtPosJoystickAdd.Text = "10";
            this.txtPosJoystickAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCmdElevation
            // 
            this.lblCmdElevation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblCmdElevation.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmdElevation.ForeColor = System.Drawing.Color.Blue;
            this.lblCmdElevation.Location = new System.Drawing.Point(249, 14);
            this.lblCmdElevation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCmdElevation.Name = "lblCmdElevation";
            this.lblCmdElevation.Size = new System.Drawing.Size(71, 38);
            this.lblCmdElevation.TabIndex = 276;
            this.lblCmdElevation.Text = "0";
            this.lblCmdElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCmdAzimuth
            // 
            this.lblCmdAzimuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblCmdAzimuth.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmdAzimuth.ForeColor = System.Drawing.Color.Blue;
            this.lblCmdAzimuth.Location = new System.Drawing.Point(39, 381);
            this.lblCmdAzimuth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCmdAzimuth.Name = "lblCmdAzimuth";
            this.lblCmdAzimuth.Size = new System.Drawing.Size(71, 38);
            this.lblCmdAzimuth.TabIndex = 277;
            this.lblCmdAzimuth.Text = "0";
            this.lblCmdAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChkBox_PointRepeatMove
            // 
            this.ChkBox_PointRepeatMove.AutoSize = true;
            this.ChkBox_PointRepeatMove.Location = new System.Drawing.Point(598, 403);
            this.ChkBox_PointRepeatMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBox_PointRepeatMove.Name = "ChkBox_PointRepeatMove";
            this.ChkBox_PointRepeatMove.Size = new System.Drawing.Size(112, 16);
            this.ChkBox_PointRepeatMove.TabIndex = 279;
            this.ChkBox_PointRepeatMove.Text = "포인트 반복구동";
            this.ChkBox_PointRepeatMove.UseVisualStyleBackColor = true;
            // 
            // txtTestLabel1
            // 
            this.txtTestLabel1.BackColor = System.Drawing.Color.White;
            this.txtTestLabel1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel1.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel1.Location = new System.Drawing.Point(523, 838);
            this.txtTestLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel1.Name = "txtTestLabel1";
            this.txtTestLabel1.Size = new System.Drawing.Size(53, 26);
            this.txtTestLabel1.TabIndex = 280;
            this.txtTestLabel1.Text = "9";
            this.txtTestLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel2
            // 
            this.txtTestLabel2.BackColor = System.Drawing.Color.White;
            this.txtTestLabel2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel2.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel2.Location = new System.Drawing.Point(579, 838);
            this.txtTestLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel2.Name = "txtTestLabel2";
            this.txtTestLabel2.Size = new System.Drawing.Size(60, 26);
            this.txtTestLabel2.TabIndex = 281;
            this.txtTestLabel2.Text = "0.5";
            this.txtTestLabel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel3
            // 
            this.txtTestLabel3.BackColor = System.Drawing.Color.White;
            this.txtTestLabel3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel3.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel3.Location = new System.Drawing.Point(642, 838);
            this.txtTestLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel3.Name = "txtTestLabel3";
            this.txtTestLabel3.Size = new System.Drawing.Size(61, 26);
            this.txtTestLabel3.TabIndex = 282;
            this.txtTestLabel3.Text = "0.82";
            this.txtTestLabel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel4
            // 
            this.txtTestLabel4.BackColor = System.Drawing.Color.White;
            this.txtTestLabel4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel4.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel4.Location = new System.Drawing.Point(708, 838);
            this.txtTestLabel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel4.Name = "txtTestLabel4";
            this.txtTestLabel4.Size = new System.Drawing.Size(52, 26);
            this.txtTestLabel4.TabIndex = 283;
            this.txtTestLabel4.Text = "1800";
            this.txtTestLabel4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(1062, 648);
            this.btnTest2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(20, 34);
            this.btnTest2.TabIndex = 284;
            this.btnTest2.Text = "-TEST";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // txtGrapeDataMax
            // 
            this.txtGrapeDataMax.BackColor = System.Drawing.Color.White;
            this.txtGrapeDataMax.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGrapeDataMax.ForeColor = System.Drawing.Color.Black;
            this.txtGrapeDataMax.Location = new System.Drawing.Point(1076, 553);
            this.txtGrapeDataMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGrapeDataMax.Name = "txtGrapeDataMax";
            this.txtGrapeDataMax.Size = new System.Drawing.Size(54, 26);
            this.txtGrapeDataMax.TabIndex = 285;
            this.txtGrapeDataMax.Text = "300";
            this.txtGrapeDataMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel5
            // 
            this.txtTestLabel5.BackColor = System.Drawing.Color.White;
            this.txtTestLabel5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel5.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel5.Location = new System.Drawing.Point(765, 838);
            this.txtTestLabel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel5.Name = "txtTestLabel5";
            this.txtTestLabel5.Size = new System.Drawing.Size(62, 26);
            this.txtTestLabel5.TabIndex = 286;
            this.txtTestLabel5.Text = "10";
            this.txtTestLabel5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel6
            // 
            this.txtTestLabel6.BackColor = System.Drawing.Color.White;
            this.txtTestLabel6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel6.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel6.Location = new System.Drawing.Point(835, 838);
            this.txtTestLabel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel6.Name = "txtTestLabel6";
            this.txtTestLabel6.Size = new System.Drawing.Size(56, 26);
            this.txtTestLabel6.TabIndex = 287;
            this.txtTestLabel6.Text = "0.01";
            this.txtTestLabel6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTimeDisplay
            // 
            this.lblTimeDisplay.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTimeDisplay.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeDisplay.ForeColor = System.Drawing.Color.Lime;
            this.lblTimeDisplay.Location = new System.Drawing.Point(1076, 583);
            this.lblTimeDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTimeDisplay.Name = "lblTimeDisplay";
            this.lblTimeDisplay.Size = new System.Drawing.Size(56, 24);
            this.lblTimeDisplay.TabIndex = 288;
            this.lblTimeDisplay.Text = "0";
            this.lblTimeDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel7
            // 
            this.txtTestLabel7.BackColor = System.Drawing.Color.White;
            this.txtTestLabel7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel7.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel7.Location = new System.Drawing.Point(908, 837);
            this.txtTestLabel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel7.Name = "txtTestLabel7";
            this.txtTestLabel7.Size = new System.Drawing.Size(56, 26);
            this.txtTestLabel7.TabIndex = 289;
            this.txtTestLabel7.Text = "2";
            this.txtTestLabel7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel8
            // 
            this.txtTestLabel8.BackColor = System.Drawing.Color.White;
            this.txtTestLabel8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel8.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel8.Location = new System.Drawing.Point(398, 838);
            this.txtTestLabel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel8.Name = "txtTestLabel8";
            this.txtTestLabel8.Size = new System.Drawing.Size(53, 26);
            this.txtTestLabel8.TabIndex = 290;
            this.txtTestLabel8.Text = "15";
            this.txtTestLabel8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTestLabel9
            // 
            this.txtTestLabel9.BackColor = System.Drawing.Color.White;
            this.txtTestLabel9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTestLabel9.ForeColor = System.Drawing.Color.Black;
            this.txtTestLabel9.Location = new System.Drawing.Point(460, 838);
            this.txtTestLabel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestLabel9.Name = "txtTestLabel9";
            this.txtTestLabel9.Size = new System.Drawing.Size(53, 26);
            this.txtTestLabel9.TabIndex = 291;
            this.txtTestLabel9.Text = "0.03";
            this.txtTestLabel9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label46.Location = new System.Drawing.Point(519, 866);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(61, 12);
            this.label46.TabIndex = 292;
            this.label46.Text = "De기울기";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label47.Location = new System.Drawing.Point(590, 866);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(42, 12);
            this.label47.TabIndex = 293;
            this.label47.Text = "Decel";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label48.Location = new System.Drawing.Point(646, 866);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 12);
            this.label48.TabIndex = 294;
            this.label48.Text = "전체감속";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label49.Location = new System.Drawing.Point(707, 867);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(57, 12);
            this.label49.TabIndex = 295;
            this.label49.Text = "최대속도";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label50.Location = new System.Drawing.Point(767, 867);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(57, 12);
            this.label50.TabIndex = 296;
            this.label50.Text = "시작거리";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label51.Location = new System.Drawing.Point(833, 867);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(57, 12);
            this.label51.TabIndex = 297;
            this.label51.Text = "이동단위";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label52.Location = new System.Drawing.Point(907, 867);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(57, 12);
            this.label52.TabIndex = 298;
            this.label52.Text = "목표거리";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label53.Location = new System.Drawing.Point(465, 866);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(42, 12);
            this.label53.TabIndex = 300;
            this.label53.Text = "Accel";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label54.Location = new System.Drawing.Point(405, 866);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(44, 12);
            this.label54.TabIndex = 299;
            this.label54.Text = "기울기";
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label55.ForeColor = System.Drawing.Color.Red;
            this.label55.Location = new System.Drawing.Point(480, 5);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(190, 24);
            this.label55.TabIndex = 301;
            this.label55.Text = "64000 소수점 버젼!-190410";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogDisList
            // 
            this.LogDisList.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LogDisList.Location = new System.Drawing.Point(8, 111);
            this.LogDisList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogDisList.Multiline = true;
            this.LogDisList.Name = "LogDisList";
            this.LogDisList.Size = new System.Drawing.Size(234, 207);
            this.LogDisList.TabIndex = 302;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(491, 405);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 303;
            this.label34.Text = "전송시간";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 888);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.LogDisList);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.txtTestLabel9);
            this.Controls.Add(this.txtTestLabel8);
            this.Controls.Add(this.txtTestLabel7);
            this.Controls.Add(this.lblTimeDisplay);
            this.Controls.Add(this.txtTestLabel6);
            this.Controls.Add(this.txtTestLabel5);
            this.Controls.Add(this.txtGrapeDataMax);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.txtTestLabel4);
            this.Controls.Add(this.txtTestLabel3);
            this.Controls.Add(this.txtTestLabel2);
            this.Controls.Add(this.txtTestLabel1);
            this.Controls.Add(this.ChkBox_PointRepeatMove);
            this.Controls.Add(this.lblCmdAzimuth);
            this.Controls.Add(this.lblCmdElevation);
            this.Controls.Add(this.txtPosJoystickAdd);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.btnPosSend2);
            this.Controls.Add(this.btnPosSend1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtMultiSeqNo);
            this.Controls.Add(this.btnMultiPosSend);
            this.Controls.Add(this.ElSpeed4);
            this.Controls.Add(this.ElPos4);
            this.Controls.Add(this.AzSpeed4);
            this.Controls.Add(this.AzPos4);
            this.Controls.Add(this.ElSpeed3);
            this.Controls.Add(this.ElPos3);
            this.Controls.Add(this.AzSpeed3);
            this.Controls.Add(this.AzPos3);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.lblDataDisplay3);
            this.Controls.Add(this.btnAzZeroSet);
            this.Controls.Add(this.btnElZeroSet);
            this.Controls.Add(this.btnBitTest);
            this.Controls.Add(this.txtPosOnCode);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtMessageAckTime);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.txtAutoTimerVal);
            this.Controls.Add(this.btnAutoMoveStop);
            this.Controls.Add(this.btnAutoMove);
            this.Controls.Add(this.ListDisChkBox);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtElAddPos2);
            this.Controls.Add(this.txtAzAddPos2);
            this.Controls.Add(this.lblDataDisplay2);
            this.Controls.Add(this.lblDataDisplay1);
            this.Controls.Add(this.GrapDisChkBox);
            this.Controls.Add(this.ChkBox_AutoSeekPos);
            this.Controls.Add(this.lblHzDis);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.ChkBox_AutoSinePos);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblRecvRunDis);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lblRecvDataNoDis);
            this.Controls.Add(this.ChkBox_AutoStepIncreasePos);
            this.Controls.Add(this.btnSeekStop);
            this.Controls.Add(this.btnSeekOn);
            this.Controls.Add(this.ChkBox_AutoDecreasePos);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtTimerVal);
            this.Controls.Add(this.lblTimerDis);
            this.Controls.Add(this.btnAutoStop);
            this.Controls.Add(this.btnAutoStart);
            this.Controls.Add(this.lblTimeDis);
            this.Controls.Add(this.TxDataDisChkBox);
            this.Controls.Add(this.btnDecreasePosMove);
            this.Controls.Add(this.txtAzAddStepPos);
            this.Controls.Add(this.txtElAddStepPos);
            this.Controls.Add(this.btnAddPosMove);
            this.Controls.Add(this.txtElAddPos);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtElAddSpeed);
            this.Controls.Add(this.txtAzAddSpeed);
            this.Controls.Add(this.txtAzAddPos);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ElSpeed2);
            this.Controls.Add(this.ElPos2);
            this.Controls.Add(this.AzSpeed2);
            this.Controls.Add(this.AzPos2);
            this.Controls.Add(this.ElSpeed1);
            this.Controls.Add(this.ElPos1);
            this.Controls.Add(this.AzSpeed1);
            this.Controls.Add(this.AzPos1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtOriginSpeed);
            this.Controls.Add(this.btnZeroPosMove);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSerialOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialPortBps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerialPortName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPosSingleSend);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtElSpeedData);
            this.Controls.Add(this.txtElPosData);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAzSpeedData);
            this.Controls.Add(this.txtAzPosData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAzSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtElSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblElevation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAzimuth);
            this.Controls.Add(this.ZogElDnchkBox);
            this.Controls.Add(this.ZogElUpchkBox);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDn);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btFileSave);
            this.Controls.Add(this.ZogAzRightchkBox);
            this.Controls.Add(this.ZogAzLeftchkBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClear);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "TEST";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ZogAzLeftchkBox;
        private System.Windows.Forms.CheckBox ZogAzRightchkBox;
        private System.Windows.Forms.Button btFileSave;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDn;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.CheckBox ZogElUpchkBox;
        private System.Windows.Forms.CheckBox ZogElDnchkBox;
        private System.Windows.Forms.TextBox lblAzimuth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lblElevation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtElSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAzSpeed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPosSingleSend;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtElSpeedData;
        private System.Windows.Forms.TextBox txtElPosData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAzSpeedData;
        private System.Windows.Forms.TextBox txtAzPosData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSerialOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerialPortBps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerialPortName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtOriginSpeed;
        private System.Windows.Forms.Button btnZeroPosMove;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox ElSpeed2;
        private System.Windows.Forms.TextBox ElPos2;
        private System.Windows.Forms.TextBox AzSpeed2;
        private System.Windows.Forms.TextBox AzPos2;
        private System.Windows.Forms.TextBox ElSpeed1;
        private System.Windows.Forms.TextBox ElPos1;
        private System.Windows.Forms.TextBox AzSpeed1;
        private System.Windows.Forms.TextBox AzPos1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnAddPosMove;
        private System.Windows.Forms.TextBox txtElAddPos;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtElAddSpeed;
        private System.Windows.Forms.TextBox txtAzAddSpeed;
        private System.Windows.Forms.TextBox txtAzAddPos;
        private System.Windows.Forms.TextBox txtElAddStepPos;
        private System.Windows.Forms.TextBox txtAzAddStepPos;
        private System.Windows.Forms.Button btnDecreasePosMove;
        private System.Windows.Forms.CheckBox TxDataDisChkBox;
        private System.Windows.Forms.Label lblTimeDis;

        private Multimedia.Timer mmTimer;
        private System.Windows.Forms.Label lblTimerDis;
        private System.Windows.Forms.Button btnAutoStop;
        private System.Windows.Forms.Button btnAutoStart;
        private System.Windows.Forms.TextBox txtTimerVal;
        private System.Windows.Forms.CheckBox ChkBox_AutoDecreasePos;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnSeekStop;
        private System.Windows.Forms.Button btnSeekOn;
        private System.Windows.Forms.CheckBox ChkBox_AutoStepIncreasePos;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox lblRecvDataNoDis;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox lblRecvRunDis;
        private System.Windows.Forms.CheckBox ChkBox_AutoSinePos;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblHzDis;
        private System.Windows.Forms.CheckBox ChkBox_AutoSeekPos;
        private System.Windows.Forms.CheckBox GrapDisChkBox;
        private System.Windows.Forms.Label lblDataDisplay2;
        private System.Windows.Forms.Label lblDataDisplay1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtElAddPos2;
        private System.Windows.Forms.TextBox txtAzAddPos2;
        private System.Windows.Forms.CheckBox ListDisChkBox;
        private System.Windows.Forms.Button btnAutoMove;
        private System.Windows.Forms.Button btnAutoMoveStop;
        private System.Windows.Forms.TextBox txtAutoTimerVal;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtMessageAckTime;
        private System.Windows.Forms.TextBox txtPosOnCode;
        private System.Windows.Forms.Button btnBitTest;
        private System.Windows.Forms.Button btnAzZeroSet;
        private System.Windows.Forms.Button btnElZeroSet;
        private System.Windows.Forms.Label lblDataDisplay3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMultiSeqNo;
        private System.Windows.Forms.Button btnMultiPosSend;
        private System.Windows.Forms.TextBox ElSpeed4;
        private System.Windows.Forms.TextBox ElPos4;
        private System.Windows.Forms.TextBox AzSpeed4;
        private System.Windows.Forms.TextBox AzPos4;
        private System.Windows.Forms.TextBox ElSpeed3;
        private System.Windows.Forms.TextBox ElPos3;
        private System.Windows.Forms.TextBox AzSpeed3;
        private System.Windows.Forms.TextBox AzPos3;
        private System.Windows.Forms.Button btnPosSend2;
        private System.Windows.Forms.Button btnPosSend1;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtPosJoystickAdd;
        private System.Windows.Forms.TextBox lblCmdAzimuth;
        private System.Windows.Forms.TextBox lblCmdElevation;
        private System.Windows.Forms.CheckBox ChkBox_PointRepeatMove;
        private System.Windows.Forms.TextBox txtTestLabel4;
        private System.Windows.Forms.TextBox txtTestLabel3;
        private System.Windows.Forms.TextBox txtTestLabel2;
        private System.Windows.Forms.TextBox txtTestLabel1;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.TextBox txtGrapeDataMax;
        private System.Windows.Forms.TextBox txtTestLabel5;
        private System.Windows.Forms.TextBox txtTestLabel6;
        private System.Windows.Forms.TextBox lblTimeDisplay;
        private System.Windows.Forms.TextBox txtTestLabel7;
        private System.Windows.Forms.TextBox txtTestLabel8;
        private System.Windows.Forms.TextBox txtTestLabel9;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox LogDisList;
        private System.Windows.Forms.Label label34;
    }
}

