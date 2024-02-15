using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PixeLINK;

namespace AutoWhiteBalance
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnInitialize;
		private System.Windows.Forms.Button btnWhiteBalance;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int s_hCamera = 0;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			btnWhiteBalance.Enabled = false;
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
			this.btnWhiteBalance = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnInitialize
			// 
			this.btnInitialize.Location = new System.Drawing.Point(48, 17);
			this.btnInitialize.Name = "btnInitialize";
			this.btnInitialize.Size = new System.Drawing.Size(120, 48);
			this.btnInitialize.TabIndex = 0;
			this.btnInitialize.Text = "Initialize";
			this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
			// 
			// btnWhiteBalance
			// 
			this.btnWhiteBalance.Location = new System.Drawing.Point(48, 89);
			this.btnWhiteBalance.Name = "btnWhiteBalance";
			this.btnWhiteBalance.Size = new System.Drawing.Size(120, 48);
			this.btnWhiteBalance.TabIndex = 1;
			this.btnWhiteBalance.Text = "White Balance";
			this.btnWhiteBalance.Click += new System.EventHandler(this.btnWhiteBalance_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(216, 202);
			this.Controls.Add(this.btnWhiteBalance);
			this.Controls.Add(this.btnInitialize);
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
			Application.Run(new Form1());
		}

		private void btnInitialize_Click(object sender, System.EventArgs e)
		{
			Cursor originalCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;

			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0, ref hCamera);
			if (!Api.IsSuccess(rc)) 
			{
				MessageBox.Show("ERROR: Unable to initialize a camera");
			} 
			else 
			{
				rc = Api.SetStreamState(hCamera, StreamState.Start);
				if (!Api.IsSuccess(rc)) 
				{
					Api.Uninitialize(hCamera);
					MessageBox.Show("ERROR: Unable to start the image stream");
				} 
				else 
				{
					s_hCamera = hCamera;
					btnWhiteBalance.Enabled = true;
					btnInitialize.Enabled = false;
				}
			}

			this.Cursor = originalCursor;

		}

		private void btnWhiteBalance_Click(object sender, System.EventArgs e)
		{
			Cursor originalCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;

			System.Diagnostics.Debug.Assert(0 != s_hCamera);

			// Start the white balance
			PixeLINK.FeatureFlags flags = 0;
			int numParams = 3;
			float[] parameters = new float[numParams];
			ReturnCode rc = Api.GetFeature(s_hCamera, Feature.WhiteShading, ref flags, ref numParams, parameters);
			if (!Api.IsSuccess(rc)) 
			{
				MessageBox.Show("ERROR: Unable to read the white balance.");
			} 
			else 
			{
				flags = FeatureFlags.OnePush;
				rc = Api.SetFeature(s_hCamera, Feature.WhiteShading, flags, numParams, parameters);
				if (!Api.IsSuccess(rc)) 
				{
					MessageBox.Show("ERROR: Unable to start the white balance.");
				}
				else
				{
					rc = WaitForAutoWhiteBalanceToComplete();
					if (!Api.IsSuccess(rc))
					{
						MessageBox.Show("ERROR: Unable to perform the white balance.");
					}
					else
					{
						MessageBox.Show("White balance complete.");
					}
				}
			}

			this.Cursor = originalCursor;
		}

		private ReturnCode WaitForAutoWhiteBalanceToComplete()
		{
			PixeLINK.FeatureFlags flags = 0;
			int numParams = 3;
			float[] parameters = new float[numParams];
			ReturnCode rc = ReturnCode.UnknownError;
			for(int i = 0; i < 20; i++) 
			{
				rc = Api.GetFeature(s_hCamera, Feature.WhiteShading, ref flags, ref numParams, parameters);
				if (!Api.IsSuccess(rc)) 
				{
					return rc;
				}
				// Is it done?
				if (0 == (flags & FeatureFlags.OnePush)) 
				{
					return rc;
				}

				System.Threading.Thread.Sleep(1000);
			}	

			return ReturnCode.TimeoutError;

		}
	}
}
