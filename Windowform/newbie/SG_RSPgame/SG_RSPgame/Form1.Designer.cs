
namespace SG_RSPgame
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
            this.SButton = new System.Windows.Forms.Button();
            this.RButton = new System.Windows.Forms.Button();
            this.PButton = new System.Windows.Forms.Button();
            this.WorLLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.winCount = new System.Windows.Forms.Label();
            this.muCount = new System.Windows.Forms.Label();
            this.loseCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SButton
            // 
            this.SButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SButton.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SButton.Location = new System.Drawing.Point(34, 368);
            this.SButton.Name = "SButton";
            this.SButton.Size = new System.Drawing.Size(75, 75);
            this.SButton.TabIndex = 0;
            this.SButton.Text = "가위";
            this.SButton.UseVisualStyleBackColor = true;
            this.SButton.Click += new System.EventHandler(this.SButton_Click);
            // 
            // RButton
            // 
            this.RButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RButton.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RButton.Location = new System.Drawing.Point(158, 368);
            this.RButton.Name = "RButton";
            this.RButton.Size = new System.Drawing.Size(75, 75);
            this.RButton.TabIndex = 1;
            this.RButton.Text = "바위";
            this.RButton.UseVisualStyleBackColor = true;
            this.RButton.Click += new System.EventHandler(this.RButton_Click);
            // 
            // PButton
            // 
            this.PButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PButton.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PButton.Location = new System.Drawing.Point(277, 368);
            this.PButton.Name = "PButton";
            this.PButton.Size = new System.Drawing.Size(75, 75);
            this.PButton.TabIndex = 2;
            this.PButton.Text = "보";
            this.PButton.UseVisualStyleBackColor = true;
            this.PButton.Click += new System.EventHandler(this.PButton_Click);
            // 
            // WorLLabel
            // 
            this.WorLLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WorLLabel.AutoSize = true;
            this.WorLLabel.Font = new System.Drawing.Font("돋움", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WorLLabel.Location = new System.Drawing.Point(142, 126);
            this.WorLLabel.Name = "WorLLabel";
            this.WorLLabel.Size = new System.Drawing.Size(0, 30);
            this.WorLLabel.TabIndex = 3;
            this.WorLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // winCount
            // 
            this.winCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.winCount.AutoSize = true;
            this.winCount.Font = new System.Drawing.Font("돋움", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winCount.Location = new System.Drawing.Point(32, 26);
            this.winCount.Name = "winCount";
            this.winCount.Size = new System.Drawing.Size(75, 19);
            this.winCount.TabIndex = 4;
            this.winCount.Text = "승리 : 0";
            // 
            // muCount
            // 
            this.muCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.muCount.AutoSize = true;
            this.muCount.Font = new System.Drawing.Font("돋움", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muCount.Location = new System.Drawing.Point(143, 26);
            this.muCount.Name = "muCount";
            this.muCount.Size = new System.Drawing.Size(94, 19);
            this.muCount.TabIndex = 5;
            this.muCount.Text = "무승부 : 0";
            // 
            // loseCount
            // 
            this.loseCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loseCount.AutoSize = true;
            this.loseCount.Font = new System.Drawing.Font("돋움", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loseCount.Location = new System.Drawing.Point(276, 26);
            this.loseCount.Name = "loseCount";
            this.loseCount.Size = new System.Drawing.Size(75, 19);
            this.loseCount.TabIndex = 6;
            this.loseCount.Text = "패배 : 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.loseCount);
            this.Controls.Add(this.muCount);
            this.Controls.Add(this.winCount);
            this.Controls.Add(this.WorLLabel);
            this.Controls.Add(this.PButton);
            this.Controls.Add(this.RButton);
            this.Controls.Add(this.SButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "가위바위보";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SButton;
        private System.Windows.Forms.Button RButton;
        private System.Windows.Forms.Button PButton;
        private System.Windows.Forms.Label WorLLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label winCount;
        private System.Windows.Forms.Label muCount;
        private System.Windows.Forms.Label loseCount;
    }
}

