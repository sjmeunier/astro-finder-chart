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
			((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
			this.SuspendLayout();
			// 
			// butGenerate
			// 
			this.butGenerate.Location = new System.Drawing.Point(15, 184);
			this.butGenerate.Name = "butGenerate";
			this.butGenerate.Size = new System.Drawing.Size(75, 23);
			this.butGenerate.TabIndex = 1;
			this.butGenerate.Text = "&Generate";
			this.butGenerate.UseVisualStyleBackColor = true;
			this.butGenerate.Click += new System.EventHandler(this.butGenerate_Click);
			// 
			// butSave
			// 
			this.butSave.Location = new System.Drawing.Point(96, 184);
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
			this.cboLimitingMagnitude.Location = new System.Drawing.Point(114, 45);
			this.cboLimitingMagnitude.Name = "cboLimitingMagnitude";
			this.cboLimitingMagnitude.Size = new System.Drawing.Size(39, 21);
			this.cboLimitingMagnitude.TabIndex = 3;
			this.cboLimitingMagnitude.Text = "12";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(114, 19);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(121, 20);
			this.txtTitle.TabIndex = 4;
			// 
			// txtRAH
			// 
			this.txtRAH.Location = new System.Drawing.Point(114, 72);
			this.txtRAH.Name = "txtRAH";
			this.txtRAH.Size = new System.Drawing.Size(30, 20);
			this.txtRAH.TabIndex = 5;
			this.txtRAH.Text = "0";
			// 
			// txtRAM
			// 
			this.txtRAM.Location = new System.Drawing.Point(161, 72);
			this.txtRAM.Name = "txtRAM";
			this.txtRAM.Size = new System.Drawing.Size(30, 20);
			this.txtRAM.TabIndex = 6;
			this.txtRAM.Text = "42";
			// 
			// txtRAS
			// 
			this.txtRAS.Location = new System.Drawing.Point(205, 72);
			this.txtRAS.Name = "txtRAS";
			this.txtRAS.Size = new System.Drawing.Size(30, 20);
			this.txtRAS.TabIndex = 7;
			this.txtRAS.Text = "44";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Limiting Magnitude";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Right Ascension";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Declination";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 124);
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
			this.cboRadius.Location = new System.Drawing.Point(114, 124);
			this.cboRadius.Name = "cboRadius";
			this.cboRadius.Size = new System.Drawing.Size(39, 21);
			this.cboRadius.TabIndex = 12;
			this.cboRadius.Text = "4";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(152, 127);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(11, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "°";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(143, 75);
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
			this.label8.Location = new System.Drawing.Point(190, 75);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(15, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "m";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Location = new System.Drawing.Point(234, 75);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "s";
			// 
			// txtDecS
			// 
			this.txtDecS.Location = new System.Drawing.Point(205, 98);
			this.txtDecS.Name = "txtDecS";
			this.txtDecS.Size = new System.Drawing.Size(30, 20);
			this.txtDecS.TabIndex = 20;
			this.txtDecS.Text = "8";
			// 
			// txtDecM
			// 
			this.txtDecM.Location = new System.Drawing.Point(161, 98);
			this.txtDecM.Name = "txtDecM";
			this.txtDecM.Size = new System.Drawing.Size(30, 20);
			this.txtDecM.TabIndex = 19;
			this.txtDecM.Text = "16";
			// 
			// txtDecD
			// 
			this.txtDecD.Location = new System.Drawing.Point(114, 98);
			this.txtDecD.Name = "txtDecD";
			this.txtDecD.Size = new System.Drawing.Size(30, 20);
			this.txtDecD.TabIndex = 18;
			this.txtDecD.Text = "41";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Location = new System.Drawing.Point(234, 101);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(12, 13);
			this.label10.TabIndex = 23;
			this.label10.Text = "\"";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Location = new System.Drawing.Point(190, 101);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(9, 13);
			this.label11.TabIndex = 22;
			this.label11.Text = "\'";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Location = new System.Drawing.Point(143, 101);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(11, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "°";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// picChart
			// 
			this.picChart.Dock = System.Windows.Forms.DockStyle.Right;
			this.picChart.Location = new System.Drawing.Point(248, 0);
			this.picChart.Name = "picChart";
			this.picChart.Size = new System.Drawing.Size(800, 800);
			this.picChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picChart.TabIndex = 0;
			this.picChart.TabStop = false;
			// 
			// chkLimitDeepsky
			// 
			this.chkLimitDeepsky.AutoSize = true;
			this.chkLimitDeepsky.Checked = true;
			this.chkLimitDeepsky.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkLimitDeepsky.Location = new System.Drawing.Point(114, 152);
			this.chkLimitDeepsky.Name = "chkLimitDeepsky";
			this.chkLimitDeepsky.Size = new System.Drawing.Size(15, 14);
			this.chkLimitDeepsky.TabIndex = 24;
			this.chkLimitDeepsky.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(12, 152);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(102, 13);
			this.label13.TabIndex = 25;
			this.label13.Text = "Limit Deep Sky Mag";
			// 
			// ChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1048, 800);
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
			this.Name = "ChartForm";
			this.Text = "ChartForm";
			this.Load += new System.EventHandler(this.ChartForm_Load);
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
	}
}