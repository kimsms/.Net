using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        int stage = 1;
        int anser;
        int clear;
        public Form1()
        {
            InitializeComponent();
            stages();
        }
        public void yes()
        {
            stage++;
            stages();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Visible = true;
        }
        public void no()
        {
            MessageBox.Show("틀렸습니다\n" + clear + "개의 문제를 맞추었습니다.");
            Application.Restart();
        }

        public void chkanser()
        {
            if(stage == 1 && anser == 3 || stage == 3 && anser == 2 || stage == 5 && anser == 4 || stage == 7 && anser == 1 || stage == 9 && anser == 4)
            {
                yes();
                clear++;
            }
            else if(stage == 11 && anser == 1)
            {
                yes();
                clear++;
            }
            else
            {
                no();
            }
        }

        public void stages()
        {
            if(stage == 1)
            {
                QuizLabel.Text = "어느 학교 교실에 20명의 학생들이 있었다. 그러던 어느날 야자 시간에 갑자기 정전이 되었고, 순간 비명소리가 들렸다." +
                                 "어둠 속에서 신음 소리가 이어졌고, 그 소리는 이내 멈추었다." +
                                 "그리고, 정확히 7분 후에 교실에 다시 불이 켜졌다."+
                                 "확인해보니 11번 '김태환' 학생이 숨져있었고, 그의 주변에는 그가 죽기 직전에 쓴 것으로 보이는 'LION' 이라는 핏빛 글자가 있었다."+
                                 "그의 주변의 학생들이 곧 용의자로 지목 되었다.\n"+
                                 "A. 13번 박용석, B. 15번 이연호 C. 17번 신승호, D. 20번 최현승\n"+
                                 "범인은 누구인가?";
            }else if(stage == 2)
            {
                QuizLabel.Text = "범인은 바로 '17번 신승호'이다. \nLION이라는 글자를 거꾸로 뒤집어보면 'NO. 17'이 된다. 고로 17번인 신승호가 범인이다.";
            }else if(stage == 3)
            {
                QuizLabel.Text = "어느 집에서 살인 사건이 일어났다. 피해자는 'Y씨' 살해 도구는 칼이었다. 피해자는 죽기 직전에 '#'이라는 메세지를 남기고 죽었다. Y씨와 관련이 있는 인물은 총 4명, 다음은 그들의 알리바이이다.\n A : 어제 전 혼자 술을 먹고 잤어요. 집에서 마셔서 본 사람은 없습니다. \n B : 전 가게를 운영해서, 직원들은 다 퇴근시키고 혼자 남아서 정리하다가 집에 왔죠. \n C : 전 어제 부모님 댁에 가서 하룻밤 자고 왔습니다. \n D : 어제 Y를 만나긴 했지만, 저녁만 먹고 헤어졌어요. 그 뒤론 차를 타고 집에 갔죠. \n 범인은 누구인가?";
            }else if(stage == 4)
            {
                QuizLabel.Text = "범인은 바로 'B' 이다.\n 다잉메세지로 적혀있던 '#'은 샵(#), 즉 가게라는 의미로 볼 수 있다. 따라서 범인은 가게를 운영하는 B이다.";
            }
            else if(stage == 5)
            {
                QuizLabel.Text = "갈림길에 두 노인이 서있다. 팻말에는 두 노인 중 한명은 참말만, 다른 한명은 거짓말만 한다. 질문은 한명에게 딱 한번만 할 수 있다라고 쓰여 있다 누구에게 어떤 질문을 해야 맞는 길로 갈 수 있을까?\n A : 왼쪽 노인에게 “왼쪽 길이 산티아고 가는 길인가요?”\n B : 오른쪽 노인에게 “오른쪽 길이 산티아고 가는 길인가요?”\n C : 아무에게나 “산티아고 가는 길이 어느 쪽인가요?”\n D : 아무에게나 “옆에 계신 분께 산티아고 가는 길을 물으면 어느 쪽이라고 답하실까요?”";
            }
            else if(stage == 6)
            {
                QuizLabel.Text = "정답은 D \n 아무에게나 “옆에 계신 분께 산티아고 가는 길을 물으면 어느 쪽이라고 답하실까요?” 질문한 노인이 참말을 하는 노인이라면, 옆 사람은 거짓말을 하는 노인이므로 틀린 길을 알려줄 것이라는 걸 알고 그렇게 답할 것이다. 만약 거짓말을 하는 노인에게 질문을 했다면, 그는 참말을 하는 노인과는 다른 길을 알려줄 것이다. 따라서 누구에게 묻든 답은 틀린 길이므로, 알려주는 쪽과 반대 방향으로 가면 산티아고로 갈 수 있다.";
            }
            else if(stage == 7)
            {
                QuizLabel.Text = "인적이 드문 새벽, 경기도 현풍동의 24시 편의점에 강도가 들었다. 범인은 혼자 가게를 지키던 아르바이트생을 기절시키고 금고를 털어갔다. 경보 시스템이 작동해 진양경찰서 이재한 순경이 편의점에 도착했을 땐 이미 범인이 떠난 뒤였고, 기절한 아르바이트생은 계속 깨어나지 못했다. 범인의 지문을 비롯한 기본적인 단서는 당연히 없었다. 하필이면 CCTV마저 고장난 상태. 하지만 포기하지 않고 현장을 수색하던 이재한 순경의 눈에 계산기 하나가 들어왔다. 계산기엔 71057735345 라는 숫자가 적혀 있었다. 평소 야간순찰 때 이 편의점에서 음료수를 사 마시며 아르바이트생과 친해진 이재한 순경은 아르바이트생이 수학과에 다닌다는 걸 알고 있었고, 이 숫자를 보고 범인이 일하는 곳을 알아냈다. 그곳은 어디일까? 편의점 주변엔 주유소(A), 금은방(B), 요가원(C), 세탁소(D)가 있다.";
            }
            else if(stage == 8)
            {
                QuizLabel.Text = "계산기에 적힌 디지털 숫자 ‘71057735345’를 180도 회전하면 영문자 ‘ShE SELLS OIL’이 된다. 즉, 범인은 여성으로 기름을 판매하는 주유소에서 일한다는 메시지로 풀이할 수 있다.";
            }
            else if(stage == 9)
            {
                QuizLabel.Text = "1초에 2배로 증가하는 세균이 있다. 이 세균이 병 하나를 가득 채우는 데는 1분이 걸린다. 그렇다면 병의 절반을 채우는 데는 시간이 얼마나 걸릴까?\n A : 30초 B : 48초 C : 55초 D : 59초";
            }
            else if(stage == 10)
            {
                QuizLabel.Text = "59초. 세균이 1초에 2배씩 증가하므로, 병의 절반을 채우는 데 59초, 가득 채우는 데 1분이 걸린다.";
            }
            else if(stage == 11)
            {
                QuizLabel.Text = "4개의 가방과 4개의 양말 색이 모두 하나씩 쌍을 이루고 있다. 당신의 눈은 가려졌고 빨강, 파랑, 하양, 노랑 양마을 각각 같은 색 가방에 넣어야 한다 4가지 중 3가지만 맞게 넣을 확률은 얼마인가?\n A : 0% B : 25% C : 50% D : 100%";
            }
            else if(stage == 12)
            {
                QuizLabel.Text = "정답은 'A' \n4가지 중 3가지가 일치했다면 당연히 나머지 1가지도 일치한다. 때문에 3가지만 맞을 확률은 0이다.";
            }
            else
            {
                MessageBox.Show("모든 문제(" + clear + "개)를 맞추었습니다!\n게임이 종료됩니다.");
                Application.Exit();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            anser = 1;
            chkanser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anser = 2;
            chkanser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anser = 3;
            chkanser();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anser = 4;
            chkanser();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stage++;
            stages();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Visible = false;
        }
    }
}
