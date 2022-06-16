using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCVClass;
using OpenCvSharp;
using ImageClass;
using System.Drawing;

namespace synthesis
{
    public partial class Form1 : Form
    {
        ImageTools IT = new ImageTools();
        OpecnCVTools OC = new OpecnCVTools();
        //Graphics G = new Graphics();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Image image = IT.LoadImage();
            if (image != null)
            {
                pictureBox1.Image = image;
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            Image image = IT.LoadImage();
            if (image != null)
            {
                pictureBox2.Image = image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mat src = OC.Cvt_toMat(pictureBox1.Image);
            Mat logo = OC.Cvt_toMat(pictureBox2.Image);

            Cv2.ImShow("result", Alphablending(src, logo, 0.5));
        }

        private Mat Alphablending(Mat src, Mat logo, double alpha)
        {
            Cv2.Resize(src, src, new OpenCvSharp.Size(550, 550));
            Cv2.Resize(logo, logo, new OpenCvSharp.Size(550, 550));
            Mat result = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.AddWeighted(src, alpha, logo, 1-alpha, 0, result);

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //부분 합성

        }




        /*public IplImage ResultOKNG(IplImage Src, bool TFOKNG)
        {
            try
            {
                ResultIMG = null;
                ResultIMG = new IplImage(Src.Size, BitDepth.U8, 4);
                T1 = null;
                T1 = new IplImage(Src.Size, BitDepth.U8, 4);

                IplImage OK = Cv.LoadImage(@"./Img/OK.png", LoadMode.Unchanged);
                IplImage NG = Cv.LoadImage(@"./Img/NG.png", LoadMode.Unchanged);

                if (TFOKNG)
                {
                    T1.DrawImage(20, 20, OK.Width, OK.Height, OK);
                }
                else
                {
                    T1.DrawImage(20, 20, NG.Width, NG.Height, NG);
                }

                Cv.CvtColor(Src.Clone(), ResultIMG, ColorConversion.RgbToRgba);

                double alpha_ = 1.0f;
                double beta_ = 0.99f; //1.0 - alpha_;

                Cv.AddWeighted(ResultIMG, alpha_, T1, beta_, 0.0f, ResultIMG);


            }
            catch (Exception) { }


            return ResultIMG;
            //double alpha_ = 1.0f;
            //double beta_ = 0.7f; //1.0 - alpha_;

            //Cv.AddWeighted(ResultIMG, alpha_, T1, beta_, 0.0f, ResultIMG);
        }*/

    }
}
