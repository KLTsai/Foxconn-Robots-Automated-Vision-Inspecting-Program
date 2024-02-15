using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCP_IP_class;
using PixeLinkU3_Acquisition;
using PR;
using DO_StaticDO;
using HalconDotNet;



namespace RAVIP
{
    public partial class FormMain : Form
    {
       

        //FormPixeLinkU3HalconAcquisition FormPixeLink= null;
        FormRobotControl RobotControlForm1 =null;
        FormSF SFForm=null;
        StaticDOForm StaticDoForm = null;

    
        

        public FormMain()
        {
            InitializeComponent();

            
            
            
            // create the Robot Control Form #1
            RobotControlForm1 = new FormRobotControl();
            RobotControlForm1.TopLevel = false;
            this.groupBoxRobotControl1.Controls.Add(RobotControlForm1);
            RobotControlForm1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            RobotControlForm1.Dock = DockStyle.Fill;
            RobotControlForm1.Show();

            // create the Robot Control Form #2
            //FormRobotControl RobotControlForm2 = new FormRobotControl();
            //RobotControlForm2.TopLevel = false;
            //this.groupBoxＲobotControl2.Controls.Add(RobotControlForm2);
            //RobotControlForm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //RobotControlForm2.Dock = DockStyle.Fill;
            //RobotControlForm2.Show();

            // create Shape Finder Control Form
            //SFForm = new FormSF();
            //SFForm.TopLevel = false;
            //this.groupBoxSFControl.Controls.Add(SFForm);
            //SFForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           // SFForm.Dock = DockStyle.Fill;
            //SFForm.Show();


            CSystemPara.sp_RAVIPForm.TopLevel = false;
            this.groupBoxPixeLinkCCD.Controls.Add(CSystemPara.sp_RAVIPForm);
            CSystemPara.sp_RAVIPForm.Dock = DockStyle.Fill;
            CSystemPara.sp_RAVIPForm.Show();
          
            /*
            FormPixeLink = new FormPixeLinkU3HalconAcquisition();
            FormPixeLink.TopLevel = false;
            this.groupBoxPixeLinkCCD.Controls.Add(FormPixeLink);
            FormPixeLink.Dock = DockStyle.Fill;
            FormPixeLink.Show();*/

            StaticDoForm = new StaticDOForm();
            StaticDoForm.TopLevel = false;
            this.groupBoxStaticDO.Controls.Add(StaticDoForm);
            StaticDoForm.Dock = DockStyle.Fill;
            StaticDoForm.Show();



            CSystemPara.sp_ShapeFinderForm.TopLevel = false;
            this.tabPageMain.Controls.Add(CSystemPara.sp_ShapeFinderForm);
            //this.tabPageMain.AutoScroll = true;
            CSystemPara.sp_ShapeFinderForm.Dock = DockStyle.Top;
            CSystemPara.sp_ShapeFinderForm.Show();

           // RAVIPDelegateObj = new RAVIPformDelegateImage(RAVIP_Call_Test.R2_Cam_form.TogetImage);
           // RAVIPDelegateBool = new RAVIPformDelegateAutoFocus(RAVIP_Call_Test.R2_Cam_form.ToUseAutoFocus);
           // RAVIPDelegateValue = new RAVIPDelegateManual(RAVIP_Call_Test.R2_Cam_form.Maunal_Focus);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void robotControl1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form form = new Form();
            form.BackColor = Color.Pink;
            form.Text = "My Form";
            this.dock1.DockControl(form, DockLocation.Left);
            form.Display();
            */
            if (RobotControlForm1 !=null)
            {
                this.groupBoxRobotControl1.Controls.Remove(RobotControlForm1);
                RobotControlForm1.Show();
            }
            RobotControlForm1 = new FormRobotControl();
            //this.groupBox1.dockCont
            RobotControlForm1.Show();
        }

       
        
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FormPixeLink.Close();
            CSystemPara.sp_RAVIPForm.Close();
            RobotControlForm1.Close();
            StaticDoForm.Close();
        }

        private void shapeFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SFForm != null)
            {
                SFForm.Show();
                return;
            }
            SFForm = new FormSF();
            //SFForm.MdiParent = this;  // main form must be a mdi container;
            //SFForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //SFForm.Dock = DockStyle.Fill;
            SFForm.Show();
        }

        private void cCDControlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = CSystemPara.time;
        }

        
    }
}
