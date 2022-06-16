using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using ImageClass;

namespace blur
{
    public partial class Form1 : Form
    {
        ImageTools IC = new ImageTools();

        Image RollBack_Image;
        Mat original = new Mat();
        Mat result = new Mat();
        Mat picture = new Mat();

        public Form1()
        {
            InitializeComponent();
            SharpenModListbox.SelectedIndex = 0;
        }

        /// <summary>
        /// Mat to Bitmap
        /// </summary>
        /// <param name="src">source image</param>
        /// <returns>Bitmap</returns>
        private Bitmap Convert_to_Bitmap(Mat src)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
        }

        /// <summary>
        /// Bitmap to Mat
        /// </summary>
        /// <param name="src">source image</param>
        /// <returns>Mat</returns>
        private Mat Convert_to_Mat(Bitmap src)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat(src);
        }

        /// <summary>
        /// Image to Mat
        /// </summary>
        /// <param name="src">source image</param>
        /// <returns>Mat</returns>
        private Mat Convert_to_Mat(Image src)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)src);
        }

        /// <summary>
        /// 이미지 로드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.LoadImage();

            if (pictureBox1.Image != null)
            {
                RollBack_Image = pictureBox1.Image;
                original = Convert_to_Mat(pictureBox1.Image);
                picture = Convert_to_Mat(pictureBox1.Image);
                if (CvtImageChannelCheckbox.Checked)
                    Cv2.CvtColor(original, original, ColorConversionCodes.RGB2GRAY);
                ImageChannelLabel.Text = original.Type().ToString();
            }
        }

        /// <summary>
        /// 이미지 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            IC.SaveImage(pictureBox1.Image);
        }

        /// <summary>
        /// 롤백
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollBackBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = RollBack_Image;
            picture = original;
        }

        /// <summary>
        /// 이진화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThresholdBtn_Click(object sender, EventArgs e)
        {
            Cv2.Threshold(original, result, (double)ThresholdValue.Value, 255, ThresholdTypes.BinaryInv);
            pictureBox1.Image = Convert_to_Bitmap(result);
        }

        /// <summary>
        /// GaussianBlur 필터
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GaussianBlurBtn_Click(object sender, EventArgs e)
        {
            Cv2.GaussianBlur(original, result, new OpenCvSharp.Size(9, 9), 1, 1, BorderTypes.Default);
            pictureBox1.Image = Convert_to_Bitmap(result);
        }

        /// <summary>
        /// 양방향 필터
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BilateralFilterBtn_Click(object sender, EventArgs e)
        {

            Cv2.BilateralFilter(original, result, 9, 3, 3, BorderTypes.Default);
            pictureBox1.Image = Convert_to_Bitmap(result);
        }

        /// <summary>
        /// Sharpen 필터
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SharpenBtn_Click(object sender, EventArgs e)
        {
            //샤프닝 마스크의 모든 계수의 합은 1이다
            float[] mask1 = new float[9]
            {
                1, -2, 1,
                -2, 5, -2,
                1, -2, 1
            };
            float[] mask2 = new float[9] {
                 0, -1, 0,
                 -1, 5, -1,
                 0, -1, 0
            };
            float[] mask3 = new float[9] {
                 -1, -1, -1,
                 -1, 9, -1,
                 -1, -1, -1
            };

            //Mat kernel = new Mat(3, 3, MatType.CV_32F, mask1);
            Mat kernel;
            if (SharpenModListbox.SelectedIndex == 0)
            {
                kernel = new Mat(3, 3, MatType.CV_32F, mask1);
            }
            else if (SharpenModListbox.SelectedIndex == 1)
            {
                kernel = new Mat(3, 3, MatType.CV_32F, mask2);
            }
            else
            {
                kernel = new Mat(3, 3, MatType.CV_32F, mask3);
            }

            if (ApplyImmediatelyCheckBtn.Checked)
            {
                Cv2.Filter2D(picture, picture, original.Type(), kernel, new OpenCvSharp.Point(0, 0));
                pictureBox1.Image = Convert_to_Bitmap(picture);
            }
            else
            {
                Cv2.Filter2D(original, result, original.Type(), kernel, new OpenCvSharp.Point(0, 0));
                pictureBox1.Image = Convert_to_Bitmap(result);
            }
        }
    }
}
