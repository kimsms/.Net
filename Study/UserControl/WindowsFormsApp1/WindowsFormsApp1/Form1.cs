using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        private Bitmap _bmp = null;
        private float _zoom = 2.0F;
        private Point _pt;
        private Point _pt2;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(742, 543);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
        public Form1()
        {
            InitializeComponent();

            Init();

            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSize = new Size(600, 300);
            this.splitContainer1.SplitterDistance = 300;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            this.pictureBox2.MouseDown += new MouseEventHandler(pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new MouseEventHandler(pictureBox2_MouseMove);

            this.pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            this.pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
        }
        private void Init()
        {
            //usually done with the designer of VS

            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();

            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";

            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);

            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Size = new System.Drawing.Size(284, 262);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 0;

            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;

            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;

            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.splitContainer1);
        }
        void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (_pt.X >= 0 && _pt.Y >= 0 && _pt2.X >= 0 && _pt2.Y >= 0)
            {
                e.Graphics.DrawRectangle(Pens.Blue, _pt.X * _zoom, _pt.Y * _zoom, (_pt2.X - _pt.X) * _zoom, (_pt2.Y - _pt.Y) * _zoom);
            }
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_pt.X >= 0 && _pt.Y >= 0 && _pt2.X >= 0 && _pt2.Y >= 0)
            {
                e.Graphics.DrawRectangle(Pens.Blue, _pt.X, _pt.Y, _pt2.X - _pt.X, _pt2.Y - _pt.Y);
            }
        }

        void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int ix = (int)(e.X / _zoom);
                int iy = (int)(e.Y / _zoom);

                _pt2 = new Point(ix, iy);

                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
        }

        void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int ix = (int)(e.X / _zoom);
                int iy = (int)(e.Y / _zoom);

                //reset _pt2
                _pt2 = new Point(0, 0);
                _pt = new Point(ix, iy);

                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bmp != null)
                _bmp.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _bmp = new Bitmap(300, 300);

            using (Graphics g = Graphics.FromImage(_bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Green);
                g.FillEllipse(Brushes.Red, new Rectangle(0, 0, _bmp.Width, _bmp.Height));
            }

            this.pictureBox1.Image = _bmp;

            this.pictureBox2.ClientSize = new Size((int)(_bmp.Width * _zoom), (int)(_bmp.Height * _zoom));
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            this.pictureBox2.Image = _bmp;
        }
    }
}
