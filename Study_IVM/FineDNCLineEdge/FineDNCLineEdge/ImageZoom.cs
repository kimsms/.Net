using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FineDNCLineEdge
{
    internal class ImageZoom
    {
        /*
            사전에 마우스 Wheel 이벤트 직접 추가해야 함
            예시) pictureBox.MouseWheel += pictureBox_MouseWheel;
        */

        private int Speed = 10;
        private double limit = 999999999;

        public void setSpeed(int Speed = 10)
        {
            this.Speed = Speed;
        }

        public void setLimit(double limit = 999999999)
        {
            this.limit = limit;
        }

        public void MainPicturebox_MouseWheel(object sender, MouseEventArgs e, PictureBox pictureBox, Panel panel)
        {
            panel.AutoScroll = true;
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            if (lines > 0)
            {
                //확대 크기 제한
                if ((float)pictureBox.Width / (float)panel.Width > limit) return;

                pictureBox.Size = new System.Drawing.Size(pictureBox.Width + Speed, pictureBox.Height + Speed);
            }
            else if (lines < 0)
            {
                //축소 한계치
                if (pictureBox.Size.Width <= panel.Size.Width) return;


                pictureBox.Size = new System.Drawing.Size(pictureBox.Width - Speed, pictureBox.Height - Speed);
            }
        }
    }
}
