using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ImageClass
{
    public class ImageTools
    {
        #region 변수
        /// <summary>
        /// 저장시킬 이미지를 넣을 변수
        /// </summary>
        ConcurrentQueue<Image> ImgSaveList = new ConcurrentQueue<Image>();

        /// <summary>
        /// 이미지를 저장할 폴더의 경로를 저장할 변수
        /// </summary>
        string TxtSavePath = Application.StartupPath + "\\ImageSavePath.txt";

        /// <summary>
        /// 이미지를 저장할 경로를 넣을 변수
        /// </summary>
        string ImageStoragePath;

        /// <summary>
        /// 프로그램이 종료됐는지 확인할 변수
        /// </summary>
        bool StopThread = false;

        /// <summary>
        /// 파일 확장자(소문자로)
        /// </summary>
        string extension = "bmp";
        #endregion

        public ImageTools()
        {
            GetPath();
            Thread thread = new Thread(SaveThread);
            thread.Start();
        }

        /// <summary>
        /// 모든 Queue의 이미지를 저장한 후 스레드를 종료시킴
        /// </summary>
        public void Stop()
        {
            StopThread = true;
        }

        /// <summary>
        /// 이미지를 Queue에 넣어서 저장시킴
        /// </summary>
        /// <param name="image">저장할 이미지</param>
        public void Save(Image image)
        {
            ImgSaveList.Enqueue(image);
        }

        /// <summary>
        /// 이미지 저장 스레드
        /// </summary>
        private void SaveThread()
        {
            Image img;

            while (true)
            {
                //Queue에 이미지가 있으면 실행
                if (ImgSaveList.TryDequeue(out img))
                {
                    //저장위치에 폴더가 존재하는지 확인
                    DirectoryInfo di = new DirectoryInfo(ImageStoragePath);
                    if (!di.Exists)
                        di.Create();

                    Random ran = new Random();

                    //저장하는데 시간이 걸릴 수도 있기 때문에 저장할 시간을 정확하게 받아옴
                    string finaldata = $"{ImageStoragePath}{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.{extension}";
                    string Subfinaldata = $"{ImageStoragePath}{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}_{ran.GetHashCode()}.{extension}";

                    //동일명의 파일이 존재하는지 확인(Substring으로 1만분의 1초가 없는 파일이 있는지 확인)
                    FileInfo fi = new FileInfo(finaldata);
                    if (fi.Exists)
                    {
                        //현재 시간을 파일명으로 하여 저장함(같은 이름의 파일이 없기 때문에 1만분의 1초는 제외하고 저장)
                        //img.Save(Subfinaldata, System.Drawing.Imaging.ImageFormat.Bmp);
                        switch (extension)
                        {
                            case "bmp":
                                img.Save(Subfinaldata, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case "png":
                                img.Save(Subfinaldata, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case "jpg":
                                img.Save(Subfinaldata, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                        }
                    }
                    else
                    {
                        //같은 이름의 파일이 있을 경우 파일명에 1만분의 1초 단위를 달아 저장
                        //img.Save(finaldata, System.Drawing.Imaging.ImageFormat.Bmp);
                        switch (extension)
                        {
                            case "bmp":
                                img.Save(finaldata, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case "png":
                                img.Save(finaldata, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case "jpg":
                                img.Save(finaldata, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                        }
                    }
                }

                //Queue안에 저장할 이미지가 존재하지 않고 프로그램 종료 시켰다면 스레드를 중지
                if (ImgSaveList.IsEmpty && StopThread) break;
            }
        }
        /// <summary>
        /// 이미지를 저장할 폴더 경로를 선택
        /// </summary>
        public void SetPath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(TxtSavePath, dialog.SelectedPath + "\\");
                GetPath();
            }
        }

        /// <summary>
        /// 이미지를 저장할 폴더 경로를 직접 써넣을 경우 사용
        /// </summary>
        /// <param name="path">폴더 경로</param>
        public void SetPath(string path)
        {
            File.WriteAllText(TxtSavePath, path + "\\");
            GetPath();
        }

        /// <summary>
        /// 이미지를 저장할 경로가 써있는 txt파일을 읽어옴
        /// </summary>
        private void GetPath()
        {
            //TxtSavePath 데이터의 저장 경로에 txt가 있는지 확인
            FileInfo fi = new FileInfo(TxtSavePath);

            //데이터가 있다면 읽어와 저장 경로로 설정
            //없다면(else) 저장경로를 기본으로 설정(실행한 프로그램과 같은 경로에 ImgSave폴더를 생성)
            if (fi.Exists)
            {
                ImageStoragePath = File.ReadAllText(Application.StartupPath + "\\ImageSavePath.txt");
            }
            else
            {
                SetPath(Application.StartupPath + "\\ImgSave");
            }
        }

        public void SetExtension(string Extension)
        {
            if (Extension == "bmp" || Extension == "png" || Extension == "jpg")
            {
                extension = Extension;
            }
            else
            {
                MessageBox.Show("확장자는 bmp / png / jpg 만 지원합니다.");
            }
        }

        #region 기본 Load, Save
        /// <summary>
        /// 이미지 로드
        /// </summary>
        /// <returns></returns>
        public Bitmap Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png;)| *.bmp; *.jpg; *.png; | All files(*.*) | *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap recImg = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);

                return recImg.Clone(new Rectangle(0, 0, recImg.Width, recImg.Height), System.Drawing.Imaging.PixelFormat.DontCare);

            }
            return null;
        }

        /// <summary>
        /// 저장할 장소와 이미지 타입을 직접 설정 한 후 저장
        /// </summary>
        /// <param name="Image">저장할 이미지</param>
        public void SaveImage(Image Image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap File(*.bmp) | *.bmp |PNG File(*.png) | *.png |JPG File(*.jpg)| *.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Image == null)
                {
                    MessageBox.Show("저장할 이미지가 없습니다.");
                    return;
                }
                //선택한 방식에 따라 이미지 타입을 변경하여 저장
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 3:
                        Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
            }
        }
        #endregion
    }
}