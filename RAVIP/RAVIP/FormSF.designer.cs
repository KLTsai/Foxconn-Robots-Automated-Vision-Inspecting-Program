namespace PR
{
    partial class FormSF
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
            this.tabControlPRNCC = new System.Windows.Forms.TabControl();
            this.tabPageExtractPattern = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxSaveFilename = new System.Windows.Forms.TextBox();
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
            this.tabPageNCC = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownMinScore = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownOverlapRatio = new System.Windows.Forms.NumericUpDown();
            this.checkBoxisSubPixel = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownNoOfMatches = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngleExtent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngleStart = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNCC_PR = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSF = new System.Windows.Forms.Button();
            this.buttonSFbyFunction = new System.Windows.Forms.Button();
            this.buttonSFLearn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownSFGreediness = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxSFOptimization = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownAngleStep = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxSFSubpixel = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.numericUpDownSFMinScore = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDownSFOverlapRatio = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.numericUpDownSFNoOfMatch = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSFAngleExtent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSFAngleStart = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.LabelScale = new System.Windows.Forms.Label();
            this.numericUpDownScale1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownScale2 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxImageType = new System.Windows.Forms.ComboBox();
            this.tabControlShapeFinder = new System.Windows.Forms.TabControl();
            this.tabPageGeometryTransform = new System.Windows.Forms.TabPage();
            this.buttonMatchAgain = new System.Windows.Forms.Button();
            this.buttonAffineTransform = new System.Windows.Forms.Button();
            this.groupBoxAffineTransform = new System.Windows.Forms.GroupBox();
            this.numericUpDownTransform_Scale = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCenterY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCenterX = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.texb_Port = new System.Windows.Forms.TextBox();
            this.Click_ClienConnect = new System.Windows.Forms.Button();
            this.texb_IP = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonSegment = new System.Windows.Forms.Button();
            this.groupBoxCompareCondition = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.numericUpDownMaxArea = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.numericUpDownMinArea = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.numericUpDownNoOfClosing = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.numericUpDownSmoothWindowSize = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.numericUpDownOffSet = new System.Windows.Forms.NumericUpDown();
            this.buttonFindDiff = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Ini_LearnPattern_Btn = new System.Windows.Forms.Button();
            this.MainmenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPostureData)).BeginInit();
            this.tabControlPRNCC.SuspendLayout();
            this.tabPageExtractPattern.SuspendLayout();
            this.groupBoxROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStep)).BeginInit();
            this.tabPageNCC.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlapRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleStart)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFGreediness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFMinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFOverlapRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFNoOfMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFAngleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale2)).BeginInit();
            this.tabControlShapeFinder.SuspendLayout();
            this.tabPageGeometryTransform.SuspendLayout();
            this.groupBoxAffineTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransform_Scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBoxCompareCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfClosing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffSet)).BeginInit();
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
            this.MainmenuStrip.Size = new System.Drawing.Size(1235, 24);
            this.MainmenuStrip.TabIndex = 18;
            this.MainmenuStrip.Text = "menuStrip1";
            this.MainmenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainmenuStrip_ItemClicked);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItemLoadSVM
            // 
            this.toolStripMenuItemLoadSVM.Name = "toolStripMenuItemLoadSVM";
            this.toolStripMenuItemLoadSVM.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItemLoadSVM.Text = "Load SVM Model";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadImageToolStripMenuItem.Text = "&Load Image";
            // 
            // toolStripMenuItemSaveImage
            // 
            this.toolStripMenuItemSaveImage.Name = "toolStripMenuItemSaveImage";
            this.toolStripMenuItemSaveImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveImage.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItemSaveImage.Text = "&Save_Image";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.ShortcutKeyDisplayString = "e";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(42, 20);
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
            this.toolStripMenuItemView.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItemView.Text = "&View";
            // 
            // classificationToolStripMenuItem
            // 
            this.classificationToolStripMenuItem.Name = "classificationToolStripMenuItem";
            this.classificationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.classificationToolStripMenuItem.Text = "Classification";
            // 
            // waferDataProcessToolStripMenuItem
            // 
            this.waferDataProcessToolStripMenuItem.Name = "waferDataProcessToolStripMenuItem";
            this.waferDataProcessToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.waferDataProcessToolStripMenuItem.Text = "Wafer Data Process";
            // 
            // waferDIPToolStripMenuItem
            // 
            this.waferDIPToolStripMenuItem.Name = "waferDIPToolStripMenuItem";
            this.waferDIPToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.waferDIPToolStripMenuItem.Text = "Wafer DIP";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem1.Text = "Color Selection";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSelectionToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.otherToolStripMenuItem.Text = "Other";
            this.otherToolStripMenuItem.Visible = false;
            // 
            // colorSelectionToolStripMenuItem
            // 
            this.colorSelectionToolStripMenuItem.Name = "colorSelectionToolStripMenuItem";
            this.colorSelectionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.colorSelectionToolStripMenuItem.Text = "Color Selection";
            // 
            // dataInfoToolStripMenuItem
            // 
            this.dataInfoToolStripMenuItem.Name = "dataInfoToolStripMenuItem";
            this.dataInfoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.dataInfoToolStripMenuItem.Text = "Data Info";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // showDIPToolStripMenuItem
            // 
            this.showDIPToolStripMenuItem.Name = "showDIPToolStripMenuItem";
            this.showDIPToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showDIPToolStripMenuItem.Text = "Show DIP";
            // 
            // showFeatureToolStripMenuItem
            // 
            this.showFeatureToolStripMenuItem.Name = "showFeatureToolStripMenuItem";
            this.showFeatureToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
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
            this.toolStripMenuItemPR.Size = new System.Drawing.Size(110, 20);
            this.toolStripMenuItemPR.Text = "Data Processing";
            this.toolStripMenuItemPR.Visible = false;
            // 
            // matrixToolStripMenuItem
            // 
            this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            this.matrixToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.matrixToolStripMenuItem.Text = "Wafer Image Process";
            // 
            // iplImageToolStripMenuItem
            // 
            this.iplImageToolStripMenuItem.Name = "iplImageToolStripMenuItem";
            this.iplImageToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.iplImageToolStripMenuItem.Text = "Detect NG";
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.convertToolStripMenuItem.Text = "Classify Wafer";
            // 
            // MLPtoolStripMenuItem
            // 
            this.MLPtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tryToolStripMenuItem,
            this.aNNToolToolStripMenuItem});
            this.MLPtoolStripMenuItem.Name = "MLPtoolStripMenuItem";
            this.MLPtoolStripMenuItem.ShortcutKeyDisplayString = "p";
            this.MLPtoolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.MLPtoolStripMenuItem.Text = "PR Models";
            // 
            // tryToolStripMenuItem
            // 
            this.tryToolStripMenuItem.Name = "tryToolStripMenuItem";
            this.tryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tryToolStripMenuItem.Text = "NCC Model";
            this.tryToolStripMenuItem.Click += new System.EventHandler(this.tryToolStripMenuItem_Click);
            // 
            // aNNToolToolStripMenuItem
            // 
            this.aNNToolToolStripMenuItem.Enabled = false;
            this.aNNToolToolStripMenuItem.Name = "aNNToolToolStripMenuItem";
            this.aNNToolToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aNNToolToolStripMenuItem.Text = "Shape Model";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeyDisplayString = "h";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // textBoxNoOfData
            // 
            this.textBoxNoOfData.Location = new System.Drawing.Point(1125, 26);
            this.textBoxNoOfData.Name = "textBoxNoOfData";
            this.textBoxNoOfData.Size = new System.Drawing.Size(55, 22);
            this.textBoxNoOfData.TabIndex = 25;
            this.textBoxNoOfData.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label35.Location = new System.Drawing.Point(1053, 30);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 12);
            this.label35.TabIndex = 26;
            this.label35.Text = "No of Data";
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(12, 622);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(243, 220);
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
            this.dataGridViewPostureData.Size = new System.Drawing.Size(243, 561);
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
            this.comboBoxDir.Size = new System.Drawing.Size(344, 20);
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
            this.hWindowControl1.Location = new System.Drawing.Point(261, 55);
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
            this.hWindowControl2.Location = new System.Drawing.Point(742, 56);
            this.hWindowControl2.Name = "hWindowControl2";
            this.hWindowControl2.Size = new System.Drawing.Size(483, 419);
            this.hWindowControl2.TabIndex = 28;
            this.hWindowControl2.WindowSize = new System.Drawing.Size(483, 419);
            // 
            // tabControlPRNCC
            // 
            this.tabControlPRNCC.Controls.Add(this.tabPageExtractPattern);
            this.tabControlPRNCC.Controls.Add(this.tabPageNCC);
            this.tabControlPRNCC.Controls.Add(this.tabPage1);
            this.tabControlPRNCC.Location = new System.Drawing.Point(261, 494);
            this.tabControlPRNCC.Name = "tabControlPRNCC";
            this.tabControlPRNCC.SelectedIndex = 0;
            this.tabControlPRNCC.Size = new System.Drawing.Size(478, 348);
            this.tabControlPRNCC.TabIndex = 29;
            // 
            // tabPageExtractPattern
            // 
            this.tabPageExtractPattern.Controls.Add(this.label17);
            this.tabPageExtractPattern.Controls.Add(this.textBoxSaveFilename);
            this.tabPageExtractPattern.Controls.Add(this.buttonSetPRPattern);
            this.tabPageExtractPattern.Controls.Add(this.label1);
            this.tabPageExtractPattern.Controls.Add(this.groupBoxROI);
            this.tabPageExtractPattern.Location = new System.Drawing.Point(4, 22);
            this.tabPageExtractPattern.Name = "tabPageExtractPattern";
            this.tabPageExtractPattern.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExtractPattern.Size = new System.Drawing.Size(470, 322);
            this.tabPageExtractPattern.TabIndex = 0;
            this.tabPageExtractPattern.Text = "Extract Learning Pattern";
            this.tabPageExtractPattern.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(128, 285);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 12);
            this.label17.TabIndex = 10;
            this.label17.Text = "Save Filename: ";
            // 
            // textBoxSaveFilename
            // 
            this.textBoxSaveFilename.Location = new System.Drawing.Point(213, 280);
            this.textBoxSaveFilename.Name = "textBoxSaveFilename";
            this.textBoxSaveFilename.Size = new System.Drawing.Size(97, 22);
            this.textBoxSaveFilename.TabIndex = 9;
            this.textBoxSaveFilename.Text = "Pattern";
            // 
            // buttonSetPRPattern
            // 
            this.buttonSetPRPattern.Location = new System.Drawing.Point(334, 265);
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
            this.buttonSetFocusROI.Location = new System.Drawing.Point(292, 181);
            this.buttonSetFocusROI.Name = "buttonSetFocusROI";
            this.buttonSetFocusROI.Size = new System.Drawing.Size(123, 51);
            this.buttonSetFocusROI.TabIndex = 15;
            this.buttonSetFocusROI.Text = "Extract Pattern and Testing Model";
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
            this.numericUpDownROIHeight.Location = new System.Drawing.Point(365, 134);
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
            this.numericUpDownROIWidth.Location = new System.Drawing.Point(365, 100);
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
            this.numericUpDownROIStartY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIStartY.Location = new System.Drawing.Point(365, 59);
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
            // tabPageNCC
            // 
            this.tabPageNCC.Controls.Add(this.button2);
            this.tabPageNCC.Controls.Add(this.button1);
            this.tabPageNCC.Controls.Add(this.groupBox1);
            this.tabPageNCC.Controls.Add(this.label4);
            this.tabPageNCC.Controls.Add(this.buttonNCC_PR);
            this.tabPageNCC.Controls.Add(this.label3);
            this.tabPageNCC.Controls.Add(this.label2);
            this.tabPageNCC.Location = new System.Drawing.Point(4, 22);
            this.tabPageNCC.Name = "tabPageNCC";
            this.tabPageNCC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNCC.Size = new System.Drawing.Size(470, 322);
            this.tabPageNCC.TabIndex = 1;
            this.tabPageNCC.Text = "NCC Model";
            this.tabPageNCC.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "NCC TienPR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Learn TienPR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(178, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Angle Extent";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "No of Matches";
            // 
            // numericUpDownNoOfMatches
            // 
            this.numericUpDownNoOfMatches.Location = new System.Drawing.Point(100, 21);
            this.numericUpDownNoOfMatches.Name = "numericUpDownNoOfMatches";
            this.numericUpDownNoOfMatches.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownNoOfMatches.TabIndex = 2;
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
            this.buttonNCC_PR.Location = new System.Drawing.Point(362, 242);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "1. Select a pattern image (in Pattern Dir) to Learn";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.buttonSF);
            this.tabPage1.Controls.Add(this.buttonSFbyFunction);
            this.tabPage1.Controls.Add(this.buttonSFLearn);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(470, 322);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Shape Model";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(261, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 50);
            this.button3.TabIndex = 13;
            this.button3.Text = "Learn SF (function?)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // buttonSF
            // 
            this.buttonSF.Location = new System.Drawing.Point(261, 93);
            this.buttonSF.Name = "buttonSF";
            this.buttonSF.Size = new System.Drawing.Size(94, 55);
            this.buttonSF.TabIndex = 12;
            this.buttonSF.Text = "Shape Finder";
            this.buttonSF.UseVisualStyleBackColor = true;
            this.buttonSF.Click += new System.EventHandler(this.buttonSF_Click);
            // 
            // buttonSFbyFunction
            // 
            this.buttonSFbyFunction.Location = new System.Drawing.Point(361, 95);
            this.buttonSFbyFunction.Name = "buttonSFbyFunction";
            this.buttonSFbyFunction.Size = new System.Drawing.Size(91, 53);
            this.buttonSFbyFunction.TabIndex = 11;
            this.buttonSFbyFunction.Text = "Shape Finder Tien";
            this.buttonSFbyFunction.UseVisualStyleBackColor = true;
            this.buttonSFbyFunction.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonSFLearn
            // 
            this.buttonSFLearn.Location = new System.Drawing.Point(359, 20);
            this.buttonSFLearn.Name = "buttonSFLearn";
            this.buttonSFLearn.Size = new System.Drawing.Size(94, 50);
            this.buttonSFLearn.TabIndex = 10;
            this.buttonSFLearn.Text = "Learn SF";
            this.buttonSFLearn.UseVisualStyleBackColor = true;
            this.buttonSFLearn.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownSFGreediness);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.comboBoxSFOptimization);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.numericUpDownAngleStep);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.comboBoxSFSubpixel);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.numericUpDownSFMinScore);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.numericUpDownSFOverlapRatio);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.numericUpDownSFNoOfMatch);
            this.groupBox3.Controls.Add(this.numericUpDownSFAngleExtent);
            this.groupBox3.Controls.Add(this.numericUpDownSFAngleStart);
            this.groupBox3.Location = new System.Drawing.Point(9, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 134);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Parameters of Shape Finder   ";
            // 
            // numericUpDownSFGreediness
            // 
            this.numericUpDownSFGreediness.DecimalPlaces = 1;
            this.numericUpDownSFGreediness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSFGreediness.Location = new System.Drawing.Point(389, 79);
            this.numericUpDownSFGreediness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSFGreediness.Name = "numericUpDownSFGreediness";
            this.numericUpDownSFGreediness.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownSFGreediness.TabIndex = 18;
            this.numericUpDownSFGreediness.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(308, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 12);
            this.label21.TabIndex = 17;
            this.label21.Text = "Greediness";
            // 
            // comboBoxSFOptimization
            // 
            this.comboBoxSFOptimization.FormattingEnabled = true;
            this.comboBoxSFOptimization.Items.AddRange(new object[] {
            "auto",
            "none",
            "point_reduction_low",
            "point_reduction_medium",
            "point_reduction_high",
            "pregeneration"});
            this.comboBoxSFOptimization.Location = new System.Drawing.Point(379, 17);
            this.comboBoxSFOptimization.Name = "comboBoxSFOptimization";
            this.comboBoxSFOptimization.Size = new System.Drawing.Size(70, 20);
            this.comboBoxSFOptimization.TabIndex = 16;
            this.comboBoxSFOptimization.Text = "none";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(308, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 15;
            this.label20.Text = "Optimization";
            // 
            // numericUpDownAngleStep
            // 
            this.numericUpDownAngleStep.DecimalPlaces = 4;
            this.numericUpDownAngleStep.Enabled = false;
            this.numericUpDownAngleStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownAngleStep.Location = new System.Drawing.Point(384, 49);
            this.numericUpDownAngleStep.Maximum = new decimal(new int[] {
            19625,
            0,
            0,
            327680});
            this.numericUpDownAngleStep.Name = "numericUpDownAngleStep";
            this.numericUpDownAngleStep.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownAngleStep.TabIndex = 14;
            this.numericUpDownAngleStep.Value = new decimal(new int[] {
            175,
            0,
            0,
            262144});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(308, 53);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 12);
            this.label19.TabIndex = 13;
            this.label19.Text = "Angle Step";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(157, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 12);
            this.label18.TabIndex = 12;
            this.label18.Text = "Subpixel";
            // 
            // comboBoxSFSubpixel
            // 
            this.comboBoxSFSubpixel.FormattingEnabled = true;
            this.comboBoxSFSubpixel.Items.AddRange(new object[] {
            " none",
            "interpolation",
            "least_squares",
            "least_squares_high",
            "least_squares_very_high",
            "max_deformation 1",
            "max_deformation 2",
            "max_deformation 3",
            "max_deformation 4",
            "max_deformation 5",
            "max_deformation 6 "});
            this.comboBoxSFSubpixel.Location = new System.Drawing.Point(213, 20);
            this.comboBoxSFSubpixel.Name = "comboBoxSFSubpixel";
            this.comboBoxSFSubpixel.Size = new System.Drawing.Size(89, 20);
            this.comboBoxSFSubpixel.TabIndex = 11;
            this.comboBoxSFSubpixel.Text = "least_squares";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(157, 82);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 10;
            this.label25.Text = "Min Score";
            // 
            // numericUpDownSFMinScore
            // 
            this.numericUpDownSFMinScore.DecimalPlaces = 2;
            this.numericUpDownSFMinScore.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownSFMinScore.Location = new System.Drawing.Point(229, 80);
            this.numericUpDownSFMinScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSFMinScore.Name = "numericUpDownSFMinScore";
            this.numericUpDownSFMinScore.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownSFMinScore.TabIndex = 9;
            this.numericUpDownSFMinScore.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 84);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 12);
            this.label26.TabIndex = 8;
            this.label26.Text = "Overlap Ratio";
            // 
            // numericUpDownSFOverlapRatio
            // 
            this.numericUpDownSFOverlapRatio.DecimalPlaces = 1;
            this.numericUpDownSFOverlapRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSFOverlapRatio.Location = new System.Drawing.Point(85, 82);
            this.numericUpDownSFOverlapRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSFOverlapRatio.Name = "numericUpDownSFOverlapRatio";
            this.numericUpDownSFOverlapRatio.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownSFOverlapRatio.TabIndex = 7;
            this.numericUpDownSFOverlapRatio.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(157, 54);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 12);
            this.label27.TabIndex = 5;
            this.label27.Text = "Angle Extent";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 53);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 12);
            this.label28.TabIndex = 4;
            this.label28.Text = "Angle Start";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(73, 12);
            this.label29.TabIndex = 3;
            this.label29.Text = "No of Matches";
            // 
            // numericUpDownSFNoOfMatch
            // 
            this.numericUpDownSFNoOfMatch.Location = new System.Drawing.Point(85, 21);
            this.numericUpDownSFNoOfMatch.Name = "numericUpDownSFNoOfMatch";
            this.numericUpDownSFNoOfMatch.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownSFNoOfMatch.TabIndex = 2;
            this.numericUpDownSFNoOfMatch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownSFAngleExtent
            // 
            this.numericUpDownSFAngleExtent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownSFAngleExtent.Location = new System.Drawing.Point(229, 52);
            this.numericUpDownSFAngleExtent.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownSFAngleExtent.Name = "numericUpDownSFAngleExtent";
            this.numericUpDownSFAngleExtent.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownSFAngleExtent.TabIndex = 1;
            this.numericUpDownSFAngleExtent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownSFAngleStart
            // 
            this.numericUpDownSFAngleStart.Location = new System.Drawing.Point(85, 52);
            this.numericUpDownSFAngleStart.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownSFAngleStart.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownSFAngleStart.Name = "numericUpDownSFAngleStart";
            this.numericUpDownSFAngleStart.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownSFAngleStart.TabIndex = 0;
            this.numericUpDownSFAngleStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(15, 137);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(186, 12);
            this.label30.TabIndex = 8;
            this.label30.Text = "3. Set up the NCC Matching parameter";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(15, 79);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(217, 12);
            this.label31.TabIndex = 7;
            this.label31.Text = "2. Select a testing image (in testing Dir) to test";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(15, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(233, 12);
            this.label32.TabIndex = 6;
            this.label32.Text = "1. Select a pattern image (in Pattern Dir) to Learn";
            // 
            // LabelScale
            // 
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(491, 28);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(29, 12);
            this.LabelScale.TabIndex = 31;
            this.LabelScale.Text = "Scale";
            // 
            // numericUpDownScale1
            // 
            this.numericUpDownScale1.DecimalPlaces = 2;
            this.numericUpDownScale1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownScale1.Location = new System.Drawing.Point(526, 24);
            this.numericUpDownScale1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScale1.Name = "numericUpDownScale1";
            this.numericUpDownScale1.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownScale1.TabIndex = 32;
            this.numericUpDownScale1.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // numericUpDownScale2
            // 
            this.numericUpDownScale2.DecimalPlaces = 2;
            this.numericUpDownScale2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownScale2.Location = new System.Drawing.Point(966, 30);
            this.numericUpDownScale2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScale2.Name = "numericUpDownScale2";
            this.numericUpDownScale2.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownScale2.TabIndex = 34;
            this.numericUpDownScale2.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(923, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "Scale";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(362, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 12);
            this.label16.TabIndex = 35;
            this.label16.Text = "Image Type: ";
            // 
            // comboBoxImageType
            // 
            this.comboBoxImageType.FormattingEnabled = true;
            this.comboBoxImageType.Items.AddRange(new object[] {
            "bmp",
            "jeg",
            "tiff",
            "png"});
            this.comboBoxImageType.Location = new System.Drawing.Point(435, 23);
            this.comboBoxImageType.Name = "comboBoxImageType";
            this.comboBoxImageType.Size = new System.Drawing.Size(50, 20);
            this.comboBoxImageType.TabIndex = 36;
            this.comboBoxImageType.Text = "bmp";
            // 
            // tabControlShapeFinder
            // 
            this.tabControlShapeFinder.Controls.Add(this.tabPageGeometryTransform);
            this.tabControlShapeFinder.Controls.Add(this.tabPage2);
            this.tabControlShapeFinder.Controls.Add(this.tabPage3);
            this.tabControlShapeFinder.Location = new System.Drawing.Point(745, 494);
            this.tabControlShapeFinder.Name = "tabControlShapeFinder";
            this.tabControlShapeFinder.SelectedIndex = 0;
            this.tabControlShapeFinder.Size = new System.Drawing.Size(478, 348);
            this.tabControlShapeFinder.TabIndex = 37;
            // 
            // tabPageGeometryTransform
            // 
            this.tabPageGeometryTransform.Controls.Add(this.buttonMatchAgain);
            this.tabPageGeometryTransform.Controls.Add(this.buttonAffineTransform);
            this.tabPageGeometryTransform.Controls.Add(this.groupBoxAffineTransform);
            this.tabPageGeometryTransform.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeometryTransform.Name = "tabPageGeometryTransform";
            this.tabPageGeometryTransform.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeometryTransform.Size = new System.Drawing.Size(470, 322);
            this.tabPageGeometryTransform.TabIndex = 1;
            this.tabPageGeometryTransform.Text = "Geometry Transform";
            this.tabPageGeometryTransform.UseVisualStyleBackColor = true;
            // 
            // buttonMatchAgain
            // 
            this.buttonMatchAgain.Location = new System.Drawing.Point(18, 173);
            this.buttonMatchAgain.Name = "buttonMatchAgain";
            this.buttonMatchAgain.Size = new System.Drawing.Size(107, 51);
            this.buttonMatchAgain.TabIndex = 11;
            this.buttonMatchAgain.Text = "Match Again";
            this.buttonMatchAgain.UseVisualStyleBackColor = true;
            this.buttonMatchAgain.Click += new System.EventHandler(this.buttonMatchAgain_Click);
            // 
            // buttonAffineTransform
            // 
            this.buttonAffineTransform.Location = new System.Drawing.Point(18, 120);
            this.buttonAffineTransform.Name = "buttonAffineTransform";
            this.buttonAffineTransform.Size = new System.Drawing.Size(107, 47);
            this.buttonAffineTransform.TabIndex = 9;
            this.buttonAffineTransform.Text = "Affine Transform";
            this.buttonAffineTransform.UseVisualStyleBackColor = true;
            this.buttonAffineTransform.Click += new System.EventHandler(this.buttonAffineTransform_Click);
            // 
            // groupBoxAffineTransform
            // 
            this.groupBoxAffineTransform.Controls.Add(this.numericUpDownTransform_Scale);
            this.groupBoxAffineTransform.Controls.Add(this.label33);
            this.groupBoxAffineTransform.Controls.Add(this.numericUpDownAngle);
            this.groupBoxAffineTransform.Controls.Add(this.numericUpDownCenterY);
            this.groupBoxAffineTransform.Controls.Add(this.numericUpDownCenterX);
            this.groupBoxAffineTransform.Controls.Add(this.label24);
            this.groupBoxAffineTransform.Controls.Add(this.label23);
            this.groupBoxAffineTransform.Controls.Add(this.label22);
            this.groupBoxAffineTransform.Location = new System.Drawing.Point(18, 20);
            this.groupBoxAffineTransform.Name = "groupBoxAffineTransform";
            this.groupBoxAffineTransform.Size = new System.Drawing.Size(312, 80);
            this.groupBoxAffineTransform.TabIndex = 8;
            this.groupBoxAffineTransform.TabStop = false;
            this.groupBoxAffineTransform.Text = " Affine Transform  ";
            // 
            // numericUpDownTransform_Scale
            // 
            this.numericUpDownTransform_Scale.DecimalPlaces = 3;
            this.numericUpDownTransform_Scale.Location = new System.Drawing.Point(223, 47);
            this.numericUpDownTransform_Scale.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTransform_Scale.Name = "numericUpDownTransform_Scale";
            this.numericUpDownTransform_Scale.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownTransform_Scale.TabIndex = 15;
            this.numericUpDownTransform_Scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(173, 49);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 12);
            this.label33.TabIndex = 14;
            this.label33.Text = "Scale: ";
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.DecimalPlaces = 3;
            this.numericUpDownAngle.Location = new System.Drawing.Point(80, 47);
            this.numericUpDownAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownAngle.TabIndex = 13;
            // 
            // numericUpDownCenterY
            // 
            this.numericUpDownCenterY.DecimalPlaces = 3;
            this.numericUpDownCenterY.Location = new System.Drawing.Point(223, 21);
            this.numericUpDownCenterY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCenterY.Name = "numericUpDownCenterY";
            this.numericUpDownCenterY.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownCenterY.TabIndex = 12;
            // 
            // numericUpDownCenterX
            // 
            this.numericUpDownCenterX.DecimalPlaces = 3;
            this.numericUpDownCenterX.Location = new System.Drawing.Point(80, 23);
            this.numericUpDownCenterX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCenterX.Name = "numericUpDownCenterX";
            this.numericUpDownCenterX.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownCenterX.TabIndex = 11;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 12);
            this.label24.TabIndex = 10;
            this.label24.Text = "Angle: ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(164, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 9;
            this.label23.Text = "Center Y: ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(21, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 8;
            this.label22.Text = "Center X: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label36);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.btn_Send);
            this.tabPage2.Controls.Add(this.texb_Port);
            this.tabPage2.Controls.Add(this.Click_ClienConnect);
            this.tabPage2.Controls.Add(this.texb_IP);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(470, 322);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "ClienConnect";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(25, 50);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(27, 12);
            this.label36.TabIndex = 6;
            this.label36.Text = "Port:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(34, 20);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(18, 12);
            this.label34.TabIndex = 5;
            this.label34.Text = "IP:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 79);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(177, 169);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(260, 77);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // texb_Port
            // 
            this.texb_Port.Location = new System.Drawing.Point(69, 47);
            this.texb_Port.Name = "texb_Port";
            this.texb_Port.Size = new System.Drawing.Size(100, 22);
            this.texb_Port.TabIndex = 2;
            this.texb_Port.Text = "8000";
            // 
            // Click_ClienConnect
            // 
            this.Click_ClienConnect.Location = new System.Drawing.Point(260, 45);
            this.Click_ClienConnect.Name = "Click_ClienConnect";
            this.Click_ClienConnect.Size = new System.Drawing.Size(75, 23);
            this.Click_ClienConnect.TabIndex = 1;
            this.Click_ClienConnect.Text = "Connect";
            this.Click_ClienConnect.UseVisualStyleBackColor = true;
            this.Click_ClienConnect.Click += new System.EventHandler(this.Click_ClienConnect_Click);
            // 
            // texb_IP
            // 
            this.texb_IP.Location = new System.Drawing.Point(69, 17);
            this.texb_IP.Name = "texb_IP";
            this.texb_IP.Size = new System.Drawing.Size(100, 22);
            this.texb_IP.TabIndex = 0;
            this.texb_IP.Text = "127.0.0.1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonSegment);
            this.tabPage3.Controls.Add(this.groupBoxCompareCondition);
            this.tabPage3.Controls.Add(this.buttonFindDiff);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(470, 322);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "ImageCompare";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonSegment
            // 
            this.buttonSegment.Location = new System.Drawing.Point(43, 250);
            this.buttonSegment.Name = "buttonSegment";
            this.buttonSegment.Size = new System.Drawing.Size(102, 44);
            this.buttonSegment.TabIndex = 17;
            this.buttonSegment.Text = "Segment";
            this.buttonSegment.UseVisualStyleBackColor = true;
            this.buttonSegment.Click += new System.EventHandler(this.buttonSegment_Click);
            // 
            // groupBoxCompareCondition
            // 
            this.groupBoxCompareCondition.Controls.Add(this.label44);
            this.groupBoxCompareCondition.Controls.Add(this.comboBox1);
            this.groupBoxCompareCondition.Controls.Add(this.button4);
            this.groupBoxCompareCondition.Controls.Add(this.label43);
            this.groupBoxCompareCondition.Controls.Add(this.numericUpDownMaxArea);
            this.groupBoxCompareCondition.Controls.Add(this.label42);
            this.groupBoxCompareCondition.Controls.Add(this.label40);
            this.groupBoxCompareCondition.Controls.Add(this.numericUpDownMinArea);
            this.groupBoxCompareCondition.Controls.Add(this.label39);
            this.groupBoxCompareCondition.Controls.Add(this.numericUpDownNoOfClosing);
            this.groupBoxCompareCondition.Controls.Add(this.label38);
            this.groupBoxCompareCondition.Controls.Add(this.numericUpDownSmoothWindowSize);
            this.groupBoxCompareCondition.Controls.Add(this.label37);
            this.groupBoxCompareCondition.Controls.Add(this.label41);
            this.groupBoxCompareCondition.Controls.Add(this.numericUpDownOffSet);
            this.groupBoxCompareCondition.Location = new System.Drawing.Point(34, 14);
            this.groupBoxCompareCondition.Name = "groupBoxCompareCondition";
            this.groupBoxCompareCondition.Size = new System.Drawing.Size(375, 224);
            this.groupBoxCompareCondition.TabIndex = 16;
            this.groupBoxCompareCondition.TabStop = false;
            this.groupBoxCompareCondition.Text = "Condition ";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(221, 32);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(87, 12);
            this.label44.TabIndex = 41;
            this.label44.Text = "欲選擇何種Case";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "(2)",
            "(3)"});
            this.comboBox1.Location = new System.Drawing.Point(314, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(55, 20);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.Text = "(2)";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(234, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 50);
            this.button4.TabIndex = 18;
            this.button4.Text = "Auto";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label43.Location = new System.Drawing.Point(283, 59);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(68, 37);
            this.label43.TabIndex = 39;
            this.label43.Text = "No.";
            // 
            // numericUpDownMaxArea
            // 
            this.numericUpDownMaxArea.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownMaxArea.Location = new System.Drawing.Point(140, 171);
            this.numericUpDownMaxArea.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDownMaxArea.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownMaxArea.Name = "numericUpDownMaxArea";
            this.numericUpDownMaxArea.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownMaxArea.TabIndex = 9;
            this.numericUpDownMaxArea.Value = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(221, 61);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 12);
            this.label42.TabIndex = 38;
            this.label42.Text = "影像編號:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(37, 173);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(54, 12);
            this.label40.TabIndex = 8;
            this.label40.Text = "Max. Area";
            // 
            // numericUpDownMinArea
            // 
            this.numericUpDownMinArea.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownMinArea.Location = new System.Drawing.Point(140, 138);
            this.numericUpDownMinArea.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownMinArea.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownMinArea.Name = "numericUpDownMinArea";
            this.numericUpDownMinArea.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownMinArea.TabIndex = 7;
            this.numericUpDownMinArea.Value = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(37, 140);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(52, 12);
            this.label39.TabIndex = 6;
            this.label39.Text = "Min. Area";
            // 
            // numericUpDownNoOfClosing
            // 
            this.numericUpDownNoOfClosing.Location = new System.Drawing.Point(140, 94);
            this.numericUpDownNoOfClosing.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownNoOfClosing.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownNoOfClosing.Name = "numericUpDownNoOfClosing";
            this.numericUpDownNoOfClosing.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownNoOfClosing.TabIndex = 5;
            this.numericUpDownNoOfClosing.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(37, 95);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(74, 12);
            this.label38.TabIndex = 4;
            this.label38.Text = "No. of Closing";
            // 
            // numericUpDownSmoothWindowSize
            // 
            this.numericUpDownSmoothWindowSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSmoothWindowSize.Location = new System.Drawing.Point(140, 62);
            this.numericUpDownSmoothWindowSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSmoothWindowSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSmoothWindowSize.Name = "numericUpDownSmoothWindowSize";
            this.numericUpDownSmoothWindowSize.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownSmoothWindowSize.TabIndex = 3;
            this.numericUpDownSmoothWindowSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(37, 63);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(87, 12);
            this.label37.TabIndex = 2;
            this.label37.Text = "Smoothing  Mask";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(37, 32);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(82, 12);
            this.label41.TabIndex = 1;
            this.label41.Text = "Compare Offset ";
            // 
            // numericUpDownOffSet
            // 
            this.numericUpDownOffSet.Location = new System.Drawing.Point(140, 30);
            this.numericUpDownOffSet.Name = "numericUpDownOffSet";
            this.numericUpDownOffSet.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownOffSet.TabIndex = 0;
            this.numericUpDownOffSet.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // buttonFindDiff
            // 
            this.buttonFindDiff.Location = new System.Drawing.Point(151, 250);
            this.buttonFindDiff.Name = "buttonFindDiff";
            this.buttonFindDiff.Size = new System.Drawing.Size(102, 50);
            this.buttonFindDiff.TabIndex = 15;
            this.buttonFindDiff.Text = "Find Difference";
            this.buttonFindDiff.UseVisualStyleBackColor = true;
            this.buttonFindDiff.Click += new System.EventHandler(this.buttonFindDiff_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Ini_LearnPattern_Btn
            // 
            this.Ini_LearnPattern_Btn.Location = new System.Drawing.Point(604, 20);
            this.Ini_LearnPattern_Btn.Name = "Ini_LearnPattern_Btn";
            this.Ini_LearnPattern_Btn.Size = new System.Drawing.Size(122, 27);
            this.Ini_LearnPattern_Btn.TabIndex = 38;
            this.Ini_LearnPattern_Btn.Text = "Initial learn pattern";
            this.Ini_LearnPattern_Btn.UseVisualStyleBackColor = true;
            this.Ini_LearnPattern_Btn.Click += new System.EventHandler(this.Ini_LearnPattern_Btn_Click);
            // 
            // FormSF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1235, 846);
            this.Controls.Add(this.Ini_LearnPattern_Btn);
            this.Controls.Add(this.tabControlShapeFinder);
            this.Controls.Add(this.comboBoxImageType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numericUpDownScale2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericUpDownScale1);
            this.Controls.Add(this.LabelScale);
            this.Controls.Add(this.tabControlPRNCC);
            this.Controls.Add(this.hWindowControl2);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.textBoxNoOfData);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.dataGridViewPostureData);
            this.Controls.Add(this.comboBoxDir);
            this.Controls.Add(this.MainmenuStrip);
            this.Name = "FormSF";
            this.Text = "Pattern Learning and Matching -- Shape & NCC  Model";
            this.MainmenuStrip.ResumeLayout(false);
            this.MainmenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPostureData)).EndInit();
            this.tabControlPRNCC.ResumeLayout(false);
            this.tabPageExtractPattern.ResumeLayout(false);
            this.tabPageExtractPattern.PerformLayout();
            this.groupBoxROI.ResumeLayout(false);
            this.groupBoxROI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStep)).EndInit();
            this.tabPageNCC.ResumeLayout(false);
            this.tabPageNCC.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlapRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleStart)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFGreediness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFMinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFOverlapRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFNoOfMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSFAngleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale2)).EndInit();
            this.tabControlShapeFinder.ResumeLayout(false);
            this.tabPageGeometryTransform.ResumeLayout(false);
            this.groupBoxAffineTransform.ResumeLayout(false);
            this.groupBoxAffineTransform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransform_Scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBoxCompareCondition.ResumeLayout(false);
            this.groupBoxCompareCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfClosing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffSet)).EndInit();
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
        private System.Windows.Forms.TabControl tabControlPRNCC;
        private System.Windows.Forms.TabPage tabPageExtractPattern;
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
        private System.Windows.Forms.TabPage tabPageNCC;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.Button buttonSetPRPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxImageType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxSaveFilename;
        private System.Windows.Forms.TabControl tabControlShapeFinder;
        private System.Windows.Forms.TabPage tabPageGeometryTransform;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonSFLearn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownSFGreediness;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxSFOptimization;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownAngleStep;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBoxSFSubpixel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDownSFOverlapRatio;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown numericUpDownSFNoOfMatch;
        private System.Windows.Forms.NumericUpDown numericUpDownSFAngleExtent;
        private System.Windows.Forms.NumericUpDown numericUpDownSFAngleStart;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button buttonSFbyFunction;
        private System.Windows.Forms.Button buttonSF;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAffineTransform;
        private System.Windows.Forms.GroupBox groupBoxAffineTransform;
        private System.Windows.Forms.NumericUpDown numericUpDownTransform_Scale;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterY;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterX;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox texb_Port;
        private System.Windows.Forms.Button Click_ClienConnect;
        private System.Windows.Forms.TextBox texb_IP;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonSegment;
        private System.Windows.Forms.GroupBox groupBoxCompareCondition;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxArea;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown numericUpDownMinArea;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown numericUpDownNoOfClosing;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.NumericUpDown numericUpDownSmoothWindowSize;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.NumericUpDown numericUpDownOffSet;
        private System.Windows.Forms.Button buttonFindDiff;
        private System.Windows.Forms.Button buttonMatchAgain;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numericUpDownSFMinScore;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Ini_LearnPattern_Btn;
    }
}

