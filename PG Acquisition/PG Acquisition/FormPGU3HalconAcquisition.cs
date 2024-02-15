using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HalconDotNet;
using PGU3;
using Tien_Function;
using PixeLINK;

// Note: Halcon dotnet is using 11.0 version x64, so the 使用中平台必須為x64
namespace PG_CCD_U3_Acquisition
{
    public partial class FormPGU3HalconAcquisition : Form
    {
        PGU3_CCD_Acquisition PGCCD1 = new PGU3_CCD_Acquisition();
        public HObject m_HoImage = null;
        public CCD_Parameter CCD_Param_1 = new CCD_Parameter();
        private HalconDotNet.HWindowControl hWindowControlPG;
        
        public FormPGU3HalconAcquisition()
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
            hWindowControlPG = new HalconDotNet.HWindowControl();
            hWindowControlPG.AutoScroll = true;
            setView(hWindowControlPG);
            resetView(1280, 1024);
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
            PGCCD1.CCD_Type = comboBoxCCDType.Text;
            PGCCD1.Window = hWindowControlPG.HalconWindow;
            Thread CCD_Live = new Thread(PGCCD1.RunHalcon);
            if (buttonLive.Text == "Live")
            {
                CCD_Live.Start();
                while (!CCD_Live.IsAlive) ;
                buttonLive.Text = "Stop";
            }
            else
            {
                PGCCD1.Stop_Acquisition();
                //PGCCD1.Acquistion_Stop = true;
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
                    hWindowControlPG.Size = new Size(this.Size.Width, Convert.ToInt32(((double)this.Size.Width) / imageRatio));
                }
                else  //以Hieght 為主
                {
                    hWindowControlPG.Size = new Size(Convert.ToInt32(((double)this.Size.Height) * imageRatio), this.Size.Height);
                }
            }
            else  // 符合視窗比例
            {
                hWindowControlPG.Size = this.Size;
            }

            //originalSize = new Size(hWindowControlPG.Size.Width, hWindowControlPG.Size.Height);
            hWindowControlPG.ImagePart = new Rectangle(0, 0, width, height);
        }
        private void buttonGetCCDInfo_Click(object sender, EventArgs e)
        {
            PGCCD1.Window = hWindowControlPG.HalconWindow;
            PGCCD1.Get_Camera_Exposure(ref CCD_Param_1.Exposure);
            richTextBoxInfo.AppendText("CCD Exposure: " + CCD_Param_1.Exposure.ToString());
        }

        private void buttonGrab_Click_1(object sender, EventArgs e)
        {
            PGCCD1.Window = hWindowControlPG.HalconWindow;  // assign window handle
            m_HoImage = PGCCD1.Grab();
            buttonLive.Text = "Live";
        }

        private void FormPGU3HalconAcquisition_FormClosing(object sender, FormClosingEventArgs e)
        {
            PGCCD1.Acquistion_Stop = true;
        }

        private void comboBoxCCDType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            m_HoImage = PGCCD1.Grab();
            buttonLive.Text = "Live";
            HOperatorSet.WriteImage(m_HoImage, "bmp", 0, "temp.bmp"); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Local iconic variables 

            HObject ho_Image = null, ho_SymbolRegions = null;


            // Local control variables 

            HTuple hv_BarCodeHandle = null, hv_WindowHandle = new HTuple();
            HTuple hv_I = null, hv_Width = new HTuple(), hv_Height = new HTuple();
            HTuple hv_DecodedDataStrings = new HTuple(), hv_LastChar = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_SymbolRegions);

            //Read bar codes of type 2/5 Industrial
            //
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
            //set_display_font(hv_ExpDefaultWinHandle, 14, "mono", "true", "false");
            HOperatorSet.SetDraw(hWindowControlPG.HalconWindow, "margin");
            HOperatorSet.SetLineWidth(hWindowControlPG.HalconWindow, 3);
            //for (hv_I = 1; (int)hv_I <= 4; hv_I = (int)hv_I + 1)
            string Path = Application.StartupPath  + @"\Image\";
            string FN = Path + "temp1.bmp";
            //{
                ho_Image.Dispose();
                //HOperatorSet.ReadImage(out ho_Image, "barcode/25industrial/25industrial0" + hv_I);
                HOperatorSet.ReadImage(out ho_Image, FN);
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                //dev_set_window_extents(...);
                HOperatorSet.DispObj(ho_Image, hWindowControlPG.HalconWindow);
                HOperatorSet.SetColor(hWindowControlPG.HalconWindow, "green");
                //Read bar code, the resulting string includes the check character
                HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "check_char", "absent");
                ho_SymbolRegions.Dispose();
                HOperatorSet.FindBarCode(ho_Image, out ho_SymbolRegions, hv_BarCodeHandle,
                    "2/5 Industrial", out hv_DecodedDataStrings);
                HOperatorSet.SetTposition(hWindowControlPG.HalconWindow, 12,12);
                HOperatorSet.WriteString(hWindowControlPG.HalconWindow, hv_DecodedDataStrings);
                //disp_message(hWindowControlPG.HalconWindow, hv_DecodedDataStrings, "window", 12, 12,
                //    "black", "false");
                hv_LastChar = (hv_DecodedDataStrings.TupleStrlen()) - 1;
                //disp_message(hv_ExpDefaultWinHandle, ((HTuple.TupleGenConst(hv_LastChar, " ")).TupleSum()
                //    ) + (hv_DecodedDataStrings.TupleStrBitSelect(hv_LastChar)), "window", 12,
                //    12, "forest green", "false");
                // show the character
                richTextBoxInfo.AppendText("Barcode with Char = " + hv_LastChar.ToString() + "\n");
                //HDevelopStop();
                //Read bar code using the check character to check the result, i.e.,
                //the check character does not belong to the returned string anymore.
                //If the check character is not correct, the bar code reading fails
                HOperatorSet.SetColor(hWindowControlPG.HalconWindow, "green");
                HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "check_char", "present");
                ho_SymbolRegions.Dispose();
                HOperatorSet.FindBarCode(ho_Image, out ho_SymbolRegions, hv_BarCodeHandle,
                    "2/5 Industrial", out hv_DecodedDataStrings);
                //disp_message(hv_ExpDefaultWinHandle, hv_DecodedDataStrings, "window", 36, 12,
                //    "black", "false");
                richTextBoxInfo.AppendText("Barcode with Char = " + hv_DecodedDataStrings.ToString() + "\n");
                HOperatorSet.SetColor(hWindowControlPG.HalconWindow, "magenta");
               // if ((int)(new HTuple(hv_I.TupleLess(4))) != 0)
               // {
               //     HDevelopStop();
               // }
                MessageBox.Show("stop");
            //}
            HOperatorSet.ClearBarCodeModel(hv_BarCodeHandle);
            ho_Image.Dispose();
            ho_SymbolRegions.Dispose();
        }
    }
}
