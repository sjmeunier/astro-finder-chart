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
            this._chartBitmap = this._finderChart.CreateChart();
            picChart.Image = this._chartBitmap;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (this._chartBitmap != null) {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this._chartBitmap.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }
    }
}
