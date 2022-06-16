using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.QuickBuild;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageFile;

namespace CognexBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap bitmap = (Bitmap)Image.FromFile(@"C:\Users\Administrator\Desktop\temp.bmp");

            ICogImage cogImage = new CogImage8Grey(bitmap);
        }


    }
}
