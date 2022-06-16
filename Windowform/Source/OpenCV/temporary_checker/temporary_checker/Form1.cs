using ImageClass;
using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace temporary_checker
{
    public partial class Form1 : Form
    {
        ImageTools IT = new ImageTools();
        Mat src = new Mat();
        Mat bin = new Mat();
        Mat rollback = new Mat();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Image = IT.LoadImage();
            rollback = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
            rollback.CopyTo(src);
            rollback.CopyTo(bin);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //입력 이미지가 1채널이라 CvtColor가 필요 없음
            //Cv2.CvtColor(src, bin, ColorConversionCodes.BGR2GRAY);
            if (checkBox1.Checked)
            {
                Cv2.Threshold(bin, bin, (double)numericUpDown1.Value, 255, ThresholdTypes.BinaryInv);
            }
            else
            {
                Cv2.Threshold(bin, bin, (double)numericUpDown1.Value, 255, ThresholdTypes.Binary);
            }


            //blob
            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            CvBlobs blobs = new CvBlobs();
            blobs.Label(bin);
            foreach (var item in blobs)
            {
                CvBlob blob = item.Value;

                CvContourChainCode chainCode = blob.Contour;

                chainCode.Render(result, Scalar.MintCream);
            }

            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);

            if (checkBox2.Checked)
            {
                if (radioButton1.Checked)
                {
                    button4_Click(sender, e);
                }
                else
                {
                    button3_Click(sender, e);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rollback);
            rollback.CopyTo(src);
            rollback.CopyTo(bin);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Normalization
            Cv2.Normalize(bin, bin, 0, 255, NormTypes.MinMax);
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(bin);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GaussianBlur
            Cv2.GaussianBlur(bin, bin, new OpenCvSharp.Size(9, 9), 1, 1, BorderTypes.Default);
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(bin);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
            }
        }

    }
}
