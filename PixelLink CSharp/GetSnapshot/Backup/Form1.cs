using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PixeLINK;

namespace GetSnapshot
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSnapshot;
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
			this.btnSnapshot = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSnapshot
			// 
			this.btnSnapshot.Location = new System.Drawing.Point(88, 64);
			this.btnSnapshot.Name = "btnSnapshot";
			this.btnSnapshot.Size = new System.Drawing.Size(112, 32);
			this.btnSnapshot.TabIndex = 0;
			this.btnSnapshot.Text = "Take Snapshot";
			this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 182);
			this.Controls.Add(this.btnSnapshot);
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

		private void btnSnapshot_Click(object sender, System.EventArgs e)
		{
			// Declare the camera handle we'll use to interact with the camera
			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0,ref hCamera);
			if (!Api.IsSuccess(rc)) 
			{
				MessageBox.Show(this, String.Format("Unable to initialize a camera\n({0})", rc));
				return;
			}

			SnapshotHelper h = new SnapshotHelper(hCamera);

			h.GetSnapshot(ImageFormat.Bmp, "hello.bmp");

			rc = Api.Uninitialize(hCamera);
		
		}
	}
}
