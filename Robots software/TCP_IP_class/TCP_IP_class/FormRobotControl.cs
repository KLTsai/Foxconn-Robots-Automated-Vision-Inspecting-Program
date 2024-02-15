using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using DO_StaticDO;



namespace TCP_IP_class
{
    public partial class FormRobotControl : Form
    {
        TCP_ServerClass Initial_TCP;
        static_DO_class IO_Control;
        StaticDOForm try_DO = new StaticDOForm();
        Thread Th_Server;
        Robot_Control act_step;//準備送出路徑 執行
        int No;
          
        string []IP_lastR= new string[5] ;//切出所需IP資料
        delegate void UIControl(string Msg, Control conl);
        delegate void Client_informUsing(string IP, DataGridView datagridview_tool, bool state, int Num);
        delegate void Button_Using(Button[] button_Robot1, Button[] button_Robot2);
        delegate void File_Using(TextBox UIname, ComboBox UItype);
        private TextBox[] txb_ControlsForJ = new TextBox[6];
        private TextBox[] txb_ControlsForVec = new TextBox[3];
        private TextBox[] txb_ControlsForJ_2 = new TextBox[6];
        private TextBox[] txb_ControlsForVec_2 = new TextBox[3];
        private TextBox[] txb_Planning_Control = new TextBox[6];
        private Button[] Btn_Robot1 = new Button[18];
        private Button[] Btn_Robot2 = new Button[18];
        private CheckBox[] ChBox_Vector = new CheckBox[2];
        string[,] last;//儲存路徑空間
        string[] Relative_C = new string[3];//相對位置座標陣列 
       
        bool robot_using = false;

        //private CSystemPara.Robot_Position_struct Robot_info = new CSystemPara.Robot_Position_struct();
     
        public FormRobotControl()
        {
            InitializeComponent();

            Initial_TCP = new TCP_ServerClass(27608, 29784, 29376, 29648, 26656, 28288, 26350,27064,27200 ,26792);
            Initial_TCP.Client = new Socket[5]{null,null,null,null,null};
            IO_Control = new static_DO_class();
            act_step=new Robot_Control();
      
            Relative_C[0] = "1";
            Relative_C[1] = "1";
            Relative_C[2] = "1";
            dataGridView1.ColumnCount = 9;//一開始初始
            dataGridView1.RowCount = 2; // 一開始初始

            //Robot1 Status
            txb_ControlsForJ[0] = textBox_J1;
            txb_ControlsForJ[1] = textBox_J2;
            txb_ControlsForJ[2] = textBox_J3;
            txb_ControlsForJ[3] = textBox_J4;
            txb_ControlsForJ[4] = textBox_J5;
            txb_ControlsForJ[5] = textBox_J6;

            txb_ControlsForVec[0] = textBox_X;
            txb_ControlsForVec[1] = textBox_Y;
            txb_ControlsForVec[2] = textBox_Z;
            //

            //Robot2 Status
            txb_ControlsForJ_2[0] = textBox_J1_Two;
            txb_ControlsForJ_2[1] = textBox_J2_Two;
            txb_ControlsForJ_2[2] = textBox_J3_Two;
            txb_ControlsForJ_2[3] = textBox_J4_Two;
            txb_ControlsForJ_2[4] = textBox_J5_Two;
            txb_ControlsForJ_2[5] = textBox_J6_Two;

            txb_ControlsForVec_2[0] = textBox_X_Two;
            txb_ControlsForVec_2[1] = textBox_Y_Two;
            txb_ControlsForVec_2[2] = textBox_Z_Two;
            //

            //Robot1 button 
            Btn_Robot1[0]=J1_minBtn;
            Btn_Robot1[1]=J1_addBtn;
            Btn_Robot1[2]=J2_minBtn;
            Btn_Robot1[3]=J2_addBtn;
            Btn_Robot1[4]=J3_minBtn;
            Btn_Robot1[5]=J3_addBtn;
            Btn_Robot1[6]=J4_minBtn;
            Btn_Robot1[7]=J4_addBtn;
            Btn_Robot1[8]=J5_minBtn;
            Btn_Robot1[9]=J5_addBtn;
            Btn_Robot1[10]=J6_minBtn;
            Btn_Robot1[11]=J6_addBtn;
            Btn_Robot1[12]=X_minBtn;
            Btn_Robot1[13]=X_addBtn;
            Btn_Robot1[14]=Y_minBtn;
            Btn_Robot1[15]=Y_addBtn;
            Btn_Robot1[16] = Z_minBtn;
            Btn_Robot1[17] = Z_addBtn;
            //

            //Robot2 button
            Btn_Robot2[0] = J1_minBtn_Two;
            Btn_Robot2[1] = J1_addBtn_Two;
            Btn_Robot2[2] = J2_minBtn_Two;
            Btn_Robot2[3] = J2_addBtn_Two;
            Btn_Robot2[4] = J3_minBtn_Two;
            Btn_Robot2[5] = J3_addBtn_Two;
            Btn_Robot2[6] = J4_minBtn_Two;
            Btn_Robot2[7] = J4_addBtn_Two;
            Btn_Robot2[8] = J5_minBtn_Two;
            Btn_Robot2[9] = J5_addBtn_Two;
            Btn_Robot2[10] = J6_minBtn_Two;
            Btn_Robot2[11] = J6_addBtn_Two;
            Btn_Robot2[12] = X_minBtn_Two;
            Btn_Robot2[13] = X_addBtn_Two;
            Btn_Robot2[14] = Y_minBtn_Two;
            Btn_Robot2[15] = Y_addBtn_Two;
            Btn_Robot2[16] = Z_minBtn_Two;
            Btn_Robot2[17] = Z_addBtn_Two;
            //
       
           //計算相對路徑的textbox連結
           txb_Planning_Control[0] = planning_X1;
           txb_Planning_Control[1] = planning_Y1;
           txb_Planning_Control[2] = planning_Z1;
           txb_Planning_Control[3] = planning_X0;
           txb_Planning_Control[4] = planning_Y0;
           txb_Planning_Control[5] = planning_Z0;
            //
        
           //UI checkbox connect
           ChBox_Vector[0] = checkBox1;
           ChBox_Vector[1] = checkBox2;
           //
        }

