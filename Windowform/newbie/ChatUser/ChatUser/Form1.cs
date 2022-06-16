using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using System.Security.Cryptography;
using System.IO;

namespace ChatUser
{
    public partial class MainForm : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;
        string getiptext = "";
        string getporttext;
        bool timestop;
        bool colormode;
        bool hardmode;
        Random ran = new Random();
        bool login;
        string IPlog;

        int R1 = 128;
        int G1 = 128;
        int B1 = 128;
        int R2 = 100;
        int G2 = 100;
        int B2 = 100;
        int Timeval = 0;
        // 도배방지
        int repeat;
        int stopcount;
        // 알림창
        bool STF;

        string SecurityKey;

        public MainForm()
        {
            InitializeComponent();
            IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
            IPlog = IPHost.AddressList[0].ToString();
            timer3.Start();
            timer5.Start();
            timer6.Start();
            MenBtnOff();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // 해시 문자열을 스트링으로 받아오는 함수, 아래 str 은 파일의 경로를 지정한다.
        private static string getMD5Hash(string str)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(str))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void GetMessage()   // 서버에서 메세지 받아오기
        {
            while (true)
            {
                try
                {
                    stream = clientSocket.GetStream();
                    int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                    byte[] buffer = new byte[BUFFERSIZE];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                    if (command(message, textBoxNickName.Text) != true) //서버에서 보낸 명령어 구분
                        DisplayText(message);
                    if (timestop != true)
                    {
                        richTextBox1.ScrollToCaret();
                        richTextBox2.ScrollToCaret();
                    }
                    if (message == "System : 서버가 종료되었습니다.")
                    {
                        login = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        private void DisplayText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new MethodInvoker(delegate
                {
                    richTextBox1.AppendText(text + Environment.NewLine);


                }));
            }
            else
            {
                richTextBox1.AppendText(text + Environment.NewLine);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (textBoxMessage.Text == "")
            {
                MessageBox.Show("내용을 입력하세요.", "오류");
            }
            else
            {


                repeat++;
                label4.Text = repeat.ToString();
                byte[] buffer = Encoding.Unicode.GetBytes(this.textBoxMessage.Text + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                textBoxMessage.Clear();
                timer2.Start();
                if (richTextBox2.Visible == true)
                {
                    timer1.Start();
                }
            }
        }

        public void IPT()
        {
            byte[] buffer = Encoding.Unicode.GetBytes("▦" + IPlog + "▦" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

        }

        public void SC()
        {
            byte[] buffer = Encoding.Unicode.GetBytes("▩" + SecurityKey + "▩" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {

            if (textBoxNickName.Text != "" && textBox2.Text != "")
            {
                

                getiptext = textBox1.Text;
                getporttext = textBox2.Text;
                try
                {
                    clientSocket.Connect(getiptext, int.Parse(getporttext));
                    stream = clientSocket.GetStream();

                    message = "Connected to Chat Server";
                    
                    login = true;

                    byte[] buffer = Encoding.Unicode.GetBytes(this.textBoxNickName.Text + "$");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();

                    Thread t_handler = new Thread(GetMessage);
                    t_handler.IsBackground = true;
                    t_handler.Start();


                    SecurityKey = getMD5Hash(this.openFileDialog1.FileName.ToString());
                    SC();

                    IPT();
                    richTextBox2.Text = "";

                    btnSend.Enabled = true;
                    textBoxNickName.TabStop = false;
                    textBox1.TabStop = false;
                    textBox2.TabStop = false;
                    textBox3.TabStop = false;
                    btnConnect.TabStop = false;
                    textBoxMessage.TabStop = true;

                    textBox1.PasswordChar = '*';
                    textBox2.PasswordChar = '*';
                    textBox3.PasswordChar = '*';

                    timer1.Start();
                    if (int.Parse(textBox3.Text) == passTime())
                    {
                        if (richTextBox2.Visible == true)
                        {
                            richTextBox2.Visible = false;
                            timer1.Stop();
                        }
                        else
                        {
                            timer1.Start();
                            richTextBox2.Visible = true;
                        }
                    }
                    DisplayText(message);
                    MenBtnOn();
                    btnConnect.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("이름 또는 포트를 확인하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBoxMessage.Text == "")
                    {
                        e.SuppressKeyPress = true;
                        MessageBox.Show("내용을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (btnSend.Enabled != true)
                    {
                        e.SuppressKeyPress = true;
                        MessageBox.Show("서버와의 연결을 확인하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxMessage.Clear();
                    }
                    else
                    {
                        char[] a = new char[32767]; // 배열 선언
                        a = textBoxMessage.Text.ToCharArray(); // 문자열을 char형 배열로 변환

                        string output = "";

                        for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
                        {
                            if (a[i] == '\0') // a[i]가 공백인지 검사
                                break; // 반복 종료
                            output += (char)(a[i] - 30000);// a[i]의 아스키 값에서 -30000한 문자를 output에 추가
                        }

                        textBoxMessage.Text = output;

                        repeat++;
                        label4.Text = repeat.ToString();

                        e.SuppressKeyPress = true;
                        byte[] buffer = Encoding.Unicode.GetBytes(this.textBoxMessage.Text + "$");
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                        textBoxMessage.Clear();
                        timer2.Start();


                        if (richTextBox2.Visible == true)
                        {
                            timer1.Start();
                        }
                    }
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBoxMessage.Text == "")
                    {
                        e.SuppressKeyPress = true;
                        MessageBox.Show("내용을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (btnSend.Enabled != true)
                    {
                        e.SuppressKeyPress = true;
                        MessageBox.Show("서버와의 연결을 확인하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxMessage.Clear();
                    }
                    else
                    {
                        try
                        {
                            repeat++;
                            label4.Text = repeat.ToString();

                            e.SuppressKeyPress = true;
                            byte[] buffer = Encoding.Unicode.GetBytes(this.textBoxMessage.Text + "$");
                            stream.Write(buffer, 0, buffer.Length);
                            stream.Flush();
                            textBoxMessage.Clear();
                            timer2.Start();
                            if (richTextBox2.Visible == true)
                            {
                                timer1.Start();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBoxMessage.Text = Clipboard.GetText();
            char[] a = new char[32767]; // 배열 선언
            a = textBoxMessage.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] + 30000);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
            }

            textBoxMessage.Text = output;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)    //화면 보호기
        {
            if (e.KeyCode == Keys.Escape && pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
            }
            else if (e.KeyCode == Keys.Escape && pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)   // darkmode 판별
        {
            if (colormode == true)
            {
                colormode = false;
                this.BackColor = MainForm.DefaultBackColor;
                textBoxNickName.BackColor = Color.White;
                textBoxMessage.BackColor = Color.White;
                richTextBox1.BackColor = Color.White;
                richTextBox2.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                richTextBox2.ForeColor = Color.Black;
                textBoxMessage.ForeColor = Color.Black;
            }
            else
            {
                colormode = true;
                this.BackColor = Color.FromArgb(R1, G1, B1);
                textBoxNickName.BackColor = Color.FromArgb(R2, G2, B2);
                textBoxMessage.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox1.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox2.BackColor = Color.FromArgb(R2, G2, B2);
                textBox1.BackColor = Color.FromArgb(R2, G2, B2);
                textBox2.BackColor = Color.FromArgb(R2, G2, B2);
                textBox3.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox1.ForeColor = Color.White;
                richTextBox2.ForeColor = Color.White;
                textBoxMessage.ForeColor = Color.White;
            }
            changecolor();
        }

        public void changecolor()   // 글씨색 변경
        {
            if (colormode == true && hardmode == true)
            {

                this.BackColor = Color.FromArgb(R1, G1, B1);
                textBoxNickName.BackColor = Color.FromArgb(R2, G2, B2);
                textBoxMessage.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox1.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox2.BackColor = Color.FromArgb(R2, G2, B2);
                textBox1.BackColor = Color.FromArgb(R2, G2, B2);
                textBox2.BackColor = Color.FromArgb(R2, G2, B2);
                textBox3.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox1.ForeColor = Color.Gray;
                richTextBox2.ForeColor = Color.Gray;
                textBoxMessage.ForeColor = Color.Gray;
            }
            else if (colormode == true && hardmode == false)
            {

                this.BackColor = Color.FromArgb(R1, G1, B1);
                textBoxNickName.BackColor = Color.FromArgb(R2, G2, B2);
                textBoxMessage.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox1.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox2.BackColor = Color.FromArgb(R2, G2, B2);
                textBox1.BackColor = Color.FromArgb(R2, G2, B2);
                textBox2.BackColor = Color.FromArgb(R2, G2, B2);
                textBox3.BackColor = Color.FromArgb(R2, G2, B2);
                richTextBox1.ForeColor = Color.White;
                richTextBox2.ForeColor = Color.White;
                textBoxMessage.ForeColor = Color.White;
            }
            else if (colormode == false && hardmode == true)
            {

                this.BackColor = MainForm.DefaultBackColor;
                textBoxNickName.BackColor = Color.White;
                textBoxMessage.BackColor = Color.White;
                richTextBox1.BackColor = Color.White;
                richTextBox2.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                richTextBox1.ForeColor = Color.FromArgb(200, 200, 200);
                richTextBox2.ForeColor = Color.FromArgb(200, 200, 200);
                textBoxMessage.ForeColor = Color.FromArgb(200, 200, 200);
            }
            else if (colormode == false && hardmode == false)
            {

                this.BackColor = MainForm.DefaultBackColor;
                textBoxNickName.BackColor = Color.White;
                textBoxMessage.BackColor = Color.White;
                richTextBox1.BackColor = Color.White;
                richTextBox2.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                richTextBox2.ForeColor = Color.Black;
                textBoxMessage.ForeColor = Color.Black;
            }
        }


        public int passTime()   // 패스워드 설정
        {
            int yy = DateTime.Now.Year;
            int mm = DateTime.Now.Month;
            int dd = DateTime.Now.Day;
            int re = yy + mm + dd;
            return re;
        }

        private void timer1_Tick(object sender, EventArgs e)    // 보호모드 기능
        {

            char[] a = new char[32767]; // 배열 선언
            a = richTextBox1.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] + ran.Next(5000, 10001));// a[i]의 아스키 값에서 -1한 문자를 output에 추가
            }

            richTextBox2.Text = output;
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();
            timer1.Stop();

        }

        private void timer2_Tick(object sender, EventArgs e)    //자동 줄 내리기
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
            timer2.Stop();
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)   // 체크박스 상태 변경
        {
            if (timestop == true)
            {
                timestop = false;
            }
            else
            {
                timestop = true;
            }
        }


        private void checkBox4_CheckedChanged(object sender, EventArgs e)   // 글씨색 변경
        {
            if (hardmode == false)
            {
                hardmode = true;
            }
            else
            {
                hardmode = false;
            }
            changecolor();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)    // 닫는창 표출
        {
            DialogResult exit = MessageBox.Show("접속을 종료히시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                if (login == true)
                {
                    byte[] buffer = Encoding.Unicode.GetBytes("wjqthrwhdfy▦" + "$");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)    // 도배 방지
        {
            if (repeat > 10)
            {
                timer3.Stop();
                timer5.Stop();
                textBoxMessage.Enabled = false;
                btnSend.Enabled = false;
                timer4.Start();
                stopcount++;
                repeat = stopcount * 10;
                for (int i = 0; i < stopcount * 100; i++)
                {
                    MessageBox.Show("도배금지", "그만해", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                label4.Text = repeat.ToString();
            }

        }

        private void timer4_Tick(object sender, EventArgs e)    // 채금시간 확인
        {

            repeat--;
            label4.Text = repeat.ToString();
            textBoxMessage.Text = "남은시간 : " + repeat;
            if (repeat <= 0)
            {
                timer4.Stop();
                textBoxMessage.Clear();
                textBoxMessage.Enabled = true;
                btnSend.Enabled = true;
                timer3.Start();
                timer5.Start();

            }
        }

        private void timer5_Tick(object sender, EventArgs e)    // 남은시간 표출
        {
            if (repeat > 0)
            {
                repeat--;
            }
            label4.Text = repeat.ToString();
        }

        private void timer6_Tick(object sender, EventArgs e)    // 강제종료
        {
            if (richTextBox1.Text.Contains("tjqjvhrvk▦"))
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
        public void notice()    // 알림창
        {
            if (checkBox5.Checked == true)
            {
                if (STF == false)
                {
                    Form2 newform2 = new Form2();
                    System.Drawing.Rectangle ScreenRectangle = Screen.PrimaryScreen.WorkingArea;

                    int xPos = ScreenRectangle.Width - newform2.Bounds.Width;   //화면 오른쪽 하단에서 얼마나 떨어뜨릴것인가 -(값)

                    int yPos = ScreenRectangle.Height - newform2.Bounds.Height;



                    newform2.Show();




                    newform2.SetBounds(xPos, yPos, newform2.Size.Width, newform2.Size.Height, BoundsSpecified.Location);

                    newform2.BringToFront();

                    STF = true;
                    timer7.Start();
                }

            }
        }
        private void testbutton_Click(object sender, EventArgs e)
        {
            notice();

        }

        private void timer7_Tick(object sender, EventArgs e)    // 알림창 표출 시간
        {


            timer1.Stop();
            STF = false;
        }

        public bool command(string servermessage, string username)  // 서버 명령어 확인
        {
            if (servermessage == "▦apstus" + username)  // 멘션
            {
                MessageBox.Show("멘션되었습니다.", "멘션", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (servermessage.Contains("▦apstus") == true)
            {
                return true;
            }
            else if (servermessage == "▦xpfj" + username)   //공격
            {
                Remessagebox();
                return true;
            }
            else if(servermessage.Contains("▦xpfj") == true)
            {
                return true;
            }
            else if(servermessage == "▧xpfj" + username)    //테러
            {
                int xpfjval = ran.Next(1,5);
                if (xpfjval == 1)
                {
                    System.Diagnostics.Process.Start("calc");
                }
                else if (xpfjval == 2)
                {
                    System.Diagnostics.Process.Start("notepad");
                }
                else if (xpfjval == 3)
                {
                    System.Diagnostics.Process.Start("cmd");
                }
                else if (xpfjval == 4)
                {
                    System.Diagnostics.Process.Start("explorer.exe", "https://google.com");
                }


                return true;
            }
            else if(servermessage.Contains("▧xpfj") == true)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public void Remessagebox()
        {
            DialogResult dr = MessageBox.Show("A fatal error has been detected. Error Number: 597884315 If you need help, please contact us at https://support.microsoft.com/. This translation is a trap, a trap station. There is no door to get off. You see this and understand that you will be very shy, but you are already late but I can help. Wake up from your house and scream in front of you and it will help you", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Retry)
            {
                Remessagebox();
            }
            else
            {
                DialogResult dr2 = MessageBox.Show("종료할 경우 PC에 심각한 손상이 생길 수 있습니다. 정말 종료하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr2 != DialogResult.Yes)
                {
                    Remessagebox();
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;

            MessageBox.Show("개발중...", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void Mention1_Click(object sender, EventArgs e) //구승현 rntmdgus
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "rntmdgus" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void Mention2_Click(object sender, EventArgs e) //김성민 rlatjdals
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "rlatjdals" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void Mention3_Click(object sender, EventArgs e) //김찬희 rlacksgml
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "rlacksgml" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void Mention4_Click(object sender, EventArgs e) //박동유 qkrehddb
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "qkrehddb" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void Mention5_Click(object sender, EventArgs e) //박우빈 qkrdnqls
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "qkrdnqls" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void Mention6_Click(object sender, EventArgs e) //양희수 didgmltn
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "didgmltn" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void Mention7_Click(object sender, EventArgs e) //이준영 dlwnsdud
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "dlwnsdud" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
        private void button1_Click(object sender, EventArgs e)  //모두 ahen
        {
            MentionTimer.Start();
            MenBtnOff();
            byte[] buffer = Encoding.Unicode.GetBytes("▒ghcnf" + "ahen" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void codeRed_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes("▥rlsrmqwjdwl" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void MentionTimer_Tick(object sender, EventArgs e)
        {
            if(Timeval < 10)
            {
                Timeval++;
            }
            else
            {
                MenBtnOn();
                MentionTimer.Stop();
                Timeval = 0;
            }
        }

        public void MenBtnOn()
        {
            Mention1.Visible = true;
            Mention2.Visible = true;
            Mention3.Visible = true;
            Mention4.Visible = true;
            Mention5.Visible = true;
            Mention6.Visible = true;
            Mention7.Visible = true;
            Mention8.Visible = true;
            MentionLabel.Visible = true;
        }
        public void MenBtnOff()
        {
            Mention1.Visible = false;
            Mention2.Visible = false;
            Mention3.Visible = false;
            Mention4.Visible = false;
            Mention5.Visible = false;
            Mention6.Visible = false;
            Mention7.Visible = false;
            Mention8.Visible = false;
            MentionLabel.Visible = false;
        }


    }
}
