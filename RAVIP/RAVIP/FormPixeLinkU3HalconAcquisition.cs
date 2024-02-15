using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using HalconDotNet;
using System.Diagnostics;
using PixeLinkU3;
using Tien_Function;
using PixeLINK;
using System.Globalization;
using TCP_IP_class;



// Note: Halcon dotnet is using 11.0 version x64, so the 使用中平台必須為x64
namespace PixeLinkU3_Acquisition
{
    public partial class FormPixeLinkU3HalconAcquisition : Form
    {
        PGU3_CCD_Acquisition PGCCD1;
        public HObject m_HoImage = null;
        public CCD_Parameter CCD_Param_1 = new CCD_Parameter();
        HTuple ImageWidth = 1280, ImageHeight =1024;
        ROI FocusROI = new ROI();
        Thread CCD_Live=null;
        //private HalconDotNet.HWindowControl hWindowControlPG;
        delegate void ImageWindow_control(HObject grab_hImage, HWindowControl Window);

        int hCamera = 0; // PixeLink camera handle
        
        
        public FormPixeLinkU3HalconAcquisition()
        {
            InitializeComponent();
            CCD_Param_1.Exposure = 1;
            CCD_Param_1.Brightness = 20;
            CCD_Param_1.Hue = 0;
            CCD_Param_1.Sharpness = 25;
            CCD_Param_1.Gamma = 100;
            CCD_Param_1.FrameRate = 60;
            CCD_Param_1.Gain = 0;
            CCD_Param_1.External_Trigger = false;
            //hWindowControlPG = new HalconDotNet.HWindowControl();
            hWindowControl.AutoScroll = true;
            setView(hWindowControl);
            resetView(1280, 1024);
            FocusROI.StartX = 100;
            FocusROI.StartY = 100;
            FocusROI.Width = 250;
            FocusROI.Height = 250;
            HOperatorSet.SetColor(hWindowControl.HalconWindow, "red");
            HOperatorSet.SetDraw(hWindowControl.HalconWindow, "margin");
            PGCCD1 = new PGU3_CCD_Acquisition();
        }
        protected void setView(object view)
        {
            panel1.Controls.Add((Control)view);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonGrab_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonLive_Click(object sender, EventArgs e)
        {
            PGCCD1.CCD_Type = comboBoxCCDType.Text;  // must tell grabber what kind of CCD is used
            PGCCD1.Window = hWindowControl.HalconWindow;
            CCD_Live = new Thread(PGCCD1.RunHalcon);
            //CCD_Live.IsBackground = true;  // 可用  無影響
            if (buttonLive.Text == "Live")
            {
                CCD_Live.Start();
                while (!CCD_Live.IsAlive) ;  // // Loop until worker thread activates.
                Thread.Sleep(1);
                buttonLive.Text = "Stop";
                
                numericUpDownROIStartX.Value = (decimal)ImageWidth / 2 - FocusROI.Width / 2;
                numericUpDownROIStartY.Value = (decimal)ImageHeight / 2 - FocusROI.Height / 2;
                numericUpDownROIWidth.Value = (decimal)FocusROI.Width;
                numericUpDownROIHeight.Value = (decimal)FocusROI.Height;
                FocusROI.StartY = (int) numericUpDownROIStartY.Value;
                FocusROI.StartX = (int)numericUpDownROIStartX.Value;
                FocusROI.Width = (int)numericUpDownROIWidth.Value;
                FocusROI.Height = (int)numericUpDownROIHeight.Value;
                PGCCD1.FocusROI = FocusROI;
            }
            else
            {
                PGCCD1.Stop_Acquisition();
                while (CCD_Live.IsAlive) ;
                //CCD_Live.Join();  // 無發使用  會出錯
                buttonLive.Text = "Live";

            }

            
        }
        public void resetView(int width, int height)
        {
            bool FixedDisplayRatio = true;
            if (FixedDisplayRatio == true)  //保持原始比例
            {
                double imageRatio;
                double formRatio;

                if (height == 0)
                    imageRatio = 0;
                else
                    imageRatio = (double)width / (double)height;
                formRatio = (double)this.Width / (double)this.Height;

                if (imageRatio > formRatio) //以Width為主
                {
                    hWindowControl.Size = new Size(this.Size.Width, Convert.ToInt32(((double)this.Size.Width) / imageRatio));
                }
                else  //以Hieght 為主
                {
                    hWindowControl.Size = new Size(Convert.ToInt32(((double)this.Size.Height) * imageRatio), this.Size.Height);
                }
            }
            else  // 符合視窗比例
            {
                hWindowControl.Size = this.Size;
            }

            //originalSize = new Size(hWindowControlPG.Size.Width, hWindowControlPG.Size.Height);
            hWindowControl.ImagePart = new Rectangle(0, 0, width, height);
        }
        private void buttonGetCCDInfo_Click(object sender, EventArgs e)
        {
            
        }
        public void Updata_WindowUI(HObject grab_hImage, HWindowControl Window)
        {
            if (this.InvokeRequired)
            {
                ImageWindow_control UI = new ImageWindow_control(Updata_WindowUI);
                this.Invoke(UI, grab_hImage, Window);
            }
            else
            {
               // PGCCD1.Window = Window.HalconWindow;
                HOperatorSet.GetImageSize(grab_hImage, out ImageWidth, out ImageHeight);
                HOperatorSet.DispObj(grab_hImage, Window.HalconWindow);
            }
        }  //畫在halconwindow上的 跨執行續方法
        public HObject Tograb()
        {
            if (CCD_Live.IsAlive)
            {
                PGCCD1.Stop_Acquisition();
                // while (CCD_Live.IsAlive)
                //    PGCCD1.Stop_Acquisition();
                CCD_Live.Join();  // 無發使用  會出錯
                //buttonLive.Text = "Live";
            }
            // PGCCD1.CCD_Type = comboBoxCCDType.Text;
            PGCCD1.CCD_Type = "[0] PixeLINK USB3 Camera Release 4";
            m_HoImage = PGCCD1.Grab();
            
            Updata_WindowUI(m_HoImage, hWindowControl);
            CSystemPara.sp_HoImage = m_HoImage;
            return m_HoImage;
        }
        public HObject TogetImage(string filename,string type)
        {
            if (CCD_Live.IsAlive)
            {
                PGCCD1.Stop_Acquisition();
                // while (CCD_Live.IsAlive)
                //    PGCCD1.Stop_Acquisition();
                CCD_Live.Join();  // 無發使用  會出錯
                //buttonLive.Text = "Live";
            }
           // PGCCD1.CCD_Type = comboBoxCCDType.Text;
            PGCCD1.CCD_Type = "[0] PixeLINK USB3 Camera Release 4";
            m_HoImage = PGCCD1.Grab();
          
            string dirPath = Application.StartupPath + @"\Img\";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
           
            //string fn = dirPath + textBoxFilename.Text + count_index.ToString()+"." + comboBoxFileType.Text;
            string fn = dirPath + filename ;
            HOperatorSet.WriteImage(m_HoImage, type, 0, fn);
          
            return m_HoImage;
        }

        private void buttonGrab_Click_1(object sender, EventArgs e)
        {
            if (CCD_Live.IsAlive)
            {
                PGCCD1.Stop_Acquisition();
               // while (CCD_Live.IsAlive)
                //    PGCCD1.Stop_Acquisition();
                CCD_Live.Join();  // 無發使用  會出錯
                buttonLive.Text = "Live";
            }
            HiPerfTimer TSpend = new HiPerfTimer();
            TSpend.Start();
            PGCCD1.CCD_Type = comboBoxCCDType.Text;  // must tell grabber what kind of CCD is used
            
            PGCCD1.Window = hWindowControl.HalconWindow;  // assign window handle
            m_HoImage = PGCCD1.Grab();
            TSpend.Stop();
           

            HOperatorSet.GetImageSize(m_HoImage, out ImageWidth, out ImageHeight);
            HOperatorSet.DispObj(m_HoImage, hWindowControl.HalconWindow);
            toolStripStatusLabelSpendTime.Text = TSpend.Duration.ToString("F3", CultureInfo.InvariantCulture) + " ms";
            buttonLive.Text = "Live";
            
           
        }
      
        private void FormPGU3HalconAcquisition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PGCCD1.Acquistion_Stop != true)
            {
                PGCCD1.Stop_Acquisition();
                Thread.Sleep(200);
            }
           
        }

