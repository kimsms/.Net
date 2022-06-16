using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using System.IO;

namespace Image_compare
{
    public partial class Form1 : Form
    {
        bool ready1;
        bool ready2;
        int count;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                Bitmap oneImage = new Bitmap(openFileDialog1.FileName);
                ready1 = true;

                //pictureBox2.Image = oneImage;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Load(openFileDialog1.FileName);
                ready2 = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ready1 == true && ready2 == true)
            {
                TrySearch();
            }
            else
            {
                MessageBox.Show("파일을 선택하세요.", "오류");
            }
        }

        public void TrySearch()
        {
            Mat screen = null, find = null, res = null;

            try
            {
                screen = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
                find = OpenCvSharp.Extensions.BitmapConverter.ToMat(new Bitmap(pictureBox2.Image));

                res = screen.MatchTemplate(find, TemplateMatchModes.CCoeffNormed);

                double min, max = 0;

                Cv2.MinMaxLoc(res, out min, out max);

                //label1.Text = "검색 유사도 : " + max;
                textBox1.Text = max.ToString();
                count++;
                listBox1.Items.Add(count + " : " + max.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                screen.Dispose();
                find.Dispose();
                res.Dispose();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //SaveLogFile
            string result = ""; 
            foreach (var input_items in listBox1.Items)
            {
                result += string.Format("{0} ", input_items); 
            }
            SaveLogFile(result);
            MessageBox.Show("저장되었습니다");


        }

        public void SaveLogFile(string inLogMessage)
        {
            // 로그 데이터 파일에 들어갈 날짜 얻어오기
            string strDate;
            GetSystemDate(out strDate);

            // 로그 데이터가 저장될 폴더와 파일명 설정
            string FilePath = string.Format(Application.StartupPath + "\\" + "SaveFile" + "\\" + strDate + ".txt");
            FileInfo fi = new FileInfo(FilePath);

            // 폴더가 존재하는지 확인하고 존재하지 않으면 폴더부터 생성
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\" + "SaveFile");

            if (dir.Exists == false)
            {
                // 새로 생성합니다.
                dir.Create();

                //파일 숨김
                //dir.Attributes = FileAttributes.ReadOnly;
                if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    dir.Attributes = dir.Attributes | FileAttributes.Hidden;
                }
            }

            // 기존 로그 데이터가 존재시 이어쓰고 아니면 새로 생성
            try
            {
                if (fi.Exists != true)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        //foreach (ListViewItem item in listView1.Items)

                        //{

                        //    // 원하는 형태의 문자열로 한줄씩 기록

                        //    sw.WriteLine(string.Format("{0};{1};{2}"

                        //        , item.Text, item.SubItems[1].Text, item.SubItems[2].Text));

                        //}
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        #region 프로그램 날자 얻어오기
        public void GetSystemDate(out string outTime)
        {
            outTime = string.Format(DateTime.Now.ToString("yyyy.MM.dd"));
        }


        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            string a = System.Windows.Forms.Application.StartupPath;
            System.Diagnostics.Process.Start(a + "\\SaveFile");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            count = 0;
        }
    }
}
