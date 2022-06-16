using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Thumbnail_extractor
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapSource saveimage;
        public MainWindow()
        {
            InitializeComponent();
            startchange();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                startchange();
            }
        }

        public void startchange()
        {

                if (inputbox.Text.Length > 33 && inputbox.Text.Substring(0, 32) == "https://www.youtube.com/watch?v=")
                {
                    try
                    {
                        string temp = "https://img.youtube.com/vi/" + inputbox.Text.Substring(32) + "/maxresdefault.jpg";
                        //string temp2 = "https://img.youtube.com/vi/" + inputbox.Text.Substring(32) + "/sddefault.jpg";
                        Bitmap bitmap = WebImageView(temp);
                        imagebox.Source = BitmapToImageSource(bitmap);
                        //Bitmap bitmap2 = WebImageView(temp2);
                        //imagebox2.Source = BitmapToImageSource(bitmap2);


                        System.Windows.Media.Imaging.BitmapSource bitmapSource =
                        System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bitmap.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                        saveimage = bitmapSource;
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("오류");
                    return;
                }


            
            
        }

        public Bitmap WebImageView(string URL)

        {

            try

            {

                WebClient Downloader = new WebClient();

                Stream ImageStream = Downloader.OpenRead(URL);

                Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;

                return DownloadImage;

            }

            catch (Exception)

            {

                return null;

            }

        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                if(bitmap != null)
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();

                    return bitmapimage;

                }
                else
                {
                    BitmapImage bitmapimage = new BitmapImage();
                    return bitmapimage;
                }   
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startchange();
            SaveJPEGFile(saveimage, @"C:\Users", 1);
        }

        public static void SaveAsPng(RenderTargetBitmap src)
        {
            string filePath = "C:\\Users\\김성민\\Desktop";

            FileStream stream = new FileStream(filePath, FileMode.Create);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(src));

            encoder.Save(stream);

            stream.Close();
        }

        public void SaveJPEGFile(BitmapSource bitmapSource, string filePath, int qualityLevel) 
        { 
            JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder(); 
            jpegBitmapEncoder.QualityLevel = qualityLevel; 
            jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapSource)); 
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write)) 
            { 
                jpegBitmapEncoder.Save(fileStream); 
            } 
        }

    }
}
