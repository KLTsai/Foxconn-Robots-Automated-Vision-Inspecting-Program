using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HalconDotNet;
using Tien_Function;
using TienDIP_Funciton_Using_Halcon;
using System.Net;
using System.Net.Sockets;
using TCP_IP_class;



namespace PR
{
    public partial class FormSF : Form
    {
        int i = 0;
       
        string dirPath, selectDir;
        HObject ho_Image = null, ho_Image_Pattern=null, ho_Image_test=null;
        HObject ho_Image_AffinTrans, ho_imageAbsDiff, ho_imageconnect, ho_SelectShape;  // image after rotation
        HObject ho_Image_1 = null;  // after match, reduced
        HObject ho_ImageReduced = null, ho_ImagePart1 = null;
        HObject ho_ShapeModel;  // for display the Shape Finder result
        
        HTuple hv_ParameterName = new HTuple(), hv_ParameterValue = new HTuple();
        HTuple hv_ModelID, hv_ShapeModelID;
        
        float scale =(float) 0.2;
        ShapeFinder_ROI PR_ROI = new ShapeFinder_ROI();

        bool bl_shaper = false;

        delegate void ImageWindow_control(HObject grab_hImage, HWindowControl SF_Window, HTuple width, HTuple height);
        delegate void Set_Parameter_control(NumericUpDown controller, float variable,bool is_Int);
        delegate void Richtext_control(RichTextBox controller, string Message);
        delegate void ComboBox_control(ComboBox controller, HTuple  class_temp);
        delegate void Numeric_Parameter_control(NumericUpDown controller, HTuple class_temp,bool To_convert,bool is_integer);
        delegate void reset_Windows_control(int width, int height, float scale, HWindowControl hWindowControl);
        delegate void Get_control_value(NumericUpDown controller, Decimal To_setvalue);
        delegate void Label_control(Label controller, string message);

        int SmoothNo, OffSet, NoOfClosing, MinArea, MaxArea;
        public FormSF()
        {
            InitializeComponent();

            btn_Send.Enabled = false;


            string Dir = @"\Img";
            LoadDir(Dir);
            PR_ROI.StartX = 130;
            PR_ROI.StartY = 140;
            PR_ROI.Width = 380;
            PR_ROI.Height = 310;
            
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            HOperatorSet.SetColor(hWindowControl2.HalconWindow, "red");
            HOperatorSet.SetDraw(hWindowControl2.HalconWindow, "margin");
        }
        IPEndPoint ipont;
        Socket server;

        #region  ------事件跨執行緒-------
        public void Update_LabelText(Label controller , string message) 
        {
            if (this.InvokeRequired)
            {
                Label_control UI = new Label_control(Update_LabelText);
                this.Invoke(UI, controller, message);
            }
            else
                controller.Text = message;
        
        }
        public void Update_GetNumericDown_P(NumericUpDown controller, Decimal To_setvalue)
        {
            if (this.InvokeRequired)
            {
                Get_control_value UI = new Get_control_value(Update_GetNumericDown_P);
                this.Invoke(UI, controller, To_setvalue);
            }
            else
            {
                if (To_setvalue > -360)
                    controller.Value = (Decimal)To_setvalue;
                else
                    controller.Value = -360;
            }
        
        }
        public void Update_NumericUpDown_Parameter(NumericUpDown controller, HTuple class_temp, bool To_convert,bool is_integer)
        {
            if (this.InvokeRequired)
            {
                Numeric_Parameter_control UI = new Numeric_Parameter_control(Update_NumericUpDown_Parameter);
                this.Invoke(UI, controller, class_temp, To_convert,is_integer);
            }
            else
            {
                if (To_convert == true)
                    class_temp = ((HTuple)controller.Value).TupleRad();
                else
                {
                
                  if(is_integer ==true)
                    class_temp = (HTuple)Convert.ToInt16(controller.Value);
                  else
                    class_temp = (HTuple)(double)controller.Value;
                               
                }
            }
        }//處理控制元件 跨執緒方法  處理class存值狀況
        public void Update_ComboBoxParam(ComboBox controller, HTuple class_temp)
        {
            if (this.InvokeRequired)
            {
                ComboBox_control UI = new ComboBox_control(Update_ComboBoxParam);
                this.Invoke(UI, controller, class_temp);
            }
            else
            {

                class_temp = (HTuple)controller.Text;

            }
        }
        public void Update_Richtextbox(RichTextBox controller, string message)
        {
            if (this.InvokeRequired)
            {
                Richtext_control UI = new Richtext_control(Update_Richtextbox);
                this.Invoke(UI, controller, message);
            }
            else
            {
                controller.AppendText(message);
            }
        }//處理反饋訊息 跨執緒方法
        public void Update_NumericUpDown(NumericUpDown controller, float variable, bool is_int)
        {
            if (this.InvokeRequired)
            {
                Set_Parameter_control UI = new Set_Parameter_control(Update_NumericUpDown);
                this.Invoke(UI, controller, variable, is_int);
            }
            else
            {
                if (is_int == true)
                    variable = Convert.ToInt16(controller.Value);
                else
                    variable = (float)controller.Value;

            }

        }//處理控制元件 跨執緒方法  處理一般變數設置(set)
        public void Update_WindowUI(HObject grab_hImage, HWindowControl SF_Window, HTuple width, HTuple height)
        {
            if (this.InvokeRequired)
            {
                ImageWindow_control UI = new ImageWindow_control(Update_WindowUI);
                this.Invoke(UI, grab_hImage, SF_Window, width, height);
            }
            else
            {
                // PGCCD1.Window = Window.HalconWindow;
                HOperatorSet.GetImageSize(grab_hImage, out width, out height);
                HOperatorSet.DispObj(grab_hImage, SF_Window.HalconWindow);
            }
        }  //畫在halconwindow上的 跨執行緒方法
        public void Update_ResetView(int width, int height, float scale, HWindowControl hWindowControl)
        {
            if (this.InvokeRequired)
            {
                reset_Windows_control UI = new reset_Windows_control(Update_ResetView);
                this.Invoke(UI, width, height, scale, hWindowControl);
            }
            else
            {
                bool FixedDisplayRatio = true;
                if (scale == 0)
                {
                    MessageBox.Show("Please choose correct scale");
                    return;
                }
                if (FixedDisplayRatio == true)  //保持原始比例
                {

                    hWindowControl.Size = new Size((int)(width * scale), (int)(height * scale));

                }
                else  // 符合視窗比例
                {
                    hWindowControl.Size = this.Size;
                }

                hWindowControl.ImagePart = new Rectangle(0, 0, width, height);

            }

        }
         #endregion

        protected void setView(object view)
        {
            //panel1.Controls.Add((Control)view);
        }
        public void resetView(int width, int height, float scale, HalconDotNet.HWindowControl hWindowControl)
        {
            bool FixedDisplayRatio = true;
            //scale = (float) nu //Convert.ToDecimal(textBoxScale.Text);
            if (scale == 0)
            {
                MessageBox.Show("Please choose correct scale");
                return;
            }    
            if (FixedDisplayRatio == true)  //保持原始比例
            {
                
                    hWindowControl.Size = new Size((int) (width * scale), (int) (height * scale));
                
            }
            else  // 符合視窗比例
            {
                hWindowControl.Size = this.Size;
            }

            //originalSize = new Size(hWindowControlPG.Size.Width, hWindowControlPG.Size.Height);
            //hWindowControl2.Left = hWindowControl1.Left + hWindowControl2.Width + 20;
            //hWindowControl2.Size = hWindowControl1.Size;
            hWindowControl.ImagePart = new Rectangle(0, 0, width, height);
        }
        private void LoadDir(string Dir)
        {
            try
            {
                dirPath = Application.StartupPath + Dir; //"\Image";

                List<string> dirs = new List<string>(Directory.EnumerateDirectories(dirPath));

                foreach (var dir in dirs)
                {
                    //Console.WriteLine("{0}", dir.Substring(dir.LastIndexOf("\\") + 1));
                    // add the directory into comboboxDir
                    comboBoxDir.Items.Add(dir);
                }
                //Console.WriteLine("{0} directories found.",  dirs.Count);
                richTextBoxInfo.AppendText(dirs.Count.ToString());
            }
            catch (UnauthorizedAccessException UAEx)
            {
                //Console.WriteLine(UAEx.Message);
                MessageBox.Show(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                //Console.WriteLine(PathEx.Message);
                MessageBox.Show(PathEx.Message);
            }
        }
        private void LoadFile(string selectDir)
        {
            // determine Tag name         
            string file_type = comboBoxImageType.Text;
            try
            {
                var files = from file in Directory.EnumerateFiles(selectDir, "*."+ file_type, SearchOption.TopDirectoryOnly) //  AllDirectories)
                            //from line in File.ReadLines(file)
                            //where line.Contains("Microsoft")
                            select new
                            {
                                File = file,
                                //Line = line
                            };
                int no = 0;

                int dirLength = selectDir.Length;
                foreach (var f in files)
                {
                    no++;
                    //Console.WriteLine("{0}\t{1}", f.File, f.Line);
                    string[] item = new string[3];
                    item[0] = no.ToString();
                    int first = f.File.IndexOf(selectDir) + selectDir.Length + 1;
                    int last = f.File.IndexOf(file_type) + file_type.Length;
                    //int first = f.File.LastIndexOf("\\");
                    int leng = last - first;
                    item[1] = f.File.Substring(first, leng);
                    
                    //item[1] = (string)f.File ;
                    //richTextBoxInfo.AppendText(f.File + "\n");

                    dataGridViewPostureData.Rows.Add(item);
                }
                //Console.WriteLine("{0} files found.", files.Count().ToString());
                textBoxNoOfData.Text = files.Count().ToString();
            }
            catch (UnauthorizedAccessException UAEx)
            {
                //Console.WriteLine(UAEx.Message);
                MessageBox.Show(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                //Console.WriteLine(PathEx.Message);
                MessageBox.Show(PathEx.Message);
            }

        }
        private void dataGridViewPostureData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBoxInfo.Clear();
            //label1Result.Visible = false;
            // check if anything in the grid



            //  SelectedCells[i].Value.ToString());
            if (dataGridViewPostureData.Rows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Please select dir in combobox");
                return;
            }
            //dataGridViewDataList.Rows.Clear();

            //richTextBoxInfo.AppendText("selection changed" + sender.ToString() + "\n");
            Int32 selectedCellCount =
            dataGridViewPostureData.GetCellCount(DataGridViewElementStates.Selected);

            // Original Design is cooperated with dataGrid, now is to show the image on ImageBox

            //string fn;  // declare globally
            //int col, row;

            if (dataGridViewPostureData.AreAllCellsSelected(true))
            {
                MessageBox.Show("All cells are selected", "Selected Cells");
            }
            else
            {
                //System.Text.StringBuilder sb =
                //    new System.Text.StringBuilder();


                string sb;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    //sb.Append("Row: ");
                    int row = dataGridViewPostureData.SelectedCells[i].RowIndex;
                    int col = dataGridViewPostureData.SelectedCells[i].ColumnIndex; // RowIndex;
                    //sb.Append(dataGridViewPostureData.SelectedCells[i].RowIndex
                    //    .ToString());
                    //sb.Append(", Column: ");
                    //sb.Append(dataGridViewPostureData.SelectedCells[i].ColumnIndex
                    //   .ToString());
                    //sb.Append(dataGridViewPostureData.SelectedCells[i].Value.ToString());

                    if (dataGridViewPostureData.SelectedCells[i].Value == null)
                        return;  // no data file

                    sb = (dataGridViewPostureData.SelectedCells[i].Value.ToString());

                    if (dataGridViewPostureData.SelectedCells[i].Value == null)
                    {
                        MessageBox.Show("Please load the image into the directory");
                        return;
                    }
                    

                    string fn = comboBoxDir.Text + "\\" + sb.ToString();  // Application.StartupPath + @"\Image\" +
                    if (!File.Exists(fn))
                    {
                        MessageBox.Show("Please select the filename");
                        return;
                    }
                    // Load Image :  readtxtFromFile(List<String[]> data_total, string filename);
                   
                    
                    
                    
                    //hWindowControl1.ImagePart = new Rectangle(0, 0, width, height);
                    //dev_open_window_fit_image(ho_Image, 0, 0, width / 4, height / 4, out hWindowControl.HalconWindow);
                    scale = (float)numericUpDownScale1.Value;
                    int pos = selectDir.IndexOf("Testing");
                    int pos1 = selectDir.IndexOf("Learn  Image");
                    int pos2 = selectDir.IndexOf("Pattern");
                    if (pos != -1)  // tesing image
                    {
                        HOperatorSet.GenEmptyObj(out ho_Image_test);
                        HOperatorSet.ReadImage(out ho_Image_test, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image_test, out width, out height);
                        scale = (float)numericUpDownScale2.Value;
                        resetView(width, height, scale, hWindowControl2);
                        
                        HOperatorSet.DispObj(ho_Image_test, hWindowControl2.HalconWindow);
                        //tabControlPRNCC.SelectedIndex = 1;
                        //tabControlShapeFinder.SelectedIndex = 0;

                    }
                    else if (pos1 != -1)  // learning image for extraction
                    {
                        HOperatorSet.GenEmptyObj(out ho_Image);
                        HOperatorSet.ReadImage(out ho_Image, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image, out width, out height);
                        scale = (float)numericUpDownScale1.Value;
                        resetView(width, height, scale, hWindowControl1);
                        HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
                        //tabControlPRNCC.SelectedIndex = 0;
                        //tabControlShapeFinder.SelectedIndex = 0;
                    }
                    else if (pos2 != -1) // pattern image
                    {

                        HOperatorSet.GenEmptyObj(out ho_Image_Pattern);
                        HOperatorSet.ReadImage(out ho_Image_Pattern, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image_Pattern, out width, out height);
                        scale = (float)numericUpDownScale1.Value;
                        resetView(width, height, scale, hWindowControl1);
                        HOperatorSet.DispObj(ho_Image_Pattern, hWindowControl1.HalconWindow);
                        //tabControlPRNCC.SelectedIndex = 1;
                        //tabControlShapeFinder.SelectedIndex = 0;

                    }
                    else  // all other cases will be treated as extraction case
                    {
                        HOperatorSet.GenEmptyObj(out ho_Image);
                        HOperatorSet.ReadImage(out ho_Image, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image, out width, out height);
                        scale = (float)numericUpDownScale1.Value;
                        resetView(width, height, scale, hWindowControl1);
                        HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
                        tabControlPRNCC.SelectedIndex = 0;
                        tabControlShapeFinder.SelectedIndex = 0;
                    }


                }
            }
        }

