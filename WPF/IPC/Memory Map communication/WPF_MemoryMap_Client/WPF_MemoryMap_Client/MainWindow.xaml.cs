using System;
using System.Collections.Generic;
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

using System.IO.MemoryMappedFiles;
using System.IO;

namespace WPF_MemoryMap_Client
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // MemoryMapTest로 이름붙인 공유 Memory 열기
            MemoryMappedFile.CreateOrOpen("MemoryMapTest",1000);
            var mappedFile = MemoryMappedFile.OpenExisting(

                "MemoryMapTest",

                MemoryMappedFileRights.ReadWrite);



            // 공유 Memory에서 읽은 것을 Stream으로 받기

            using (Stream view = mappedFile.CreateViewStream())

            {

                // stream을 String으로 변환

                view.Position = 0;

                using (StreamReader reader = new StreamReader(view, Encoding.UTF8))

                {

                    // Textbox에 표시 

                    txtReadMemory.Text = reader.ReadToEnd();
                    MessageBox.Show(reader.ReadToEnd());

                }

            }
        }
    }
}
