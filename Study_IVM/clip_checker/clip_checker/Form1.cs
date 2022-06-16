using ImageClass;
using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = OpenCvSharp.Point;

namespace clip_checker
{
    public partial class Form1 : Form
    {
        #region mainpicturebox 관련
        /// <summary>
        /// 이미지 이동 기준 좌표
        /// </summary>
        System.Drawing.Point clickPoint;

        #region mainpicturebox에 그려주기

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

        #endregion

        #region 잘라낼 이미지 좌표

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


        filter filter = new filter();

        public Form1()
        {
            InitializeComponent();

            mainPicturebox.MouseWheel += MainPicturebox_MouseWheel;
        }

        private void MainPicturebox_MouseWheel(object sender, MouseEventArgs e)
        {
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            if (lines > 0)
            {
                //확대 크기 제한
                if ((float)mainPicturebox.Width / (float)panel1.Width > 1.5) return;

                mainPicturebox.Size = new System.Drawing.Size(mainPicturebox.Width + 10, mainPicturebox.Height + 10);
            }
            else if (lines < 0)
            {
                //축소 한계치
                if (mainPicturebox.Size.Width <= panel1.Size.Width) return;


                mainPicturebox.Size = new System.Drawing.Size(mainPicturebox.Width - 10, mainPicturebox.Height - 10);
            }

            label3.Text = mainPicturebox.Width.ToString();
        }

        private void mainPicturebox_Paint(object sender, PaintEventArgs e)
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

        private void mainPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                clickPoint = new System.Drawing.Point(e.X, e.Y);
            }

