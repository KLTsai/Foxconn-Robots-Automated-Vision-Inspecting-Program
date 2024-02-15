using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PixeLINK;

namespace GetCameraInfo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGetCameraInfo;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtFirmwareVersion;
		private System.Windows.Forms.TextBox txtFPGAVersion;
		private System.Windows.Forms.TextBox txtSerialNumber;
		private System.Windows.Forms.TextBox txtVendor;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtModelName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
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
			this.btnGetCameraInfo = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtFirmwareVersion = new System.Windows.Forms.TextBox();
			this.txtFPGAVersion = new System.Windows.Forms.TextBox();
			this.txtSerialNumber = new System.Windows.Forms.TextBox();
			this.txtVendor = new System.Windows.Forms.TextBox();
			this.txtModelName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGetCameraInfo
			// 
			this.btnGetCameraInfo.Location = new System.Drawing.Point(160, 32);
			this.btnGetCameraInfo.Name = "btnGetCameraInfo";
			this.btnGetCameraInfo.Size = new System.Drawing.Size(160, 56);
			this.btnGetCameraInfo.TabIndex = 0;
			this.btnGetCameraInfo.Text = "Get Camera Info";
			this.btnGetCameraInfo.Click += new System.EventHandler(this.btnGetCameraInfo_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(128, 110);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(320, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(128, 144);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(320, 20);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.Text = "";
			// 
			// txtFirmwareVersion
			// 
			this.txtFirmwareVersion.Location = new System.Drawing.Point(128, 176);
			this.txtFirmwareVersion.Name = "txtFirmwareVersion";
			this.txtFirmwareVersion.Size = new System.Drawing.Size(320, 20);
			this.txtFirmwareVersion.TabIndex = 3;
			this.txtFirmwareVersion.Text = "";
			// 
			// txtFPGAVersion
			// 
			this.txtFPGAVersion.Location = new System.Drawing.Point(128, 208);
			this.txtFPGAVersion.Name = "txtFPGAVersion";
			this.txtFPGAVersion.Size = new System.Drawing.Size(320, 20);
			this.txtFPGAVersion.TabIndex = 4;
			this.txtFPGAVersion.Text = "";
			// 
			// txtSerialNumber
			// 
			this.txtSerialNumber.Location = new System.Drawing.Point(128, 272);
			this.txtSerialNumber.Name = "txtSerialNumber";
			this.txtSerialNumber.Size = new System.Drawing.Size(320, 20);
			this.txtSerialNumber.TabIndex = 5;
			this.txtSerialNumber.Text = "";
			// 
			// txtVendor
			// 
			this.txtVendor.Location = new System.Drawing.Point(128, 304);
			this.txtVendor.Name = "txtVendor";
			this.txtVendor.Size = new System.Drawing.Size(320, 20);
			this.txtVendor.TabIndex = 6;
			this.txtVendor.Text = "";
			// 
			// txtModelName
			// 
			this.txtModelName.Location = new System.Drawing.Point(128, 240);
			this.txtModelName.Name = "txtModelName";
			this.txtModelName.Size = new System.Drawing.Size(320, 20);
			this.txtModelName.TabIndex = 7;
			this.txtModelName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Camera Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Description";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Firmware Version:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 210);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "FPGA Version";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 242);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Model Name";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 274);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Serial Number";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 306);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "Vendor Name";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 358);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtModelName);
			this.Controls.Add(this.txtVendor);
			this.Controls.Add(this.txtSerialNumber);
			this.Controls.Add(this.txtFPGAVersion);
			this.Controls.Add(this.txtFirmwareVersion);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnGetCameraInfo);
			this.Name = "Form1";
			this.Text = "Demo App - Get Camera Info";
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

		private void btnGetCameraInfo_Click(object sender, System.EventArgs e)
		{
			// Ask the API to initialize a camera for us
			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0,ref hCamera);
			if (!Api.IsSuccess(rc))
			{
				MessageBox.Show("Error " + rc + " when initializing the camera");
				return;
			}
		
			// 
			// Ask the API for camera info, and then display it to to the window
			// 
			CameraInformation info = new CameraInformation();
			rc = Api.GetCameraInformation(hCamera, ref info);
			if (Api.IsSuccess(rc)) 
			{
				txtName.Text = info.CameraName;
				txtDescription.Text = info.Description;
				txtFirmwareVersion.Text = info.FirmwareVersion;
				txtFPGAVersion.Text = info.FpgaVersion;
				txtModelName.Text = info.ModelName;
				txtSerialNumber.Text = info.SerialNumber;
				txtVendor.Text = info.VendorName;
			} 
			else 
			{
				MessageBox.Show("Error " + rc + " when getting the camera info");
			}

			Api.Uninitialize(hCamera);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
