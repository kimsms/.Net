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

namespace EduCog
{
    class CogTestLib
    {
        public CogToolGroup TestLibTool = new CogToolGroup();

        /// <summary>
        /// 클래스 선언시 실행됨
        /// </summary>
        public CogTestLib()
        {
            TestLibTool.Tools.Add(((CogToolGroup)CreateInsTool(ENUM_INSPECT_METHOD.BLOB)).Tools[0]);
            //TestLibTool.Tools.Add(((CogToolGroup)CreateInsTool(ENUM_INSPECT_METHOD.ALIGN_BLOB)).Tools[0]);
        }

        /// <summary>
        /// 검사 결과를 표시함
        /// </summary>
        /// <param name="cogDisplay">표시할 CogDisplay</param>
        /// <param name="cogTool">ICogTool</param>
        public static void FindToolSet(ref CogDisplay cogDisplay, ICogTool cogTool)
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

            //CogRecord a = cogTool.CreateLastRunRecord().SubRecords;
            if (cogTool.CreateCurrentRecord().SubRecords.Count > 0)
                CogUtil.InsertInteractiveGraphic(ref cogDisplay, (CogRecord)cogTool.CreateLastRunRecord().SubRecords["InputImage"]);

        }

        /// <summary>
        /// 선택한 CogToolGroup을 불러옴
        /// </summary>
        /// <param name="insMethod">사용할 CogToolGroup명</param>
        /// <returns>CogToolGroup</returns>
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

        /// <summary>
        /// 길이 측정하는거 같은데 뭐지
        /// TODO 뭐야 이거 어따쓰는거지
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CogCaliperTool CreateCaliperTool(string name)
        {
            CogCaliperTool caliper = new CogCaliperTool();
            caliper.Name = name;

            caliper.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
            caliper.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DontCare;
            caliper.RunParams.Edge0Position = 0;

            return caliper;
        }
    }
}
