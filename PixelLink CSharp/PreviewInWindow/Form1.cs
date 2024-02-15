using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using PixeLINK;

//
// Demonstrates how to use the Preview feature of the PixeLINK API to preview
// into a PictureBox. 
//
//

namespace PreviewInWindow
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
				Api.Uninitialize(m_hCamera);
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 129);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(356, 319);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

		private System.Windows.Forms.PictureBox pictureBox1;
		private int m_hCamera = 0;
		private bool m_previewingEnabled;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ReturnCode rc = Api.Initialize(0,ref m_hCamera);
			if (!Api.IsSuccess(rc)) 
			{
				MessageBox.Show("ERROR: Unable to initialize a camera");
				m_hCamera = 0;
			}
			ResizePreviewPictureBox();
			SetPreviewSettings();

		}



		// When the form is resized:
		// 1) Stop the preview
		// 2) Resize the picture box control to fill the entire form
		// 3) Set the preview settings again
		private void Form_Resize(object sender, System.EventArgs e)
		{
			if ((m_previewingEnabled) && (0 != m_hCamera))
			{
				int hWnd = 0;
				Api.SetPreviewState(m_hCamera, PreviewState.Stop, ref hWnd);
			}
			
			ResizePreviewPictureBox();
			SetPreviewSettings();
		}

		//
		// Resize the picture box to fill a percentage of the form.
		// 
		private const float m_previewPercentOfClient = 0.75f;

		private void ResizePreviewPictureBox()
		{
			pictureBox1.Height = (int)(this.ClientRectangle.Height * m_previewPercentOfClient);
			pictureBox1.Width = (int)(this.ClientRectangle.Width * m_previewPercentOfClient);

			pictureBox1.Left = (this.ClientRectangle.Width - pictureBox1.Width)  / 2;
			pictureBox1.Top = (this.ClientRectangle.Height - pictureBox1.Height) / 2;
			
		}


		// Tell the PixeLINK Api to stream a preview into the picture box.
		private void SetPreviewSettings()
		{
			if (0 == m_hCamera) 
			{
				return;
			}

			// Tell the PixeLINK API we want to preview into the picture box control.
			ReturnCode rc = Api.SetPreviewSettings(m_hCamera, "Title is ignored", (PreviewWindowStyles.Child | PreviewWindowStyles.Visible), 0, 0, pictureBox1.Width, pictureBox1.Height, (int)pictureBox1.Handle, 0);

			rc = Api.SetStreamState(m_hCamera,StreamState.Start);
			int hWnd = 0;
			rc = Api.SetPreviewState(m_hCamera, PreviewState.Start, ref hWnd);

			m_previewingEnabled = true;

		}

	}
}
