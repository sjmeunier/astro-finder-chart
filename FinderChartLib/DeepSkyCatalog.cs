using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class DeepSkyCatalog
	{
		private string _ngcFilename = "data/catalogs/revngc.txt";
		private string _icFilename = "data/catalogs/revic.txt";
		private string _saguaroFilename = "data/catalogs/sac.txt";

		private HashSet<string> _uniqueNames = new HashSet<string>();
		public List<DeepSkyObject> DeepSkyObjects = new List<DeepSkyObject>();
		
		public DeepSkyCatalog()
		{
			LoadDeepSky();
		}

		public void ProcessFile(string fileCatalog, string filename)
		{
			float rightAscension;
			float declination;
			float magnitude;
			string name;
			string componentNumber;
			Enums.DeepSkyObjectType type;
			string constellation;
			string catalog;
			float longDimension;
			float shortDimension;
			float positionAngle;
			int messierNumber;
			string id1;
			string id2;
			string id3;

			using (TextReader reader = File.OpenText(filename))
			{
				string line;
				reader.ReadLine();
				reader.ReadLine();
				while ((line = reader.ReadLine()) != null)
				{
					catalog = fileCatalog;
					if (line.Substring(11, 1) != " ")
					{
						name = line.Substring(0, 5).Trim();

						if (this._uniqueNames.Contains(catalog + name))
						{
							type = Enums.DeepSkyObjectType.AlreadyInNGCorIC;
						}
						else
						{
							type = (Enums.DeepSkyObjectType)Int32.Parse(line.Substring(11, 1));
							if (type == Enums.DeepSkyObjectType.DiffuseNebula && line.Substring(78, 3) == "SNR")
								type = Enums.DeepSkyObjectType.SNR;
						}
						this._uniqueNames.Add(catalog + name);

						if (line.Substring(5, 1) != " ")
							componentNumber = line.Substring(5, 1);
						else
							componentNumber = "";

						constellation = line.Substring(15, 3).Trim().ToUpper();

						rightAscension = (float)Math.PI * (float.Parse(line.Substring(20, 2)) + float.Parse(line.Substring(23, 2)) / 60.0f + float.Parse(line.Substring(26, 2)) / 3600.0f) / 12.0f;
						declination = (float)Math.PI * (float.Parse(line.Substring(32, 2)) + float.Parse(line.Substring(35, 2)) / 60.0f + float.Parse(line.Substring(38, 2)) / 3600.0f) / 180.0f;
						if (line.Substring(31, 1) == "-")
							declination *= -1;

						magnitude = 0;
						if (line.Substring(50, 4).Trim() != "")
						{
							magnitude = float.Parse(line.Substring(50, 4));
						}
						else if (line.Substring(43, 4).Trim() != "")
						{
							magnitude = float.Parse(line.Substring(43, 4));
						}

						longDimension = -1;
						if (line.Substring(61, 6).Trim() != "")
						{
							longDimension = (float.Parse(line.Substring(61, 6)) / 60f) * ((float)Math.PI / 180f);
						}
						shortDimension = -1;
						if (line.Substring(68, 6).Trim() != "")
						{
							shortDimension = (float.Parse(line.Substring(68, 6)) / 60f) * ((float)Math.PI / 180f);
						}

						if (shortDimension <= 0)
							shortDimension = longDimension;

						positionAngle = 0.5f * (float)Math.PI;
						if (line.Substring(74, 3).Trim() != "")
						{
							positionAngle = float.Parse(line.Substring(74, 3)) * (float)Math.PI / 180.0f;
						}

						List<string> allNames = new List<string>();
						List<string> allNamesSearch = new List<string>();
						allNames.Add(catalog + " " + name);
						allNamesSearch.Add(catalog + name);

						messierNumber = 0;
						id1 = line.Substring(96, 14).Trim();
						if (id1 != "")
						{
							string manipulatedName = id1.Replace(" ", "").ToUpper();

							allNamesSearch.Add(manipulatedName);
							allNames.Add(id1);
							this._uniqueNames.Add(manipulatedName);
							if (id1.Substring(0, 2) == "M ")
							{
								messierNumber = int.Parse(id1.Substring(1));
								catalog = "M";
								name = messierNumber.ToString();
							}
						}
						id2 = line.Substring(112, 14).Trim();
						if (id2 != "")
						{
							string manipulatedName = id2.Replace(" ", "").ToUpper();
							allNamesSearch.Add(manipulatedName);
							allNames.Add(id2);
						}
						id3 = line.Substring(128, 14).Trim();
						if (id3 != "")
						{
							string manipulatedName = id3.Replace(" ", "").ToUpper();
							allNamesSearch.Add(manipulatedName);
							allNames.Add(id3);
						}
						this.DeepSkyObjects.Add(new DeepSkyObject(rightAscension, declination, magnitude, catalog, name, allNames, allNamesSearch, componentNumber, type, constellation, longDimension, shortDimension, positionAngle, messierNumber));
					}
				}
			}
		}
		public void LoadDeepSky()
		{
			ProcessFile("NGC", this._ngcFilename);
			ProcessFile("IC", this._icFilename);
		}
	}
}
