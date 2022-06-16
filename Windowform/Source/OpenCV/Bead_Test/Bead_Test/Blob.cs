using System;
using System.Collections.Generic;

using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus;
using AForge.Imaging.Filters;


namespace Setinspection
{
    public class BlobSub : IDisposable
    {

        GaussianBlur GB = new GaussianBlur();

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
       
        public object[] HSV_Conv(IplImage SRC, int Min, int Max)
        {
            object[] Result = new object[3];
            
            using (IplImage DST = new IplImage(SRC.Size, BitDepth.U8, 3))
            using (IplImage H = new IplImage(SRC.Size, BitDepth.U8, 1))
            using (IplImage S = new IplImage(SRC.Size, BitDepth.U8, 1))
            using (IplImage V = new IplImage(SRC.Size, BitDepth.U8, 1))
            {
                Cv.CvtColor(SRC, DST, ColorConversion.RgbToHsv);
                Cv.Split(DST, H, S, V, null);
                //H.SaveImage(@"d:\temp\H.jpg");
                //S.SaveImage(@"d:\temp\S.jpg");
                //V.SaveImage(@"d:\temp\V.jpg");

                Cv.InRangeS(H, Min, Max, H);

                Cv.Threshold(H, H, 1, 255, ThresholdType.BinaryInv);

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

                byte[] Temp = H.ToBytes(".bmp");

                int PixelStartPos = BitConverter.ToInt32(Temp, 10);
           
                for (int f = PixelStartPos; f < PixelStartPos + ( H.Width * H.Height ); f++)
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

        public object[] BlobSize(IplImage OP1, int ThresholVal, bool invBinary, string Num)
        {
            object[] result = null;
            result = new object[3];

            List<CvRect> cRect = new List<CvRect>();
            List<double> cArea = new List<double>();

            try
            {
                using (IplImage SRC_Copy = OP1.Clone())
                using (IplImage imgBinary = new IplImage(OP1.Size, BitDepth.U8, 1))
                using (IplImage DST = new IplImage(OP1.Size, OP1.Depth, 1))
                {
                    {
                        {
                            Cv.CvtColor(SRC_Copy.Clone(), DST, ColorConversion.RgbToGray); ;

                            if (!invBinary)
                                Cv.Threshold(DST, DST, ThresholVal, 255, ThresholdType.Binary);
                            else
                                Cv.Threshold(DST, DST, ThresholVal, 255, ThresholdType.BinaryInv);                            
                          

                            CvSeq<CvPoint> Pos;
                            using (CvMemStorage Mos = new CvMemStorage())
                            using (IplImage TImg = new IplImage(DST.Size, BitDepth.U8, 3))
                            {
                                TImg.SetZero();

                                Cv.FindContours(DST, Mos, out Pos, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                                Pos = Cv.ApproxPoly(Pos, CvContour.SizeOf, Mos, ApproxPolyMethod.DP, 3, true);                             

                                Cv.DrawContours(TImg, Pos, CvColor.Red, CvColor.Blue, 2, 1, LineType.AntiAlias);
                                Cv.CvtColor(TImg, DST, ColorConversion.RgbToGray);

                                //using (new CvWindow("Bin", DST))
                                //using (new CvWindow("Contour", TImg))
                                //using (new CvWindow("Ori", SRC_Copy))
                                //{
                                //    Cv.WaitKey();
                                //}
                            }
                            
                            CvBlobs Blobs = new CvBlobs();
                            Blobs.Label(DST);
                                                       
                            foreach (KeyValuePair<int, CvBlob> item in Blobs)
                            {
                                CvBlob b = item.Value;
                                if (b.Area > 10)
                                {
                                    cRect.Add(b.Rect);
                                    cArea.Add(b.Area);
                                }
                            }
                                                        
                            if (cRect.Count > 2)
                            {

                                //using (new CvWindow("Cou", TImg))
                                //using (new CvWindow("Bin", DST))
                                //using (new CvWindow("Ori", SRC_Copy))
                                //{
                                //    Cv.WaitKey();
                                //}
                               // DST.SaveImage(@"d:\temp1\" + Num + "_.jpg");
                            }

                            result[0] = "OK";
                            result[1] = cArea;
                            result[2] = cRect;                            
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result[0] = "Fail";
                result[1] = ex.ToString();

                return result;
            }
            finally
            {
                GC.Collect(0, GCCollectionMode.Forced);
            }
            return result;
        }
        
        public object[] BlobCrop(IplImage OP1, bool BinaryInvType, int ThresholVal)
        {
            object[] result = new object[5];

            List<CvRect> cRect = new List<CvRect>();
            List<IplImage> cImg = new List<IplImage>();
            List<double> cArea = new List<double>();
            List<CvPoint> cCenter = new List<CvPoint>();

            try
            {
                using (IplImage SRC_Copy = OP1.Clone())
                using (IplImage imgBinary = new IplImage(OP1.Size, BitDepth.U8, 1))
                using (IplImage DST = new IplImage(OP1.Size, OP1.Depth, OP1.NChannels))
                {
                    {
                        {
                            if (DST.NChannels != 1)
                            {
                                Cv.CvtColor(DST, imgBinary, ColorConversion.RgbToGray);
                            }
                            else
                            {
                                Cv.Copy(DST, imgBinary);
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
                                        cCenter.Add(b.Centroid);
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





    }
}
