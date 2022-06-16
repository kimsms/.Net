using System.Windows.Forms;

namespace RawInput
{
    public partial class Form1 : Form
    {
        InputDevice id;
        int NumberOfKeyboards;

        public Form1()
        {
            InitializeComponent();

            id = new InputDevice(Handle);
            NumberOfKeyboards = id.EnumerateDevices();
            id.KeyPressed += new InputDevice.DeviceEventHandler(m_KeyPressed);
        }
        
        protected override void WndProc( ref Message message )
        {
           if( id != null )
           {
                NumberOfKeyboards = id.EnumerateDevices(); //2015.03.13 $osh
                id.ProcessMessage( message );
           }
           base.WndProc( ref message );
        }

        private void m_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
        {
            lbHandle.Text = e.Keyboard.deviceHandle.ToString();
            lbType.Text = e.Keyboard.deviceType;

            //TODO 왜 여기 이상하게 나오는거지
            lbName.Text = e.Keyboard.deviceName.Replace("&", "&&");

            lbDescription.Text = e.Keyboard.Name;
            //lbKey.Text = e.Keyboard.key.ToString();
            lbNumKeyboards.Text = NumberOfKeyboards.ToString();
            //lbVKey.Text = e.Keyboard.vKey;
            if (e.Keyboard.deviceName.Replace("&", "&&") == @"\\?\ACPI#HPQ8001#4&&26b92865&&0#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
            {
                textBox1.Focus();
            }
            else if (e.Keyboard.deviceName.Replace("&", "&&") == @"\\?\HID#VID_0566&&PID_3032&&MI_00#7&&349609b5&&0&&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}")
            {
                textBox2.Focus();
            }
            else
                textBox3.Focus();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void lbName_DoubleClick(object sender, System.EventArgs e)
        {
            Clipboard.SetText(lbName.Text);
            MessageBox.Show("클립보드에 복사되었습니다.");
        }
    }
}