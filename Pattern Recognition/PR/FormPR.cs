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

namespace PR
{
    public partial class FormPR : Form
    {
        string dirPath, selectDir;
        HObject ho_Image = null, ho_Image_Pattern=null, ho_Image_test=null;
        HObject ho_ImageReduced = null, ho_ImagePart1 = null; 
        HTuple hv_ParameterName = new HTuple(), hv_ParameterValue = new HTuple();
        HTuple hv_ModelID;
        float scale =(float) 0.2;
        ROI PR_ROI = new ROI();
        
        public FormPR()
        {
            InitializeComponent();
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
        protected void setView(object view)
        {
            //panel1.Controls.Add((Control)view);
        }
        public void resetView(int width, int height, float scale, HalconDotNet.HWindowControl hWindowControl1)
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
                
                    hWindowControl1.Size = new Size((int) (width * scale), (int) (height * scale));
                
            }
            else  // 符合視窗比例
            {
                hWindowControl1.Size = this.Size;
            }

            //originalSize = new Size(hWindowControlPG.Size.Width, hWindowControlPG.Size.Height);
            //hWindowControl2.Left = hWindowControl1.Left + hWindowControl2.Width + 20;
            //hWindowControl2.Size = hWindowControl1.Size;
            hWindowControl1.ImagePart = new Rectangle(0, 0, width, height);
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
            try
            {
                var files = from file in Directory.EnumerateFiles(selectDir, "*.bmp", SearchOption.TopDirectoryOnly) //  AllDirectories)
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
                    int last = f.File.IndexOf("bmp") + "bmp".Length;
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
                        MessageBox.Show("Please load the data into the directory");
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
                    int pos1 = selectDir.IndexOf("Pattern Image");
                    if (pos != -1)
                    {
                        HOperatorSet.GenEmptyObj(out ho_Image_test);
                        HOperatorSet.ReadImage(out ho_Image_test, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image_test, out width, out height);
                        scale = (float)numericUpDownScale2.Value;
                        resetView(width, height, scale, hWindowControl2);
                        
                        HOperatorSet.DispObj(ho_Image_test, hWindowControl2.HalconWindow);
                        tabControlPR.SelectedIndex = 1;

                    }
                    else if (pos1 != -1)  // pattern image for extraction
                    {
                        HOperatorSet.GenEmptyObj(out ho_Image);
                        HOperatorSet.ReadImage(out ho_Image, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image, out width, out height);
                        scale = (float)numericUpDownScale1.Value;
                        resetView(width, height, scale, hWindowControl1);
                        HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
                        tabControlPR.SelectedIndex = 0;
                    }
                    else  // pattern image
                    {
                        HOperatorSet.GenEmptyObj(out ho_Image_Pattern);
                        HOperatorSet.ReadImage(out ho_Image_Pattern, fn);
                        HTuple width, height;
                        HOperatorSet.GetImageSize(ho_Image_Pattern, out width, out height);
                        scale = (float) numericUpDownScale1.Value;
                        resetView(width, height, scale, hWindowControl1);
                        HOperatorSet.DispObj(ho_Image_Pattern, hWindowControl1.HalconWindow);
                        tabControlPR.SelectedIndex = 1;
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
                MessageBox.Show("Please load signal files into the corresponding directories");
                return;
            }
        }

        private void buttonROIUp_Click(object sender, EventArgs e)
        {
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.Width = (int)numericUpDownROIWidth.Value;
            PR_ROI.StartY = PR_ROI.StartY - (int)numericUpDownROIStep.Value;
            numericUpDownROIStartY.Value = PR_ROI.StartY;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonROIDown_Click(object sender, EventArgs e)
        {
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartY = PR_ROI.StartY + (int)numericUpDownROIStep.Value;
            numericUpDownROIStartY.Value = PR_ROI.StartY;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonROIRight_Click(object sender, EventArgs e)
        {
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            PR_ROI.StartX = PR_ROI.StartX + (int)numericUpDownROIStep.Value;
            numericUpDownROIStartX.Value = PR_ROI.StartX;
            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, PR_ROI.StartY, PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height, PR_ROI.StartX + PR_ROI.Width);
        }

        private void buttonROILeft_Click(object sender, EventArgs e)
        {
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
            
            HOperatorSet.GenRectangle1(out rect, (HTuple) PR_ROI.StartY, (HTuple) PR_ROI.StartX, PR_ROI.StartY + PR_ROI.Height,  PR_ROI.StartX + PR_ROI.Width);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_ImagePart1);
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
        }

