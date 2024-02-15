//
// Form1.cs
//
// A demonstration of the right way and the wrong way to create a callback delegate.
// 
// Just comment out the line below to execute the code that breaks
//
#define DO_THINGS_THE_RIGHT_WAY

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using PixeLINK;



namespace Callback2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnRunGC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRunGC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(82, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(128, 46);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRunGC
            // 
            this.btnRunGC.Location = new System.Drawing.Point(88, 138);
            this.btnRunGC.Name = "btnRunGC";
            this.btnRunGC.Size = new System.Drawing.Size(120, 93);
            this.btnRunGC.TabIndex = 1;
            this.btnRunGC.Text = "GC";
            this.btnRunGC.Click += new System.EventHandler(this.btnRunGC_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(1089, 567);
            this.Controls.Add(this.btnRunGC);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Process me = Process.GetCurrentProcess();
			for(int i=0; i < me.Threads.Count; i++) 
			{
				Debug.WriteLine(me.Threads[i]);
			}

			Application.Run(new Form1());

			for(int i=0; i < me.Threads.Count; i++) 
			{
				Debug.WriteLine(me.Threads[i]);
			}

		}

		static bool s_idle = true;

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			if (s_idle) 
			{
				if (StartCallback()) 
				{
					s_idle = false;
					btnStart.Text = "Stop";

				}
			} 
			else
			{
				StopCallback();
				s_idle = true;
				btnStart.Text = "Start";
			}
		}

		static int s_hCamera;
		static Api.Callback s_callbackDelegate;

		private bool StartCallback()
		{
			if (!Api.IsSuccess(Api.Initialize(0, ref s_hCamera))) 
			{
				return false;
			}
			
#if DO_THINGS_THE_RIGHT_WAY
			// Note here that we keep a reference to the callback object that exists for the entire time
			// the callback method will be called.
			// If we don't, the delegate object will be cleaned up with the first garbage collection sweep, and then
			// the next callback from the API will crash.
			s_callbackDelegate = new Api.Callback(MyCallbackFunction);
			Api.SetCallback(s_hCamera, Overlays.Frame, 0xD00D, s_callbackDelegate);
#else
			// Bad code! Bad! This object will quickly be garbage collected and the next callback from the API will crash.
			Api.Callback temp = new Api.Callback(TestCallback);
			Api.SetCallback(s_hCamera, Overlays.Frame, 0xD00D, temp);
#endif

			Api.SetStreamState(s_hCamera, StreamState.Start);

//			int hWnd = 0;
//			Api.SetPreviewState(s_hCamera, PreviewState.Start, ref hWnd);
			return true;
		}


		private int MyCallbackFunction(int hCamera, System.IntPtr pData, PixelFormat pf, ref FrameDescriptor frameDesc, int userData)
		{
			
            
            Debug.WriteLine(String.Format("{0},{1},{2},{3}", Process.GetCurrentProcess().PrivateMemorySize, Process.GetCurrentProcess().Threads.Count, System.Threading.Thread.CurrentThread.ToString(), frameDesc.FrameNumber));
			return 0;
		}

		private void StopCallback()
		{
			Api.Uninitialize(s_hCamera);
			s_hCamera = 0;
			s_callbackDelegate = null;
		}

		private void btnRunGC_Click(object sender, System.EventArgs e)
		{
			GC.Collect(3);
			GC.WaitForPendingFinalizers();
		}
	}
}
