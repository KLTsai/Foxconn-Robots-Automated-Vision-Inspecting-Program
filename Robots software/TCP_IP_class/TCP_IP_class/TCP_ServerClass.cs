using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Tien_Function;
using PixeLinkU3_Acquisition;
using HalconDotNet;
using PixeLinkU3;
using System.Globalization;
using RAVIP;
using PR;


namespace TCP_IP_class
{
    class TCP_ServerClass
    {
        
        public  FormPixeLinkU3HalconAcquisition R2_Cam_form = new FormPixeLinkU3HalconAcquisition();
        public FormSF SF_Form = new FormSF();
        static_DO_class IO = new static_DO_class();
        Robot_Control test = new Robot_Control();
        
        //儲存影像 委派設置
        public delegate HObject DelegateImage(string CanbeGotname, string CanbeGottype);
        public DelegateImage DelegateObj;

        //AutoFocus 委派設置
        public delegate bool DelegateAutoFocus(bool CanbeUse);
        public DelegateAutoFocus DelegateBool;

        //ManualFocus 委派設置
        public delegate void DelegateManual(int SetValue);
        public DelegateManual DelegateValue;
       
       // GrabImage 委派設置
        public delegate HObject DelegateGrab();
        public DelegateGrab Delegategrab_Image;
      
        // ImageProcess 委派設置
        public delegate void DelegateDIP(int Setindex);
        public DelegateDIP DelegateImg_Process;

        //公用變數宣告
        public TcpListener Server;//伺服端網路監聽器(相當於電話總機)
        public Socket[] Client = new Socket[5] { null, null, null, null, null };//給客戶用的連線物件(相當於電話分機)
        public bool[] Connect_state;
        public string[] _ClientData;
        public string[] Only_forR2;//只有給R2專門空間收資料
        public int[] manual_num;
        public int NumOfClient = 0;
        public IPAddress localAddr;
        public string Real_IP;
        public HObject TCP_Image = null;
        public TextBox Use_Name = new TextBox();
        public ComboBox Use_Type = new ComboBox();
       
        public Thread DIP_Act;
        public double X;
        public double Y;
        public int C;//收取哪一台PC當作client
        List<HObject> Grab_temp = new List<HObject>();

        public TCP_ServerClass(int focus_num_1, int focus_num_2, int focus_num_3, int focus_num_4, int focus_num_5, int focus_num_6, int focus_num_7, int focus_num_8, int focus_num_9, int focus_num_10)
        {
            _ClientData = new string[5] { "", "", "", "", "" };
            Only_forR2 = new string[5] { "", "", "", "", "" };
            Connect_state = new bool[5] { false, false, false, false, false };
            manual_num = new int[10] { focus_num_1, focus_num_2, focus_num_3, focus_num_4, focus_num_5, focus_num_6, focus_num_7, focus_num_8, focus_num_9, focus_num_10 };
            DelegateObj = new DelegateImage(R2_Cam_form.TogetImage);//委派建構子
            DelegateBool = new DelegateAutoFocus(R2_Cam_form.ToUseAutoFocus);
            DelegateValue = new DelegateManual(R2_Cam_form.Maunal_Focus);
            Delegategrab_Image = new DelegateGrab(R2_Cam_form.Tograb);
            DelegateImg_Process = new DelegateDIP(SF_Form.Testing_Process);
            CSystemPara.sp_RAVIPForm = R2_Cam_form;
            CSystemPara.sp_ShapeFinderForm = SF_Form;
        }
        public void ServerInitial(int port_num)
        {
            //Server IP 和 Port
            localAddr = IPAddress.Any;
            IPEndPoint EP = new IPEndPoint(localAddr, port_num);
            Server = new TcpListener(EP);
            Server.Start(5);
        }
        public int Server_WaitClient()
        {
            NumOfClient = check_TorF(ref Connect_state);//判斷哪些位置是未被占據

            Client[NumOfClient] = Server.AcceptSocket();//等待直到client進來 才會往下執行
            Connect_state[NumOfClient] = true;

            Real_IP = delimit_char(Client[NumOfClient].RemoteEndPoint.ToString(), ':')[0];
            return NumOfClient;
            //NumOfClient++;
            //Th_Clent = new Thread(new ParameterizedThreadStart(Server_Receive_Sub));//建立監聽這個Client連線的獨立執行緒  ---可能會有多個
            //Th_Clent.IsBackground = true;
            //Th_Clent.Start(NumOfClient);
            //Thread.Sleep(1);
        }

