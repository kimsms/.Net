using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace ServerSideSocket
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Socket Server, Client;

        public static byte[] getByte = new byte[1024];
        public static byte[] setByte = new byte[1024];

        public const int sPort = 5000;


        public MainWindow()
        {
            InitializeComponent();

            string stringbyte = null;
            IPAddress serverIP = IPAddress.Parse("192.168.0.153");
            IPEndPoint serverEndPoint = new IPEndPoint(serverIP, sPort);

            try
            {
                Server = new Socket(
                  AddressFamily.InterNetwork,
                  SocketType.Stream, ProtocolType.Tcp);

                Server.Bind(serverEndPoint);
                Server.Listen(10);

                Console.WriteLine("------------------------");
                Console.WriteLine("클라이언트의 연결을 기다립니다. ");
                Console.WriteLine("------------------------");

                Client = Server.Accept();

                if (Client.Connected)
                {
                    while (true)
                    {
                        Client.Receive(getByte, 0, getByte.Length, SocketFlags.None);
                        stringbyte = Encoding.UTF8.GetString(getByte);

                        if (stringbyte != String.Empty)
                        {
                            int getValueLength = 0;
                            getValueLength = byteArrayDefrag(getByte);

                            stringbyte = Encoding.UTF7.GetString(
                              getByte, 0, getValueLength + 1);

                            Console.WriteLine("수신데이터:{0} | 길이:{1}",
                              stringbyte, getValueLength + 1);

                            setByte = Encoding.UTF7.GetBytes(stringbyte);
                            Client.Send(setByte, 0, setByte.Length, SocketFlags.None);
                        }

                        getByte = new byte[1024];
                        setByte = new byte[1024];
                    }
                }
            }
            catch (System.Net.Sockets.SocketException socketEx)
            {
                Console.WriteLine("[Error]:{0}", socketEx.Message);
            }
            catch (System.Exception commonEx)
            {
                Console.WriteLine("[Error]:{0}", commonEx.Message);
            }
            finally
            {
                Server.Close();
                Client.Close();
            }

        }

        public static int byteArrayDefrag(byte[] sData)
        {
            int endLength = 0;

            for (int i = 0; i < sData.Length; i++)
            {
                if ((byte)sData[i] != (byte)0)
                {
                    endLength = i;
                }
            }

            return endLength;
        }


    }
}
