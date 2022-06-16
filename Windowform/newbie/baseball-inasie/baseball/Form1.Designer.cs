namespace baseball
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Input = new System.Windows.Forms.Button();
            this.list_Result = new System.Windows.Forms.ListBox();
            this.label_Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Input
            // 
            this.tb_Input.Location = new System.Drawing.Point(81, 15);
            this.tb_Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_Input.Name = "tb_Input";
            this.tb_Input.Size = new System.Drawing.Size(140, 25);
            this.tb_Input.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "숫자입력";
            // 
            // bt_Input
            // 
            this.bt_Input.Location = new System.Drawing.Point(229, 12);
            this.bt_Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_Input.Name = "bt_Input";
            this.bt_Input.Size = new System.Drawing.Size(49, 29);
            this.bt_Input.TabIndex = 2;
            this.bt_Input.Text = "입력!";
            this.bt_Input.UseVisualStyleBackColor = true;
            this.bt_Input.Click += new System.EventHandler(this.bt_Input_Click);
            // 
            // list_Result
            // 
            this.list_Result.FormattingEnabled = true;
            this.list_Result.ItemHeight = 15;
            this.list_Result.Location = new System.Drawing.Point(14, 98);
            this.list_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.list_Result.Name = "list_Result";
            this.list_Result.Size = new System.Drawing.Size(262, 274);
            this.list_Result.TabIndex = 3;
            this.list_Result.SelectedIndexChanged += new System.EventHandler(this.list_Result_SelectedIndexChanged);
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Location = new System.Drawing.Point(14, 56);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(0, 15);
            this.label_Result.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 382);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.list_Result);
            this.Controls.Add(this.bt_Input);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Input);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "숫자야구";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Input;
        private System.Windows.Forms.ListBox list_Result;
        private System.Windows.Forms.Label label_Result;
    }
}

