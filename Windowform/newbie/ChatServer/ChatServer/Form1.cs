using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        int a;
        bool autodown;
        bool Security_mode;
        bool[] chatON = new bool[99];
        string[] chatname = new string[99];
        string[] ipArrangement = new string[99];
        int b;
        string[] namecheck = new string[] { "김찬희", "김성민","박우빈","박동유","이준영","양희수","구승현" };

        string filepath;
        string SecurityKey;
        string SecurityKey2;

        public Form1()
        {
            InitializeComponent();
            a = ran.Next(0, 10000);
            int yy = DateTime.Now.Year;
            int mm = DateTime.Now.Month;
            int dd = DateTime.Now.Day;
            int re = yy + mm + dd;
            Clipboard.SetText(re.ToString());
            label1.Text = "ip : " + Client_IP + " port : " + a;
            // socket start
            Thread t = new Thread(InitSocket);
            t.IsBackground = true;
            t.Start();
            


        }


        // 해시 문자열을 스트링으로 받아오는 함수, 아래 str 은 파일의 경로를 지정한다.
        private static string getMD5Hash(string str)
        {
            using (var md5 = MD5.Create())
            {
                //using (var stream = File.OpenRead(str))

                using (var stream = File.OpenRead(str))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        TcpListener server = null;
        TcpClient clientSocket = null;
        static int counter = 0;

        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();

        public void InitSocket()    // 소켓 접속
        {
            server = new TcpListener(IPAddress.Any, a);
            clientSocket = default(TcpClient);
            server.Start();
            DisplayText(">> Server Started");
            while (true)
            {
                try
                {
                    counter++;
                    clientSocket = server.AcceptTcpClient();

                    NetworkStream stream = clientSocket.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string user_name = Encoding.Unicode.GetString(buffer, 0, bytes);
                    user_name = user_name.Substring(0, user_name.IndexOf("$"));

                    if(namecheck.Contains(user_name) == false)
                    {
                        DisplayText("누군가 " + user_name + "의 이름으로 접속을 시도했습니다.");
                        SendMessageAll("누군가 " + user_name + "의 이름으로 접속을 시도했습니다.", "", false);
                        return;
                    }

                    if (listBox1.Items.Contains(user_name) == true)
                    {
                        SendMessageAll("System : 누군가 \"" + user_name + "\"님의 이름으로 접속을 시도했습니다.", "", false);
                        DisplayText("System : 누군가 \"" + user_name + "\"님의 이름으로 접속을 시도했습니다.");
                        return;
                    }
                    else
                    {

                        chatON[counter] = false;
                        chatname[counter] = user_name;

                        DisplayText(user_name + "님이 접속하였습니다.");
                        clientList.Add(clientSocket, user_name);
                        listBox1.Items.Add(user_name);



                        // send message all user
                        SendMessageAll(user_name + " Joined ", "", false);


                        handleClient h_client = new handleClient();
                        h_client.OnReceived += new handleClient.MessageDisplayHandler(OnReceived);
                        h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected);
                        h_client.startClient(clientSocket, clientList);
                    }
                }
                catch (SocketException se)
                {
                    Trace.WriteLine(string.Format("InitSocket - SocketException : {0}", se.Message));
                    break;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(string.Format("InitSocket - Exception : {0}", ex.Message));
                    break;
                }
            }

            clientSocket.Close();
            server.Stop();

        }

        void h_client_OnDisconnected(TcpClient clientSocket)    // 소켓 연결 해제시
        {
            if (clientList.ContainsKey(clientSocket))
                clientList.Remove(clientSocket);
        }

        private void OnReceived(string message, string user_name)   //메세지를 클라이언트 -> 서버 -> 다른 클라이언트
        {
            if (message.Substring(0, 1) == "▦")
            {
                ipArrangement[counter] = message;
                return;
            }
            if (message.Substring(0, 1) == "▩") 
            {
                DisplayText(message);
                if(message != SecurityKey2)
                {
                    int numval = Array.IndexOf(chatname, user_name);
                    chatON[numval] = true;
                    listBox1.Items.Remove(user_name);
                    DisplayText("System : 비정상적인 접속 차단 됨. name : "+ user_name);
                    SendMessageAll("System : 비정상적인 접속이 차단되었습니다 name : " + user_name, "", false);
                    textBox1.Clear();
                }
                else
                {
                    return;
                }
            }
            if (message == "wjqthrwhdfy▦")
            {
                listBox1.Items.Remove(user_name);
                DisplayText("System : " + user_name + "님이 접속을 종료하였습니다.");
                SendMessageAll("wjqthrwhdfy▦", user_name, false);
                return;
            }
            if (message == "▒ghcnf"+ "rntmdgus")    //user to user 멘션
            {
                DisplayText(user_name + "-> 구승현 멘션");
                SendMessageAll("System : " + user_name + "님이 구승현 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "구승현", "", false);
                return;
            }
            if (message == "▒ghcnf" + "rlatjdals")
            {
                DisplayText(user_name + "-> 김성민 멘션");
                SendMessageAll("System : " + user_name + "님이 김성민 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "김성민", "", false);
                return;
            }
            if (message == "▒ghcnf" + "rlacksgml")
            {
                DisplayText(user_name + "-> 김찬희 멘션");
                SendMessageAll("System : " + user_name + "님이 김찬희 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "김찬희", "", false);
                return;
            }
            if (message == "▒ghcnf" + "qkrehddb")
            {
                DisplayText(user_name + "-> 박동유 멘션");
                SendMessageAll("System : " + user_name + "님이 박동유 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "박동유", "", false);
                return;
            }
            if (message == "▒ghcnf" + "qkrdnqls")
            {
                DisplayText(user_name + "-> 박우빈 멘션");
                SendMessageAll("System : " + user_name + "님이 박우빈 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "박우빈", "", false);
                return;
            }
            if (message == "▒ghcnf" + "didgmltn")
            {
                DisplayText(user_name + "-> 양희수 멘션");
                SendMessageAll("System : " + user_name + "님이 양희수 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "양희수", "", false);
                return;
            }
            if (message == "▒ghcnf" + "dlwnsdud")
            {
                DisplayText(user_name + "-> 이준영 멘션");
                SendMessageAll("System : " + user_name + "님이 이준영 님을 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "이준영", "", false);
                return;
            }
            if(message == "▒ghcnf" + "ahen")
            {
                DisplayText(user_name + "-> 모두 멘션");
                SendMessageAll("System : " + user_name + "님이 모두를 멘션하였습니다.", "", false);
                SendMessageAll("▦apstus" + "구승현", "", false);
                DisplayText("구슴현 멘션 완료");
                SendMessageAll("▦apstus" + "김성민", "", false);
                DisplayText("김성민 멘션 완료");
                SendMessageAll("▦apstus" + "김찬희", "", false);
                DisplayText("김찬희 멘션 완료");
                SendMessageAll("▦apstus" + "박동유", "", false);
                DisplayText("박동유 멘션 완료");
                SendMessageAll("▦apstus" + "박우빈", "", false);
                DisplayText("박우빈 멘션 완료");
                SendMessageAll("▦apstus" + "양희수", "", false);
                DisplayText("양희수 멘션 완료");
                SendMessageAll("▦apstus" + "이준영", "", false);
                DisplayText("이준영 멘션 완료");
                return;
            }
            if (message == "tjqjvhrvk▦")
            {
                this.Close();
            }
            if (message == "▥rlsrmqwjdwl")
            {
                if(checkBox3.Checked == false)
                {
                    DisplayText(user_name + "이 긴급정지");
                    SendMessageAll("System : 긴급정지가 허용되지 않았습니다.", user_name, false);
                    return;
                }
                else
                {
                    DisplayText("폭파");
                    SendMessageAll("tjqjvhrvk▦", "", false);
                    textBox1.Clear();
                    button1.Enabled = false;
                    this.Close();
                }
            }
            if (Security_mode == true)
            {
                string displayMessage = "??? : " + message;
                DisplayText(displayMessage);
                SendMessageAll(message, user_name, true);
            }
            else
            {
                string displayMessage = "From client : " + user_name + " : " + message;
                DisplayText(displayMessage);
                SendMessageAll(message, user_name, true);
            }
        }

        public void SendMessageAll(string message, string user_name, bool flag) //"메세지", "유저 이름", "이름 표시 유/무"  클라이언트에게 메세지를 보내는 부분
        {
            foreach (var pair in clientList)
            {
                Trace.WriteLine(string.Format("tcpclient : {0} user_name : {1}", pair.Key, pair.Value));

                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;

                if (flag)
                {
                    if (Security_mode == true)
                    {
                        if (message == "wjqthrwhdfy▦")
                        {
                            buffer = Encoding.Unicode.GetBytes("???님이 접속을 종료하였습니다.");
                        }
                        else
                        {
                            buffer = Encoding.Unicode.GetBytes("??? : " + message);
                        }

                        if (message == "tjqjwhdfy▦")
                        {
                            buffer = Encoding.Unicode.GetBytes("System : 서버가 종료되었습니다.");
                        }
                    }
                    else
                    {
                        if (message == "wjqthrwhdfy▦")
                        {
                            buffer = Encoding.Unicode.GetBytes("System : " + user_name + "님이 접속을 종료하였습니다.");
                            SendMessageAll(user_name + "님이 접속을 종료하였습니다.", user_name, true);
                        }
                        else
                        {
                            if (chatname.Contains(user_name) == true)
                            {
                                int numval = Array.IndexOf(chatname, user_name);
                                if (chatON[numval] != true)
                                {
                                    buffer = Encoding.Unicode.GetBytes(user_name + " : " + message);    // 클라이언트로 메세지 전송
                                }
                            }

                        }


                        if (message == "tjqjwhdfy▦")
                        {
                            buffer = Encoding.Unicode.GetBytes("System : 서버가 종료되었습니다.");
                        }
                    }

                }
                else
                {
                    buffer = Encoding.Unicode.GetBytes(message);
                }

                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }


        private void DisplayText(string text)   //메세지들을 서버 richbox에 넣어주는 부분 
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new MethodInvoker(delegate
                {
                    richTextBox1.AppendText(text + Environment.NewLine);
                    if (autodown == false)
                    {
                        richTextBox1.ScrollToCaret();
                    }
                }));
            }
            else
            {
                richTextBox1.AppendText(text + Environment.NewLine);
                if (autodown == false)
                {
                    richTextBox1.ScrollToCaret();
                }
            }
        }


        public static string Client_IP  // 아이피 불러오기
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string ClientIP = string.Empty;
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ClientIP = host.AddressList[i].ToString();
                    }
                }
                return ClientIP;
            }
        }

        private void button1_Click(object sender, EventArgs e)  // 내용 저장
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                sw.Write(richTextBox1.Text);
                sw.Close();

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)    //명령어
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {


                    if (textBox1.Text.Contains("/help"))
                    {
                        DisplayText("----------------------\n/지우개 : 화면 지우기 \n/ban (이름) : 밴\n/눈치게임 : 눈치게임\n/stop : 채팅창 기록 삭제 밑 종료\n/공격(이름) : 상대방에게 경고알림창을 보냄\n/멘션(이름) : 상대방을 멘션함\n/테러(이름) : 상대방의 화면에 테러를 함\n----------------------");
                    }

                    else if (textBox1.Text.Contains("/지우개") == true)
                    {

                        for (int i = 0; i < 50; i++)
                        {
                            DisplayText("지우개");
                            SendMessageAll(" ", "", false);

                            textBox1.Clear();
                        }
                    }

                    else if (textBox1.Text.Contains("/stop"))
                    {

                            DisplayText("폭파");
                            SendMessageAll("tjqjvhrvk▦", "", false);
                            textBox1.Clear();
                            button1.Enabled = false;
                            this.Close();
                        
                    }

                    else if (textBox1.Text.Contains("/ban 박우빈") == true)
                    {
                        int numval = Array.IndexOf(chatname, "박우빈");
                        chatON[numval] = true;
                        listBox1.Items.Remove("박우빈");
                        DisplayText("System : 박우빈 밴 완료");
                        SendMessageAll("System : 박우빈 님이 차단되었습니다.", "", false);

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Contains("/ban 김찬희") == true)
                    {
                        int numval = Array.IndexOf(chatname, "김찬희");
                        chatON[numval] = true;
                        listBox1.Items.Remove("김찬희");
                        DisplayText("System : 김찬희 밴 완료");
                        SendMessageAll("System : 김찬희 님이 차단되었습니다.", "", false);

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Contains("/ban 박동유") == true)
                    {
                        int numval = Array.IndexOf(chatname, "박동유");
                        chatON[numval] = true;
                        listBox1.Items.Remove("박동유");
                        DisplayText("System : 박동유 밴 완료");
                        SendMessageAll("System : 박동유 님이 차단되었습니다.", "", false);

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Contains("/ban 이준영") == true)
                    {
                        int numval = Array.IndexOf(chatname, "이준영");
                        chatON[numval] = true;
                        listBox1.Items.Remove("이준영");
                        DisplayText("System : 이준영 밴 완료");
                        SendMessageAll("System : 이준영 님이 차단되었습니다.", "", false);

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Contains("/ban 양희수") == true)
                    {
                        int numval = Array.IndexOf(chatname, "양희수");
                        chatON[numval] = true;
                        listBox1.Items.Remove("양희수");
                        DisplayText("System : 양희수 밴 완료");
                        SendMessageAll("System : 양희수 님이 차단되었습니다.", "", false);

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Contains("/ban 구승현") == true)
                    {
                        int numval = Array.IndexOf(chatname, "구승현");
                        chatON[numval] = true;
                        listBox1.Items.Remove("구승현");
                        DisplayText("System : 구승현 밴 완료");
                        SendMessageAll("System : 구승현 님이 차단되었습니다.", "", false);

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Contains("/눈치게임"))
                    {
                        DisplayText("System : 눈치게임 활성화");
                        SendMessageAll("System : 일정 시간 후 눈치게임이 시작됩니다. (ex.-----시작-----)","",false);
                        Random ran = new Random();
                        b = ran.Next(1, 11);
                        timer1.Start();

                        textBox1.Clear();
                    }

                    else if (textBox1.Text.Length > 3 && textBox1.Text.Substring(0,3)=="/멘션")
                    {
                        DisplayText(textBox1.Text.Substring(3)+"를 멘션");
                        SendMessageAll("System : " + textBox1.Text.Substring(3) + "님을 멘션하였습니다.", "", false);
                        SendMessageAll("▦apstus" + textBox1.Text.Substring(3), "", false);
                        
                        textBox1.Clear();
                    }
                    else if (textBox1.Text.Length > 3 && textBox1.Text.Substring(0,3) == "/공격")
                    {
                        DisplayText(textBox1.Text.Substring(3) + "를 공격");
                        SendMessageAll("▦xpfj" + textBox1.Text.Substring(3), "", false);

                        textBox1.Clear();
                    }
                    else if(textBox1.Text.Length > 3 && textBox1.Text.Substring(0,3) == "/테러")
                    {
                        DisplayText(textBox1.Text.Substring(3) + "를 테러");
                        SendMessageAll("▧xpfj" + textBox1.Text.Substring(3), "", false);

                        textBox1.Clear();
                    }
                    else if (textBox1.Text.Length >= 1 && textBox1.Text.Substring(0,1) == "/")
                    {
                        MessageBox.Show("올바른 명령어가 아닙니다.");
                        textBox1.Clear();
                        return;
                    }

                    //-------------------------비공개---------------------
                    else
                    {
                        if (Security_mode == true)
                        {
                            DisplayText("??? : " + textBox1.Text);
                            SendMessageAll("??? : " + textBox1.Text, "", false);
                            textBox1.Clear();
                        }
                        else
                        {
                            DisplayText("Server : " + textBox1.Text);
                            SendMessageAll("Server : " + textBox1.Text, "", false);
                            textBox1.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)   // 자동 줄 내림 ON/OFF
        {
            if (autodown == true)
            {
                autodown = false;
            }
            else
            {
                autodown = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)   // 보안모드 ON/OFF
        {
            if (Security_mode == false)
            {
                Security_mode = true;

            }
            else
            {
                Security_mode = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)   // 서버종료 메세지 보냄
        {
            SendMessageAll("tjqjwhdfy▦", "", true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (b > 0)
            {
                b--;
            }
            else
            {
                DisplayText("System : 게임시작");
                SendMessageAll("-----눈치게임 시작-----","",false);
                timer1.Stop();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)  // 리스트박스에 넣어진 아이피 불러오기
        {
            if (listBox1.SelectedItem != null) 
            { int Selected_index = listBox1.SelectedIndex;
                //MessageBox.Show(Selected_index.ToString());
                MessageBox.Show(ipArrangement[Selected_index+2],listBox1.SelectedItem.ToString());
                //MessageBox.Show(listBox1.Items[Selected_index].ToString());
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                //MessageBox.Show(getMD5Hash(filepath));
                SecurityKey = getMD5Hash(filepath);
                SecurityKey2 = "▩" + SecurityKey + "▩";
                DisplayText(SecurityKey2);
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            
        }
    }
}
