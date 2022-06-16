using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace blob
{
    public partial class Form1 : Form
    {
        Mat src = new Mat();
        Mat Threshold_Img = new Mat();
        public Form1()
        {
            InitializeComponent();
        }

        public Bitmap LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png;)| *.bmp; *.jpg; *.png; | All files(*.*) | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap recImg;

                return recImg = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);

            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //이미지 불러오기
            pictureBox1.Image = LoadImage();
            if (pictureBox1.Image == null)
                return;
            src = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //이미지 이진화
            Cv2.CvtColor(src, Threshold_Img, ColorConversionCodes.RGB2GRAY);
            Cv2.Threshold(Threshold_Img, Threshold_Img, 0, 255, ThresholdTypes.Otsu);
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Threshold_Img);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Threshold_Img.Width == 0)
            {
                //이진화 작업 확인 필요
                MessageBox.Show("이진화 작업 필요");
                return;
            }

            //Contour 이용해 윤곽선 찾기
            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            CvBlobs blobs = new CvBlobs();
            blobs.Label(Threshold_Img);
            blobs.RenderBlobs(src, result);
            foreach (var item in blobs)
            {
                CvBlob b = item.Value;
                Cv2.Circle(result, b.Contour.StartingPoint, 4, Scalar.Red, 2, LineTypes.AntiAlias);
                Cv2.PutText(result, b.Label.ToString(), new OpenCvSharp.Point(b.Centroid.X, b.Centroid.Y),
                    HersheyFonts.HersheyComplex, 1, Scalar.Yellow, 2, LineTypes.AntiAlias);
            }

            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //롤백
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            //Blob 이용해 윤곽선 찾기
            Mat result = new Mat(src.Size(), MatType.CV_8UC3); 
            CvBlobs blobs = new CvBlobs(); 
            blobs.Label(Threshold_Img); 
            foreach (var item in blobs) 
            { 
                CvBlob blob = item.Value; 
                CvContourChainCode chainCode = blob.Contour; 
                chainCode.Render(result); 
            }

            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
        }
    }
}
