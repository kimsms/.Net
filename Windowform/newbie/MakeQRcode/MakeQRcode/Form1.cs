using BusinessRefinery.Barcode;
using System;
using System.Text;
using System.Windows.Forms;

namespace MakeQRcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void MakeQRcode()
        {
            QRCode barcode = new QRCode();
            string url = textBox1.Text;
            barcode.Code = url;
            barcode.ModuleSize = 6.0f;  //QR코드의 크기
            barcode.Resolution = 300;   //QR코드의 해상도
            pictureBox1.Image = barcode.drawBarcodeOnBitmap();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MakeQRcode();
            }
            else
            {
                MessageBox.Show("내용을 입력하세요");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                    MessageBox.Show("저장되었습니다", "Save");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
    }
}
