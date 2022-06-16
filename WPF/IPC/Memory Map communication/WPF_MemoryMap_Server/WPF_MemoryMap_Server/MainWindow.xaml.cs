using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
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


namespace WPF_MemoryMap_Server
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        //MemoryMappedFile mapFile = MemoryMappedFile.CreateNew("MemoryMapTest", 500);
        public MainWindow()
        {
            InitializeComponent();

            //MemoryMappedFile.CreateOrOpen("MemoryMapTest", 1000);
            //MemoryMappedFile.CreateFromFile("MemoryMapTest");
            
        }

        // 파일 매핑한 공유 메모리 쓰기
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Mapping된 file 가져오기


            /*MemoryMappedFile mapFile = MemoryMappedFile.OpenExisting(

                "MemoryMapTest",

                MemoryMappedFileRights.ReadWrite);*/
            MemoryMappedFile mapFile = MemoryMappedFile.CreateOrOpen("MemoryMapTest", 500);
            



            MemoryMappedViewAccessor accessor = mapFile.CreateViewAccessor();



            // 공유 Memory에 쓰기

            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(txtMemory.Text + "\0");

            accessor.WriteArray(0, Buffer, 0, Buffer.Length);



            accessor.Dispose();

            mapFile.Dispose();
        }

        // 파일 매핑한 공유 메모리 읽기
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*MemoryMappedFile mapFile = MemoryMappedFile.OpenExisting(

                "MemoryMapTest",

                MemoryMappedFileRights.ReadWrite);*/
            MemoryMappedFile mapFile = MemoryMappedFile.CreateOrOpen("MemoryMapTest", 500);


            using (Stream view = mapFile.CreateViewStream())

            {

                // stream을 String으로 변환

                view.Position = 0;

                using (StreamReader reader = new StreamReader(view, Encoding.UTF8))

                {

                    txtMemory.Text = reader.ReadToEnd();

                }

            }
        }

    }
}
