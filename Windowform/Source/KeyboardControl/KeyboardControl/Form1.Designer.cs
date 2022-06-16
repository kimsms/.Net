namespace KeyboardControl
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
            this.MainTextbox = new System.Windows.Forms.TextBox();
            this.NotebookKeyboardBtn = new System.Windows.Forms.CheckBox();
            this.ExternalKeyboardBtn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // MainTextbox
            // 
            this.MainTextbox.Location = new System.Drawing.Point(307, 139);
            this.MainTextbox.Multiline = true;
            this.MainTextbox.Name = "MainTextbox";
            this.MainTextbox.Size = new System.Drawing.Size(263, 149);
            this.MainTextbox.TabIndex = 0;
            // 
            // NotebookKeyboardBtn
            // 
            this.NotebookKeyboardBtn.AutoSize = true;
            this.NotebookKeyboardBtn.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NotebookKeyboardBtn.Location = new System.Drawing.Point(307, 305);
            this.NotebookKeyboardBtn.Name = "NotebookKeyboardBtn";
            this.NotebookKeyboardBtn.Size = new System.Drawing.Size(121, 50);
            this.NotebookKeyboardBtn.TabIndex = 1;
            this.NotebookKeyboardBtn.Text = "Notebook\r\nKeyboard";
            this.NotebookKeyboardBtn.UseVisualStyleBackColor = true;
            // 
            // ExternalKeyboardBtn
            // 
            this.ExternalKeyboardBtn.AutoSize = true;
            this.ExternalKeyboardBtn.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExternalKeyboardBtn.Location = new System.Drawing.Point(454, 305);
            this.ExternalKeyboardBtn.Name = "ExternalKeyboardBtn";
            this.ExternalKeyboardBtn.Size = new System.Drawing.Size(116, 50);
            this.ExternalKeyboardBtn.TabIndex = 2;
            this.ExternalKeyboardBtn.Text = "External\r\nKeyboard";
            this.ExternalKeyboardBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 436);
            this.Controls.Add(this.ExternalKeyboardBtn);
            this.Controls.Add(this.NotebookKeyboardBtn);
            this.Controls.Add(this.MainTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MainTextbox;
        private System.Windows.Forms.CheckBox NotebookKeyboardBtn;
        private System.Windows.Forms.CheckBox ExternalKeyboardBtn;
    }
}

