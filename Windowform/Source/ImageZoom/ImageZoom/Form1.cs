using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageZoom
{
    public partial class Form1 : Form
    {
        // 사각형 도형 표시 flag
        bool squareFigureDisplayFlag = false;

        // 원본 이미지에 표시할 시작 좌표입니다.
        System.Drawing.Point startPoint;

        // 원본 이미지에 표시할 끝 좌표입니다.
        System.Drawing.Point endPoint;

        // 자를 이미지의 시작 좌표
        System.Drawing.Point CropImageStartPoint;

        // 자를 이미지의 끝 좌표
        System.Drawing.Point CropImageEndPoint;

        int pictureBoxWidth;
        int pictureBoxHeight;
        int imageWidth;
        int imageHeight;

        private double ratio = 1.0F;
        private Point imgPoint;
        private Rectangle imgRect;
        public Form1()
        {
            InitializeComponent();

            pictureBox1.MouseWheel += pictureBox1_MouseWheel2;

            imgPoint = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            imgRect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            ratio = 1.0;
            pictureBox1.Invalidate();
        }

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
            else
            {
                imgPoint = new Point(e.X, e.Y);
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

                }
                catch (OutOfMemoryException)
                {
                    //MessageBox.Show("마우스가 영역을 벗어남");
                    return;
                }
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

            if(pictureBox1.Image != null && !squareFigureDisplayFlag)
            {
                //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                e.Graphics.DrawImage(pictureBox1.Image, imgRect);
                pictureBox1.Focus();
            }
        }

        //이미지 줌
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int ZoomSpeed = 100; //확대 속도
            double magnification = 6; //확대 배율

            if (lines > 0)
            {
                //확대 크기 제한
                if ((float)pictureBox1.Width / (float)panel1.Width > magnification) return;

                pictureBox1.Size = new System.Drawing.Size(pictureBox1.Width + ZoomSpeed, pictureBox1.Height + ZoomSpeed);
            }
            else if (lines < 0)
            {
                //축소 한계치
                if (pictureBox1.Size.Width <= panel1.Size.Width) return;


                pictureBox1.Size = new System.Drawing.Size(pictureBox1.Width - ZoomSpeed, pictureBox1.Height - ZoomSpeed);
            }
        }

        private void pictureBox1_MouseWheel2(object sender, MouseEventArgs e)
        {
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            PictureBox pb = (PictureBox)sender;

            if (lines > 0)
            {
                ratio *= 1.1F;
                if (ratio > 100.0) ratio = 100.0f;

                imgRect.Width = (int)Math.Round(pictureBox1.Width * ratio);
                imgRect.Height = (int)Math.Round(pictureBox1.Height * ratio);
                imgRect.X = -(int)Math.Round(1.1F * (imgPoint.X - imgRect.X) - imgPoint.X);
                imgRect.Y = -(int)Math.Round(1.1F * (imgPoint.Y - imgRect.Y) - imgPoint.Y);
            }
            else if (lines < 0)
            {
                ratio *= 0.9F;
                if (ratio < 1) ratio = 1;

                imgRect.Width = (int)Math.Round(pictureBox1.Width * ratio);
                imgRect.Height = (int)Math.Round(pictureBox1.Height * ratio);
                imgRect.X = -(int)Math.Round(0.9F * (imgPoint.X - imgRect.X) - imgPoint.X);
                imgRect.Y = -(int)Math.Round(0.9F * (imgPoint.Y - imgRect.Y) - imgPoint.Y);
            }

            if (imgRect.X > 0) imgRect.X = 0;
            if (imgRect.Y > 0) imgRect.Y = 0;
            if (imgRect.X + imgRect.Width < pictureBox1.Width) imgRect.X = pictureBox1.Width - imgRect.Width;
            if (imgRect.Y + imgRect.Height < pictureBox1.Height) imgRect.Y = pictureBox1.Height - imgRect.Height;
            pictureBox1.Invalidate();
        }

    }

}
