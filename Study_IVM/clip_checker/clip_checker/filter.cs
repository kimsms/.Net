using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clip_checker
{
    internal class filter
    {
        /// <summary>
        /// Bitmap이나 Image를 Mat으로 변환함
        /// </summary>
        /// <param name="src">변환할 이미지</param>
        /// <returns>변환된 이미지</returns>
        public Mat cvtToMat(Bitmap src)
        {
            if (src == null)
                return null;
            return OpenCvSharp.Extensions.BitmapConverter.ToMat(src);
        }

        /// <summary>
        /// Bitmap이나 Image를 Mat으로 변환함
        /// </summary>
        /// <param name="src">변환할 이미지</param>
        /// <returns>변환된 이미지</returns>
        public Mat cvtToMat(Image src)
        {
            if (src == null)
                return null;
            return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)src);
        }

        /// <summary>
        /// Mat을 Bitmap으로 변환함
        /// </summary>
        /// <param name="src">변환할 이미지</param>
        /// <returns>변환된 이미지</returns>
        public Bitmap cvtToBitmap(Mat src)
        {
            if (src == null)
                return null;
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
        }

        /// <summary>
        /// 가우시안 블러를 입힘
        /// </summary>
        /// <param name="src">대상 이미지</param>
        /// <param name="size">사이즈</param>
        public void GaussianBlur(ref Mat src, OpenCvSharp.Size size)
        {
            Cv2.GaussianBlur(src, src, size, 1, 1, BorderTypes.Default);
        }

        /// <summary>
        /// 정규화
        /// </summary>
        /// <param name="src"></param>
        public void Normalization(ref Mat src)
        {
            //TODO 요놈이 문제 검은색으로 변경됨
            Cv2.Normalize(src, src, 1, 100, NormTypes.L2);
        }

        /// <summary>
        /// 이진화
        /// </summary>
        /// <param name="src">적용할 이미지</param>
        /// <param name="thresh">임곗값</param>
        /// <param name="maxval">최대값</param>
        /// <param name="types">임곗값 형식</param>
        /// <returns></returns>
        public void Threshold(ref Mat src, double thresh, double maxval, ThresholdTypes types)
        {
            if (src.Channels() != 1)
                Cv2.CvtColor(src, src, ColorConversionCodes.RGB2GRAY);
            Cv2.Threshold(src, src, thresh, maxval, types);
        }

        /// <summary>
        /// 가장자리 검출(Canny)
        /// </summary>
        /// <param name="src">적용할 이미지</param>
        /// <param name="threshold1">임계값1</param>
        /// <param name="threshold2">임계값2</param>
        public void CannyEdge(ref Mat src, double threshold1, double threshold2)
        {
            if (src.Channels() != 1)
                Cv2.CvtColor(src, src, ColorConversionCodes.RGB2GRAY);
            Cv2.Canny(src, src, threshold1, threshold2);
        }

        /// <summary>
        /// blob 표시
        /// </summary>
        /// <param name="src">적용할 이미지</param>
        public void blob(ref Mat src)
        {
            CvBlobs blobs = new CvBlobs();
            Mat mat = new Mat();
            if (src.Channels() != 1)
            {
                Cv2.CvtColor(src, mat, ColorConversionCodes.RGB2GRAY);
                Cv2.Threshold(mat, mat, 0, 255, ThresholdTypes.Otsu);
            }
            else
            {
                mat = src.Clone();
            }

            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            blobs.Label(mat);
            //blobs.RenderBlobs(src, result);
            foreach (var item in blobs)
            {
                /*CvBlob b = item.Value;
                Cv2.Circle(result, b.Contour.StartingPoint, 4, Scalar.Red, 2, LineTypes.AntiAlias);
                Cv2.PutText(result, b.Label.ToString(), new OpenCvSharp.Point(b.Centroid.X, b.Centroid.Y),
                     HersheyFonts.HersheyComplex, 1, Scalar.Yellow, 2, LineTypes.AntiAlias);*/
                CvBlob blob = item.Value;

                CvContourChainCode chainCode = blob.Contour;
                chainCode.Render(result);
            }
            src = result;
        }

        public int Contour(ref Mat src)
        {
            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            CvBlobs blobs = new CvBlobs();
            blobs.Label(src);
            CvBlob blob;
            int returnval = 0;
            foreach (var item in blobs)
            {
                blob = item.Value;
                CvContourChainCode chainCode = blob.Contour;
                chainCode.Render(result);
                //검출 조건 개수
                if (item.Key > returnval)
                {
                    returnval = item.Key;
                }
            }

            src = result;
            return returnval;
        }

        public void Sharpen(ref Mat src)
        {
            float[] data = new float[9] { 0, -1, 0, -1, 5, -1, 0, -1, 0 };
            Mat kernel = new Mat(3, 3, MatType.CV_32F, data);

            Cv2.Filter2D(src, src, src.Type(), kernel, new OpenCvSharp.Point(0, 0));
        }

        /// <summary>
        /// 영역 합성...
        /// </summary>
        /// <param name="Src">이미지 데이터 Mat 타입</param>
        /// <param name="Tool">검색 툴</param>
        /// <param name="nMarginX">합성하고 싶은 x의 거리</param>
        /// <param name="nMarginY">합성하고 싶은 y의 거리</param>
        /// <param name="DisableWidth">합성하고 난 후 영역에서 제외하고 싶은 넓이의 값</param>
        /// <param name="DisableHeight">합성하고 난 후 영역에서 제외하고 싶은 높이의 값</param>
        /// <param name="ThrValue">임계값</param>
        /// <returns>"List<CvRect>" 형식의 리턴</returns>        
        public List<Rect> MergeRect(Mat Src, BlobSub Tool, int nMarginX, int nMarginY, int DisableWidth, int DisableHeight, int ThrValue)
        {
            try
            {
                //using (new CvWindow(Src)) { Cv.WaitKey(); }

                List<Rect> Rect_Comp = new List<Rect>(); // 완료 리턴할 데이터
                List<Rect> Rect_Sort = new List<Rect>(); // 소팅 후 처리 된 데이터

                //Cv2.ImShow("src", Src);

                object[] Etemp1 = Tool.BlobCrop(Src, false, ThrValue);

                List<Rect> cRect = new List<Rect>(); // 블랍으로 검색 후 처리된 Rect의 List 컬렉션

                cRect = Etemp1[1] as List<Rect>;

                bool[] arrMerged = new bool[cRect.Count];

                for (int n = 0; n < cRect.Count; n++)
                    arrMerged[n] = false;

                cRect.Sort(delegate (Rect A, Rect B) // 
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


                    for (int j = 0; j < cRect.Count; j++)
                    {
                        if (i == j) continue;

                        //대상 블롭의 박스
                        Rectangle rectB = new Rectangle(Rect_Sort[j].X, Rect_Sort[j].Y,
                                                        Rect_Sort[j].Width, Rect_Sort[j].Height);
                        rectInter = Rectangle.Empty;

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

                            Rect_Sort[i] = new Rect(l1, t1, width, height);
                        }
                    }

                }

                for (int i = 0; i < Rect_Sort.Count; i++)
                {
                    if (Rect_Sort[i].Width < DisableWidth || Rect_Sort[i].Height < DisableHeight)
                        continue;

                    Rect_Comp.Add(Rect_Sort[i]);
                }

                return Rect_Comp;
            }
            catch (Exception ex)
            {
                WriteErrLog.ErrLog.Add(ex);
                return new List<Rect>();
            }
        }

        public List<OpenCvSharp.Point> CircleDetection(ref Mat src, bool Draw)
        {
            Mat result = new Mat(src.Size(), MatType.CV_8UC1);
            List<OpenCvSharp.Point> points = new List<OpenCvSharp.Point>();
            if (src.Channels() != 1)
            {
                Cv2.CvtColor(src, result, ColorConversionCodes.RGB2GRAY);
            }
            else
            {
                src.CopyTo(result);
            }

            Mat hierarchy = new Mat();
            Cv2.FindContours(result, out Mat[] contour, hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);
            for (int i = 0; i < contour.Length; i++)
            {
                Moments mmt = Cv2.Moments(contour[i]);
                double cx = mmt.M10 / mmt.M00, cy = mmt.M01 / mmt.M00;
                points.Add(new OpenCvSharp.Point(cx, cy));
                if(Draw)
                    Cv2.Circle(result, new OpenCvSharp.Point(cx, cy), 3, Scalar.Red, -1, LineTypes.AntiAlias);
            }
            //Cv2.ImShow("dst", result);
            
            src = result;
            return points;
        }
    }
}
