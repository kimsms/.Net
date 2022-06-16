using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseball
{
    public partial class Form1 : Form
    {
        // 문제로 쓰일 4자리 숫자
        int[] question;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // 폼이 로드되면 게임 시작
            gameStart();
        }

        private void gameStart()
        {
            // 결과 리스트 초기화
            list_Result.Items.Clear();
            question = new int[4];            
            
            // 문제 생성 (0~9까지 4자리 겹치지 않는 난수 생성)
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                question[i] = r.Next(10);
                
                for (int j = 0; j < i; j++)
                {
                    if (question[j] == question[i]) i--;
                }
            }
        }

        // 입력 버튼을 클릭하였을 경우
        private void bt_Input_Click(object sender, EventArgs e)
        {
            // strike 와 ball 초기화
            int strike = 0;
            int ball = 0;
            
            // 입력값을 string 형태로 받고
            string input = tb_Input.Text;

            // 제대로된 입력값이 아니면 결과 출력 후 리턴
            if (inputValidation(input) == false) return;

            // 문제값과 입력값 비교
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // input[i]은 char형이므로 -48을 해야 비교됨
                    if ((int)input[i]-48 == question[j])
                    {
                        // 위치까지 같으면 strike
                        if (i == j) strike++;
                        else
                        {
                            ball++;
                        } 
                    }
                }
            }

            // 해당하는 결과 출력
            if (strike == 0 && ball == 0)
            {
                label_Result.Text = "OUT";
                list_Result.Items.Add(input + " = OUT");
            }
            else if (strike == 4)
            {
                label_Result.Text = "HomeRun!";
                gameStart();
            }
            else
            {
                label_Result.Text = "Strike : " + strike.ToString() + ", Ball : " + ball.ToString();
                list_Result.Items.Add(input + " = S : " + strike.ToString() + ", B : " + ball.ToString());
            }
        }

        // 입력값 유효성 체크
        private bool inputValidation(string input)
        {
            // 입력받은 문자의 개수가 4개가 아닐경우
            if (input.Length != 4)
            {
                label_Result.Text = "숫자 4개를 입력해주세요";
                return false;
            }

            // 입력받은 문자가 숫자가 아니거나 중복값이 있을경우
            for (int i = 0; i < 4; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    label_Result.Text = "0-9 숫자들만 입력해주세요";
                    return false;
                }

                for (int j = 0; j < i; j++)
                {
                    if (input[j] == input[i])
                    {
                        label_Result.Text = "중복된 숫자는 입력할 수 없습니다";
                        return false;
                    }
                }
            }
            
            // 별 문제가 없으면 true반환
            return true;
        }
    }
}