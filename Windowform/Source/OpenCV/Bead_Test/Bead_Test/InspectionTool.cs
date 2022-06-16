using OpenCvSharp;
using Setinspection;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bead_Test
{
    public class InspectionTool : IDisposable
    {
        BlobSub BsTool;

        List<CvRect> m_cvRect_Inspection_Area;
        List<CvRect> m_cvRect_HSV_Result;
        List<CvRect> m_cvRect_BlackPoint_Result;

        object Lock_Merge;
        object Lock_Image_Pros;
        object Lock_HSV_Find;
        object Lock_BlackPoint;

        public InspectionTool()
        {
            BsTool                      = new BlobSub();
            m_cvRect_Inspection_Area    = new List<CvRect>();
            m_cvRect_HSV_Result         = new List<CvRect>();
            m_cvRect_BlackPoint_Result  = new List<CvRect>();
            Lock_Merge                  = new object();
            Lock_Image_Pros             = new object();
            Lock_HSV_Find               = new object();
            Lock_BlackPoint             = new object();
        }

        ~InspectionTool()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                BsTool.Dispose();
            }
        }

        public IplImage RunPros(IplImage Get_LineScan_Image)
        {
           //using (new CvWindow(ImagePros(Get_LineScan_Image.Clone(), 100, 60))) { Cv.WaitKey(); }

            m_cvRect_Inspection_Area =  MergeRect(ImagePros(Get_LineScan_Image, 100, 60), BsTool, 5, 5, 150, 150, 60);
            HSV_Find                    (Get_LineScan_Image, BsTool, m_cvRect_Inspection_Area, 20, 60, 50, 2099);
            BlackPoint_Find             (Get_LineScan_Image, BsTool, m_cvRect_Inspection_Area,  0, 40, 1, 2099);

            for (int i = 0; i < m_cvRect_HSV_Result.Count; i++)
            {
                Get_LineScan_Image.PutText(i.ToString(),
                    new CvPoint(m_cvRect_HSV_Result[i].Right, m_cvRect_HSV_Result[i].Top),
                    new CvFont(FontFace.HersheyPlain, 1.0f, 1.5f),
                    new CvColor(255, 255, 255));
                CvRect Pos = new CvRect(m_cvRect_HSV_Result[i].X, m_cvRect_HSV_Result[i].Y, m_cvRect_HSV_Result[i].Width, m_cvRect_HSV_Result[i].Height);

                Get_LineScan_Image.DrawRect(Pos, CvColor.Red, 1);
            }

            for (int i = 0; i < m_cvRect_BlackPoint_Result.Count; i++)
            {
                Get_LineScan_Image.PutText(i.ToString(),
                    new CvPoint(m_cvRect_BlackPoint_Result[i].Right, m_cvRect_BlackPoint_Result[i].Top),
                    new CvFont(FontFace.HersheyPlain, 1.0f, 1.5f),
                    new CvColor(255, 255, 255));
                CvRect Pos = new CvRect(m_cvRect_BlackPoint_Result[i].X, m_cvRect_BlackPoint_Result[i].Y, m_cvRect_BlackPoint_Result[i].Width, m_cvRect_BlackPoint_Result[i].Height);

                Get_LineScan_Image.DrawRect(Pos, CvColor.Yellow, 1);
            }
            //using (new CvWindow(Get_LineScan_Image)) { Cv.WaitKey(); }

            return Get_LineScan_Image.Clone();
        }

        /// <summary>
        /// 이미지 재처리, 상하위 임계값을 주어 처리함.
        /// </summary>
        /// <param name="Src"> 처리대상의 이미지 </param>
        /// <param name="TheValeu_A">하한값</param>
        /// <param name="TheValeu_B">상한값</param>
        /// <returns>ipl이미지 타입으로 반환</returns>
        private IplImage ImagePros(IplImage Src, int TheValeu_A, int TheValeu_B )
        {
            lock (Lock_Image_Pros)
            {
                try
                {
                    m_cvRect_Inspection_Area.Clear();
                    m_cvRect_HSV_Result.Clear();
                    m_cvRect_BlackPoint_Result.Clear();
                    //m_cvRect_Inspection_Area = new List<CvRect>();                    

                    IplImage ProsEnd_Image = new IplImage(Src.Size, BitDepth.U8, 1);

                    using (IplImage DST = Src.Clone())
                    using (IplImage R = new IplImage(DST.Size, BitDepth.U8, 1))
                    using (IplImage G = new IplImage(DST.Size, BitDepth.U8, 1))
                    using (IplImage B = new IplImage(DST.Size, BitDepth.U8, 1))
                    {
                        Cv.Split(DST, R, G, B, null);
                        //R.SaveImage(@"d:\temp1\r.jpg");
                        //G.SaveImage(@"d:\temp1\g.jpg");
                        //B.SaveImage(@"d:\temp1\b.jpg");

                        IplImage Gray_ORI = new IplImage(B.Size, BitDepth.U8, 1);
                        Cv.Copy(B, Gray_ORI);


                        IplImage GrayIMG1 = Gray_ORI.Clone();
                        IplImage GrayIMG2 = Gray_ORI.Clone();

                        IplImage BinaryIMG = new IplImage(Gray_ORI.Size, BitDepth.U8, 1);

                        Cv.Smooth(GrayIMG1, GrayIMG1, SmoothType.Gaussian);
                        Cv.Smooth(GrayIMG2, GrayIMG2, SmoothType.Gaussian);

                        Cv.Threshold(GrayIMG1, GrayIMG1, TheValeu_A, 255, ThresholdType.Binary);
                        Cv.Threshold(GrayIMG2, GrayIMG2, TheValeu_B, 255, ThresholdType.BinaryInv);

                        BinaryIMG.Add(GrayIMG1, BinaryIMG);
                        BinaryIMG.Add(GrayIMG2, BinaryIMG);

                        BinaryIMG.Erode(BinaryIMG, null, 1);

                        ProsEnd_Image = BinaryIMG.Clone();
                    }

                    //using (new CvWindow("ProImg",ProsEnd_Image)) { Cv.WaitKey(); }
                    return ProsEnd_Image;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 영역 합성...
        /// </summary>
        /// <param name="Src">이미지 데이터 IPL 타입</param>
        /// <param name="Tool">검색 툴</param>
        /// <param name="nMarginX">합성하고 싶은 x의 거리</param>
        /// <param name="nMarginY">합성하고 싶은 y의 거리</param>
        /// <param name="DisableWidth">합성하고 난 후 영역에서 제외하고 싶은 넓이의 값</param>
        /// <param name="DisableHeight">합성하고 난 후 영역에서 제외하고 싶은 높이의 값</param>
        /// <param name="ThrValue">임계값</param>
        /// <returns>"List<CvRect>" 형식의 리턴</returns>        
        public List<CvRect> MergeRect(IplImage Src, BlobSub Tool,int nMarginX, int nMarginY, int DisableWidth, int DisableHeight, int ThrValue)
        {
            lock (Lock_Merge)
            {
                try
                {
                    //using (new CvWindow(Src)) { Cv.WaitKey(); }

                    List<CvRect> Rect_Comp = new List<CvRect>(); // 완료 리턴할 데이터
                    List<CvRect> Rect_Sort = new List<CvRect>(); // 소팅 후 처리 된 데이터

                    object[] Etemp1 = Tool.BlobCrop(Src, false, ThrValue);

                    List<CvRect> cRect = new List<CvRect>(); // 블랍으로 검색 후 처리된 Rect의 List 컬렉션

                    cRect = Etemp1[1] as List<CvRect>;

                    bool[] arrMerged = new bool[cRect.Count];

                    for (int n = 0; n < cRect.Count; n++)
                        arrMerged[n] = false;

                    cRect.Sort(delegate (CvRect A, CvRect B) // 
                    {
                        if (A.X > B.X && A.Y > B.Y) return 1;
                        else if (A.X > B.X && A.Y > B.Y) return -1;
                        return 0;
                    });

                    Rect_Sort.AddRange(cRect);
                    
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
                        r1 = Rect_Sort[i].X + cRect[i].Width;
                        b1 = Rect_Sort[i].Y + cRect[i].Height;
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

                                Rect_Sort[i] = new CvRect(l1, t1, width, height);
                            }
                        }

                    }

                    for (int i = 0; i < Rect_Sort.Count; i++)
                    {
                        if (arrMerged[i])
                            continue;
                        if (Rect_Sort[i].Width > DisableWidth || Rect_Sort[i].Height > DisableHeight)
                            continue;

                        Rect_Comp.Add(Rect_Sort[i]);
                    }

                    return Rect_Comp;
                }
                catch (Exception)
                {
                    return new List<CvRect>();
                }
            }
        }
        /// <summary>
        /// HSV 테이블을 이용한 이미지 컬러 검사
        /// </summary>
        /// <param name="Src">대상 이미지 NCh == 3 </param>
        /// <param name="Tool">BlobSub 클래스 타입</param>
        /// <param name="RectData"> 검출해야하는 영역의 "List<CvRect>" 타입 </param>
        /// <param name="RangeA">검출해야하는 HSV 테이블 값의 Min</param>
        /// <param name="RangeB">검출해야하는 HSV 테이블 값의 Max</param>
        /// <param name="TFValue">임계값</param>
        /// <param name="SizeLimit">즉정대상의 렉 사이즈가 넘으면 검사 패스</param>
        private void HSV_Find(IplImage Src, BlobSub Tool, List<CvRect> RectData, int RangeA, int RangeB, double TFValue, int SizeLimit)
        {
            lock (Lock_HSV_Find)
            {
                for (int i = 0; i < RectData.Count; i++)
                {
                    IplImage HSV_Img = Src.GetSubImage(RectData[i]);

                    object[] HSV = Tool.HSV_Conv(HSV_Img, RangeA, RangeB);
                    int Area = (int)HSV[0];

                    int SizeTotal = HSV_Img.Width * HSV_Img.Height;
                    if (SizeTotal < SizeLimit) continue;

                    double Judge = ((double)Area / (double)SizeTotal) * 100;

                    if (Judge > TFValue)
                    {
                        m_cvRect_HSV_Result.Add(RectData[i]);
                    }
                }
            }
        }
        /// <summary>
        /// 검사 대상의 흑점을 검사
        /// </summary>
        /// <param name="Src">대상 이미지 NCh == 3 </param>
        /// <param name="Tool">BlobSub 클래스 타입</param>
        /// <param name="RectData"> 검출해야하는 영역의 "List<CvRect>" 타입 </param>
        /// <param name="RangeA">검출해야하는 HSV 테이블 값의 Min</param>
        /// <param name="RangeB">검출해야하는 HSV 테이블 값의 Max</param>
        /// <param name="TFValue">임계값</param>
        /// <param name="SizeLimit">즉정대상의 렉 사이즈가 넘으면 검사 패스</param>
        private void BlackPoint_Find(IplImage Src, BlobSub Tool, List<CvRect> RectData, int RangeA, int RangeB, double TFValue, int SizeLimit)
        {
            lock (Lock_BlackPoint)
            {
                IplImage Gray = new IplImage(Src.Size, BitDepth.U8, 1);

                if(Src.NChannels > 1)
                {
                    Cv.CvtColor(Src, Gray, ColorConversion.RgbToGray);
                }
                else
                {
                    Cv.Copy(Src, Gray);
                }

                for (int i = 0; i < RectData.Count; i++)
                {
                    IplImage BP_Img = Gray.GetSubImage(RectData[i]);

                    Cv.InRangeS(BP_Img, RangeA, RangeB, BP_Img);

                    int Area = 0;

                    int SizeTotal = BP_Img.Width * BP_Img.Height;
                    if (SizeTotal < SizeLimit) continue;

                    byte[] Temp = BP_Img.ToBytes(".bmp");

                    int PixelStartPos = BitConverter.ToInt32(Temp, 10);

                    for (int f = PixelStartPos; f < PixelStartPos + SizeTotal; f++)
                    {
                        int t = Temp[f];

                        if (t > 1)
                            Area++;
                    }

                    double Judge = ((double)Area / (double)SizeTotal) * 100;

                    if (Judge >= TFValue)
                    {
                        m_cvRect_BlackPoint_Result.Add(RectData[i]);
                    }
                }
            }           
        }
        ///////////////////////////////



    }
}
