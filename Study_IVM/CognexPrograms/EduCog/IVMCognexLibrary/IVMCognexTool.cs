using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

using System.Windows;
using System.Windows.Forms;
using System.IO;

using IVMInsCommon;

using OpenCvSharp;
using OpenCvSharp.Extensions;

using Cognex;
using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.ToolGroup;

using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PatInspect;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Exceptions;

using Cognex.VisionPro.Inspection;

using Cognex.VisionPro.ID;

using Cognex.VisionPro.Display;

using Cognex.VisionPro.ToolBlock;

using Cognex.VisionPro.CalibFix;//CogFixtureTool
using Cognex.VisionPro.Dimensioning;//CogDistancePointLineTool : Cognex.VisionPro.Dimensioning.dll\
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.EdgeBlob;

namespace IVMCognexLibrary
{



    public class IVMCognexTool : IInspectTool
    {

        int m_GraphicLabelCount = 0;

        static int INS_LABEL_FONTSIZE = 12;
        static int INS_DIS_LABEL_FONTSIZE = 12;

        static string MainSpaceName = "MainAlign";
        static Dictionary<int, string> SugSpaceNameList = new Dictionary<int, string>();

        static CogTransform2DLinear FixtureTransform = new CogTransform2DLinear();

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


        /// <summary>
        /// Display 쪽에 Interactive graphic Add
        /// </summary>
        /// <param name="cogDisplay"></param>
        /// <param name="record"></param>
        public static void InsertInteractiveGraphic(CogDisplay cogDisplay, CogRecord record)
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
                    foreach (ICogGraphic graphicChildren in findLineCollection)
                    {
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
                    if(recordCollection.Content != null)
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

        public static void FindToolSet(CogDisplay cogDisplay, ICogTool cogTool)
        {
            if (cogTool.GetType() == typeof(CogFindLineTool))
                ((CogFindLineTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;
            else if (cogTool.GetType() == typeof(CogFindCornerTool))
                ((CogFindCornerTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;
            else if (cogTool.GetType() == typeof(CogBlobTool))
                ((CogBlobTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;
            else if (cogTool.GetType() == typeof(CogSobelEdgeTool))
                ((CogSobelEdgeTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;
            else if (cogTool.GetType() == typeof(CogFindCircleTool))
                ((CogFindCircleTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;
            else if (cogTool.GetType() == typeof(CogFindEllipseTool))
                ((CogFindEllipseTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;
            else if (cogTool.GetType() == typeof(CogCaliperTool))
                ((CogCaliperTool)cogTool).InputImage = (CogImage8Grey)cogDisplay.Image;

            cogTool.Run();

            if (cogTool.CreateCurrentRecord().SubRecords.Count > 0)
                InsertInteractiveGraphic(cogDisplay, (CogRecord)cogTool.CreateCurrentRecord().SubRecords["InputImage"]);

        }

        public static void FindAlignToolSet(CogDisplay cogDisplay, CogPMAlignTool alignTool)
        {
            alignTool.Run();

            cogDisplay.InteractiveGraphics.Add((ICogGraphicInteractive)alignTool.Pattern.TrainRegion, "", true);

        }

        public static void FindToolResultView(CogDisplay cogDisplay, ICogTool cogTool)
        {
            cogTool.Run();

            ICogRecord cogRecord = (CogRecord)cogTool.CreateLastRunRecord();

            if(cogRecord.SubRecords.Count > 0)
                InsertStaticGraphic(cogDisplay, (CogRecord)cogTool.CreateLastRunRecord().SubRecords["InputImage"]);
        }

        #region Tool Check Visible
        public static void ToolCheckVisible(InspectData insData, CogDisplay display, ICogImage inputImage)
        {
            switch (insData.Type)
            {
                case ENUM_INSPECT_METHOD.EDGE_EDGE:
                    {
                        EdgetoEdgeCheckView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_EDGE:
                    {

                        LinetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_CORNER:
                    {
                        LinetoCornerSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_CIRCLE:
                    {
                        LinetoCircleSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.CORNER_CORNER:
                    {
                        CornertoCornerSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.RADIUS:
                    {
                        RadiusSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_BUR:
                    {
                        //EdgetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_ANGLE:
                    {
                        //EdgetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.ALIGN_BLOB:
                    {
                        //EdgetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.BLOB:
                    {
                        //EdgetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.GEN_SURFACE:
                    {
                        break;
                    }

            }
        }

        public static void EdgetoEdgeCheckView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();



            CogCaliperTool caliperTool1 = (CogCaliperTool)toolGroup.Tools[0];
            CogCaliperTool caliperTool2 = (CogCaliperTool)toolGroup.Tools[1];

            caliperTool1.RunParams.ContrastThreshold = 100;

            caliperTool1.InputImage = inputImage;
            caliperTool2.InputImage = inputImage;

            caliperTool1.Run();
            caliperTool2.Run();

            FindToolResultView(display, caliperTool1);
            FindToolResultView(display, caliperTool2);
        }
        #endregion

        #region Tool Setup Visible
        public static void ToolSettingVisible(InspectData insData, CogDisplay display, ICogImage inputImage)
        {
            switch (insData.Type)
            {
                case ENUM_INSPECT_METHOD.EDGE_EDGE:
                    {
                        EdgetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.EDGE_CORNER:
                    {
                        EdgetoCornerSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_EDGE:
                    {

                        LinetoEdgeSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_CORNER:
                    {
                        LinetoCornerSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_CIRCLE:
                    {
                        LinetoCircleSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.CORNER_CORNER:
                    {
                        CornertoCornerSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.RADIUS:
                    {
                        RadiusSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.ELLIPSE_RADIUS:
                    {
                        EllipseRadiusSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_BUR:
                    {
                        LineBurSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_ANGLE:
                    {
                        LineAngleSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.ALIGN_BLOB:
                    {
                        AlignBlobSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.BLOB:
                    {
                        BlobSetView(insData, display, inputImage);
                        break;
                    }
                case ENUM_INSPECT_METHOD.GEN_SURFACE:
                    {
                        GenSurfaceSetView(insData, display, inputImage);
                        break;
                    }

            }
        }

        /// <summary>
        /// edge to edge Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void EdgetoEdgeSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
                return;

            CogCaliperTool caliperTool1 = (CogCaliperTool)toolGroup.Tools[0];
            CogCaliperTool caliperTool2 = (CogCaliperTool)toolGroup.Tools[1];


            caliperTool1.InputImage = inputImage;
            caliperTool2.InputImage = inputImage;

            caliperTool1.Run();
            caliperTool2.Run();

            FindToolSet(display, caliperTool1);
            FindToolSet(display, caliperTool2);
        }

        /// <summary>
        /// line to edge Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void LinetoEdgeSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
                return;

            CogFindLineTool tool1 = (CogFindLineTool)toolGroup.Tools[0];
            CogCaliperTool tool2 = (CogCaliperTool)toolGroup.Tools[1];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool2.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();
            tool2.Run();

            FindToolSet(display, tool1);
            FindToolSet(display, tool2);
        }

        /// <summary>
        /// line angle Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void LineAngleSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindLineTool tool1 = (CogFindLineTool)toolGroup.Tools[0];
            CogFindLineTool tool2 = (CogFindLineTool)toolGroup.Tools[1];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool2.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();
            tool2.Run();

            FindToolSet(display, tool1);
            FindToolSet(display, tool2);
        }




        /// <summary>
        /// Edge to Corner Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void EdgetoCornerSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogCaliperTool tool1 = (CogCaliperTool)toolGroup.Tools[0];
            CogFindCornerTool tool2 = (CogFindCornerTool)toolGroup.Tools[1];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool2.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();
            tool2.Run();

            FindToolSet(display, tool1);
            FindToolSet(display, tool2);
        }


        /// <summary>
        /// line to Corner Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void LinetoCornerSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindLineTool tool1 = (CogFindLineTool)toolGroup.Tools[0];
            CogFindCornerTool tool2 = (CogFindCornerTool)toolGroup.Tools[1];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool2.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();
            tool2.Run();

            FindToolSet(display, tool1);
            FindToolSet(display, tool2);
        }

        /// <summary>
        /// line to Corner Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void LinetoCircleSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindLineTool tool1 = (CogFindLineTool)toolGroup.Tools[0];
            CogFindCircleTool tool2 = (CogFindCircleTool)toolGroup.Tools[1];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool2.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();
            tool2.Run();

            FindToolSet(display, tool1);
            FindToolSet(display, tool2);
        }

        /// <summary>
        /// Corner to Corner Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void CornertoCornerSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindCornerTool tool1 = (CogFindCornerTool)toolGroup.Tools[0];
            CogFindCornerTool tool2 = (CogFindCornerTool)toolGroup.Tools[1];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool2.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();
            tool2.Run();

            FindToolSet(display, tool1);
            FindToolSet(display, tool2);
        }

        /// <summary>
        /// Corner to Corner Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void RadiusSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindCircleTool tool1 = (CogFindCircleTool)toolGroup.Tools[0];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool1.Run();

            FindToolSet(display, tool1);
        }

        /// <summary>
        /// Find Ellipse Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void EllipseRadiusSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindEllipseTool tool1 = (CogFindEllipseTool)toolGroup.Tools[0];

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool1.Run();

            FindToolSet(display, tool1);
        }


        /// <summary>
        /// Align Blob Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void AlignBlobSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogBlobTool tool1 = (CogBlobTool)toolGroup.Tools[2];

            if (tool1.Region == null)
            {
                CogRectangleAffine rectaffine = new CogRectangleAffine();
                rectaffine.Interactive = true;
                rectaffine.GraphicDOFEnable = Cognex.VisionPro.CogRectangleAffineDOFConstants.All;

                tool1.Region = rectaffine;
            }

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool1.Run();

            FindToolSet(display, tool1);
        }


        /// <summary>
        /// Blob Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void BlobSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogBlobTool tool1 = (CogBlobTool)toolGroup.Tools[0];

            if (tool1.Region == null)
            {
                CogRectangleAffine rectaffine = new CogRectangleAffine();
                rectaffine.Interactive = true;
                rectaffine.GraphicDOFEnable = Cognex.VisionPro.CogRectangleAffineDOFConstants.All;

                tool1.Region = rectaffine;
            }

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool1.Run();

            FindToolSet(display, tool1);
        }

        /// <summary>
        /// general surface Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void GenSurfaceSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogSobelEdgeTool tool1 = (CogSobelEdgeTool)toolGroup.Tools[0];

            if (tool1.Region == null)
            {
                CogRectangleAffine rectaffine = new CogRectangleAffine();
                rectaffine.Interactive = true;
                rectaffine.GraphicDOFEnable = Cognex.VisionPro.CogRectangleAffineDOFConstants.All;

                tool1.Region = rectaffine;
            }

            CogBlobTool tool2 = (CogBlobTool)toolGroup.Tools[1];

            tool2.Region = tool1.Region;

            tool1.InputImage = (CogImage8Grey)inputImage;
            tool1.Run();

            FindToolSet(display, tool1);
        }

        /// <summary>
        /// line bur Tool 설정 Display View
        /// </summary>
        /// <param name="insData"></param>
        /// <param name="display"></param>
        /// <param name="inputImage"></param>
        public static void LineBurSetView(InspectData insData, CogDisplay display, ICogImage inputImage)
        {

            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindLineTool tool1 = (CogFindLineTool)toolGroup.Tools[0];

            tool1.InputImage = (CogImage8Grey)inputImage;

            tool1.Run();

            FindToolSet(display, tool1);

        }
        #endregion


        /// <summary>
        /// 각 Tool의 결과 Display
        /// </summary>
        /// <param name="cogTool"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static CogGraphicCollection ResultDisplayColleciton(ICogTool cogTool, ENUM_INS_RESULT result)
        {
            if (cogTool == null)
                return null;

            CogGraphicCollection collection = new CogGraphicCollection();
            CogRecord record = (CogRecord)cogTool.CreateLastRunRecord().SubRecords["InputImage"];

            CogColorConstants drawColor = CogColorConstants.Green;
            if (result == ENUM_INS_RESULT.OK)
            {

            }
            else
            {
                drawColor = CogColorConstants.Red;
            }

            foreach (CogRecord recordCollection in record.SubRecords)
            {
                if (recordCollection.ContentType == typeof(ICogGraphicInteractive))
                {
                    if (recordCollection.Content != null)
                    {

                        if (recordCollection.Content.GetType() != typeof(CogLine))
                        {
                            ((ICogGraphic)(recordCollection.Content)).Color = drawColor;
                            collection.Add((ICogGraphic)(recordCollection.Content));
                        }

                    }



                }
                else if (recordCollection.ContentType == typeof(CogGraphicCollection))
                {
                    CogGraphicCollection findLineCollection = (CogGraphicCollection)recordCollection.Content;

                    if (findLineCollection != null)
                    {
                        foreach (ICogGraphic graphic in findLineCollection)
                        {

                            if (graphic.GetType() == typeof(CogCompositeShape))
                            {
                                CogCompositeShape shape = (CogCompositeShape)graphic;
                                foreach (ICogGraphic subGraphic in shape.Shapes)
                                {
                                    subGraphic.Color = drawColor;
                                }
                            }

                            //graphic.SelectedSpaceName = "@";
                            graphic.Color = drawColor;
                            collection.Add(graphic);
                        }
                    }

                }
                else if (recordCollection.ContentType == typeof(CogPointMarker))
                {
                    if (recordCollection.Content != null)
                    {
                        ((ICogGraphic)(recordCollection.Content)).Color = drawColor;
                        collection.Add((ICogGraphic)(recordCollection.Content));
                    }
                }
            }

            return collection;
        }

        /// <summary>
        /// 검사 방법에 따른 Tool 초기화 작업 진행
        /// Cognex의 경우 Tool 생성 작업
        /// </summary>
        /// <param name="insMethod"></param>
        /// <returns></returns>
        public object CreateInsTool(ENUM_INSPECT_METHOD insMethod)
        {
            CogToolGroup toolGroup = new CogToolGroup();

            switch (insMethod)
            {
                case ENUM_INSPECT_METHOD.EDGE_EDGE:
                    {
                        toolGroup.Tools.Add(CreateCaliperTool("FirstCaliper"));
                        toolGroup.Tools.Add(CreateCaliperTool("SecondCaliper"));
                        toolGroup.Tools.Add(new CogDistancePointPointTool() { Name = "DistancePointPoint" });
                        //toolGroup.Tools.Add(new CogFindLineTool());
                        break;
                    }
                case ENUM_INSPECT_METHOD.EDGE_CORNER:
                    {
                        toolGroup.Tools.Add(CreateCaliperTool("FindEdge"));
                        toolGroup.Tools.Add(new CogFindCornerTool() { Name = "FindCorner" });
                        toolGroup.Tools.Add(new CogDistancePointPointTool() { Name = "DistancePointPoint" });
                        //toolGroup.Tools.Add(new CogFindLineTool());
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_EDGE:
                    {
                        toolGroup.Tools.Add(new CogFindLineTool() { Name = "FindLine" });
                        toolGroup.Tools.Add(CreateCaliperTool("Caliper"));
                        toolGroup.Tools.Add(new CogDistancePointLineTool() { Name = "DistancePointLine" });

                        CogFindLineTool lineTool = (CogFindLineTool)toolGroup.Tools[0];

                        //toolGroup.Tools.Add(new CogFindLineTool());
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_CORNER:
                    {
                        toolGroup.Tools.Add(new CogFindLineTool() { Name = "FindLine" });
                        toolGroup.Tools.Add(new CogFindCornerTool() { Name = "FindCorner" });
                        toolGroup.Tools.Add(new CogDistancePointLineTool());
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_CIRCLE:
                    {
                        toolGroup.Tools.Add(new CogFindLineTool() { Name = "FindLine" });
                        toolGroup.Tools.Add(new CogFindCircleTool() { Name = "FindCircle" });
                        // 원과의 거리 측정
                        toolGroup.Tools.Add(new CogDistanceLineCircleTool() { Name = "LinetoCircleDis" });
                        // 원의 중심점과의 거리측정
                        toolGroup.Tools.Add(new CogDistancePointLineTool() { Name = "PointtoLineDis" });
                        break;
                    }
                case ENUM_INSPECT_METHOD.CORNER_CORNER:
                    {
                        toolGroup.Tools.Add(new CogFindCornerTool() { Name = "FindCorner1" });
                        toolGroup.Tools.Add(new CogFindCornerTool() { Name = "FindCorner2" });
                        toolGroup.Tools.Add(new CogDistancePointPointTool() { Name = "DistancePointPoint" });
                        break;
                    }
                case ENUM_INSPECT_METHOD.RADIUS:
                    {
                        /*
                        toolGroup.Tools.Add(new CogPMAlignTool() { Name = "PMAlignTool" });
                        toolGroup.Tools.Add(new CogFixtureTool() { Name = "FixtureTool" });
                        */
                        toolGroup.Tools.Add(new CogFindCircleTool() { Name = "FindCircle" });
                        break;
                    }
                case ENUM_INSPECT_METHOD.ELLIPSE_RADIUS:
                    {
                        /*
                        toolGroup.Tools.Add(new CogPMAlignTool() { Name = "PMAlignTool" });
                        toolGroup.Tools.Add(new CogFixtureTool() { Name = "FixtureTool" });
                        */
                        toolGroup.Tools.Add(new CogFindEllipseTool() { Name = "FindEllipse" });
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_BUR:
                    {
                        CogFindLineTool findLineTool = new CogFindLineTool();
                        findLineTool.Name = "FindLine";
                        toolGroup.Tools.Add(findLineTool);
                        break;
                    }
                case ENUM_INSPECT_METHOD.LINE_ANGLE:
                    {

                        toolGroup.Tools.Add(new CogFindLineTool() { Name = "FindLine1" });
                        toolGroup.Tools.Add(new CogFindLineTool() { Name = "FindLine2" });
                        toolGroup.Tools.Add(new CogAngleLineLineTool() { Name = "AngleLine" });
                        break;
                    }
                case ENUM_INSPECT_METHOD.ALIGN_BLOB:
                    {
                        //PM으로 원형 찾기
                        toolGroup.Tools.Add(new CogPMAlignTool());
                        //Fixture를 이용해 홀 사이즈 및 좌표 축 조정 
                        toolGroup.Tools.Add(new CogFixtureTool() { Name = "FixtureAlign" });
                        //해당 위치에서 Blob 확인
                        CogBlobTool blobTool = new CogBlobTool();
                        blobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                        blobTool.Name = "BlobTool";
                        toolGroup.Tools.Add(blobTool);
                        break;
                    }
                case ENUM_INSPECT_METHOD.BLOB:
                    {
                        CogBlobTool blobTool = new CogBlobTool();
                        blobTool.Name = "BlobTool";
                        blobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                        toolGroup.Tools.Add(blobTool);
                        break;
                    }
                case ENUM_INSPECT_METHOD.GEN_SURFACE:
                    {
                        toolGroup.Tools.Add(new CogSobelEdgeTool() { Name = "SobelEdge" });
                        CogBlobTool blobTool = new CogBlobTool();
                        blobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                        blobTool.Name = "BlobTool";
                        toolGroup.Tools.Add(blobTool);
                        break;
                    }

            }
            return toolGroup;
        }


        public CogCaliperTool CreateCaliperTool(string name)
        {
            CogCaliperTool caliper = new CogCaliperTool();
            caliper.Name = name;

            caliper.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
            caliper.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DontCare;
            caliper.RunParams.Edge0Position = 0;

            return caliper;
        }


        #region Align Tool
        public InsRetResult PMAlign(MainInspectData mainInspectData, Bitmap inputImage, ref CogTransform2DLinear transform)
        {

            InsRetResult result = new InsRetResult();

            result.Result = ENUM_INS_RESULT.OK;
            CogImage8Grey cogImage = IVMCogUtil.GetCogImage((Bitmap)inputImage);
            result.OutImage = cogImage;

            transform = new CogTransform2DLinear();

            try
            {
                // 입력 이미지 정리


                CogToolGroup toolGroup = (CogToolGroup)mainInspectData.PMAData.GetAlignToolData();

                CogPMAlignTool pmAlignTool = (CogPMAlignTool)toolGroup.Tools[0];
                CogFixtureTool fixTureTool = (CogFixtureTool)toolGroup.Tools[1];

                // 설정 파라메터 확인 후 Setting
                // 향후 Loading 시 Setting
                pmAlignTool.InputImage = cogImage;
                /*pmAlignTool.RunParams.AcceptThreshold = mainInspectData.PMAData.PMLimit;
                
                pmAlignTool.RunParams.ZoneAngle.High = mainInspectData.PMAData.AngleHigh*Math.PI/180;
                pmAlignTool.RunParams.ZoneAngle.Low = mainInspectData.PMAData.AngleLow * Math.PI / 180;
                pmAlignTool.RunParams.ZoneScale.High = mainInspectData.PMAData.ScaleHigh;
                pmAlignTool.RunParams.ZoneScale.Low = mainInspectData.PMAData.ScaleLow;

                if((pmAlignTool.RunParams.ZoneAngle.High != 0) || (pmAlignTool.RunParams.ZoneAngle.Low != 0))
                    pmAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                else
                    pmAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.Nominal;

                if ((pmAlignTool.RunParams.ZoneScale.High != 1) || (pmAlignTool.RunParams.ZoneScale.Low != 1))
                    pmAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                else
                    pmAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                // pmAlignTool.RunParams.
                */

                pmAlignTool.Run();
              

                if (pmAlignTool.Results == null)
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }


                if (pmAlignTool.Results.Count <= 0)
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }

                transform = pmAlignTool.Results[0].GetPose();
                //transform.SetScalingsRotationsTranslation
                //   (transform.ScalingX, transform.ScalingY,
                //   transform.RotationX, transform.RotationY,
                //   500.0f, transform.TranslationY);

                fixTureTool.InputImage = cogImage;
                fixTureTool.RunParams.UnfixturedFromFixturedTransform = transform;
                fixTureTool.Run();

                // Transform 정의
                FixtureTransform = transform;

                //Bitmap bitmap = fixTureTool.OutputImage.ToBitmap();

                // 이미지 Crop 작업 진행
                // 1st Image
                CogCompositeShape pmaBoundingBox = pmAlignTool.Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);


                CogRectangle PMA1Rectangle = null;

                

                // 바운딩 영역 확인
                if (pmaBoundingBox.Shapes.Count > 0)
                {
                    PMA1Rectangle = (CogRectangle)pmaBoundingBox.Shapes[0];
                }
                int xPos = (int)PMA1Rectangle.X - (int)mainInspectData.PMAData.TrimXPos;
                int yPos = (int)PMA1Rectangle.Y;

                int Height = (int)mainInspectData.PMAData.TrimHeight;
                int Width = (int)mainInspectData.PMAData.TrimWidth;


                Mat inputImageMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputImage);

                if (Height == 0)
                    Height = 10;
                if (Width == 0)
                    Width = 10;

                if ((xPos + Width) > inputImageMat.Width)
                {
                    Width = inputImageMat.Width - xPos;
                }
                if ((yPos + Height) > inputImageMat.Height)
                {
                    Height = inputImageMat.Height - yPos;
                }

                /*
                Mat CropImage1 = inputImageMat.SubMat(new OpenCvSharp.Rect(xPos, yPos, Width, Height));

                //Bitmap cropImage1 = inputImage.Clone(new Rectangle(xPos, yPos, Width, Height), System.Drawing.Imaging.PixelFormat.DontCare);

                result.OutImage = IVMCogUtil.GetCogImage(BitmapConverter.ToBitmap(CropImage1.Clone()));
                */ 

                result.OutImage = fixTureTool.OutputImage;
                //pmAlignTool.re
                //fixTureTool.InputImage = cogImage;

            }
            catch (Exception ex)
            {
                result.Result = ENUM_INS_RESULT.NG;

            }

            return result;
            //pmAlignTool.
        }

        //220214 김동균 
        //public InsRetResult MultiPMAlign(MainInspectData mainInspectData, Bitmap inputImage, ref CogTransform2DLinear transform)
        //{


        //    InsRetResult result = new InsRetResult();

        //    result.Result = ENUM_INS_RESULT.OK;

        //    CogImage8Grey cogImage = IVMCogUtil.GetCogImage((Bitmap)inputImage);
        //    result.OutImage = cogImage;


        //    transform = new CogTransform2DLinear();

        //    try
        //    {
        //        // 입력 이미지 정리
        //        CogToolGroup toolGroup = (CogToolGroup)mainInspectData.PMAData.GetAlignToolData();

        //        CogPMAlignTool pmAlignTool1 = (CogPMAlignTool)toolGroup.Tools[0];
        //        CogPMAlignTool pmAlignTool2 = (CogPMAlignTool)toolGroup.Tools[2];

        //        // 설정 파라메터 확인 후 Setting
        //        // 향후 Loading 시 Setting
        //        pmAlignTool1.InputImage = cogImage;
        //        pmAlignTool2.InputImage = cogImage;

        //        /*
        //        pmAlignTool1.RunParams.AcceptThreshold = mainInspectData.PMAData.PMLimit;
        //        pmAlignTool1.RunParams.ZoneAngle.High = mainInspectData.PMAData.AngleHigh;
        //        pmAlignTool1.RunParams.ZoneAngle.Low = mainInspectData.PMAData.AngleLow;
        //        pmAlignTool1.RunParams.ZoneScale.High = mainInspectData.PMAData.ScaleHigh;
        //        pmAlignTool1.RunParams.ZoneScale.Low = mainInspectData.PMAData.ScaleLow;
        //        */
        //        pmAlignTool1.Run();
        //        pmAlignTool2.Run();

        //        if ((pmAlignTool1.Results == null) || (pmAlignTool2.Results == null))
        //        {
        //            result.Result = ENUM_INS_RESULT.NG;
        //            return result;
        //        }


        //        if ((pmAlignTool1.Results.Count <= 0) || (pmAlignTool2.Results.Count <= 0))
        //        {
        //            result.Result = ENUM_INS_RESULT.NG;
        //            return result;
        //        }

        //        CogPMAlignResult retResult1 = pmAlignTool1.Results[0];
        //        CogPMAlignResult retResult2 = pmAlignTool2.Results[0];

        //        // 이미지 Crop 작업 진행
        //        // 1st Image
        //        CogCompositeShape pmaBoundingBox = retResult1.CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);


        //        CogRectangle PMA1Rectangle = null;

        //        // 바운딩 영역 확인
        //        if (pmaBoundingBox.Shapes.Count > 0)
        //        {
        //            PMA1Rectangle = (CogRectangle)pmaBoundingBox.Shapes[0];
        //        }
        //        int xPos = (int)PMA1Rectangle.X - (int)mainInspectData.PMAData.TrimXPos;
        //        int yPos = (int)PMA1Rectangle.Y;

        //        int Height = (int)mainInspectData.PMAData.TrimHeight;
        //        int Width = (int)mainInspectData.PMAData.TrimWidth;


        //        if (Height == 0)
        //            Height = 10;
        //        if (Width == 0)
        //            Width = 10;

        //        Mat inputImageMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputImage);


        //        if ((xPos + Width) > inputImageMat.Width)
        //        {
        //            Width = inputImageMat.Width - xPos;
        //        }
        //        if ((yPos + Height) > inputImageMat.Height)
        //        {
        //            Height = inputImageMat.Height - yPos;
        //        }


        //        Mat CropImage1 = inputImageMat.SubMat(new OpenCvSharp.Rect(xPos, yPos, Width, Height));

        //        //Bitmap cropImage1 = inputImage.Clone(new Rectangle(xPos, yPos, Width, Height), System.Drawing.Imaging.PixelFormat.DontCare);


        //        // 이미지 Crop 작업 진행
        //        // 2nd Image
        //        CogCompositeShape pmaBoundingBox2 = retResult2.CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);


        //        CogRectangle PMA1Rectangle2 = null;

        //        // 바운딩 영역 확인
        //        if (pmaBoundingBox2.Shapes.Count > 0)
        //        {
        //            PMA1Rectangle2 = (CogRectangle)pmaBoundingBox2.Shapes[0];
        //        }
        //        int xPos2 = (int)PMA1Rectangle2.X - (int)mainInspectData.PMAData.TrimXPos2;
        //        int yPos2 = (int)PMA1Rectangle2.Y;

        //        int Height2 = (int)mainInspectData.PMAData.TrimHeight2;
        //        int Width2 = (int)mainInspectData.PMAData.TrimWidth2;


        //        if (Height2 == 0)
        //            Height2 = 10;
        //        if (Width2 == 0)
        //            Width2 = 10;

        //        if ((xPos2 + Width2) > inputImageMat.Width)
        //        {
        //            Width2 = inputImageMat.Width - xPos2;
        //        }
        //        if ((yPos2 + Height2) > inputImageMat.Height)
        //        {
        //            Height2 = inputImageMat.Height - yPos2;
        //        }


        //        Mat CropImage2 = inputImageMat.SubMat(new OpenCvSharp.Rect(xPos2, yPos2, Width2, Height2));

        //        Mat FinalImage = new Mat(new OpenCvSharp.Size(Width + Width2, Height + Height2), MatType.CV_8U);

        //        Cv2.VConcat(CropImage1, CropImage2, FinalImage);

        //        result.OutImage = IVMCogUtil.GetCogImage(BitmapConverter.ToBitmap(FinalImage.Clone()));

        //        //Bitmap cr0opImage2 = inputImage.Clone(new Rectangle(xPos, yPos, Width, Height), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        //        /*
        //        if (leftBoundingShape.Shapes.Count > 0)
        //        {
        //            PMA1Rectangle = (CogRectangle)leftBoundingShape.Shapes[0];
        //        }*/

        //        /*
        //        retResult.get

        //        // 이미지 Crop 작업 진행
        //        // 1st Image
        //        CogCompositeShape pmaBoundingBox = GetPMAlignMultiResult(leftPMATools.Results).CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);
        //        // 바운딩 영역 확인

        //        CogRectangle PMA1Rectangle = null;
        //        if (leftBoundingShape.Shapes.Count > 0)
        //        {
        //            PMA1Rectangle = (CogRectangle)leftBoundingShape.Shapes[0];
        //        }
        //        */

        //        /*
        //        CogTransform2DLinear transform = pmAlignTool.Results[0].GetPose();
        //        fixTureTool.InputImage = cogImage;
        //        fixTureTool.RunParams.UnfixturedFromFixturedTransform = transform;
        //        fixTureTool.Run();
        //        */
        //        //Bitmap bitmap = fixTureTool.OutputImage.ToBitmap();
        //        //pmAlignTool.re
        //        //fixTureTool.InputImage = cogImage;

        //        //result.OutImage = bitmap;

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Result = ENUM_INS_RESULT.NG;
        //    }


        //    return result;
        //    //pmAlignTool.
        //}


        public InsRetResult CaliperAlign(MainInspectData mainInspectData, Bitmap inputImage, ref CogTransform2DLinear transform)
        {
            InsRetResult result = new InsRetResult();

            result.Result = ENUM_INS_RESULT.OK;
            CogImage8Grey cogImage = IVMCogUtil.GetCogImage((Bitmap)inputImage);
            result.OutImage = cogImage;

            transform = new CogTransform2DLinear();
            try
            {

                // 입력 이미지 정리
                CogToolGroup toolGroup = (CogToolGroup)mainInspectData.PMAData.GetAlignToolData();

                CogCaliperTool caliperTool1 = (CogCaliperTool)toolGroup.Tools[3];
                CogCaliperTool caliperTool2 = (CogCaliperTool)toolGroup.Tools[4];

                // 설정 파라메터 확인 후 Setting
                // 향후 Loading 시 Setting
                caliperTool1.InputImage = cogImage;
                caliperTool2.InputImage = cogImage;

                /*
                pmAlignTool1.RunParams.AcceptThreshold = mainInspectData.PMAData.PMLimit;
                pmAlignTool1.RunParams.ZoneAngle.High = mainInspectData.PMAData.AngleHigh;
                pmAlignTool1.RunParams.ZoneAngle.Low = mainInspectData.PMAData.AngleLow;
                pmAlignTool1.RunParams.ZoneScale.High = mainInspectData.PMAData.ScaleHigh;
                pmAlignTool1.RunParams.ZoneScale.Low = mainInspectData.PMAData.ScaleLow;
                */
                caliperTool1.Run();
                caliperTool2.Run();

                if ((caliperTool1.Results == null) || (caliperTool1.Results == null))
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }


                if ((caliperTool2.Results.Count <= 0) || (caliperTool2.Results.Count <= 0))
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }

                CogCaliperResult retResult1 = caliperTool1.Results[0];
                CogCaliperResult retResult2 = caliperTool2.Results[0];

                // 이미지 Crop 작업 진행
                // 1st Image

                int xPos = (int)retResult1.PositionX - (int)mainInspectData.PMAData.TrimXPos;
                int yPos = (int)retResult1.PositionY;

                int Height = (int)mainInspectData.PMAData.TrimHeight;
                int Width = (int)mainInspectData.PMAData.TrimWidth;


                Mat inputImageMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputImage);


                if ((yPos + Height) > cogImage.Height)
                {
                    Height = cogImage.Height - yPos;
                }
                if ((xPos + Width) > cogImage.Width)
                {
                    Width = cogImage.Width - xPos;
                }


                if (Width < 0)
                {
                    xPos = xPos + Width;
                }

                Mat CropImage1 = inputImageMat.SubMat(new OpenCvSharp.Rect(xPos, yPos, Math.Abs(Width), Height));

                //Bitmap cropImage1 = inputImage.Clone(new Rectangle(xPos, yPos, Width, Height), System.Drawing.Imaging.PixelFormat.DontCare);


                int xPos2 = (int)retResult1.PositionX - (int)mainInspectData.PMAData.TrimXPos2;
                int yPos2 = (int)retResult2.PositionY;

                int Height2 = (int)mainInspectData.PMAData.TrimHeight2;
                int Width2 = (int)mainInspectData.PMAData.TrimWidth2;



                if ((yPos2 + Height2) > cogImage.Height)
                {
                    Height2 = cogImage.Height - yPos2;
                }
                if ((xPos2 + Width2) > cogImage.Width)
                {
                    Width2 = cogImage.Width - xPos2;
                }

                if (Width2 < 0)
                {
                    xPos2 = xPos2 + Width;
                }


                Mat CropImage2 = inputImageMat.SubMat(new OpenCvSharp.Rect(xPos2, yPos2, Math.Abs(Width2), Height2));

                Mat FinalImage = new Mat();

                Cv2.VConcat(CropImage1, CropImage2, FinalImage);

                result.OutImage = IVMCogUtil.GetCogImage(BitmapConverter.ToBitmap(FinalImage.Clone()));

                //Bitmap cr0opImage2 = inputImage.Clone(new Rectangle(xPos, yPos, Width, Height), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                /*
                if (leftBoundingShape.Shapes.Count > 0)
                {
                    PMA1Rectangle = (CogRectangle)leftBoundingShape.Shapes[0];
                }*/

                /*
                retResult.get

                // 이미지 Crop 작업 진행
                // 1st Image
                CogCompositeShape pmaBoundingBox = GetPMAlignMultiResult(leftPMATools.Results).CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);
                // 바운딩 영역 확인

                CogRectangle PMA1Rectangle = null;
                if (leftBoundingShape.Shapes.Count > 0)
                {
                    PMA1Rectangle = (CogRectangle)leftBoundingShape.Shapes[0];
                }
                */

                /*
                CogTransform2DLinear transform = pmAlignTool.Results[0].GetPose();
                fixTureTool.InputImage = cogImage;
                fixTureTool.RunParams.UnfixturedFromFixturedTransform = transform;
                fixTureTool.Run();
                */
                //Bitmap bitmap = fixTureTool.OutputImage.ToBitmap();
                //pmAlignTool.re
                //fixTureTool.InputImage = cogImage;

                //result.OutImage = bitmap;
            }
            catch (Exception ex)
            {
                result.Result = ENUM_INS_RESULT.NG;
            }


            return result;
            //pmAlignTool.
        }


        public InsRetResult LineAlign(MainInspectData mainInspectData, Bitmap inputImage, ref CogTransform2DLinear transform)
        {
            InsRetResult result = new InsRetResult();

            result.Result = ENUM_INS_RESULT.OK;
            CogImage8Grey cogImage = IVMCogUtil.GetCogImage((Bitmap)inputImage);
            result.OutImage = cogImage;

            transform = new CogTransform2DLinear();

            try
            {

                // 입력 이미지 정리
                CogToolGroup toolGroup = (CogToolGroup)mainInspectData.PMAData.GetAlignToolData();

                CogFindLineTool findLine = (CogFindLineTool)toolGroup.Tools[5];

                // 설정 파라메터 확인 후 Setting
                // 향후 Loading 시 Setting
                findLine.InputImage = null;
                findLine.InputImage = cogImage;

                /*
                pmAlignTool1.RunParams.AcceptThreshold = mainInspectData.PMAData.PMLimit;
                pmAlignTool1.RunParams.ZoneAngle.High = mainInspectData.PMAData.AngleHigh;
                pmAlignTool1.RunParams.ZoneAngle.Low = mainInspectData.PMAData.AngleLow;
                pmAlignTool1.RunParams.ZoneScale.High = mainInspectData.PMAData.ScaleHigh;
                pmAlignTool1.RunParams.ZoneScale.Low = mainInspectData.PMAData.ScaleLow;
                */
                findLine.Run();


                if (findLine.Results == null)
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }


                if (findLine.Results.Count <= 0)
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }

                CogLine retResult = findLine.Results.GetLine();

                CogLineSegment retSegmentLine = findLine.Results.GetLineSegment();

                if(retResult == null)
                {
                    result.Result = ENUM_INS_RESULT.NG;
                    return result;
                }
                //CogCaliperResult retResult2 = caliperTool2.Results[0];

                // 찾은 Line의 Rotation 및 Position Check
                double Angle = mainInspectData.PMAData.Angle + retResult.Rotation*180/Math.PI;

                Mat inputImageMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputImage);

                // Line 의 기울기에 맞도록 Rotation
                Mat RotationMat = Rotate(inputImageMat, Angle).Clone();

                // 이미지 제거
                inputImageMat.Dispose();

                // Image Crop
                int xPos = (int)mainInspectData.PMAData.TrimXPos - (int)retResult.X;
                int yPos = (int)mainInspectData.PMAData.TrimYPos - (int)retResult.Y;

                int Height = (int)mainInspectData.PMAData.TrimHeight;
                int Width = (int)mainInspectData.PMAData.TrimWidth;

                // Crop Size가 실제 이미지 사이즈보다 작을 경우 전체 사이즈로 적용
                if ((yPos + Height) > cogImage.Height)
                    Height = cogImage.Height - yPos;
                if ((xPos + Width) > cogImage.Width)
                    Width = cogImage.Width - xPos;

                if (Width < 0)
                    xPos = xPos + Width;
                if (Height < 0)
                    yPos = yPos + Height;

                // 이미지 Crop
                Mat CropImage1 = RotationMat;//RotationMat.SubMat(new OpenCvSharp.Rect(xPos, yPos, Math.Abs(Width), Height));

                // 결과 Image Return
                result.OutImage = IVMCogUtil.GetCogImage(BitmapConverter.ToBitmap(RotationMat.Clone()));

            }
            catch (Exception ex)
            {
                result.Result = ENUM_INS_RESULT.NG;
            }


            return result;
            //pmAlignTool.
        }

        public Mat Rotate(Mat src, double angle)
        {
            //Mat rotate = new Mat(src.Size(), src.Channels());
            //Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(src.Width / 2, src.Height / 2), angle, 1);
            //Cv2.WarpAffine(src, rotate, matrix, src.Size(), InterpolationFlags.Lanczos4);
            return src;
        }


        #endregion

        #region Tool 및 Align 데이터 Save Load


        public void DeleteToolFile(MainInspectData mainInspectData)
        {


            ModelData modelData = mainInspectData.GetModelData();

            string CurrentPath = InspectionCommon.CurrentPath;

            string ModelPath = string.Format("{0}_{1}", modelData.Number, modelData.Name);
            string finalPath = string.Format("{0}\\ModelData\\{1}\\{2}", CurrentPath, ModelPath, mainInspectData.DeviceName);

            IVMCommon.IVMUtil.DirExistsChk(finalPath);

            string[] fileList = Directory.GetFiles(finalPath, string.Format("Tool_{0}*", mainInspectData.GroupNumber));

            foreach (string file in fileList)
            {
                File.Delete(file);
            }

            //toolGroup = (CogToolGroup)CogSerializer.LoadObjectFromFile(finalPath);
        }

        public void Save(InspectData insData, string deviceName)
        {
            //insData.GetInspectionTool();
            string CurrentPath = InspectionCommon.CurrentPath;

            ModelData modelData = insData.GetModelData();

            string ModelPath = string.Format("{0}_{1}", modelData.Number, modelData.Name);
            string finalPath = string.Format("{0}\\ModelData\\{1}\\{2}\\Tool_{3}_{4}.xml", CurrentPath, ModelPath, deviceName, insData.GroupNumber, insData.InsNumber - 1);

            IVMCommon.IVMUtil.DirExistsChk(string.Format("{0}\\ModelData", CurrentPath));

            if (insData.GetInsToolData() != null)
                CogSerializer.SaveObjectToFile((CogToolGroup)insData.GetInsToolData(), finalPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
        }


        public object Load(InspectData insData, string deviceName)
        {
            CogToolGroup toolGroup;
            try
            {

                string CurrentPath = InspectionCommon.CurrentPath;

                ModelData modelData = insData.GetModelData();

                string ModelPath = string.Format("{0}_{1}", modelData.Number, modelData.Name);
                string finalPath = string.Format("{0}\\ModelData\\{1}\\{2}\\Tool_{3}_{4}.xml", CurrentPath, ModelPath, deviceName, insData.GroupNumber, insData.InsNumber - 1);

                toolGroup = (CogToolGroup)CogSerializer.LoadObjectFromFile(finalPath);

            }
            catch (Exception ex)
            {

                //ToolGroup이 존재하지 않을 때에 오류가 발생하므로 해당 toolGroup 자동 생성

                toolGroup = (CogToolGroup)CreateInsTool(insData.Type);
            }
            return toolGroup;
        }


        public void SaveAlign(object alignTool, MainInspectData mainInspectData)
        {
            //insData.GetInspectionTool();
            string CurrentPath = InspectionCommon.CurrentPath;

            ModelData modelData = mainInspectData.GetModelData();
            string ModelPath = string.Format("{0}_{1}", modelData.Number, modelData.Name);
            string finalPath = string.Format("{0}\\ModelData\\{1}\\{2}\\AlignTool_{3}.xml", CurrentPath, ModelPath, mainInspectData.DeviceName, mainInspectData.GroupNumber);

            IVMCommon.IVMUtil.DirExistsChk(string.Format("{0}\\ModelData", CurrentPath));

            if (alignTool == null)
                alignTool = CreateAlignTool(mainInspectData.ImageAlignType);
            if (alignTool != null)

                CogSerializer.SaveObjectToFile((CogToolGroup)alignTool, finalPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
        }

        public object LoadAlign(MainInspectData mainInspectData)
        {
            CogToolGroup toolGroup;
            try
            {
                string CurrentPath = InspectionCommon.CurrentPath;

                ModelData modelData = mainInspectData.GetModelData();

                string ModelPath = string.Format("{0}_{1}", modelData.Number, modelData.Name);
                string finalPath = string.Format("{0}\\ModelData\\{1}\\{2}\\AlignTool_{3}.xml", CurrentPath, ModelPath, mainInspectData.DeviceName, mainInspectData.GroupNumber);

                toolGroup = (CogToolGroup)CogSerializer.LoadObjectFromFile(finalPath, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter));

            }
            // tool 이 없는 경우
            catch (Exception ex)
            {
                toolGroup = (CogToolGroup)CreateAlignTool(mainInspectData.ImageAlignType);
            }
            return toolGroup;
        }


        #endregion


        #region 검사
        public List<InsRetResult> Inspection(Bitmap image, MainInspectData mainInsData, out IVMTransForm transform)
        {
            // 검사 진행 및 InspectData에 정보 전달
            List<InsRetResult> retResults = new List<InsRetResult>();

            List<InspectData> insDatas = mainInsData.InspectionDataList;

            transform = new IVMTransForm();
            CogTransform2DLinear retTransform = new CogTransform2DLinear();


            try
            {
                // 검사 전 PM 진행
                InsRetResult result = null;
                if (mainInsData.ImageAlignType == ENUM_INS_ALIGN_TYPE.SINGLE_PMA)
                {
                    result = PMAlign(mainInsData, image, ref retTransform);
                }
                //else if (mainInsData.ImageAlignType == ENUM_INS_ALIGN_TYPE.IMAGE_CROP_MULTI_PMA)
                //{
                //    result = MultiPMAlign(mainInsData, image, ref retTransform);
                //}
                else if (mainInsData.ImageAlignType == ENUM_INS_ALIGN_TYPE.CALIPER2_ALIGN)
                {
                    result = CaliperAlign(mainInsData, image, ref retTransform);
                }
                else if (mainInsData.ImageAlignType == ENUM_INS_ALIGN_TYPE.LINE_ALIGN)
                {
                    result = LineAlign(mainInsData, image, ref retTransform);
                }

                transform.Scale = retTransform.Scaling;
                transform.ScaleX = retTransform.ScalingX;
                transform.ScaleY = retTransform.ScalingY;

                transform.Rotation = retTransform.Rotation;
                transform.RotationX = retTransform.RotationX;
                transform.RotationY = retTransform.RotationY;

                transform.TransX = retTransform.TranslationX;
                transform.TransY = retTransform.TranslationY;

                // 입력 이미지 정리
                CogImage8Grey cogImage = (CogImage8Grey)result.OutImage; //IVMCogUtil.GetCogImage(result.OutImage);

                retResults.Add(result);

                if (result.Result == ENUM_INS_RESULT.NG)
                {
                    // Align 이 Error일 경우 이후 검사 전체 NG로 설정 후 Return
                    foreach(InspectData insData in insDatas)
                    {
                        InsRetResult retResult = null;
                        if (!insData.Enable)
                        {
                            retResult = new InsRetResult(insData);
                            retResult.Result = ENUM_INS_RESULT.PASS;
                        }
                        else
                        {
                            retResult = new InsRetResult(insData);
                            retResult.Result = ENUM_INS_RESULT.NG;
                        }

                        // Error 일 경우 데이터 초기화
                        retResult.sValue.Area = insData.sValue.Area;
                        retResult.sValue.Count = insData.sValue.Count;

                        retResult.sValue.RealArea = 0;
                        retResult.sValue.RealCount = 0;

                        insData.sValue.RealArea = 0;
                        insData.sValue.RealCount = 0;

                        retResult.InsData = insData;
                        retResults.Add(retResult);
                    }

                    return retResults;
                }
                    

                // 각 검사 항목별 검사 진행
                foreach (InspectData insData in insDatas)
                {

                    InsRetResult retResult = null;

                    // 검사 상태가 아닐 경우 Pass 후 Return;

                    if (!insData.Enable)
                    {
                        retResult = new InsRetResult(insData);
                        retResult.Result = ENUM_INS_RESULT.PASS;
                    }
                    else
                    {
                        switch (insData.Type)
                        {
                            case ENUM_INSPECT_METHOD.EDGE_EDGE:
                                retResult = EdgetoEdgeDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.EDGE_CORNER:
                                retResult = EdgetoCornerDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.LINE_EDGE:
                                retResult = LinetoEdgeDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.LINE_CIRCLE:
                                retResult = LinetoCircleDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.LINE_CORNER:
                                retResult = LinetoCornerDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.CORNER_CORNER:
                                retResult = CornertoCornerDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.LINE_ANGLE:
                                retResult = LinetoLineAngle(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.RADIUS:
                                retResult = RadiusDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.ELLIPSE_RADIUS:
                                retResult = EllipseRadiusDistance(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.BLOB:
                                retResult = BlobIns(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.ALIGN_BLOB:
                                retResult = AlignBlobIns(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.GEN_SURFACE:
                                retResult = GenSurfaceIns(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.CIRCLE_BUR:
                                retResult = GenSurfaceIns(cogImage, insData);
                                break;
                            case ENUM_INSPECT_METHOD.LINE_BUR:
                                retResult = LineBurIns(cogImage, insData);
                                break;
                        }

                        if (retResult == null)
                        {
                            retResult = new InsRetResult(insData);
                            retResult.Result = ENUM_INS_RESULT.NG;
                        }
                    }

                    //220214 김동균, 검사 패스 설정시 강제 ok..
                    if (!mainInsData.Enable)
                    {
                        retResult.Result = ENUM_INS_RESULT.OK;
                    }

                    retResult.InsData = insData;
                    retResults.Add(retResult);

                }
            }
            catch (Exception ex)
            {

            }
            ///result.OutImage.Dispose();
            image.Dispose();
            return retResults;
        }


        #region Distance Method
        /// <summary>
        /// edge to edge distance insptection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult EdgetoEdgeDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);


            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogCaliperTool caliper1 = (CogCaliperTool)toolGroup.Tools[0];
            CogCaliperTool caliper2 = (CogCaliperTool)toolGroup.Tools[1];

            if (cogImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            caliper1.InputImage = null;
            caliper2.InputImage = null;

            caliper1.InputImage = cogImage;
            caliper2.InputImage = cogImage;

            caliper1.Run();
            caliper2.Run();

            System.Windows.Point caliper1Point = new System.Windows.Point();
            System.Windows.Point caliper2Point = new System.Windows.Point();

            if (caliper1.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (caliper1.Results.Count > 0)
            {
                caliper1Point.X = caliper1.Results[0].Edge0.PositionX;
                caliper1Point.Y = caliper1.Results[0].Edge0.PositionY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (caliper2.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (caliper2.Results.Count > 0)
            {
                caliper2Point.X = caliper2.Results[0].Edge0.PositionX;
                caliper2Point.Y = caliper2.Results[0].Edge0.PositionY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            // Point 사이 거리 계산 및 검사 진행
            CogDistancePointPointTool distanceTool = (CogDistancePointPointTool)toolGroup.Tools[2];

            distanceTool.InputImage = cogImage;
            distanceTool.StartX = caliper1Point.X;
            distanceTool.StartY = caliper1Point.Y;

            distanceTool.EndX = caliper2Point.X;
            distanceTool.EndY = caliper2Point.Y;

            distanceTool.Run();

            double distance = distanceTool.Distance;

            insData.Value.RealValue = distance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;

            if (insData.Value.Value < (insData.Value.ReferLow) || insData.Value.Value > (insData.Value.ReferHigh))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                //insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                //insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(caliper1, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(caliper2, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(distanceTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, (distanceTool.StartX + distanceTool.EndX) / 2, (distanceTool.StartY + distanceTool.EndY) / 2, "@"));
            return retResult;
        }


        /// <summary>
        /// Line to Edge Distance Inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult LinetoEdgeDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogFindLineTool findLine = (CogFindLineTool)toolGroup.Tools[0];
            CogCaliperTool caliper = (CogCaliperTool)toolGroup.Tools[1];


            findLine.InputImage = null;
            caliper.InputImage = null;


            findLine.InputImage = cogImage;
            caliper.InputImage = cogImage;

            findLine.Run();
            caliper.Run();

            System.Windows.Point caliperPoint = new System.Windows.Point();

            if (caliper.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (caliper.Results.Count > 0)
            {
                caliperPoint.X = caliper.Results[0].PositionX;
                caliperPoint.Y = caliper.Results[0].PositionY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (findLine.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogLine line = null;
            if (findLine.Results.Count > 0)
            {

                line = findLine.Results.GetLine();
                //caliper2Point.X = findLine.Results[0].;
                //caliper2Point.Y = findLine.Results[0].PositionY;

                if (line == null)
                {
                    retResult.Result = ENUM_INS_RESULT.NG;
                    return retResult;
                }
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            // Point 사이 거리 계산 및 검사 진행
            CogDistancePointLineTool distanceTool = (CogDistancePointLineTool)toolGroup.Tools[2];

            distanceTool.InputImage = cogImage;
            distanceTool.X = caliperPoint.X;
            distanceTool.Y = caliperPoint.Y;

            distanceTool.Line = line;

            distanceTool.Run();

            if (distanceTool.RunStatus.Result != CogToolResultConstants.Accept)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            double distance = distanceTool.Distance;

            insData.Value.RealValue = distance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;



            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                //insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                //insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findLine, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(caliper, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(distanceTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, (distanceTool.X + distanceTool.LineX) / 2, (distanceTool.Y + distanceTool.LineY) / 2, "@"));
            return retResult;
        }

        /// <summary>
        /// Line to Line Angle Inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult LinetoLineAngle(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogFindLineTool findLine1 = (CogFindLineTool)toolGroup.Tools[0];
            CogFindLineTool findLine2 = (CogFindLineTool)toolGroup.Tools[1];

            findLine1.InputImage = cogImage;
            findLine2.InputImage = cogImage;

            findLine1.Run();
            findLine2.Run();

            System.Windows.Point caliperPoint = new System.Windows.Point();


            CogLine line1 = null;

            if (findLine1.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (findLine1.Results.Count > 0)
            {

                line1 = findLine1.Results.GetLine();
                if (line1 == null)
                {
                    retResult.Result = ENUM_INS_RESULT.NG;
                    return retResult;
                }
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogLine line2 = null;

            if (findLine2.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (findLine2.Results.Count > 0)
            {

                line2 = findLine2.Results.GetLine();
                //caliper2Point.X = findLine.Results[0].;
                //caliper2Point.Y = findLine.Results[0].PositionY;

                if (line2 == null)
                {
                    retResult.Result = ENUM_INS_RESULT.NG;
                    return retResult;
                }
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            // Point 사이 거리 계산 및 검사 진행
            CogAngleLineLineTool angleTool = (CogAngleLineLineTool)toolGroup.Tools[2];

            angleTool.InputImage = cogImage;
            angleTool.LineA = line1;
            angleTool.LineB = line2;

            angleTool.Run();

            //angleTool.StateFlags;

            double angle = angleTool.Angle;

            insData.Value.RealValue = angle * 180 / Math.PI;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;



            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                //insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                //insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findLine1, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findLine2, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(angleTool, retResult.Result));

            ICogGraphic angleArc = null;
            if (angleTool.CreateLastRunRecord().SubRecords["InputImage"].SubRecords.Count > 2)
            {
                angleArc = (ICogGraphic)angleTool.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["Angle"].Content;
            }


            if (angleArc != null)
            {
                CogCircularArc finalArc = (CogCircularArc)angleArc;

                finalArc.Radius = 300;

                retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, finalArc.CenterX, finalArc.CenterY, "@"));
            }

            return retResult;
        }

        /// <summary>
        /// Line to Corner Distance inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult LinetoCornerDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindLineTool findLine = (CogFindLineTool)toolGroup.Tools[0];
            CogFindCornerTool corner = (CogFindCornerTool)toolGroup.Tools[1];


            findLine.InputImage = null;
            corner.InputImage = null;

            findLine.InputImage = cogImage;
            corner.InputImage = cogImage;

            findLine.Run();
            corner.Run();

            System.Windows.Point cornerPoint = new System.Windows.Point();

            if (corner.Result == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (corner.Result.CornerFound)
            {
                cornerPoint.X = corner.Result.CornerX;
                cornerPoint.Y = corner.Result.CornerY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (findLine.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogLine line = null;
            if (findLine.Results.Count > 0)
            {

                line = findLine.Results.GetLine();
                //caliper2Point.X = findLine.Results[0].;
                //caliper2Point.Y = findLine.Results[0].PositionY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            // Point 사이 거리 계산 및 검사 진행
            CogDistancePointLineTool distanceTool = (CogDistancePointLineTool)toolGroup.Tools[2];

            distanceTool.InputImage = cogImage;
            distanceTool.X = cornerPoint.X;
            distanceTool.Y = cornerPoint.Y;

            distanceTool.Line = line;

            distanceTool.Run();




            double distance = distanceTool.Distance;

            insData.Value.RealValue = distance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;

            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                //insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                //insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findLine, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(corner, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(distanceTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, (distanceTool.LineX + distanceTool.X) / 2, (distanceTool.LineY + distanceTool.Y) / 2, "@"));

            return retResult;
        }

        /// <summary>
        /// Edge to Corner Distance inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult EdgetoCornerDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogCaliperTool caliper = (CogCaliperTool)toolGroup.Tools[0];
            CogFindCornerTool corner = (CogFindCornerTool)toolGroup.Tools[1];

            caliper.InputImage = null;
            corner.InputImage = null;
            caliper.InputImage = cogImage;
            corner.InputImage = cogImage;

            caliper.Run();
            corner.Run();

            System.Windows.Point cornerPoint = new System.Windows.Point();

            if (corner.Result == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (corner.Result.CornerFound)
            {
                cornerPoint.X = corner.Result.CornerX;
                cornerPoint.Y = corner.Result.CornerY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (caliper.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            System.Windows.Point caliper1Point = new System.Windows.Point();

            if (caliper.Results.Count > 0)
            {

                caliper1Point.X = caliper.Results[0].PositionX;
                caliper1Point.Y = caliper.Results[0].PositionY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            // Point 사이 거리 계산 및 검사 진행
            CogDistancePointPointTool distanceTool = (CogDistancePointPointTool)toolGroup.Tools[2];

            distanceTool.InputImage = cogImage;
            distanceTool.StartX = cornerPoint.X;
            distanceTool.StartY = cornerPoint.Y;

            distanceTool.EndX = caliper1Point.X;
            distanceTool.EndY = caliper1Point.Y;

            distanceTool.Run();


            double distance = distanceTool.Distance;

            insData.Value.RealValue = distance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;

            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                //insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                //insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(caliper, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(corner, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(distanceTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, (distanceTool.StartX + distanceTool.EndX) / 2, (distanceTool.StartY + distanceTool.EndY) / 2, "@"));
            return retResult;
        }


        /// <summary>
        /// Corner to Corner Distance inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult CornertoCornerDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindCornerTool corner1 = (CogFindCornerTool)toolGroup.Tools[0];
            CogFindCornerTool corner2 = (CogFindCornerTool)toolGroup.Tools[1];

            corner1.InputImage = null;
            corner2.InputImage = null;
            corner1.InputImage = cogImage;
            corner2.InputImage = cogImage;

            corner1.Run();
            corner2.Run();

            System.Windows.Point cornerPoint1 = new System.Windows.Point();
            System.Windows.Point cornerPoint2 = new System.Windows.Point();

            if (corner1.Result == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (corner1.Result.CornerFound)
            {
                cornerPoint1.X = corner1.Result.CornerX;
                cornerPoint1.Y = corner1.Result.CornerY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (corner2.Result == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (corner2.Result.CornerFound)
            {
                cornerPoint2.X = corner2.Result.CornerX;
                cornerPoint2.Y = corner2.Result.CornerY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            // Point 사이 거리 계산 및 검사 진행
            CogDistancePointPointTool distanceTool = (CogDistancePointPointTool)toolGroup.Tools[2];

            distanceTool.InputImage = cogImage;
            distanceTool.StartX = cornerPoint1.X;
            distanceTool.StartY = cornerPoint1.Y;

            distanceTool.EndX = cornerPoint2.X;
            distanceTool.EndY = cornerPoint2.Y;

            distanceTool.Run();


            double distance = distanceTool.Distance;

            insData.Value.RealValue = distance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;

            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                //insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                //insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(corner1, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(corner2, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(distanceTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, (distanceTool.StartX + distanceTool.EndX) / 2, (distanceTool.StartY + distanceTool.EndY) / 2, "@"));
            return retResult;
        }



        /// <summary>
        /// Line to Circle Distance Inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult LinetoCircleDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindLineTool findLine = (CogFindLineTool)toolGroup.Tools[0];
            CogFindCircleTool findCircle = (CogFindCircleTool)toolGroup.Tools[1];

            findLine.InputImage = null;
            findCircle.InputImage = null;
            findLine.InputImage = cogImage;
            findCircle.InputImage = cogImage;

            findLine.Run();
            findCircle.Run();

            System.Windows.Point centerPoint = new System.Windows.Point();
            double radius = 0;

            if (findCircle.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogCircle resultCircle = null;
            if (findCircle.Results.Count > 0)
            {
                if (insData.ConnectionPosition == 0)
                {
                    resultCircle = findCircle.Results.GetCircle();

                    if (resultCircle == null)
                    {
                        retResult.Result = ENUM_INS_RESULT.NG;
                        return retResult;
                    }
                    centerPoint.X = resultCircle.CenterX;
                    centerPoint.Y = resultCircle.CenterY;
                    /*
                    cornerPoint.X = findCircle.Results.;
                    cornerPoint.Y = findCircle.Results[0].CornerY;
                    */
                }
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (findLine.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogLine line = null;
            if (findLine.Results.Count > 0)
            {

                line = findLine.Results.GetLine();
                //caliper2Point.X = findLine.Results[0].;
                //caliper2Point.Y = findLine.Results[0].PositionY;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            ICogTool insTool = null;

            double finalDistance = 0;


            double startLabelX = 0;
            double startLabelY = 0;
            double endLabelX = 0;
            double endLabelY = 0;

            // 라인과 원의 연결 점에 따른 거리 측정
            // 원의 중심과의 거리
            if (insData.LCDisType == ENUM_INS_LINE_CIRCLE_DIS_TYPE.CENETER)
            {
                CogDistancePointLineTool distance = (CogDistancePointLineTool)toolGroup.Tools[3];

                distance.InputImage = cogImage;
                distance.X = centerPoint.X;
                distance.Y = centerPoint.Y;
                distance.Line = line;
                distance.Run();

                insTool = distance;

                startLabelX = distance.X;
                startLabelY = distance.Y;
                endLabelX = line.X;
                endLabelY = line.Y;
            }
            // 원과 만나는 점 사이의 거리
            else if (insData.LCDisType == ENUM_INS_LINE_CIRCLE_DIS_TYPE.INTERSECTION)
            {
                CogDistanceLineCircleTool distance = (CogDistanceLineCircleTool)toolGroup.Tools[2];

                distance.InputImage = cogImage;
                distance.InputCircle = resultCircle;
                distance.Line = line;
                distance.Run();

                finalDistance = distance.Distance;

                insTool = distance;

                startLabelX = distance.LineX;
                startLabelY = distance.LineY;
                endLabelX = distance.CircleX;
                endLabelY = distance.CircleY;
            }


            insData.Value.RealValue = finalDistance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;

            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                insData.ResultData.Count.OK++;
            }

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findLine, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findCircle, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(insTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, (startLabelX + endLabelX) / 2, (startLabelY + endLabelY) / 2, "@"));
            return retResult;
        }

        /// <summary>
        /// Radius Distance Inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult RadiusDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindCircleTool findCircle = (CogFindCircleTool)toolGroup.Tools[0];


            findCircle.InputImage = null;
            findCircle.InputImage = cogImage;

            findCircle.Run();

            System.Windows.Point centerPoint = new System.Windows.Point();
            double radius = 0;

            if (findCircle.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogCircle resultCircle = null;
            if (findCircle.Results.Count > 0)
            {


                resultCircle = findCircle.Results.GetCircle();
                /*
                if (insData.ConnectionPosition == 0)
                {
                    resultCircle = findCircle.Results.GetCircle();

                    if (resultCircle == null)
                    {
                        retResult.Result = ENUM_INS_RESULT.NG;
                        return retResult;
                    }
                    centerPoint.X = resultCircle.CenterX;
                    centerPoint.Y = resultCircle.CenterY;

                }*/
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            ICogTool insTool = null;

            double finalDistance = 0;
            // 라인과 원의 연결 점에 따른 거리 측정
            // 원의 중심과의 거리

            if (resultCircle != null)
            {
                finalDistance = resultCircle.Radius;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            /*
            if (insData.LCDisType == ENUM_INS_LINE_CIRCLE_DIS_TYPE.CENETER)
            {
                CogDistancePointLineTool distance = (CogDistancePointLineTool)toolGroup.Tools[3];

                distance.InputImage = cogImage;
                distance.X = centerPoint.X;
                distance.Y = centerPoint.Y;
                distance.Line = line;
                distance.Run();

                insTool = distance;

            }
            // 원과 만나는 점 사이의 거리
            else if (insData.LCDisType == ENUM_INS_LINE_CIRCLE_DIS_TYPE.INTERSECTION)
            {
                CogDistanceLineCircleTool distance = (CogDistanceLineCircleTool)toolGroup.Tools[2];

                distance.InputImage = cogImage;
                distance.InputCircle = resultCircle;
                distance.Line = line;
                distance.Run();

                finalDistance = distance.Distance;

                insTool = distance;
            }
            */

            insData.Value.RealValue = finalDistance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;

            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                insData.ResultData.Count.OK++;
            }

            //이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findCircle, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(insTool, retResult.Result));

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, resultCircle.CenterX, resultCircle.CenterY, "@"));


            return retResult;
        }

        /// <summary>
        /// Ellipse Distance Inspection
        /// </summary>
        /// <param name="cogImage"></param>
        /// <param name="insData"></param>
        /// <returns></returns>
        public static InsRetResult EllipseRadiusDistance(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            CogFindEllipseTool findCircle = (CogFindEllipseTool)toolGroup.Tools[0];

            findCircle.InputImage = null;
            findCircle.InputImage = cogImage;

            findCircle.Run();

            System.Windows.Point centerPoint = new System.Windows.Point();
            double radius = 0;

            if (findCircle.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogEllipse resultEllipse = null;
            if (findCircle.Results.Count > 0)
            {


                resultEllipse = findCircle.Results.GetEllipse();
                /*
                if (insData.ConnectionPosition == 0)
                {
                    resultCircle = findCircle.Results.GetCircle();

                    if (resultCircle == null)
                    {
                        retResult.Result = ENUM_INS_RESULT.NG;
                        return retResult;
                    }
                    centerPoint.X = resultCircle.CenterX;
                    centerPoint.Y = resultCircle.CenterY;

                }*/
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            ICogTool insTool = null;

            double finalDistance = 0;
            // 라인과 원의 연결 점에 따른 거리 측정
            // 원의 중심과의 거리

           

            double XDistance = 0;
            double YDistance = 0;

            if (resultEllipse != null)
            {
                XDistance = resultEllipse.RadiusX;
                YDistance = resultEllipse.RadiusY;
             
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (insData.ValueList.Count == 0)
                return retResult;
            MeasureValue measureXInsValue = insData.ValueList[0];
            MeasureValue measureYInsValue = insData.ValueList[1];

            // 지름으로 계산
            measureXInsValue.RealValue = resultEllipse.RadiusX*2;
            measureYInsValue.RealValue = resultEllipse.RadiusY*2;

            measureXInsValue.Value = measureXInsValue.RealValue * measureXInsValue.CalibrationValue;
            measureYInsValue.Value = measureYInsValue.RealValue * measureYInsValue.CalibrationValue;

            retResult.InsArea = new Rectangle((int)(resultEllipse.CenterX - XDistance), (int)(resultEllipse.CenterY - YDistance), (int)XDistance * 2, (int)YDistance * 2);


            ENUM_INS_RESULT xResult = ENUM_INS_RESULT.OK;
            ENUM_INS_RESULT yResult = ENUM_INS_RESULT.OK;
            if ((measureXInsValue.Value < measureXInsValue.ReferLow) || (measureXInsValue.Value > measureXInsValue.ReferHigh))
            {
                xResult = ENUM_INS_RESULT.NG;
            }

            if ((measureYInsValue.Value < measureYInsValue.ReferLow) || (measureYInsValue.Value > measureYInsValue.ReferHigh))
            {
                yResult = ENUM_INS_RESULT.NG;
            }

            if((xResult == ENUM_INS_RESULT.NG) || (yResult == ENUM_INS_RESULT.NG))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                insData.ResultData.Count.NG++;

                retResult.OutImage = cogImage.ToBitmap().Clone(new Rectangle(retResult.InsArea.X-10, retResult.InsArea.Y-10, retResult.InsArea.Width+20, retResult.InsArea.Height+20), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                insData.ResultData.Count.OK++;
            }

            // 결과 데이터 Insert
            retResult.ValueList.Add(measureXInsValue.Clone());
            retResult.ValueList.Add(measureYInsValue.Clone());

            retResult.Value = retResult.ValueList[0];



            /*
            insData.sValue.Count = insData.Value.Reference;

            insData.Value.RealValue = finalDistance;
            insData.Value.Value = insData.Value.RealValue * insData.Value.CalibrationValue;
            insData.sValue.Area = insData.Value.Value;


            if ((insData.Value.Value < (insData.Value.ReferLow)) || (insData.Value.Value > (insData.Value.ReferHigh)))
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                insData.ResultData.Count.NG++;
            }
            else
            {
                retResult.Result = ENUM_INS_RESULT.OK;
                insData.ResultData.Count.OK++;
            }
            */

            /*
            XDistance;
            YDistance;*/

            //findCircle.CreateLastRunRecord().SubRecords[""]
            //이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findCircle, retResult.Result));
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(insTool, retResult.Result));

            // X 및 Y Label 정리
            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, resultEllipse.CenterX, resultEllipse.CenterY, "@\\Fixture"));
            return retResult;
        }


        #endregion

        #region Surface Method
        public static InsRetResult BlobIns(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            retResult.Result = ENUM_INS_RESULT.OK;

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogBlobTool blob = (CogBlobTool)toolGroup.Tools[0];

            if (cogImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            blob.InputImage = null;

            blob.InputImage = cogImage;

            blob.Run();

            if (blob.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogBlobResults blobResults = blob.Results;


            double totalArea = 0;
            if (blobResults.GetBlobs().Count > 0)
            {
                foreach (CogBlobResult blobResult in blobResults.GetBlobs())
                {
                    totalArea += blobResult.Area;
                }
            }



            if (blobResults.GetBlobs().Count > insData.sValue.Count)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            if (totalArea > insData.sValue.Area)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            CogTransform2DLinear transform = (CogTransform2DLinear)blob.InputImage.PixelFromRootTransform;

            retResult.sValue.Area = insData.sValue.Area;
            retResult.sValue.Count = insData.sValue.Count;

            retResult.sValue.RealArea = totalArea;
            retResult.sValue.RealCount = blobResults.GetBlobs().Count;

            insData.sValue.RealArea = totalArea;
            insData.sValue.RealCount = blobResults.GetBlobs().Count;

            //Blob 이미지 정리
            CogGraphicCollection addCollection = ResultDisplayColleciton(blob, retResult.Result);

            System.Drawing.Point retPoint = new System.Drawing.Point();
            ICogGraphic regionGraphic = GetRegion(blob.Region, retResult.Result, ref retPoint, transform);

            if (regionGraphic != null)
                addCollection.Add(regionGraphic);
            retResult.ResultGraphicCollection.Add(addCollection);

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, retPoint.X, retPoint.Y, "@"));

            return retResult;
        }

        public static InsRetResult LineBurIns(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            retResult.Result = ENUM_INS_RESULT.OK;

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogFindLineTool findLine = (CogFindLineTool)toolGroup.Tools[0];

            if (cogImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            findLine.InputImage = cogImage;

            findLine.Run();

            if (findLine.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            if (findLine.Results.Count <= 0)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            //double totalArea = 0;

            CogLine line = findLine.Results.GetLine();

            if (line == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            double MaxArea = 0.0;
            double SumArea = 0;
            int Count = 0;

            foreach (CogFindLineResult result in findLine.Results)
            {
                if (result.Found)
                {
                    if (Math.Abs(result.DistanceToLine) > insData.sValue.Area)
                    {

                        Count++;
                    }

                    if (MaxArea < Math.Abs(result.DistanceToLine))
                    {
                        MaxArea = result.DistanceToLine;
                    }
                }
            }

            if (Count > insData.sValue.Count)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            /*
            if (blobResults.GetBlobs().Count > 0)
            {
                foreach (CogBlobResult blobResult in blobResults.GetBlobs())
                {
                    totalArea += blobResult.Area;
                }
            }



            if (blobResults.GetBlobs().Count > insData.sValue.Count)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            if (totalArea > insData.sValue.Area)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }*/

            CogTransform2DLinear transform = (CogTransform2DLinear)findLine.InputImage.PixelFromRootTransform;

            retResult.sValue.Area = insData.sValue.Area;
            retResult.sValue.Count = insData.sValue.Count;

            retResult.sValue.RealArea = MaxArea;
            retResult.sValue.RealCount = Count;

            insData.sValue.RealArea = MaxArea;
            insData.sValue.RealCount = Count;

            //Blob 이미지 정리
            CogGraphicCollection addCollection = ResultDisplayColleciton(findLine, retResult.Result);


            CogLineSegment lineSegment = (CogLineSegment)findLine.CreateCurrentRecord().SubRecords["InputImage"].SubRecords["ExpectedShapeSegment"].Content;
            System.Drawing.Point retPoint = new System.Drawing.Point();

            retPoint.X = (int)lineSegment.StartX;
            retPoint.Y = (int)lineSegment.StartY;

            //3가지 이미지 정리
            retResult.ResultGraphicCollection.Add(ResultDisplayColleciton(findLine, retResult.Result));
            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, retPoint.X, retPoint.Y, "@"));

            return retResult;
        }

        public static InsRetResult AlignBlobIns(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            retResult.Result = ENUM_INS_RESULT.OK;

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            // PM Align
            CogPMAlignTool alignTool = (CogPMAlignTool)toolGroup.Tools[0];
            alignTool.InputImage = null;
            alignTool.InputImage = cogImage;
            alignTool.Run();


            if (alignTool.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            if (alignTool.Results.Count <= 0)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogFixtureTool fixtureTool = (CogFixtureTool)toolGroup.Tools[1];
            fixtureTool.InputImage = cogImage;
            fixtureTool.RunParams.FixturedSpaceName = "Fixture" + insData.InsNumber.ToString();
            fixtureTool.RunParams.UnfixturedFromFixturedTransform = alignTool.Results[0].GetPose();
            fixtureTool.Run();




            CogBlobTool blob = (CogBlobTool)toolGroup.Tools[2];

            blob.InputImage = fixtureTool.OutputImage;
            blob.Region.SelectedSpaceName = "@\\" + fixtureTool.RunParams.FixturedSpaceName;

            if (cogImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            // blob.InputImage = cogImage;

            blob.Run();



            if (blob.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogBlobResults blobResults = blob.Results;


            double totalArea = 0;
            if (blobResults.GetBlobs().Count > 0)
            {
                foreach (CogBlobResult blobResult in blobResults.GetBlobs())
                {
                    totalArea += blobResult.Area;
                }
            }

            if (blobResults.GetBlobs().Count > insData.sValue.Count)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            if (totalArea > insData.sValue.Area)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }


            retResult.sValue.Area = insData.sValue.Area;
            retResult.sValue.Count = insData.sValue.Count;

            retResult.sValue.RealArea = totalArea;
            retResult.sValue.RealCount = blobResults.GetBlobs().Count;

            insData.sValue.RealArea = totalArea;
            insData.sValue.RealCount = blobResults.GetBlobs().Count;

            //Blob 이미지 정리
            CogGraphicCollection addCollection = ResultDisplayColleciton(blob, retResult.Result);

            System.Drawing.Point retPoint = new System.Drawing.Point();

            //blob.Region.SelectedSpaceName = "@";

            //blob.Region
            ICogGraphic regionGraphic = GetRegion(blob.Region, retResult.Result, ref retPoint, (CogTransform2DLinear)fixtureTool.RunParams.UnfixturedFromFixturedTransform);

            //CogCompositeShape shape = new CogCompositeShape();

            if (regionGraphic != null)
            {
                //shape.Shapes.Add((ICogGraphicParentChild)regionGraphic);
                //shape.ParentFromChildTransform = fixtureTool.RunParams.UnfixturedFromFixturedTransform;
                addCollection.Add(regionGraphic);
            }

            retResult.ResultGraphicCollection.Add(addCollection);

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, retPoint.X, retPoint.Y, blob.Region.SelectedSpaceName));

            return retResult;
        }


        public static InsRetResult GenSurfaceIns(CogImage8Grey cogImage, InspectData insData)
        {
            InsRetResult retResult = new InsRetResult(insData);
            retResult.Result = ENUM_INS_RESULT.OK;

            CogToolGroup toolGroup = (CogToolGroup)insData.GetInsToolData();

            if (toolGroup == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            CogSobelEdgeTool sobel = (CogSobelEdgeTool)toolGroup.Tools[0];

            if (cogImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            sobel.InputImage = cogImage;

            sobel.Run();

            if (sobel.Result == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogSobelEdgeResult sobelResult = sobel.Result;



            CogBlobTool blob = (CogBlobTool)toolGroup.Tools[1];

            blob.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
            blob.RunParams.SegmentationParams.HardFixedThreshold = insData.sValue.Threshold;



            if (sobel.Result.FinalMagnitudeImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            blob.InputImage = sobel.Result.FinalMagnitudeImage;

            CogTransform2DLinear transForm = (CogTransform2DLinear)blob.InputImage.GetTransform(".", ".");

            blob.Region = sobel.Region;

            blob.Run();

            if (blob.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogBlobResults blobResults = blob.Results;


            double totalArea = 0;
            if (blobResults.GetBlobs().Count > 0)
            {
                foreach (CogBlobResult blobResult in blobResults.GetBlobs())
                {
                    totalArea += blobResult.Area;
                }
            }

            if (blobResults.GetBlobs().Count > insData.sValue.Count)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            if (totalArea > insData.sValue.Area)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }


            retResult.sValue.Area = insData.sValue.Area;
            retResult.sValue.Count = insData.sValue.Count;

            retResult.sValue.RealArea = totalArea;
            retResult.sValue.RealCount = blobResults.GetBlobs().Count;

            insData.sValue.RealArea = totalArea;
            insData.sValue.RealCount = blobResults.GetBlobs().Count;

            //Blob 이미지 정리
            CogGraphicCollection addCollection = ResultDisplayColleciton(blob, retResult.Result);

            System.Drawing.Point retPoint = new System.Drawing.Point();
            ICogGraphic regionGraphic = GetRegion(blob.Region, retResult.Result, ref retPoint, transForm);

            if (regionGraphic != null)
                addCollection.Add(regionGraphic);
            retResult.ResultGraphicCollection.Add(addCollection);

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, retPoint.X, retPoint.Y, "@"));

            /*
            CogBlobTool blob = (CogBlobTool)toolGroup.Tools[0];

            if (cogImage == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }


            blob.InputImage = cogImage;

            blob.Run();

            if (blob.Results == null)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
                return retResult;
            }

            CogBlobResults blobResults = blob.Results;


            double totalArea = 0;
            if (blobResults.GetBlobs().Count > 0)
            {
                foreach (CogBlobResult blobResult in blobResults.GetBlobs())
                {
                    totalArea += blobResult.Area;
                }
            }



            if (blobResults.GetBlobs().Count > insData.sCount)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }

            if (totalArea > insData.Area)
            {
                retResult.Result = ENUM_INS_RESULT.NG;
            }


            retResult.sValue.Area = insData.sValue.Area;
            retResult.sValue.Count = insData.sValue.Count;

            retResult.sValue.RealArea = totalArea;
            retResult.sValue.RealCount = blobResults.GetBlobs().Count;

            insData.sValue.RealArea = totalArea;
            insData.sValue.RealCount = blobResults.GetBlobs().Count;

            //Blob 이미지 정리
            CogGraphicCollection addCollection = ResultDisplayColleciton(blob, retResult.Result);

            System.Drawing.Point retPoint = new System.Drawing.Point();
            ICogGraphic regionGraphic = GetRegion(blob.Region, retResult.Result, ref retPoint);

            addCollection.Add(regionGraphic);
            retResult.ResultGraphicCollection.Add(addCollection);

            retResult.ResultLableColleciton.Add(CreateLabel(string.Format("[{0}] {1}", insData.InsNumber, insData.Name), INS_LABEL_FONTSIZE, retPoint.X, retPoint.Y));
            */
            return retResult;
        }


        public static ICogGraphic GetRegion(CogGraphicCollection graphicColleciton, ENUM_INS_RESULT result, ref System.Drawing.Point point, CogTransform2DLinear transform)
        {
            if (graphicColleciton == null)
                return null;

            ICogGraphic blobRegion = null;

            foreach (ICogGraphic graphic in graphicColleciton)
            {
                if (graphic.GetType() == typeof(CogCompositeShape))
                {
                    CogCompositeShape shape = (CogCompositeShape)graphic;

                    foreach (ICogGraphic subShape in shape.Shapes)
                    {
                        blobRegion = GetRegion((ICogGraphic)subShape, result, ref point, transform);

                        if (blobRegion != null)
                            break;
                    }
                }
                else
                {
                    blobRegion = GetRegion((ICogGraphic)graphic, result, ref point, transform);
                }
            }

            return blobRegion;
        }

        public static ICogGraphic GetRegion(ICogGraphic region, ENUM_INS_RESULT result, ref System.Drawing.Point point, CogTransform2DLinear transform)
        {
            if (region == null)
                return null;

            ICogGraphic blobRegion = region;



            if (blobRegion.GetType() == typeof(CogRectangleAffine))
            {
                ((CogRectangleAffine)blobRegion).Selected = false;
                ((CogRectangleAffine)blobRegion).Interactive = false;

                point.X = (int)((CogRectangleAffine)blobRegion).CornerXX;
                point.Y = (int)((CogRectangleAffine)blobRegion).CornerXY;
            }
            else if (blobRegion.GetType() == typeof(CogCircle))
            {
                ((CogCircle)blobRegion).Selected = false;
                ((CogCircle)blobRegion).Interactive = false;

                point.X = (int)((CogCircle)blobRegion).CenterX;
                point.Y = (int)((CogCircle)blobRegion).CenterY;
            }
            else if (blobRegion.GetType() == typeof(CogEllipse))
            {
                ((CogEllipse)blobRegion).Selected = false;
                ((CogEllipse)blobRegion).Interactive = false;

                //((CogEllipse)blobRegion).SetFromUnitCircleTransform(transform);
                point.X = (int)((CogEllipse)blobRegion).CenterX;
                point.Y = (int)((CogEllipse)blobRegion).CenterY;
            }
            else if (blobRegion.GetType() == typeof(CogRectangle))
            {
                ((CogRectangle)blobRegion).Selected = false;
                ((CogRectangle)blobRegion).Interactive = false;

                //((CogEllipse)blobRegion).SetFromUnitCircleTransform(transform);
                point.X = (int)((CogRectangle)blobRegion).X;
                point.Y = (int)((CogRectangle)blobRegion).Y;
            }
            else
                blobRegion = null;


            if (blobRegion == null)
                return null;

            if (result == ENUM_INS_RESULT.NG)
                blobRegion.Color = CogColorConstants.Red;
            else
                blobRegion.Color = CogColorConstants.Green;

            return blobRegion;
        }


        public static ICogGraphic GetRegion(ICogRegion region, ENUM_INS_RESULT result, ref System.Drawing.Point point, CogTransform2DLinear transform)
        {
            if (region == null)
                return null;

            ICogGraphic blobRegion = ((ICogGraphic)region).CopyBase(CogCopyShapeConstants.All);

            blobRegion = GetRegion(blobRegion, result, ref point, transform);

            return blobRegion;
        }

        #endregion

        #endregion


        /// <summary>
        /// 이미지 사전 정렬을 위한 Align Tool 생성 부분
        /// </summary>
        /// <param name="alignType"></param>
        /// <returns></returns>
        public object CreateAlignTool(ENUM_INS_ALIGN_TYPE alignType)
        {
            CogToolGroup toolGroup = new CogToolGroup();


            //전체 Tool을 생성 시켜 놓은 후 필요한 Tool 만 이용해 Align 진행
            toolGroup.Tools.Add(new CogPMAlignTool() { Name = "AlignTool" });
            toolGroup.Tools.Add(new CogFixtureTool() { Name = "FixtureTool" });
            toolGroup.Tools.Add(new CogPMAlignTool() { Name = "AlignTool2" });
            toolGroup.Tools.Add(new CogCaliperTool() { Name = "Caliper1" });
            toolGroup.Tools.Add(new CogCaliperTool() { Name = "Caliper2" });
            //220214 김동균
            //toolGroup.Tools.Add(new CogPMAlignMultiTool() { Name = "AlignMultiTool" });
            toolGroup.Tools.Add(new CogFindLineTool() { Name = "FindLine" });

            /*
            switch(alignType)
            {
                case ENUM_INS_ALIGN_TYPE.SINGLE_PMA:
                    toolGroup.Tools.Add(new CogPMAlignTool() { Name = "AlignTool" });
                    toolGroup.Tools.Add(new CogFixtureTool() { Name = "FixtureTool" });
                    break;
                case ENUM_INS_ALIGN_TYPE.IMAGE_CROP_MULTI_PMA:
                    toolGroup.Tools.Add(new CogPMAlignTool() { Name = "AlignTool1" });
                    toolGroup.Tools.Add(new CogPMAlignTool() { Name = "AlignTool2" });
                    break;
                case ENUM_INS_ALIGN_TYPE.CALIPER2_ALIGN:
                    toolGroup.Tools.Add(new CogPMAlignTool() { Name = "Caliper1" });
                    toolGroup.Tools.Add(new CogPMAlignTool() { Name = "Caliper2" });
                    break;
            }
            */
            return toolGroup;
        }

        #region 결과 Display
        public static void DisplayResult(MainInspectResult mainInsResult, CogDisplay display)
        {
            display.StaticGraphics.Clear();
            display.InteractiveGraphics.Clear();


            // Display 좌표에 맞도록 정의



            int Count = 0;
            foreach (InsRetResult result in mainInsResult.InspectResults)
            {
                if (result.InsData != null)
                {
                    if (result.InsData.Enable)
                    {
                        DrawResultImage(display, result.InsData, result);

                        // 검사 결과 출력 Label
                        DrawLabel(display, mainInsResult.InsData, result, ref Count);
                        Count++;
                    }
                }
            }

        }

        public static void DrawLabel(CogDisplay display, MainInspectData mainInspectData, InsRetResult result, ref int Count)
        {
            //display.Region
            double zoom = display.Zoom;
            //double labelDis = (double)display.Image.Height / (double)display.Height * 20;
            double labelDis = 20 / zoom;


            if (result.InsData == null)
                return;

            switch (result.InsData.Type)
            {
                case ENUM_INSPECT_METHOD.EDGE_EDGE:
                case ENUM_INSPECT_METHOD.EDGE_CORNER:
                case ENUM_INSPECT_METHOD.LINE_EDGE:
                case ENUM_INSPECT_METHOD.LINE_CORNER:
                case ENUM_INSPECT_METHOD.LINE_CIRCLE:
                case ENUM_INSPECT_METHOD.CORNER_CORNER:
                case ENUM_INSPECT_METHOD.RADIUS:
                case ENUM_INSPECT_METHOD.LINE_ANGLE:
                    {

                        if (result.InsData != null)
                        {
                            CogCompositeShape resultLableDisplayShape = IVMCognexLibrary.IVMCognexTool.CreateLabel(string.Format("[{0}]{1} : {2:0.000}", result.InsData.InsNumber, result.InsData.Name, result.InsData.Value.Value), INS_DIS_LABEL_FONTSIZE, mainInspectData.ResultLabelBaseXPos, mainInspectData.ResultLabelBaseYPos + Count * labelDis, "$", false);

                            if (result.Result == ENUM_INS_RESULT.OK)
                                resultLableDisplayShape.Color = CogColorConstants.Green;
                            else if (result.Result == ENUM_INS_RESULT.NG)
                                resultLableDisplayShape.Color = CogColorConstants.Red;
                            else if (result.Result == ENUM_INS_RESULT.PASS)
                                resultLableDisplayShape.Color = CogColorConstants.LightGrey;

                            resultLableDisplayShape.SelectedSpaceName = "@";

                            display.StaticGraphics.Add(resultLableDisplayShape, "");

                        }
                        break;
                    }
                case ENUM_INSPECT_METHOD.ALIGN_BLOB:
                case ENUM_INSPECT_METHOD.BLOB:
                case ENUM_INSPECT_METHOD.GEN_SURFACE:
                case ENUM_INSPECT_METHOD.LINE_BUR:
                    {

                        if (result.InsData != null)
                        {
                            //resultLableDisplayShape.Shapes.Add(IVMCognexLibrary.IVMCognexTool.CreateLabel(string.Format("[{0}]{1} : Area->{2}, Count->{3}", result.InsData.InsNumber, result.InsData.Name, result.InsData.sValue.RealArea, result.InsData.sValue.RealCount), INS_DIS_LABEL_FONTSIZE, mainInspectData.ResultLabelBaseXPos, mainInspectData.ResultLabelBaseYPos + Count * labelDis, "$"));

                            CogCompositeShape resultLableDisplayShape = IVMCognexLibrary.IVMCognexTool.CreateLabel(string.Format("[{0}]{1} : Area->{2:0.000}, Count->{3:0.000}", result.InsData.InsNumber, result.InsData.Name, result.InsData.sValue.RealArea, result.InsData.sValue.RealCount), INS_DIS_LABEL_FONTSIZE, mainInspectData.ResultLabelBaseXPos, mainInspectData.ResultLabelBaseYPos + Count * labelDis, "$", false);

                            if (result.Result == ENUM_INS_RESULT.OK)
                                resultLableDisplayShape.Color = CogColorConstants.Green;
                            else if (result.Result == ENUM_INS_RESULT.NG)
                                resultLableDisplayShape.Color = CogColorConstants.Red;
                            else if (result.Result == ENUM_INS_RESULT.PASS)
                                resultLableDisplayShape.Color = CogColorConstants.LightGrey;

                            resultLableDisplayShape.SelectedSpaceName = "@";

                            display.StaticGraphics.Add(resultLableDisplayShape, "");

                        }
                        break;
                    }
                case ENUM_INSPECT_METHOD.ELLIPSE_RADIUS:
                    {
                        if (result.InsData != null)
                        {

                            CogCompositeShape resultLableDisplayShape = IVMCognexLibrary.IVMCognexTool.CreateLabel(string.Format("[{0}]{1} : X->{2:0.000}, Y->{3:0.000}", result.InsData.InsNumber, result.InsData.Name, result.InsData.ValueList[0].Value, result.InsData.ValueList[1].Value), INS_DIS_LABEL_FONTSIZE, mainInspectData.ResultLabelBaseXPos, mainInspectData.ResultLabelBaseYPos + Count * labelDis, "$", false);

                            if (result.Result == ENUM_INS_RESULT.OK)
                                resultLableDisplayShape.Color = CogColorConstants.Green;
                            else if (result.Result == ENUM_INS_RESULT.NG)
                                resultLableDisplayShape.Color = CogColorConstants.Red;
                            else if (result.Result == ENUM_INS_RESULT.PASS)
                                resultLableDisplayShape.Color = CogColorConstants.LightGrey;

                            resultLableDisplayShape.SelectedSpaceName = "@";
                           

                            //display.Image.
                            display.StaticGraphics.Add(resultLableDisplayShape, "");
                        }
                        break;
                    }
            }
        }



        public static void DrawResultImage(CogDisplay display, InspectData insData, InsRetResult result)
        {
            // Graphic data view
            foreach (CogGraphicCollection collection in result.ResultGraphicCollection)
            {
                if (collection != null)
                {

                    display.StaticGraphics.AddList(collection, "");
                }

            }


            CogCompositeShape shape = new CogCompositeShape();


            // label data view
            foreach (CogCompositeShape collection in result.ResultLableColleciton)
            {

                if (result.Result == ENUM_INS_RESULT.NG)
                    collection.Color = CogColorConstants.Red;
                else if (result.Result == ENUM_INS_RESULT.OK)
                    collection.Color = CogColorConstants.Green;
                else
                    collection.Color = CogColorConstants.LightGrey;
                /*
                if(collection.Parent == null)
                {
                    shape.SelectedSpaceName = collection.SelectedSpaceName;
                    shape.Shapes.Add(collection);
                }
                */
                display.StaticGraphics.Add(collection, "");
            }

            //display.StaticGraphics.Add(shape, "");
        }
        #endregion

        #region 화면 출력 Label 정의

        public static CogCompositeShape CreateLabel(string text, int size, double x, double y, string spaceName, bool transform = true)
        {
            CogCompositeShape shape = new CogCompositeShape();
            CogGraphicLabel label = new CogGraphicLabel();
            label.Text = text;
            label.X = x;
            label.Y = y;
            label.BackgroundColor = CogColorConstants.Black;
            label.SelectedSpaceName = "$";
            label.Alignment = CogGraphicLabelAlignmentConstants.BottomLeft;
            label.Font = new Font(label.Font.FontFamily, size);
            //shape.Color = color;
            shape.SelectedSpaceName = spaceName;

            if(transform)
                shape.ParentFromChildTransform = FixtureTransform;

           shape.Shapes.Add(label);

            return shape;
        }
        public CogCompositeShape CreateViewLabel(string text, int size, CogColorConstants color)
        {
            System.Drawing.Point point = GetLabelPoint();

            CogCompositeShape shape = new CogCompositeShape();
            CogGraphicLabel label = new CogGraphicLabel();
            label.Text = text;
            label.X = point.X;
            label.Y = point.Y;
            label.BackgroundColor = CogColorConstants.Black;
            label.SelectedSpaceName = "$";
            label.Alignment = CogGraphicLabelAlignmentConstants.BottomLeft;
            label.Font = new Font(label.Font.FontFamily, size);
            shape.Color = color;
            shape.Shapes.Add(label);

            m_GraphicLabelCount++;
            return shape;
        }


        public CogGraphicLabel CreateLabel(string text, int size, CogPointMarker point, CogColorConstants color)
        {
            CogGraphicLabel label = new CogGraphicLabel();
            label.Text = text;
            label.X = point.X;
            label.Y = point.Y;
            label.Color = color;
            label.SelectedSpaceName = "$";
            label.Alignment = CogGraphicLabelAlignmentConstants.BottomLeft;
            label.Font = new Font(label.Font.FontFamily, size);

            return label;
        }


        public System.Drawing.Point GetLabelPoint()
        {
            System.Drawing.Point point = new System.Drawing.Point();

            // 7개씩 정렬
            int RowCount = m_GraphicLabelCount / 5;
            int Position = m_GraphicLabelCount % 5;


            point.X = Position * 850;
            point.Y = RowCount * 180;

            return point;

        }


        #endregion

        /// <summary>
        /// Tool 별 Window Open 부분
        /// </summary>
        /// <param name="control"></param>
        /// <param name="ToolName"></param>
        public static void OpenToolWindow(CogToolEditControlBaseV2 control, string ToolName)
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
