using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace TienDIP_Funciton_Using_Halcon
{
    class TienDIP_PR
    {
        HObject m_Pattern;

        public HObject Pattern
        {
            get { return m_Pattern; }
            set { m_Pattern = value; }
        }
        HObject m_Image_Testing;

        public HObject Image_Testing
        {
            get { return m_Image_Testing; }
            set { m_Image_Testing = value; }
        }
        HalconDotNet.HWindowControl m_hWindowControl;

        public HalconDotNet.HWindowControl HWindowControl
        {
            get { return m_hWindowControl; }
            set { m_hWindowControl = value; }
        }

       
        PR_Parameter m_PR_Param = new PR_Parameter();

        internal PR_Parameter PR_Param
        {
            get { return m_PR_Param; }
            set { m_PR_Param = value; }
        }
        HTuple m_hv_ModelID= null;

        public HTuple Hv_ModelID
        {
            get { return m_hv_ModelID; }
            set { m_hv_ModelID = value; }
        }
        private System.Windows.Forms.RichTextBox m_richTextBoxInfo;

        public System.Windows.Forms.RichTextBox RichTextBoxInfo
        {
            get { return m_richTextBoxInfo; }
            set { m_richTextBoxInfo = value; }
        }
        PR_Result m_PR_Result = null;

        //internal PR_Result PR_Result
        //{
        //    get { return m_PR_Result; }
        //    set { m_PR_Result = value; }
       // }

        public HTuple PR_Learn()
        {
            HTuple hv_Message = new HTuple();
            HTuple hv_ParameterName = new HTuple(), hv_ParameterValue = new HTuple();
            m_richTextBoxInfo.Clear();
            // 由程式評估NCC 的參數
            if (m_Pattern == null)
            {
                System.Windows.Forms.MessageBox.Show("Please load a pattern image first");
                return null;  // no pattern is loaded
            }
            // 決定 NCC 所使用之參數 (沒有scale?)
            HOperatorSet.DetermineNccModelParams(m_Pattern, m_PR_Param.NumLevel, m_PR_Param.AngleStart, m_PR_Param.AngleExtent, "use_polarity", "all", out hv_ParameterName, out hv_ParameterValue);
            // Show 參數到 richtextbox 上
            hv_Message = "NCC model parameters:";
            m_richTextBoxInfo.AppendText(hv_Message.ToString() + "\n");
            int NoOfParameter = hv_ParameterName.Length;
            for (int i = 0; i < NoOfParameter; i++)
            {
                hv_Message[i + 1] = ((hv_ParameterName.TupleSelect(i) + ": ") + (hv_ParameterValue.TupleSelect(i)));
                m_richTextBoxInfo.AppendText("Parameter " + (i + 1).ToString() + ": " + hv_Message.TupleSelect(i + 1).ToString() + "\n");
            }
            // build ncc model
            HOperatorSet.CreateNccModel(m_Pattern, hv_ParameterValue[0], m_PR_Param.AngleStart, m_PR_Param.AngleExtent, hv_ParameterValue[1], "use_polarity", out m_hv_ModelID);
            //System.Windows.Forms.MessageBox.Show("NCC Model is learned");
            
            return m_hv_ModelID; // success
        }
        public PR_Result PR_Matching()
        {
            //HTuple hv_Row = new HTuple(); // center of gravity of the domain (region) of the image that was used to create the NCC mode
           // HTuple hv_Column = new HTuple();
            //HTuple hv_Angle = new HTuple();
            //HTuple hv_Score = new HTuple();
            if (m_Image_Testing == null || m_hv_ModelID == null)
            {
                System.Windows.Forms.MessageBox.Show("NCC Model is learned or Image must be loaded");
                return null;
            }
            m_PR_Result = new PR_Result();
            HOperatorSet.FindNccModel(m_Image_Testing, m_hv_ModelID, m_PR_Param.AngleStart, m_PR_Param.AngleExtent, m_PR_Param.MinScore, m_PR_Param.NumMatches, m_PR_Param.OverlapRatio, m_PR_Param.isSubpixel, m_PR_Param.NumLevel, out m_PR_Result.Row, out m_PR_Result.Column, out m_PR_Result.Angle, out m_PR_Result.Score);
            m_PR_Result.NoOfMatch = m_PR_Result.Row.Length;
            if (m_PR_Result.NoOfMatch == 0)
            {
                System.Windows.Forms.MessageBox.Show("No patterns is found!");
                return null;

            }
            HOperatorSet.DispObj(m_Image_Testing, m_hWindowControl.HalconWindow);  // display the image again
            HOperatorSet.SetColor(m_hWindowControl.HalconWindow, "red");
            
            
            //HTuple width, height;
            HOperatorSet.GetImageSize(m_Pattern, out m_PR_Result.Width, out m_PR_Result.Height);
            /*
             * HObject ho_Rectangle2 = null;
             * HOperatorSet.GenEmptyObj(out ho_Rectangle2);
            for (int i = 0; i < m_PR_Result.NoOfMatch; i++)
            { // draw all the pattern with rectangles
                //richTextBoxInfo.AppendText("Center X: " + hv_Column.TupleSelect(i).ToString() + "Center Y: " + hv_Row.TupleSelect(i).ToString() + "Angle : " + hv_Angle.TupleSelect(i).ToString()+ "\n");
                HOperatorSet.DispCross(m_hWindowControl.HalconWindow, m_PR_Result.Row[i], m_PR_Result.Column[i], 20.0, 0.0);
                HOperatorSet.GenRectangle2(out ho_Rectangle2, m_PR_Result.Row[i], m_PR_Result.Column[i], m_PR_Result.Angle[i], width, height);
                HOperatorSet.DispRectangle2(m_hWindowControl.HalconWindow, m_PR_Result.Row[i], m_PR_Result.Column[i], m_PR_Result.Angle[i], width * 0.5, height * 0.5);
            }
            ho_Rectangle2.Dispose();*/
            return m_PR_Result; // success;
        }
    }
    class PR_Parameter
    {
        public double AngleStart = -0.39; //angle.rad 
        public double AngleExtent = 0.78; //angle.rad
        public double MinScore = 0.5;
        public int NumMatches = 0; // all possible matches
        public double OverlapRatio = 0.5;
        public string isSubpixel ="true";
        public int NumLevel = 0;
    }
    public class PR_Result
    {
        public int NoOfMatch;
        public HTuple Row;  // matching result matrix: Y
        public HTuple Column ; // matching result matrix: X
        public HTuple Angle ; // Angle of matched instance
        public HTuple Width;
        public HTuple Height;
        public HTuple Score ; // Score of matched instance

    }
}
