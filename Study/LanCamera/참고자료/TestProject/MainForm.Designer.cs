namespace TestProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourcePictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.sourcePictureBox.Location = new System.Drawing.Point(20, 20);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(480, 480);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            this.sourcePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sourcePictureBox_MouseDown);
            this.sourcePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sourcePictureBox_MouseMove);
            this.sourcePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sourcePictureBox_MouseUp);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPictureBox.Location = new System.Drawing.Point(520, 20);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(100, 100);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.resultPictureBox.TabIndex = 1;
            this.resultPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Font = new System.Drawing.Font("나눔고딕코딩", 12F);
            this.Name = "MainForm";
            this.Text = "이미지 사각형 선택하기";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox resultPictureBox;
    }
}

