
namespace Clock
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
            this.ㅅ = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TimerResetButton = new System.Windows.Forms.Button();
            this.TimerStartStopButton = new System.Windows.Forms.Button();
            this.TimerSS = new System.Windows.Forms.TextBox();
            this.TimerMM = new System.Windows.Forms.TextBox();
            this.TimerHH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SWMMSS = new System.Windows.Forms.TextBox();
            this.SWresetButton = new System.Windows.Forms.Button();
            this.SWstartbutton = new System.Windows.Forms.Button();
            this.SWSS = new System.Windows.Forms.TextBox();
            this.SWMM = new System.Windows.Forms.TextBox();
            this.SWHH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TimerTimer = new System.Windows.Forms.Timer(this.components);
            this.SWtimer = new System.Windows.Forms.Timer(this.components);
            this.armMM = new System.Windows.Forms.TextBox();
            this.armHH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.armStartbutton = new System.Windows.Forms.Button();
            this.OjunorOhu = new System.Windows.Forms.Button();
            this.armTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ㅅ.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ㅅ
            // 
            this.ㅅ.Controls.Add(this.tabPage1);
            this.ㅅ.Controls.Add(this.tabPage2);
            this.ㅅ.Controls.Add(this.tabPage3);
            this.ㅅ.Controls.Add(this.tabPage4);
            this.ㅅ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ㅅ.Location = new System.Drawing.Point(0, 0);
            this.ㅅ.Name = "ㅅ";
            this.ㅅ.SelectedIndex = 0;
            this.ㅅ.Size = new System.Drawing.Size(800, 450);
            this.ㅅ.TabIndex = 0;
            this.ㅅ.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TimerResetButton);
            this.tabPage1.Controls.Add(this.TimerStartStopButton);
            this.tabPage1.Controls.Add(this.TimerSS);
            this.tabPage1.Controls.Add(this.TimerMM);
            this.tabPage1.Controls.Add(this.TimerHH);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "타이머";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TimerResetButton
            // 
            this.TimerResetButton.AutoSize = true;
            this.TimerResetButton.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TimerResetButton.Location = new System.Drawing.Point(390, 236);
            this.TimerResetButton.Name = "TimerResetButton";
            this.TimerResetButton.Size = new System.Drawing.Size(83, 40);
            this.TimerResetButton.TabIndex = 4;
            this.TimerResetButton.Text = "리셋";
            this.TimerResetButton.UseVisualStyleBackColor = true;
            this.TimerResetButton.Click += new System.EventHandler(this.TimerResetButton_Click);
            // 
            // TimerStartStopButton
            // 
            this.TimerStartStopButton.AutoSize = true;
            this.TimerStartStopButton.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TimerStartStopButton.Location = new System.Drawing.Point(287, 236);
            this.TimerStartStopButton.Name = "TimerStartStopButton";
            this.TimerStartStopButton.Size = new System.Drawing.Size(83, 40);
            this.TimerStartStopButton.TabIndex = 3;
            this.TimerStartStopButton.Text = "시작";
            this.TimerStartStopButton.UseVisualStyleBackColor = true;
            this.TimerStartStopButton.Click += new System.EventHandler(this.TimerStartStopButton_Click);
            // 
            // TimerSS
            // 
            this.TimerSS.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TimerSS.Location = new System.Drawing.Point(440, 110);
            this.TimerSS.MaxLength = 2;
            this.TimerSS.Multiline = true;
            this.TimerSS.Name = "TimerSS";
            this.TimerSS.Size = new System.Drawing.Size(61, 52);
            this.TimerSS.TabIndex = 2;
            this.TimerSS.Text = "0";
            // 
            // TimerMM
            // 
            this.TimerMM.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TimerMM.Location = new System.Drawing.Point(347, 110);
            this.TimerMM.MaxLength = 2;
            this.TimerMM.Multiline = true;
            this.TimerMM.Name = "TimerMM";
            this.TimerMM.Size = new System.Drawing.Size(61, 52);
            this.TimerMM.TabIndex = 1;
            this.TimerMM.Text = "0";
            // 
            // TimerHH
            // 
            this.TimerHH.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TimerHH.Location = new System.Drawing.Point(253, 110);
            this.TimerHH.MaxLength = 2;
            this.TimerHH.Multiline = true;
            this.TimerHH.Name = "TimerHH";
            this.TimerHH.Size = new System.Drawing.Size(61, 52);
            this.TimerHH.TabIndex = 0;
            this.TimerHH.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(315, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(409, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 43);
            this.label2.TabIndex = 5;
            this.label2.Text = ":";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SWMMSS);
            this.tabPage2.Controls.Add(this.SWresetButton);
            this.tabPage2.Controls.Add(this.SWstartbutton);
            this.tabPage2.Controls.Add(this.SWSS);
            this.tabPage2.Controls.Add(this.SWMM);
            this.tabPage2.Controls.Add(this.SWHH);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "스톱워치";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SWMMSS
            // 
            this.SWMMSS.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWMMSS.Location = new System.Drawing.Point(504, 127);
            this.SWMMSS.MaxLength = 2;
            this.SWMMSS.Multiline = true;
            this.SWMMSS.Name = "SWMMSS";
            this.SWMMSS.Size = new System.Drawing.Size(61, 52);
            this.SWMMSS.TabIndex = 13;
            this.SWMMSS.TabStop = false;
            this.SWMMSS.Text = "0";
            // 
            // SWresetButton
            // 
            this.SWresetButton.AutoSize = true;
            this.SWresetButton.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWresetButton.Location = new System.Drawing.Point(409, 253);
            this.SWresetButton.Name = "SWresetButton";
            this.SWresetButton.Size = new System.Drawing.Size(83, 40);
            this.SWresetButton.TabIndex = 11;
            this.SWresetButton.Text = "리셋";
            this.SWresetButton.UseVisualStyleBackColor = true;
            this.SWresetButton.Click += new System.EventHandler(this.SWresetButton_Click);
            // 
            // SWstartbutton
            // 
            this.SWstartbutton.AutoSize = true;
            this.SWstartbutton.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWstartbutton.Location = new System.Drawing.Point(306, 253);
            this.SWstartbutton.Name = "SWstartbutton";
            this.SWstartbutton.Size = new System.Drawing.Size(83, 40);
            this.SWstartbutton.TabIndex = 10;
            this.SWstartbutton.Text = "시작";
            this.SWstartbutton.UseVisualStyleBackColor = true;
            this.SWstartbutton.Click += new System.EventHandler(this.SWstartbutton_Click);
            // 
            // SWSS
            // 
            this.SWSS.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWSS.Location = new System.Drawing.Point(416, 127);
            this.SWSS.MaxLength = 2;
            this.SWSS.Multiline = true;
            this.SWSS.Name = "SWSS";
            this.SWSS.Size = new System.Drawing.Size(61, 52);
            this.SWSS.TabIndex = 9;
            this.SWSS.TabStop = false;
            this.SWSS.Text = "0";
            // 
            // SWMM
            // 
            this.SWMM.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWMM.Location = new System.Drawing.Point(323, 127);
            this.SWMM.MaxLength = 2;
            this.SWMM.Multiline = true;
            this.SWMM.Name = "SWMM";
            this.SWMM.Size = new System.Drawing.Size(61, 52);
            this.SWMM.TabIndex = 7;
            this.SWMM.TabStop = false;
            this.SWMM.Text = "0";
            // 
            // SWHH
            // 
            this.SWHH.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWHH.Location = new System.Drawing.Point(229, 127);
            this.SWHH.MaxLength = 2;
            this.SWHH.Multiline = true;
            this.SWHH.Name = "SWHH";
            this.SWHH.Size = new System.Drawing.Size(61, 52);
            this.SWHH.TabIndex = 6;
            this.SWHH.TabStop = false;
            this.SWHH.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(291, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 43);
            this.label3.TabIndex = 8;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(385, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 43);
            this.label4.TabIndex = 12;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(474, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 43);
            this.label5.TabIndex = 14;
            this.label5.Text = ".";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.OjunorOhu);
            this.tabPage3.Controls.Add(this.armStartbutton);
            this.tabPage3.Controls.Add(this.armMM);
            this.tabPage3.Controls.Add(this.armHH);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "알람";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TimerTimer
            // 
            this.TimerTimer.Interval = 1;
            this.TimerTimer.Tick += new System.EventHandler(this.TimerTimer_Tick);
            // 
            // SWtimer
            // 
            this.SWtimer.Interval = 1;
            this.SWtimer.Tick += new System.EventHandler(this.SWtimer_Tick);
            // 
            // armMM
            // 
            this.armMM.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.armMM.Location = new System.Drawing.Point(444, 138);
            this.armMM.MaxLength = 2;
            this.armMM.Multiline = true;
            this.armMM.Name = "armMM";
            this.armMM.Size = new System.Drawing.Size(61, 52);
            this.armMM.TabIndex = 2;
            this.armMM.Text = "0";
            // 
            // armHH
            // 
            this.armHH.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.armHH.Location = new System.Drawing.Point(350, 138);
            this.armHH.MaxLength = 2;
            this.armHH.Multiline = true;
            this.armHH.Name = "armHH";
            this.armHH.Size = new System.Drawing.Size(61, 52);
            this.armHH.TabIndex = 1;
            this.armHH.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(412, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 43);
            this.label6.TabIndex = 8;
            this.label6.Text = ":";
            // 
            // armStartbutton
            // 
            this.armStartbutton.AutoSize = true;
            this.armStartbutton.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.armStartbutton.Location = new System.Drawing.Point(363, 259);
            this.armStartbutton.Name = "armStartbutton";
            this.armStartbutton.Size = new System.Drawing.Size(83, 40);
            this.armStartbutton.TabIndex = 3;
            this.armStartbutton.Text = "시작";
            this.armStartbutton.UseVisualStyleBackColor = true;
            this.armStartbutton.Click += new System.EventHandler(this.armStartbutton_Click);
            // 
            // OjunorOhu
            // 
            this.OjunorOhu.AutoSize = true;
            this.OjunorOhu.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OjunorOhu.Location = new System.Drawing.Point(252, 147);
            this.OjunorOhu.Name = "OjunorOhu";
            this.OjunorOhu.Size = new System.Drawing.Size(83, 40);
            this.OjunorOhu.TabIndex = 0;
            this.OjunorOhu.Text = "오전";
            this.OjunorOhu.UseVisualStyleBackColor = true;
            this.OjunorOhu.Click += new System.EventHandler(this.OjunorOhu_Click);
            // 
            // armTimer
            // 
            this.armTimer.Tick += new System.EventHandler(this.armTimer_Tick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 421);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "사진";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(284, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 212);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(549, 112);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ㅅ);
            this.Name = "Form1";
            this.Text = "알람 및 시계";
            this.ㅅ.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ㅅ;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TimerHH;
        private System.Windows.Forms.TextBox TimerSS;
        private System.Windows.Forms.TextBox TimerMM;
        private System.Windows.Forms.Button TimerStartStopButton;
        private System.Windows.Forms.Button TimerResetButton;
        private System.Windows.Forms.Timer TimerTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SWresetButton;
        private System.Windows.Forms.Button SWstartbutton;
        private System.Windows.Forms.TextBox SWSS;
        private System.Windows.Forms.TextBox SWMM;
        private System.Windows.Forms.TextBox SWHH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer SWtimer;
        private System.Windows.Forms.TextBox SWMMSS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox armMM;
        private System.Windows.Forms.TextBox armHH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button armStartbutton;
        private System.Windows.Forms.Button OjunorOhu;
        private System.Windows.Forms.Timer armTimer;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