        private void connect_Btn_Click(object sender, EventArgs e)
        {
            Initial_TCP.ServerInitial(Convert.ToInt16(Port_num.Text));
            Th_Server = new Thread(Server_Sub);
            Th_Server.IsBackground = true;
            Th_Server.Start();
            UpdateUI_richtext("連線監聽中....." + "\n", richTextBox1);

            if (!timer1.Enabled)
            {
                Gridview_Info.Rows.Add(15); //注意些增加所需要的列  共15列
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
            //Thread Tt = new Thread(THD_Receive);
            //Tt.IsBackground = true;
            //Tt.Start();
        }

        private void Server_Sub()//開啟監聽
        {
            byte[] testRecByte = new byte[1];
            try
            {
                while (true)
                {
                    No = Initial_TCP.Server_WaitClient(); //等待Client端這瞬間，得到連上的index
                    show_Client_inform(Initial_TCP.Real_IP, Gridview_Info, true, No);//dataGrid UI呈現
                  

                }
                //show_Client_inform("", Gridview_Info, false, No);

            }
            catch { }
            
        
        }
       
        private void UpdateUI_richtext(string str, Control conl)
        {
            if (this.InvokeRequired)
            {
                UIControl ui = new UIControl(UpdateUI_richtext);
                this.Invoke(ui, str, conl);
            }

            else
            {
                richTextBox1.AppendText(str);
            }
        }
      /* private void THD_Receive()
        {
           
            while (true)
            {
                for (int i = 0; i < Initial_TCP.Client.Length; i++)
                {
                    if (Initial_TCP.Connect_state[i])
                    {
                        if (Initial_TCP.Server_Receive_Sub(i))
                        {
                            UpdateUI("第" + (i + 1).ToString() + "台:" + Initial_TCP._ClientData, richTextBox1);
                            //richTextBox1.AppendText("第" + (i + 1).ToString() + "台:" + Initial_TCP._ClientData);
                            //Initial_TCP._ClientData = "";
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }*/

        private string[] SplitWithChar(string str, char deli)
        {
            return str.Split(deli);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Client_index = Initial_TCP.Client.Length;
              

            for (int i = 0; i < Client_index; i++)
            {
               
                if (Initial_TCP.Connect_state[i])
                {
                    lock_controlbutton(Btn_Robot1, Btn_Robot2);
                    getfiletype(textBoxfilename, combofiletype);
                    if (Initial_TCP.Server_Receive_Sub(i))
                    {
                        richTextBox1.AppendText("第" + (i + 1).ToString() + "台:" + "\n");
                        richTextBox1.AppendText(Initial_TCP._ClientData[i] + "\n"+"\n");
                        richTextBox1.ScrollToCaret();//資料直接下最底層顯示
                        if (Initial_TCP._ClientData[i] != "Stop")
                        {

                            string[] str = SplitWithChar(Initial_TCP._ClientData[i], ','); //切出各軸數值
                            string[] str_last = SplitWithChar(IP_lastR[i], '.');//切出IP每一個位置
                            switch (str.Length)
                            {
                                case 6:  //Move 參數共有6組數值 J1~J6
                                    for (int j = 0; j < str.Length; j++)
                                    {
                                        string[] temp = SplitWithChar(str[j], '=');
                                        if (str_last[3] == "27")// IP last code of the Robot1
                                        {
                                          
                                            txb_ControlsForJ[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();    //給UI呈現(與textbox類別連結)
                                        } 
                                        if (str_last[3] == "6")// IP last code of the Robot2
                                            txb_ControlsForJ_2[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();
                                    }
                                    break;
                                case 3:  //Draw 參數共有3組數值 X Y Z
                                    for (int j = 0; j < str.Length; j++)
                                    {
                                        string[] temp = SplitWithChar(str[j], '=');
                                        if (str_last[3] == "27")
                                            txb_ControlsForVec[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();
                                        if (str_last[3] == "6")
                                        {
                                            txb_ControlsForVec_2[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();
                                            switch (j)// 取得R2監控位置直角座標 (取像用)
                                            {
                                                case 0:
                                                    CSystemPara.Robot2_Monitor_Pose.X = Math.Round(Convert.ToDouble(temp[1]), 3);
                                                    break;
                                                case 1:
                                                    CSystemPara.Robot2_Monitor_Pose.Y = Math.Round(Convert.ToDouble(temp[1]), 3);
                                                    break;
                                                case 2:
                                                    CSystemPara.Robot2_Monitor_Pose.Z = Math.Round(Convert.ToDouble(temp[1]), 3);
                                                    break;
                                            }
                                        }
                                     }
                                    break;
                            }
                            //renew_pos();
                        }
                        else
                        {
                            CSystemPara.sp_bCanSend = true;
                            Initial_TCP._ClientData[i] = "";
                        }
                        
                    }
                    
                }
                else
                {
                    show_Client_inform(Initial_TCP.Real_IP, Gridview_Info, false, i);
                }
               /* else if (for_sure_disconnect[i]==false ) 
                {
                    show_Client_inform(Initial_TCP.Real_IP, Gridview_Info, false, i);
                }*/
              
            }
            //No = Initial_TCP.NumOfClient ;
           //if (Initial_TCP.Client[Initial_TCP.NumOfClient].Available>0)
            /* if (Initial_TCP._ClientData[No] != "")
            {
                //richTextBox1.AppendText(Initial_TCP._ClientData[Initial_TCP.NumOfClient] + "\n");
                UpdateUI(Initial_TCP._ClientData[No] + "\n", richTextBox1);
                Initial_TCP._ClientData[No] = "";
               
            }*/

            /*if (Initial_TCP._ClientData != "")
            {
                //richTextBox1.AppendText(Initial_TCP._ClientData[Initial_TCP.NumOfClient] + "\n");
                UpdateUI(Initial_TCP._ClientData + No+ "\n", richTextBox1);
                Initial_TCP._ClientData = "";
            }*/
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

                if (Initial_TCP.Connect_state[1])
                {
                    lock_controlbutton(Btn_Robot1, Btn_Robot2);
                    getfiletype(textBoxfilename, combofiletype);
                    if (Initial_TCP.Server_Receive_Sub(1))
                    {
                        richTextBox1.AppendText("第" + (1 + 1).ToString() + "台 (only):" + "\n");
                        richTextBox1.AppendText(Initial_TCP.Only_forR2[1] + "  only"+"\n" + "\n");
                        richTextBox1.ScrollToCaret();//資料直接下最底層顯示
                        if (Initial_TCP.Only_forR2[1] != "Stop")
                        {

                            string[] str = SplitWithChar(Initial_TCP.Only_forR2[1], ','); //切出各軸數值
                            string[] str_last = SplitWithChar(IP_lastR[1], '.');//切出IP每一個位置
                            switch (str.Length)
                            {
                                case 6:  //Move 參數共有6組數值 J1~J6
                                    for (int j = 0; j < str.Length; j++)
                                    {
                                        string[] temp = SplitWithChar(str[j], '=');
                                        if (str_last[3] == "27")// IP last code of the Robot1
                                        {

                                            txb_ControlsForJ[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();    //給UI呈現(與textbox類別連結)
                                        }
                                        if (str_last[3] == "6")// IP last code of the Robot2
                                            txb_ControlsForJ_2[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();
                                    }
                                    break;
                                case 3:  //Draw 參數共有3組數值 X Y Z
                                    for (int j = 0; j < str.Length; j++)
                                    {
                                        string[] temp = SplitWithChar(str[j], '=');
                                        if (str_last[3] == "27")
                                            txb_ControlsForVec[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();
                                        if (str_last[3] == "6")
                                        {
                                            txb_ControlsForVec_2[j].Text = Math.Round(Convert.ToDouble(temp[1]), 3).ToString();
                                            switch (j)// 取得R2監控位置直角座標 (取像用)
                                            {
                                                case 0:
                                                    CSystemPara.Robot2_Monitor_Pose.X = Math.Round(Convert.ToDouble(temp[1]), 3);
                                                    break;
                                                case 1:
                                                    CSystemPara.Robot2_Monitor_Pose.Y = Math.Round(Convert.ToDouble(temp[1]), 3);
                                                    break;
                                                case 2:
                                                    CSystemPara.Robot2_Monitor_Pose.Z = Math.Round(Convert.ToDouble(temp[1]), 3);
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                            }
                            //renew_pos();
                       }
                        //else
                          //  Initial_TCP._ClientData[1] = "";
                    }

                }
        }
        
        private void lock_controlbutton(Button[] button_Robot1,Button[]button_Robot2)
        {
            if (this.InvokeRequired)
            {
                Button_Using button_using = new Button_Using(lock_controlbutton);
                this.Invoke(button_using, button_Robot1, button_Robot2);
            }
            else
            {
                if (robot_using == true)
                {
                    for (int i = 0; i < button_Robot1.Length; i++)
                        button_Robot1[i].Enabled = true;
                    for (int i = 0; i < button_Robot2.Length; i++)
                        button_Robot2[i].Enabled = true;

                    R1home_Btn.Enabled = true;
                    R2home_Btn.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < button_Robot1.Length; i++)
                        button_Robot1[i].Enabled = false;
                    for (int i = 0; i < button_Robot2.Length; i++)
                        button_Robot2[i].Enabled = false;
                    R1home_Btn.Enabled = false;
                    R2home_Btn.Enabled = false;
                }
            }
        }
        private void show_Client_inform(string IP, DataGridView datagridview_tool, bool state, int Num)
        {
            if (this.InvokeRequired)
            {
                Client_informUsing client_inform = new Client_informUsing(show_Client_inform);
                this.Invoke(client_inform, IP, datagridview_tool, state, Num);
            }
            else
            {
                //datagridview_tool.Rows.Add(1);
                //datagridview_tool.Rows[Num].Cells[0].Value = IP;
                if (state == true)
                {
                    datagridview_tool.Rows[Num].Cells[0].Value = IP;
                    datagridview_tool.Rows[Num].Cells[1].Value = "連線中....";
                    IP_lastR [Num]= Gridview_Info.Rows[Num].Cells[0].Value.ToString();
                    richTextBox1.AppendText(IP_lastR[Num]+ "***" + "\n");
                }
                else
                {
                  //datagridview_tool.Rows.RemoveAt(Num);
                    datagridview_tool.Rows[Num].Cells[1].Value = "斷線" + Num;
                }
            }
        }
        private void getfiletype(TextBox UIname, ComboBox UItype)
        {
            if (this.InvokeRequired)
            {
                File_Using file_using = new File_Using(getfiletype);
                this.Invoke(file_using, UIname, UItype);
            }
            else
            {
           
                string combine_name = UIname.Text + CSystemPara.image_index.ToString();
               CSystemPara.sp_filename = combine_name;

               CSystemPara.sp_filetype = UItype.Text;
            }
        }

        private void Send_Btn_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
          

            Initial_TCP.Send_To_Robot(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Thread T1 = new Thread(Initial_TCP.Robot_Act);
               
                T1.IsBackground = true;
                T1.Start();
                
            }
        }

        private void Initial_p_Btn_Click(object sender, EventArgs e)
        {
            renew_pos();
            robot_using = true;
            MessageBox.Show("Initial Sucess!!");
            CSystemPara.sp_bCanSend = true;
        }
        public void renew_pos()
        { 
        
            string initial_position_code = "S,7A,init,E";
            Initial_TCP.Send_to_getpos("one",initial_position_code);
            Initial_TCP.Send_to_getpos("two",initial_position_code);
        
        }
        private void GetRobotPosition()//狀態欄傳入結構中
        {
            CSystemPara.Robot_Position_struct.J1 = Convert.ToDouble(textBox_J1.Text);
            CSystemPara.Robot_Position_struct.J2 = Convert.ToDouble(textBox_J2.Text);
            CSystemPara.Robot_Position_struct.J3 = Convert.ToDouble(textBox_J3.Text);
            CSystemPara.Robot_Position_struct.J4 = Convert.ToDouble(textBox_J4.Text);
            CSystemPara.Robot_Position_struct.J5 = Convert.ToDouble(textBox_J5.Text);
            CSystemPara.Robot_Position_struct.J6 = Convert.ToDouble(textBox_J6.Text);

            CSystemPara.Robot_Position_struct.X = Convert.ToDouble(textBox_X.Text);
            CSystemPara.Robot_Position_struct.Y = Convert.ToDouble(textBox_Y.Text);
            CSystemPara.Robot_Position_struct.Z = Convert.ToDouble(textBox_Z.Text);


            CSystemPara.Robot_Two_Position_struct.J1 = Convert.ToDouble(textBox_J1_Two.Text);
            CSystemPara.Robot_Two_Position_struct.J2 = Convert.ToDouble(textBox_J2_Two.Text);
            CSystemPara.Robot_Two_Position_struct.J3 = Convert.ToDouble(textBox_J3_Two.Text);
            CSystemPara.Robot_Two_Position_struct.J4 = Convert.ToDouble(textBox_J4_Two.Text);
            CSystemPara.Robot_Two_Position_struct.J5 = Convert.ToDouble(textBox_J5_Two.Text);
            CSystemPara.Robot_Two_Position_struct.J6 = Convert.ToDouble(textBox_J6_Two.Text);

            CSystemPara.Robot_Two_Position_struct.X = Convert.ToDouble(textBox_X_Two.Text);
            CSystemPara.Robot_Two_Position_struct.Y = Convert.ToDouble(textBox_Y_Two.Text);
            CSystemPara.Robot_Two_Position_struct.Z = Convert.ToDouble(textBox_Z_Two.Text);

           

        }
        private void GetHeaderLables()
        {
            int renew_row = dataGridView1.Rows.Count;
            for (int i = 0; i < renew_row - 1; i++)
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
        }
        private void SaveTxt_Btn_Click(object sender, EventArgs e)
        {
            int size_row = dataGridView1.Rows.Count - 1;
            int size_column = dataGridView1.ColumnCount;
            last = new string[size_row, size_column];


            string[] saveline = new string[size_row];

            for (int i = 0; i < size_row; i++)
            {
                string savechar = "";
                for (int j = 0; j < size_column; j++)
                {
                    last[i, j] = dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString();
                    if (last[i, j] != "E")
                        savechar += last[i, j].ToString() + ",";
                    else
                    {
                        savechar += last[i, j].ToString();
                        break;
                    }
                }

                saveline[i] = savechar;

            }

            System.IO.File.WriteAllLines(@".\\" + textBox3.Text + ".txt", saveline);

            MessageBox.Show("儲存成功" + "\n");
        }
        private void Convert_Btn_Click(object sender, EventArgs e)
        {
           
            // dataGridView1.ColumnCount = 9; //決定行數;
            if (dataGridView1.RowCount == 0)
                return;

            if (radioButton1.Checked == true)//選擇第一台的話
            {
              
                switch (comboBox1.SelectedIndex)
                {
                    case 0://Pose_J
                       
                        foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                        {
                            dataGridView1.RowCount += 1; //每點一次開始生成row
                            r.Cells[0].Value = "R1:S";
                            r.Cells[1].Value = "1A";
                            r.Cells[8].Value = "E";
                            for (int i = 0; i < txb_ControlsForJ.Length; i++)
                            {
                                if (!r.IsNewRow)
                                {
                                    r.Cells[i + 2].Value = txb_ControlsForJ[i].Text;

                                }
                            }
                        }
                        GetHeaderLables();
                        break;

                    case 1://Pose_V

                        if (Relative_C[0] == "1") //因為計算完一次相對座標會清空Relative_C，所以需要防呆  "1"不代表任何意義
                        {
                            MessageBox.Show("please check your 「Pose_V」if it had been calculated~~");
                            return;
                        }
                        
                       
                        
                        foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                        {
                            dataGridView1.RowCount += 1; //每點一次開始生成row
                            r.Cells[0].Value = "R1:S";
                            r.Cells[1].Value = "2A";
                            r.Cells[5].Value = "E";
                            for (int i = 0; i < txb_ControlsForVec.Length; i++)
                            {
                                 if (!r.IsNewRow)
                                    r.Cells[i + 2].Value = Relative_C[i];

                                 Relative_C[i] = "1";//會清空相對座標   "1"不代表任何意義
                            }
                         }
                        GetHeaderLables();
                        break;
                }
            }
            else if (radioButton2.Checked == true)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0://Pose_J
                       
                        foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                        {
                             dataGridView1.RowCount += 1; //每點一次開始生成row
                            r.Cells[0].Value = "R2:S";
                            r.Cells[1].Value = "1A";
                            r.Cells[8].Value = "E";
                            for (int i = 0; i < txb_ControlsForJ_2.Length; i++)
                            {
                                if (!r.IsNewRow)
                                {
                                    r.Cells[i + 2].Value = txb_ControlsForJ_2[i].Text;

                                }
                            }
                        }
                        GetHeaderLables();
                        break;

                    case 1://Pose_V
                      
                        if (Relative_C[0] == "1") //因為計算完一次相對座標會清空Relative_C，所以需要防呆  "1"不代表任何意義
                        {
                            MessageBox.Show("please check your 「Pose_V」if it had been calculated~~");
                            return;
                        }
                        
                       
                        foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                        {
                            dataGridView1.RowCount += 1; //每點一次開始生成row
                            r.Cells[0].Value = "R2:S";
                            r.Cells[1].Value = "2A";
                            r.Cells[5].Value = "E";
                            for (int i = 0; i < txb_ControlsForVec_2.Length; i++)
                            {
                                if (!r.IsNewRow)
                                    r.Cells[i + 2].Value = txb_ControlsForVec_2[i].Text;
                                
                                Relative_C[i] = "";//會清空相對座標
                            }
                        }
                        GetHeaderLables();
                        break;
                }

            }

        }
        private void Addrow_Btn_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.IsNewRow)
                {

                    dataGridView1.Rows.Insert(r.Index);

                    GetHeaderLables();
                }

            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (((DataObject)e.Data).GetData(typeof(DataGridViewRow)) == null) return;

            Point TargetPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
            if ((dataGridView1.HitTest(TargetPoint.X, TargetPoint.Y).Type != DataGridViewHitTestType.Cell)) return;

            int TargetRowIndex = dataGridView1.HitTest(TargetPoint.X, TargetPoint.Y).RowIndex;
            if ((dataGridView1.Rows[TargetRowIndex].IsNewRow) || (dataGridView1.SelectedRows.Contains(dataGridView1.Rows[TargetRowIndex]))) return;

            if (dataGridView1.DataSource == null)
            {
                DataGridViewRow SourceRow = dataGridView1.SelectedRows[0];
                dataGridView1.Rows.Remove(SourceRow);
                dataGridView1.Rows.Insert(TargetRowIndex, SourceRow);

                //renew header label

                GetHeaderLables();

            }
            else
            {
                DataTable SourceData = dataGridView1.DataSource.GetType() == typeof(BindingSource) ? ((DataSet)((BindingSource)dataGridView1.DataSource).DataSource).Tables[0] : (DataTable)dataGridView1.DataSource;
                SourceData.PrimaryKey = new DataColumn[] { SourceData.Columns[0] };

                DataRow OriginRow = SourceData.Rows.Find(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (OriginRow == null) return;

                DataRow SourceRow = SourceData.NewRow();
                int InsertIndex = SourceData.Rows.IndexOf(SourceData.Rows.Find(dataGridView1.Rows[TargetRowIndex].Cells[0].Value));
                SourceRow.ItemArray = OriginRow.ItemArray;
                SourceData.Rows.Remove(OriginRow);
                SourceData.Rows.InsertAt(SourceRow, InsertIndex);

                SourceData.AcceptChanges();
            }
            dataGridView1.CurrentCell = dataGridView1.Rows[TargetRowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex];
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            // Scroll滾動功能
            if (e.Y <= PointToScreen(new Point(dataGridView1.Location.X , dataGridView1.Location.Y)).Y+40)
                dataGridView1.FirstDisplayedScrollingRowIndex -= 1;
            if (e.Y >= PointToScreen(new Point(dataGridView1.Location.X + dataGridView1.Width, dataGridView1.Location.Y)).Y-60)
                dataGridView1.FirstDisplayedScrollingRowIndex += 1;

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridView1.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.Cell) return;

            if (e.Button == MouseButtons.Left)
            {
                if (dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].IsNewRow) return;
            }
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dataGridView1.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.Cell) return;

            if (e.Button == MouseButtons.Left)
            {
           
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Selected = true;
                dataGridView1.DoDragDrop(dataGridView1.SelectedRows[0], DragDropEffects.Move);
               
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dataGridView1.Rows.Remove(r);

                    GetHeaderLables();
                }

            }
        }


        private void J1_addBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J1 += Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                
                //renew_pos();
                
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J1_minBtn_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J1 -= Convert.ToDouble(add_value_J.Value);
                string combine = "R1:"+numericUpDown_R1_Speed.Value.ToString()+":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";
                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
                
             
            }
            
        }

