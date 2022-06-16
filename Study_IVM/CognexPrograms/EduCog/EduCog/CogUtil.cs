using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;  
using Cognex.VisionPro.Implementation;
using System.Windows.Forms;

namespace EduCog
{
    class CogUtil
    {  /// <summary>
       /// Display 쪽에 Interactive graphic Add
       /// </summary>
       /// <param name="cogDisplay"></param>
       /// <param name="record"></param>
        public static void InsertInteractiveGraphic(ref CogDisplay cogDisplay, CogRecord record)
        {
            foreach (CogRecord recordCollection in record.SubRecords)
            {
                
                if (recordCollection.ContentType == typeof(ICogGraphicInteractive))
                {
                    cogDisplay.InteractiveGraphics.Add((ICogGraphicInteractive)(recordCollection.Content), "", true);
                }
                else if (recordCollection.ContentType == typeof(CogGraphicCollection))
                {
                    CogGraphicCollection findLineCollection = (CogGraphicCollection)recordCollection.Content;
                     
                    CogGraphicInteractiveCollection collectionList = new CogGraphicInteractiveCollection();
                    //TODO 여기서 표시함 findLineCollection 요놈이 가지고 있는듯한데 없음
                    foreach (ICogGraphic graphicChildren in findLineCollection)
                    {
                        //검사된걸 표시해줌
                        collectionList.Add((ICogGraphicInteractive)graphicChildren);
                    }
                    cogDisplay.InteractiveGraphics.AddList(collectionList, "", true);
                }
                else
                {
                    cogDisplay.InteractiveGraphics.Add((ICogGraphicInteractive)(recordCollection.Content), "", true);

                }

            }
        } 

        /// <summary>
        /// Display 쪽에 Static Graphic Add
        /// </summary>
        /// <param name="cogDisplay"></param>
        /// <param name="record"></param>
        public static void InsertStaticGraphic(CogDisplay cogDisplay, CogRecord record)
        {
            foreach (CogRecord recordCollection in record.SubRecords)
            {
                if (recordCollection.ContentType == typeof(ICogGraphicInteractive))
                {
                    if (recordCollection.Content != null)
                        cogDisplay.StaticGraphics.Add((ICogGraphicInteractive)(recordCollection.Content), "");
                }
                else if (recordCollection.ContentType == typeof(CogGraphicCollection))
                {
                    CogGraphicCollection findLineCollection = (CogGraphicCollection)recordCollection.Content;

                    if (findLineCollection != null)
                        cogDisplay.StaticGraphics.AddList(findLineCollection, "");

                }
                else if (recordCollection.ContentType == typeof(CogPointMarker))
                {
                    if (recordCollection.Content != null)
                        cogDisplay.StaticGraphics.Add((CogPointMarker)(recordCollection.Content), "");
                }
            }
        }

        /// <summary>
        /// Mat형식을 CogImage8Grey형식으로 변경함
        /// </summary>
        /// <param name="mat">Mat</param>
        /// <returns>CogImage8Grey</returns>
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

        /// <summary>
        /// Bitmap형식을 CogImage8Grey형식으로 변경함
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        /// <returns>CogImage8Grey</returns>
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

        /// <summary>
        /// Bitmap형식을 CogImage8Grey형식으로 변경
        /// TODO 왜 이걸 또 만들어 놓은거야 함수명 때문인건가 
        /// 어차피 Mat로 해도 변경해서 넣으면 되는건데 실제로도 그렇게 해놨고
        /// </summary>
        /// <param name="bit">Bitmap</param>
        /// <returns>CogImage8Grey</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                cogImage = null;

            }
            return cogImage;
        }

        /// <summary>
        /// 컨트롤러 창을 띄워줌
        /// </summary>
        /// <param name="control">표시할 컨트롤</param>
        /// <param name="ToolName">Tool 이름</param>
        public static void OpenToolWindow( CogToolEditControlBaseV2 control, string ToolName)
        {
            try
            {

                Form viewForm = new Form();
                viewForm.Text = ToolName;

                viewForm.Name = ToolName;

                viewForm.Size = new System.Drawing.Size(control.Size.Width + 18, control.Size.Height + 45);

                control.Dock = DockStyle.Fill;
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                viewForm.Controls.Add(control);
                //viewForm.TopMost = true;

                viewForm.ShowDialog();
                viewForm.Controls.Clear();



            }
            catch (Exception ex)
            {

            }

        }
    }
}