        private void comboBoxDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxInfo.Clear();
            dataGridViewPostureData.Rows.Clear();
            selectDir = comboBoxDir.SelectedItem.ToString();
            LoadFile(selectDir);

            // load first image

            if (dataGridViewPostureData.Rows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Please load images into the corresponding directories");
                return;
            }
        }

        private void buttonROIUp_Click(object sender, EventArgs e)
        {
            if (ho_Image == null)
            {
                MessageBox.Show("Please load learning image");
                return;
            }
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.Width = (int)numericUpDownROIWidth.Value;
            PR_ROI.StartY = PR_ROI.StartY - (int)numericUpDownROIStep.Value;
            numericUpDownROIStartY.Value = PR_ROI.StartY;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonROIDown_Click(object sender, EventArgs e)
        {
            if (ho_Image == null)
            {
                MessageBox.Show("Please load learning image");
                return;
            }
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartY = PR_ROI.StartY + (int)numericUpDownROIStep.Value;
            numericUpDownROIStartY.Value = PR_ROI.StartY;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonROIRight_Click(object sender, EventArgs e)
        {
            if (ho_Image == null)
            {
                MessageBox.Show("Please load learning image");
                return;
            }
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartX = PR_ROI.StartX + (int)numericUpDownROIStep.Value;
            numericUpDownROIStartX.Value = PR_ROI.StartX;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonROILeft_Click(object sender, EventArgs e)
        {
            if (ho_Image == null)
            {
                MessageBox.Show("Please load learning image");
                return;
            }
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartX = PR_ROI.StartX - (int)numericUpDownROIStep.Value;           
            numericUpDownROIStartX.Value = PR_ROI.StartX;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void numericUpDownROIStartX_ValueChanged(object sender, EventArgs e)
        {
            
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartX = (int)numericUpDownROIStartX.Value;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void numericUpDownROIStartY_ValueChanged(object sender, EventArgs e)
        {
            
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartY = (int)numericUpDownROIStartY.Value;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void numericUpDownROIWidth_ValueChanged(object sender, EventArgs e)
        {
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.Width = (int)numericUpDownROIWidth.Value;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void numericUpDownROIHeight_ValueChanged(object sender, EventArgs e)
        {
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.Height = (int)numericUpDownROIHeight.Value;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void checkBoxDisplayROI_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisplayROI.Checked== true)
                HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonSetFocusROI_Click(object sender, EventArgs e)
        {
            HObject rect = null;
            
            HTuple hv_Message = new HTuple();
            HTuple hv_AreaModelRegions = null, hv_RowModelRegions = null;
            HTuple hv_ColumnModelRegions = null, hv_HeightPyramid = null;  // no of pyraid derived by inspect
            HTuple hv_i = null, hv_NumLevels = new HTuple();
            HObject ho_ShapeModelImages=null, ho_ShapeModelRegions=null, ho_ShapeModel=null;
            
            HOperatorSet.GenRectangle1(out rect, (HTuple) PR_ROI.StartY, (HTuple) PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height,  PR_ROI.StartX + PR_ROI.Width);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_ImagePart1);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelImages);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelRegions);
            HOperatorSet.GenEmptyObj(out ho_ShapeModel);
            HOperatorSet.ReduceDomain(ho_Image, rect, out ho_ImageReduced);
            HOperatorSet.DetermineNccModelParams(ho_ImageReduced, "auto", -0.39, 0.79,  "use_polarity", "all", out hv_ParameterName, out hv_ParameterValue);
            hv_Message = "NCC model parameters:";
            richTextBoxInfo.AppendText(hv_Message.ToString() + "\n");
            int NoOfParameter = hv_ParameterName.Length;
            for(int i=0; i< NoOfParameter; i++){
                hv_Message[i+1] = ((hv_ParameterName.TupleSelect(i) + ": ") + (hv_ParameterValue.TupleSelect(i)));
                richTextBoxInfo.AppendText("Parameter " + (i + 1).ToString() + ": " + hv_Message.TupleSelect(i+1).ToString() + "\n");
            }
            //ho_ImagePart1.Dispose();
            //HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart1);
            //HOperatorSet.CreateNccModel(ho_ImagePart1, "auto", -0.39, 0.79, "auto", "use_polarity",  out hv_ModelID);
            // for shape finder: inspect
            hv_ShapeModelID = null;
            HOperatorSet.InspectShapeModel(ho_ImageReduced, out ho_ShapeModelImages, out ho_ShapeModelRegions, 8, 30);  // try to get a good model for shapefinder
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.DispObj(ho_ShapeModelRegions, hWindowControl1.HalconWindow);
            HOperatorSet.AreaCenter(ho_ShapeModelRegions, out hv_AreaModelRegions, out hv_RowModelRegions,  out hv_ColumnModelRegions);
            HOperatorSet.CountObj(ho_ShapeModelRegions, out hv_HeightPyramid);
            HTuple end_val38 = hv_HeightPyramid;
            HTuple step_val38 = 1;
            for (hv_i = 1; hv_i.Continue(end_val38, step_val38); hv_i = hv_i.TupleAdd(step_val38))
            {
                if ((int)(new HTuple(((hv_AreaModelRegions.TupleSelect(hv_i - 1))).TupleGreaterEqual(15))) != 0)  // 面積需大於 15
                {
                    hv_NumLevels = hv_i.Clone();  // 決定 Pyramid 的次數
                }
            }
            HTuple Contrast = 30;  // threshold to derive features
            HTuple MinConstrat = 10;
            HOperatorSet.CreateShapeModel(ho_ImageReduced, hv_NumLevels, 0, (new HTuple(360)).TupleRad(), "auto", "none", "use_polarity", Contrast, MinConstrat, out hv_ShapeModelID);
            ho_ShapeModel.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ShapeModel, hv_ShapeModelID, 1);
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
            HOperatorSet.DispObj(ho_ShapeModel, hWindowControl1.HalconWindow);
            richTextBoxInfo.AppendText("Shape Model ID: " + hv_ShapeModelID.ToString());
        }

        private void buttonSetPRPattern_Click(object sender, EventArgs e)
        {
            HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart1);  // to crop the image to the small boundary
            HOperatorSet.CreateNccModel(ho_ImagePart1, hv_ParameterValue[0], -0.39, 0.79, hv_ParameterValue[1], "use_polarity", out hv_ModelID);
            string Path = Application.StartupPath + @"\Img\Pattern\";
            string FN = Path + textBoxSaveFilename.Text +"." + comboBoxImageType.Text; //@"Pattern1.bmp";
            if(!Directory.Exists(Path)){
                Directory.CreateDirectory(Path);
            }
            HOperatorSet.WriteImage(ho_ImagePart1, comboBoxImageType.Text, 0, FN);
            //HTuple width, height;
            //HOperatorSet.GetImageSize(ho_ImagePart1, out width, out height);
            //resetView(width, height, scale);
            hWindowControl1.HalconWindow.ClearWindow();
            //hWindowControl1.ImagePart = new Rectangle(0, 0, width, height);
            //dev_open_window_fit_image(ho_Image, 0, 0, width / 4, height / 4, out hWindowControl.HalconWindow);
            HOperatorSet.DispObj(ho_ImagePart1, hWindowControl1.HalconWindow);
        }

        private void buttonLearn_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonNCC_PR_Click(object sender, EventArgs e)
        {
            
            /*
            HTuple hv_Row = new HTuple(); // center of gravity of the domain (region) of the image that was used to create the NCC mode
            HTuple hv_Column = new HTuple();
            HTuple hv_Angle =new HTuple();
            HTuple hv_Score = new HTuple();
            // 0: for all match
            double AngleStart = -0.39; //angle.rad 
            double AngleExtent = 0.78; //angle.rad
            double MinScore = 0.5;
            int NumMatches = 0; // all possible matches
            double OverlapRatio = 0.5;
            string isSubpixel ="true";
            int NumLevels = 0; //Number of pyramid levels used in the matching,  If NumLevels is set to 0, the number of pyramid levels specified in create_ncc_model is used. 

            if (hv_ModelID == null)
            {
                MessageBox.Show("Please load or learn the PR Model first!");
                return;
            }
            HOperatorSet.FindNccModel(ho_Image_test, hv_ModelID, AngleStart, AngleExtent, MinScore, NumMatches, OverlapRatio, isSubpixel, NumLevels, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
            if (hv_Row.Length == 0)
            {
                MessageBox.Show("No patterns is found!");
                return;

            }
            HOperatorSet.DispObj(ho_Image_test, hWindowControl2.HalconWindow);  // display the image again
            HOperatorSet.SetColor(hWindowControl2.HalconWindow, "red");
            HObject ho_Rectangle2=null;
            HOperatorSet.GenEmptyObj(out ho_Rectangle2);
            HTuple width, height;
            HOperatorSet.GetImageSize(ho_Image_Pattern, out width, out height);
            for (int i = 0; i < hv_Row.Length; i++)
            { // draw all the pattern with rectangles
                //richTextBoxInfo.AppendText("Center X: " + hv_Column.TupleSelect(i).ToString() + "Center Y: " + hv_Row.TupleSelect(i).ToString() + "Angle : " + hv_Angle.TupleSelect(i).ToString()+ "\n");
                HOperatorSet.DispCross(hWindowControl2.HalconWindow, hv_Row[i], hv_Column[i], 20.0, 0.0);
                HOperatorSet.GenRectangle2(out ho_Rectangle2, hv_Row[i], hv_Column[i], hv_Angle[i], width, height);
                HOperatorSet.DispRectangle2(hWindowControl2.HalconWindow, hv_Row[i], hv_Column[i], hv_Angle[i], width* 0.5, height* 0.5);
            }
            ho_Rectangle2.Dispose();
             **/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TienDIP_PR Tien_PR = new TienDIP_PR();
            Tien_PR.Pattern = ho_Image_Pattern;
            Tien_PR.Image_Testing = ho_Image_test;
            Tien_PR.HWindowControl = hWindowControl2;  //to display the testing image and matchiing result
            Tien_PR.RichTextBoxInfo = richTextBoxInfo;
            //Tien_PR.Hv_ModelID = hv_ModelID;
            // PR param setup
            Tien_PR.PR_NCC_Param.AngleStart = (double) numericUpDownAngleStart.Value;
            Tien_PR.PR_NCC_Param.AngleExtent = (double)numericUpDownAngleExtent.Value;
            //Tien_PR.PR_Param.NumLevel = 0;  // using default
            if (checkBoxisSubPixel.Checked)
                Tien_PR.PR_NCC_Param.isSubpixel = "true";
            else
            {
                Tien_PR.PR_NCC_Param.isSubpixel = "false";
            }
            Tien_PR.PR_NCC_Param.MinScore = (double)numericUpDownMinScore.Value;
            Tien_PR.PR_NCC_Param.NumMatches = (int)numericUpDownNoOfMatches.Value;
            Tien_PR.PR_NCC_Param.OverlapRatio = (double)numericUpDownOverlapRatio.Value;

            // determine and create ncc model
            hv_ModelID = Tien_PR.PR_NCC_Learn();
            if (hv_ModelID != null)
            {
                System.Windows.Forms.MessageBox.Show("NCC Model is learned");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Learning failed!");
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hv_ModelID == null)
            {
                MessageBox.Show("Please load or learn the PR Model first!");
                return;
            }
            if (ho_Image_test == null)
            {
                MessageBox.Show("Please load image first");
                return;
            }
            TienDIP_PR Tien_PR = new TienDIP_PR();
            Tien_PR.Pattern = ho_Image_Pattern;  // should be learn in the pattern, if not then send the pattern
            Tien_PR.Image_Testing = ho_Image_test;
            Tien_PR.HWindowControl = hWindowControl2;  //to display the testing image and matchiing result
            Tien_PR.RichTextBoxInfo = richTextBoxInfo;
            Tien_PR.Hv_ModelID = hv_ModelID;  // must be learnt first
            // PR param setup
            Tien_PR.PR_NCC_Param.AngleStart = (double)numericUpDownAngleStart.Value;
            Tien_PR.PR_NCC_Param.AngleExtent = (double)numericUpDownAngleExtent.Value;
            Tien_PR.PR_NCC_Param.MinScore = (double)numericUpDownMinScore.Value;
            Tien_PR.PR_NCC_Param.NumMatches = (int)numericUpDownNoOfMatches.Value;
            Tien_PR.PR_NCC_Param.OverlapRatio = (double)numericUpDownOverlapRatio.Value;
            if (checkBoxisSubPixel.Checked)
                Tien_PR.PR_NCC_Param.isSubpixel = "true";
            else
            {
                Tien_PR.PR_NCC_Param.isSubpixel = "false";
            }
            PR_NCC_Result Result = new PR_NCC_Result();
            //Tien_PR.PR_Result = Result;  // send to get result back (position and no of matches)
            //Tien_PR.PR_Param.NumLevel = 0;  // using default
            if (checkBoxisSubPixel.Checked)
                Tien_PR.PR_NCC_Param.isSubpixel = "true";
            else
            {
                Tien_PR.PR_NCC_Param.isSubpixel = "false";
            }

            // run PR matching
            Result = Tien_PR.PR_NCC_Matching();

            // display the result
           
             HObject ho_Rectangle2 = null;
             if (Result == null)
                 return;
             HOperatorSet.GenEmptyObj(out ho_Rectangle2);
             for (int i = 0; i < Result.NoOfMatch; i++)
            { // draw all the pattern with rectangles
                richTextBoxInfo.AppendText("Center X: " + Result.Column[i].F.ToString() + "Center Y: " + Result.Row[i].F.ToString() + "Angle : " + ((Result.Angle[i].F)/3.14159 * 180).ToString() + "\n");
                HOperatorSet.DispCross(hWindowControl2.HalconWindow, Result.Row[i], Result.Column[i], 20.0, 0.0);
                HOperatorSet.GenRectangle2(out ho_Rectangle2, Result.Row[i], Result.Column[i], Result.Angle[i], Result.Width * 0.5, Result.Height*0.5);
                HOperatorSet.DispRectangle2(hWindowControl2.HalconWindow, Result.Row[i], Result.Column[i], Result.Angle[i], Result.Width * 0.5, Result.Height * 0.5);
            }
             numericUpDownCenterX.Value = (Decimal)Result.Column[0].D;
             numericUpDownCenterY.Value = (Decimal)Result.Row[0].D;
             numericUpDownAngle.Value = (Decimal)(-Result.Angle[0].D / 3.14159 * 180);
             ho_Rectangle2.Dispose();
        }

        private void numericUpDownROIStep_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownROIStartY.Increment = numericUpDownROIStep.Increment;
            numericUpDownROIStartX.Increment = numericUpDownROIStep.Increment;
            numericUpDownROIWidth.Increment = numericUpDownROIStep.Increment;
            numericUpDownROIHeight.Increment = numericUpDownROIStep.Increment; 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (ho_Image_Pattern == null)
            {
                MessageBox.Show("Please load the pattern first");
                return;
            }
            HTuple hv_AreaModelRegions = null, hv_RowModelRegions = null;
            HTuple hv_ColumnModelRegions = null, hv_HeightPyramid = null;  // no of pyraid derived by inspect
            HTuple hv_i = null, hv_NumLevels = new HTuple();

            HObject ho_ShapeModelRegions, ho_ShapeModelImages; // ho_ShapeModel: declared globally

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            //HOperatorSet.GenEmptyObj(out ho_ImagePart1);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelImages);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelRegions);
            HOperatorSet.GenEmptyObj(out ho_ShapeModel);
            HOperatorSet.InspectShapeModel(ho_Image_Pattern, out ho_ShapeModelImages, out ho_ShapeModelRegions, 8, 30);  // try to get a good model for shapefinder
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.DispObj(ho_ShapeModelRegions, hWindowControl1.HalconWindow);
            HOperatorSet.AreaCenter(ho_ShapeModelRegions, out hv_AreaModelRegions, out hv_RowModelRegions, out hv_ColumnModelRegions);
            HOperatorSet.CountObj(ho_ShapeModelRegions, out hv_HeightPyramid);
            HTuple end_val38 = hv_HeightPyramid;
            HTuple step_val38 = 1;
            
            for (hv_i = 1; hv_i.Continue(end_val38, step_val38); hv_i = hv_i.TupleAdd(step_val38))
            {
                if ((int)(new HTuple(((hv_AreaModelRegions.TupleSelect(hv_i - 1))).TupleGreaterEqual(15))) != 0)  // 面積需大於 15
                {
                    hv_NumLevels = hv_i.Clone();  // 決定 Pyramid 的次數
                }
            }
            HTuple AngelStart = (new HTuple(0)).TupleRad(); // Transform to Radius
            HTuple AngelExtent = (new HTuple(360)).TupleRad();
            HTuple Contrast = 30;  // threshold to derive features, or use "auto"
            HTuple MinConstrat = 10;  // or use "auto"
            HOperatorSet.CreateShapeModel(ho_Image_Pattern, hv_NumLevels, AngelStart, AngelExtent, "auto", "none", "use_polarity", "auto", "auto", out hv_ShapeModelID);
            richTextBoxInfo.AppendText("Shape Model ID: " + hv_ShapeModelID.ToString());
            ho_ShapeModel.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ShapeModel, hv_ShapeModelID, 1);  // 只會show 出1/4的Contour pattern，因為中心點在pattern的中心點
            //HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
            //HOperatorSet.DispObj(ho_ShapeModel, hWindowControl1.HalconWindow);
            if (hv_ShapeModelID != null)
                MessageBox.Show("Shape Model is learned");
            ho_ShapeModelRegions.Dispose();
            ho_ShapeModelImages.Dispose();
            //ho_ShapeModel.Dispose(); // will be used later
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void MainmenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonLearnSF_Tien_Click(object sender, EventArgs e)
        {
            
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (ho_Image_Pattern == null)
            {
                MessageBox.Show("Please load the pattern first");
                return;
            }
            HTuple hv_AreaModelRegions = null, hv_RowModelRegions = null;
            HTuple hv_ColumnModelRegions = null, hv_HeightPyramid = null;  // no of pyraid derived by inspect
            HTuple hv_i = null, hv_NumLevels = new HTuple();

            HObject ho_ShapeModelRegions, ho_ShapeModelImages; // ho_ShapeModel: declared globally

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            //HOperatorSet.GenEmptyObj(out ho_ImagePart1);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelImages);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelRegions);
            HOperatorSet.GenEmptyObj(out ho_ShapeModel);
            HOperatorSet.InspectShapeModel(ho_Image_Pattern, out ho_ShapeModelImages, out ho_ShapeModelRegions, 8, 30);  // try to get a good model for shapefinder
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.DispObj(ho_ShapeModelRegions, hWindowControl1.HalconWindow);
            HOperatorSet.AreaCenter(ho_ShapeModelRegions, out hv_AreaModelRegions, out hv_RowModelRegions, out hv_ColumnModelRegions);
            HOperatorSet.CountObj(ho_ShapeModelRegions, out hv_HeightPyramid);
            HTuple end_val38 = hv_HeightPyramid;
            HTuple step_val38 = 1;
            for (hv_i = 1; hv_i.Continue(end_val38, step_val38); hv_i = hv_i.TupleAdd(step_val38))
            {
                if ((int)(new HTuple(((hv_AreaModelRegions.TupleSelect(hv_i - 1))).TupleGreaterEqual(15))) != 0)  // 面積需大於 15
                {
                    hv_NumLevels = hv_i.Clone();  // 決定 Pyramid 的次數
                }
            }
            HTuple AngelStart = (new HTuple(0)).TupleRad(); // Transform to Radius
            HTuple AngelExtent = (new HTuple(360)).TupleRad();
            HTuple Contrast = 30;  // threshold to derive features, or use "auto"
            HTuple MinConstrat = 10;  // or use "auto"
            HOperatorSet.CreateShapeModel(ho_Image_Pattern, hv_NumLevels, AngelStart, AngelExtent, "auto", "none", "use_polarity", "auto", "auto", out hv_ShapeModelID);
            richTextBoxInfo.AppendText("Shape Model ID: " + hv_ShapeModelID.ToString());
            ho_ShapeModel.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ShapeModel, hv_ShapeModelID, 1);  // 只會show 出1/4的Contour pattern，因為中心點在pattern的中心點
            //HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
            //HOperatorSet.DispObj(ho_ShapeModel, hWindowControl1.HalconWindow);
            if (hv_ShapeModelID != null)
                MessageBox.Show("Shape Model is learned");
            ho_ShapeModelRegions.Dispose();
            ho_ShapeModelImages.Dispose();
            //ho_ShapeModel.Dispose(); // will be used later

            bl_shaper = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PR_Shape_Parameter Tien_PR_Param = new PR_Shape_Parameter();
            TienDIP_PR Tien_SF = new TienDIP_PR();  // to call function later
            PR_Shape_Result Result = new PR_Shape_Result();

            Tien_SF.HWindowControl = hWindowControl2;  //to display the testing image and matchiing result
            Tien_SF.RichTextBoxInfo = richTextBoxInfo;

            // PR param setup
            // set up the parameter used by shape finder;
            Tien_PR_Param.ShapeModelID = hv_ShapeModelID;  // must send in the learned model ID
            Tien_PR_Param.TestingImage = ho_Image_test; // send in the image for shape finding (desitnation image)
            Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
            Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
            Tien_PR_Param.AngleStep = "auto";
            Tien_PR_Param.Optimization = comboBoxSFOptimization.Text;  // use "none" or "auto";
            Tien_PR_Param.NumLevel = 0;  // using default
            Tien_PR_Param.Subpixel = (HTuple)comboBoxSFSubpixel.Text;
            Tien_PR_Param.MinScore = (HTuple)(double)numericUpDownSFMinScore.Value;
            Tien_PR_Param.NumMatches = (HTuple)Convert.ToInt16(numericUpDownSFNoOfMatch.Value);
            Tien_PR_Param.OverlapRatio = (HTuple)(double)numericUpDownSFOverlapRatio.Value;
            Tien_PR_Param.Greediness = (HTuple)(double)numericUpDownSFGreediness.Value;

            Result = Tien_SF.PR_Shape_Finder(Tien_PR_Param);
            if (Result == null)
            {
                MessageBox.Show("Shape Finder: no match found!");
                return;
            }
            for (int i = 0; i < Result.NoOfMatch; i++)
            {
                richTextBoxInfo.AppendText("Center X: " + Result.Column[i].F.ToString() + ", Center Y: " + Result.Row[i].F.ToString() + ", Angle: " + (Result.Angle[0].D / 3.14159 * 180).ToString());
            }
            numericUpDownCenterX.Value = (Decimal) Result.Column[0].D;
            numericUpDownCenterY.Value = (Decimal) Result.Row[0].D;
            numericUpDownAngle.Value = (Decimal) (-Result.Angle[0].D /3.14159 * 180);

        }