            if (e.Button == MouseButtons.Left)
            {
                //사각형 그림 표시 flag
                squareFigureDisplayFlag = true;

                //picturebox 시작 지점 설정
                startPoint = e.Location;
                endPoint = e.Location;

                //picturebox와 image의 크기 차를 구하기 위한 변수
                pictureBoxWidth = mainPicturebox.Width;
                pictureBoxHeight = mainPicturebox.Height;
                imageWidth = mainPicturebox.Image.Width;
                imageHeight = mainPicturebox.Image.Height;


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

        private void mainPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            //이미지 이동
            if (e.Button == MouseButtons.Right && false)
            {
                System.Drawing.Point movepoint = new System.Drawing.Point(e.X - clickPoint.X, e.Y - clickPoint.Y);
                //TODO picturebox 이동 제한 필요
                //panel의 picturebox의 location을 panel의 loaction밖으로 빠져나가지 못하게 만들면 될 듯

                //pannel 50, 40 / picturebox 0, 0
                //if (panel1.Location.X != pictureBox1.Location.X + 44) return;
                mainPicturebox.Location = new System.Drawing.Point(mainPicturebox.Location.X + movepoint.X, mainPicturebox.Location.Y + movepoint.Y);

            }

            //Rectangle 설정
            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;

                //영역 표시
                mainPicturebox.Refresh();

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

        private void mainPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //사각형 그림 표시 flag
                squareFigureDisplayFlag = false;

                //picturebox 기준 사각형 정보
                Rectangle rectangle = GetRectangle(startPoint, endPoint);
                label1.Text = rectangle.ToString();

                //잘라낼 이미지의 크기 설정
                double width = Math.Abs(CropImageStartPoint.X - CropImageEndPoint.X);
                double height = Math.Abs(CropImageStartPoint.Y - CropImageEndPoint.Y);

                //Image 기준 사각형 표시
                try
                {
                    Bitmap resultBitmap = (Bitmap)mainPicturebox.Image;
                    Rectangle resultingRectangle = new Rectangle((int)Math.Min(CropImageStartPoint.X, CropImageEndPoint.X),
                                     (int)Math.Min(CropImageStartPoint.Y, CropImageEndPoint.Y),
                                     (int)width,
                                     (int)height);
                    //pictureBox1.Image = resultBitmap.Clone(resultingRectangle, System.Drawing.Imaging.PixelFormat.DontCare);

                    label2.Text = resultingRectangle.ToString();

                    Rectlocation = new Rect(resultingRectangle.X, resultingRectangle.Y, resultingRectangle.Width, resultingRectangle.Height);
                    RectangleImage = filter.cvtToMat(resultBitmap.Clone(resultingRectangle, System.Drawing.Imaging.PixelFormat.DontCare));
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("마우스가 영역을 벗어남");
                }
                catch (ArgumentException) { }
            }
        }

        /// <summary>
        /// 사각형 좌표 및 크기 연산
        /// </summary>
        /// <param name="startPoint">시작 좌표</param>
        /// <param name="endPoint">끝 좌표</param>
        /// <returns>결과값</returns>
        private Rectangle GetRectangle(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);

            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);

            return new Rectangle(x, y, width, height);
        }
        #endregion

        BlobSub m_blobsub = new BlobSub();
        Mat RotateImage = new Mat(); //이미지 회전 여부 확인용 이미지
        Mat RectangleImage = new Mat(); //각인 유무 확인용 이미지
        Rect Rectlocation = new Rect(); //각인 위치값 저장용
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap resultBitmap = (Bitmap)mainPicturebox.Image;
            //resultingRectangle = new Rect(909, 720, 454, 413);

            ///전체 이미지를 통쨰로 Threshold하여 이미지 회전
            //Mat src = filter.cvtToMat(pictureBox1.Image);
            RotateImage = filter.cvtToMat(resultBitmap);

            //이미지 사전 처리
            filter.Threshold(ref RotateImage, (int)numericUpDown2.Value, 255, ThresholdTypes.BinaryInv); //BinaryInv 이어야 검사가 제대로 진행됨
            filter.Sharpen(ref RotateImage);
            Rotate(ref RotateImage, int.Parse(textBox8.Text));

            ///이미지 회전
            List<Rect> tempRect = m_blobsub.rotation(RotateImage);
            label13.Text = Math.Round(Math.Sqrt((Math.Pow(tempRect[0].X - tempRect[1].X, 2) + Math.Pow(tempRect[0].Y - tempRect[1].Y, 2)))).ToString();
            imageRotate(ref RotateImage);
            
            
            RectangleImage = RotateImage.Clone(Rectlocation);


            ///여기 기준으로 회전, 검사 파트 분리

            ///머지렉 표시
            List<Rect> rectList = new List<Rect>();
            rectList = filter.MergeRect(RectangleImage, m_blobsub, Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text));
            for (int i = 0; i < rectList.Count; i++)
            {
                RectangleImage.PutText(i.ToString(),
                    new OpenCvSharp.Point(rectList[i].Right, rectList[i].Top),
                    HersheyFonts.HersheyScriptSimplex, 1.0, Scalar.White, 2);
                Rect pos = new Rect(rectList[i].X, rectList[i].Y, rectList[i].Width, rectList[i].Height);
                Cv2.Rectangle(RectangleImage, pos, Scalar.White);
            }
            
            ///결과 표시를 위한 Mat 생성
            Mat result = new Mat();
            RotateImage.CopyTo(result);
            //RectangleImage.CopyTo(result);
            Cv2.CvtColor(result, result, ColorConversionCodes.GRAY2RGB);

            ///결과 선 긋기
            //각인 여부 선
            //TODO 이미지를 잘라낸 위치에 결과 이미지를 덮어 쓰는 형식으로 표시 or 결과 point를 기록했다가 표시
            DrawDiagonal(ref result, rectList, int.Parse(textBox6.Text), int.Parse(textBox7.Text));
            //회전 확인용 선
            //Cv2.Line(result, new Point(tempRect[0].X, tempRect[0].Y), new Point(tempRect[1].X, tempRect[1].Y), Scalar.Red, 5);

            ///중심 원 표시
            //DrawCircle(ref result, filter.CircleDetection(ref src, false));
            //HoughCircles(ref result);
            Cv2.ImShow("temp", RectangleImage);
            pictureBox1.Image = filter.cvtToBitmap(result);
        }

        /// <summary>
        /// 선의 길이에 따라 이미지 회전
        /// </summary>
        /// <param name="src">돌릴 이미지</param>
        private void imageRotate(ref Mat src)
        {
            int value = int.Parse(label13.Text);

            switch (value)
            {
                case 1146: Rotate(ref src, 0); break;
                case 382:Rotate(ref src, 45); break;
                case 617: Rotate(ref src, 90); break;
                case 1401: Rotate(ref src, 120); break;
                case 1239: Rotate(ref src, 180); break;
                case 1408: Rotate(ref src, 220); break;
                case 307: Rotate(ref src, 270); break;
                case 207: Rotate(ref src, 305); break;
            }
        }

        private void DrawCircle(ref Mat src, List<OpenCvSharp.Point> CirclePoints)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < CirclePoints.Count; i++) //Y축의 중간을 찾기 위해서 찾아진 좌표들중 0 이상의 Y좌표를 가져옴
            {
                if (CirclePoints[i].Y >= 0)
                {
                    indices.Add(CirclePoints[i].Y);
                }
            }

            int avg = (indices.Max() + indices.Min()) / 2; //평균 구하고
            for (int i = 0; i < CirclePoints.Count; i++)
            {
                if (CirclePoints[i].Y >= avg - 50 && CirclePoints[i].Y <= avg + 50) //Y축 평균을 기준으로 +-일정치 만큼 사이에있는 좌표에만 점으로 표시
                {
                    Cv2.Circle(src, new OpenCvSharp.Point(CirclePoints[i].X, CirclePoints[i].Y), 3, Scalar.Green, -1, LineTypes.AntiAlias);
                    if (a.X == 0)
                    {
                        a.X = CirclePoints[i].X;
                        a.Y = CirclePoints[i].Y;
                    }
                    else
                    {
                        b.X = CirclePoints[i].X;
                        b.Y = CirclePoints[i].Y;
                    }

                    //MessageBox.Show(points[i].ToString() + "\n평균 " + avg + " \n최소값 " + (avg - 50) + " \n최대값 " + (avg + 50));
                }
            }
        }

        private void HoughCircles(ref Mat src)
        {
            Mat gray = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(3, 3), 2);
            //Cv2.ImShow("gray", gray);
            //Cv2.HoughCircles(gray, HoughMethods.Gradient, 1, 100);
            var circles = Cv2.HoughCircles(gray, HoughMethods.Gradient, 5, 50, 1, 60, 1, 60);
            //찾은 결과가 없음
            foreach (CircleSegment item in circles)
            {
                if (item.Center.Y >= 230 && item.Center.Y <= 270)
                {
                    Cv2.Circle(src, (OpenCvSharp.Point)item.Center, (int)item.Radius, Scalar.Red, 2);
                    Cv2.PutText(src, item.Center.ToString(), (OpenCvSharp.Point)item.Center, HersheyFonts.HersheyScriptSimplex, 0.5, Scalar.GreenYellow);
                }
                /*else
                {
                    Cv2.Circle(src, (OpenCvSharp.Point)item.Center, (int)item.Radius, Scalar.Blue, 2);
                    Cv2.PutText(src, item.Center.ToString(), (OpenCvSharp.Point)item.Center, HersheyFonts.HersheyScriptSimplex, 0.5, Scalar.GreenYellow);
                }*/
            }
        }

        /// <summary>
        /// 이미지 중심 기준 회전
        /// </summary>
        /// <param name="src">이미지</param>
        /// <param name="angle">각도</param>
        public void Rotate(ref Mat src, int angle)
        {
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(src.Width / 2, src.Height / 2), angle, 1);
            Cv2.WarpAffine(src, src, matrix, src.Size(), InterpolationFlags.Linear);
        }

        /// <summary>
        /// 두 좌표의 중심 기준 이미지 회전
        /// </summary>
        /// <param name="src">이미지</param>
        /// <param name="angle">각도</param>
        /// <param name="point1">좌표1</param>
        /// <param name="point2">좌표2</param>
        public void Rotate(ref Mat src, int angle, Point point1, Point point2)
        {
            Point temp = new Point((point1.X + point2.X)/2, (point1.Y + point2.Y)/2);
            Mat matrix = Cv2.GetRotationMatrix2D(temp, angle, 1);
            Cv2.WarpAffine(src, src, matrix, src.Size(), InterpolationFlags.Linear);
        }



        /// <summary>
        /// 대각선 긋기
        /// </summary>
        /// <param name="src">이미지</param>
        /// <param name="rectList">검출된 결과</param>
        /// <param name="Length">윗쪽 선길이 기준</param>
        /// <param name="Length2">아래쪽 선길이 기준</param>
        private void DrawDiagonal(ref Mat src, List<Rect> rectList, int Length, int Length2)
        {
            Rect rect = new Rect();
            Rect rect1 = new Rect();
            for (int i = 0; i < rectList.Count; i++)
            {
                //위에서 가장 긴거
                if (rectList[i].Y < RectangleImage.Height / 2 && rect.Width < rectList[i].Width)
                {
                    rect.X = rectList[i].X;
                    rect.Y = rectList[i].Y;
                    rect.Width = rectList[i].Width;
                    rect.Height = rectList[i].Height;
                }

                //아래에서 가장 긴거
                if (rectList[i].Y >= RectangleImage.Height / 2 && rect1.Width < rectList[i].Width)
                {
                    rect1.X = rectList[i].X;
                    rect1.Y = rectList[i].Y;
                    rect1.Width = rectList[i].Width;
                    rect1.Height = rectList[i].Height;
                }
                //이거는 모든선 표시할때
                //Cv2.Line(temp, new OpenCvSharp.Point(rectList[i].X, rectList[i].Y), new OpenCvSharp.Point(rectList[i].X + rectList[i].Width, rectList[i].Y + rectList[i].Height), Scalar.Red, 3);

            }

            //조건에 따라 선 긋기
            _DrawDiagonal(ref src, rect, Length);
            _DrawDiagonal(ref src, rect1, Length2);

            //대각선 길이 표시
            //label6.Text = Math.Round(Math.Sqrt(Math.Pow(rect.X + rect.Width - rect.X, 2) + Math.Pow(rect.Y + rect.Height - rect.Y, 2))).ToString();
            label6.Text = Math.Round(Math.Sqrt(Math.Pow(rect.Width, 2) + Math.Pow(rect.Height, 2))).ToString();
            //label7.Text = Math.Round(Math.Sqrt(Math.Pow(rect1.X + rect1.Width - rect1.X, 2) + Math.Pow(rect1.Y + rect1.Height - rect1.Y, 2))).ToString();
            label7.Text = Math.Round(Math.Sqrt(Math.Pow(rect1.Width, 2) + Math.Pow(rect1.Height, 2))).ToString();
        }

        private void _DrawDiagonal(ref Mat src, Rect rect, int Length)
        {
            double temp = Math.Round(Math.Sqrt(Math.Pow(rect.Width, 2) + Math.Pow(rect.Height, 2)));
            if (temp < Length)
            {
                Cv2.Line(src, new Point(Rectlocation.X + rect.X, Rectlocation.Y + rect.Y), new Point(Rectlocation.X + rect.X + rect.Width, Rectlocation.Y + rect.Y + rect.Height), Scalar.Red, 5);
            }
            else
            {
                Cv2.Line(src, new Point(Rectlocation.X + rect.X, Rectlocation.Y + rect.Y), new Point(Rectlocation.X + rect.X + rect.Width, Rectlocation.Y + rect.Y + rect.Height), Scalar.SkyBlue, 5);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button1.Enabled = true;
                button1.BackColor = Color.LightGreen;
                //button2.BackColor = Color.LightCoral;
            }
            else
            {
                timer1.Start();
                button1.Enabled = false;
                button1.BackColor = Color.LightCoral;
                //button2.BackColor = Color.LightGreen;
            }
        }

        bool imgbool = false;
        private void button3_Click(object sender, EventArgs e)
        {
            mainPicturebox.Image = it.Load();
            return;
            if (imgbool)
            {
                mainPicturebox.Image = Image.FromFile(@"\\192.168.0.200\전체공유폴더\2022_업체별 자료실\22-(주)한국기능공사_클립검사\20220303\9.6_1.bmp");
                imgbool = false;
            }
            else
            {
                mainPicturebox.Image = Image.FromFile(@"\\192.168.0.200\전체공유폴더\2022_업체별 자료실\22-(주)한국기능공사_클립검사\20220303\9.6_2.bmp");
                imgbool = true;
            }
        }

        ImageTools it = new ImageTools();
        int i = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            for (i = 0; i < numericUpDown1.Value; i++)
            {
                it.Save(pictureBox1.Image);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            it.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            it.SetPath();
        }

        public static float GetAngle(Vector2 point, Vector2 center)
        {
            Vector2 relPoint = point - center;
            return (ToDegrees((float)Math.Atan2(relPoint.Y, relPoint.X)) + 450f) % 360f;
        }

        public static float ToDegrees(float radians) => (float)(radians * 180f / Math.PI);

        Vector2 a;
        Vector2 b;
        Vector2 centor;
        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"a = {a}, b = {b}");
            centor = new Vector2((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            MessageBox.Show(GetAngle(a, centor).ToString());
            MessageBox.Show(GetAngle(b, centor).ToString());
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
