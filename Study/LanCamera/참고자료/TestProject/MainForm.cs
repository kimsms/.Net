using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject
{
    /// <summary>
    /// 메인 폼
    /// </summary>
    public partial class MainForm : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 소스 비트맵
        /// </summary>
        private Bitmap sourceBitmap;

        /// <summary>
        /// 선택 여부
        /// </summary>
        private bool isSelecting = false;

        /// <summary>
        /// 시작 X 좌표
        /// </summary>
        private int xStart;
        
        /// <summary>
        /// 시작 Y 좌표
        /// </summary>
        private int yStart;
        
        /// <summary>
        /// 종료 X 좌표
        /// </summary>
        private int xEnd;
        
        /// <summary>
        /// 종료 Y 좌표
        /// </summary>
        private int yEnd;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - MainForm()

        /// <summary>
        /// 생성자
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region 폼 로드시 처리하기 - Form_Load(sender, e)

        /// <summary>
        /// 폼 로드시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void Form_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = Bitmap.FromFile("cows.jpg") as Bitmap;

            this.sourceBitmap = new Bitmap(bitmap);

            this.sourcePictureBox.Image = this.sourceBitmap;
        }

        #endregion
        #region 소스 픽처 박스 마우스 DOWN 처리하기 - sourcePictureBox_MouseDown(sender, e)

        /// <summary>
        /// 소스 픽처 박스 마우스 DOWN 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void sourcePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.isSelecting = true;

            this.xStart = e.X;
            this.yStart = e.Y;
        }

        #endregion
        #region 소스 픽처 박스 마우스 이동시 처리하기 - sourcePictureBox_MouseMove(sender, e)

        /// <summary>
        /// 소스 픽처 박스 마우스 이동시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void sourcePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(!this.isSelecting)
            {
                return;
            }

            this.xEnd = e.X;
            this.yEnd = e.Y;

            Bitmap bitmap = new Bitmap(this.sourceBitmap);

            using(Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawRectangle
                (
                    Pens.Red,
                    Math.Min(this.xStart, this.xEnd),
                    Math.Min(this.yStart, this.yEnd),
                    Math.Abs(this.xStart - this.xEnd),
                    Math.Abs(this.yStart - this.yEnd)
                );
            }

            this.sourcePictureBox.Image = bitmap;
        }

        #endregion
        #region 소스 픽처 박스 마우스 UP 처리하기 - sourcePictureBox_MouseUp(sender, e)

        /// <summary>
        /// 소스 픽처 박스 마우스 UP 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void sourcePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(!this.isSelecting)
            {
                return;
            }

            this.isSelecting = false;

            this.sourcePictureBox.Image = this.sourceBitmap;

            int width  = Math.Abs(this.xStart - this.xEnd);
            int height = Math.Abs(this.yStart - this.yEnd);

            if((width < 1) || (height < 1))
            {
                return;
            }

            Bitmap resultBitmap = new Bitmap(width, height);

            using(Graphics graphics = Graphics.FromImage(resultBitmap))
            {
                Rectangle sourceRectangle = new Rectangle
                (
                    Math.Min(this.xStart, this.xEnd),
                    Math.Min(this.yStart, this.yEnd),
                    width,
                    height
                );

                Rectangle resultRectangle = new Rectangle(0, 0, width, height);

                graphics.DrawImage(this.sourceBitmap, resultRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }

            this.resultPictureBox.Image = resultBitmap;
        }

        #endregion
    }
}