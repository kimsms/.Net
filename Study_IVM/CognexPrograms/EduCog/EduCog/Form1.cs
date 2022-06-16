using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ToolGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduCog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt = "Bitmap";
            openFileDlg.Filter = "Bitmp Files(*.bmp)|*.bmp";
            openFileDlg.ShowDialog();
                
            using(Bitmap src = new Bitmap(openFileDlg.FileName))
            {
                cogDisplay1.Image = CogUtil.GetCogImage(src);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //화면 초기화
            cogDisplay1.InteractiveGraphics.Clear();
            cogDisplay1.StaticGraphics.Clear();

            //클래스 선언과 동시에 CTL.TestLibTool에 BLOB을 추가함
            CogTestLib CTL = new CogTestLib();

            //BLOB이 추가된 도구를 가져옴
            CogToolGroup toolGroup = (CogToolGroup)CTL.TestLibTool;

            //toolGroup에 들어있는 BLOB 클래스를 가져옴
            CogBlobTool tool1 = (CogBlobTool)toolGroup.Tools[0];
            //CogPMAlignTool pmtool = (CogPMAlignTool)toolGroup.Tools[0];
            
            //Test
            
            
            //true 선택된 영역 유무 확인
            if (tool1.Region == null)
            {
                CogRectangleAffine rectaffine = new CogRectangleAffine();
                rectaffine.Interactive = true;
                rectaffine.GraphicDOFEnable = Cognex.VisionPro.CogRectangleAffineDOFConstants.All;

                tool1.Region = rectaffine;
            }

            //BLOB에 화면의 이미지를 집어넣음
            tool1.InputImage = (CogImage8Grey)cogDisplay1.Image;

            //컨트롤러 선언
            //뭐하는 놈이지 데이터 받아와서 다시 ref형식으로 돌려주나
            CogBlobEditV2 edit = new CogBlobEditV2();
            //CogPMAlignEditV2 edit = new CogPMAlignEditV2();

            //컨트롤러에 정보입력(이미지, 영역)
            edit.Subject = tool1;

            //창 띄우기
            CogUtil.OpenToolWindow(edit, "TestTool");


            //? edit에 tool1넣고 띄웟는데 왜 tool1이 받아서 실행하지 뭐야
            tool1.Run();

            
            //도구 타입 확인 후 결과를 화면에 표시
            CogTestLib.FindToolSet(ref cogDisplay1, tool1);
        }


    }
}
