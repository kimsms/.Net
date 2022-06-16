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

namespace Clinet
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
            Console.WriteLine("Memory mapped file reader started"); 
            using (var file = MemoryMappedFile.OpenExisting("myFile")) 
            {
                using (var reader = file.CreateViewAccessor(0, 24)) 
                { 
                    var bytes = new byte[24]; reader.ReadArray<byte>(0, bytes, 0, bytes.Length);
                    Console.WriteLine("Reading bytes");
                    for (var i = 0; i < bytes.Length; i++)
                        Console.Write((char)bytes[i] + " "); 
                    Console.WriteLine(string.Empty);
                } 
            }
            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }
    }
}
