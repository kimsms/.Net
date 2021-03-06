//Downloaded from
//Visual C# Kicks - http://vckicks.110mb.com/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; //Needed

namespace WindowsApplication2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnTake_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = ScreenShot.take();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
			}
		}
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