namespace PR
{
    partial class FormPR
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
            this.MainmenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadSVM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.classificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waferDataProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waferDIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPR = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iplImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MLPtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aNNToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxNoOfData = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.dataGridViewPostureData = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxDir = new System.Windows.Forms.ComboBox();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.hWindowControl2 = new HalconDotNet.HWindowControl();
            this.tabControlPR = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.buttonSetPRPattern = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxROI = new System.Windows.Forms.GroupBox();
            this.buttonSetFocusROI = new System.Windows.Forms.Button();
            this.checkBoxDisplayROI = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownROIHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownROIWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownROIStartY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownROIStartX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownROIStep = new System.Windows.Forms.NumericUpDown();
            this.buttonROIDown = new System.Windows.Forms.Button();
            this.buttonROIRight = new System.Windows.Forms.Button();
            this.buttonROILeft = new System.Windows.Forms.Button();
            this.buttonROIUp = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNCC_PR = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLearn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelScale = new System.Windows.Forms.Label();
            this.numericUpDownAngleStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngleExtent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNoOfMatches = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBoxisSubPixel = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownOverlapRatio = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownMinScore = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDownScale1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownScale2 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.MainmenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPostureData)).BeginInit();
            this.tabControlPR.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.groupBoxROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStep)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlapRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale2)).BeginInit();
            this.SuspendLayout();
            // 
            // MainmenuStrip
            // 
            this.MainmenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MainmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemView,
            this.toolStripMenuItemPR,
            this.MLPtoolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainmenuStrip.Name = "MainmenuStrip";
            this.MainmenuStrip.Size = new System.Drawing.Size(1274, 24);
            this.MainmenuStrip.TabIndex = 18;
            this.MainmenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoadSVM,
            this.toolStripSeparator2,
            this.loadImageToolStripMenuItem,
            this.toolStripMenuItemSaveImage,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "F";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItemLoadSVM
            // 
            this.toolStripMenuItemLoadSVM.Name = "toolStripMenuItemLoadSVM";
            this.toolStripMenuItemLoadSVM.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemLoadSVM.Text = "Load SVM Model";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loadImageToolStripMenuItem.Text = "&Load Image";
            // 
            // toolStripMenuItemSaveImage
            // 
            this.toolStripMenuItemSaveImage.Name = "toolStripMenuItemSaveImage";
            this.toolStripMenuItemSaveImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveImage.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemSaveImage.Text = "&Save_Image";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.ShortcutKeyDisplayString = "e";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(41, 20);
            this.toolStripMenuItemEdit.Text = "&Edit";
            // 
            // toolStripMenuItemView
            // 
            this.toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classificationToolStripMenuItem,
            this.waferDataProcessToolStripMenuItem,
            this.waferDIPToolStripMenuItem,
            this.toolStripMenuItem1,
            this.otherToolStripMenuItem,
            this.dataInfoToolStripMenuItem,
            this.toolStripSeparator1,
            this.showDIPToolStripMenuItem,
            this.showFeatureToolStripMenuItem});
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            this.toolStripMenuItemView.ShortcutKeyDisplayString = "v";
            this.toolStripMenuItemView.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItemView.Text = "&View";
            // 
            // classificationToolStripMenuItem
            // 
            this.classificationToolStripMenuItem.Name = "classificationToolStripMenuItem";
            this.classificationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.classificationToolStripMenuItem.Text = "Classification";
            // 
            // waferDataProcessToolStripMenuItem
            // 
            this.waferDataProcessToolStripMenuItem.Name = "waferDataProcessToolStripMenuItem";
            this.waferDataProcessToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.waferDataProcessToolStripMenuItem.Text = "Wafer Data Process";
            // 
            // waferDIPToolStripMenuItem
            // 
            this.waferDIPToolStripMenuItem.Name = "waferDIPToolStripMenuItem";
            this.waferDIPToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.waferDIPToolStripMenuItem.Text = "Wafer DIP";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem1.Text = "Color Selection";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSelectionToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.otherToolStripMenuItem.Text = "Other";
            this.otherToolStripMenuItem.Visible = false;
            // 
            // colorSelectionToolStripMenuItem
            // 
            this.colorSelectionToolStripMenuItem.Name = "colorSelectionToolStripMenuItem";
            this.colorSelectionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.colorSelectionToolStripMenuItem.Text = "Color Selection";
            // 
            // dataInfoToolStripMenuItem
            // 
            this.dataInfoToolStripMenuItem.Name = "dataInfoToolStripMenuItem";
            this.dataInfoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.dataInfoToolStripMenuItem.Text = "Data Info";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // showDIPToolStripMenuItem
            // 
            this.showDIPToolStripMenuItem.Name = "showDIPToolStripMenuItem";
            this.showDIPToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showDIPToolStripMenuItem.Text = "Show DIP";
            // 
            // showFeatureToolStripMenuItem
            // 
            this.showFeatureToolStripMenuItem.Name = "showFeatureToolStripMenuItem";
            this.showFeatureToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showFeatureToolStripMenuItem.Text = "Show Feature Data";
            // 
            // toolStripMenuItemPR
            // 
            this.toolStripMenuItemPR.Checked = true;
            this.toolStripMenuItemPR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemPR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matrixToolStripMenuItem,
            this.iplImageToolStripMenuItem,
            this.convertToolStripMenuItem});
            this.toolStripMenuItemPR.Name = "toolStripMenuItemPR";
            this.toolStripMenuItemPR.ShortcutKeyDisplayString = "w";
            this.toolStripMenuItemPR.Size = new System.Drawing.Size(109, 20);
            this.toolStripMenuItemPR.Text = "Data Processing";
            this.toolStripMenuItemPR.Visible = false;
            // 
            // matrixToolStripMenuItem
            // 
            this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            this.matrixToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.matrixToolStripMenuItem.Text = "Wafer Image Process";
            // 
            // iplImageToolStripMenuItem
            // 
            this.iplImageToolStripMenuItem.Name = "iplImageToolStripMenuItem";
            this.iplImageToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.iplImageToolStripMenuItem.Text = "Detect NG";
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.convertToolStripMenuItem.Text = "Classify Wafer";
            // 
            // MLPtoolStripMenuItem
            // 
            this.MLPtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tryToolStripMenuItem,
            this.aNNToolToolStripMenuItem});
            this.MLPtoolStripMenuItem.Name = "MLPtoolStripMenuItem";
            this.MLPtoolStripMenuItem.ShortcutKeyDisplayString = "p";
            this.MLPtoolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.MLPtoolStripMenuItem.Text = "PR Models";
            // 
            // tryToolStripMenuItem
            // 
            this.tryToolStripMenuItem.Name = "tryToolStripMenuItem";
            this.tryToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.tryToolStripMenuItem.Text = "SVM Tool";
            // 
            // aNNToolToolStripMenuItem
            // 
            this.aNNToolToolStripMenuItem.Enabled = false;
            this.aNNToolToolStripMenuItem.Name = "aNNToolToolStripMenuItem";
            this.aNNToolToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aNNToolToolStripMenuItem.Text = "ANN Tool";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeyDisplayString = "h";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // textBoxNoOfData
            // 
            this.textBoxNoOfData.Location = new System.Drawing.Point(359, 24);
            this.textBoxNoOfData.Name = "textBoxNoOfData";
            this.textBoxNoOfData.Size = new System.Drawing.Size(55, 22);
            this.textBoxNoOfData.TabIndex = 25;
            this.textBoxNoOfData.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label35.Location = new System.Drawing.Point(297, 29);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 12);
            this.label35.TabIndex = 26;
            this.label35.Text = "No of Data";
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(12, 622);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(277, 220);
            this.richTextBoxInfo.TabIndex = 24;
            this.richTextBoxInfo.Text = "";
            // 
            // dataGridViewPostureData
            // 
            this.dataGridViewPostureData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPostureData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Filename,
            this.TagName});
            this.dataGridViewPostureData.Location = new System.Drawing.Point(12, 55);
            this.dataGridViewPostureData.MultiSelect = false;
            this.dataGridViewPostureData.Name = "dataGridViewPostureData";
            this.dataGridViewPostureData.RowHeadersVisible = false;
            this.dataGridViewPostureData.RowTemplate.Height = 24;
            this.dataGridViewPostureData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewPostureData.Size = new System.Drawing.Size(277, 561);
            this.dataGridViewPostureData.TabIndex = 23;
            this.dataGridViewPostureData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPostureData_CellContentClick);
            // 
            // No
            // 
            this.No.HeaderText = "Number";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // Filename
            // 
            this.Filename.HeaderText = "Fileanme";
            this.Filename.Name = "Filename";
            this.Filename.Width = 150;
            // 
            // TagName
            // 
            this.TagName.HeaderText = "Tag";
            this.TagName.Name = "TagName";
            // 
            // comboBoxDir
            // 
            this.comboBoxDir.DropDownHeight = 200;
            this.comboBoxDir.DropDownWidth = 750;
            this.comboBoxDir.FormattingEnabled = true;
            this.comboBoxDir.IntegralHeight = false;
            this.comboBoxDir.Location = new System.Drawing.Point(12, 26);
            this.comboBoxDir.Name = "comboBoxDir";
            this.comboBoxDir.Size = new System.Drawing.Size(273, 20);
            this.comboBoxDir.Sorted = true;
            this.comboBoxDir.TabIndex = 22;
            this.comboBoxDir.Text = "------     選擇資料夾  -------";
            this.comboBoxDir.SelectedIndexChanged += new System.EventHandler(this.comboBoxDir_SelectedIndexChanged);
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(295, 55);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(478, 419);
            this.hWindowControl1.TabIndex = 27;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(478, 419);
            // 
            // hWindowControl2
            // 
            this.hWindowControl2.BackColor = System.Drawing.Color.Black;
            this.hWindowControl2.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl2.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl2.Location = new System.Drawing.Point(797, 55);
            this.hWindowControl2.Name = "hWindowControl2";
            this.hWindowControl2.Size = new System.Drawing.Size(459, 419);
            this.hWindowControl2.TabIndex = 28;
            this.hWindowControl2.WindowSize = new System.Drawing.Size(459, 419);
            // 
            // tabControlPR
            // 
            this.tabControlPR.Controls.Add(this.tabPage);
            this.tabControlPR.Controls.Add(this.tabPage2);
            this.tabControlPR.Location = new System.Drawing.Point(295, 494);
            this.tabControlPR.Name = "tabControlPR";
            this.tabControlPR.SelectedIndex = 0;
            this.tabControlPR.Size = new System.Drawing.Size(493, 348);
            this.tabControlPR.TabIndex = 29;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.buttonSetPRPattern);
            this.tabPage.Controls.Add(this.label1);
            this.tabPage.Controls.Add(this.groupBoxROI);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(485, 322);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Extract Learning Pattern";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // buttonSetPRPattern
            // 
            this.buttonSetPRPattern.Location = new System.Drawing.Point(329, 254);
            this.buttonSetPRPattern.Name = "buttonSetPRPattern";
            this.buttonSetPRPattern.Size = new System.Drawing.Size(87, 48);
            this.buttonSetPRPattern.TabIndex = 8;
            this.buttonSetPRPattern.Text = "Save Pattern";
            this.buttonSetPRPattern.UseVisualStyleBackColor = true;
            this.buttonSetPRPattern.Click += new System.EventHandler(this.buttonSetPRPattern_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "2. Set ROI as Matching Pattern";
            // 
            // groupBoxROI
            // 
            this.groupBoxROI.Controls.Add(this.buttonSetFocusROI);
            this.groupBoxROI.Controls.Add(this.checkBoxDisplayROI);
            this.groupBoxROI.Controls.Add(this.label11);
            this.groupBoxROI.Controls.Add(this.label10);
            this.groupBoxROI.Controls.Add(this.label9);
            this.groupBoxROI.Controls.Add(this.label8);
            this.groupBoxROI.Controls.Add(this.numericUpDownROIHeight);
            this.groupBoxROI.Controls.Add(this.numericUpDownROIWidth);
            this.groupBoxROI.Controls.Add(this.numericUpDownROIStartY);
            this.groupBoxROI.Controls.Add(this.numericUpDownROIStartX);
            this.groupBoxROI.Controls.Add(this.label7);
            this.groupBoxROI.Controls.Add(this.numericUpDownROIStep);
            this.groupBoxROI.Controls.Add(this.buttonROIDown);
            this.groupBoxROI.Controls.Add(this.buttonROIRight);
            this.groupBoxROI.Controls.Add(this.buttonROILeft);
            this.groupBoxROI.Controls.Add(this.buttonROIUp);
            this.groupBoxROI.Location = new System.Drawing.Point(6, 6);
            this.groupBoxROI.Name = "groupBoxROI";
            this.groupBoxROI.Size = new System.Drawing.Size(451, 242);
            this.groupBoxROI.TabIndex = 6;
            this.groupBoxROI.TabStop = false;
            this.groupBoxROI.Text = "1. ROI Setting";
            // 
            // buttonSetFocusROI
            // 
            this.buttonSetFocusROI.Location = new System.Drawing.Point(323, 181);
            this.buttonSetFocusROI.Name = "buttonSetFocusROI";
            this.buttonSetFocusROI.Size = new System.Drawing.Size(92, 51);
            this.buttonSetFocusROI.TabIndex = 15;
            this.buttonSetFocusROI.Text = "Determine PR Parameter";
            this.buttonSetFocusROI.UseVisualStyleBackColor = true;
            this.buttonSetFocusROI.Click += new System.EventHandler(this.buttonSetFocusROI_Click);
            // 
            // checkBoxDisplayROI
            // 
            this.checkBoxDisplayROI.AutoSize = true;
            this.checkBoxDisplayROI.Location = new System.Drawing.Point(136, 24);
            this.checkBoxDisplayROI.Name = "checkBoxDisplayROI";
            this.checkBoxDisplayROI.Size = new System.Drawing.Size(82, 16);
            this.checkBoxDisplayROI.TabIndex = 14;
            this.checkBoxDisplayROI.Text = "Display ROI";
            this.checkBoxDisplayROI.UseVisualStyleBackColor = true;
            this.checkBoxDisplayROI.CheckedChanged += new System.EventHandler(this.checkBoxDisplayROI_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "Height";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "Width";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "Start Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start X";
            // 
            // numericUpDownROIHeight
            // 
            this.numericUpDownROIHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIHeight.Location = new System.Drawing.Point(365, 138);
            this.numericUpDownROIHeight.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIHeight.Name = "numericUpDownROIHeight";
            this.numericUpDownROIHeight.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIHeight.TabIndex = 9;
            this.numericUpDownROIHeight.Value = new decimal(new int[] {
            310,
            0,
            0,
            0});
            this.numericUpDownROIHeight.ValueChanged += new System.EventHandler(this.numericUpDownROIHeight_ValueChanged);
            // 
            // numericUpDownROIWidth
            // 
            this.numericUpDownROIWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIWidth.Location = new System.Drawing.Point(365, 104);
            this.numericUpDownROIWidth.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIWidth.Name = "numericUpDownROIWidth";
            this.numericUpDownROIWidth.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIWidth.TabIndex = 8;
            this.numericUpDownROIWidth.Value = new decimal(new int[] {
            380,
            0,
            0,
            0});
            this.numericUpDownROIWidth.ValueChanged += new System.EventHandler(this.numericUpDownROIWidth_ValueChanged);
            // 
            // numericUpDownROIStartY
            // 
            this.numericUpDownROIStartY.Location = new System.Drawing.Point(365, 61);
            this.numericUpDownROIStartY.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIStartY.Name = "numericUpDownROIStartY";
            this.numericUpDownROIStartY.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIStartY.TabIndex = 7;
            this.numericUpDownROIStartY.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.numericUpDownROIStartY.ValueChanged += new System.EventHandler(this.numericUpDownROIStartY_ValueChanged);
            // 
            // numericUpDownROIStartX
            // 
            this.numericUpDownROIStartX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIStartX.Location = new System.Drawing.Point(365, 21);
            this.numericUpDownROIStartX.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIStartX.Name = "numericUpDownROIStartX";
            this.numericUpDownROIStartX.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIStartX.TabIndex = 6;
            this.numericUpDownROIStartX.Value = new decimal(new int[] {
            130,
            0,
            0,
            0});
            this.numericUpDownROIStartX.ValueChanged += new System.EventHandler(this.numericUpDownROIStartX_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "Step ";
            // 
            // numericUpDownROIStep
            // 
            this.numericUpDownROIStep.Location = new System.Drawing.Point(71, 21);
            this.numericUpDownROIStep.Name = "numericUpDownROIStep";
            this.numericUpDownROIStep.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIStep.TabIndex = 4;
            this.numericUpDownROIStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIStep.ValueChanged += new System.EventHandler(this.numericUpDownROIStep_ValueChanged);
            // 
            // buttonROIDown
            // 
            this.buttonROIDown.Location = new System.Drawing.Point(105, 157);
            this.buttonROIDown.Name = "buttonROIDown";
            this.buttonROIDown.Size = new System.Drawing.Size(55, 47);
            this.buttonROIDown.TabIndex = 3;
            this.buttonROIDown.Text = "Down";
            this.buttonROIDown.UseVisualStyleBackColor = true;
            this.buttonROIDown.Click += new System.EventHandler(this.buttonROIDown_Click);
            // 
            // buttonROIRight
            // 
            this.buttonROIRight.Location = new System.Drawing.Point(158, 113);
            this.buttonROIRight.Name = "buttonROIRight";
            this.buttonROIRight.Size = new System.Drawing.Size(55, 47);
            this.buttonROIRight.TabIndex = 2;
            this.buttonROIRight.Text = "Right";
            this.buttonROIRight.UseVisualStyleBackColor = true;
            this.buttonROIRight.Click += new System.EventHandler(this.buttonROIRight_Click);
            // 
            // buttonROILeft
            // 
            this.buttonROILeft.Location = new System.Drawing.Point(53, 113);
            this.buttonROILeft.Name = "buttonROILeft";
            this.buttonROILeft.Size = new System.Drawing.Size(55, 47);
            this.buttonROILeft.TabIndex = 1;
            this.buttonROILeft.Text = "Left";
            this.buttonROILeft.UseVisualStyleBackColor = true;
            this.buttonROILeft.Click += new System.EventHandler(this.buttonROILeft_Click);
            // 
            // buttonROIUp
            // 
            this.buttonROIUp.Location = new System.Drawing.Point(105, 71);
            this.buttonROIUp.Name = "buttonROIUp";
            this.buttonROIUp.Size = new System.Drawing.Size(55, 45);
            this.buttonROIUp.TabIndex = 0;
            this.buttonROIUp.Text = "Up";
            this.buttonROIUp.UseVisualStyleBackColor = true;
            this.buttonROIUp.Click += new System.EventHandler(this.buttonROIUp_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.buttonNCC_PR);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.buttonLearn);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(485, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Testing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numericUpDownMinScore);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.numericUpDownOverlapRatio);
            this.groupBox1.Controls.Add(this.checkBoxisSubPixel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDownNoOfMatches);
            this.groupBox1.Controls.Add(this.numericUpDownAngleExtent);
            this.groupBox1.Controls.Add(this.numericUpDownAngleStart);
            this.groupBox1.Location = new System.Drawing.Point(39, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 118);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Parameters of NCC  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "3. Set up the NCC Matching parameter";
            // 
            // buttonNCC_PR
            // 
            this.buttonNCC_PR.Location = new System.Drawing.Point(380, 146);
            this.buttonNCC_PR.Name = "buttonNCC_PR";
            this.buttonNCC_PR.Size = new System.Drawing.Size(94, 49);
            this.buttonNCC_PR.TabIndex = 3;
            this.buttonNCC_PR.Text = "NCC PR";
            this.buttonNCC_PR.UseVisualStyleBackColor = true;
            this.buttonNCC_PR.Click += new System.EventHandler(this.buttonNCC_PR_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "2. Select a testing image (in testing Dir) to test";
            // 
            // buttonLearn
            // 
            this.buttonLearn.Location = new System.Drawing.Point(380, 29);
            this.buttonLearn.Name = "buttonLearn";
            this.buttonLearn.Size = new System.Drawing.Size(94, 41);
            this.buttonLearn.TabIndex = 1;
            this.buttonLearn.Text = "Learn";
            this.buttonLearn.UseVisualStyleBackColor = true;
            this.buttonLearn.Click += new System.EventHandler(this.buttonLearn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "1. Select a pattern image (in Pattern Dir) to Learn";
            // 
            // LabelScale
            // 
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(446, 30);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(29, 12);
            this.LabelScale.TabIndex = 31;
            this.LabelScale.Text = "Scale";
            // 
            // numericUpDownAngleStart
            // 
            this.numericUpDownAngleStart.DecimalPlaces = 2;
            this.numericUpDownAngleStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownAngleStart.Location = new System.Drawing.Point(100, 51);
            this.numericUpDownAngleStart.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownAngleStart.Minimum = new decimal(new int[] {
            314,
            0,
            0,
            -2147352576});
            this.numericUpDownAngleStart.Name = "numericUpDownAngleStart";
            this.numericUpDownAngleStart.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownAngleStart.TabIndex = 0;
            this.numericUpDownAngleStart.Value = new decimal(new int[] {
            39,
            0,
            0,
            -2147352576});
            // 
            // numericUpDownAngleExtent
            // 
            this.numericUpDownAngleExtent.DecimalPlaces = 2;
            this.numericUpDownAngleExtent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownAngleExtent.Location = new System.Drawing.Point(257, 51);
            this.numericUpDownAngleExtent.Maximum = new decimal(new int[] {
            314,
            0,
            0,
            131072});
            this.numericUpDownAngleExtent.Name = "numericUpDownAngleExtent";
            this.numericUpDownAngleExtent.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownAngleExtent.TabIndex = 1;
            this.numericUpDownAngleExtent.Value = new decimal(new int[] {
            78,
            0,
            0,
            131072});
            // 
            // numericUpDownNoOfMatches
            // 
            this.numericUpDownNoOfMatches.Location = new System.Drawing.Point(100, 21);
            this.numericUpDownNoOfMatches.Name = "numericUpDownNoOfMatches";
            this.numericUpDownNoOfMatches.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownNoOfMatches.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "No of Matches";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Angle Start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(178, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Angle Extent";
            // 
            // checkBoxisSubPixel
            // 
            this.checkBoxisSubPixel.AutoSize = true;
            this.checkBoxisSubPixel.Checked = true;
            this.checkBoxisSubPixel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxisSubPixel.Location = new System.Drawing.Point(210, 23);
            this.checkBoxisSubPixel.Name = "checkBoxisSubPixel";
            this.checkBoxisSubPixel.Size = new System.Drawing.Size(65, 16);
            this.checkBoxisSubPixel.TabIndex = 6;
            this.checkBoxisSubPixel.Text = "SubPixel";
            this.checkBoxisSubPixel.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "Overlap Ratio";
            // 
            // numericUpDownOverlapRatio
            // 
            this.numericUpDownOverlapRatio.DecimalPlaces = 1;
            this.numericUpDownOverlapRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownOverlapRatio.Location = new System.Drawing.Point(100, 79);
            this.numericUpDownOverlapRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOverlapRatio.Name = "numericUpDownOverlapRatio";
            this.numericUpDownOverlapRatio.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownOverlapRatio.TabIndex = 7;
            this.numericUpDownOverlapRatio.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Learn TienPR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(178, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 10;
            this.label14.Text = "Min Score";
            // 
            // numericUpDownMinScore
            // 
            this.numericUpDownMinScore.DecimalPlaces = 2;
            this.numericUpDownMinScore.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownMinScore.Location = new System.Drawing.Point(257, 79);
            this.numericUpDownMinScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinScore.Name = "numericUpDownMinScore";
            this.numericUpDownMinScore.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownMinScore.TabIndex = 9;
            this.numericUpDownMinScore.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(377, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "NCC TienPR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDownScale1
            // 
            this.numericUpDownScale1.DecimalPlaces = 2;
            this.numericUpDownScale1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownScale1.Location = new System.Drawing.Point(481, 26);
            this.numericUpDownScale1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScale1.Name = "numericUpDownScale1";
            this.numericUpDownScale1.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownScale1.TabIndex = 32;
            this.numericUpDownScale1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownScale2
            // 
            this.numericUpDownScale2.DecimalPlaces = 2;
            this.numericUpDownScale2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownScale2.Location = new System.Drawing.Point(998, 30);
            this.numericUpDownScale2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScale2.Name = "numericUpDownScale2";
            this.numericUpDownScale2.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownScale2.TabIndex = 34;
            this.numericUpDownScale2.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(963, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "Scale";
            // 
            // FormPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 846);
            this.Controls.Add(this.numericUpDownScale2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericUpDownScale1);
            this.Controls.Add(this.LabelScale);
            this.Controls.Add(this.tabControlPR);
            this.Controls.Add(this.hWindowControl2);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.textBoxNoOfData);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.dataGridViewPostureData);
            this.Controls.Add(this.comboBoxDir);
            this.Controls.Add(this.MainmenuStrip);
            this.Name = "FormPR";
            this.Text = "Pattern Learning and Matching";
            this.MainmenuStrip.ResumeLayout(false);
            this.MainmenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPostureData)).EndInit();
            this.tabControlPR.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.groupBoxROI.ResumeLayout(false);
            this.groupBoxROI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStep)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlapRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainmenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadSVM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem classificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waferDataProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waferDIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPR;
        private System.Windows.Forms.ToolStripMenuItem matrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iplImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MLPtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aNNToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxNoOfData;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.DataGridView dataGridViewPostureData;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.ComboBox comboBoxDir;
        private HalconDotNet.HWindowControl hWindowControl1;
        private HalconDotNet.HWindowControl hWindowControl2;
        private System.Windows.Forms.TabControl tabControlPR;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.GroupBox groupBoxROI;
        private System.Windows.Forms.Button buttonSetFocusROI;
        private System.Windows.Forms.CheckBox checkBoxDisplayROI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownROIHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownROIWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownROIStartY;
        private System.Windows.Forms.NumericUpDown numericUpDownROIStartX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownROIStep;
        private System.Windows.Forms.Button buttonROIDown;
        private System.Windows.Forms.Button buttonROIRight;
        private System.Windows.Forms.Button buttonROILeft;
        private System.Windows.Forms.Button buttonROIUp;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.Button buttonSetPRPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLearn;
        private System.Windows.Forms.Button buttonNCC_PR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownAngleExtent;
        private System.Windows.Forms.NumericUpDown numericUpDownAngleStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownNoOfMatches;
        private System.Windows.Forms.CheckBox checkBoxisSubPixel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownOverlapRatio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownMinScore;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDownScale1;
        private System.Windows.Forms.NumericUpDown numericUpDownScale2;
        private System.Windows.Forms.Label label15;
    }
}