        private void J2_addBtn_Click(object sender, EventArgs e)
        {
       
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J2 += Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
           
        }

        private void J2_minBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J2 -= Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
          
        }

        private void J3_addBtn_Click(object sender, EventArgs e)
        {
          
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J3 += Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J3_minBtn_Click(object sender, EventArgs e)
        {
   
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J3 -= Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
           
        }

        private void J4_addBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J4 += Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J4_minBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J4 -= Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J5_addBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J5 += Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J5_minBtn_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J5 -= Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
               // renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J6_addBtn_Click(object sender, EventArgs e)
        {
          
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J6 += Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
               // renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void J6_minBtn_Click(object sender, EventArgs e)
        {
         
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                CSystemPara.Robot_Position_struct.J6 -= Convert.ToDouble(add_value_J.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void X_addBtn_Click(object sender, EventArgs e)
        {
           
            
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,2A," + add_value_V.Value.ToString() + "," +
                                           "0" + "," +
                                           "0" + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void X_minBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();

                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,2A,-" + add_value_V.Value.ToString() + "," +
                                           "0" + "," +
                                           "0" + ",E";

                Initial_TCP.Send_To_Robot(combine);

                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void Y_addBtn_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,2A," + "0" + "," +
                                           add_value_V.Value.ToString() + "," +
                                           "0" + ",E";
                CSystemPara.sp_bCanSend = false;
                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                //Update();

                //Thread R1_wait = new Thread(Wait);
                //R1_wait.Start();
                //while (R1_wait.IsAlive) { }
                
              
            }
            
        }
        private void Y_minBtn_Click(object sender, EventArgs e)
        {
       
            if (CSystemPara.sp_bCanSend)
            {
                Y_minBtn.Enabled = false;
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,2A," + "0" + ",-" +
                                           add_value_V.Value.ToString() + "," +
                                           "0" + ",E";
                
                Initial_TCP.Send_To_Robot(combine);
                CSystemPara.sp_bCanSend = false;
                //renew_pos();
                //Update();
                
           
                Y_minBtn.Enabled = true;
            }
            
        }

        private void Z_addBtn_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,2A," + "0" + "," +
                                           "0" + "," +
                                            add_value_V.Value.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }

           
        }

        private void Z_minBtn_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R1:" + numericUpDown_R1_Speed.Value.ToString() + ":S,2A," + "0" + "," +
                                           "0" + ",-" +
                                            add_value_V.Value.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
            
        }

