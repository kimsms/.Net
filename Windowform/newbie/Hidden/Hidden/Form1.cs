using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
//https://m.blog.naver.com/PostView.nhn?blogId=ocllos&logNo=220582980441&proxyReferer=https:%2F%2Fwww.google.com%2F
namespace Hidden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 엔터가 눌리면 string을 listbox1 과 로그에 저장
            if(e.KeyChar == 13)
            {
                // 로그 출력 및 저장
                SaveLogFile(textBox1.Text);

                // 텍스트박스 문자열 초기화
                textBox1.Text = "";
            }
        }
        #region Log Data 저장
        public void SaveLogFile(string inLogMessage)
        {
            // 로그 데이터 파일에 들어갈 날짜 얻어오기
            string strDate;
            GetSystemDate(out strDate);

            // 로그 데이터가 저장될 폴더와 파일명 설정
            string FilePath = string.Format(Application.StartupPath + "\\" + "DataFile" + "\\" + strDate + ".txt");
            FileInfo fi = new FileInfo(FilePath);

            // 폴더가 존재하는지 확인하고 존재하지 않으면 폴더부터 생성
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\" + "DataFile");

            if (dir.Exists == false)
            {
                // 새로 생성합니다.
                dir.Create();

                dir.Attributes = FileAttributes.ReadOnly;
                if((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    dir.Attributes = dir.Attributes | FileAttributes.Hidden;
                }
            }

            // 기존 로그 데이터가 존재시 이어쓰고 아니면 새로 생성
            try
            {
                if(fi.Exists != true)
                {
                    using(StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine(inLogMessage);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(inLogMessage);
                        sw.Close();
                    }
                }
            }
            catch(Exception e)
            {

            }
        }
        #endregion

        #region 프로그램 날자 얻어오기
        public void GetSystemDate(out string outTime)
        {
            outTime = string.Format(DateTime.Now.ToString("yyyy.MM.dd"));
        }
        #endregion
    }
}