        //public void Server_Receive_Sub(object Num )
        public bool Server_Receive_Sub(int Num)
        {
            try
            {
                byte[] testRecByte = new byte[1];

                if (Client[Num].Available > 0)
                {
                    Byte[] Byte = new Byte[5120];//資料用陣列
                    int byterec = Client[Num].Receive(Byte);//接收網路資訊(Byte陣列)
                    string Msg = System.Text.Encoding.Default.GetString(Byte, 0, byterec);
                    if (Msg != "Stop")
                    {
                        Only_forR2[Num] = Msg;

                        _ClientData[Num] = Msg;
                    }
                    else
                        _ClientData[Num] = Msg;
                    
                    
                    return true;
                }

                if (Client[Num].Poll(0, SelectMode.SelectRead))
                {
                    Connect_state[Num] = false;
                    return false;
                }
                else
                   return false;
                 
                   
                
                /*  while (Client[Num].Connected)
               {

                   if (Client[Num].Available == 0)
                   {
                       //使用Peek，測試client是否還有連線
                       if (Client[Num].Receive(testRecByte, SocketFlags.Peek) == 0)

                           break;


                       Thread.Sleep(20);

                       continue;

                   }

               }*/
                //使用Peek測試連線是否仍存在
                /* if (Client[Num].Connected && Client[Num].Poll(0, SelectMode.SelectRead))
                 {
                     Connect_state[Num] = Client[Num].Receive(testRecByte, SocketFlags.Peek) == 0;

                 }*/
            }
            catch (Exception)
            {

                return false;
            }
        }
        private int check_TorF(ref bool[] array)
        {
            int To_use = 0;
            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] == true)
                {
                    // Show_Message_inform("不可用空間index :" + i + "\n", richTextBox1);
                }
                else if (array[i] == false)
                {

                    // Show_Message_inform("可用空間index :" + i + "\n", richTextBox1);
                    To_use = i;
                    return i;
                }
            }
            return To_use;
        }
        private string[] delimit_char(string str, char sign)
        {
            string[] word = str.Split(sign);
            return word;
        }

        private void SendMsg(int whichClient, string dataMsg)
        {
            if (whichClient <= 0)
                return;
            try
            {
                whichClient = whichClient - 1;
                if (Client[whichClient] != null)
                {
                    //NetworkStream stream = Client[whichClient].GetStream();
                    byte[] msg = Encoding.ASCII.GetBytes(dataMsg);
                    //stream.Write(msg, 0, msg.Length);
                    Client[whichClient].Send(msg);
                }
            }
            catch (Exception e)
            {
                // rtb_ExeMsg.AppendText("例外訊息SendMsg : " + e.Message);
                MessageBox.Show("例外訊息SendMsg : " + e.Message);
            }

        }/////////////// end SendMsg
        public void Send_To_Robot(string Port_Code)
        {
            string[] Obj = delimit_char(Port_Code, ':'); //分辨 給哪台robot ---> Obj[0] = R1 , Obj[1] = 外部速度 , Obj[2]=port code
 
            if (Obj[0] == "R1")
            {
                SendMsg(1, "S,8A," + Obj[1] + ",E");
                //Thread.Sleep(1);
                SendMsg(1, Obj[2]);
            
            }
            else if (Obj[0] == "R2")
            {
                SendMsg(2, "S,8A," + Obj[1] + ",E");
                //Thread.Sleep(1);
                SendMsg(2, Obj[2]);
            }
        }
        public void Send_to_getpos(string num, string Port_code)
        {
            if (num == "one")
                SendMsg(1, Port_code);
            else if (num == "two")
                SendMsg(2, Port_code);
        }
        public void Recive_SuckPose()  //取得中心點
        {   
          
            string[] spilt;
            for (int i = 2; i < 5; i++)
            {

                if (Connect_state[i])//確認另一台PC為幾號
                    C = i;
            }
               
                string[] point = delimit_char(_ClientData[C], ' ');//取得型式→x:~ y:~
                for (int j = 0; j < point.Length; j++)
                {
                    spilt = delimit_char(point[j], ':');

                    if (j == 0)
                        X = Convert.ToDouble(spilt[1]);
                    else if (j == 1)
                        Y = Convert.ToDouble(spilt[1]);
                }
            
            X = X - 455.482;
            Y = Y - (-7.949);

            if (Y > 650) //確保在該範圍值
                Y = 641.633;
        }

        public void getpath(Robot_Control data)
        {

           test.robot_path = data.robot_path;
              

        }

      

        public void Robot_Act()
        {

           //Path_no_initial();
            /*  test.robot_path = new string[10];
             test.robot_path[0] = "S,1A,-2.154,-39.736,115.019,0.010,-75.852,-53.271,E";
             test.robot_path[1] = "S,1A,-2.084,-39.678,114.759,-0.250,15.474,-53.177,E";
             test.robot_path[2] = "S,1A,-2.084,-39.682,114.774,-0.250,15.463,-143.285,E";
             test.robot_path[3] = "S,1A,-2.084,-39.682,114.774,-0.25,-73.485,-143.286,E";
            test.robot_path[4] ="S,1A,-2.084,-40.450,118.284,-0.271,-79.391,-143.289,E";
             test.robot_path[5] ="S,1A,-2.000,-40.450,118.284,-1,-79.391,38.99,E";
           test.robot_path[6] ="S,1A,-62.088,-40.446,118.275,0.266,-79.391,-143.289,E";
            test.robot_path[7] ="S,2A,0,-307.725,0,E";
            test.robot_path[8] = "S,1A,-78.829,-9.482,101.466,-0.297,84.245,-126.611,E";
             test.robot_path[9] ="S,1A,-0.956,-11.471,81.717,-0.019,108.636,-5";
            */
           Recive_SuckPose();
            // for (int act = 0; act < 5; act++)
            if (X!=0 && Y!=0)
            {
                while (X != 0 && Y != 0)
                {
                    Grab_temp.Clear();
                    if (Grab_temp.Count != 0 && Grab_temp != null)
                        MessageBox.Show("Having Problem");

                    R1_suck("R1:30:S,2A," + X + "," + Y + ",0,E");//前進指定位置
                    IO.Send_Signal_On(0, 1);
                    //位置歸零
                    X = 0;
                    Y = 0;
                    for (int i = 0; i < test.robot_path.Length; i++)
                    {
                      
                        if (i <= 4)
                            R1_pick(i);
                        else if (i > 4 && i <= 25)//檢測第一面
                        {
                           
                            if (i == 5)
                                 manual_focus(manual_num[0]);//1
                             else if (i == 13)
                                 manual_focus(manual_num[1]);//2
                             else if (i == 16)
                                 manual_focus(manual_num[2]);
                             else if (i == 20)
                                 manual_focus(manual_num[3]);
                            
                         
                            R2_inspect(i);

                            if (i != 25)
                                ONandOFF();
                                       
                        }
                        else if (i == 26)
                        {
                            R1_pick(i);//轉向
                        }
                        else if (i > 26 && i <= 28)//檢測第二面
                        {
                            R2_inspect(i);
                            if (i == 27)
                                manual_focus(manual_num[4]);//3
                           

                            ONandOFF();
                         
                        }
                        else if (i == 29)//轉向
                        {
                            R1_pick(i);
                        }
                        else if (i > 29 && i <= 35) //檢測第三面
                        {
                            
                            if (i == 30)
                                manual_focus(manual_num[5]);//3
                           // else if(i==33)  // 早上? 晚上?
                                //manual_focus(manual_num[6]);//4
                                                     
                            
                            R2_inspect(i);
                          
                            ONandOFF();
                           
                        }
                        else if (i == 36)//轉向
                        {
                            R1_pick(i);
                        }
                        else if (i > 36 && i <= 40) //檢測第四面
                        {
                            if (i == 37)
                                manual_focus(manual_num[6]);

                            R2_inspect(i);

                            if (i != 40)
                                ONandOFF();
                        }
                        else if (i > 40 && i <= 54)//放置區
                        {
                            R1_pick(i);
                            if (i == 44)//關吸盤
                                IO.Send_Signal_Off(0, 1);
                            if (i == 49)
                                IO.Send_Signal_On(0, 1);

                        }

                        else if (i > 54 && i <= 72)//檢測第五面
                        {
                            

                            if (i == 55)
                                manual_focus(manual_num[7]);//6
                            else if (i == 69)
                                manual_focus(manual_num[9]);//7

                            R2_inspect(i);

                            if (i != 72)
                                ONandOFF();
                        }
                        else if (i > 72 && i <= 80)
                        {
                            R1_pick(i);
                            if (i == 79)
                                IO.Send_Signal_Off(0, 1);
                        }
                    }

                    CSystemPara.image_index = 1;

                   Recive_SuckPose();
                }
            }
           
        }
        public void Path_no_initial()
        { 
         Recive_SuckPose();
            // for (int act = 0; act < 5; act++)
            if (X!=0 && Y!=0)
            {
                while (X != 0 && Y != 0)
                {
                    R1_suck("R1:30:S,2A," + X + "," + Y + ",0,E");//前進指定位置
                    IO.Send_Signal_On(0, 1);
                    //位置歸零
                    X = 0;
                    Y = 0;
                    for (int i = 0; i < test.robot_path.Length; i++)
                    {
                        if (i <= 6)
                        {
                           // if (i == 1)
                              //  IO.Send_Signal_On(0, 1);
                            R1_pick(i);//---------------------1
                              // if (i == 0)
                            // IO.Send_Signal_On(0, 1);
                        }
                        else if (i > 6 && i <= 12)//檢測第一面
                        {

                            if (i != 8)
                                R2_inspect(i);

                            if (i == 7)
                                manual_focus(manual_num[0]);//1
                            else if (i == 8)
                                R1_pick(i);
                            else if (i == 9)
                                manual_focus(manual_num[1]);//2

                            if (i != 8)
                                ONandOFF();
                        }
                        else if (i == 13)
                        {
                            R1_pick(i);//轉向
                        }
                        else if (i > 13 && i <= 18)//檢測第二面
                        {
                            R2_inspect(i);
                            if (i == 14)
                                manual_focus(manual_num[2]);//3
                            else if (i == 15)
                                manual_focus(manual_num[3]);//4

                            ONandOFF();
                        }
                        else if (i == 19)//轉向
                        {
                            R1_pick(i);
                        }
                        else if (i > 19 && i <= 24) //檢測第三面
                        {

                            R2_inspect(i);
                            if (i == 20)
                                manual_focus(manual_num[2]);//3
                            else if (i == 21)
                                manual_focus(manual_num[3]);//4

                            ONandOFF();
                        }
                        else if (i == 25)//轉向
                        {
                            R1_pick(i);
                        }
                        else if (i > 25 && i <= 30) //檢測第四面
                        {
                            if (i != 27)
                                R2_inspect(i);

                            if (i == 26)
                                manual_focus(manual_num[2]);//3
                            else if (i == 27)
                                R1_pick(i);
                            else if (i == 28)
                                manual_focus(manual_num[4]);//5

                            if (i != 27)
                                ONandOFF();
                        }
                        else if (i > 30 && i <= 44)//放置區
                        {
                            R1_pick(i);
                            if (i == 34)//關吸盤
                                IO.Send_Signal_Off(0, 1);
                            if (i == 39)
                                IO.Send_Signal_On(0, 1);

                        }

                        else if (i > 44 && i <= 49)//檢測第五面
                        {
                            R2_inspect(i);

                            if (i == 45)
                                manual_focus(manual_num[5]);//6
                            else if (i == 46)
                                manual_focus(manual_num[6]);//7

                            ONandOFF();
                        }
                        else if (i > 49 && i <= 57)
                        {
                            R1_pick(i);
                            if (i == 56)
                                IO.Send_Signal_Off(0, 1);
                        }
                        else if (i == 58)
                            R2_inspect(i);

                    }
                    CSystemPara.image_index = 1;

                    Recive_SuckPose();
                }
            }
        
        }  //for新機構設計
        public void R1_suck(string pos)
        {
            Send_To_Robot(pos);

            CSystemPara.sp_bCanSend = false;

            while (!CSystemPara.sp_bCanSend)
            {
                Thread.Sleep(1);//430
            }

        
        }
        public void R1_pick(int index)
        {
            Send_To_Robot(test.robot_path[index]);

            CSystemPara.sp_bCanSend = false;

            while (!CSystemPara.sp_bCanSend)
            {
                Thread.Sleep(1);//430
            }

            //IO.Send_Signal_On(0, 1); // 開啟吸盤
        }
        public void R2_inspect(int index)
        {

            Send_To_Robot(test.robot_path[index]);
            CSystemPara.sp_bCanSend = false;
            // IO.Send_Signal_Off(0, 0);
            while (!CSystemPara.sp_bCanSend)
            {
                Thread.Sleep(1);//430
                
            }

        }


        public void ONandOFF()
        {
            HiPerfTimer tspend = new HiPerfTimer();
            //string casefile = Use_Name.Text + count.ToString() + Use_Type.Text;
            IO.Send_Signal_On(0, 0);
            tspend.Start();
            //save_Image(CSystemPara.sp_filename, CSystemPara.sp_filetype);
            grab_Image();
            tspend.Stop();
            CSystemPara.time = tspend.Duration.ToString("F3", CultureInfo.InvariantCulture) + " ms";
            DIP_Act = new Thread(Image_Shake_Finder);
            DIP_Act.Start();
            DIP_Act.IsBackground = true;
            IO.Send_Signal_Off(0, 0);
            CSystemPara.image_index++;
        }
        public void show()
        {
            R2_Cam_form.Show();
        }

        public void save_Image(string name, string type)//
        {
            DelegateObj.Invoke(name, type);
            
        }
        public void auto_focus()
        {
            DelegateBool.Invoke(true);
        }
        public void  grab_Image()
        {
          Grab_temp.Add(Delegategrab_Image.Invoke());
   
          CSystemPara.grab_count = Grab_temp.Count;  
        }
        public void manual_focus(int value)
        {
            DelegateValue.Invoke(value);
        }
        public void Image_Shake_Finder()
        {
            DelegateImg_Process.Invoke((int)(CSystemPara.image_index)-2);//??引數問題無解
            //Thread.Sleep(1);
        }

        
    }
}
