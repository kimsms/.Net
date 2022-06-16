using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCVClass
{
    public class OpecnCVTools
    {
        public Mat Cvt_toMat(Bitmap bitmap)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
        }

        public Mat Cvt_toMat(Image image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)image);
        }

        public Bitmap Cvt_toBitmap(Mat mat)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
        }

        public Image Cvt_toImage(Mat mat)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
        }

        public Mat binarization(Mat src, double thresh)
        {
            Mat result = new Mat();

            Cv2.Threshold(src, result, thresh, 255, ThresholdTypes.Binary);

            return result;
        }

    }
}
