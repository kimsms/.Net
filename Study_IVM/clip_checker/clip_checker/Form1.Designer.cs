﻿namespace clip_checker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainPicturebox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicturebox
            // 
            this.mainPicturebox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("mainPicturebox.Image")));
            this.mainPicturebox.Location = new System.Drawing.Point(0, 0);
            this.mainPicturebox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPicturebox.Name = "mainPicturebox";
            this.mainPicturebox.Size = new System.Drawing.Size(525, 480);
            this.mainPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPicturebox.TabIndex = 0;
            this.mainPicturebox.TabStop = false;
            this.mainPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPicturebox_Paint);
            this.mainPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPicturebox_MouseDown);
            this.mainPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPicturebox_MouseMove);
            this.mainPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPicturebox_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "picturebox 기준";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(590, 54);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(525, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "이미지 기준";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "picturebox 가로길이";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1139, 122);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "검사";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.mainPicturebox);
            this.panel1.Location = new System.Drawing.Point(44, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 480);
            this.panel1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(1220, 122);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "라이브\r\n검사";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1298, 54);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 39);
            this.button3.TabIndex = 9;
            this.button3.Text = "이미지 변경";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1139, 54);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 39);
            this.button4.TabIndex = 10;
            this.button4.Text = "결과\r\nn번 저장";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1220, 54);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 39);
            this.button5.TabIndex = 11;
            this.button5.Text = "저장위치";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1139, 221);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 21);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "150";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1186, 221);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 21);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "40";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1139, 246);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 21);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "100";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1186, 246);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 21);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "50";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1139, 270);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(42, 21);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "200";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1298, 122);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 39);
            this.button6.TabIndex = 17;
            this.button6.Text = "각도\r\n확인";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1298, 324);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(42, 21);
            this.textBox6.TabIndex = 18;
            this.textBox6.Text = "270";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(1298, 362);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(42, 21);
            this.textBox7.TabIndex = 19;
            this.textBox7.Text = "390";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1128, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "위쪽 선 길이 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1128, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "아래 선 길이 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(1232, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(1232, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(1298, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "기준";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1298, 270);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(42, 21);
            this.textBox8.TabIndex = 25;
            this.textBox8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(1256, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "회전";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1139, 30);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            248248248,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 21);
            this.numericUpDown1.TabIndex = 27;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1137, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "머지렉";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(1276, 221);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(64, 21);
            this.numericUpDown2.TabIndex = 29;
            this.numericUpDown2.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(1267, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 14);
            this.label11.TabIndex = 30;
            this.label11.Text = "Threashold";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(1128, 396);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 14);
            this.label12.TabIndex = 31;
            this.label12.Text = "대각선  길이 :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(1232, 396);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 14);
            this.label13.TabIndex = 32;
            this.label13.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1384, 762);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPicturebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

