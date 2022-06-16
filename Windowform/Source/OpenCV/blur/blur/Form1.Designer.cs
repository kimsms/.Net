namespace blur
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.RollBackBtn = new System.Windows.Forms.Button();
            this.ThresholdBtn = new System.Windows.Forms.Button();
            this.ThresholdValue = new System.Windows.Forms.NumericUpDown();
            this.GaussianBlurBtn = new System.Windows.Forms.Button();
            this.BilateralFilterBtn = new System.Windows.Forms.Button();
            this.SharpenBtn = new System.Windows.Forms.Button();
            this.SharpenModListbox = new System.Windows.Forms.ComboBox();
            this.CvtImageChannelCheckbox = new System.Windows.Forms.CheckBox();
            this.ImageChannelLabel = new System.Windows.Forms.Label();
            this.ApplyImmediatelyCheckBtn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(34, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 385);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "이미지 채널 :";
            // 
            // LoadBtn
            // 
            this.LoadBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoadBtn.Location = new System.Drawing.Point(541, 58);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(76, 90);
            this.LoadBtn.TabIndex = 14;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SaveBtn.Location = new System.Drawing.Point(621, 58);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(76, 90);
            this.SaveBtn.TabIndex = 15;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // RollBackBtn
            // 
            this.RollBackBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RollBackBtn.Location = new System.Drawing.Point(781, 58);
            this.RollBackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RollBackBtn.Name = "RollBackBtn";
            this.RollBackBtn.Size = new System.Drawing.Size(109, 90);
            this.RollBackBtn.TabIndex = 16;
            this.RollBackBtn.Text = "RollBack";
            this.RollBackBtn.UseVisualStyleBackColor = true;
            this.RollBackBtn.Click += new System.EventHandler(this.RollBackBtn_Click);
            // 
            // ThresholdBtn
            // 
            this.ThresholdBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ThresholdBtn.Location = new System.Drawing.Point(781, 194);
            this.ThresholdBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ThresholdBtn.Name = "ThresholdBtn";
            this.ThresholdBtn.Size = new System.Drawing.Size(109, 90);
            this.ThresholdBtn.TabIndex = 17;
            this.ThresholdBtn.Text = "Threshold";
            this.ThresholdBtn.UseVisualStyleBackColor = true;
            this.ThresholdBtn.Click += new System.EventHandler(this.ThresholdBtn_Click);
            // 
            // ThresholdValue
            // 
            this.ThresholdValue.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ThresholdValue.Location = new System.Drawing.Point(681, 217);
            this.ThresholdValue.Margin = new System.Windows.Forms.Padding(2);
            this.ThresholdValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ThresholdValue.Name = "ThresholdValue";
            this.ThresholdValue.Size = new System.Drawing.Size(96, 30);
            this.ThresholdValue.TabIndex = 18;
            // 
            // GaussianBlurBtn
            // 
            this.GaussianBlurBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GaussianBlurBtn.Location = new System.Drawing.Point(463, 370);
            this.GaussianBlurBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GaussianBlurBtn.Name = "GaussianBlurBtn";
            this.GaussianBlurBtn.Size = new System.Drawing.Size(139, 90);
            this.GaussianBlurBtn.TabIndex = 19;
            this.GaussianBlurBtn.Text = "GaussianBlur";
            this.GaussianBlurBtn.UseVisualStyleBackColor = true;
            this.GaussianBlurBtn.Click += new System.EventHandler(this.GaussianBlurBtn_Click);
            // 
            // BilateralFilterBtn
            // 
            this.BilateralFilterBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BilateralFilterBtn.Location = new System.Drawing.Point(606, 370);
            this.BilateralFilterBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BilateralFilterBtn.Name = "BilateralFilterBtn";
            this.BilateralFilterBtn.Size = new System.Drawing.Size(139, 90);
            this.BilateralFilterBtn.TabIndex = 20;
            this.BilateralFilterBtn.Text = "BilateralFilter";
            this.BilateralFilterBtn.UseVisualStyleBackColor = true;
            this.BilateralFilterBtn.Click += new System.EventHandler(this.BilateralFilterBtn_Click);
            // 
            // SharpenBtn
            // 
            this.SharpenBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SharpenBtn.Location = new System.Drawing.Point(751, 370);
            this.SharpenBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SharpenBtn.Name = "SharpenBtn";
            this.SharpenBtn.Size = new System.Drawing.Size(139, 90);
            this.SharpenBtn.TabIndex = 21;
            this.SharpenBtn.Text = "Sharpen";
            this.SharpenBtn.UseVisualStyleBackColor = true;
            this.SharpenBtn.Click += new System.EventHandler(this.SharpenBtn_Click);
            // 
            // SharpenModListbox
            // 
            this.SharpenModListbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SharpenModListbox.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SharpenModListbox.FormattingEnabled = true;
            this.SharpenModListbox.Items.AddRange(new object[] {
            "mask1",
            "mask2",
            "mask3"});
            this.SharpenModListbox.Location = new System.Drawing.Point(751, 340);
            this.SharpenModListbox.Margin = new System.Windows.Forms.Padding(2);
            this.SharpenModListbox.Name = "SharpenModListbox";
            this.SharpenModListbox.Size = new System.Drawing.Size(140, 26);
            this.SharpenModListbox.TabIndex = 22;
            // 
            // CvtImageChannelCheckbox
            // 
            this.CvtImageChannelCheckbox.AutoSize = true;
            this.CvtImageChannelCheckbox.Location = new System.Drawing.Point(541, 35);
            this.CvtImageChannelCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.CvtImageChannelCheckbox.Name = "CvtImageChannelCheckbox";
            this.CvtImageChannelCheckbox.Size = new System.Drawing.Size(144, 19);
            this.CvtImageChannelCheckbox.TabIndex = 23;
            this.CvtImageChannelCheckbox.Text = "이미지 채널 변경";
            this.CvtImageChannelCheckbox.UseVisualStyleBackColor = true;
            // 
            // ImageChannelLabel
            // 
            this.ImageChannelLabel.AutoSize = true;
            this.ImageChannelLabel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ImageChannelLabel.Location = new System.Drawing.Point(173, 41);
            this.ImageChannelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImageChannelLabel.Name = "ImageChannelLabel";
            this.ImageChannelLabel.Size = new System.Drawing.Size(39, 20);
            this.ImageChannelLabel.TabIndex = 24;
            this.ImageChannelLabel.Text = "null";
            // 
            // ApplyImmediatelyCheckBtn
            // 
            this.ApplyImmediatelyCheckBtn.AutoSize = true;
            this.ApplyImmediatelyCheckBtn.Location = new System.Drawing.Point(463, 340);
            this.ApplyImmediatelyCheckBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ApplyImmediatelyCheckBtn.Name = "ApplyImmediatelyCheckBtn";
            this.ApplyImmediatelyCheckBtn.Size = new System.Drawing.Size(154, 19);
            this.ApplyImmediatelyCheckBtn.TabIndex = 25;
            this.ApplyImmediatelyCheckBtn.Text = "픽쳐박스에서 적용";
            this.ApplyImmediatelyCheckBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1017, 594);
            this.Controls.Add(this.ApplyImmediatelyCheckBtn);
            this.Controls.Add(this.ImageChannelLabel);
            this.Controls.Add(this.CvtImageChannelCheckbox);
            this.Controls.Add(this.SharpenModListbox);
            this.Controls.Add(this.SharpenBtn);
            this.Controls.Add(this.BilateralFilterBtn);
            this.Controls.Add(this.GaussianBlurBtn);
            this.Controls.Add(this.ThresholdValue);
            this.Controls.Add(this.ThresholdBtn);
            this.Controls.Add(this.RollBackBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button RollBackBtn;
        private System.Windows.Forms.Button ThresholdBtn;
        private System.Windows.Forms.NumericUpDown ThresholdValue;
        private System.Windows.Forms.Button GaussianBlurBtn;
        private System.Windows.Forms.Button BilateralFilterBtn;
        private System.Windows.Forms.Button SharpenBtn;
        private System.Windows.Forms.ComboBox SharpenModListbox;
        private System.Windows.Forms.CheckBox CvtImageChannelCheckbox;
        private System.Windows.Forms.Label ImageChannelLabel;
        private System.Windows.Forms.CheckBox ApplyImmediatelyCheckBtn;
    }
}

