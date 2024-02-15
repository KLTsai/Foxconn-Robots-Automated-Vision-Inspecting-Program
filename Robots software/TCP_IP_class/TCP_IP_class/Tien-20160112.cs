using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
//using Emgu.CV;
//using Emgu.Util;
//using Emgu.CV.Structure;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;
//using Emgu.CV.UI;


namespace Tien_Function
{
    
    public class CCD_Parameter
    {
        public int Exposure;
        public int FrameRate;
        public int Brightness;
        public int Hue;
        public int Saturation;
        public int Sharpness;
        public int Gamma;
        public int Gain;
        public bool External_Trigger;
    }
    public class ROI
    {
        public int StartX;
        public int StartY;
        public int Width;
        public int Height;
    }
    public class ShapeFinder_ROI
    {
        public int StartX;
        public int StartY;
        public int Width;
        public int Height;
    }
    public class HiPerfTimer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(
            out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(
            out long lpFrequency);

        private long startTime, stopTime;
        private long freq;

        private bool _bStarted;
        public bool m_bStarted
        {
            get { return _bStarted; }

        }
        private bool _bStoped;
        public bool m_bStoped
        {
            get { return _bStoped; }
        }
        // Constructor

        public HiPerfTimer()
        {
            startTime = 0;
            stopTime = 0;
            _bStarted = false;
            _bStoped = true;

            if (QueryPerformanceFrequency(out freq) == false)
            {
                // high-performance counter not supported

                throw new Win32Exception();
            }
        }

        // Start the timer

        public void Start()
        {
            // lets do the waiting threads there work

            Thread.Sleep(0);
            QueryPerformanceCounter(out startTime);
            _bStarted = true;
            _bStoped = false;
        }

        // Stop the timer

        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
            _bStarted = false;
            _bStoped = true;
        }

        // Returns the duration of the timer (in seconds)