        private void buttonSetPRPattern_Click(object sender, EventArgs e)
        {
            HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart1);  // to crop the image to the small boundary
            HOperatorSet.CreateNccModel(ho_ImagePart1, hv_ParameterValue[0], -0.39, 0.79, hv_ParameterValue[1], "use_polarity", out hv_ModelID);
            string Path = Application.StartupPath + @"\Img\Pattern\";
            string FN = Path + @"Pattern1.bmp";
            if(!Directory.Exists(Path)){
                Directory.CreateDirectory(Path);
            }
            HOperatorSet.WriteImage(ho_ImagePart1, "bmp", 0, FN);
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
            HTuple hv_Message = new HTuple();
            richTextBoxInfo.Clear();
            // 由程式評估NCC 的參數
            if (ho_Image_Pattern == null)
            {
                MessageBox.Show("Please load a pattern image first");
                return;
            }
            HOperatorSet.DetermineNccModelParams(ho_Image_Pattern, "auto", -0.39, 0.79, "use_polarity", "all", out hv_ParameterName, out hv_ParameterValue);
            hv_Message = "NCC model parameters:";
            richTextBoxInfo.AppendText(hv_Message.ToString() + "\n");
            int NoOfParameter = hv_ParameterName.Length;
            for (int i = 0; i < NoOfParameter; i++)
            {
                hv_Message[i + 1] = ((hv_ParameterName.TupleSelect(i) + ": ") + (hv_ParameterValue.TupleSelect(i)));
                richTextBoxInfo.AppendText("Parameter " + (i + 1).ToString() + ": " + hv_Message.TupleSelect(i + 1).ToString() + "\n");
            }
            // build ncc model
            HOperatorSet.CreateNccModel(ho_Image_Pattern, hv_ParameterValue[0], -0.39, 0.79, hv_ParameterValue[1], "use_polarity", out hv_ModelID);
            MessageBox.Show("NCC Model is learned");
        }

        private void buttonNCC_PR_Click(object sender, EventArgs e)
        {
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
            Tien_PR.PR_Param.AngleStart = (double) numericUpDownAngleStart.Value;
            Tien_PR.PR_Param.AngleExtent = (double)numericUpDownAngleExtent.Value;
            //Tien_PR.PR_Param.NumLevel = 0;  // using default
            if (checkBoxisSubPixel.Checked)
                Tien_PR.PR_Param.isSubpixel = "true";
            else
            {
                Tien_PR.PR_Param.isSubpixel = "false";
            }
            Tien_PR.PR_Param.MinScore = (double)numericUpDownMinScore.Value;
            Tien_PR.PR_Param.NumMatches = (int)numericUpDownNoOfMatches.Value;
            Tien_PR.PR_Param.OverlapRatio = (double)numericUpDownOverlapRatio.Value;

            // determine and create ncc model
            hv_ModelID = Tien_PR.PR_Learn();
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
            Tien_PR.PR_Param.AngleStart = (double)numericUpDownAngleStart.Value;
            Tien_PR.PR_Param.AngleExtent = (double)numericUpDownAngleExtent.Value;
            Tien_PR.PR_Param.MinScore = (double)numericUpDownMinScore.Value;
            Tien_PR.PR_Param.NumMatches = (int)numericUpDownNoOfMatches.Value;
            Tien_PR.PR_Param.OverlapRatio = (double)numericUpDownOverlapRatio.Value;
            if (checkBoxisSubPixel.Checked)
                Tien_PR.PR_Param.isSubpixel = "true";
            else
            {
                Tien_PR.PR_Param.isSubpixel = "false";
            }
            PR_Result Result = new PR_Result();
            //Tien_PR.PR_Result = Result;  // send to get result back (position and no of matches)
            //Tien_PR.PR_Param.NumLevel = 0;  // using default
            if (checkBoxisSubPixel.Checked)
                Tien_PR.PR_Param.isSubpixel = "true";
            else
            {
                Tien_PR.PR_Param.isSubpixel = "false";
            }

            // run PR matching
            Result = Tien_PR.PR_Matching();

            // display the result
           
             HObject ho_Rectangle2 = null;
             if (Result == null)
                 return;
             HOperatorSet.GenEmptyObj(out ho_Rectangle2);
             for (int i = 0; i < Result.NoOfMatch; i++)
            { // draw all the pattern with rectangles
                //richTextBoxInfo.AppendText("Center X: " + hv_Column.TupleSelect(i).ToString() + "Center Y: " + hv_Row.TupleSelect(i).ToString() + "Angle : " + hv_Angle.TupleSelect(i).ToString()+ "\n");
                HOperatorSet.DispCross(hWindowControl2.HalconWindow, Result.Row[i], Result.Column[i], 20.0, 0.0);
                HOperatorSet.GenRectangle2(out ho_Rectangle2, Result.Row[i], Result.Column[i], Result.Angle[i], Result.Width * 0.5, Result.Height*0.5);
                HOperatorSet.DispRectangle2(hWindowControl2.HalconWindow, Result.Row[i], Result.Column[i], Result.Angle[i], Result.Width * 0.5, Result.Height * 0.5);
            }
            ho_Rectangle2.Dispose();
        }

        private void numericUpDownROIStep_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownROIStartY.Increment = numericUpDownROIStep.Increment;
            numericUpDownROIStartX.Increment = numericUpDownROIStep.Increment;
            numericUpDownROIWidth.Increment = numericUpDownROIStep.Increment;
            numericUpDownROIHeight.Increment = numericUpDownROIStep.Increment; 
        }
    }
}
