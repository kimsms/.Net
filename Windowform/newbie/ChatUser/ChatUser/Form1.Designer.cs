
namespace ChatUser
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.nickname = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.testbutton = new System.Windows.Forms.Button();
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Mention1 = new System.Windows.Forms.Button();
            this.Mention2 = new System.Windows.Forms.Button();
            this.Mention3 = new System.Windows.Forms.Button();
            this.Mention4 = new System.Windows.Forms.Button();
            this.codeRed = new System.Windows.Forms.Button();
            this.Mention7 = new System.Windows.Forms.Button();
            this.Mention6 = new System.Windows.Forms.Button();
            this.Mention5 = new System.Windows.Forms.Button();
            this.MentionTimer = new System.Windows.Forms.Timer(this.components);
            this.MentionLabel = new System.Windows.Forms.Label();
            this.Mention8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nickname
            // 
            this.nickname.AutoSize = true;
            this.nickname.Location = new System.Drawing.Point(36, 32);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(47, 15);
            this.nickname.TabIndex = 0;
            this.nickname.Text = "이름 :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox1.Location = new System.Drawing.Point(230, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(436, 237);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSend.Location = new System.Drawing.Point(348, 376);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(180, 65);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.BackColor = System.Drawing.Color.White;
            this.textBoxNickName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.textBoxNickName.Location = new System.Drawing.Point(95, 29);
            this.textBoxNickName.MaxLength = 3;
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(100, 25);
            this.textBoxNickName.TabIndex = 0;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.Color.White;
            this.textBoxMessage.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMessage.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.textBoxMessage.Location = new System.Drawing.Point(230, 255);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMessage.Size = new System.Drawing.Size(436, 110);
            this.textBoxMessage.TabIndex = 4;
            this.textBoxMessage.TabStop = false;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(105, 157);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 25);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(95, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "192.168.0.78";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(95, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "주소 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "포트 :";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(549, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 65);
            this.button2.TabIndex = 12;
            this.button2.TabStop = false;
            this.button2.Text = "복호화";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(672, 112);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 19);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "메세지 암호화";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(672, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 19);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "DarkMode";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox2.Location = new System.Drawing.Point(230, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(436, 237);
            this.richTextBox2.TabIndex = 16;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(95, 122);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "암호 :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-10, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(811, 450);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(672, 87);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(129, 19);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "채팅 고정 해제";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(672, 37);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(96, 19);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.TabStop = false;
            this.checkBox4.Text = "HardMode";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 2000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer6
            // 
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(105, 201);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(75, 25);
            this.testbutton.TabIndex = 25;
            this.testbutton.TabStop = false;
            this.testbutton.Text = "test";
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Visible = false;
            this.testbutton.Click += new System.EventHandler(this.testbutton_Click);
            // 
            // timer7
            // 
            this.timer7.Interval = 1500;
            this.timer7.Tick += new System.EventHandler(this.timer7_Tick);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(672, 62);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(94, 19);
            this.checkBox5.TabIndex = 26;
            this.checkBox5.TabStop = false;
            this.checkBox5.Text = "알림 받기";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ChatUser.exe";
            // 
            // Mention1
            // 
            this.Mention1.Location = new System.Drawing.Point(12, 275);
            this.Mention1.Name = "Mention1";
            this.Mention1.Size = new System.Drawing.Size(75, 25);
            this.Mention1.TabIndex = 27;
            this.Mention1.TabStop = false;
            this.Mention1.Text = "구승현";
            this.Mention1.UseVisualStyleBackColor = true;
            this.Mention1.Click += new System.EventHandler(this.Mention1_Click);
            // 
            // Mention2
            // 
            this.Mention2.Location = new System.Drawing.Point(105, 275);
            this.Mention2.Name = "Mention2";
            this.Mention2.Size = new System.Drawing.Size(75, 25);
            this.Mention2.TabIndex = 28;
            this.Mention2.TabStop = false;
            this.Mention2.Text = "김성민";
            this.Mention2.UseVisualStyleBackColor = true;
            this.Mention2.Click += new System.EventHandler(this.Mention2_Click);
            // 
            // Mention3
            // 
            this.Mention3.Location = new System.Drawing.Point(12, 306);
            this.Mention3.Name = "Mention3";
            this.Mention3.Size = new System.Drawing.Size(75, 25);
            this.Mention3.TabIndex = 29;
            this.Mention3.TabStop = false;
            this.Mention3.Text = "김찬희";
            this.Mention3.UseVisualStyleBackColor = true;
            this.Mention3.Click += new System.EventHandler(this.Mention3_Click);
            // 
            // Mention4
            // 
            this.Mention4.Location = new System.Drawing.Point(105, 306);
            this.Mention4.Name = "Mention4";
            this.Mention4.Size = new System.Drawing.Size(75, 25);
            this.Mention4.TabIndex = 30;
            this.Mention4.TabStop = false;
            this.Mention4.Text = "박동유";
            this.Mention4.UseVisualStyleBackColor = true;
            this.Mention4.Click += new System.EventHandler(this.Mention4_Click);
            // 
            // codeRed
            // 
            this.codeRed.Location = new System.Drawing.Point(62, 416);
            this.codeRed.Name = "codeRed";
            this.codeRed.Size = new System.Drawing.Size(75, 25);
            this.codeRed.TabIndex = 34;
            this.codeRed.TabStop = false;
            this.codeRed.Text = "긴급";
            this.codeRed.UseVisualStyleBackColor = true;
            this.codeRed.Click += new System.EventHandler(this.codeRed_Click);
            // 
            // Mention7
            // 
            this.Mention7.Location = new System.Drawing.Point(12, 371);
            this.Mention7.Name = "Mention7";
            this.Mention7.Size = new System.Drawing.Size(75, 25);
            this.Mention7.TabIndex = 33;
            this.Mention7.TabStop = false;
            this.Mention7.Text = "이준영";
            this.Mention7.UseVisualStyleBackColor = true;
            this.Mention7.Click += new System.EventHandler(this.Mention7_Click);
            // 
            // Mention6
            // 
            this.Mention6.Location = new System.Drawing.Point(105, 340);
            this.Mention6.Name = "Mention6";
            this.Mention6.Size = new System.Drawing.Size(75, 25);
            this.Mention6.TabIndex = 32;
            this.Mention6.TabStop = false;
            this.Mention6.Text = "양희수";
            this.Mention6.UseVisualStyleBackColor = true;
            this.Mention6.Click += new System.EventHandler(this.Mention6_Click);
            // 
            // Mention5
            // 
            this.Mention5.Location = new System.Drawing.Point(12, 340);
            this.Mention5.Name = "Mention5";
            this.Mention5.Size = new System.Drawing.Size(75, 25);
            this.Mention5.TabIndex = 31;
            this.Mention5.TabStop = false;
            this.Mention5.Text = "박우빈";
            this.Mention5.UseVisualStyleBackColor = true;
            this.Mention5.Click += new System.EventHandler(this.Mention5_Click);
            // 
            // MentionTimer
            // 
            this.MentionTimer.Interval = 1000;
            this.MentionTimer.Tick += new System.EventHandler(this.MentionTimer_Tick);
            // 
            // MentionLabel
            // 
            this.MentionLabel.AutoSize = true;
            this.MentionLabel.Location = new System.Drawing.Point(77, 255);
            this.MentionLabel.Name = "MentionLabel";
            this.MentionLabel.Size = new System.Drawing.Size(37, 15);
            this.MentionLabel.TabIndex = 35;
            this.MentionLabel.Text = "멘션";
            // 
            // Mention8
            // 
            this.Mention8.Location = new System.Drawing.Point(105, 371);
            this.Mention8.Name = "Mention8";
            this.Mention8.Size = new System.Drawing.Size(75, 25);
            this.Mention8.TabIndex = 36;
            this.Mention8.TabStop = false;
            this.Mention8.Text = "모두";
            this.Mention8.UseVisualStyleBackColor = true;
            this.Mention8.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Mention8);
            this.Controls.Add(this.MentionLabel);
            this.Controls.Add(this.codeRed);
            this.Controls.Add(this.Mention7);
            this.Controls.Add(this.Mention6);
            this.Controls.Add(this.Mention5);
            this.Controls.Add(this.Mention4);
            this.Controls.Add(this.Mention3);
            this.Controls.Add(this.Mention2);
            this.Controls.Add(this.Mention1);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.testbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxNickName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 500);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nickname;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBoxNickName;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Button testbutton;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Mention1;
        private System.Windows.Forms.Button Mention2;
        private System.Windows.Forms.Button Mention3;
        private System.Windows.Forms.Button Mention4;
        private System.Windows.Forms.Button codeRed;
        private System.Windows.Forms.Button Mention7;
        private System.Windows.Forms.Button Mention6;
        private System.Windows.Forms.Button Mention5;
        private System.Windows.Forms.Timer MentionTimer;
        private System.Windows.Forms.Label MentionLabel;
        private System.Windows.Forms.Button Mention8;
    }
}

