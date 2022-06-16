using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Runtime.InteropServices;

namespace underInkey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isRunning = true;
        int a = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread TH = new Thread(Keyboardd);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();
        }

        void Keyboardd()
        {
            while (isRunning)
            {
                Thread.Sleep(40);
                if ((Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > 0 && (Keyboard.GetKeyStates(Key.P) & KeyStates.Down) > 0 && (Keyboard.GetKeyStates(Key.LeftShift) & KeyStates.Down) > 0)
                {
                    pictureBox1.Image = ScreenShot.take();
                    saveimg();
                }

                
            }
        }

        void saveimg()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                pictureBox1.Image.Save(saveFileDialog1.FileName,
                                System.Drawing.Imaging.ImageFormat.Bmp);
            }
            a++;
            pictureBox1.Image = null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        internal class API
        {
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("user32.dll", ExactSpelling = true)]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

            [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
            public static extern IntPtr GetDesktopWindow();
        }

        internal class ScreenShot
        {
            public static Bitmap take()
            {
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;

                Bitmap screenBmp = new Bitmap(screenWidth, screenHeight);
                Graphics g = Graphics.FromImage(screenBmp);

                IntPtr dc1 = API.GetDC(API.GetDesktopWindow());
                IntPtr dc2 = g.GetHdc();

                //Main drawing, copies the screen to the bitmap
                API.BitBlt(dc2, 0, 0, screenWidth, screenHeight, dc1, 0, 0, 13369376); //last number is the copy constant

                //Clean up
                API.ReleaseDC(API.GetDesktopWindow(), dc1);
                g.ReleaseHdc(dc2);
                g.Dispose();

                return screenBmp;
            }
        }
    }
}