        public double Duration
        {
            get
            {
                return (double)(stopTime - startTime) / (double)freq;
            }
        }
    }
    public class Tien
    {
        // data reading function
        
        public bool readtxtFromFile(List<String[]> data_total)
        {
            //int NoOfNode = 100; // max no of data in the each line
            
            OpenFileDialog txt = new OpenFileDialog(); // create a dialog dynamically
            txt.ShowDialog();
            try
            {
                StreamReader reader = new StreamReader(txt.FileName);  // open a data stream
                while (true)
                {
                    string line = reader.ReadLine(); // read in a line of text
                    if (line == null)
                        break;  // nothing, then break the loop
                    if (line.Length == 0) // 只有 enter 的一行需要跳過
                        continue;
                    if (line == "")
                        continue;  // skip the white return line
                    string[] block = line.Split(new char[] { ' ', '/', ',', '|', '\t' });  // split char

                    string[] data = new string[block.Length];  // save the length
                    for (int i = 0; i < block.Length; i++)
                    {
                        data[i] = block[i];
                    }
                    data_total.Add(data);

                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Data were not read in correctly!");//ex.ToString());
                return false;
            }
        }
        // data reading function
        public bool readtxtFromFile(List<String[]> data_total, string filename)
        {
            //int NoOfNode = 100; // max no of data in the each line
            //OpenFileDialog txt = new OpenFileDialog(); // create a dialog dynamically
            //txt.ShowDialog();
            try
            {
                StreamReader reader = new StreamReader(filename);  // open a data stream
                while (true)
                {
                    string line = reader.ReadLine(); // read in a line of text
                    
                    if (line == null)
                        break;  // nothing, then break the loop
                    if (line.Length == 0) // 只有 enter 的一行需要跳過
                        continue;
                    if (line == "")
                        continue;  // skip the white return line
                    
                    string[] block = line.Split(new char[] { ' ', '/', ',', '|', '\t' });  // split char

                    string[] data = new string[block.Length];  // save the length
                    for (int i = 0; i < block.Length; i++)
                    {
                        if (block[i] == "")
                            continue;  // skip the blank string
                        data[i] = block[i];
                    }
                    data_total.Add(data);

                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data were not read incorrectly: " + ex.ToString());
                return false;
            }
            
        }

        // data reading function: floating point data
        public void readtxtFromFile(float[][] DataSet)
        {
            int NoOfRow, NoOfColumn;
            //int NoOfNode = 100; // max no of data in the each line
            OpenFileDialog txt = new OpenFileDialog(); // create a dialog dynamically
            txt.ShowDialog();
            List<String[]> data_total = new List<string[]>();  // declare a string list to store data
            try
            {
                StreamReader reader = new StreamReader(txt.FileName);  // open a data stream


                while (true)
                {
                    string line = reader.ReadLine(); // read in a line of text
                    if (line == null)
                        break;  // nothing, then break the loop
                    if (line.Length == 0) // 只有 enter 的一行需要跳過
                        continue;
                    if (line == "")
                        continue;  // skip the white return line
                    string[] block = line.Split(new char[] { ' ', '/', ',', '|' });  // split char
                    NoOfColumn = block.Length;
                    string[] data = new string[block.Length];  // save the length
                    for (int i = 0; i < block.Length; i++)
                    {
                        data[i] = block[i];
                    }
                    data_total.Add(data);
                }
                NoOfRow = data_total.Count;
                //DataSet = new float[NoOfRow][NoOfColumn];
                //for (int i = 0; i < NoOfRow; i++)
                //{
                //    [] DataSet = new float [NoOfColumn];
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //  Using Emgu function, so temporarily marked off
        /*
        public bool saveTxtToFile(Matrix <float> data, string filename)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
                
                for (int i = 0; i < data.Rows; i++)
                {
                    string line = "";
                    for (int j = 0; j < data.Cols; j++)
                    {
                        if(j== data.Cols-1)
                            line = line + data[i, j].ToString();
                        else
                            line = line + data[i, j].ToString() + "\t";
                    }
                    if(i!=data.Rows-1)
                        line = line + "\n";
                    file.WriteLine(line);
                    Application.DoEvents();
                }
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing text to file fails!" + ex.Message);
                return false;
            }
        }*/
        public bool loadsvmmodel(ref string FN)
        {
            OpenFileDialog svmModeldialog = new OpenFileDialog(); // create a dialog dynamically
            svmModeldialog.InitialDirectory = Application.StartupPath+ @"\SVMModel\";
            try
            {
                svmModeldialog.ShowDialog();
                FN = svmModeldialog.FileName;
                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("SVM Load filename fails!" + ex.Message);
                FN="";
                return false;
            }
        }
       
        #region Screen_Circular_Out()  過濾圓外的雜訊: 參數: source image, dest image, CenterX, CenterY, radius,  填入之灰階直
        /*
        public void Screen_Circular_Out(Image<Gray, Byte> source, Image<Gray, Byte> dst, int CenterX, int CenterY, int Radius, byte Intensity)
        {
            for (int i = 0; i < source.Rows; i++)
            {
                for (int j = 0; j < source.Cols; j++)
                {
                    if ((i - CenterY) * (i - CenterY) + (j - CenterX) * (j - CenterX) - (Radius ) * (Radius ) > 0)
                    {
                        dst.Data[i, j, 0] = Intensity;
                    }
                    else
                    {
                        dst.Data[i, j, 0] = source.Data[i, j, 0];
                    }

                }
            }
        }*/
        #endregion 
        /*
        public double ImageArea(Image<Gray, Byte> cvImage)  // count black pixel
        {
            double Area = 0;
            for (int i = 0; i < cvImage.Rows; i++)
            {
                for (int j = 0; j < cvImage.Cols; j++)
                {
                    if (cvImage.Data[i, j, 0] == 0)  // black
                    {
                        Area++;
                    }

                }
            }
            return Area;
        }
        public double ImageArea(Image<Gray, Byte> cvImage, int Threshold)  // count pixel > Threshold
        {
            double Area = 0;
            for (int i = 0; i < cvImage.Rows; i++)
            {
                for (int j = 0; j < cvImage.Cols; j++)
                {
                    if (cvImage.Data[i, j, 0] < Threshold)  // black
                    {
                        Area++;
                    }

                }
            }
            return Area;
        }
        public double ImageGravityCenter(Image<Gray, Byte> cvImage, int Threshold, ref double GX, ref double GY)  // count pixel > Threshold
        {
            double Area = 0;
            double CenterX = 0;
            double CenterY = 0;
            double No=0;
            for (int i = 0; i < cvImage.Rows; i++)
            {
                for (int j = 0; j < cvImage.Cols; j++)
                {
                    if (cvImage.Data[i, j, 0] < Threshold)  // black
                    {
                        Area++;
                        CenterX = CenterX + j;
                        CenterY = CenterY + i;
                        No++;
                    }

                }
            }
            GX = CenterX/No;
            GY = CenterY/No;
            return Area;
        }

        public void Draw_Point_Cross(Image<Bgr, Byte> cvImage, Point Center, int size, int Line_Width, Bgr color)
        {
            Point start = new Point();
            Point second = new Point();

            start.X = Center.X - size;
            second.X = Center.X + size;
            start.Y = Center.Y;
            second.Y = Center.Y;
            LineSegment2D line = new LineSegment2D(start, second);
            cvImage.Draw(line, color, 2);

            start.X = Center.X;
            second.X = Center.X;
            start.Y = Center.Y - size;
            second.Y = Center.Y + size;

            line = new LineSegment2D(start, second);

            cvImage.Draw(line, color, Line_Width);
        }
        public void Load_Image(Image<Bgr, Byte> SrcImage, ImageBox imageBox)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.InitialDirectory = Application.StartupPath;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                //Load the Image
                SrcImage = new Image<Bgr, Byte>(OpenFile.FileName);
                imageBox.Image = SrcImage;
            }

        }
        public void Load_Image(Image<Gray, Byte> SrcImage, ImageBox imageBox)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.InitialDirectory = Application.StartupPath;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                //Load the Image
                SrcImage = new Image<Gray, Byte>(OpenFile.FileName);
                imageBox.Image = SrcImage;
            }

        }
        public void Load_Image(ref Image<Bgr, Byte> SrcImage, ImageBox imageBox)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.InitialDirectory = Application.StartupPath;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                //Load the Image
                SrcImage = new Image<Bgr, Byte>(OpenFile.FileName);
                imageBox.Image = SrcImage;
            }

        }
        public void Load_Image(ref Image<Gray, Byte> SrcImage, ImageBox imageBox)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.InitialDirectory = Application.StartupPath;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                //Load the Image
                SrcImage = new Image<Gray, Byte>(OpenFile.FileName);
                imageBox.Image = SrcImage;
            }

        }
        public void ColorToGrayConversion(Image<Bgr, Byte> ImgOriginal, ref Image<Gray, Byte> ImgGray)
        {
            ImgGray = new Image<Gray, Byte>(ImgOriginal.Size);  // declare the size of image
            for (int i = 0; i < ImgOriginal.Height; i++)
            {
                for (int j = 0; j < ImgOriginal.Width; j++)
                {
                    ImgGray.Data[i, j, 0] = (byte)(ImgOriginal.Data[i, j, 0] * 0.1140 + ImgOriginal.Data[i, j, 1] * 0.5870 + ImgOriginal.Data[i, j, 2] * 0.2989);
                }
            }

        }
        public void ColorToRGBConversion(Image<Bgr, Byte> ImgOriginal, ref Image<Gray, Byte> ImgR, ref Image<Gray, Byte> ImgG, ref Image<Gray, Byte> ImgB)
        {
            ImgR = new Image<Gray, Byte>(ImgOriginal.Size);
            ImgG = new Image<Gray, Byte>(ImgOriginal.Size);
            ImgB = new Image<Gray, Byte>(ImgOriginal.Size);
            for (int i = 0; i < ImgOriginal.Height; i++)
            {
                for (int j = 0; j < ImgOriginal.Width; j++)
                {
                    ImgB.Data[i, j, 0] = ImgOriginal.Data[i, j, 0];
                    ImgG.Data[i, j, 0] = ImgOriginal.Data[i, j, 1];
                    ImgR.Data[i, j, 0] = ImgOriginal.Data[i, j, 2];
                }
            }
        }*/
 
    }
}
