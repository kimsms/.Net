
namespace AutoMouse
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.mode1 = new System.Windows.Forms.Button();
            this.mode2 = new System.Windows.Forms.Button();
            this.mode3 = new System.Windows.Forms.Button();
            this.mode4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.modelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "닫기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mode1
            // 
            this.mode1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mode1.AutoSize = true;
            this.mode1.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mode1.Location = new System.Drawing.Point(55, 181);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(117, 29);
            this.mode1.TabIndex = 1;
            this.mode1.Text = "MoveButton";
            this.mode1.UseVisualStyleBackColor = true;
            this.mode1.Click += new System.EventHandler(this.mode1_Click);
            // 
            // mode2
            // 
            this.mode2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mode2.AutoSize = true;
            this.mode2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mode2.Location = new System.Drawing.Point(300, 181);
            this.mode2.Name = "mode2";
            this.mode2.Size = new System.Drawing.Size(121, 29);
            this.mode2.TabIndex = 2;
            this.mode2.Text = "MoveMouse";
            this.mode2.UseVisualStyleBackColor = true;
            this.mode2.Click += new System.EventHandler(this.mode2_Click);
            // 
            // mode3
            // 
            this.mode3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mode3.AutoSize = true;
            this.mode3.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mode3.Location = new System.Drawing.Point(55, 253);
            this.mode3.Name = "mode3";
            this.mode3.Size = new System.Drawing.Size(140, 29);
            this.mode3.TabIndex = 3;
            this.mode3.Text = "Hardmode";
            this.mode3.UseVisualStyleBackColor = true;
            this.mode3.Click += new System.EventHandler(this.mode3_Click);
            // 
            // mode4
            // 
            this.mode4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mode4.AutoSize = true;
            this.mode4.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mode4.Location = new System.Drawing.Point(281, 253);
            this.mode4.Name = "mode4";
            this.mode4.Size = new System.Drawing.Size(140, 29);
            this.mode4.TabIndex = 4;
            this.mode4.Text = "S_Hardmode";
            this.mode4.UseVisualStyleBackColor = true;
            this.mode4.Click += new System.EventHandler(this.mode4_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(366, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "하드모드";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(108, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "중도포기는 Ctrl + Shift + S";
            // 
            // modelabel
            // 
            this.modelabel.AutoSize = true;
            this.modelabel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modelabel.Location = new System.Drawing.Point(196, 42);
            this.modelabel.Name = "modelabel";
            this.modelabel.Size = new System.Drawing.Size(93, 20);
            this.modelabel.TabIndex = 7;
            this.modelabel.Text = "하드모드";
            this.modelabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.mode4);
            this.Controls.Add(this.mode3);
            this.Controls.Add(this.mode2);
            this.Controls.Add(this.mode1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelabel);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(500, 500);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AimMaster_V2";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mode1;
        private System.Windows.Forms.Button mode2;
        private System.Windows.Forms.Button mode3;
        private System.Windows.Forms.Button mode4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label modelabel;
    }
}

