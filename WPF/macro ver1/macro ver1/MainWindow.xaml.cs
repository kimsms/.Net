using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace macro_ver1
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Thread findXY = new Thread(finXY);
            findXY.IsBackground = true;
            findXY.Start();
        }

        void finXY()
        {
            while (true)
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                {
                    var point = Mouse.GetPosition(this);
                    Xlabel.Content = point.X;
                    Ylabel.Content = point.Y;
                }));
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            

        }
    }
}
