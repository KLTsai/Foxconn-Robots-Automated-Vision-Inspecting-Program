namespace PixeLinkU3_Acquisition
{
    partial class FormPixeLinkU3HalconAcquisition
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOperation = new System.Windows.Forms.TabPage();
            this.buttonStopCCD = new System.Windows.Forms.Button();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCCDType = new System.Windows.Forms.ComboBox();
            this.buttonGrab = new System.Windows.Forms.Button();
            this.buttonLive = new System.Windows.Forms.Button();
            this.tabPageSetParameter = new System.Windows.Forms.TabPage();
            this.lstRoiInfo = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonGetPixeLinkCCDInfo = new System.Windows.Forms.Button();
            this.txtMaxGain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinGain = new System.Windows.Forms.TextBox();
            this.lblMinGain = new System.Windows.Forms.Label();
            this.txtRoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageFocus = new System.Windows.Forms.TabPage();
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
            this.textBoxFocusCounter = new System.Windows.Forms.TextBox();
            this.hScrollBarFocusCounter = new System.Windows.Forms.HScrollBar();
            this.buttonManaulFocus = new System.Windows.Forms.Button();
            this.buttonAutoFocus = new System.Windows.Forms.Button();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hWindowControl = new HalconDotNet.HWindowControl();
            this.timerCheckLensPosition = new System.Windows.Forms.Timer(this.components);
            this.statusStripPixeLink = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIntensity = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpendTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPageOperation.SuspendLayout();
            this.tabPageSetParameter.SuspendLayout();
            this.tabPageFocus.SuspendLayout();
            this.groupBoxROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStep)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStripPixeLink.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOperation);
            this.tabControl1.Controls.Add(this.tabPageSetParameter);
            this.tabControl1.Controls.Add(this.tabPageFocus);
            this.tabControl1.Location = new System.Drawing.Point(878, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 429);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageOperation
            // 
            this.tabPageOperation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageOperation.Controls.Add(this.buttonStopCCD);
            this.tabPageOperation.Controls.Add(this.comboBoxFileType);
            this.tabPageOperation.Controls.Add(this.label12);
            this.tabPageOperation.Controls.Add(this.textBoxFilename);
            this.tabPageOperation.Controls.Add(this.buttonSaveImage);
            this.tabPageOperation.Controls.Add(this.label1);
            this.tabPageOperation.Controls.Add(this.comboBoxCCDType);
            this.tabPageOperation.Controls.Add(this.buttonGrab);
            this.tabPageOperation.Controls.Add(this.buttonLive);
            this.tabPageOperation.Location = new System.Drawing.Point(4, 22);
            this.tabPageOperation.Name = "tabPageOperation";
            this.tabPageOperation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOperation.Size = new System.Drawing.Size(310, 403);
            this.tabPageOperation.TabIndex = 0;
            this.tabPageOperation.Text = "Function";
            // 
            // buttonStopCCD
            // 
            this.buttonStopCCD.Location = new System.Drawing.Point(22, 338);
            this.buttonStopCCD.Name = "buttonStopCCD";
            this.buttonStopCCD.Size = new System.Drawing.Size(107, 50);
            this.buttonStopCCD.TabIndex = 11;
            this.buttonStopCCD.Text = "Stop";
            this.buttonStopCCD.UseVisualStyleBackColor = true;
            this.buttonStopCCD.Visible = false;
            this.buttonStopCCD.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Items.AddRange(new object[] {
            "bmp",
            "tif",
            "jpg",
            "png"});
            this.comboBoxFileType.Location = new System.Drawing.Point(211, 193);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(49, 20);
            this.comboBoxFileType.TabIndex = 10;
            this.comboBoxFileType.Text = "bmp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(82, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "Filename: ";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(150, 192);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(55, 22);
            this.textBoxFilename.TabIndex = 8;
            this.textBoxFilename.Text = "temp_";
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(153, 121);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(106, 56);
            this.buttonSaveImage.TabIndex = 7;
            this.buttonSaveImage.Text = "Save Image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select CCD Type";
            // 
            // comboBoxCCDType
            // 
            this.comboBoxCCDType.FormattingEnabled = true;
            this.comboBoxCCDType.Items.AddRange(new object[] {
            "[1] Point Grey Camera",
            "[0] PixeLINK USB3 Camera Release 4"});
            this.comboBoxCCDType.Location = new System.Drawing.Point(112, 16);
            this.comboBoxCCDType.Name = "comboBoxCCDType";
            this.comboBoxCCDType.Size = new System.Drawing.Size(192, 20);
            this.comboBoxCCDType.TabIndex = 5;
            this.comboBoxCCDType.Text = "[0] PixeLINK USB3 Camera Release 4";
            this.comboBoxCCDType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCCDType_SelectedIndexChanged);
            // 
            // buttonGrab
            // 
            this.buttonGrab.Location = new System.Drawing.Point(153, 51);
            this.buttonGrab.Name = "buttonGrab";
            this.buttonGrab.Size = new System.Drawing.Size(107, 53);
            this.buttonGrab.TabIndex = 3;
            this.buttonGrab.Text = "Grab";
            this.buttonGrab.UseVisualStyleBackColor = true;
            this.buttonGrab.Click += new System.EventHandler(this.buttonGrab_Click_1);
            // 
            // buttonLive
            // 
            this.buttonLive.Location = new System.Drawing.Point(22, 51);
            this.buttonLive.Name = "buttonLive";
            this.buttonLive.Size = new System.Drawing.Size(107, 51);
            this.buttonLive.TabIndex = 2;
            this.buttonLive.Text = "Live";
            this.buttonLive.UseVisualStyleBackColor = true;
            this.buttonLive.Click += new System.EventHandler(this.buttonLive_Click);
            // 
            // tabPageSetParameter
            // 
            this.tabPageSetParameter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageSetParameter.Controls.Add(this.lstRoiInfo);
            this.tabPageSetParameter.Controls.Add(this.label6);
            this.tabPageSetParameter.Controls.Add(this.buttonGetPixeLinkCCDInfo);
            this.tabPageSetParameter.Controls.Add(this.txtMaxGain);
            this.tabPageSetParameter.Controls.Add(this.label4);
            this.tabPageSetParameter.Controls.Add(this.txtMinGain);
            this.tabPageSetParameter.Controls.Add(this.lblMinGain);
            this.tabPageSetParameter.Controls.Add(this.txtRoi);
            this.tabPageSetParameter.Controls.Add(this.label3);
            this.tabPageSetParameter.Controls.Add(this.txtExposure);
            this.tabPageSetParameter.Controls.Add(this.label2);
            this.tabPageSetParameter.Controls.Add(this.txtGain);
            this.tabPageSetParameter.Controls.Add(this.label5);
            this.tabPageSetParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetParameter.Name = "tabPageSetParameter";
            this.tabPageSetParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetParameter.Size = new System.Drawing.Size(310, 403);
            this.tabPageSetParameter.TabIndex = 1;
            this.tabPageSetParameter.Text = "CCD Parameter";
            // 
            // lstRoiInfo
            // 
            this.lstRoiInfo.ItemHeight = 12;
            this.lstRoiInfo.Location = new System.Drawing.Point(37, 333);
            this.lstRoiInfo.Name = "lstRoiInfo";
            this.lstRoiInfo.Size = new System.Drawing.Size(224, 64);
            this.lstRoiInfo.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(89, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "ROI Parameter Info";
            // 
            // buttonGetPixeLinkCCDInfo
            // 
            this.buttonGetPixeLinkCCDInfo.Location = new System.Drawing.Point(47, 29);
            this.buttonGetPixeLinkCCDInfo.Name = "buttonGetPixeLinkCCDInfo";
            this.buttonGetPixeLinkCCDInfo.Size = new System.Drawing.Size(114, 33);
            this.buttonGetPixeLinkCCDInfo.TabIndex = 21;
            this.buttonGetPixeLinkCCDInfo.Text = "Get CCD Feature";
            this.buttonGetPixeLinkCCDInfo.UseVisualStyleBackColor = true;
            this.buttonGetPixeLinkCCDInfo.Click += new System.EventHandler(this.buttonGetPixeLinkCCDInfo_Click);
            // 
            // txtMaxGain
            // 
            this.txtMaxGain.Location = new System.Drawing.Point(141, 213);
            this.txtMaxGain.Name = "txtMaxGain";
            this.txtMaxGain.Size = new System.Drawing.Size(120, 22);
            this.txtMaxGain.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(45, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Max Gain (dB)";
            // 
            // txtMinGain
            // 
            this.txtMinGain.Location = new System.Drawing.Point(141, 169);
            this.txtMinGain.Name = "txtMinGain";
            this.txtMinGain.Size = new System.Drawing.Size(120, 22);
            this.txtMinGain.TabIndex = 18;
            // 
            // lblMinGain
            // 
            this.lblMinGain.Location = new System.Drawing.Point(45, 169);
            this.lblMinGain.Name = "lblMinGain";
            this.lblMinGain.Size = new System.Drawing.Size(80, 18);
            this.lblMinGain.TabIndex = 17;
            this.lblMinGain.Text = "Min Gain (dB)";
            // 
            // txtRoi
            // 
            this.txtRoi.Location = new System.Drawing.Point(141, 256);
            this.txtRoi.Name = "txtRoi";
            this.txtRoi.Size = new System.Drawing.Size(120, 22);
            this.txtRoi.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(45, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "ROI";
            // 
            // txtExposure
            // 
            this.txtExposure.Location = new System.Drawing.Point(141, 81);
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(120, 22);
            this.txtExposure.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(45, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Exposure (ms)";
            // 
            // txtGain
            // 
            this.txtGain.Location = new System.Drawing.Point(141, 125);
            this.txtGain.Name = "txtGain";
            this.txtGain.Size = new System.Drawing.Size(120, 22);
            this.txtGain.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(45, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Gain (dB)";
            // 
            // tabPageFocus
            // 
            this.tabPageFocus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageFocus.Controls.Add(this.groupBoxROI);
            this.tabPageFocus.Controls.Add(this.textBoxFocusCounter);
            this.tabPageFocus.Controls.Add(this.hScrollBarFocusCounter);
            this.tabPageFocus.Controls.Add(this.buttonManaulFocus);
            this.tabPageFocus.Controls.Add(this.buttonAutoFocus);
            this.tabPageFocus.Location = new System.Drawing.Point(4, 22);
            this.tabPageFocus.Name = "tabPageFocus";
            this.tabPageFocus.Size = new System.Drawing.Size(310, 403);
            this.tabPageFocus.TabIndex = 2;
            this.tabPageFocus.Text = "Auto/Manual Focus";
            this.tabPageFocus.Click += new System.EventHandler(this.tabPageFocus_Click);
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
            this.groupBoxROI.Location = new System.Drawing.Point(3, 14);
            this.groupBoxROI.Name = "groupBoxROI";
            this.groupBoxROI.Size = new System.Drawing.Size(304, 244);
            this.groupBoxROI.TabIndex = 5;
            this.groupBoxROI.TabStop = false;
            this.groupBoxROI.Text = "ROI Setting";
            this.groupBoxROI.Enter += new System.EventHandler(this.groupBoxROI_Enter);
            // 
            // buttonSetFocusROI
            // 
            this.buttonSetFocusROI.Location = new System.Drawing.Point(207, 172);
            this.buttonSetFocusROI.Name = "buttonSetFocusROI";
            this.buttonSetFocusROI.Size = new System.Drawing.Size(80, 31);
            this.buttonSetFocusROI.TabIndex = 15;
            this.buttonSetFocusROI.Text = "Set ROI";
            this.buttonSetFocusROI.UseVisualStyleBackColor = true;
            this.buttonSetFocusROI.Click += new System.EventHandler(this.buttonSetFocusROI_Click);
            // 
            // checkBoxDisplayROI
            // 
            this.checkBoxDisplayROI.AutoSize = true;
            this.checkBoxDisplayROI.Location = new System.Drawing.Point(206, 213);
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
            this.label11.Location = new System.Drawing.Point(204, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "Height";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "Width";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "Start Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 26);
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
            this.numericUpDownROIHeight.Location = new System.Drawing.Point(248, 138);
            this.numericUpDownROIHeight.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIHeight.Name = "numericUpDownROIHeight";
            this.numericUpDownROIHeight.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIHeight.TabIndex = 9;
            this.numericUpDownROIHeight.ValueChanged += new System.EventHandler(this.numericUpDownROIHeight_ValueChanged);
            // 
            // numericUpDownROIWidth
            // 
            this.numericUpDownROIWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIWidth.Location = new System.Drawing.Point(248, 104);
            this.numericUpDownROIWidth.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIWidth.Name = "numericUpDownROIWidth";
            this.numericUpDownROIWidth.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIWidth.TabIndex = 8;
            this.numericUpDownROIWidth.ValueChanged += new System.EventHandler(this.numericUpDownROIWidth_ValueChanged);
            // 
            // numericUpDownROIStartY
            // 
            this.numericUpDownROIStartY.Location = new System.Drawing.Point(248, 61);
            this.numericUpDownROIStartY.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIStartY.Name = "numericUpDownROIStartY";
            this.numericUpDownROIStartY.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIStartY.TabIndex = 7;
            this.numericUpDownROIStartY.ValueChanged += new System.EventHandler(this.numericUpDownROIStartY_ValueChanged);
            // 
            // numericUpDownROIStartX
            // 
            this.numericUpDownROIStartX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownROIStartX.Location = new System.Drawing.Point(248, 21);
            this.numericUpDownROIStartX.Maximum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.numericUpDownROIStartX.Name = "numericUpDownROIStartX";
            this.numericUpDownROIStartX.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownROIStartX.TabIndex = 6;
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
            this.buttonROIDown.Location = new System.Drawing.Point(66, 157);
            this.buttonROIDown.Name = "buttonROIDown";
            this.buttonROIDown.Size = new System.Drawing.Size(55, 47);
            this.buttonROIDown.TabIndex = 3;
            this.buttonROIDown.Text = "Down";
            this.buttonROIDown.UseVisualStyleBackColor = true;
            this.buttonROIDown.Click += new System.EventHandler(this.buttonROIDown_Click);
            // 
            // buttonROIRight
            // 
            this.buttonROIRight.Location = new System.Drawing.Point(119, 113);
            this.buttonROIRight.Name = "buttonROIRight";
            this.buttonROIRight.Size = new System.Drawing.Size(55, 47);
            this.buttonROIRight.TabIndex = 2;
            this.buttonROIRight.Text = "Right";
            this.buttonROIRight.UseVisualStyleBackColor = true;
            this.buttonROIRight.Click += new System.EventHandler(this.buttonROIRight_Click);
            // 
            // buttonROILeft
            // 
            this.buttonROILeft.Location = new System.Drawing.Point(14, 113);
            this.buttonROILeft.Name = "buttonROILeft";
            this.buttonROILeft.Size = new System.Drawing.Size(55, 47);
            this.buttonROILeft.TabIndex = 1;
            this.buttonROILeft.Text = "Left";
            this.buttonROILeft.UseVisualStyleBackColor = true;
            this.buttonROILeft.Click += new System.EventHandler(this.buttonROILeft_Click);
            // 
            // buttonROIUp
            // 
            this.buttonROIUp.Location = new System.Drawing.Point(66, 71);
            this.buttonROIUp.Name = "buttonROIUp";
            this.buttonROIUp.Size = new System.Drawing.Size(55, 45);
            this.buttonROIUp.TabIndex = 0;
            this.buttonROIUp.Text = "Up";
            this.buttonROIUp.UseVisualStyleBackColor = true;
            this.buttonROIUp.Click += new System.EventHandler(this.buttonROIUp_Click);
            // 
            // textBoxFocusCounter
            // 
            this.textBoxFocusCounter.Location = new System.Drawing.Point(114, 281);
            this.textBoxFocusCounter.Name = "textBoxFocusCounter";
            this.textBoxFocusCounter.Size = new System.Drawing.Size(55, 22);
            this.textBoxFocusCounter.TabIndex = 4;
            this.textBoxFocusCounter.Text = "13000";
            // 
            // hScrollBarFocusCounter
            // 
            this.hScrollBarFocusCounter.LargeChange = 1000;
            this.hScrollBarFocusCounter.Location = new System.Drawing.Point(18, 306);
            this.hScrollBarFocusCounter.Maximum = 34000;
            this.hScrollBarFocusCounter.Minimum = 13000;
            this.hScrollBarFocusCounter.Name = "hScrollBarFocusCounter";
            this.hScrollBarFocusCounter.Size = new System.Drawing.Size(256, 17);
            this.hScrollBarFocusCounter.SmallChange = 100;
            this.hScrollBarFocusCounter.TabIndex = 2;
            this.hScrollBarFocusCounter.Value = 13000;
            this.hScrollBarFocusCounter.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarFocusCounter_Scroll);
            // 
            // buttonManaulFocus
            // 
            this.buttonManaulFocus.Location = new System.Drawing.Point(175, 281);
            this.buttonManaulFocus.Name = "buttonManaulFocus";
            this.buttonManaulFocus.Size = new System.Drawing.Size(69, 22);
            this.buttonManaulFocus.TabIndex = 1;
            this.buttonManaulFocus.Text = "Focus";
            this.buttonManaulFocus.UseVisualStyleBackColor = true;
            this.buttonManaulFocus.Click += new System.EventHandler(this.buttonManaulFocus_Click);
            // 
            // buttonAutoFocus
            // 
            this.buttonAutoFocus.Location = new System.Drawing.Point(101, 338);
            this.buttonAutoFocus.Name = "buttonAutoFocus";
            this.buttonAutoFocus.Size = new System.Drawing.Size(92, 42);
            this.buttonAutoFocus.TabIndex = 0;
            this.buttonAutoFocus.Text = "Auto Focus";
            this.buttonAutoFocus.UseVisualStyleBackColor = true;
            this.buttonAutoFocus.Click += new System.EventHandler(this.buttonAutoFocus_Click);
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(878, 461);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(317, 217);
            this.richTextBoxInfo.TabIndex = 5;
            this.richTextBoxInfo.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hWindowControl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 666);
            this.panel1.TabIndex = 6;
            // 
            // hWindowControl
            // 
            this.hWindowControl.BackColor = System.Drawing.Color.Black;
            this.hWindowControl.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl.Location = new System.Drawing.Point(3, 3);
            this.hWindowControl.Name = "hWindowControl";
            this.hWindowControl.Size = new System.Drawing.Size(66, 69);
            this.hWindowControl.TabIndex = 0;
            this.hWindowControl.WindowSize = new System.Drawing.Size(66, 69);
            this.hWindowControl.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl_HMouseMove);
            // 
            // timerCheckLensPosition
            // 
            this.timerCheckLensPosition.Interval = 5;
            this.timerCheckLensPosition.Tick += new System.EventHandler(this.timerCheckLensPosition_Tick);
            // 
            // statusStripPixeLink
            // 
            this.statusStripPixeLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelXY,
            this.toolStripStatusLabelIntensity,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelSpendTime});
            this.statusStripPixeLink.Location = new System.Drawing.Point(0, 681);
            this.statusStripPixeLink.Name = "statusStripPixeLink";
            this.statusStripPixeLink.Size = new System.Drawing.Size(1210, 22);
            this.statusStripPixeLink.TabIndex = 7;
            this.statusStripPixeLink.Text = "statusStrip1";
            this.statusStripPixeLink.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStripPixeLink_ItemClicked);
            // 
            // toolStripStatusLabelXY
            // 
            this.toolStripStatusLabelXY.AutoSize = false;
            this.toolStripStatusLabelXY.Name = "toolStripStatusLabelXY";
            this.toolStripStatusLabelXY.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabelXY.Text = "(X, Y)  Gray";
            // 
            // toolStripStatusLabelIntensity
            // 
            this.toolStripStatusLabelIntensity.AutoSize = false;
            this.toolStripStatusLabelIntensity.Name = "toolStripStatusLabelIntensity";
            this.toolStripStatusLabelIntensity.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelIntensity.Text = "Intensity";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "Process Time";
            // 
            // toolStripStatusLabelSpendTime
            // 
            this.toolStripStatusLabelSpendTime.AutoSize = false;
            this.toolStripStatusLabelSpendTime.Name = "toolStripStatusLabelSpendTime";
            this.toolStripStatusLabelSpendTime.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelSpendTime.Text = "00.00 ms";
            // 
            // FormPixeLinkU3HalconAcquisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 703);
            this.Controls.Add(this.statusStripPixeLink);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormPixeLinkU3HalconAcquisition";
            this.Text = "TAVIS - U3 using Halcon Acquisition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPGU3HalconAcquisition_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPixeLinkU3HalconAcquisition_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOperation.ResumeLayout(false);
            this.tabPageOperation.PerformLayout();
            this.tabPageSetParameter.ResumeLayout(false);
            this.tabPageSetParameter.PerformLayout();
            this.tabPageFocus.ResumeLayout(false);
            this.tabPageFocus.PerformLayout();
            this.groupBoxROI.ResumeLayout(false);
            this.groupBoxROI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownROIStep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStripPixeLink.ResumeLayout(false);
            this.statusStripPixeLink.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOperation;
        private System.Windows.Forms.Button buttonLive;
        private System.Windows.Forms.TabPage tabPageSetParameter;
        private System.Windows.Forms.Button buttonGrab;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCCDType;
        private System.Windows.Forms.Button buttonGetPixeLinkCCDInfo;
        private System.Windows.Forms.TextBox txtMaxGain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinGain;
        private System.Windows.Forms.Label lblMinGain;
        private System.Windows.Forms.TextBox txtRoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstRoiInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPageFocus;
        private System.Windows.Forms.Button buttonAutoFocus;
        private System.Windows.Forms.Timer timerCheckLensPosition;
        private System.Windows.Forms.HScrollBar hScrollBarFocusCounter;
        private System.Windows.Forms.Button buttonManaulFocus;
        private System.Windows.Forms.TextBox textBoxFocusCounter;
        private System.Windows.Forms.GroupBox groupBoxROI;
        private System.Windows.Forms.Button buttonROIUp;
        private System.Windows.Forms.Button buttonROIDown;
        private System.Windows.Forms.Button buttonROIRight;
        private System.Windows.Forms.Button buttonROILeft;
        private HalconDotNet.HWindowControl hWindowControl;
        private System.Windows.Forms.StatusStrip statusStripPixeLink;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelXY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIntensity;
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
        private System.Windows.Forms.CheckBox checkBoxDisplayROI;
        private System.Windows.Forms.Button buttonSetFocusROI;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Button buttonStopCCD;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpendTime;
    }
}

