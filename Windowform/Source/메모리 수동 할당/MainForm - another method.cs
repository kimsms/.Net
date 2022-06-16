/*
+-------------------------------- DISCLAIMER ---------------------------------+
|                                                                             |
| This application program is provided to you free of charge as an example.   |
| Despite the considerable efforts of Euresys personnel to create a usable    |
| example, you should not assume that this program is error-free or suitable  |
| for any purpose whatsoever.                                                 |
|                                                                             |
| EURESYS does not give any representation, warranty or undertaking that this |
| program is free of any defect or error or suitable for any purpose. EURESYS |
| shall not be liable, in contract, in torts or otherwise, for any damages,   |
| loss, costs, expenses or other claims for compensation, including those     |
| asserted by third parties, arising out of or in connection with the use of  |
| this program.                                                               |
|                                                                             |
+-----------------------------------------------------------------------------+
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using Euresys.MultiCam;
using System.Runtime.InteropServices;

namespace GrablinkSnapshotTrigger
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    /// 

    public class MainForm : System.Windows.Forms.Form
    {
        const int EURESYS_SURFACE_COUNT = 6;
        const int EURESYS_RESERVED_SURFACE_COUNT = EURESYS_SURFACE_COUNT - 3;

        // Creation of an event for asynchronous call to paint function
        public delegate void PaintDelegate(Graphics g);
        public delegate void UpdateStatusBarDelegate(String text);

        // The object that will contain the acquired image
        private Bitmap image = null;
        
        // The object that will contain the palette information for the bitmap
        private ColorPalette imgpal = null;

        // The Mutex object that will protect image objects during processing
        private static Mutex imageMutex = new Mutex();

        // The MultiCam object that controls the acquisition
        UInt32 channel;

        // The MultiCam object that contains the acquired buffer
        private UInt32 currentSurface;

        // A table of reserved surfaces for later processing        
        Queue<UInt32> reservedSurfaces = new Queue<UInt32>(EURESYS_RESERVED_SURFACE_COUNT);

        Int32 width, height, bufferSize, bufferPitch;
        IntPtr buffer, surfAddress;

        MC.CALLBACK multiCamCallback;

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.MenuItem Go;
        private System.Windows.Forms.MenuItem Stop;
        private MenuItem mnuReadFirstImg;
        private System.ComponentModel.IContainer components;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // Show scope of the sample program
            MessageBox.Show(@"
                This program demonstrates the SNAPSHOT Acquisition Mode on a Grablink Board.
                
                The Go! menu generates a soft trigger which starts a frame acquisition.
                By default, this program requires an area-scan camera connected on connector M.",
                "Sample program description", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.Go = new System.Windows.Forms.MenuItem();
            this.Stop = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.mnuReadFirstImg = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Go,
            this.Stop,
            this.mnuReadFirstImg});
            // 
            // Go
            // 
            this.Go.Index = 0;
            this.Go.Text = "Go!";
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Stop
            // 
            this.Stop.Index = 1;
            this.Stop.Text = "Stop!";
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 568);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(768, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "Ready. Click on the \'GO!\' button to start.";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // mnuReadFirstImg
            // 
            this.mnuReadFirstImg.Index = 2;
            this.mnuReadFirstImg.Text = "Read First Image";
            this.mnuReadFirstImg.Click += new System.EventHandler(this.mnuReadFirstImg_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 590);
            this.Controls.Add(this.statusBar);
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "GrablinkSnapshotTrigger";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

            // + GrablinkSnapshotTrigger Sample Program

            try
            {
                // Open MultiCam driver
                MC.OpenDriver();

                // Enable error logging
                MC.SetParam(MC.CONFIGURATION, "ErrorLog", "error.log");

                // In order to support a 10-tap camera on Grablink Full
                // BoardTopology must be set to MONO_DECA
                // In all other cases the default value will work properly 
                // and the parameter doesn't need to be set

                // Set the board topology to support 10 taps mode (only with a Grablink Full)
                // MC.SetParam(MC.BOARD + 0, "BoardTopology", "MONO_DECA");

                // Create a channel and associate it with the first connector on the first board
                MC.Create("CHANNEL", out channel);
                MC.SetParam(channel, "DriverIndex", 0);

                // In order to use single camera on connector A
                // MC_Connector must be set to A for Grablink DualBase
                // For all other Grablink boards the parameter has to be set to M  

                // For all GrabLink boards except Grablink DualBase
                //MC.SetParam(channel, "Connector", "M");
                // For Grablink DualBase
                MC.SetParam(channel, "Connector", "A");

                // Choose the CAM file
                MC.SetParam(channel, "CamFile", "1000m_P50RG");
                // Choose the camera expose duration
                MC.SetParam(channel,"Expose_us", 20000);
                // Choose the pixel color format
                MC.SetParam(channel, "ColorFormat", "Y8");

                //Set the acquisition mode to Snapshot
                MC.SetParam(channel, "AcquisitionMode", "SNAPSHOT");
                // Choose the way the first acquisition is triggered
                MC.SetParam(channel, "TrigMode", "COMBINED");
                // Choose the triggering mode for subsequent acquisitions
                MC.SetParam(channel, "NextTrigMode", "COMBINED");

                // Configure triggering line
                // A rising edge on the triggering line generates a trigger.
                // See the TrigLine Parameter and the board documentation for more details.
                MC.SetParam(channel, "TrigLine", "NOM");
                MC.SetParam(channel, "TrigEdge", "GOHIGH");
                MC.SetParam(channel, "TrigFilter", "ON");
                
                // Parameter valid for all Grablink but Full, DualBase, Base
                // MC.SetParam(channel, "TrigCtl", "ITTL");
                // Parameter valid only for Grablink Full, DualBase, Base
                MC.SetParam(channel, "TrigCtl", "ISO");
                
                // Choose the number of images to acquire
                MC.SetParam(channel, "SeqLength_Fr", MC.INDETERMINATE);

                MC.GetParam(channel, "BufferSize", out bufferSize);
                MC.GetParam(channel, "BufferPitch", out bufferPitch);
                MC.GetParam(channel, "ImageSizeX", out width);
                MC.GetParam(channel, "ImageSizeY", out height);

                buffer = Marshal.AllocHGlobal(bufferSize * EURESYS_SURFACE_COUNT);

                for (int i = 0; i < EURESYS_SURFACE_COUNT; i++)
                {
                    // Create a surface
                    UInt32 surface;
                    MC.Create(MC.DEFAULT_SURFACE_HANDLE, out surface);

                    // Slicing the memory into small buffers
                    surfAddress = IntPtr.Add(buffer, i * bufferSize);

                    // Set surface parameters
                    MC.SetParam(surface, "SurfaceSize", bufferSize);
                    MC.SetParam(surface, "SurfacePitch", bufferPitch);
                    MC.SetParam(surface, "SurfaceAddr", surfAddress);
                    MC.SetParam(channel, "Cluster:" + i.ToString(), surface);
                }

                // Register the callback function
                multiCamCallback = new MC.CALLBACK(MultiCamCallback);
                MC.RegisterCallback(channel, multiCamCallback, channel);

                // Enable the signals corresponding to the callback functions
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_SURFACE_PROCESSING, "ON");
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_ACQUISITION_FAILURE, "ON");

                // Prepare the channel in order to minimize the acquisition sequence startup latency
                MC.SetParam(channel, "ChannelState", "READY");
            }
            catch (Euresys.MultiCamException exc)
            {
                // An exception has occurred in the try {...} block. 
                // Retrieve its description and display it in a message box.
                MessageBox.Show(exc.Message, "MultiCam Exception");
                Close();
            }

            // - GrablinkSnapshotTrigger Sample Program
        }


        private void MultiCamCallback(ref MC.SIGNALINFO signalInfo)
        {
            switch(signalInfo.Signal)
            {
                case MC.SIG_SURFACE_PROCESSING:
                    ProcessingCallback(signalInfo);
                    break;
                case MC.SIG_ACQUISITION_FAILURE:
                    AcqFailureCallback(signalInfo);
                    break;
                default:
                    throw new Euresys.MultiCamException("Unknown signal");
            }
        }

        private void ProcessingCallback(MC.SIGNALINFO signalInfo)
        {
            UInt32 currentChannel = (UInt32)signalInfo.Context;

            statusBar.Text = "Processing";
            currentSurface = signalInfo.SignalInfo;

            // + GrablinkSnapshotTrigger Sample Program

            try
            {
                // Update the image with the acquired image buffer data 
                Int32 width, height, bufferPitch;
                IntPtr bufferAddress;
                MC.GetParam(currentChannel, "ImageSizeX", out width);
                MC.GetParam(currentChannel, "ImageSizeY", out height);
                MC.GetParam(currentChannel, "BufferPitch", out bufferPitch);
                MC.GetParam(currentSurface, "SurfaceAddr", out bufferAddress);

                if (reservedSurfaces.Count < EURESYS_RESERVED_SURFACE_COUNT)
                {
                    // Add reserved surface to the queue only if the queue is non-full
                    MC.SetParam(currentSurface, "SurfaceState", "RESERVED");
                    reservedSurfaces.Enqueue(currentSurface);
                }

                try
                {
                    imageMutex.WaitOne();

                    image = new Bitmap(width, height, bufferPitch, PixelFormat.Format8bppIndexed, bufferAddress);
                    
                    imgpal = image.Palette;

                    // Build bitmap palette Y8
                    for (uint i = 0; i < 256; i++)
                    {
                        imgpal.Entries[i] = Color.FromArgb(
                        (byte)0xFF,
                        (byte)i,
                        (byte)i,
                        (byte)i);
                    }

                    image.Palette = imgpal;

                    /* Insert image analysis and processing code here */
                }
                finally
                {
                    imageMutex.ReleaseMutex();
                }

                // Retrieve the frame rate
                Double frameRate_Hz;
                MC.GetParam(channel, "PerSecond_Fr", out frameRate_Hz);

                // Retrieve the channel state
                String channelState;
                MC.GetParam(channel, "ChannelState", out channelState);

                // Display frame rate and channel state
                statusBar.Text = String.Format("Frame Rate: {0:f2}, Channel State: {1}", frameRate_Hz, channelState);

                // Display the new image
                this.BeginInvoke(new PaintDelegate(Redraw), new object[1] { CreateGraphics() });
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }
            // - GrablinkSnapshotTrigger Sample Program
        }

        private void AcqFailureCallback(MC.SIGNALINFO signalInfo)
        {
            UInt32 currentChannel = (UInt32)signalInfo.Context;

            // + GrablinkSnapshotTrigger Sample Program

            try
            {
                // Display frame rate and channel state
                statusBar.Text = String.Format("Acquisition Failure, Channel State: IDLE");
                this.BeginInvoke(new PaintDelegate(Redraw), new object[1] { CreateGraphics() });
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }

            // - GrablinkSnapshotTrigger Sample Program
        }

        private void UpdateStatusBar(String text)
        {
            statusBarPanel1.Text = text;
        }

        void Redraw(Graphics g)
        {
            // + GrablinkSnapshotTrigger Sample Program

            try
            {
                imageMutex.WaitOne();

                if (image != null)
                    g.DrawImage(image, 0, 0);
                UpdateStatusBar(statusBar.Text);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }
            finally
            {
                imageMutex.ReleaseMutex();
            }

            // - GrablinkSnapshotTrigger Sample Program
        }

        private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Redraw(e.Graphics);
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Stop_Click(sender, e);
                // Delete the channel
                if (channel != 0)
                {
                    MC.Delete(channel);
                    channel = 0;
                }

                Marshal.FreeHGlobal(buffer);
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
        }

        private void Go_Click(object sender, System.EventArgs e)
        {
            // + GrablinkSnapshotTrigger Sample Program


            // Start an acquisition sequence by activating the channel
            String channelState;
            MC.GetParam(channel, "ChannelState", out channelState);
            if (channelState != "ACTIVE")
                MC.SetParam(channel, "ChannelState", "ACTIVE");
            
            // Generate a soft trigger event
            MC.SetParam(channel, "ForceTrig", "TRIG");
            Refresh();

            // - GrablinkSnapshotTrigger Sample Program
        }

        private void Stop_Click(object sender, System.EventArgs e)
        {
            // + GrablinkSnapshotTrigger Sample Program
            // Stop an acquisition sequence by deactivating the channel

            // Flush queue of reserved surfaces
            while (reservedSurfaces.Count > 0)
            {
                UInt32 reservedSurface = reservedSurfaces.Dequeue();
                MC.SetParam(reservedSurface, "SurfaceState", "FREE");
            }

            if (channel != 0)
                MC.SetParam(channel, "ChannelState", "IDLE");
            UpdateStatusBar(String.Format("Frame Rate: {0:f2}, Channel State: IDLE", 0));

            // - GrablinkSnapshotTrigger Sample Program
        }

        private void MainForm_Closed(object sender, System.EventArgs e)
        {
            try
            {
                // Close MultiCam driver
                MC.CloseDriver();
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
        }

        private void mnuReadFirstImg_Click(object sender, EventArgs e)
        {
            IntPtr bufferAddress;
            UInt32 reservedSurface = 0;

            if (reservedSurfaces.Count == 0)
            {
                // The queue of reserved surfaces is empty -> no processing.
                return;
            }

            try
            {
                reservedSurface = reservedSurfaces.Dequeue();
                MC.GetParam(reservedSurface, "SurfaceAddr", out bufferAddress);

                imageMutex.WaitOne();

                Bitmap firstImage = new Bitmap(width, height, bufferPitch, PixelFormat.Format8bppIndexed, bufferAddress);

                ColorPalette firstImgpal = firstImage.Palette;

                // Build bitmap palette Y8
                for (uint i = 0; i < 256; i++)
                {
                    firstImgpal.Entries[i] = Color.FromArgb(
                    (byte)0xFF,
                    (byte)i,
                    (byte)i,
                    (byte)i);
                }

                firstImage.Palette = firstImgpal;
                firstImage.Save("FirstGrabberImage.bmp");
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }

            if (reservedSurface != 0)
            {
                MC.SetParam(reservedSurface, "SurfaceState", "FREE");
            }
        }
    }
}