        private void comboBoxCCDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCCDType.SelectedIndex == 0)
            {  // select PointGrey CCD
                tabPageSetParameter.Hide();
                tabPageFocus.Hide();
            }
        }

        private void buttonGetPixeLinkCCDInfo_Click(object sender, EventArgs e)
        {
            hCamera = 0;
            ReturnCode rc = Api.Initialize(0, ref hCamera);
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
            txtRoi.Text = "(" + left + "," + top + ") -> (" + (left + width) + "," + (top + height) + ")";

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
                for (int i = 0; i < featureInfo.parameters.Length; i++)
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
            top = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiTop]);
            left = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiLeft]);
            width = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiWidth]);
            height = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiHeight]);

        }
        private void SetRoi(int hCamera, ROI focusROI)
        {
            FeatureFlags flags = FeatureFlags.Persistable;
            int numParms = 4;
            
            float[] parms = new float[numParms];
            parms[(int)FeatureParameterIndex.RoiTop] = focusROI.StartY;
            parms[(int)FeatureParameterIndex.RoiLeft] = focusROI.StartX;
            parms[(int)FeatureParameterIndex.RoiWidth] = focusROI.Width;
            parms[(int)FeatureParameterIndex.RoiHeight] = focusROI.Height;
            ReturnCode rc = Api.SetFeature(hCamera, Feature.SharpnessScore, flags, numParms, parms);
            
        }
        public bool ToUseAutoFocus(bool CanbeAuto)
        {

            
            try
            {
                ReturnCode rc = Api.Initialize(0, ref hCamera);
                if (!Api.IsSuccess(rc))
                {
                    MessageBox.Show("Unable to initialize a camera");
                    return false;
                }
                // Get Focus info
                FeatureFlags flags = 0;
                int numParms = 1;
                float[] parms = new float[numParms];
                rc = Api.GetFeature(hCamera, Feature.Focus, ref flags, ref numParms, parms);
                if (!Api.IsSuccess(rc))
                {
                    return false;
                }
                Debug.Assert(numParms == 1);    //
                //richTextBoxInfo.AppendText("Auto Focus Status = " + flags.ToString());
                
                flags = FeatureFlags.OnePush;
                rc = Api.SetFeature(hCamera, Feature.Focus, flags, numParms, parms);
                
               // Request_Lens_Counter();
                //return parms[0];
                Api.Uninitialize(hCamera);
                if (!Api.IsSuccess(rc))
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        
        
        }

        
        private void buttonAutoFocus_Click(object sender, EventArgs e)
        {
            if (buttonLive.Text == "Live")  // CCD must be live
            {
                buttonLive_Click(sender, e);    
            }
            // use timer does not work
            //timerCheckLensPosition.Enabled = true;  // check position
            bool Sucess = PixeLink_AutoFocus_OnePush();
            //timerCheckLensPosition.Enabled = false;
        }
        bool PixeLink_AutoFocus_OnePush()
        {
            try
            {
                ReturnCode rc = Api.Initialize(0, ref hCamera);
                if (!Api.IsSuccess(rc))
                {
                    MessageBox.Show("Unable to initialize a camera");
                    return false;
                }
                // Get Focus info
                FeatureFlags flags = 0;
                int numParms = 1;
                float[] parms = new float[numParms];
                rc = Api.GetFeature(hCamera, Feature.Focus, ref flags, ref numParms, parms);
                if (!Api.IsSuccess(rc))
                {
                    return false;
                }
                Debug.Assert(numParms == 1);    //
                //richTextBoxInfo.AppendText("Auto Focus Status = " + flags.ToString());
                
                flags = FeatureFlags.OnePush;
                rc = Api.SetFeature(hCamera, Feature.Focus, flags, numParms, parms);
                
                Request_Lens_Counter();
                //return parms[0];
                Api.Uninitialize(hCamera);
                if (!Api.IsSuccess(rc))
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        
        private void Request_Lens_Counter()
        {
            // Get Focus info
            FeatureFlags flags =FeatureFlags.OnePush;
            int numParms = 1;
            float[] parms = new float[numParms];
            ReturnCode rc = Api.GetFeature(hCamera, Feature.Focus, ref flags, ref numParms, parms);
            //richTextBoxInfo.AppendText("No of Parameteres: " + numParms.ToString()+ "\n");
            //richTextBoxInfo.AppendText("Flags: " + flags.ToString() + "\n");
            richTextBoxInfo.Clear();
            richTextBoxInfo.AppendText("Lens Position: " + parms[0].ToString() + "\n");
        }

        private void FormPixeLinkU3HalconAcquisition_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PGCCD1.Acquistion_Stop != true)
            {
                PGCCD1.Stop_Acquisition();
            }
        }

        private void timerCheckLensPosition_Tick(object sender, EventArgs e)
        {
            //if(hCamera != 0)
                Request_Lens_Counter();
        }

        private void buttonManaulFocus_Click(object sender, EventArgs e)
        {
            Maunal_Focus(hScrollBarFocusCounter.Value);
        }
        public void Maunal_Focus(int Counter)
        {
            hCamera = 0;
            ReturnCode rc = Api.Initialize(0, ref hCamera);
            if (!Api.IsSuccess(rc))
            {
                MessageBox.Show("Unable to initialize a camera");
                return;
            }
            FeatureFlags flags = FeatureFlags.Manual;
            int numParms = 1;
            float[] parms = new float[numParms];
            parms[0] = Counter;
            
            rc = Api.SetFeature(hCamera, Feature.Focus, flags, numParms, parms);
            
            Api.Uninitialize(hCamera);
        }
        private void hScrollBarFocusCounter_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxFocusCounter.Text = hScrollBarFocusCounter.Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void hWindowControl_HMouseMove(object sender, HMouseEventArgs e)
        {
            if (m_HoImage == null)
            {
                return;
            }
            HTuple NoOfChannels = 0;
            HTuple grayvalue = 0;
            HOperatorSet.CountChannels(m_HoImage, out NoOfChannels);
            //RichTextInfo.AppendText("No of Channels: " + NoOfChannels.ToString());
            string r, g, b;
            HTuple X = (HTuple)((int)e.X);
            HTuple Y = (HTuple)((int)e.Y);
            HTuple Width = 0, Height = 0;
            HOperatorSet.GetImageSize(m_HoImage, out Width, out Height);
            if (NoOfChannels == 1)
            {
                // get_grayval(Image : : Row, Column : Grayval) 
                if (e.X < Width && e.Y < Height)
                {
                    HOperatorSet.GetGrayval(m_HoImage, Y, X, out grayvalue);
                    toolStripStatusLabelIntensity.Text = "( " + ((int)e.X).ToString() + " , " + ((int)e.Y).ToString() + " ) = " + grayvalue.I.ToString();
                }
            }
            else if (NoOfChannels == 3)
            {
                if (e.X < Width && e.Y < Height)
                {
                    HOperatorSet.GetGrayval(m_HoImage, Y, X, out grayvalue);
                    toolStripStatusLabelIntensity.Text = "( " + ((int)e.X).ToString() + " , " + ((int)e.Y).ToString() + " ) = " + grayvalue[0].I.ToString();
                }
            }
        }

        private void groupBoxROI_Enter(object sender, EventArgs e)
        {
            
        }

        private void checkBoxDisplayROI_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBoxDisplayROI.Checked)
            {
                //if (m_HoImage == null)
                //    return;
                // draw rectangle ROI on Halcon Window
                HTuple row1 = (HTuple)FocusROI.StartY;
                HTuple col1 = (HTuple)FocusROI.StartX;
                HTuple row2 = (HTuple)(FocusROI.Height + FocusROI.StartY);
                HTuple col2 = (HTuple)(FocusROI.Width + FocusROI.StartX);
                //HOperatorSet.DrawRectangle1 (hWindowControl.HalconWindow,  out row1, out col1, out row2, out col2);
                
                HOperatorSet.DispRectangle1(hWindowControl.HalconWindow, row1, col1, row2, col2);
            }*/ // only show one time; not work
            PGCCD1.DisplayROI = true;
            PGCCD1.FocusROI = FocusROI;
        }

        private void tabPageFocus_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownROIWidth_ValueChanged(object sender, EventArgs e)
        {
            FocusROI.Width = (int)numericUpDownROIWidth.Value;
            PGCCD1.FocusROI = FocusROI;
        }

        private void buttonROIUp_Click(object sender, EventArgs e)
        {
            FocusROI.StartY = FocusROI.StartY - (int) numericUpDownROIStep.Value;
            PGCCD1.FocusROI = FocusROI;
            numericUpDownROIStartY.Value = FocusROI.StartY;
        }

        private void buttonROIDown_Click(object sender, EventArgs e)
        {
            FocusROI.StartY = FocusROI.StartY + (int)numericUpDownROIStep.Value;
            PGCCD1.FocusROI = FocusROI;
            numericUpDownROIStartY.Value = FocusROI.StartY;
        }

        private void buttonROIRight_Click(object sender, EventArgs e)
        {
            FocusROI.StartX = FocusROI.StartX + (int)numericUpDownROIStep.Value;
            PGCCD1.FocusROI = FocusROI;
            numericUpDownROIStartX.Value = FocusROI.StartX;
        }

        private void buttonROILeft_Click(object sender, EventArgs e)
        {
            FocusROI.StartX = FocusROI.StartX - (int)numericUpDownROIStep.Value;
            PGCCD1.FocusROI = FocusROI;
            numericUpDownROIStartX.Value = FocusROI.StartX;
        }

        private void numericUpDownROIStartX_ValueChanged(object sender, EventArgs e)
        {
            FocusROI.StartX = (int)numericUpDownROIStartX.Value;
            PGCCD1.FocusROI = FocusROI;
        }

        private void numericUpDownROIStartY_ValueChanged(object sender, EventArgs e)
        {
            FocusROI.StartY = (int)numericUpDownROIStartY.Value;
            PGCCD1.FocusROI = FocusROI;
        }

        private void numericUpDownROIHeight_ValueChanged(object sender, EventArgs e)
        {
            FocusROI.Height= (int)numericUpDownROIHeight.Value;
            PGCCD1.FocusROI = FocusROI;
        }

        private void buttonSetFocusROI_Click(object sender, EventArgs e)
        {
            SetRoi(hCamera, FocusROI);
        }

        private void numericUpDownROIStep_ValueChanged(object sender, EventArgs e)
        {

        }

        

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            string dirPath = Application.StartupPath + @"\Img\";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fn = dirPath + textBoxFilename.Text + "." + comboBoxFileType.Text;
            HOperatorSet.WriteImage(m_HoImage, comboBoxFileType.Text, 0, fn);
        }
        
        private void buttonStopCCD_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (CCD_Live.IsAlive)
            {
                PGCCD1.Stop_Acquisition();
                // while (CCD_Live.IsAlive)
                //    PGCCD1.Stop_Acquisition();
                CCD_Live.Join();  // 無發使用  會出錯
                buttonLive.Text = "Live";
            }
        }

        private void statusStripPixeLink_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
