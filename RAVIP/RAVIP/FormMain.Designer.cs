namespace RAVIP
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robotControl1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robotControl2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cCDControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapeFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlShapeFinder = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageRobotControl1 = new System.Windows.Forms.TabPage();
            this.groupBoxRobotControl1 = new System.Windows.Forms.GroupBox();
            this.tabPagePixeLinkCCD = new System.Windows.Forms.TabPage();
            this.groupBoxPixeLinkCCD = new System.Windows.Forms.GroupBox();
            this.groupBoxStaticDO = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControlShapeFinder.SuspendLayout();
            this.tabPageRobotControl1.SuspendLayout();
            this.tabPagePixeLinkCCD.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1562, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            this.menuStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadConfigToolStripMenuItem.Text = "Load Config";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.robotControl1ToolStripMenuItem,
            this.robotControl2ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cCDControlToolStripMenuItem,
            this.shapeFinderToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.controlToolStripMenuItem.Text = "&Control";
            // 
            // robotControl1ToolStripMenuItem
            // 
            this.robotControl1ToolStripMenuItem.Name = "robotControl1ToolStripMenuItem";
            this.robotControl1ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.robotControl1ToolStripMenuItem.Text = "Robot Control #1";
            this.robotControl1ToolStripMenuItem.Click += new System.EventHandler(this.robotControl1ToolStripMenuItem_Click);
            // 
            // robotControl2ToolStripMenuItem
            // 
            this.robotControl2ToolStripMenuItem.Name = "robotControl2ToolStripMenuItem";
            this.robotControl2ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.robotControl2ToolStripMenuItem.Text = "Robot Control #2";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // cCDControlToolStripMenuItem
            // 
            this.cCDControlToolStripMenuItem.Name = "cCDControlToolStripMenuItem";
            this.cCDControlToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cCDControlToolStripMenuItem.Text = "CCD Control";
            this.cCDControlToolStripMenuItem.Click += new System.EventHandler(this.cCDControlToolStripMenuItem_Click);
            // 
            // shapeFinderToolStripMenuItem
            // 
            this.shapeFinderToolStripMenuItem.Name = "shapeFinderToolStripMenuItem";
            this.shapeFinderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.shapeFinderToolStripMenuItem.Text = "Shape Finder";
            this.shapeFinderToolStripMenuItem.Click += new System.EventHandler(this.shapeFinderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripMain.Location = new System.Drawing.Point(0, 860);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1562, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "00.00ms";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 51);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1327, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 491);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(225, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(339, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControlShapeFinder
            // 
            this.tabControlShapeFinder.Controls.Add(this.tabPageMain);
            this.tabControlShapeFinder.Controls.Add(this.tabPageRobotControl1);
            this.tabControlShapeFinder.Controls.Add(this.tabPagePixeLinkCCD);
            this.tabControlShapeFinder.Controls.Add(this.groupBoxStaticDO);
            this.tabControlShapeFinder.Location = new System.Drawing.Point(0, 84);
            this.tabControlShapeFinder.Name = "tabControlShapeFinder";
            this.tabControlShapeFinder.SelectedIndex = 0;
            this.tabControlShapeFinder.Size = new System.Drawing.Size(1321, 759);
            this.tabControlShapeFinder.TabIndex = 4;
            // 
            // tabPageMain
            // 
            this.tabPageMain.AutoScroll = true;
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1313, 733);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageRobotControl1
            // 
            this.tabPageRobotControl1.Controls.Add(this.groupBoxRobotControl1);
            this.tabPageRobotControl1.Location = new System.Drawing.Point(4, 22);
            this.tabPageRobotControl1.Name = "tabPageRobotControl1";
            this.tabPageRobotControl1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRobotControl1.Size = new System.Drawing.Size(1229, 699);
            this.tabPageRobotControl1.TabIndex = 1;
            this.tabPageRobotControl1.Text = "Robot Control #1";
            this.tabPageRobotControl1.UseVisualStyleBackColor = true;
            // 
            // groupBoxRobotControl1
            // 
            this.groupBoxRobotControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRobotControl1.Location = new System.Drawing.Point(3, 3);
            this.groupBoxRobotControl1.Name = "groupBoxRobotControl1";
            this.groupBoxRobotControl1.Size = new System.Drawing.Size(1223, 693);
            this.groupBoxRobotControl1.TabIndex = 0;
            this.groupBoxRobotControl1.TabStop = false;
            // 
            // tabPagePixeLinkCCD
            // 
            this.tabPagePixeLinkCCD.Controls.Add(this.groupBoxPixeLinkCCD);
            this.tabPagePixeLinkCCD.Location = new System.Drawing.Point(4, 22);
            this.tabPagePixeLinkCCD.Name = "tabPagePixeLinkCCD";
            this.tabPagePixeLinkCCD.Size = new System.Drawing.Size(1229, 699);
            this.tabPagePixeLinkCCD.TabIndex = 3;
            this.tabPagePixeLinkCCD.Text = "PixeLink CCD";
            this.tabPagePixeLinkCCD.UseVisualStyleBackColor = true;
            // 
            // groupBoxPixeLinkCCD
            // 
            this.groupBoxPixeLinkCCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPixeLinkCCD.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPixeLinkCCD.Name = "groupBoxPixeLinkCCD";
            this.groupBoxPixeLinkCCD.Size = new System.Drawing.Size(1229, 699);
            this.groupBoxPixeLinkCCD.TabIndex = 0;
            this.groupBoxPixeLinkCCD.TabStop = false;
            // 
            // groupBoxStaticDO
            // 
            this.groupBoxStaticDO.Location = new System.Drawing.Point(4, 22);
            this.groupBoxStaticDO.Name = "groupBoxStaticDO";
            this.groupBoxStaticDO.Size = new System.Drawing.Size(1229, 699);
            this.groupBoxStaticDO.TabIndex = 4;
            this.groupBoxStaticDO.Text = "I/O Control";
            this.groupBoxStaticDO.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1562, 882);
            this.Controls.Add(this.tabControlShapeFinder);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Foxconn -- RAVIP System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabControlShapeFinder.ResumeLayout(false);
            this.tabPageRobotControl1.ResumeLayout(false);
            this.tabPagePixeLinkCCD.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControlShapeFinder;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageRobotControl1;
        private System.Windows.Forms.ToolStripMenuItem robotControl1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robotControl2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.GroupBox groupBoxRobotControl1;
        private System.Windows.Forms.ToolStripMenuItem cCDControlToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPagePixeLinkCCD;
        private System.Windows.Forms.GroupBox groupBoxPixeLinkCCD;
        private System.Windows.Forms.ToolStripMenuItem shapeFinderToolStripMenuItem;
        private System.Windows.Forms.TabPage groupBoxStaticDO;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}

