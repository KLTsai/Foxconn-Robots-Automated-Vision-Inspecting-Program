//
// Example of minimal interaction with a PixeLINK camera using C#
//
// 1) To the project, Add Reference to PxLApi4DotNet.dll 
// 2) add "using PxL"
// 3) See the btnInitialize_Click method below
//




using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PixeLINK;

namespace Initialize
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnInitialize;
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
			this.btnInitialize = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnInitialize
			// 
			this.btnInitialize.Location = new System.Drawing.Point(80, 64);
			this.btnInitialize.Name = "btnInitialize";
			this.btnInitialize.Size = new System.Drawing.Size(128, 32);
			this.btnInitialize.TabIndex = 0;
			this.btnInitialize.Text = "Initialize Camera";
			this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btnInitialize);
			this.Name = "Form1";
			this.Text = "Demo App - Initialize";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnInitialize_Click(object sender, System.EventArgs e)
		{
			// Declare the camera handle we'll use to interact with the camera
			int hCamera = 0;

			// By passing in a serial number of 0, we're saying to the API that 
			// we want ANY camera. If there are 2 or more cameras, we can't be 
			// certain a priori which camera we'll get, but we will get one of them.
			ReturnCode rc = Api.Initialize(0, ref hCamera);
			if (Api.IsSuccess(rc)) 
			{
				MessageBox.Show(this,"Successfully initialized camera. hCamera = " + hCamera);
		
				// Tell the API that we're done interacting with the camera.
				rc = Api.Uninitialize(hCamera);
				MessageBox.Show(this,"Uninitialize return code = " + rc);
			}
			else 
			{
				string msg = String.Format("Error initializing camera\nReturn code: {0} (0x{1:X})", rc, rc);
				MessageBox.Show(this, msg);
			}


		}
	}
}
