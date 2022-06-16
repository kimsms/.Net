using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace binarization
{
    public partial class Form1 : Form
    {
        Mat original = new Mat();
        Mat result = new Mat();
        Image RollBack;
        public Form1()
        {
            InitializeComponent();
        }

        //이미지 로드
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = LoadImage();

            if (pictureBox1.Image != null)
            {
                original = new Mat(original.Size(), MatType.CV_8UC1);
                original = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBox1.Image);

                //흑백으로 변환
                try
                {
                    Cv2.CvtColor(original, original, ColorConversionCodes.RGB2GRAY);
                }
                catch (Exception) { }
                RollBack = pictureBox1.Image;
            }
        }

        //이진화
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //임계값 실시간 표시
            label1.Text = hScrollBar1.Value.ToString();

            //이진화
            if (radioButton1.Checked == true)
            {
                Cv2.Threshold(original, result, hScrollBar1.Value, 255, ThresholdTypes.Binary);
            }
            else
            {
                Cv2.Threshold(original, result, hScrollBar1.Value, 255, ThresholdTypes.BinaryInv);
            }

            //이미지 표시
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
        }


        //이미지 로드
        public Bitmap LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Bitmap recImg = null;
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png;)| *.bmp; *.jpg; *.png; | All files(*.*) | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                recImg = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
            }
            return recImg;
        }

        //롤백
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = RollBack;
        }

        //중간값
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //이진화
                Cv2.Threshold(original, result, (double)numericUpDown1.Value, 255, ThresholdTypes.BinaryInv);

                //양방향 이진화
                Cv2.Threshold(result, result, (double)numericUpDown2.Value, 255, ThresholdTypes.BinaryInv);
            }
            else
            {
                //이진화
                Cv2.Threshold(original, result, (double)numericUpDown1.Value, 255, ThresholdTypes.BinaryInv);

                //양방향 이진화
                Cv2.Threshold(result, result, (double)numericUpDown2.Value, 255, ThresholdTypes.BinaryInv);
            }

            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //자동 이진화
            Cv2.Threshold(original, result, 0, 255, ThresholdTypes.Otsu);

            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
        }
    }
}
