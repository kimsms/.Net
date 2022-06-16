using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF_Named_Pipe_Client
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        NamedPipeControl Client = new NamedPipeControl("test");
        NamedPipeControl Server = new NamedPipeControl("load");
        List<string> list = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Thread testpipeopen = new Thread(Client.ClientOpen);
            testpipeopen.IsBackground = true;
            testpipeopen.Start();

            Thread loadpipeopen = new Thread(Server.ServerOpen);
            loadpipeopen.IsBackground = true;
            loadpipeopen.Start();

            Thread read = new Thread(readmsg);
            read.Start();
        }



        private void sendbtn_Click(object sender, RoutedEventArgs e)
        {
            sendbtn.IsEnabled = false;
            Thread sendmsg = new Thread(new ParameterizedThreadStart(send));
            sendmsg.IsBackground = true;
            sendmsg.Start(dataCount.Text);
            Thread chkend = new Thread(end);
            chkend.IsBackground = true;
            chkend.Start();
            

            void end()
            {
                while (true)
                {
                    if (!sendmsg.IsAlive)
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            sendbtn.IsEnabled = true;
                            return;
                        }));
                    }
                }
            }
        }

        void send(object Count)
        {
            for (int i = 0; i < int.Parse((string)Count); i++)
            {
                Client.Write(i.ToString());
            }
        }

        void readmsg()
        {
            list = Server.Readmsg();
            for (int i = 0; i < list.Count; i++)
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
    }
}
