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
			this.picChart = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
			this.SuspendLayout();
			// 
			// picChart
			// 
			this.picChart.Location = new System.Drawing.Point(330, 1);
			this.picChart.Name = "picChart";
			this.picChart.Size = new System.Drawing.Size(800, 800);
			this.picChart.TabIndex = 0;
			this.picChart.TabStop = false;
			// 
			// ChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1150, 809);
			this.Controls.Add(this.picChart);
			this.Name = "ChartForm";
			this.Text = "ChartForm";
			this.Load += new System.EventHandler(this.ChartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.picChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picChart;
	}
}