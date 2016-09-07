using FinderChartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstroFinderChart
{
	public partial class ChartForm : Form
	{
		private FinderChart _finderChart = new FinderChart();
        private Bitmap _chartBitmap = null;

		public ChartForm()
		{
			InitializeComponent();
		}

		private void ChartForm_Load(object sender, EventArgs e)
		{
	        
		}

        private void butGenerate_Click(object sender, EventArgs e)
        {
			string title = txtTitle.Text;
			int limitingMagnitude = int.Parse(cboLimitingMagnitude.Text);
			float radius = float.Parse(cboRadius.Text);
			float ra = (int.Parse(txtRAH.Text) + int.Parse(txtRAM.Text) / 60f + float.Parse(txtRAS.Text) / 3600f) * 15f;
			float decl = int.Parse(txtDecD.Text) + int.Parse(txtDecM.Text) / 60f + float.Parse(txtDecS.Text) / 3600f;

			this._finderChart.SetFieldView(8400, limitingMagnitude, MathExt.Deg2Rad(radius), MathExt.Deg2Rad(ra), MathExt.Deg2Rad(decl), title, chkLimitDeepsky.Checked);

			if (this._chartBitmap != null)
			{
				picChart.Image = null;
				this._chartBitmap.Dispose();
				this._chartBitmap = null;
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			this._chartBitmap = this._finderChart.CreateChart();
            picChart.Image = this._chartBitmap;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (this._chartBitmap != null) {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.AddExtension = true;
                dialog.DefaultExt = "png";
                dialog.Filter = "PNG files (*.png) | *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this._chartBitmap.Save(dialog.FileName, ImageFormat.Png);
                }
            }
        }

	}
}