        private void Loadtxt_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            //openfile.InitialDirectory = Application.StartupPath + "@.\\iris\\";
            
            openfile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] Temp = System.IO.File.ReadAllLines(openfile.FileName);//讀取整行
                act_step.robot_path = new string[Temp.Length];

                
                //---------增加欄位的資料行、列
                dataGridView1.ColumnCount = 9; //決定行數
                dataGridView1.RowCount = Temp.Length + 1;//資料列
                dataGridView1.ColumnHeadersVisible = true;
                //
                dataGridView1.Columns[0].HeaderText ="機器人No & 起始碼";
                dataGridView1.Columns[1].HeaderText = "指令碼";
             

                for (int i = 0; i < Temp.Length; i++)
                {
                    char[] delimeter = {','};
                    string[] data = Temp[i].Split(delimeter, StringSplitOptions.RemoveEmptyEntries);

                    //dataGridView1.Columns[4].HeaderText = "4";
                    dataGridView1.Rows[i].HeaderCell.Value = (i+1).ToString();
                    //dataGridView1.ColumnCount = data.Length;//決定行數
                   
                   
                    for (int j = 0; j < data.Length; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = data[j];
                       
                    }
                }
                
                for (int i = 0;i< Temp.Length;i++ )
                    act_step.robot_path[i] = Temp[i];
                    
                Initial_TCP.getpath(act_step);
                MessageBox.Show("機器人路徑已設置.....");
            }
        }

        private void J1_minBtn_Two_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J1 -= Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J1_addBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J1 += Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J2_addBtn_Two_Click(object sender, EventArgs e)
        {
          
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J2 += Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J2_minBtn_Two_Click(object sender, EventArgs e)
        {
         
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J2 -= Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J3_addBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J3 += Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J3_minBtn_Two_Click(object sender, EventArgs e)
        {
        
            
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J3 -= Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J4_addBtn_Two_Click(object sender, EventArgs e)
        {

           
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J4 += Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J4_minBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J4 -= Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J5_addBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J5 += Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J5_minBtn_Two_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J5 -= Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J6_addBtn_Two_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J6 += Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
               // renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void J6_minBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {

                GetRobotPosition();
                CSystemPara.Robot_Two_Position_struct.J6 -= Convert.ToDouble(add_value_J_Two.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,1A," + CSystemPara.Robot_Two_Position_struct.J1.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J2.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J3.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J4.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J5.ToString() + "," +
                                           CSystemPara.Robot_Two_Position_struct.J6.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void X_addBtn_Two_Click(object sender, EventArgs e)
        {
          
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();

                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,2A," + add_value_V_Two.Value.ToString() + "," +
                                           "0" + "," +
                                           "0" + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void X_minBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                 
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,2A,-" + add_value_V_Two.Value.ToString() + "," +
                                           "0" + "," +
                                           "0" + ",E";

                Initial_TCP.Send_To_Robot(combine);
                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void Y_addBtn_Two_Click(object sender, EventArgs e)
        {
            
  
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,2A," + "0" + "," +
                                           add_value_V_Two.Value.ToString() + "," +
                                           "0" + ",E";

                Initial_TCP.Send_To_Robot(combine);

                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void Y_minBtn_Two_Click(object sender, EventArgs e)
        {
           
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                //CSystemPara.Robot_Position_struct.X += Convert.ToDouble(add_value_V.Value);
                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,2A," + "0" + ",-" +
                                           add_value_V_Two.Value.ToString() + "," +
                                           "0" + ",E";

                Initial_TCP.Send_To_Robot(combine);

                //renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void Z_addBtn_Two_Click(object sender, EventArgs e)
        {
            
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();

                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,2A," + "0" + "," +
                                           "0" + "," +
                                            add_value_V_Two.Value.ToString() + ",E";

                Initial_TCP.Send_To_Robot(combine);
               // renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void Z_minBtn_Two_Click(object sender, EventArgs e)
        {

            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();

                string combine = "R2:" + numericUpDown_R2_Speed.Value.ToString() + ":S,2A," + "0" + "," +
                                           "0" + ",-" +
                                            add_value_V_Two.Value.ToString() + ",E";

                Initial_TCP.Send_To_Robot( combine);
                // renew_pos();
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initial_TCP.show();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Initial_TCP.save_Image(textBoxfilename.Text, combofiletype.Text);
           
            //Initial_TCP.auto_focus();
           // Initial_TCP.manual_focus(22440);
        }


        private void GetDrawP_Btn_Click(object sender, EventArgs e)
        {
            Initial_p_Btn_Click(sender, e);
            //GetRobotPosition();//再次確認位置
            //renew_pos();
            if (comboBox1.SelectedIndex != 1)
                return;
            
            //選到Pose_V
                if (radioButton1.Checked == true)//選到Robot1
                {
                    if (ChBox_Vector[0].Checked)
                    {
                        planning_X1.Text = textBox_X.Text;
                        planning_Y1.Text = textBox_Y.Text;
                        planning_Z1.Text = textBox_Z.Text;
                    }
                    else if (ChBox_Vector[1].Checked == true)
                    {

                        planning_X0.Text = textBox_X.Text;
                        planning_Y0.Text = textBox_Y.Text;
                        planning_Z0.Text = textBox_Z.Text;

                    }
                }
                else if (radioButton2.Checked == true)//選到Robot2
                {

                    if (ChBox_Vector[0].Checked)
                    {
                        planning_X1.Text = textBox_X_Two.Text;
                        planning_Y1.Text = textBox_Y_Two.Text;
                        planning_Z1.Text = textBox_Z_Two.Text;

                    }
                    else if (ChBox_Vector[1].Checked == true)
                    {

                        planning_X0.Text = textBox_X_Two.Text;
                        planning_Y0.Text = textBox_Y_Two.Text;
                        planning_Z0.Text = textBox_Z_Two.Text;

                    }

                }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
              ChBox_Vector[1].Checked = false;
            
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ChBox_Vector[0].Checked = false;
            
        }
        private void calculate_position_Click(object sender, EventArgs e)
        {
            if (txb_Planning_Control[0].Text == "" || txb_Planning_Control[3].Text == "")
                return;
            
           
            Relative_C[0] = (Convert.ToDouble(txb_Planning_Control[0].Text) - Convert.ToDouble(txb_Planning_Control[3].Text)).ToString();
            Relative_C[1] = (Convert.ToDouble(txb_Planning_Control[1].Text) - Convert.ToDouble(txb_Planning_Control[4].Text)).ToString();
            Relative_C[2] = (Convert.ToDouble(txb_Planning_Control[2].Text) - Convert.ToDouble(txb_Planning_Control[5].Text)).ToString();

            for (int i = 0; i < Relative_C.Length; i++)
                 Relative_C[i] = Math.Round(Convert.ToDouble(Relative_C[i]), 8).ToString();

            MessageBox.Show("Calculated Success!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try_DO.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                string combine = act_step.R1home;
                Initial_TCP.Send_To_Robot(combine);
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void R2home_Btn_Click(object sender, EventArgs e)
        {
            if (CSystemPara.sp_bCanSend)
            {
                GetRobotPosition();
                string combine = act_step.R2home;
                Initial_TCP.Send_To_Robot(combine);
                CSystemPara.sp_bCanSend = false;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           Initial_TCP.ONandOFF();

           richTextBox1.AppendText(CSystemPara.grab_count.ToString());
        }

       

        

       

    }
}
