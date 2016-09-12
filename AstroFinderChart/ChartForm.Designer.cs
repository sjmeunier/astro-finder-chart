namespace AstroFinderChart
{
	partial class ChartForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
			this.butGenerate = new System.Windows.Forms.Button();
			this.butSave = new System.Windows.Forms.Button();
			this.cboLimitingMagnitude = new System.Windows.Forms.ComboBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtRAH = new System.Windows.Forms.TextBox();
			this.txtRAM = new System.Windows.Forms.TextBox();
			this.txtRAS = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboRadius = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDecS = new System.Windows.Forms.TextBox();
			this.txtDecM = new System.Windows.Forms.TextBox();
			this.txtDecD = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.picChart = new System.Windows.Forms.PictureBox();
			this.chkLimitDeepsky = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.chkShowLabels = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.butSearch = new System.Windows.Forms.Button();
			this.labInfo = new System.Windows.Forms.Label();
			this.labGenerating = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.chkInvertNS = new System.Windows.Forms.CheckBox();
			this.label17 = new System.Windows.Forms.Label();
			this.chkInvertEW = new System.Windows.Forms.CheckBox();
			this.label18 = new System.Windows.Forms.Label();
			this.chkInvertColors = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.cboResolution = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
			this.SuspendLayout();
			// 
			// butGenerate
			// 
			this.butGenerate.Location = new System.Drawing.Point(69, 376);
			this.butGenerate.Name = "butGenerate";
			this.butGenerate.Size = new System.Drawing.Size(75, 23);
			this.butGenerate.TabIndex = 1;
			this.butGenerate.Text = "&Generate";
			this.butGenerate.UseVisualStyleBackColor = true;
			this.butGenerate.Click += new System.EventHandler(this.butGenerate_Click);
			// 
			// butSave
			// 
			this.butSave.Location = new System.Drawing.Point(150, 376);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(75, 23);
			this.butSave.TabIndex = 2;
			this.butSave.Text = "&Save";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// cboLimitingMagnitude
			// 
			this.cboLimitingMagnitude.FormattingEnabled = true;
			this.cboLimitingMagnitude.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14"});
			this.cboLimitingMagnitude.Location = new System.Drawing.Point(114, 114);
			this.cboLimitingMagnitude.Name = "cboLimitingMagnitude";
			this.cboLimitingMagnitude.Size = new System.Drawing.Size(39, 21);
			this.cboLimitingMagnitude.TabIndex = 3;
			this.cboLimitingMagnitude.Text = "12";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(114, 88);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(121, 20);
			this.txtTitle.TabIndex = 4;
			this.txtTitle.Text = "M32";
			// 
			// txtRAH
			// 
			this.txtRAH.Location = new System.Drawing.Point(114, 141);
			this.txtRAH.Name = "txtRAH";
			this.txtRAH.Size = new System.Drawing.Size(30, 20);
			this.txtRAH.TabIndex = 5;
			this.txtRAH.Text = "0";
			// 
			// txtRAM
			// 
			this.txtRAM.Location = new System.Drawing.Point(161, 141);
			this.txtRAM.Name = "txtRAM";
			this.txtRAM.Size = new System.Drawing.Size(30, 20);
			this.txtRAM.TabIndex = 6;
			this.txtRAM.Text = "42";
			// 
			// txtRAS
			// 
			this.txtRAS.Location = new System.Drawing.Point(205, 141);
			this.txtRAS.Name = "txtRAS";
			this.txtRAS.Size = new System.Drawing.Size(30, 20);
			this.txtRAS.TabIndex = 7;
			this.txtRAS.Text = "44";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Limiting Magnitude";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Right Ascension";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 170);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Declination";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 193);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Radius";
			// 
			// cboRadius
			// 
			this.cboRadius.FormattingEnabled = true;
			this.cboRadius.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "1",
            "2",
            "4",
            "8"});
			this.cboRadius.Location = new System.Drawing.Point(114, 193);
			this.cboRadius.Name = "cboRadius";
			this.cboRadius.Size = new System.Drawing.Size(39, 21);
			this.cboRadius.TabIndex = 12;
			this.cboRadius.Text = "4";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(152, 196);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(11, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "°";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(143, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(13, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "h";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Location = new System.Drawing.Point(190, 144);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(15, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "m";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Location = new System.Drawing.Point(234, 144);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "s";
			// 
			// txtDecS
			// 
			this.txtDecS.Location = new System.Drawing.Point(205, 167);
			this.txtDecS.Name = "txtDecS";
			this.txtDecS.Size = new System.Drawing.Size(30, 20);
			this.txtDecS.TabIndex = 20;
			this.txtDecS.Text = "8";
			// 
			// txtDecM
			// 
			this.txtDecM.Location = new System.Drawing.Point(161, 167);
			this.txtDecM.Name = "txtDecM";
			this.txtDecM.Size = new System.Drawing.Size(30, 20);
			this.txtDecM.TabIndex = 19;
			this.txtDecM.Text = "16";
			// 
			// txtDecD
			// 
			this.txtDecD.Location = new System.Drawing.Point(114, 167);
			this.txtDecD.Name = "txtDecD";
			this.txtDecD.Size = new System.Drawing.Size(30, 20);
			this.txtDecD.TabIndex = 18;
			this.txtDecD.Text = "41";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Location = new System.Drawing.Point(234, 170);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(12, 13);
			this.label10.TabIndex = 23;
			this.label10.Text = "\"";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Location = new System.Drawing.Point(190, 170);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(9, 13);
			this.label11.TabIndex = 22;
			this.label11.Text = "\'";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Location = new System.Drawing.Point(143, 170);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(11, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "°";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// picChart
			// 
			this.picChart.BackColor = System.Drawing.Color.White;
			this.picChart.Location = new System.Drawing.Point(248, 0);
			this.picChart.Name = "picChart";
			this.picChart.Size = new System.Drawing.Size(800, 800);
			this.picChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picChart.TabIndex = 0;
			this.picChart.TabStop = false;
			// 
			// chkLimitDeepsky
			// 
			this.chkLimitDeepsky.AutoSize = true;
			this.chkLimitDeepsky.Checked = true;
			this.chkLimitDeepsky.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkLimitDeepsky.Location = new System.Drawing.Point(114, 221);
			this.chkLimitDeepsky.Name = "chkLimitDeepsky";
			this.chkLimitDeepsky.Size = new System.Drawing.Size(15, 14);
			this.chkLimitDeepsky.TabIndex = 24;
			this.chkLimitDeepsky.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(12, 221);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(102, 13);
			this.label13.TabIndex = 25;
			this.label13.Text = "Limit Deep Sky Mag";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(12, 246);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(68, 13);
			this.label14.TabIndex = 27;
			this.label14.Text = "Show Labels";
			// 
			// chkShowLabels
			// 
			this.chkShowLabels.AutoSize = true;
			this.chkShowLabels.Checked = true;
			this.chkShowLabels.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowLabels.Location = new System.Drawing.Point(114, 246);
			this.chkShowLabels.Name = "chkShowLabels";
			this.chkShowLabels.Size = new System.Drawing.Size(15, 14);
			this.chkShowLabels.TabIndex = 26;
			this.chkShowLabels.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(12, 15);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(41, 13);
			this.label15.TabIndex = 29;
			this.label15.Text = "Search";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(114, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(121, 20);
			this.txtSearch.TabIndex = 28;
			// 
			// butSearch
			// 
			this.butSearch.Location = new System.Drawing.Point(161, 38);
			this.butSearch.Name = "butSearch";
			this.butSearch.Size = new System.Drawing.Size(75, 23);
			this.butSearch.TabIndex = 30;
			this.butSearch.Text = "&Search";
			this.butSearch.UseVisualStyleBackColor = true;
			this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
			// 
			// labInfo
			// 
			this.labInfo.Location = new System.Drawing.Point(12, 412);
			this.labInfo.Name = "labInfo";
			this.labInfo.Size = new System.Drawing.Size(337, 303);
			this.labInfo.TabIndex = 31;
			this.labInfo.Click += new System.EventHandler(this.labInfo_Click);
			// 
			// labGenerating
			// 
			this.labGenerating.BackColor = System.Drawing.Color.White;
			this.labGenerating.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labGenerating.Location = new System.Drawing.Point(248, 0);
			this.labGenerating.Name = "labGenerating";
			this.labGenerating.Size = new System.Drawing.Size(800, 800);
			this.labGenerating.TabIndex = 32;
			this.labGenerating.Text = "Generating....";
			this.labGenerating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labGenerating.Visible = false;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(12, 270);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(55, 13);
			this.label16.TabIndex = 34;
			this.label16.Text = "Invert N-S";
			// 
			// chkInvertNS
			// 
			this.chkInvertNS.AutoSize = true;
			this.chkInvertNS.Location = new System.Drawing.Point(114, 270);
			this.chkInvertNS.Name = "chkInvertNS";
			this.chkInvertNS.Size = new System.Drawing.Size(15, 14);
			this.chkInvertNS.TabIndex = 33;
			this.chkInvertNS.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(12, 293);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 13);
			this.label17.TabIndex = 36;
			this.label17.Text = "Invert E-W";
			// 
			// chkInvertEW
			// 
			this.chkInvertEW.AutoSize = true;
			this.chkInvertEW.Location = new System.Drawing.Point(114, 293);
			this.chkInvertEW.Name = "chkInvertEW";
			this.chkInvertEW.Size = new System.Drawing.Size(15, 14);
			this.chkInvertEW.TabIndex = 35;
			this.chkInvertEW.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(12, 315);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(66, 13);
			this.label18.TabIndex = 38;
			this.label18.Text = "Invert Colors";
			// 
			// chkInvertColors
			// 
			this.chkInvertColors.AutoSize = true;
			this.chkInvertColors.Location = new System.Drawing.Point(114, 315);
			this.chkInvertColors.Name = "chkInvertColors";
			this.chkInvertColors.Size = new System.Drawing.Size(15, 14);
			this.chkInvertColors.TabIndex = 37;
			this.chkInvertColors.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(12, 341);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(57, 13);
			this.label19.TabIndex = 39;
			this.label19.Text = "Resolution";
			// 
			// cboResolution
			// 
			this.cboResolution.FormattingEnabled = true;
			this.cboResolution.Items.AddRange(new object[] {
            "1000x1000",
            "2000x2000",
            "4000x4000",
            "8000x8000",
            "12000x12000"});
			this.cboResolution.Location = new System.Drawing.Point(114, 338);
			this.cboResolution.Name = "cboResolution";
			this.cboResolution.Size = new System.Drawing.Size(121, 21);
			this.cboResolution.TabIndex = 40;
			this.cboResolution.Text = "8000x8000";
			// 
			// ChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1048, 800);
			this.Controls.Add(this.cboResolution);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.chkInvertColors);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.chkInvertEW);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.chkInvertNS);
			this.Controls.Add(this.labGenerating);
			this.Controls.Add(this.butSearch);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.chkShowLabels);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.chkLimitDeepsky);
			this.Controls.Add(this.txtDecS);
			this.Controls.Add(this.txtDecM);
			this.Controls.Add(this.txtDecD);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cboRadius);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRAS);
			this.Controls.Add(this.txtRAM);
			this.Controls.Add(this.txtRAH);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.cboLimitingMagnitude);
			this.Controls.Add(this.butSave);
			this.Controls.Add(this.butGenerate);
			this.Controls.Add(this.picChart);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.labInfo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ChartForm";
			this.Text = "ChartForm";
			this.Load += new System.EventHandler(this.ChartForm_Load);
			this.Resize += new System.EventHandler(this.ChartForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.picChart)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button butGenerate;
        private System.Windows.Forms.Button butSave;
		private System.Windows.Forms.ComboBox cboLimitingMagnitude;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtRAH;
		private System.Windows.Forms.TextBox txtRAM;
		private System.Windows.Forms.TextBox txtRAS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboRadius;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDecS;
		private System.Windows.Forms.TextBox txtDecM;
		private System.Windows.Forms.TextBox txtDecD;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.PictureBox picChart;
		private System.Windows.Forms.CheckBox chkLimitDeepsky;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.CheckBox chkShowLabels;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button butSearch;
		private System.Windows.Forms.Label labInfo;
		private System.Windows.Forms.Label labGenerating;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.CheckBox chkInvertNS;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.CheckBox chkInvertEW;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.CheckBox chkInvertColors;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cboResolution;
	}
}