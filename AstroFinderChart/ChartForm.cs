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

		private void Generate()
		{
			labGenerating.Visible = true;
			Application.DoEvents();

			string title = txtTitle.Text;
			int limitingMagnitude = int.Parse(cboLimitingMagnitude.Text);
			float radius = float.Parse(cboRadius.Text);
			float ra = (int.Parse(txtRAH.Text) + int.Parse(txtRAM.Text) / 60f + float.Parse(txtRAS.Text) / 3600f) * 15f;
			int decD = int.Parse(txtDecD.Text);

			float decl = (int)Math.Abs(int.Parse(txtDecD.Text)) + int.Parse(txtDecM.Text) / 60f + float.Parse(txtDecS.Text) / 3600f;

			if (decD < 0)
				decl *= -1;

			this._finderChart.SetFieldView(8400, limitingMagnitude, MathExt.Deg2Rad(radius), MathExt.Deg2Rad(ra), MathExt.Deg2Rad(decl), title, chkLimitDeepsky.Checked, chkShowLabels.Checked);

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

			labGenerating.Visible = false;
			Application.DoEvents();

		}

		private void butGenerate_Click(object sender, EventArgs e)
        {
			Generate();
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

		private void SetSearchResult(float rightAscension, float declination, string title)
		{
			txtTitle.Text = title;

			int rah = (int)Math.Floor(rightAscension * 12 / (float)Math.PI);
			int ram = (int)Math.Floor((rightAscension * 12 / (float)Math.PI - rah) * 60);
			int ras = (int)Math.Floor(((rightAscension * 12 / (float)Math.PI - rah) * 60 - ram) * 60 + 0.5);

			if (ras == 60)
			{
				ram += 1;
				ras = 0;
			}
			if (ram == 60)
			{
				rah += 1;
				ram = 0;
			}
			if (rah == 24)
			{
				rah = 0;
			}

			int decSign = 1;
			if (declination < 0)
				decSign = -1;

			int decd = (int)Math.Floor(Math.Abs(declination) * 180 / (float)Math.PI);
			int decm = (int)Math.Floor((Math.Abs(declination) * 180 / (float)Math.PI - decd) * 60);
			int decs = (int)Math.Floor(((Math.Abs(declination) * 180 / (float)Math.PI - decd) * 60 - decm) * 60 + 0.5);

			if (decs == 60)
			{
				decm += 1;
				decs = 0;
			}
			if (decm == 60)
			{
				decd += 1;
				decm = 0;
			}
			txtDecD.Text = string.Format("{0}", decSign * decd);
			txtDecM.Text = string.Format("{0}", decm);
			txtDecS.Text = string.Format("{0}", decs);
			txtRAH.Text = string.Format("{0}", rah);
			txtRAM.Text = string.Format("{0}", ram);
			txtRAS.Text = string.Format("{0}", ras);
		}

		private void SetDeepSkyInfo(DeepSkyObject deepSkyObject)
		{
			StringBuilder info = new StringBuilder();

			
			bool first = true;
			foreach(string name in deepSkyObject.AllNames)
			{
				if (first)
					info.AppendLine(string.Format("{0,-12}{1}", "Name:", name));
				else
					info.AppendLine(string.Format("{0,-12}{1}", "", name));
				first = false;
			}
			info.AppendLine(string.Format("{0,-12}{1}", "Magnitude:", deepSkyObject.Magnitude));
			info.AppendLine(string.Format("{0,-12}{1}", "Const:", deepSkyObject.Constellation));
			info.AppendLine(string.Format("{0,-12}{1}", "Type:", deepSkyObject.Type.ToString()));
			if (deepSkyObject.LongDimension != deepSkyObject.ShortDimension)
			{
				info.AppendLine(string.Format("{0,-12}{1}'", "Length:", MathExt.Round(MathExt.Rad2Deg(deepSkyObject.LongDimension) * 60f, 2)));
				info.AppendLine(string.Format("{0,-12}{1}'", "Width:", MathExt.Round(MathExt.Rad2Deg(deepSkyObject.ShortDimension) * 60f, 2)));
				info.AppendLine(string.Format("{0,-12}{1}°", "Pos angle:", MathExt.Round(MathExt.Rad2Deg(deepSkyObject.PositionAngle), 2)));
			} else
			{
				info.AppendLine(string.Format("{0,-12}{1}'", "Diameter:", MathExt.Round(MathExt.Rad2Deg(deepSkyObject.LongDimension) / 60f, 2)));
			}
			labInfo.Font = new Font(FontFamily.GenericMonospace, 8);
			labInfo.Text = info.ToString();
		}

		private void SetStarInfo(StarLabel star)
		{
			StringBuilder info = new StringBuilder();


			bool first = true;
			foreach (string name in star.AllNames)
			{
				if (first)
					info.AppendLine(string.Format("{0,-12}{1}", "Name:", name));
				else
					info.AppendLine(string.Format("{0,-12}{1}", "", name));
				first = false;
			}
			info.AppendLine(string.Format("{0,-12}{1}", "Magnitude:", star.Magnitude));
			info.AppendLine(string.Format("{0,-12}{1}", "Spec Type:", star.SpectralType));

			labInfo.Font = new Font(FontFamily.GenericMonospace, 8);
			labInfo.Text = info.ToString();
		}

		private void butSearch_Click(object sender, EventArgs e)
		{
			string searchTerm = txtSearch.Text.Replace(" ", "").ToUpper();
			bool found = false;
			foreach(DeepSkyObject deepSkyObject in this._finderChart.DeepSkyCatalog.DeepSkyObjects)
			{
				if (deepSkyObject.AllNamesSearch.Contains(searchTerm))
				{
					SetSearchResult(deepSkyObject.Coordinates.RightAscension, deepSkyObject.Coordinates.Declination, deepSkyObject.Catalog + deepSkyObject.Name);
					SetDeepSkyInfo(deepSkyObject);
					found = true;
					break;
				}
			}

			if (!found)
			{
				foreach (StarLabel star in this._finderChart.StarLabels.Stars)
				{
					if (star.AllNamesSearch.Contains(searchTerm))
					{
						SetSearchResult(star.Coordinates.RightAscension, star.Coordinates.Declination, star.Name);
						SetStarInfo(star);
						found = true;
						break;
					}
				}

			}

			if (found)
			{
				Application.DoEvents();
				Generate();
			}
		}

		private void ChartForm_Resize(object sender, EventArgs e)
		{
			picChart.Width = this.ClientSize.Width - picChart.Left;
			picChart.Height = this.ClientSize.Height;
			labGenerating.Width = picChart.Width;
			labGenerating.Height = picChart.Height;
			labGenerating.Left = picChart.Left;
			labGenerating.Top = picChart.Top;
		}


	}
}
