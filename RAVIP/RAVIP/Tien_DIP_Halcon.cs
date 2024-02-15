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

       
        PR_NCC_Parameter m_PR_NCC_Param = new PR_NCC_Parameter();

        internal PR_NCC_Parameter PR_NCC_Param
        {
            get { return m_PR_NCC_Param; }
            set { m_PR_NCC_Param = value; }
        }
        HTuple m_hv_ModelID= null;

        public HTuple Hv_ModelID
        {
            get { return m_hv_ModelID; }
            set { m_hv_ModelID = value; }
        }
        //HTuple m_hv_ShapeModelID;

        //public HTuple Hv_ShapeModelID
        //{
        //    get { return m_hv_ShapeModelID; }
        //    set { m_hv_ShapeModelID = value; }
        //}

        private System.Windows.Forms.RichTextBox m_richTextBoxInfo;

        public System.Windows.Forms.RichTextBox RichTextBoxInfo
        {
            get { return m_richTextBoxInfo; }
            set { m_richTextBoxInfo = value; }
        }
        PR_NCC_Result m_PR_NCC_Result = null;// return result fo NCC

        public HTuple PR_NCC_Learn()
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
            HOperatorSet.DetermineNccModelParams(m_Pattern, m_PR_NCC_Param.NumLevel, m_PR_NCC_Param.AngleStart, m_PR_NCC_Param.AngleExtent, "use_polarity", "all", out hv_ParameterName, out hv_ParameterValue);
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
            HOperatorSet.CreateNccModel(m_Pattern, hv_ParameterValue[0], m_PR_NCC_Param.AngleStart, m_PR_NCC_Param.AngleExtent, hv_ParameterValue[1], "use_polarity", out m_hv_ModelID);
            //System.Windows.Forms.MessageBox.Show("NCC Model is learned");
            
            return m_hv_ModelID; // success
        }
        public PR_NCC_Result PR_NCC_Matching()
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
            m_PR_NCC_Result = new PR_NCC_Result();
            HOperatorSet.FindNccModel(m_Image_Testing, m_hv_ModelID, m_PR_NCC_Param.AngleStart, m_PR_NCC_Param.AngleExtent, m_PR_NCC_Param.MinScore, m_PR_NCC_Param.NumMatches, m_PR_NCC_Param.OverlapRatio, m_PR_NCC_Param.isSubpixel, m_PR_NCC_Param.NumLevel, out m_PR_NCC_Result.Row, out m_PR_NCC_Result.Column, out m_PR_NCC_Result.Angle, out m_PR_NCC_Result.Score);
            m_PR_NCC_Result.NoOfMatch = m_PR_NCC_Result.Row.Length;
            if (m_PR_NCC_Result.NoOfMatch == 0)
            {
                System.Windows.Forms.MessageBox.Show("No patterns is found!");
                return null;

            }
            HOperatorSet.DispObj(m_Image_Testing, m_hWindowControl.HalconWindow);  // display the image again
            HOperatorSet.SetColor(m_hWindowControl.HalconWindow, "red");
            
            
            //HTuple width, height;
            HOperatorSet.GetImageSize(m_Pattern, out m_PR_NCC_Result.Width, out m_PR_NCC_Result.Height);
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
            return m_PR_NCC_Result; // success;
        }
         public HTuple Learn_Shape_Model(PR_Shape_Parameter Param)
         {
             if (Param.Pattern == null)
            {
                System.Windows.Forms.MessageBox.Show("Please load the pattern first");
                return 0;
            }
            HObject ho_ShapeModelRegions, ho_ShapeModelImages, ho_ShapeModel;
            HTuple hv_AreaModelRegions = null, hv_RowModelRegions = null;
            HTuple hv_ColumnModelRegions = null, hv_HeightPyramid = null;  // no of pyraid derived by inspect
            HTuple hv_i = null, hv_NumLevels = new HTuple();
            HTuple m_hv_ShapeModelID = new HTuple();
            
            HOperatorSet.GenEmptyObj(out ho_ShapeModelImages);
            HOperatorSet.GenEmptyObj(out ho_ShapeModelRegions);
            HOperatorSet.GenEmptyObj(out ho_ShapeModel);

            HOperatorSet.InspectShapeModel(Param.Pattern, out ho_ShapeModelImages, out ho_ShapeModelRegions, 8, 30);  // try to get a good model for shapefinder
            
            HOperatorSet.SetColor(m_hWindowControl.HalconWindow, "green");
            HOperatorSet.DispObj(ho_ShapeModelRegions, m_hWindowControl.HalconWindow);
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
            //HTuple AngelStart = (new HTuple(0)).TupleRad(); // Transform to Radius
            //HTuple AngelExtent = (new HTuple(360)).TupleRad();
            HTuple Contrast = 30;  // threshold to derive features, or use "auto"
            HTuple MinConstrat = 10;  // or use "auto"
            HOperatorSet.CreateShapeModel(Param.Pattern, hv_NumLevels, Param.AngleStart, Param.AngleExtent, "auto", "none", "use_polarity", "auto", "auto", out m_hv_ShapeModelID);
            m_richTextBoxInfo.AppendText("Shape Model ID: " + m_hv_ShapeModelID.ToString());
            ho_ShapeModel.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ShapeModel, m_hv_ShapeModelID, 1);  // 只會show 出1/4的Contour pattern，因為中心點在pattern的中心點
            //HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
            //HOperatorSet.DispObj(ho_ShapeModel, hWindowControl1.HalconWindow);
            if (m_hv_ShapeModelID != null){
                //System.Windows.Forms.MessageBox.Show("Shape Model is learned");
                return m_hv_ShapeModelID;
            }else{
                return null;
            }
        }
         public PR_Shape_Result PR_Shape_Finder(PR_Shape_Parameter Param)
         {
             PR_Shape_Result Result= new PR_Shape_Result();
             if (Param.TestingImage == null)
             {
                 System.Windows.Forms.MessageBox.Show("Please load testing image from grid");
                 return null;
             }
             if (Param.ShapeModelID == null)
             {
                 System.Windows.Forms.MessageBox.Show("Please learn the shape first");
                 return null;
             }
             // source image: ho_Image_test
             // pattern image: ho_Image_pattern
             HTuple AngelStart = Param.AngleStart ; //(new HTuple(0)).TupleRad(); // Transform to Radius
             HTuple AngelExtent = Param.AngleExtent; // (new HTuple(360)).TupleRad();
             HTuple Contrast = 30; //Param.Contrast;//  // threshold to derive features, or use "auto"
             HTuple MinConstrat = 10; // Param.MinContrast; //10;  // or use "auto"
             HTuple MinScore = Param.MinScore; //0.7;
             HTuple NoOfMatch = Param.NumMatches; // 1; // 0; // all possible match
             HTuple MaxOverlap = Param.OverlapRatio ;//0.5;
             HTuple NumLevels = Param.NumLevel;// 0; // default
             HTuple Greediness = Param.Greediness; // 0.7;
             HTuple hv_RowCheck = new HTuple(), hv_ColumnCheck = new HTuple(), hv_AngleCheck = new HTuple(), hv_Score = new HTuple(); // to store the found row, col, and anlge, score;
             HTuple SubPixel = Param.Subpixel;//"least_squares";// least_squares"
             // subpixel: //none', 'interpolation', 'least_squares', 'least_squares_high', 'least_squares_very_high', 'max_deformation 1',
             //          'max_deformation 2', 'max_deformation 3', 'max_deformation 4', 'max_deformation 5', 'max_deformation 6' 
             // about greediness; The parameter Greediness determines how “greedily” the search should be carried out. If Greediness=0, 
             //                    a safe search heuristic is used, which always finds the model if it is visible in the image. 
             //                    However, the search will be relatively time consuming in this case. If Greediness=1, an unsafe search heuristic is used, 
             //                    which may cause the model not to be found in rare cases, even though it is visible in the image. 
             //                    For Greediness=1, the maximum search speed is achieved. In almost all cases, the shape model will always be found for Greediness=0.9. 
             HOperatorSet.FindShapeModel(Param.TestingImage, Param.ShapeModelID, AngelStart, AngelExtent, MinScore, NoOfMatch, MaxOverlap, SubPixel, NumLevels, Greediness,
                 out hv_RowCheck, out hv_ColumnCheck, out hv_AngleCheck, out hv_Score);
             int NoOfFound = hv_Score.Length;
             if (NoOfFound == 0)
             {
                 //System.Windows.Forms.MessageBox.Show("No match is found");
                 return null;
             }
             Result.NoOfMatch = hv_RowCheck.Length;
             Result.Column = hv_ColumnCheck;
             Result.Row = hv_RowCheck;
             Result.Angle = hv_AngleCheck;
             Result.Score = hv_Score;
             
             // display the found pattern

             HOperatorSet.SetColor(m_hWindowControl.HalconWindow, "yellow");
             HTuple hv_MovementOfObject = new HTuple();  // Homogenous 2d Matrix: 旋轉矩陣
             HObject ho_ModelAtNewPosition = new HObject();
             HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowCheck, hv_ColumnCheck, hv_AngleCheck, out hv_MovementOfObject);
             ho_ModelAtNewPosition.Dispose();
             HObject ho_ShapeModel=null;
             HOperatorSet.GenEmptyObj(out ho_ShapeModel);
             ho_ShapeModel.Dispose();
             HOperatorSet.GetShapeModelContours(out ho_ShapeModel, Param.ShapeModelID, 1); 
             HOperatorSet.AffineTransContourXld(ho_ShapeModel, out ho_ModelAtNewPosition, hv_MovementOfObject); // 旋轉 ho_ShapeModel，此object 只是用來繪圖使用
             //HOperatorSet.DispObj(Param.TestingImage, m_hWindowControl.HalconWindow);
             //HOperatorSet.DispObj(ho_ModelAtNewPosition, m_hWindowControl.HalconWindow);
             return Result;
         }
    }
    class PR_NCC_Parameter
    {
        public double AngleStart = -0.39; //angle.rad 
        public double AngleExtent = 0.78; //angle.rad
        public double MinScore = 0.5;
        public int NumMatches = 0; // all possible matches
        public double OverlapRatio = 0.5;
        public string isSubpixel ="true";
        public int NumLevel = 0;
    }
    class PR_Shape_Parameter
    {
        public HObject Pattern;
        public HObject TestingImage;
        public HTuple AngleStart = 0; //angle.rad 
        public HTuple AngleExtent = 360; //angle.rad
        public HTuple AngleStep = "auto";
        public HTuple MinScore = 0.05;
        public HTuple NumMatches = 0; // all possible matches
        public HTuple OverlapRatio = 0.5;
        public HTuple Subpixel = "least_squares";
        public HTuple NumLevel = 0;
        public HTuple Contrast= "auto";
        public HTuple MinContrast = "auto";
        public HTuple Greediness = 0.7; // 0.9 then must find, 1 fastest
        public HTuple ShapeModelID = null;  //
        public HTuple Optimization = "none";
    }
    public class PR_NCC_Result
    {
        public int NoOfMatch;
        public HTuple Row;  // matching result matrix: Y
        public HTuple Column ; // matching result matrix: X
        public HTuple Angle ; // Angle of matched instance
        public HTuple Width;
        public HTuple Height;
        public HTuple Score ; // Score of matched instance

    }
    public class PR_Shape_Result
    {
        public int NoOfMatch;
        public HTuple Row;  // matching result matrix: Y
        public HTuple Column ; // matching result matrix: X
        public HTuple Angle ; // Angle of matched instance
        public HTuple Score ; // Score of matched instance
        public HObject Shape_Representative; // for drawing only
    }
   
}
