using FinderChartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstroFinderChart
{
	public partial class ChartForm : Form
	{
		private FinderChart finderChart = new FinderChart();

		public ChartForm()
		{
			InitializeComponent();
		}

		private void ChartForm_Load(object sender, EventArgs e)
		{
			picChart.Image = finderChart.CreateChart();
		}
	}
}
