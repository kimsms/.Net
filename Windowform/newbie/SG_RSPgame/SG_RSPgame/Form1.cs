using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_RSPgame
{
    public partial class Form1 : Form
    {
        int timer;

        int Player;
        int Com;

        int WC;
        int MC;
        int LC;

        Random Ran = new Random();

        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            Com = Ran.Next(1, 4);
        }

        public void whoWinner()
        {
            if (Player == 1 && Com == 1)
            {
                mu();
            }
            else if (Player == 1 && Com == 2)
            {
                lose();
            }
            else if (Player == 1 && Com == 3)
            {
                win();
            }
            else if (Player == 2 && Com == 1)
            {
                lose();
            }
            else if (Player == 2 && Com == 2)
            {
                mu();
            }
            else if (Player == 2 && Com == 3)
            {
                win();
            }
            else if (Player == 3 && Com == 1)
            {
                win();
            }
            else if (Player == 3 && Com == 2)
            {
                lose();
            }
            else if (Player == 3 && Com == 3)
            {
                mu();
            }
        }

        public void win()
        {
            RButton.Enabled = false;
            SButton.Enabled = false;
            PButton.Enabled = false;
            WorLLabel.Text = "승리";
            WC++;
            winCount.Text = "승리 : " + WC;
            timer = 1;
            timer1.Start();
        }

        public void lose()
        {
            RButton.Enabled = false;
            SButton.Enabled = false;
            PButton.Enabled = false;
            WorLLabel.Text = "패배";
            LC++;
            loseCount.Text = "패배 : " + LC;
            timer = 1;
            timer1.Start();
        }

        public void mu()
        {
            RButton.Enabled = false;
            SButton.Enabled = false;
            PButton.Enabled = false;
            WorLLabel.Text = "무승부";
            MC++;
            muCount.Text = "무승부 : " + MC;
            timer = 1;
            timer1.Start();
        }

        private void SButton_Click(object sender, EventArgs e)
        {
            Player = 1;
            whoWinner();
        }
        private void RButton_Click(object sender, EventArgs e)
        {
            Player = 2;
            whoWinner();
        }

        private void PButton_Click(object sender, EventArgs e)
        {
            Player = 3;
            whoWinner();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer > 0)
            {
                timer--;
                RButton.Enabled = false;
                SButton.Enabled = false;
                PButton.Enabled = false;
            }
            else
            {
                Com = Ran.Next(1, 4);
                RButton.Enabled = true;
                SButton.Enabled = true;
                PButton.Enabled = true;
                WorLLabel.Text = "";
                timer1.Stop();

            }
        }


          //-------------------------------------------
          //-------------------------------------------
    }
}
