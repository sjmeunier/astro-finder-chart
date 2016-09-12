using FinderChartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstroFinderChart
{
	public partial class ChartForm : Form
	{
		private FinderChart _finderChart;
        private Bitmap _chartBitmap = null;

		public ChartForm()
		{
			Thread t = new Thread(new ThreadStart(ShowSplash));
			t.Start();

			InitializeComponent();
			_finderChart = new FinderChart();
			LoadValues();

			t.Abort();
		}

		private void ShowSplash()
		{
			Application.Run(new Splash());
		}

		private void ChartForm_Load(object sender, EventArgs e)
		{


		}

		private void Generate()
		{
			if (txtSearch.Text.Trim() == string.Empty)
			{
				string searchTerm = txtTitle.Text.Replace(" ", "").ToUpper();
				bool found = false;
				foreach (DeepSkyObject deepSkyObject in this._finderChart.DeepSkyCatalog.DeepSkyObjects)
				{
					if (deepSkyObject.AllNamesSearch.Contains(searchTerm))
					{
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
							SetStarInfo(star);
							found = true;
							break;
						}
					}

				}
			}
			labGenerating.Visible = true;
			Application.DoEvents();
			SaveValues();

			string title = txtTitle.Text;
			int limitingMagnitude = int.Parse(cboLimitingMagnitude.Text);
			float radius = float.Parse(cboRadius.Text);
			float ra = (int.Parse(txtRAH.Text) + int.Parse(txtRAM.Text) / 60f + float.Parse(txtRAS.Text) / 3600f) * 15f;
			int decD = int.Parse(txtDecD.Text);

			float decl = (int)Math.Abs(int.Parse(txtDecD.Text)) + int.Parse(txtDecM.Text) / 60f + float.Parse(txtDecS.Text) / 3600f;

			if (decD < 0)
				decl *= -1;

			int resolution = int.Parse(cboResolution.Text.Split(new char[] { 'x' })[0]);

			this._finderChart.SetFieldView(resolution, limitingMagnitude, MathExt.Deg2Rad(radius), MathExt.Deg2Rad(ra), MathExt.Deg2Rad(decl), title, chkLimitDeepsky.Checked, chkShowLabels.Checked, chkInvertColors.Checked, chkInvertNS.Checked, chkInvertEW.Checked);

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

		private void LoadValues()
		{
			if (File.Exists("settings.dat"))
			{
				using (BinaryReader reader = new BinaryReader(File.Open("settings.dat", FileMode.Open)))
				{
					txtTitle.Text = reader.ReadString();
					txtRAH.Text = reader.ReadString();
					txtRAM.Text = reader.ReadString();
					txtRAS.Text = reader.ReadString();
					txtDecD.Text = reader.ReadString();
					txtDecM.Text = reader.ReadString();
					txtDecS.Text = reader.ReadString();
					cboLimitingMagnitude.Text = reader.ReadString();
					cboRadius.Text = reader.ReadString();
					chkInvertColors.Checked = reader.ReadBoolean();
					chkInvertNS.Checked = reader.ReadBoolean();
					chkInvertEW.Checked = reader.ReadBoolean();
					chkLimitDeepsky.Checked = reader.ReadBoolean();
					chkShowLabels.Checked = reader.ReadBoolean();
					cboResolution.Text = reader.ReadString();
				}
			}
		}

		private void SaveValues()
		{
			using (BinaryWriter writer = new BinaryWriter(File.Open("settings.dat", FileMode.Create)))
			{
				writer.Write(txtTitle.Text);
				writer.Write(txtRAH.Text);
				writer.Write(txtRAM.Text);
				writer.Write(txtRAS.Text);
				writer.Write(txtDecD.Text);
				writer.Write(txtDecM.Text);
				writer.Write(txtDecS.Text);
				writer.Write(cboLimitingMagnitude.Text);
				writer.Write(cboRadius.Text);
				writer.Write(chkInvertColors.Checked);
				writer.Write(chkInvertNS.Checked);
				writer.Write(chkInvertEW.Checked);
				writer.Write(chkLimitDeepsky.Checked);
				writer.Write(chkShowLabels.Checked);
				writer.Write(cboResolution.Text);
				writer.Flush();
				writer.Close();
			}

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

			string typeStr = "";
			switch (deepSkyObject.Type)
			{
				case Enums.DeepSkyObjectType.DiffuseNebula:
					typeStr = "Diffuse nebula";
					break;
				case Enums.DeepSkyObjectType.Galaxy:
					typeStr = "Galaxy";
					break;
				case Enums.DeepSkyObjectType.GalaxyCluster:
					typeStr = "Galaxy cluster";
					break;
				case Enums.DeepSkyObjectType.GlobularCluster:
					typeStr = "Globular cluster";
					break;
				case Enums.DeepSkyObjectType.OpenCluster:
					typeStr = "Open cluster";
					break;
				case Enums.DeepSkyObjectType.PartOfGalaxy:
					typeStr = "Part of galaxy";
					break;
				case Enums.DeepSkyObjectType.PlanetaryNebula:
					typeStr = "Planetary nebula";
					break;
				case Enums.DeepSkyObjectType.Quasar:
					typeStr = "Quasar";
					break;
				case Enums.DeepSkyObjectType.SNR:
					typeStr = "Supernova remnant";
					break;
				case Enums.DeepSkyObjectType.Stars:
					typeStr = "Asterism";
					break;
				default:
					typeStr = "Unknown";
					break;
			}
			info.AppendLine(string.Format("{0,-12}{1}", "Type:", typeStr));

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
					SetSearchResult(deepSkyObject.Coordinates.RightAscension, deepSkyObject.Coordinates.Declination, deepSkyObject.Name);
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

		private void labInfo_Click(object sender, EventArgs e)
		{

		}
	}
}
