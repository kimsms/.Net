using AForge.Imaging.Filters;
using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.Extensions;
using OpenCvSharp.Utilities;
using Setinspection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bead_Test
{
    public partial class Form1 : Form
    {
        BlobSub Bs;

        List<CvRect> pRect = new List<CvRect>();

        public Form1()
        {
            InitializeComponent();
            Bs = new BlobSub();
        }
                
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBoxIpl1.ImageIpl = Cv.LoadImage(@"d:\Sample_test.jpg");
            pictureBoxIpl1.ImageIpl = Cv.LoadImage(@".\Sample_test.jpg");

            pictureBoxIpl1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBoxIpl1.Size = new Size(pictureBoxIpl1.ImageIpl.Width, pictureBoxIpl1.ImageIpl.Height);

            label1.Text = hScrollBar1.Value.ToString();
            label2.Text = hScrollBar2.Value.ToString();

            button1_Click(sender, e);

        }
        IplImage B_img;

        private void button1_Click(object sender, EventArgs e)
        {
            //IplImage Temp = Cv.LoadImage(@"d:\Sample_test.jpg");
            IplImage Temp = Cv.LoadImage(@".\Sample_test.jpg");
            using (IplImage DST = Temp.Clone())
            using (IplImage R = new IplImage(DST.Size, BitDepth.U8, 1))
            using (IplImage G = new IplImage(DST.Size, BitDepth.U8, 1))
            using (IplImage B = new IplImage(DST.Size, BitDepth.U8, 1))
            {
                Cv.Split(DST, R, G, B, null);
                R.SaveImage(Application.StartupPath + @"\temp\r.jpg");
                G.SaveImage(Application.StartupPath + @"\temp\g.jpg");
                B.SaveImage(Application.StartupPath + @"\temp\b.jpg");

                B_img = B.Clone();
            }

            using (InspectionTool IT = new InspectionTool())
            {
               pictureBoxIpl1.ImageIpl = IT.RunPros(Temp.Clone()).Clone();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();

            pRect = new List<CvRect>();

            pictureBoxIpl1.ImageIpl = Cv.LoadImage(@".\Sample_test.jpg");
            pictureBoxIpl1.SizeMode = PictureBoxSizeMode.Normal;

            IplImage Temp = pictureBoxIpl1.ImageIpl.Clone();
            Temp = B_img.Clone();
            sw.Start();

            IplImage Gray_ORI = new IplImage(Temp.Size, BitDepth.U8, 1);
            
            // Cv.CvtColor(Temp.Clone(), Gray_ORI, ColorConversion.RgbToGray);
            Cv.Copy(Temp, Gray_ORI);


            IplImage GrayIMG1 = Gray_ORI.Clone();
            IplImage GrayIMG2 = Gray_ORI.Clone();

            IplImage BinaryIMG = new IplImage(Gray_ORI.Size, BitDepth.U8, 1);

            Cv.Smooth(GrayIMG1, GrayIMG1, SmoothType.Gaussian);
            Cv.Smooth(GrayIMG2, GrayIMG2, SmoothType.Gaussian);


            Cv.Threshold(GrayIMG1, GrayIMG1, hScrollBar1.Value, 255, ThresholdType.Binary);
            //using (new CvWindow(GrayIMG1)) { Cv.WaitKey(); }
            Cv.Threshold(GrayIMG2, GrayIMG2, hScrollBar2.Value, 255, ThresholdType.BinaryInv);
            //using (new CvWindow(GrayIMG2)) { Cv.WaitKey(); }

            BinaryIMG.Add(GrayIMG1, BinaryIMG);
            BinaryIMG.Add(GrayIMG2, BinaryIMG);

            BinaryIMG.Erode(BinaryIMG, null, 1);

            //BinaryIMG.SaveImage(@"d:\Sig\Binary.jpg");
           // using (new CvWindow(BinaryIMG)) { Cv.WaitKey(); }


            List<CvRect> Rect_Comp = new List<CvRect>();
            List<CvRect> Rect_Sort = new List<CvRect>();
            List<CvPoint> cPoint = new List<CvPoint>();
            //////////////////////////////////////////////////////////////////////////////////////

            List<CvRect> cRect = MergeRect_Y(BinaryIMG);
            InspectionTool IT = new InspectionTool();

            cRect = IT.MergeRect(BinaryIMG, Bs,
                Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 150, 150, hScrollBar2.Value);

            pRect = cRect;

            sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString() + "ms");

            Temp = Cv.LoadImage(@".\Sample_test.jpg");

            for (int i = 0; i < cRect.Count; i++)
            {
                Temp.PutText(i.ToString(),
                    new CvPoint(cRect[i].Right, cRect[i].Top),
                    new CvFont(FontFace.HersheyPlain, 1.0f, 1.5f),
                    new CvColor(255, 255, 255));
                CvRect Pos = new CvRect(cRect[i].X, cRect[i].Y, cRect[i].Width, cRect[i].Height);

                Temp.DrawRect(Pos, CvColor.Red, 1);
            }
            
            pictureBoxIpl1.ImageIpl = Temp;
        }

        //public List<CvRect> MergeRect_X(IplImage Src)
        //{
        //    List<CvRect> Rect_Comp = new List<CvRect>();
        //    List<CvRect> Rect_Sort = new List<CvRect>();
        //    List<CvPoint> cPoint = new List<CvPoint>();
        //    //////////////////////////////////////////////////////////////////////////////////////

        //    object[] Etemp1 = Bs.BlobCrop(Src, false, hScrollBar2.Value);

        //    List<CvRect> cRect = new List<CvRect>();

        //    cRect = Etemp1[1] as List<CvRect>;
        //    cPoint = Etemp1[4] as List<CvPoint>;

        //    List<int> UsedNumber = new List<int>(cRect.Count);// 블롭된 박스의 개수만큼 미리 할당

        //    bool[] arrMerged = new bool[cRect.Count];

        //    for (int n = 0; n < cRect.Count; n++)
        //        arrMerged[n] = false;
            
        //    cRect.Sort(delegate (CvRect A, CvRect B)
        //    {
        //        if (A.X > B.X) return 1;
        //        else if (A.X < B.X) return -1;
        //        return 0;
        //    });

        //    Rect_Sort.AddRange(cRect);

        //    Rect_Comp.Clear();

        //    int nMarginX = Convert.ToInt32(textBox1.Text);
        //    int nMarginY = Convert.ToInt32(textBox2.Text);

        //    Rectangle rectInter = new Rectangle();

        //    int l1, t1, r1, b1;
        //    int l2, t2, r2, b2;
        //    for (int i = 0; i < Rect_Sort.Count; i++)
        //    {
        //        if (nMarginX == 0)
        //            continue;
        //        if (arrMerged[i])
        //            continue;

        //        l1 = Rect_Sort[i].X;
        //        t1 = Rect_Sort[i].Y;
        //        r1 = Rect_Sort[i].X + Rect_Sort[i].Width;
        //        b1 = Rect_Sort[i].Y + Rect_Sort[i].Height;
        //        //현재 블롭의 박스
        //        Rectangle rectA = new Rectangle(Rect_Sort[i].X - nMarginX, Rect_Sort[i].Y,
        //                                                Rect_Sort[i].Width + nMarginX * 2, Rect_Sort[i].Height);

        //        //가로세로 5미만 머지 안함
        //        if (rectA.Width < 5)
        //            continue;

        //        for (int j = 0; j < Rect_Sort.Count; j++)
        //        {
        //            if (i == j) continue;
        //            if (Rect_Sort[i].X < 5) continue;

        //            //대상 블롭의 박스
        //            Rectangle rectB = new Rectangle(Rect_Sort[j].X, Rect_Sort[j].Y,
        //                                            Rect_Sort[j].Width, Rect_Sort[j].Height);
        //            rectInter = Rectangle.Empty;

        //            //가로세로 5미만 머지 안함
        //            if (rectB.Width < 5 && rectB.Height < 5)
        //                continue;

        //            //각각의 박스가 중첩되는지?
        //            rectInter = Rectangle.Intersect(rectA, rectB);

        //            if (!rectInter.IsEmpty)
        //            {
        //                l2 = Rect_Sort[j].X;
        //                t2 = Rect_Sort[j].Y;
        //                r2 = Rect_Sort[j].X + Rect_Sort[j].Width;
        //                b2 = Rect_Sort[j].Y + Rect_Sort[j].Height;

        //                arrMerged[j] = true;

        //                if (l1 > l2)
        //                    l1 = l2;
        //                if (t1 > t2)
        //                    t1 = t2;
        //                if (r1 < r2)
        //                    r1 = r2;
        //                if (b1 < b2)
        //                    b1 = b2;

        //                int width = r1 - l1;
        //                int height = b1 - t1;
        //                rectA = new Rectangle(l1 - nMarginX, t1 - nMarginY, width + nMarginX * 2, height);

        //                CvRect cvRect = new CvRect(l1, t1, width, height);
        //                Rect_Sort[i] = cvRect;
        //            }
        //        }

        //    }

        //    for (int i = 0; i < Rect_Sort.Count; i++)
        //    {
        //        if (arrMerged[i])
        //            continue;
        //        if (Rect_Sort[i].Width > 300)
        //            continue;

        //        Rect_Comp.Add(Rect_Sort[i]);
        //    }

        //    //////////////////////////////////////////////////////////////////////////////////////

        //    return MergeRect_Y(Src);
        //}

        public List<CvRect> MergeRect_Y(IplImage Src)
        {
            List<CvRect> Rect_Comp = new List<CvRect>();
            List<CvRect> Rect_Sort = new List<CvRect>();
            //////////////////////////////////////////////////////////////////////////////////////

            object[] Etemp1 = Bs.BlobCrop(Src, false, hScrollBar2.Value);

            List<CvRect> cRect = new List<CvRect>();

            cRect = Etemp1[1] as List<CvRect>;
          
            bool[] arrMerged = new bool[cRect.Count];

            for (int n = 0; n < cRect.Count; n++)
                arrMerged[n] = false;
            
            cRect.Sort(delegate (CvRect A, CvRect B)
            {
                if (A.X > B.X && A.Y > B.Y) return 1;
                else if (A.X > B.X && A.Y > B.Y) return -1;
                return 0;
            });

            Rect_Sort.AddRange(cRect);

            int nMarginX = Convert.ToInt32(textBox1.Text);
            int nMarginY = Convert.ToInt32(textBox2.Text);

            Rectangle rectInter = new Rectangle();

            int l1, t1, r1, b1;
            int l2, t2, r2, b2;
            for (int i = 0; i < cRect.Count; i++)
            {
                if (nMarginX == 0 || nMarginY == 0)
                    continue;
                if (arrMerged[i])
                    continue;

                l1 = Rect_Sort[i].X;
                t1 = Rect_Sort[i].Y;
                r1 = Rect_Sort[i].X + Rect_Sort[i].Width;
                b1 = Rect_Sort[i].Y + Rect_Sort[i].Height;
                //현재 블롭의 박스
                Rectangle rectA = new Rectangle(Rect_Sort[i].X - nMarginX, Rect_Sort[i].Y - nMarginY,
                                                        Rect_Sort[i].Width + nMarginX * 2, Rect_Sort[i].Height + nMarginY * 2);

                //가로세로 5미만 머지 안함
                if (rectA.Width < 5 || rectA.Height < 5)
                    continue;

                for (int j = 0; j < cRect.Count; j++)
                {
                    if (i == j) continue;
                    if (Rect_Sort[i].X < 5 || Rect_Sort[i].Y < 5) continue;

                    //대상 블롭의 박스
                    Rectangle rectB = new Rectangle(Rect_Sort[j].X, Rect_Sort[j].Y,
                                                    Rect_Sort[j].Width, Rect_Sort[j].Height);
                    rectInter = Rectangle.Empty;

                    //가로세로 5미만 머지 안함
                    if (rectB.Width < 5 || rectB.Height < 5)
                        continue;

                    //각각의 박스가 중첩되는지?
                    rectInter = Rectangle.Intersect(rectA, rectB);

                    if (!rectInter.IsEmpty)
                    {
                        l2 = Rect_Sort[j].X;
                        t2 = Rect_Sort[j].Y;
                        r2 = Rect_Sort[j].X + Rect_Sort[j].Width;
                        b2 = Rect_Sort[j].Y + Rect_Sort[j].Height;

                        arrMerged[j] = true;

                        if (l1 > l2)
                            l1 = l2;
                        if (t1 > t2)
                            t1 = t2;
                        if (r1 < r2)
                            r1 = r2;
                        if (b1 < b2)
                            b1 = b2;

                        int width = r1 - l1;
                        int height = b1 - t1;
                        //rectA = new Rectangle(l1 - nMarginX, t1 - nMarginY, width + nMarginX * 2, height + nMarginY * 2);

                        // CvRect cvRect = new CvRect(l1, t1, width, height);
                        Rect_Sort[i] = new CvRect(l1, t1, width, height);
                    }
                }

            }

            for (int i = 0; i < Rect_Sort.Count; i++)
            {
                if (arrMerged[i])
                    continue;
                if (Rect_Sort[i].Width > 150 || Rect_Sort[i].Height > 150) 
                    continue;

                Rect_Comp.Add(Rect_Sort[i]);
            }

            //////////////////////////////////////////////////////////////////////////////////////

            return Rect_Comp;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = hScrollBar1.Value.ToString();

            IplImage temp = B_img.Clone(); //Cv.LoadImage(@"d:\Sample_test.jpg");
            IplImage GrayI = new IplImage(temp.Size, BitDepth.U8, 1);
            IplImage Org = new IplImage(temp.Size, BitDepth.U8, 1);
            IplImage BinaryI = new IplImage(temp.Size, BitDepth.U8, 1);

            if (temp.NChannels > 1)
            {
                Cv.CvtColor(temp, GrayI, ColorConversion.RgbToGray);
                //Org = GrayI.Clone();

                //Cv.Smooth(GrayI, GrayI, SmoothType.Gaussian, 3, 3, 1.0f);
                //Cv.Sobel(GrayI, GrayI, 1, 1, ApertureSize.Size5);

                //Cv.Add(Org, GrayI, GrayI);
                //Cv.Smooth(GrayI, GrayI, SmoothType.Gaussian, 3, 3, 1.0f);
            }
            else
            {
                Cv.Copy(temp, GrayI);
            }

            try
            {
                Cv.Threshold(GrayI, BinaryI, hScrollBar1.Value, 255, ThresholdType.Binary);
                pictureBoxIpl1.ImageIpl = BinaryI;
            }
            catch
            { }
        }
        
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = hScrollBar2.Value.ToString();

            IplImage temp = B_img.Clone();// Cv.LoadImage(@".\Sample_test.jpg");
            IplImage GrayI = new IplImage(temp.Size, BitDepth.U8, 1);
            IplImage Org = new IplImage(temp.Size, BitDepth.U8, 1);
            IplImage BinaryI = new IplImage(temp.Size, BitDepth.U8, 1);

            if (temp.NChannels > 1)
            {
                Cv.CvtColor(temp, GrayI, ColorConversion.RgbToGray);
                //Org = GrayI.Clone();

                //Cv.Smooth(GrayI, GrayI, SmoothType.Gaussian, 3, 3, 1.0f);
                //Cv.Sobel(GrayI, GrayI, 1, 1, ApertureSize.Size5);

                //Cv.Add(Org, GrayI, GrayI);
                //Cv.Smooth(GrayI, GrayI, SmoothType.Gaussian, 3, 3, 1.0f);
            }
            else
            {
                Cv.Copy(temp, GrayI);
            }

            try
            {
                Cv.Threshold(GrayI, BinaryI, hScrollBar2.Value, 255, ThresholdType.BinaryInv);
                pictureBoxIpl1.ImageIpl = BinaryI;
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IplImage temp = Cv.LoadImage(@".\Sample_test.jpg");

            Stopwatch sw = new Stopwatch();
            sw.Start();


            List<CvRect> jRect = new List<CvRect>();
            //Parallel.For(0, pRect.Count, (i) =>
            //{
            for (int i = 0; i < pRect.Count; i++)
            {
                IplImage HSV_Img = temp.GetSubImage(pRect[i]);

                object[] HSV = Bs.HSV_Conv(HSV_Img, Convert.ToInt32(textBox3.Text.ToString()), Convert.ToInt32(textBox4.Text.ToString()));
                int Area = (int)HSV[0];
                //CvRect cRect = (CvRect)HSV[1];

                int SizeTotal = HSV_Img.Width * HSV_Img.Height;
                if (SizeTotal < 2090) continue;

                //Area = cRect.Width * cRect.Height;

                double Judge = ((double)Area / (double)SizeTotal) * 100;

                if (Judge > Convert.ToDouble(textBox5.Text.ToString()))
                {
                    jRect.Add(pRect[i]);
                }
            }
            //});

            
            sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString() + "ms");


            for (int i = 0; i < jRect.Count; i++)
            {
                temp.DrawRect(jRect[i], CvColor.Red, 2);
            }

            pictureBoxIpl1.ImageIpl = temp.Clone();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IplImage temp = Cv.LoadImage(@".\Sample_test.jpg");
            IplImage Gray = new IplImage(temp.Size, BitDepth.U8, 1);

            Stopwatch sw = new Stopwatch();
      

            Cv.CvtColor(temp, Gray, ColorConversion.RgbToGray);

            List<CvRect> jRect = new List<CvRect>();
             sw.Start();

            //Parallel.For(0, pRect.Count, (i) =>
            //{
            for (int i = 0; i < pRect.Count; i++)
            {
                IplImage BP_Img = Gray.GetSubImage(pRect[i]);
                
                Cv.InRangeS(BP_Img, Convert.ToInt32(textBox8.Text.ToString()), Convert.ToInt32(textBox7.Text.ToString()), BP_Img);

                //BP_Img.SaveImage(@"D:\Sig\" + i.ToString() + ".jpg");
                //using (new CvWindow(BP_Img)) { Cv.WaitKey(); }

                int Area = 0;

                ////Parallel.For(0, BP_Img.Width, (j) =>
                ////{
                //for (int j = 0; j < BP_Img.Width; j++)
                //{
                //    for (int k = 0; k < BP_Img.Height; k++)
                //    {
                //        CvScalar val = BP_Img.Get2D(k, j);
                //        if (val[0] < Convert.ToInt32(textBox8.Text.ToString()))
                //            Area++;
                //    }
                //}
                ////});
                
                int SizeTotal = BP_Img.Width * BP_Img.Height;

                if (SizeTotal < 2090) continue;

                byte[] Temp = BP_Img.ToBytes(".bmp");
                
                int PixelStartPos = BitConverter.ToInt32(Temp, 10) ;             

                for (int f = PixelStartPos; f < PixelStartPos + SizeTotal; f++)
                {
                    int t = Temp[f];

                    if (t > 1)
                        Area++;
                }
             
                double Judge = ((double)Area / (double)SizeTotal) * 100;
              
                if (Judge >= Convert.ToDouble(textBox6.Text.ToString()))
                {
                    jRect.Add(pRect[i]);
                }
            }
        //});
           sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString() + "ms");

            for (int i = 0; i < jRect.Count; i++)
            {
                temp.DrawRect(jRect[i], CvColor.Red, 2);
            }

            pictureBoxIpl1.ImageIpl = temp.Clone();
        }

        private void pictureBoxIpl1_Click(object sender, EventArgs e)
        {
            
        }
        

        bool isDragging = false;
        Point move;

        void pictureBoxIpl1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            move = e.Location;
        }

        void pictureBoxIpl1_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDragging == true)
            {
                pictureBoxIpl1.Left += e.X - move.X;
                pictureBoxIpl1.Top += e.Y - move.Y;
            }
        }

        void pictureBoxIpl1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
