using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using PixeLINK;

//
// Demonstrates the basics of getting various types of feature information via the 
// PixeLINK .NET API.
//
// See the PixeLINK SDK Documentation for more information about all the features
// and their parameters.
//
// Note that we don't do any error handling here as the purpose is to demonstrate 
// how to access the camera features, not tell you how to do your error handling.
//
//

namespace GetCameraFeature
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGetFeatures;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtGain;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtExposure;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRoi;
		private System.Windows.Forms.Label lblMinGain;
		private System.Windows.Forms.TextBox txtMinGain;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMaxGain;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox lstRoiInfo;
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
            this.btnGetFeatures = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGain = new System.Windows.Forms.TextBox();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMinGain = new System.Windows.Forms.Label();
            this.txtMinGain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxGain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstRoiInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGetFeatures
            // 
            this.btnGetFeatures.Location = new System.Drawing.Point(72, 18);
            this.btnGetFeatures.Name = "btnGetFeatures";
            this.btnGetFeatures.Size = new System.Drawing.Size(112, 37);
            this.btnGetFeatures.TabIndex = 0;
            this.btnGetFeatures.Text = "Get Features";
            this.btnGetFeatures.Click += new System.EventHandler(this.btnGetFeatures_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gain (dB)";
            // 
            // txtGain
            // 
            this.txtGain.Location = new System.Drawing.Point(112, 127);
            this.txtGain.Name = "txtGain";
            this.txtGain.Size = new System.Drawing.Size(120, 22);
            this.txtGain.TabIndex = 2;
            // 
            // txtExposure
            // 
            this.txtExposure.Location = new System.Drawing.Point(112, 83);
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(120, 22);
            this.txtExposure.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exposure (ms)";
            // 
            // txtRoi
            // 
            this.txtRoi.Location = new System.Drawing.Point(112, 258);
            this.txtRoi.Name = "txtRoi";
            this.txtRoi.Size = new System.Drawing.Size(120, 22);
            this.txtRoi.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "ROI";
            // 
            // lblMinGain
            // 
            this.lblMinGain.Location = new System.Drawing.Point(16, 171);
            this.lblMinGain.Name = "lblMinGain";
            this.lblMinGain.Size = new System.Drawing.Size(80, 18);
            this.lblMinGain.TabIndex = 7;
            this.lblMinGain.Text = "Min Gain (dB)";
            // 
            // txtMinGain
            // 
            this.txtMinGain.Location = new System.Drawing.Point(112, 171);
            this.txtMinGain.Name = "txtMinGain";
            this.txtMinGain.Size = new System.Drawing.Size(120, 22);
            this.txtMinGain.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max Gain (dB)";
            // 
            // txtMaxGain
            // 
            this.txtMaxGain.Location = new System.Drawing.Point(112, 215);
            this.txtMaxGain.Name = "txtMaxGain";
            this.txtMaxGain.Size = new System.Drawing.Size(120, 22);
            this.txtMaxGain.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(68, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "ROI Parameter Info";
            // 
            // lstRoiInfo
            // 
            this.lstRoiInfo.ItemHeight = 12;
            this.lstRoiInfo.Location = new System.Drawing.Point(16, 342);
            this.lstRoiInfo.Name = "lstRoiInfo";
            this.lstRoiInfo.Size = new System.Drawing.Size(224, 64);
            this.lstRoiInfo.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(268, 431);
            this.Controls.Add(this.lstRoiInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaxGain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinGain);
            this.Controls.Add(this.lblMinGain);
            this.Controls.Add(this.txtRoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExposure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetFeatures);
            this.Name = "Form1";
            this.Text = "Get Camera Features";
            this.ResumeLayout(false);
            this.PerformLayout();

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

		private void btnGetFeatures_Click(object sender, System.EventArgs e)
		{
			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0,ref hCamera);
			if (!Api.IsSuccess(rc))
			{
				MessageBox.Show("Unable to initialize a camera");
				return;
			}

			txtExposure.Text = System.Convert.ToString(GetSimpleFeature(hCamera, Feature.Shutter) * 1000); // convert from s to ms
			txtGain.Text = System.Convert.ToString(GetSimpleFeature(hCamera, Feature.Gain));

			GetGainLimits(hCamera);

			int top = 0;
			int left = 0;
			int width = 0;
			int height = 0;
			GetRoi(hCamera, ref top, ref left, ref width, ref height);
			txtRoi.Text = "(" + left +"," + top + ") -> (" + (left + width) + "," + (top + height) + ")";

			GetRoiInfo(hCamera);

			Api.Uninitialize(hCamera);
		}

		// A 'simple' feature is any feature that has only one parameter
		private float GetSimpleFeature(int hCamera, Feature featureId)
		{
			FeatureFlags flags = 0;
			int numParms = 1;
			float[] parms = new float[numParms];
			ReturnCode rc = Api.GetFeature(hCamera, featureId, ref flags, ref numParms, parms);
			return parms[0];
		}

		private void GetGainLimits(int hCamera)
		{
			CameraFeature featureInfo = new CameraFeature();
			if (!Api.IsSuccess(Api.GetCameraFeatures(hCamera, Feature.Gain, ref featureInfo))) 
			{
				lstRoiInfo.Items.Add("Unable to read Gain info");
			} 
			else 
			{
				txtMinGain.Text = System.Convert.ToString(featureInfo.parameters[0].MinimumValue);
				txtMaxGain.Text = System.Convert.ToString(featureInfo.parameters[0].MaximumValue);
			}

		}

		private void GetRoiInfo(int hCamera)
		{
			lstRoiInfo.Items.Clear();

			CameraFeature featureInfo = new CameraFeature();
			if (!Api.IsSuccess(Api.GetCameraFeatures(hCamera, Feature.Roi, ref featureInfo))) 
			{
				lstRoiInfo.Items.Add("Unable to read ROI info");
			} 
			else 
			{
				lstRoiInfo.Items.Add("Num params: " + featureInfo.numberOfParameters);
				Debug.Assert(featureInfo.numberOfParameters == featureInfo.parameters.Length);
				for (int i=0; i < featureInfo.parameters.Length; i++)
				{
					lstRoiInfo.Items.Add(String.Format("Param {0}: min={1}, max={2}", i, featureInfo.parameters[i].MinimumValue, featureInfo.parameters[i].MaximumValue));
				}
			}

		}

		// We assume a priori that we know that the ROI feature has 4 parameters.
		private void GetRoi(int hCamera, ref int top, ref int left, ref int width, ref int height)
		{
			FeatureFlags flags = 0;
			int numParms = 4;
			float[] parms = new float[numParms];
			ReturnCode rc = Api.GetFeature(hCamera, Feature.Roi, ref flags, ref numParms, parms);
			top		= System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiTop]);
			left	= System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiLeft]);
			width	= System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiWidth]);
			height	= System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiHeight]);

		}

	}
}