        private void buttonSF_Click(object sender, EventArgs e)
        {
            if (ho_Image_test == null)
            {
                MessageBox.Show("Please load testing image from grid");
                return;
            }
            if (hv_ShapeModelID == null)
            {
                MessageBox.Show("Please learn the shape first");
                return;
            }
            // source image: ho_Image_test
            // pattern image: ho_Image_pattern
            HTuple AngelStart = (new HTuple(0)).TupleRad(); // Transform to Radius
            HTuple AngelExtent = (new HTuple(360)).TupleRad();
            HTuple Contrast = 30;  // threshold to derive features, or use "auto"
            HTuple MinConstrat = 10;  // or use "auto"
            HTuple MinScore = 0.7;
            HTuple NoOfMatch = 1; // 0; // all possible match
            HTuple MaxOverlap = 0.5;
            HTuple NumLevels = 0; // default
            HTuple Greediness = 0.7;
            HTuple hv_RowCheck = new HTuple(), hv_ColumnCheck = new HTuple(), hv_AngleCheck = new HTuple(), hv_Score = new HTuple(); // to store the found row, col, and anlge, score;
            String SubPixel = "least_squares";// least_squares"
            // subpixel: //none', 'interpolation', 'least_squares', 'least_squares_high', 'least_squares_very_high', 'max_deformation 1',
            //          'max_deformation 2', 'max_deformation 3', 'max_deformation 4', 'max_deformation 5', 'max_deformation 6' 
            // about greediness; The parameter Greediness determines how “greedily” the search should be carried out. If Greediness=0, 
            //                    a safe search heuristic is used, which always finds the model if it is visible in the image. 
            //                    However, the search will be relatively time consuming in this case. If Greediness=1, an unsafe search heuristic is used, 
            //                    which may cause the model not to be found in rare cases, even though it is visible in the image. 
            //                    For Greediness=1, the maximum search speed is achieved. In almost all cases, the shape model will always be found for Greediness=0.9. 
            HOperatorSet.FindShapeModel(ho_Image_test, hv_ShapeModelID, AngelStart, AngelExtent, MinScore, NoOfMatch, MaxOverlap, SubPixel, NumLevels, Greediness,
                out hv_RowCheck, out hv_ColumnCheck, out hv_AngleCheck, out hv_Score);
            int NoOfFound = hv_Score.Length;
            if (NoOfFound == 0)
            {
                MessageBox.Show("No match is found");
                return;
            }
            // display the found pattern

            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "yellow");
            HTuple hv_MovementOfObject = new HTuple();  // Homogenous 2d Matrix: 旋轉矩陣
            HObject ho_ModelAtNewPosition = new HObject();
            HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowCheck, hv_ColumnCheck, hv_AngleCheck, out hv_MovementOfObject);
            ho_ModelAtNewPosition.Dispose();
            HOperatorSet.AffineTransContourXld(ho_ShapeModel, out ho_ModelAtNewPosition, hv_MovementOfObject); // 旋轉 ho_ShapeModel，此object 只是用來繪圖使用
            HOperatorSet.DispObj(ho_Image_test, hWindowControl2.HalconWindow);
            HOperatorSet.DispObj(ho_ModelAtNewPosition, hWindowControl2.HalconWindow);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PR_Shape_Parameter Tien_PR_Param = new PR_Shape_Parameter();
            TienDIP_PR Tien_SF = new TienDIP_PR();  // to call function later

            //Tien_PR_Param.Image_Testing = ho_Image_test;
            Tien_SF.HWindowControl = hWindowControl1;  //to display the testing image and matchiing result
            Tien_SF.RichTextBoxInfo = richTextBoxInfo;
            //Tien_PR.Hv_ModelID = hv_ModelID;
            // PR param setup
            // set up the parameter used by shape finder;
            Tien_PR_Param.Pattern = ho_Image_Pattern;
            Tien_PR_Param.AngleStart = (HTuple)numericUpDownAngleStart.Value;
            Tien_PR_Param.AngleExtent = (HTuple)numericUpDownAngleExtent.Value;
            //Tien_PR.PR_Param.NumLevel = 0;  // using default

            Tien_PR_Param.Subpixel = (HTuple)comboBoxSFSubpixel.Text;
            Tien_PR_Param.MinScore = (HTuple)numericUpDownMinScore.Value;
            Tien_PR_Param.NumMatches = (HTuple)numericUpDownNoOfMatches.Value;
            Tien_PR_Param.OverlapRatio = (HTuple)numericUpDownOverlapRatio.Value;

            // determine and create ncc model
            hv_ShapeModelID = Tien_SF.Learn_Shape_Model(Tien_PR_Param);  // 回傳 shapeModelID
            if (hv_ShapeModelID != null)
            {
                System.Windows.Forms.MessageBox.Show("Shape Model is learned");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Shape Model Learning failed!");
            }
        }

        private void buttonAffineTransform_Click(object sender, EventArgs e)
        {

            Tien_Affine_Transform_Image Affine_Transform = new Tien_Affine_Transform_Image();
            Affine_Transform.Hv_CenterX = (HTuple)numericUpDownCenterX.Value;
            Affine_Transform.Hv_CenterY = (HTuple)numericUpDownCenterY.Value;
            Affine_Transform.Hv_Angle = (HTuple)numericUpDownAngle.Value;
            Affine_Transform.Hv_Scale = (HTuple)numericUpDownTransform_Scale.Value;
            //Affine_Transform.hv_HalconWinHandle = hWindowControl2.HalconWindow;// send when calling action()
            ho_Image_AffinTrans = Affine_Transform.RunHalcon(ho_Image_test); //, hWindowControl2.HalconWindow);
            HOperatorSet.ClearWindow(hWindowControl2.HalconWindow);
            HOperatorSet.DispObj(ho_Image_AffinTrans, hWindowControl2.HalconWindow);
            HOperatorSet.DispCross(hWindowControl2.HalconWindow, Affine_Transform.Hv_CenterY, Affine_Transform.Hv_CenterX, 30, 0);  // size: 30, anlge: 0
            HTuple ROI_X1, ROI_Y1, ROI_X2, ROI_Y2;
            HTuple Width, Height;
            HOperatorSet.GetImageSize(ho_Image_Pattern, out Width, out Height);
            ROI_X1 = Affine_Transform.Hv_CenterX - Width / 2;
            ROI_X2 = Affine_Transform.Hv_CenterX + Width / 2;
            ROI_Y1 = Affine_Transform.Hv_CenterY - Height / 2;
            ROI_Y2 = Affine_Transform.Hv_CenterY + Height / 2;
            HObject Rect1 = null;
            HOperatorSet.GenRectangle1(out Rect1, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
            HOperatorSet.DispRectangle1(hWindowControl2.HalconWindow, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);

            //MessageBox.Show("Done");
        
        }

        private void Getcoordinate(out double X_value, out double Y_value)
        {
            X_value = Convert.ToDouble(numericUpDownCenterX.Value);
            Y_value = Convert.ToDouble(numericUpDownCenterY.Value);
        }

        public void Client()
        {
            byte[] bytes = new byte[1024];
            try
            {
                ipont = new IPEndPoint(IPAddress.Parse(texb_IP.Text), Convert.ToInt16(texb_Port.Text));

                //將IP位址和Port宣告為服務的連接點(Server Ip,20 Port)

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //宣告一個Socket通訊介面(使用IPv4協定,通訊類型,通訊協定)
                try
                {

                    server.Connect(ipont);
                    /*if (!this.server.Poll(5000, SelectMode.SelectError))
                    {
                        //強制拋出例外..
                        throw new Exception("Connect Timeout");
                    }*/
                    server.RemoteEndPoint.ToString();
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
                    int bytesSent = server.Send(msg);
                    //server.Shutdown(SocketShutdown.Both);
                }
                catch (ArgumentNullException eee)
                {
                    richTextBox1.AppendText(eee.Message);
                }
                catch (SocketException A)
                {
                    richTextBox1.AppendText(A.Message);
                }
                catch (InvalidOperationException B)
                {
                    richTextBox1.AppendText(B.Message);
                }
                finally
                {
                    //richTextBox1.AppendText("NO!!!!!!!!!");                   
                }
            }
            catch (SocketException e)
            {
                richTextBox1.AppendText(e.Message);
            }
            catch (Exception e)
            {
                richTextBox1.AppendText(e.Message);
            }
        }

        private void tryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Click_ClienConnect_Click(object sender, EventArgs e)
        {
            Client();
            if (server.IsBound)
                btn_Send.Enabled = true;
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {

            string input = "X:" + Convert.ToString(numericUpDownCenterX.Value) + "  " + "Y:" + Convert.ToString(numericUpDownCenterY.Value);

            //接收輸入字串

            if (input == "exit")
            {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                richTextBox1.AppendText("離線!!!!");
                btn_Send.Enabled = false;
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(input);

            //將字串以UTF8編碼存入緩衝區

            server.Send(data);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Path = Application.StartupPath + @"\Img\Pattern\";
            string fn=Path+"Pattern"+".bmp";

            //if (CSystemPara.sp_shape_finder == true)
            {
                timer1.Enabled = false;
                HOperatorSet.GenEmptyObj(out ho_Image_Pattern);
                HOperatorSet.ReadImage(out ho_Image_Pattern, fn);
                HTuple width, height;
                HOperatorSet.GetImageSize(ho_Image_Pattern, out width, out height);
                scale = (float)numericUpDownScale1.Value;
                resetView(width, height, scale, hWindowControl1);
                HOperatorSet.DispObj(ho_Image_Pattern, hWindowControl1.HalconWindow);


                button12_Click_1(sender, e);
                //------------------------------patten學習完成

              /*  if (bl_shaper == true)  //-------------------讀取Testing Image 
                {
                    string test_Path = Application.StartupPath + @"\Img\Testing Image\";
                    string test_fn = test_Path + "temp_1" + ".bmp";

                    HOperatorSet.GenEmptyObj(out ho_Image_test);
                    HOperatorSet.ReadImage(out ho_Image_test, test_fn);
                    HTuple width2, height2;
                    HOperatorSet.GetImageSize(ho_Image_test, out width2, out height2);
                    scale = (float)numericUpDownScale2.Value;
                    resetView(width2, height2, scale, hWindowControl2);

                    HOperatorSet.DispObj(ho_Image_test, hWindowControl2.HalconWindow);

                    button4_Click(sender, e);



                }

                buttonAffineTransform_Click(sender, e);//此時停止timer1
                */
               // Testing_Process();
               

           }
        }
       
        public  void Testing_Process(int index)
        {

          //-------------------讀取Testing Image ----直接進處理
        
                //string test_Path = Application.StartupPath + @"\Img\Testing Image\";
                //string test_fn = test_Path + "case_" + index+ " " +comboBox1.SelectedItem.ToString()+ ".bmp";
                
               //HOperatorSet.GenEmptyObj(out ho_Image_test);
                //HOperatorSet.ReadImage(out ho_Image_test, ho_Image_test.ToString());
                HTuple width2, height2;
                HOperatorSet.GetImageSize(CSystemPara.sp_HoImage, out width2, out height2);  //把得到的圖直接丟進來  從系統參數取
                scale = (float)numericUpDownScale2.Value;
                //Update_NumericUpDown(numericUpDownScale2, scale,false);
                //resetView(width2, height2, scale, hWindowControl2);
                Update_ResetView(width2, height2, scale, hWindowControl2);
                //HOperatorSet.DispObj(CSystemPara.sp_HoImage, hWindowControl2.HalconWindow);
                //Update_WindowUI(CSystemPara.sp_HoImage, hWindowControl2, width2, height2);
            
            //---------------------------------------------------------------------Testing Model
                PR_Shape_Parameter Tien_PR_Param = new PR_Shape_Parameter();
                TienDIP_PR Tien_SF = new TienDIP_PR();  // to call function later
                PR_Shape_Result Result = new PR_Shape_Result();
           
                Tien_SF.HWindowControl = hWindowControl2;  //to display the testing image and matchiing result
                Tien_SF.RichTextBoxInfo = richTextBoxInfo;

                
            // PR param setup
                // set up the parameter used by shape finder;
                Tien_PR_Param.ShapeModelID = index;  // must send in the learned model ID
                Tien_PR_Param.TestingImage = CSystemPara.sp_HoImage; // send in the image for shape finding (desitnation image)
                //Update_NumericUpDown_Parameter(numericUpDownSFAngleStart, Tien_PR_Param.AngleStart,true,false);
                //Update_NumericUpDown_Parameter(numericUpDownSFAngleExtent, Tien_PR_Param.AngleExtent,true,false);
                Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                Tien_PR_Param.AngleStep = "auto";
                //Tien_PR_Param.Optimization = comboBoxSFOptimization.Text;  // use "none" or "auto";
                Update_ComboBoxParam(comboBoxSFOptimization, Tien_PR_Param.Optimization);
                Tien_PR_Param.NumLevel = 0;  // using default
                Tien_PR_Param.Subpixel = (HTuple)comboBoxSFSubpixel.Text;
                //Update_ComboBoxParam(comboBoxSFSubpixel, Tien_PR_Param.Subpixel);
                Tien_PR_Param.MinScore = (HTuple)(double)numericUpDownSFMinScore.Value;
                //Update_NumericUpDown_Parameter(numericUpDownSFMinScore, Tien_PR_Param.MinScore,false,false);
                Tien_PR_Param.NumMatches = (HTuple)Convert.ToInt16(numericUpDownSFNoOfMatch.Value);
                //Update_NumericUpDown_Parameter(numericUpDownSFNoOfMatch, Tien_PR_Param.NumMatches,false,true);
                Tien_PR_Param.OverlapRatio = (HTuple)(double)numericUpDownSFOverlapRatio.Value;
                //Update_NumericUpDown_Parameter(numericUpDownSFOverlapRatio, Tien_PR_Param.OverlapRatio,false,false);
                Tien_PR_Param.Greediness = (HTuple)(double)numericUpDownSFGreediness.Value;
                //Update_NumericUpDown_Parameter(numericUpDownSFGreediness, Tien_PR_Param.Greediness,false,false);

                Result = Tien_SF.PR_Shape_Finder(Tien_PR_Param);
              
               if (Result == null)
                {
                    MessageBox.Show("Shape Finder: no match found!" + " ERROR :" + (index + 1));
                    return;
                }
                for (int i = 0; i < Result.NoOfMatch; i++)
                {
                   // richTextBoxInfo.AppendText("Center X: " + Result.Column[i].F.ToString() + ", Center Y: " + Result.Row[i].F.ToString() + ", Angle: " + (Result.Angle[0].D / 3.14159 * 180).ToString());
                    Update_Richtextbox(richTextBoxInfo, "Center X: " + Result.Column[i].F.ToString() + ", Center Y: " + Result.Row[i].F.ToString() + ", Angle: " + (Result.Angle[0].D / 3.14159 * 180).ToString());
                }

                Update_GetNumericDown_P(numericUpDownCenterX, (Decimal)Result.Column[0].D);
                Update_GetNumericDown_P(numericUpDownCenterY, (Decimal)Result.Row[0].D);
                Update_GetNumericDown_P(numericUpDownAngle, (Decimal)(-Result.Angle[0].D / 3.14159 * 180));
                //numericUpDownCenterX.Value = (Decimal)Result.Column[0].D;
                //numericUpDownCenterY.Value = (Decimal)Result.Row[0].D;
                //numericUpDownAngle.Value = (Decimal)(-Result.Angle[0].D / 3.14159 * 180);
                
                //---------------------------------------------------------------Transform
           
                Tien_Affine_Transform_Image Affine_Transform = new Tien_Affine_Transform_Image();
               
                //Update_NumericUpDown_Parameter(numericUpDownCenterX, Affine_Transform.Hv_CenterX,false);
                //Update_NumericUpDown_Parameter(numericUpDownCenterY, Affine_Transform.Hv_CenterY,false);
               // Update_NumericUpDown_Parameter(numericUpDownAngle, Affine_Transform.Hv_Angle,false);
                //Update_NumericUpDown_Parameter(numericUpDownTransform_Scale, Affine_Transform.Hv_Scale,false);
               
                Affine_Transform.Hv_CenterX = (HTuple)numericUpDownCenterX.Value;
                Affine_Transform.Hv_CenterY = (HTuple)numericUpDownCenterY.Value;
                Affine_Transform.Hv_Angle = (HTuple)numericUpDownAngle.Value;
                Affine_Transform.Hv_Scale = (HTuple)numericUpDownTransform_Scale.Value;
               // Affine_Transform.hv_HalconWinHandle = hWindowControl2.HalconWindow;// send when calling action()
                ho_Image_AffinTrans = Affine_Transform.RunHalcon(CSystemPara.sp_HoImage); //, hWindowControl2.HalconWindow);
               // HOperatorSet.ClearWindow(hWindowControl2.HalconWindow);
               // HOperatorSet.DispObj(ho_Image_AffinTrans, hWindowControl2.HalconWindow);
                //HOperatorSet.DispCross(hWindowControl2.HalconWindow, Affine_Transform.Hv_CenterY, Affine_Transform.Hv_CenterX, 30, 0);  // size: 30, anlge: 0


                string Path = Application.StartupPath + @"\Img\Pattern\";
                string fn = Path + "Pattern_" + (index + 1) + ".bmp";

                HOperatorSet.GenEmptyObj(out ho_Image_Pattern);
                HOperatorSet.ReadImage(out ho_Image_Pattern, fn);
                HTuple show_width, show_height;
                HOperatorSet.GetImageSize(ho_Image_Pattern, out show_width, out show_height);
                scale = (float)numericUpDownScale1.Value;
                //resetView(show_width, show_height, scale, hWindowControl1);
                Update_ResetView(show_width, show_height, scale, hWindowControl1);
                //HOperatorSet.DispObj(ho_Image_Pattern, hWindowControl1.HalconWindow);//UI
                Update_WindowUI(ho_Image_Pattern, hWindowControl1, show_width, show_height);





                HTuple ROI_X1, ROI_Y1, ROI_X2, ROI_Y2;
                HTuple Width, Height;
                HOperatorSet.GetImageSize(ho_Image_Pattern, out Width, out Height);
                ROI_X1 = Affine_Transform.Hv_CenterX - Width / 2;
                ROI_X2 = Affine_Transform.Hv_CenterX + Width / 2;
                ROI_Y1 = Affine_Transform.Hv_CenterY - Height / 2;
                ROI_Y2 = Affine_Transform.Hv_CenterY + Height / 2;
                HObject Rect1 = null;
                //HOperatorSet.GenRectangle1(out Rect1, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
                //HOperatorSet.DispRectangle1(hWindowControl2.HalconWindow, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
                
                
            
            //------------------------------------------------Match Again
              

                //Tien_SF.HWindowControl = hWindowControl2;  //to display the testing image and matchiing result
                //Tien_SF.RichTextBoxInfo = richTextBoxInfo;

                // PR param setup
                // set up the parameter used by shape finder;
                Tien_PR_Param.ShapeModelID = index;  // must send in the learned model ID
                Tien_PR_Param.TestingImage = ho_Image_AffinTrans;// using transformed image   // ho_Image_test; // send in the image for shape finding (desitnation image)
                Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                //Update_NumericUpDown_Parameter(numericUpDownSFAngleStart, Tien_PR_Param.AngleStart,true);
                Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                //Update_NumericUpDown_Parameter(numericUpDownSFAngleExtent, Tien_PR_Param.AngleExtent, true);
                Tien_PR_Param.AngleStep = "auto";
                Tien_PR_Param.Optimization = comboBoxSFOptimization.Text;  // use "none" or "auto";
                //Update_ComboBoxParam(comboBoxSFOptimization, Tien_PR_Param.Optimization);
                Tien_PR_Param.NumLevel = 0;  // using default
                //Tien_PR_Param.Subpixel = (HTuple)comboBoxSFSubpixel.Text;
                Update_ComboBoxParam(comboBoxSFSubpixel, Tien_PR_Param.Subpixel);
                Tien_PR_Param.MinScore = (HTuple)(double)numericUpDownSFMinScore.Value;
                //Update_NumericUpDown_Parameter(numericUpDownSFMinScore, Tien_PR_Param.MinScore, false);
                Tien_PR_Param.NumMatches = (HTuple)Convert.ToInt16(numericUpDownSFNoOfMatch.Value);
                //Update_NumericUpDown_Parameter(numericUpDownSFNoOfMatch, Tien_PR_Param.NumMatches, false);
                Tien_PR_Param.OverlapRatio = (HTuple)(double)numericUpDownSFOverlapRatio.Value;
                //Update_NumericUpDown_Parameter(numericUpDownSFOverlapRatio, Tien_PR_Param.OverlapRatio, false);
               Tien_PR_Param.Greediness = (HTuple)(double)numericUpDownSFGreediness.Value;
                //Update_NumericUpDown_Parameter(numericUpDownSFGreediness, Tien_PR_Param.Greediness, false);
               
            switch (index)
                {
                    case 0:
                            numericUpDownSFAngleStart.Value = -1;
                            Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                            numericUpDownSFAngleExtent.Value = 1;
                            Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                            break;
                //case 9:
                //        numericUpDownSFAngleStart.Value = -5;
                //        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                //        numericUpDownSFAngleExtent.Value = 10;
                //        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                //        break;
                   
                    case 31:
                        numericUpDownSFAngleStart.Value = -5;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 5;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                    case 32:
                        numericUpDownSFAngleStart.Value = -1;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 1;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                    case 37:
                        numericUpDownSFAngleStart.Value = -10;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 10;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                    case 38:
                        numericUpDownSFAngleStart.Value = -1;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 1;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                    case 40:
                        numericUpDownSFAngleStart.Value = -3;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 3;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                    case 41:
                        numericUpDownSFAngleStart.Value = -1;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 1;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                  
                
                case 43:
                        numericUpDownSFAngleStart.Value = -5;
                        Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
                        numericUpDownSFAngleExtent.Value = 5;
                        Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
                        break;
                }

                Result = Tien_SF.PR_Shape_Finder(Tien_PR_Param);
                if (Result == null)
                {
                    MessageBox.Show("Shape Finder: no match found!" + " ERROR :" + (index + 1));
                    return;
                }
                for (int i = 0; i < Result.NoOfMatch; i++)
                {
                    //richTextBoxInfo.AppendText("Center X: " + Result.Column[i].F.ToString() + ", Center Y: " + Result.Row[i].F.ToString() + ", Angle: " + (Result.Angle[0].D / 3.14159 * 180).ToString());
                    Update_Richtextbox(richTextBoxInfo,"Center X: " + Result.Column[i].F.ToString() + ", Center Y: " + Result.Row[i].F.ToString() + ", Angle: " + (Result.Angle[0].D / 3.14159 * 180).ToString()+"\n");
                }
                // match again, so the center and rectangle should be a better position
                 //numericUpDownCenterX.Value = (Decimal)Result.Column[0].D;
                // numericUpDownCenterY.Value = (Decimal)Result.Row[0].D;
                 //numericUpDownAngle.Value = (Decimal)(-Result.Angle[0].D / 3.14159 * 180);
            Update_GetNumericDown_P(numericUpDownCenterX, (Decimal)Result.Column[0].D);
            Update_GetNumericDown_P(numericUpDownCenterY, (Decimal)Result.Row[0].D);
            Update_GetNumericDown_P(numericUpDownAngle, (Decimal)(-Result.Angle[0].D / 3.14159 * 180));
           


               HOperatorSet.ClearWindow(hWindowControl2.HalconWindow);
              // HOperatorSet.DispObj(ho_Image_AffinTrans, hWindowControl2.HalconWindow);
               //HOperatorSet.DispCross(hWindowControl2.HalconWindow, Result.Row[0].D, Result.Column[0].D, 30, 0);  // size: 30, anlge: 0
                
            
                HOperatorSet.GetImageSize(ho_Image_Pattern, out Width, out Height);
                //richTextBoxInfo.AppendText("Pattern: Width = " + Width.ToString() + ",  Height=" + Height.ToString() + "\n");
                //Update_Richtextbox(richTextBoxInfo, "Pattern: Width = " + Width.ToString() + ",  Height=" + Height.ToString() + "\n");
                ROI_X1 = (int)Result.Column[0].D - Width / 2 + 1;
                ROI_X2 = (int)ROI_X1 + Width - 1;
                ROI_Y1 = (int)Result.Row[0].D - Height / 2 + 1;
                ROI_Y2 = (int)ROI_Y1 + Height - 1;  // make sure the width and height are same as pattern;
                Rect1 = null;
                HOperatorSet.GenRectangle1(out Rect1, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
                HOperatorSet.DispRectangle1(hWindowControl2.HalconWindow, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
                //HOperatorSet.ReduceDomain(ho_Image_AffinTrans, Rect1, out ho_ImageReduced);
                HOperatorSet.ClearWindow(hWindowControl2.HalconWindow);
                HOperatorSet.CropRectangle1(ho_Image_AffinTrans, out ho_ImageReduced, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
                //HOperatorSet.DispObj(ho_ImageReduced, hWindowControl2.HalconWindow);
               // HOperatorSet.WriteImage(ho_ImageReduced, "bmp", 0, "test.bmp");
                
               //richTextBoxInfo.AppendText("Reduced: Width = " + Width.ToString() + ",  Height=" + Height.ToString() + "\n");
                Update_Richtextbox(richTextBoxInfo, "Reduced: Width = " + Width.ToString() + ",  Height=" + Height.ToString() + "\n");

                //-------------------------------------------------------------Segment
              
                HObject SegImage = null;
                HOperatorSet.GenEmptyObj(out SegImage);
                
                int SmoothNo = (int)numericUpDownSmoothWindowSize.Value;
                //Update_NumericUpDown(numericUpDownSmoothWindowSize, SmoothNo,true);
                int OffSet = (int)numericUpDownOffSet.Value;
                //Update_NumericUpDown(numericUpDownOffSet, (int)OffSet,true);
                int NoOfClosing = (int)numericUpDownNoOfClosing.Value;
               // Update_NumericUpDown(numericUpDownNoOfClosing, (int)NoOfClosing,true);
                int MinArea = (int)numericUpDownMinArea.Value;
               // Update_NumericUpDown(numericUpDownMinArea, (int)MinArea,true);
                int MaxArea = (int)numericUpDownMaxArea.Value;
                //Update_NumericUpDown(numericUpDownMaxArea, (int)MaxArea,true);
               switch(index) 
               {
                   case 10 :
                       OffSet = 40;
                       MinArea = 1100;
                       MaxArea = 7000;
                       break;
                   case 11:
                       OffSet = 35;
                       SmoothNo = 5;
                        MinArea = 1100;
                       MaxArea = 7000;
                       break;
                  // case 12:
                      // OffSet = 35;
                     //  SmoothNo = 5;
                      // MinArea = 1100;
                      // MaxArea = 7000;
                      // break;
                   case 13 :
                       OffSet = 25;
                       SmoothNo = 5;
                       MinArea = 300;
                       MaxArea = 5400;
                       break;
                   case 14:
                       OffSet = 36;
                       SmoothNo = 5;
                       MinArea = 300;
                       MaxArea = 5400;
                       break;
                   case 15 :
                       OffSet = 33;
                       SmoothNo = 5;
                       MinArea = 300;
                       MaxArea = 5400;
                           break;
                   case 16 :
                       OffSet = 35;
                       SmoothNo = 20;
                       MinArea = 100;
                       MaxArea = 1000;
                           break;
                   case 17 :
                       OffSet = 35;
                       SmoothNo = 20;
                       MinArea = 200;
                       MaxArea = 5000;
                           break;
                   case 18 :
                           OffSet = 35;
                       SmoothNo = 20;
                       MinArea = 200;
                       MaxArea = 5000;
                           break;
                   case 19:
                           OffSet = 35;
                           SmoothNo = 20;
                           NoOfClosing = 5;
                           MinArea = 250;
                           MaxArea = 1100;
                           break;
                   case 20:
                           OffSet = 30;
                           SmoothNo = 20;
                           NoOfClosing = 5;
                           MinArea = 100;
                           MaxArea = 500;
                           break;
                   case 21:
                           OffSet = 35;
                           SmoothNo = 20;
                           NoOfClosing = 5;
                           MinArea = 500;
                           MaxArea = 4000;
                           break;
                   case 22:
                           OffSet = 40;
                           SmoothNo = 25;
                           MinArea = 500;
                           MaxArea = 10000;
                           break;
                   case 23:
                           OffSet = 30;
                           SmoothNo = 25;
                           MinArea = 500;
                           MaxArea = 5000;
                           break;
                   case 24:
                           OffSet = 45;
                           SmoothNo = 25;
                           MinArea = 100;
                           MaxArea = 1000;
                           break;
                   case 25 :
                           OffSet = 45;
                           SmoothNo = 15;
                           MinArea = 600;
                           MaxArea = 5500;
                           break;
                    case 26:
                           OffSet = 45;
                           SmoothNo =15;
                           MinArea = 600;
                           MaxArea = 6000;
                           break;
                    case 27:
                           OffSet = 45;
                           SmoothNo = 25;
                           MinArea = 600;
                           MaxArea = 7000;
                           break;
                   
                   
                   case  28:
                            OffSet = 45;
                           SmoothNo = 25;
                           MinArea = 100;
                           MaxArea = 1000;
                           break;
                   case 29 :
                           OffSet = 45;
                           SmoothNo = 25;
                           MinArea = 100;
                           MaxArea = 1000;
                           break;
                   case 30:
                           OffSet = 39;
                           SmoothNo = 15;
                           MinArea = 200;
                           MaxArea = 1000;
                       break;
                   case 32 :
                       OffSet = 10;
                           SmoothNo =30;
                           MinArea = 700;
                           MaxArea = 5000;
                       break;
                   case 33:
                       OffSet = 10;
                           SmoothNo = 3;
                           MinArea = 1000;
                           MaxArea = 5000;
                       break;
                   case 34 :
                       OffSet = 2;
                           SmoothNo = 10;
                           MinArea = 1000;
                           MaxArea = 5000;
                       break;
                  // case 36:
                    //  OffSet = 9;
                      //     SmoothNo = 20;
                      //     MinArea = 500;
                       //    MaxArea = 2000;
                      // break;
                   case 37 :
                       OffSet = 19;
                       SmoothNo = 45;
                           MinArea = 500;
                           MaxArea = 5000;  
                       break;
                   case 38:
                       OffSet = 15;
                       SmoothNo = 20;
                       MinArea = 800;
                       MaxArea = 5000;
                       break;
                   case 39:
                       OffSet = 10;
                       SmoothNo = 20;
                       MinArea = 800;
                       MaxArea = 5000;
                       break;

                   case 40:
                       OffSet = 21;
                       break;

                   case 42:
                       OffSet = 10;
                       SmoothNo = 25;
                       MinArea = 1000;
                       MaxArea = 5000;
                       break;
               }

                Image_Compare_Segment(ho_ImageReduced, ho_Image_Pattern, out SegImage, SmoothNo, OffSet, NoOfClosing, MinArea, MaxArea);

                Update_LabelText(label43, (index + 1).ToString());
               //set up
                HOperatorSet.SetLineWidth(hWindowControl2.HalconWindow, 2);
                HOperatorSet.SetColored(hWindowControl2.HalconWindow, 12);
                HOperatorSet.SetDraw(hWindowControl2.HalconWindow, "fill"); // "margin");
                HOperatorSet.DispObj(ho_ImageReduced, hWindowControl2.HalconWindow);
                HOperatorSet.DispObj(SegImage, hWindowControl2.HalconWindow);
                //Update_WindowUI(ho_ImageReduced, hWindowControl2, Width, Height);
                //Update_WindowUI(SegImage, hWindowControl2, Width, Height);
                //------------------------------------------------------------Find difference
               

            








               /* int SmoothNo = (int)numericUpDownSmoothWindowSize.Value;
                int OffSet = (int)numericUpDownOffSet.Value;
                int NoOfClosing = (int)numericUpDownNoOfClosing.Value;
                int MinArea = (int)numericUpDownMinArea.Value;
                int MaxArea = (int)numericUpDownMaxArea.Value;

                HObject[] OTemp = new HObject[10];
                HObject MeanImage = null, ho_RegionDynThresh = null, ho_imgthreshold = null;
                HObject ho_RegionClosing = null, ho_ConnectedRegions = null, imgdifference = null;
                // Source Image: Pattern
                // Compared Image: ho_ImageReduced
                HTuple width1, height1;
                HOperatorSet.GetImageSize(ho_Image_Pattern, out width1, out height1);
                HOperatorSet.GetImageSize(ho_ImageReduced, out width2, out height2);
                richTextBoxInfo.AppendText("Pattern Image: Width = " + width1.ToString() + ",  Height=" + height1.ToString() + "\n");
                richTextBoxInfo.AppendText("Reduced Image: Width = " + width2.ToString() + ",  Height=" + height2.ToString() + "\n");
                HOperatorSet.AbsDiffImage(ho_Image_Pattern, ho_ImageReduced, out ho_imageAbsDiff, 1);//threshold 再segment ,image segment 

                HOperatorSet.Threshold(ho_imageAbsDiff, out ho_imgthreshold, 128, 255);
                HOperatorSet.ClosingRectangle1(ho_imgthreshold, out ho_RegionClosing, NoOfClosing, NoOfClosing);
                HOperatorSet.Connection(ho_RegionClosing, out ho_ConnectedRegions);
                HOperatorSet.FillUp(ho_ConnectedRegions, out OTemp[0]);
                HOperatorSet.SelectShape(ho_RegionClosing, out OTemp[0], "area", "and", MinArea, MaxArea); // 150, 99999

                imgdifference = OTemp[0];

                HOperatorSet.DispObj(ho_ImageReduced, hWindowControl2.HalconWindow);
                HOperatorSet.DispObj(imgdifference, hWindowControl2.HalconWindow);
            */
             
        }


        private void buttonSegment_Click(object sender, EventArgs e)
        {
            HObject SegImage = null;
            HOperatorSet.GenEmptyObj(out SegImage);
            int SmoothNo = (int)numericUpDownSmoothWindowSize.Value;
            int OffSet = (int)numericUpDownOffSet.Value;
            int NoOfClosing = (int)numericUpDownNoOfClosing.Value;
            int MinArea = (int)numericUpDownMinArea.Value;
            int MaxArea = (int)numericUpDownMaxArea.Value;

         
            Image_Compare_Segment(ho_ImageReduced, ho_Image_Pattern, out SegImage, SmoothNo, OffSet, NoOfClosing, MinArea, MaxArea);

            //set up
            HOperatorSet.SetLineWidth(hWindowControl2.HalconWindow, 2);
            HOperatorSet.SetColored(hWindowControl2.HalconWindow, 12);
            HOperatorSet.SetDraw(hWindowControl2.HalconWindow, "fill"); // "margin");
            HOperatorSet.DispObj(ho_ImageReduced, hWindowControl2.HalconWindow);
            HOperatorSet.DispObj(SegImage, hWindowControl2.HalconWindow);
        }
        private void Image_Compare_Segment(HObject ho_Image, HObject Pattern_Image, out HObject SegmentImage, int SmoothNo, int OffSet, int NoOfClosing, int MinArea, int MaxArea)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[10];
            // local images
            HObject MeanImage = null, ho_RegionDynThresh = null;
            HObject ho_RegionClosing = null, ho_ConnectedRegions = null;

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out MeanImage);
            HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
            HOperatorSet.GenEmptyObj(out ho_RegionClosing);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);

            HTuple hv_Width, hv_Height;
            HOperatorSet.GetImageSize(Pattern_Image, out hv_Width, out hv_Height); // standard Image: Pattern
            MeanImage.Dispose();
            HOperatorSet.MeanImage(Pattern_Image, out MeanImage, SmoothNo, SmoothNo);

            ho_RegionDynThresh.Dispose();
            // Note: DynThreshold Segments an image using a local threshold in given image (Usuaaly is a mean image)
            // 25 is the offset: g_t - Offset > g_o or g_o > g_t + Offset  will be segment out
            //With dyn_threshold, contours of an object can be extracted, where the objects' size (diameter) is determined by the mask size of the lowpass filter and the amplitude of the objects' edges: 
            HOperatorSet.DynThreshold(ho_Image, MeanImage, out ho_RegionDynThresh, OffSet, "not_equal"); //
            ho_RegionClosing.Dispose();
            //HOperatorSet.ClosingRectangle1(ho_RegionDynThresh, out ho_RegionClosing, NoOfClosing, NoOfClosing);**
            HOperatorSet.ClosingCircle(ho_RegionDynThresh, out ho_RegionClosing, NoOfClosing);
            //dilation_rectangle1 (RegionDynThresh, RegionClosing, 15, 15)
            ho_ConnectedRegions.Dispose();

            HOperatorSet.FillUp(ho_RegionClosing, out ho_ConnectedRegions);
            HOperatorSet.Connection(ho_ConnectedRegions, out OTemp[0]);
           
            ho_ConnectedRegions.Dispose();
            ho_ConnectedRegions = OTemp[0];
            HOperatorSet.SelectShape(ho_ConnectedRegions, out OTemp[0], "area", "and", MinArea, MaxArea); // 150, 99999

            HOperatorSet.ShapeTrans(OTemp[0], out OTemp[0], "outer_circle");
            HOperatorSet.GenContourRegionXld(OTemp[0], out OTemp[0], "border");
            ho_ConnectedRegions.Dispose();
            SegmentImage = OTemp[0];
            //HOperatorSet.DispObj(ho_ImageNew, hv_ExpDefaultWinHandle);
            //HOperatorSet.DispObj(ho_ConnectedRegions, hv_ExpDefaultWinHandle);
            //ho_Image.Dispose();
            //HOperatorSet.CopyObj(ho_ImageNew, out ho_Image, 1, 1);
        }

        private void buttonFindDiff_Click(object sender, EventArgs e)
        {
         
            int SmoothNo = (int)numericUpDownSmoothWindowSize.Value;
            int OffSet = (int)numericUpDownOffSet.Value;
            int NoOfClosing = (int)numericUpDownNoOfClosing.Value;
            int MinArea = (int)numericUpDownMinArea.Value;
            int MaxArea = (int)numericUpDownMaxArea.Value;

            HObject[] OTemp = new HObject[10];
            HObject MeanImage = null, ho_RegionDynThresh = null,ho_imgthreshold=null;
            HObject ho_RegionClosing = null, ho_ConnectedRegions = null,imgdifference=null;
            // Source Image: Pattern
            // Compared Image: ho_ImageReduced
            HTuple width1, width2, height1, height2;
            HOperatorSet.GetImageSize(ho_Image_Pattern, out width1, out height1);
            HOperatorSet.GetImageSize(ho_ImageReduced, out width2, out height2);
            richTextBoxInfo.AppendText("Pattern Image: Width = " + width1.ToString() + ",  Height=" + height1.ToString() + "\n");
            richTextBoxInfo.AppendText("Reduced Image: Width = " + width2.ToString() + ",  Height=" + height2.ToString() + "\n");
            HOperatorSet.AbsDiffImage(ho_Image_Pattern, ho_ImageReduced, out ho_imageAbsDiff, 1);//threshold 再segment ,image segment 

            HOperatorSet.Threshold(ho_imageAbsDiff, out ho_imgthreshold, 128, 255);
            HOperatorSet.ClosingRectangle1(ho_imgthreshold, out ho_RegionClosing, NoOfClosing, NoOfClosing);
            HOperatorSet.Connection(ho_RegionClosing, out ho_ConnectedRegions);
            HOperatorSet.FillUp(ho_ConnectedRegions, out OTemp[0]);
            HOperatorSet.SelectShape(ho_RegionClosing, out OTemp[0], "area", "and", MinArea, MaxArea); // 150, 99999

            imgdifference = OTemp[0];

            HOperatorSet.DispObj(ho_ImageReduced, hWindowControl2.HalconWindow);
            HOperatorSet.DispObj(imgdifference, hWindowControl2.HalconWindow);
        }

        private void buttonMatchAgain_Click(object sender, EventArgs e)
        {
            PR_Shape_Parameter Tien_PR_Param = new PR_Shape_Parameter();
            TienDIP_PR Tien_SF = new TienDIP_PR();  // to call function later
            PR_Shape_Result Result = new PR_Shape_Result();

            Tien_SF.HWindowControl = hWindowControl2;  //to display the testing image and matchiing result
            Tien_SF.RichTextBoxInfo = richTextBoxInfo;

            // PR param setup
            // set up the parameter used by shape finder;
            Tien_PR_Param.ShapeModelID = hv_ShapeModelID;  // must send in the learned model ID
            Tien_PR_Param.TestingImage = ho_Image_AffinTrans;// using transformed image   // ho_Image_test; // send in the image for shape finding (desitnation image)
            Tien_PR_Param.AngleStart = ((HTuple)numericUpDownSFAngleStart.Value).TupleRad();
            Tien_PR_Param.AngleExtent = ((HTuple)numericUpDownSFAngleExtent.Value).TupleRad();
            Tien_PR_Param.AngleStep = "auto";
            Tien_PR_Param.Optimization = comboBoxSFOptimization.Text;  // use "none" or "auto";
            Tien_PR_Param.NumLevel = 0;  // using default
            Tien_PR_Param.Subpixel = (HTuple)comboBoxSFSubpixel.Text;
            Tien_PR_Param.MinScore = (HTuple)(double)numericUpDownSFMinScore.Value;
            Tien_PR_Param.NumMatches = (HTuple)Convert.ToInt16(numericUpDownSFNoOfMatch.Value);
            Tien_PR_Param.OverlapRatio = (HTuple)(double)numericUpDownSFOverlapRatio.Value;
            Tien_PR_Param.Greediness = (HTuple)(double)numericUpDownSFGreediness.Value;

            Result = Tien_SF.PR_Shape_Finder(Tien_PR_Param);
            if (Result == null)
            {
                MessageBox.Show("Shape Finder: no match found!");
                return;
            }
            for (int i = 0; i < Result.NoOfMatch; i++)
            {
                richTextBoxInfo.AppendText("Center X: " + Result.Column[i].F.ToString() + ", Center Y: " + Result.Row[i].F.ToString() + ", Angle: " + (Result.Angle[0].D / 3.14159 * 180).ToString());
            }
            // match again, so the center and rectangle should be a better position
            numericUpDownCenterX.Value = (Decimal)Result.Column[0].D;
            numericUpDownCenterY.Value = (Decimal)Result.Row[0].D;
            numericUpDownAngle.Value = (Decimal)(-Result.Angle[0].D / 3.14159 * 180);


            HOperatorSet.ClearWindow(hWindowControl2.HalconWindow);
            HOperatorSet.DispObj(ho_Image_AffinTrans, hWindowControl2.HalconWindow);
            HOperatorSet.DispCross(hWindowControl2.HalconWindow, Result.Row[0].D, Result.Column[0].D, 30, 0);  // size: 30, anlge: 0
            HTuple ROI_X1, ROI_Y1, ROI_X2, ROI_Y2;
            HTuple Width, Height;
            HOperatorSet.GetImageSize(ho_Image_Pattern, out Width, out Height);
            richTextBoxInfo.AppendText("Pattern: Width = " + Width.ToString() + ",  Height=" + Height.ToString() + "\n");
            ROI_X1 = (int)Result.Column[0].D - Width / 2 + 1;
            ROI_X2 = (int)ROI_X1 + Width - 1;
            ROI_Y1 = (int)Result.Row[0].D - Height / 2 + 1;
            ROI_Y2 = (int)ROI_Y1 + Height - 1;  // make sure the width and height are same as pattern;
            HObject Rect1 = null;
            HOperatorSet.GenRectangle1(out Rect1, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
            HOperatorSet.DispRectangle1(hWindowControl2.HalconWindow, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
            //HOperatorSet.ReduceDomain(ho_Image_AffinTrans, Rect1, out ho_ImageReduced);
            HOperatorSet.ClearWindow(hWindowControl2.HalconWindow);
            HOperatorSet.CropRectangle1(ho_Image_AffinTrans, out ho_ImageReduced, ROI_Y1, ROI_X1, ROI_Y2, ROI_X2);
            HOperatorSet.DispObj(ho_ImageReduced, hWindowControl2.HalconWindow);
            HOperatorSet.WriteImage(ho_ImageReduced, "bmp", 0, "test.bmp");
            richTextBoxInfo.AppendText("Reduced: Width = " + Width.ToString() + ",  Height=" + Height.ToString() + "\n");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            i++;
            string index = Convert.ToString(i);
            Testing_Process(Convert.ToInt16(index));
            //label43.Text = index;

            if (i == 29)
                i = 0;

            /* HTuple number1;
            HOperatorSet.Threshold(ho_imageAbsDiff,out ho_imageAbsDiff,128,255);
           // HOperatorSet.CountObj(ho_imageAbsDiff,out number1);
           // HOperatorSet.DispRegion(ho_imageAbsDiff, hWindowControl2.HalconWindow);
            HOperatorSet.Connection(ho_imageAbsDiff, out ho_imageconnect);
            HOperatorSet.SelectShape(ho_imageconnect, out ho_SelectShape, "area", "and", 10, 9999);
            HOperatorSet.DispRegion(ho_SelectShape, hWindowControl2.HalconWindow);
      
            */
        }

        private void Ini_LearnPattern_Btn_Click(object sender, EventArgs e)
        {

            for (int num = 0; num < 48; num++)
            {
                //-------------------讀取pattern
                string Path = Application.StartupPath + @"\Img\Pattern\";
                string fn = Path + "Pattern_" + (num+1) + ".bmp";

                HOperatorSet.GenEmptyObj(out ho_Image_Pattern);
                HOperatorSet.ReadImage(out ho_Image_Pattern, fn);
                HTuple width, height;
                HOperatorSet.GetImageSize(ho_Image_Pattern, out width, out height);
                scale = (float)numericUpDownScale1.Value;
                Update_NumericUpDown(numericUpDownScale1, scale, false);
                resetView(width, height, scale, hWindowControl1);
                //Update_ResetView(width, height, scale, hWindowControl1);
                //HOperatorSet.DispObj(ho_Image_Pattern, hWindowControl1.HalconWindow);//UI
                Update_WindowUI(ho_Image_Pattern, hWindowControl1, width, height);

                //------------------------------learning

                if (ho_Image_Pattern == null)
                {
                    // MessageBox.Show("Please load the pattern first");
                    return;
                }
                HTuple hv_AreaModelRegions = null, hv_RowModelRegions = null;
                HTuple hv_ColumnModelRegions = null, hv_HeightPyramid = null;  // no of pyraid derived by inspect
                HTuple hv_i = null, hv_NumLevels = new HTuple();

                HObject ho_ShapeModelRegions, ho_ShapeModelImages; // ho_ShapeModel: declared globally

                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                //HOperatorSet.GenEmptyObj(out ho_ImagePart1);
                HOperatorSet.GenEmptyObj(out ho_ShapeModelImages);
                HOperatorSet.GenEmptyObj(out ho_ShapeModelRegions);
                HOperatorSet.GenEmptyObj(out ho_ShapeModel);
                HOperatorSet.InspectShapeModel(ho_Image_Pattern, out ho_ShapeModelImages, out ho_ShapeModelRegions, 8, 30);  // try to get a good model for shapefinder
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                HOperatorSet.DispObj(ho_ShapeModelRegions, hWindowControl1.HalconWindow);
                HOperatorSet.AreaCenter(ho_ShapeModelRegions, out hv_AreaModelRegions, out hv_RowModelRegions, out hv_ColumnModelRegions);
                HOperatorSet.CountObj(ho_ShapeModelRegions, out hv_HeightPyramid);
                HTuple end_val38 = hv_HeightPyramid;
                HTuple step_val38 = 1;
                for (hv_i = 1; hv_i.Continue(end_val38, step_val38); hv_i = hv_i.TupleAdd(step_val38))
                {
                    if ((int)(new HTuple(((hv_AreaModelRegions.TupleSelect(hv_i - 1))).TupleGreaterEqual(15))) != 0)  // 面積需大於 15
                    {
                        hv_NumLevels = hv_i.Clone();  // 決定 Pyramid 的次數
                    }
                }
                HTuple AngelStart = (new HTuple(0)).TupleRad(); // Transform to Radius
                HTuple AngelExtent = (new HTuple(360)).TupleRad();
                HTuple Contrast = 30;  // threshold to derive features, or use "auto"
                HTuple MinConstrat = 10;  // or use "auto"
                HOperatorSet.CreateShapeModel(ho_Image_Pattern, hv_NumLevels, AngelStart, AngelExtent, "auto", "none", "use_polarity", "auto", "auto", out hv_ShapeModelID);
                //richTextBoxInfo.AppendText("Shape Model ID: " + hv_ShapeModelID.ToString());
                Update_Richtextbox(richTextBoxInfo, "Shape Model ID: " + hv_ShapeModelID.ToString()+"\n");
                ho_ShapeModel.Dispose();
                HOperatorSet.GetShapeModelContours(out ho_ShapeModel, hv_ShapeModelID, 1);  // 只會show 出1/4的Contour pattern，因為中心點在pattern的中心點
               
                //HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
               //HOperatorSet.DispObj(ho_ShapeModel, hWindowControl1.HalconWindow);
                if (hv_ShapeModelID != null)
                {
                   // richTextBoxInfo.AppendText(ho_ShapeModel[i].ToString() + "\n");
                }
                // MessageBox.Show("Shape Model is learned"+i);
                ho_ShapeModelRegions.Dispose();
                ho_ShapeModelImages.Dispose();
                //ho_ShapeModel.Dispose(); // will be used later

     
                bl_shaper = true;
            }
            
            
            MessageBox.Show("Learn Patterns had done!!!");
        }

    }
}
