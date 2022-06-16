using System;
using System.Collections.Generic;

using OpenCvSharp;
using OpenCvSharp.Blob;
//using OpenCvSharp.CPlusPlus;
//using AForge.Imaging.Filters;


namespace clip_checker
{
    public class BlobSub : IDisposable
    {
        public BlobSub()
        {

        }
        ~BlobSub()
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

            }
        }
       
        public object[] HSV_Conv(Mat SRC, int Min, int Max)
        {
            object[] Result = new object[3];
            Mat[] HSV = new Mat[3];

            using (Mat DST = new Mat(SRC.Size(), MatType.CV_8UC3))
            //using (Mat H = new Mat(SRC.Size(), MatType.CV_8UC3))
            //using (Mat S = new Mat(SRC.Size(), MatType.CV_8UC3))
            //using (Mat V = new Mat(SRC.Size(), MatType.CV_8UC3))
            {
                Cv2.CvtColor(SRC, DST, ColorConversionCodes.RGB2HSV);
                Cv2.Split(DST, out HSV);
                //H.SaveImage(@"d:\temp\H.jpg");
                //S.SaveImage(@"d:\temp\S.jpg");
                //V.SaveImage(@"d:\temp\V.jpg");

                Cv2.InRange(HSV[0], Min, Max, HSV[0]);

                Cv2.Threshold(HSV[0], HSV[0], 1, 255, ThresholdTypes.BinaryInv);

                int CountWhite = 0;

                //for (int i = 0; i < H.Width; i++)
                //{
                //    for (int j = 0; j < H.Height; j++)
                //    {
                //        CvScalar val = H.Get2D(j, i);
                //        if (val[0] > 1) 
                //            CountWhite++;
                //    }
                //}

                byte[] Temp = HSV[0].ToBytes(".bmp");

                int PixelStartPos = BitConverter.ToInt32(Temp, 10);
           
                for (int f = PixelStartPos; f < PixelStartPos + ( HSV[0].Width * HSV[0].Height ); f++)
                {
                    int t = Temp[f];

                    if (t > 1)
                        CountWhite++;
                }

                Result[0] = CountWhite;
                
                //using (new CvWindow( CountWhite.ToString(), H)) { Cv.WaitKey(); }
                //H.SaveImage(@"d:\temp\H1.jpg");
                //CvBlobs T = new CvBlobs(H);
                //CvBlob T1 = T.LargestBlob();

                //DST.SetZero();
                //Result_IMG = DST.Clone();

                //  Result_IMG.DrawImage(T1.Rect.X, T1.Rect.Y, T1.Rect.Width - 1, T1.Rect.Height - 1, SRC.GetSubImage(T1.Rect));

                //Result[0] = T1.Area;
                //Result[1] = T1.Rect;
            }

            return Result;
        }

        ///ksm 20220324
        ///임시로 비활성화 시킴
        //public object[] BlobSize(Mat OP1, int ThresholVal, bool invBinary, string Num)
        //{
        //    object[] result = null;
        //    result = new object[3];

        //    List<Rect> cRect = new List<Rect>();
        //    List<double> cArea = new List<double>();

        //    try
        //    {
        //        using (Mat SRC_Copy = OP1.Clone())
        //        using (Mat imgBinary = new Mat(OP1.Size(), MatType.CV_8UC1))
        //        using (Mat DST = new Mat(OP1.Size(), OP1.Depth(), 1))
        //        {
        //            {
        //                {
        //                    Cv2.CvtColor(SRC_Copy.Clone(), DST, ColorConversionCodes.RGB2GRAY);

        //                    if (!invBinary)
        //                        Cv2.Threshold(DST, DST, ThresholVal, 255, ThresholdTypes.Binary);
        //                    else
        //                        Cv2.Threshold(DST, DST, ThresholVal, 255, ThresholdTypes.BinaryInv);                            
                          

        //                    //CvSeq<CvPoint> Pos;
        //                    //Point Pos;
        //                    using (CvMemStorage Mos = new CvMemStorage())
        //                    using (Mat TImg = new Mat(DST.Size(), MatType.CV_8UC3))
        //                    {
        //                        TImg.SetZero();

        //                        Cv2.FindContours(DST, Mos, out Mat[] Pos, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
        //                        Pos = Cv2.ApproxPolyDP(Pos, CvContour.SizeOf, Mos, ApproxPolyMethod.DP, 3, true);                             

        //                        Cv2.DrawContours(TImg, Pos, Scalar.Red, Scalar.Blue, 2, 1, LineTypes.AntiAlias);
        //                        Cv2.CvtColor(TImg, DST, ColorConversionCodes.RGB2GRAY);

        //                        //using (new CvWindow("Bin", DST))
        //                        //using (new CvWindow("Contour", TImg))
        //                        //using (new CvWindow("Ori", SRC_Copy))
        //                        //{
        //                        //    Cv.WaitKey();
        //                        //}
        //                    }
                            
        //                    CvBlobs Blobs = new CvBlobs();
        //                    Blobs.Label(DST);
                                                       
        //                    foreach (KeyValuePair<int, CvBlob> item in Blobs)
        //                    {
        //                        CvBlob b = item.Value;
        //                        if (b.Area > 10)
        //                        {
        //                            cRect.Add(b.Rect);
        //                            cArea.Add(b.Area);
        //                        }
        //                    }
                                                        
        //                    if (cRect.Count > 2)
        //                    {

        //                        //using (new CvWindow("Cou", TImg))
        //                        //using (new CvWindow("Bin", DST))
        //                        //using (new CvWindow("Ori", SRC_Copy))
        //                        //{
        //                        //    Cv.WaitKey();
        //                        //}
        //                       // DST.SaveImage(@"d:\temp1\" + Num + "_.jpg");
        //                    }

        //                    result[0] = "OK";
        //                    result[1] = cArea;
        //                    result[2] = cRect;                            
        //                }
        //            }
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        result[0] = "Fail";
        //        result[1] = ex.ToString();

        //        return result;
        //    }
        //    finally
        //    {
        //        GC.Collect(0, GCCollectionMode.Forced);
        //    }
        //    return result;
        //}
        
        public object[] BlobCrop(Mat OP1, bool BinaryInvType, int ThresholVal)
        {
            object[] result = new object[5];

            List<Rect> cRect = new List<Rect>();
            List<Mat> cImg = new List<Mat>();
            List<double> cArea = new List<double>();
            List<Point> cCenter = new List<Point>();

            try
            {
                Mat imgBinary = new Mat(OP1.Size(), MatType.CV_8UC1);
                using (Mat SRC_Copy = OP1.Clone())
                //using (Mat imgBinary = new Mat(OP1.Size(), MatType.CV_8UC1))
                using (Mat DST = new Mat(OP1.Size(), OP1.Depth(), OP1.Channels()))
                {
                    {
                        {
                            if (DST.Channels() != 1)
                            {
                                Cv2.CvtColor(DST, imgBinary, ColorConversionCodes.RGB2GRAY);
                            }
                            else
                            {
                                //Cv2.Copy(DST, imgBinary);
                                imgBinary = DST.Clone();
                            }
                            
                            CvBlobs blobs = new CvBlobs();
                            blobs.Label(OP1);
                       
                            if (blobs.Count > 0)
                            {
                                foreach (KeyValuePair<int, CvBlob> item in blobs)
                                {
                                    CvBlob b = item.Value;

                                    if (b.Area > 10)
                                    {
                                        cRect.Add(b.Rect);
                                        cArea.Add(b.Area);
                                        cCenter.Add((Point)b.Centroid);
                                    }
                                }
                            
                                result[0] = "OK";
                                result[1] = cRect;
                                //result[2] = Product_Crop;
                                result[4] = cCenter;
                            }
                            else
                            {
                                result[0] = "Not Found";
                                result[1] = null;
                                //result[2] = null;

                                return result;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result[0] = "Exception Fail";
                result[1] = ex.ToString();
                //result[2] = null;

                return result;
            }
            return result;
        }

        public List<Rect> rotation(Mat src)
        {
            CvBlobs blobs = new CvBlobs();
            blobs.Label(src);
            List<Rect> cRect = new List<Rect>();
            Rect XRect = new Rect(9999, 9999, 9999, 9999);
            Rect YRect = new Rect(9999, 9999, 9999, 9999);
            List<Rect> temp = new List<Rect>();

            if (blobs.Count > 0)
            {
                foreach (KeyValuePair<int, CvBlob> item in blobs)
                {
                    CvBlob b = item.Value;

                    /*if (b.Area > 10)
                    {
                        cRect.Add(b.Rect);
                    }*/
                    cRect.Add(b.Rect);
                }
            }


            for (int i = 0; i < cRect.Count; i++)
            {
                if(cRect[i].X < XRect.X && cRect[i].X != 0)
                {
                    XRect.X = cRect[i].X;
                    XRect.Y = cRect[i].Y;
                    XRect.Width = cRect[i].Width;
                    XRect.Height = cRect[i].Height;
                }

                if(cRect[i].Y < YRect.Y && cRect[i].Y != 0)
                {
                    YRect.X = cRect[i].X;
                    YRect.Y = cRect[i].Y;
                    YRect.Width = cRect[i].Width;
                    YRect.Height = cRect[i].Height;
                }
            }

            temp.Add(XRect);
            temp.Add(YRect);
            return temp;
        }

    }
}
