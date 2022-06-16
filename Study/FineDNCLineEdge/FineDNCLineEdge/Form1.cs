using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = OpenCvSharp.Point;

namespace FineDNCLineEdge
{
    public partial class Form1 : Form
    {
        #region 이미지 잘라내기 변수
        /// <summary>
        /// 사각형 도형 표시 flag
        /// </summary>
        bool squareFigureDisplayFlag = false;

        /// <summary>
        /// 원본 이미지에 표시할 시작 좌표입니다.
        /// </summary>
        System.Drawing.Point startPoint;

        /// <summary>
        /// 원본 이미지에 표시할 끝 좌표입니다.
        /// </summary>
        System.Drawing.Point endPoint;

        /// <summary>
        /// 자를 이미지의 시작 좌표
        /// </summary>
        System.Drawing.Point CropImageStartPoint;

        /// <summary>
        /// 자를 이미지의 끝 좌표
        /// </summary>
        System.Drawing.Point CropImageEndPoint;

        int pictureBoxWidth;
        int pictureBoxHeight;
        int imageWidth;
        int imageHeight;
        #endregion

        public Form1()
        {
            InitializeComponent();

            pictureBox2.MouseWheel += pictureBox2_MouseWheel;
            IZ.setSpeed(50);
        }

        ImageZoom IZ = new ImageZoom();
        private void pictureBox2_MouseWheel(object sender, MouseEventArgs e)
        {
            IZ.MainPicturebox_MouseWheel(sender, e, pictureBox2, panel1);
        }

        #region 이미지 잘라내기
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //사각형 그림 표시 flag
                squareFigureDisplayFlag = true;

                //picturebox 시작 지점 설정
                startPoint = e.Location;
                endPoint = e.Location;

                //picturebox와 image의 크기 차를 구하기 위한 변수
                pictureBoxWidth = pictureBox1.Width;
                pictureBoxHeight = pictureBox1.Height;
                imageWidth = pictureBox1.Image.Width;
                imageHeight = pictureBox1.Image.Height;


                //Image기준 시작 좌표 설정
                double pictureBoxAspectRatio = pictureBoxWidth / pictureBoxHeight;
                double imageAspectRatio = imageWidth / imageHeight;

                if (pictureBoxAspectRatio > imageAspectRatio)
                {
                    CropImageStartPoint.Y = (int)(imageHeight * e.Y / (float)pictureBoxHeight);

                    double scaledWidth = imageWidth * pictureBoxHeight / imageHeight;

                    double deltaX = (pictureBoxWidth - scaledWidth) / 2;

                    CropImageStartPoint.X = (int)((e.X - deltaX) * imageHeight / (float)pictureBoxHeight);
                }
                else
                {
                    CropImageStartPoint.X = (int)(imageWidth * e.X / (float)pictureBoxWidth);

                    double scaledHeight = imageHeight * pictureBoxWidth / imageWidth;

                    double deltaY = (pictureBoxHeight - scaledHeight) / 2;

                    CropImageStartPoint.Y = (int)((e.Y - deltaY) * imageWidth / pictureBoxWidth);
                }

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Rectangle 설정
            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;

                //영역 표시
                pictureBox1.Refresh();

                //Image기준 끝 좌표 설정
                double pictureBoxAspectRatio = pictureBoxWidth / pictureBoxHeight;
                double imageAspectRatio = imageWidth / imageHeight;

