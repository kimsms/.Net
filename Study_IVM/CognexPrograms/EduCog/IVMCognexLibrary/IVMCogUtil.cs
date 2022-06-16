using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Cognex.VisionPro;
using System.Drawing;
using System.IO;

namespace IVMCognexLibrary
{
    public class IVMCogUtil
    {

        public static CogImage8Grey GetCogImage(Mat mat)
        {
            CogImage8Grey OutImage = null;
            try
            {
                OutImage = (CogImage8Grey)BitmapToCogImageChange(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat));
            }
            catch// (Exception ex)
            {
                //Inspect_Log_Display(camNo, ex.ToString(),false);
            }

            return OutImage;

        }

        public static CogImage8Grey GetCogImage(Bitmap bitmap)
        {
            CogImage8Grey OutImage = null;
            try
            {
                OutImage = (CogImage8Grey)BitmapToCogImageChange(bitmap);
            }
            catch// (Exception ex)
            {
                //Inspect_Log_Display(camNo, ex.ToString(),false);
            }

            return OutImage;
        }

        public static ICogImage BitmapToCogImageChange(Bitmap bit)
        {
            Cognex.VisionPro.ICogImage cogImage;
            try
            {
                cogImage = new Cognex.VisionPro.CogImage8Grey(bit);

            }
            catch
            {
                cogImage = null;

            }
            return cogImage;
        }

        
        public static ICogImage FilestreamToCogImageChange(MemoryStream memstream)
        {
            Cognex.VisionPro.ICogImage cogImage;
            try
            {
                Bitmap bitmap = new Bitmap(memstream);
                cogImage = new Cognex.VisionPro.CogImage8Grey(bitmap);
            }
            catch
            {
                cogImage = null;

            }
            return cogImage;
        }

        public static ICogImage FilestreamToCogImageChange(byte[] byteArray)
        {
            Cognex.VisionPro.ICogImage cogImage;
            try
            {
                MemoryStream ms = new MemoryStream(byteArray);
                ms.Position = 0;
                System.Drawing.Image image = Image.FromStream(ms);
                //Bitmap bitmap = new Bitmap(ms);


                cogImage = new Cognex.VisionPro.CogImage8Grey((Bitmap)image);
            }
            catch(Exception ex)
            {
                cogImage = null;

            }
            return cogImage;
        }

    }
}
