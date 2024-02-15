using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PixeLinkU3;
using HalconDotNet;
namespace TCP_IP_class
{
    static class CSystemPara
    {
        public static Form sp_RAVIPForm;//讓RAVIP專案呈現之form
        public static Form sp_ShapeFinderForm;//讓SF專案呈現之form
        public static HObject sp_HoImage;
        public static int grab_count;
        public static int image_index = 1;
        public static int sp_RobotPos;
        public static bool sp_bCanSend = true;
        public static bool sp_bChange = true;
        public static string sp_filename;
        public static string sp_filetype;
        public static int sp_which=0;//snap_shot index 

        public static string time; //計算時間變數

       
        /// <summary>
        /// Robot 位置與軸角度參數
        /// </summary>
        public struct Robot_Position_struct
        {
            public static double J1;
            public static double J2;
            public static double J3;
            public static double J4;
            public static double J5;
            public static double J6;
            public static double X;
            public static double Y;
            public static double Z;
            public static double RX;
            public static double RY;
            public static double RZ;
        }
        /// <summary>
        /// Robot2 位置與軸角度參數
        /// </summary>
        public struct Robot_Two_Position_struct
        {
            //Robot 2
            public static double J1;
            public static double J2;
            public static double J3;
            public static double J4;
            public static double J5;
            public static double J6;
            public static double X;
            public static double Y;
            public static double Z;
            public static double RX;
            public static double RY;
            public static double RZ;
            //

        }
        public struct Robot2_Monitor_Pose
        {
            public static double X;
            public static double Y;
            public static double Z;
            public static double RX;
            public static double RY;
            public static double RZ;
        
        }



    }
}
