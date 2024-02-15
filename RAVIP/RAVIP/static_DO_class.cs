using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.BDaq;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace TCP_IP_class
{
    class static_DO_class
    {
        public int state;
        private Automation.BDaq.InstantDoCtrl instantDoCtrl1 = new InstantDoCtrl();

        public static_DO_class()
       {
         instantDoCtrl1.SelectedDevice = new DeviceInformation(1);//找裝置
       
       }
    
     private void HandleError(ErrorCode err)
        {
            if (err != ErrorCode.Success)
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }
      public void Send_Signal_On(int PortNum, int bitNum) // Send output signal -- High to port 0 (1761 只有一個port), bitNum: 0~7 bit High: 1;
        {
            ErrorCode err = ErrorCode.Success;
            // 1. 決定Mask: 如第2 bit: 0010  然後做 or
            int Mask = (0x1 << bitNum); //如果是 bit 0010
            state = state | Mask;  // staet: 是global variable，儲存現在所有port 的狀態
            err = instantDoCtrl1.Write(0, (byte)state);  // write Port 0, state: 0010
            if (err != ErrorCode.Success)
            {
                HandleError(err);
            }
        }

      public void Send_Signal_Off(int PortNum, int bitNum) // Send output signal -- High to port 0 (1761 只有一個port), bitNum: 0~7 bit High: 1;
      {
          ErrorCode err = ErrorCode.Success;
          // 1. 決定Mask: 如第2 bit: 0010  然後做 or
          int Mask = ~(0x1 << bitNum); // 1101
          state = state & Mask;  // staet: 是global variable，儲存現在所有port 的狀態
          err = instantDoCtrl1.Write(0, (byte)state);  // write Port 0, state: 0010
          if (err != ErrorCode.Success)
          {
              HandleError(err);
          }
      }

      public void Turn_All_Off()
      {
          ErrorCode err = ErrorCode.Success;
          state = 0x00;
          err = instantDoCtrl1.Write(0, (byte)state);  // write Port 0, state: 0010
          if (err != ErrorCode.Success)
          {
              HandleError(err);
          }
      }

      public void Light_Control(int PortNum, int bitNum, int During)
      {
          Send_Signal_On(PortNum, bitNum);  // 1761 只有一個port, 所以是 0
          Thread.Sleep(During);
          Send_Signal_Off(PortNum, bitNum);
      }

    }
}
