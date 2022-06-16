
namespace Change_calculation
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label500 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.val500 = new System.Windows.Forms.Label();
            this.val100 = new System.Windows.Forms.Label();
            this.val50 = new System.Windows.Forms.Label();
            this.val10 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label500
            // 
            this.label500.AutoSize = true;
            this.label500.Location = new System.Drawing.Point(224, 184);
            this.label500.Name = "label500";
            this.label500.Size = new System.Drawing.Size(31, 15);
            this.label500.TabIndex = 2;
            this.label500.Text = "500";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(293, 184);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(31, 15);
            this.label100.TabIndex = 3;
            this.label100.Text = "100";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(363, 184);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(23, 15);
            this.label50.TabIndex = 4;
            this.label50.Text = "50";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(415, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "10";
            // 
            // val500
            // 
            this.val500.AutoSize = true;
            this.val500.Location = new System.Drawing.Point(224, 240);
            this.val500.Name = "val500";
            this.val500.Size = new System.Drawing.Size(15, 15);
            this.val500.TabIndex = 6;
            this.val500.Text = "0";
            // 
            // val100
            // 
            this.val100.AutoSize = true;
            this.val100.Location = new System.Drawing.Point(293, 240);
            this.val100.Name = "val100";
            this.val100.Size = new System.Drawing.Size(15, 15);
            this.val100.TabIndex = 7;
            this.val100.Text = "0";
            // 
            // val50
            // 
            this.val50.AutoSize = true;
            this.val50.Location = new System.Drawing.Point(363, 240);
            this.val50.Name = "val50";
            this.val50.Size = new System.Drawing.Size(15, 15);
            this.val50.TabIndex = 8;
            this.val50.Text = "0";
            // 
            // val10
            // 
            this.val10.AutoSize = true;
            this.val10.Location = new System.Drawing.Point(415, 240);
            this.val10.Name = "val10";
            this.val10.Size = new System.Drawing.Size(15, 15);
            this.val10.TabIndex = 9;
            this.val10.Text = "0";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(465, 212);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(15, 15);
            this.Total.TabIndex = 10;
            this.Total.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.val10);
            this.Controls.Add(this.val50);
            this.Controls.Add(this.val100);
            this.Controls.Add(this.val500);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.label500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label500;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label val500;
        private System.Windows.Forms.Label val100;
        private System.Windows.Forms.Label val50;
        private System.Windows.Forms.Label val10;
        private System.Windows.Forms.Label Total;
    }
}