                if (pictureBoxAspectRatio > imageAspectRatio)
                {

                    CropImageEndPoint.Y = (int)(imageHeight * e.Y / (float)pictureBoxHeight);

                    double scaledWidth = imageWidth * pictureBoxHeight / imageHeight;

                    double deltaX = (pictureBoxWidth - scaledWidth) / 2;

                    CropImageEndPoint.X = (int)((e.X - deltaX) * imageHeight / (float)pictureBoxHeight);
                }
                else
                {
                    CropImageEndPoint.X = (int)(imageWidth * e.X / (float)pictureBoxWidth);

                    double scaledHeight = imageHeight * pictureBoxWidth / imageWidth;

                    double deltaY = (pictureBoxHeight - scaledHeight) / 2;

                    CropImageEndPoint.Y = (int)((e.Y - deltaY) * imageWidth / pictureBoxWidth);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //사각형 그림 표시 flag
                squareFigureDisplayFlag = false;

                //picturebox 기준 사각형 정보
                Rectangle rectangle = GetRectangle(startPoint, endPoint);
                //label1.Text = rectangle.ToString();

                //잘라낼 이미지의 크기 설정
                double width = Math.Abs(CropImageStartPoint.X - CropImageEndPoint.X);
                double height = Math.Abs(CropImageStartPoint.Y - CropImageEndPoint.Y);

                //Image 기준 사각형 표시
                try
                {
                    Bitmap resultBitmap = (Bitmap)pictureBox1.Image;
                    Rectangle resultingRectangle = new Rectangle((int)Math.Min(CropImageStartPoint.X, CropImageEndPoint.X),
                                     (int)Math.Min(CropImageStartPoint.Y, CropImageEndPoint.Y),
                                     (int)width,
                                     (int)height);
                    pictureBox2.Image = resultBitmap.Clone(resultingRectangle, System.Drawing.Imaging.PixelFormat.DontCare);

                    //label2.Text = resultingRectangle.ToString();
                    src = Cvt2Mat(pictureBox2.Image);
                    //button1_Click(sender, e);
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("마우스가 영역을 벗어남");
                }
                catch (ArgumentException) { }
            }
        }

