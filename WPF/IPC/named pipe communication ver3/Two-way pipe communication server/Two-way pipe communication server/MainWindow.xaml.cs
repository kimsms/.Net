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
using WPF_Named_Pipe_Server;

namespace Two_way_pipe_communication_server
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        NamedPipeControl Clinet = new NamedPipeControl("load");
        NamedPipeControl Server = new NamedPipeControl("test");
        List<string> list = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Clinet.ClientOpen);
            thread.IsBackground = true;
            thread.Start();

            Thread thread1 = new Thread(Server.ServerOpen);
            thread1.IsBackground = true;
            thread1.Start();

            Thread read = new Thread(readmsg);
            read.Start();
        }

        void readmsg()
        {
            list = Server.Readmsg();
            for(int i =0; i < list.Count; i++)
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                {
                    viewbox.AppendText(list[i]);
                }));
            }
            Thread read = new Thread(readmsg);
            read.IsBackground = true;
            read.Start();
        }

        private void sendbtn_Click(object sender, RoutedEventArgs e)
        {
            Clinet.Write(viewbox.Text);
        }
    }
}
