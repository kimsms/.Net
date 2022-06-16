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

namespace ClientSideSocket
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Socket socket;
        public static byte[] getbyte = new byte[1024];
        public static byte[] setbyte = new byte[1024];

        public const int sPort = 5000;


        public MainWindow()
        {
            InitializeComponent();

            ViewTextBox.AppendText("----------------------------------------------\n");
            ViewTextBox.AppendText(" 서버로 접속합니다.[버튼을 눌러주세요] \n");
            ViewTextBox.AppendText("----------------------------------------------");
            
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

        private void Conbtn_Click(object sender, RoutedEventArgs e)
        {
            string sendstring = null;
            string getstring = null;

            IPAddress serverIP = IPAddress.Parse("192.168.0.153");
            IPEndPoint serverEndPoint = new IPEndPoint(serverIP, sPort);

            socket = new Socket(
              AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            /*Console.WriteLine("------------------------------");
            Console.WriteLine(" 서버로 접속합니다.[엔터를 입력하세요] ");
            Console.WriteLine("------------------------------");
            Console.ReadLine();*/

            try
            {
                socket.Connect(serverEndPoint);

                if (socket.Connected)
                {
                    Console.WriteLine(">>연결 되었습니다.(데이터를 입력하세요)");
                }

                while (true)
                {
                    Console.Write(">>");
                    sendstring = Console.ReadLine();

                    if (sendstring != String.Empty)
                    {
                        int getValueLength = 0;
                        setbyte = Encoding.UTF8.GetBytes(sendstring);

                        socket.Send(setbyte, 0,
                          setbyte.Length, SocketFlags.None);

                        Console.WriteLine("송신 데이터 : {0} | 길이{1}",
                          sendstring, setbyte.Length);

                        socket.Receive(getbyte, 0,
                          getbyte.Length, SocketFlags.None);

                        getValueLength = byteArrayDefrag(getbyte);

                        getstring = Encoding.UTF7.GetString(getbyte,
                          0, getValueLength + 1);

                        Console.WriteLine(">>수신된 데이터 :{0} | 길이{1}",
                          getstring, getValueLength + 1);
                    }

                    getbyte = new byte[1024];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
