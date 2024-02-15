using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Automation.BDaq;

using System.Globalization;

namespace DI_StaticDI
{
   public partial class StaticDIForm : Form
   {
      #region 
      private Label[] m_portNum;
      private Label[] m_portHex;
      private PictureBox[,] m_pictrueBox;
      private const int m_startPort = 0;
      private const int m_portCountShow = 4;
      #endregion

      public StaticDIForm()
      {
          InitializeComponent();
      }

      public StaticDIForm(int deviceNumber)
      {
         InitializeComponent();
         instantDiCtrl1.SelectedDevice = new DeviceInformation(deviceNumber);
      }
      
      private void InstantDiForm_Load(object sender, EventArgs e)
      {
         //The default device of project is demo device, users can choose other devices according to their needs. 
         if (!instantDiCtrl1.Initialized)
          {
             MessageBox.Show("No device be selected or device open failed!", "StaticDI");
              this.Close();
              return;
          }

          this.Text = "Static DI(" + instantDiCtrl1.SelectedDevice.Description + ")";

          m_portNum = new Label[m_portCountShow] { PortNum0, PortNum1, PortNum2, PortNum3 };
          m_portHex = new Label[m_portCountShow] { PortHex0, PortHex1, PortHex2, PortHex3 };
          m_pictrueBox = new PictureBox[m_portCountShow, 8]{
             {pictureBox00, pictureBox01, pictureBox02, pictureBox03, pictureBox04, pictureBox05,pictureBox06, pictureBox07},
             {pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,pictureBox16, pictureBox17},
             {pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25,pictureBox26, pictureBox27},
             {pictureBox30, pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35,pictureBox36, pictureBox37}
          };
          
          //enable the timer to read DI ports status
          timer1.Enabled = true;
      }

      private void timer1_Tick(object sender, EventArgs e)
       {
          // read Di port state
          byte portData = 0;
          ErrorCode err = ErrorCode.Success;

          for (int i = 0; (i + m_startPort) < instantDiCtrl1.Features.PortCount && i < m_portCountShow; ++i)
          {
             err = instantDiCtrl1.Read(i + m_startPort, out portData);
             if (err != ErrorCode.Success)
             {
                timer1.Enabled = false;
                HandleError(err);
                return;
             }

             m_portNum[i].Text = (i + m_startPort).ToString();
             m_portHex[i].Text = portData.ToString("X2");

             // Set picture box state
             for (int j = 0; j < 8; ++j)
             {
                m_pictrueBox[i,j].Image = imageList1.Images[(portData >> j) & 0x1];
                m_pictrueBox[i,j].Invalidate();
             }
          }
       }

      private void HandleError(ErrorCode err)
      {
         if (err != ErrorCode.Success)
         {
            MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString(), "Static DI");
         }
      }
   }
}