        private Rectangle GetRectangle(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);

            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //사각형 도형 표시 flag
            if (squareFigureDisplayFlag)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, GetRectangle(startPoint, endPoint));
                }
            }
        }
        #endregion

        private Mat Cvt2Mat(Image image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)image);
        }

        private Bitmap Cvt2Bitmap(Mat mat)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
        }

        private Mat Contours(Mat src)
        {
            Mat hierarchy1 = new Mat();
            Mat src1 = new Mat();
            Cv2.CvtColor(src, src1, ColorConversionCodes.GRAY2RGB);
            Cv2.FindContours(src, out Point[][] contour1, out HierarchyIndex[] hierarchy2, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);


            #region 테스트
            Point[] points = new Point[contour1[0].Length];
            for (int i = 0; i < contour1.Length; i++)
            {
                for (int j = 0; j < contour1[i].Length; j++)
                {
                    points[j] = new Point(contour1[i][j].X, contour1[i][j].Y);
                }
            }

            Point temp = new Point(0, 0);
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if ((points[i].Y > points[j].Y) || (points[i].Y == points[j].Y && points[i].X > points[j].X))
                    {
                        temp = points[i];
                        points[i] = points[j];
                        points[j] = temp;
                    }

                    /*if (points[i].X == points[j].X)
                    {
                        temp = points[i];
                        points[i] = points[j];
                        points[j] = temp;
                    }*/
                }
            }

            for (int i = 0; i < points.Length - 1; i++)
            {
                //Cv2.Circle(src1, new Point(points[i].X, points[i].Y), 1, Scalar.Red);
                if ((points[i].Y == points[i + 1].Y && points[i].X == points[i + 1].X + 1) ||
                    (points[i].Y == points[i + 1].Y && points[i].X == points[i + 1].X - 1))
                {
                    //Cv2.Circle(src1, new Point(points[i].X, points[i].Y), 1, Scalar.Red);
                    Cv2.Line(src1, new Point(points[i].X, points[i].Y), new Point(points[i + 1].X, points[i + 1].Y), Scalar.Red, 1);
                }
            }
            #endregion

            /*for (int i = 0; i < contour1.Length; i++)
            {
                Cv2.DrawContours(src1, contour1, i, Scalar.Red, 1, LineTypes.AntiAlias);
            }*/


            return src1;
        }

        private Mat blob(Mat src)
        {
            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            CvBlobs blobs = new CvBlobs();
            int blobarea;
            List<Rect> blobrect = new List<Rect>();
            blobs.Label(src);
            if (blobs.Count > 0)
            {
                foreach (var item in blobs)
                {
                    CvBlob blob = item.Value;

                    blobarea = blob.Area;
                    blobrect.Add(blob.Rect);

                    CvContourChainCode chainCode = blob.Contour;
                    chainCode.Render(result);
                }
            }
            for (int i = 0; i < blobrect.Count; i++)
            {
                Cv2.Rectangle(result, blobrect[i], Scalar.Red, 1);
            }

            return result;
        }

        Mat src = new Mat();
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = blackwhite1((Bitmap)pictureBox1.Image);


            return;
            src = Cvt2Mat(pictureBox1.Image);
            Mat result = new Mat();
            Cv2.Threshold(src, result, (double)numericUpDown1.Value, 255, ThresholdTypes.Binary);
            //Cv2.Canny(result, result, 50, 200);
            //result = Contours(result);
            result = blob(result);
            pictureBox2.Image = Cvt2Bitmap(result);
            //Cv2.ImShow("result", result);
        }

        private Bitmap blackwhite1(Bitmap src)
        {
            Bitmap bm = new Bitmap(src.Width, src.Height);
            Bitmap tmp = new Bitmap(src.Width, src.Height);
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    //픽셀의 밝기 가져오기
                    float val = src.GetPixel(x, y).GetBrightness();
                    //기준값을 이용하여 흑백으로 변경
                    if (val > 0.24)
                    {
                        tmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        tmp.SetPixel(x, y, Color.Black);
                    }

                    //가장 아랫줄이면서 밝기 값이 0.5보다 큰것을 가져옴
                    if (y == src.Height - 1 && val > 0.5)
                    {
                        tmp.SetPixel(x, y, Color.Red); //표시
                        //표시를 기준으로 아래에서 부터 위로 올라가며 확인
                        for (int i = src.Height - 1; i > 0; i--)
                        {
                            //픽셀의 밝기값을 가져와
                            float temp = src.GetPixel(x, i).GetBrightness();
                            //검은색 부분이면 표시
                            if (temp >= 0 && temp < 0.3)
                            {
                                tmp.SetPixel(x, i, Color.Orange);
                                //그중에서 바로 윗 픽셀이 검은색이 아니면
                                if (src.GetPixel(x, i - 1).GetBrightness() >= 0.3)
                                {
                                    //좌우 픽셀 확인
                                    if (src.GetPixel(x - 1, i - 1).GetBrightness() >= 0.3 && src.GetPixel(x + 1, i - 1).GetBrightness() >= 0.3)
                                    {
                                        tmp.SetPixel(x, i - 1, Color.Aqua); //표시
                                        //MessageBox.Show($"{x}, {i}");
                                        break;
                                    }
                                }
                            }
                        }
                        //위에서 부터 아래로 내려가며 확인
                        for (int i = 0; i < src.Height - 1; i++)
                        {
                            //픽셀의 밝기값을 가져와
                            float temp = src.GetPixel(x, i).GetBrightness();
                            //검은색 부분이면 표시
                            if (temp >= 0 && temp < 0.3)
                            {
                                tmp.SetPixel(x, i, Color.Yellow);
                                //그중에서 바로 밑 픽셀이 검은색이 아니면
                                if (src.GetPixel(x, i + 1).GetBrightness() >= 0.3)
                                {
                                    //좌우 픽셀 확인
                                    if (src.GetPixel(x - 1, i + 1).GetBrightness() >= 0.3 && src.GetPixel(x + 1, i + 1).GetBrightness() >= 0.3)
                                    {
                                        tmp.SetPixel(x, i + 1, Color.Coral); //표시
                                        //MessageBox.Show($"{x}, {i}");
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            return tmp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
                pictureBox2.Image.Save(@"temp.bmp");
        }
    }
}
