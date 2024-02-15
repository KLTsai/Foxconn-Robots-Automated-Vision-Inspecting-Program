namespace PG_CCD_U3_Acquisition
{
    partial class FormPGU3HalconAcquisition
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOperation = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCCDType = new System.Windows.Forms.ComboBox();
            this.buttonGetCCDInfo = new System.Windows.Forms.Button();
            this.buttonGrab = new System.Windows.Forms.Button();
            this.buttonLive = new System.Windows.Forms.Button();
            this.tabPageSetParameter = new System.Windows.Forms.TabPage();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOperation);
            this.tabControl1.Controls.Add(this.tabPageSetParameter);
            this.tabControl1.Location = new System.Drawing.Point(878, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 429);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageOperation
            // 
            this.tabPageOperation.Controls.Add(this.button2);
            this.tabPageOperation.Controls.Add(this.button1);
            this.tabPageOperation.Controls.Add(this.buttonSave);
            this.tabPageOperation.Controls.Add(this.label1);
            this.tabPageOperation.Controls.Add(this.comboBoxCCDType);
            this.tabPageOperation.Controls.Add(this.buttonGetCCDInfo);
            this.tabPageOperation.Controls.Add(this.buttonGrab);
            this.tabPageOperation.Controls.Add(this.buttonLive);
            this.tabPageOperation.Location = new System.Drawing.Point(4, 22);
            this.tabPageOperation.Name = "tabPageOperation";
            this.tabPageOperation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOperation.Size = new System.Drawing.Size(310, 403);
            this.tabPageOperation.TabIndex = 0;
            this.tabPageOperation.Text = "Function";
            this.tabPageOperation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 52);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(153, 41);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 55);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
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
            // buttonGetCCDInfo
            // 
            this.buttonGetCCDInfo.Location = new System.Drawing.Point(22, 173);
            this.buttonGetCCDInfo.Name = "buttonGetCCDInfo";
            this.buttonGetCCDInfo.Size = new System.Drawing.Size(107, 56);
            this.buttonGetCCDInfo.TabIndex = 4;
            this.buttonGetCCDInfo.Text = "Get CCD Info";
            this.buttonGetCCDInfo.UseVisualStyleBackColor = true;
            this.buttonGetCCDInfo.Click += new System.EventHandler(this.buttonGetCCDInfo_Click);
            // 
            // buttonGrab
            // 
            this.buttonGrab.Location = new System.Drawing.Point(153, 107);
            this.buttonGrab.Name = "buttonGrab";
            this.buttonGrab.Size = new System.Drawing.Size(107, 53);
            this.buttonGrab.TabIndex = 3;
            this.buttonGrab.Text = "Grab";
            this.buttonGrab.UseVisualStyleBackColor = true;
            this.buttonGrab.Click += new System.EventHandler(this.buttonGrab_Click_1);
            // 
            // buttonLive
            // 
            this.buttonLive.Location = new System.Drawing.Point(22, 107);
            this.buttonLive.Name = "buttonLive";
            this.buttonLive.Size = new System.Drawing.Size(107, 51);
            this.buttonLive.TabIndex = 2;
            this.buttonLive.Text = "Live";
            this.buttonLive.UseVisualStyleBackColor = true;
            this.buttonLive.Click += new System.EventHandler(this.buttonLive_Click);
            // 
            // tabPageSetParameter
            // 
            this.tabPageSetParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetParameter.Name = "tabPageSetParameter";
            this.tabPageSetParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetParameter.Size = new System.Drawing.Size(310, 403);
            this.tabPageSetParameter.TabIndex = 1;
            this.tabPageSetParameter.Text = "CCD Parameter";
            this.tabPageSetParameter.UseVisualStyleBackColor = true;
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(878, 461);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(317, 117);
            this.richTextBoxInfo.TabIndex = 5;
            this.richTextBoxInfo.Text = "";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 566);
            this.panel1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 52);
            this.button2.TabIndex = 9;
            this.button2.Text = "try Barcode Reading";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormPGU3HalconAcquisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 662);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormPGU3HalconAcquisition";
            this.Text = "Point Grey -- U3 using Halcon Acquisition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPGU3HalconAcquisition_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOperation.ResumeLayout(false);
            this.tabPageOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOperation;
        private System.Windows.Forms.Button buttonLive;
        private System.Windows.Forms.TabPage tabPageSetParameter;
        private System.Windows.Forms.Button buttonGrab;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Button buttonGetCCDInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCCDType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

