using System;
using System.Activities;
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

namespace Server
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Handle handle;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Memory mapped file server started"); 
            using (var file = MemoryMappedFile.CreateNew("myFile", int.MaxValue)) 
            { 
                var bytes = new byte[24]; 
                for (var i = 0; i < bytes.Length; i++) 
                    bytes[i] = (byte)(65 + i); 
                using (var writer = file.CreateViewAccessor(0, bytes.Length)) 
                { 
                    writer.WriteArray<byte>(0, bytes, 0, bytes.Length);
                } 
                Console.WriteLine("Run memory mapped file reader before exit");
                Console.WriteLine("Press any key to exit ..."); 
                Console.ReadLine(); 
            }
        }
    }
}
