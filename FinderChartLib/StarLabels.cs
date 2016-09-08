using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class StarLabels
	{
		private string _starFilename = "data/catalogs/bsc.txt";
		public List<StarLabel> Stars;

		public StarLabels()
		{
			LoadStars();
		}

		private string GetBayerSymbol(string val)
		{
			string symbol = val;

			switch (val.ToUpper())
			{
				case "ALP":
					symbol = "α";
					break;
				case "BET":
					symbol = "β";
					break;
				case "GAM":
					symbol = "γ";
					break;
				case "DEL":
					symbol = "δ";
					break;
				case "EPS":
					symbol = "ε";
					break;
				case "ZET":
					symbol = "ζ";
					break;
				case "ETA":
					symbol = "η";
					break;
				case "THE":
					symbol = "θ";
					break;
				case "IOT":
					symbol = "ι";
					break;
				case "KAP":
					symbol = "κ";
					break;
				case "LAM":
					symbol = "λ";
					break;
				case "MU":
					symbol = "μ";
					break;
				case "NU":
					symbol = "ν";
					break;
				case "XI":
					symbol = "ξ";
					break;
				case "OMI":
					symbol = "ο";
					break;
				case "PI":
					symbol = "π";
					break;
				case "RHO":
					symbol = "ρ";
					break;
				case "SIG":
					symbol = "σ";
					break;
				case "TAU":
					symbol = "τ";
					break;
				case "UPS":
					symbol = "υ";
					break;
				case "PHI":
					symbol = "φ";
					break;
				case "CHI":
					symbol = "χ";
					break;
				case "PSI":
					symbol = "ψ";
					break;
				case "OME":
					symbol = "ω";
					break;
			}
			return symbol;
		}
		public void LoadStars()
		{
			float rightAscension;
			float declination;
			float magnitude;
			string name;
			string constellation;
			string bayer;
			string bayerSymbol;
			string flamsteed;
			string componentNumber;
			string dm;
			string hr;
			string spectralType;

			this.Stars = new List<StarLabel>();

			using (TextReader reader = File.OpenText(this._starFilename))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					componentNumber = line.Substring(10, 1);
					dm = line.Substring(14, 10).Trim();
					if ((componentNumber == " " || componentNumber == "1") && dm.Length > 0)
					{
						List<string> allNamesSearch = new List<string>();
						List<string> allNames = new List<string>();

						hr = line.Substring(0, 4).Trim();
						if (hr.Length > 0)
						{
							allNames.Add("HR" + hr);
						}

						allNames.Add(dm);
						allNamesSearch.Add(dm);

						flamsteed = line.Substring(4, 3).Trim();
						bayer = line.Substring(7, 3).Trim();
						constellation = line.Substring(11, 3).Trim();

						name = "";
						if (constellation.Length > 0)
						{
							if (flamsteed.Length > 0)
							{
								if (bayer.Length == 0)
								{
									name = string.Format("{0} {1}", flamsteed, constellation);
									allNamesSearch.Add(name.ToUpper().Replace(" ", "").ToUpper());
									allNames.Add(name);
								}
								else
								{
									allNamesSearch.Add(string.Format("{0}{1}", flamsteed, constellation).ToUpper());
									allNames.Add(string.Format("{0} {1}", flamsteed, constellation));
								}
							}
							if (bayer.Length > 0)
							{
								bayerSymbol = GetBayerSymbol(bayer);
								name = string.Format("{0} {1}", bayerSymbol, constellation);
								allNames.Add(name);
								allNames.Add(string.Format("{0} {1}", bayer, constellation));

								allNamesSearch.Add(name.ToUpper().Replace(" ", ""));
								allNamesSearch.Add(string.Format("{0}{1}", bayer, constellation).ToUpper());
							}
						}

						rightAscension = MathExt.Deg2Rad((int.Parse(line.Substring(75, 2)) + int.Parse(line.Substring(77, 2)) / 60f + float.Parse(line.Substring(79, 4)) / 3600f) * 15f);
						declination = MathExt.Deg2Rad(int.Parse(line.Substring(84, 2)) + int.Parse(line.Substring(86, 2)) / 60f + float.Parse(line.Substring(88, 2)) / 3600f);
						if (line.Substring(83, 1) == "-")
							declination *= -1;

						magnitude = float.Parse(line.Substring(102, 5));
						spectralType = line.Substring(127, 20).Trim();

						if (name.Length > 0)
							this.Stars.Add(new StarLabel(rightAscension, declination, magnitude, name, allNames, allNamesSearch, spectralType));
					}
				}
			}
		}
	}
}
