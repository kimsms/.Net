using ImageClass;
using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Drawing;
using System.Windows.Forms;
using Point = OpenCvSharp.Point;

namespace Camera
{
    public partial class Form1 : Form
    {
        ImageTools IT = new ImageTools();
        VideoCapture video = new VideoCapture(0);
        Mat frame = new Mat();
        Mat blending_image = new Mat();
        bool form_flag = true;
        Image rollback;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            rollback = pictureBox2.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewCam();
        }

        private void ViewCam()
        {
            while (Cv2.WaitKey(33) != 'q' && form_flag)
            {
                video.Read(frame);
                
                //좌우반전
                if (!checkBox2.Checked)
                    Cv2.Flip(frame, frame, FlipMode.Y);

                //알파블렌딩
                if (checkBox1.Checked)
                {
                    if (pictureBox1.Image != null)
                    {
                        blending_image = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
                        AlphaBlending(ref frame, blending_image, (double)numericUpDown1.Value, (double)numericUpDown2.Value);
                    }
                }

                //HSV
                if (checkBox3.Checked)
                {
                    HSV(ref frame, (double)numericUpDown3.Value, (double)numericUpDown4.Value);
                    Contour(ref frame);
                }

                Cv2.ImShow("Q를 눌러 종료", frame);

            }

            //frame.Dispose();
            //video.Dispose();
            Cv2.DestroyAllWindows();
        }

        //알파블렌딩
        private void AlphaBlending(ref Mat src, Mat image, double alpha, double beta)
        {
            Cv2.Resize(image, image, new OpenCvSharp.Size(src.Width, src.Height));
            Cv2.AddWeighted(src, alpha, image, beta, 0, src);
        }

        //HSV
        private void HSV(ref Mat src, double min, double max)
        {
            Mat[] mv = new Mat[3];
            Mat mask = new Mat();

            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2HSV);
            mv = Cv2.Split(src);
            //mv[0] = h 색상(Hue), mv[1] = s 채도(Saturation), mv[2] = v 명도(Value)

            Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            Cv2.InRange(mv[0], new Scalar(min), new Scalar(max), mask);
            /*Cv2.InRange(mv[1], new Scalar(min), new Scalar(max), mask);
            Cv2.InRange(mv[2], new Scalar(min), new Scalar(max), mask);*/

            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);
        }

        private void Contour(ref Mat src)
        {
            Mat bin = new Mat();
            Cv2.CvtColor(src, bin, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(bin, bin, 0, 255, ThresholdTypes.Otsu);

            Cv2.FindContours(bin, out Point[][] contour, out HierarchyIndex[] hierarchy,
                RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

            //형태
            /*for(int i = 0; i < contour.Length; i++)
            {
                Cv2.DrawContours(src, contour, i, Scalar.Green, 2, LineTypes.AntiAlias, hierarchy);
            }*/
            //큰틀
            for (int i = 0; i < contour.Length; i++)
            {
                Rect rect = Cv2.BoundingRect(contour[i]);
                Cv2.Rectangle(src, new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height),
                    Scalar.Yellow, 2, LineTypes.AntiAlias);
            }
            //회전
            /*for (int i = 0; i < contour.Length; i++)
            {
                RotatedRect rect = Cv2.MinAreaRect(contour[i]);
                for (int j = 0; j < 4; j++)
                {
                    Cv2.Line(src, new Point(rect.Points()[j].X, rect.Points()[j].Y),
                        new Point(rect.Points()[(j + 1) % 4].X, rect.Points()[(j + 1) % 4].Y),
                        Scalar.Red, 2, LineTypes.AntiAlias);
                }
            }*/
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Image = IT.LoadImage();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                pictureBox1.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
            }
            else
            {
                numericUpDown3.Visible = false;
                numericUpDown4.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_flag = false;
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            pictureBox2.Image = IT.LoadImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //이미지에서 빨간색 별만 찾아내기 (HSV이용)

            Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBox2.Image);
            double min = (double)numericUpDown5.Value;
            double max = (double)numericUpDown6.Value;
            Mat[] mv = new Mat[3];
            Mat mask = new Mat();
            
            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2HSV);
            mv = Cv2.Split(src);
            //mv[0] = h 색상(Hue), mv[1] = s 채도(Saturation), mv[2] = v 명도(Value)
            
            Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            Cv2.InRange(mv[comboBox1.SelectedIndex], new Scalar(min), new Scalar(max), mask);

            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);

            Contour(ref src);

            pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //롤백
            pictureBox2.Image = rollback;
        }
    }
}
