namespace SerialTest
{
    partial class SetupDlg
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
            this.btnDlgExit = new System.Windows.Forms.Button();
            this.label_AxisX = new System.Windows.Forms.Label();
            this.label_AxisY = new System.Windows.Forms.Label();
            this.label_AxisZ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDlgExit
            // 
            this.btnDlgExit.Location = new System.Drawing.Point(312, 355);
            this.btnDlgExit.Name = "btnDlgExit";
            this.btnDlgExit.Size = new System.Drawing.Size(128, 49);
            this.btnDlgExit.TabIndex = 0;
            this.btnDlgExit.Text = "EXIT";
            this.btnDlgExit.UseVisualStyleBackColor = true;
            this.btnDlgExit.Click += new System.EventHandler(this.btnDlgExit_Click);
            // 
            // label_AxisX
            // 
            this.label_AxisX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AxisX.Location = new System.Drawing.Point(45, 80);
            this.label_AxisX.Name = "label_AxisX";
            this.label_AxisX.Size = new System.Drawing.Size(123, 23);
            this.label_AxisX.TabIndex = 1;
            this.label_AxisX.Text = "0";
            this.label_AxisX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AxisY
            // 
            this.label_AxisY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AxisY.Location = new System.Drawing.Point(45, 118);
            this.label_AxisY.Name = "label_AxisY";
            this.label_AxisY.Size = new System.Drawing.Size(123, 23);
            this.label_AxisY.TabIndex = 2;
            this.label_AxisY.Text = "0";
            this.label_AxisY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AxisZ
            // 
            this.label_AxisZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AxisZ.Location = new System.Drawing.Point(45, 154);
            this.label_AxisZ.Name = "label_AxisZ";
            this.label_AxisZ.Size = new System.Drawing.Size(123, 23);
            this.label_AxisZ.TabIndex = 3;
            this.label_AxisZ.Text = "0";
            this.label_AxisZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetupDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 433);
            this.Controls.Add(this.label_AxisZ);
            this.Controls.Add(this.label_AxisY);
            this.Controls.Add(this.label_AxisX);
            this.Controls.Add(this.btnDlgExit);
            this.Name = "SetupDlg";
            this.Text = "SetupDlg";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDlgExit;
        private System.Windows.Forms.Label label_AxisX;
        private System.Windows.Forms.Label label_AxisY;
        private System.Windows.Forms.Label label_AxisZ;
    }
}