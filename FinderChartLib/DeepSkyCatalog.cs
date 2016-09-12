using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
						name = catalog + " " + line.Substring(0, 5).Trim();

						if (this._uniqueNames.Contains(name))
						{
							type = Enums.DeepSkyObjectType.AlreadyInNGCorIC;
						}
						else
						{
							type = (Enums.DeepSkyObjectType)Int32.Parse(line.Substring(11, 1));
							if (type == Enums.DeepSkyObjectType.DiffuseNebula && line.Substring(78, 3) == "SNR")
								type = Enums.DeepSkyObjectType.SNR;
						}
						this._uniqueNames.Add(name);

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
						allNames.Add(name);
						allNamesSearch.Add(name.Replace(" ", ""));

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
								name = catalog + " " + messierNumber.ToString();
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

		public void ProcessSaguaro(string filename)
		{
			float rightAscension;
			float declination;
			float magnitude;
			string name;
			
			Enums.DeepSkyObjectType type;
			string constellation;
			float longDimension;
			float shortDimension;
			float positionAngle;

			RegexOptions options = RegexOptions.None;
			Regex regexSpaces = new Regex("[ ]{2,}", options);

			using (TextReader reader = File.OpenText(filename))
			{
				string line;
				reader.ReadLine();
				while ((line = reader.ReadLine()) != null)
				{
					string[] lineArr = line.Split(new string[] { "\",\"" }, StringSplitOptions.None);
					lineArr[0] = lineArr[0].Substring(1);
					lineArr[lineArr.Length - 1] = lineArr[lineArr.Length - 1].Substring(0, lineArr.Length - 1);

					List<string> allNamesSearch = new List<string>();
					List<string> allNames = new List<string>();

					name = regexSpaces.Replace(lineArr[0].Trim(), " ");
					allNamesSearch.Add(name.Replace(" ", "").ToUpper());
					allNames.Add(name);

					string[] otherNames = new string[0];
					if (lineArr[1].Trim().Length > 0)
						otherNames = regexSpaces.Replace(lineArr[1].Trim(), " ").Split(new char[] { ';' });

					for (int i = 0; i < otherNames.Length; i++)
					{
						allNames.Add(otherNames[i]);
						allNamesSearch.Add(otherNames[i].Replace(" ", "").ToUpper());
					}


					bool found = false;
					foreach (DeepSkyObject deepSkyObject in this.DeepSkyObjects) {

						foreach (string searchName in allNamesSearch)
						{
							if (deepSkyObject.AllNamesSearch.Contains(searchName))
							{
								found = true;
								break;
							}
						}
						if (found)
						{
							deepSkyObject.AllNames = deepSkyObject.AllNames.Union(allNames).ToList<string>();
							deepSkyObject.AllNamesSearch = deepSkyObject.AllNames.Union(allNamesSearch).ToList<string>();
							
							break;
						}
					}

					if (!found)
					{
						switch(lineArr[2].Trim())
						{
							case "GALXY":
								type = Enums.DeepSkyObjectType.Galaxy;
								break;
							case "BRTNB":
							case "DRKNB":
							case "GX+DN":
							case "LMCDN":
							case "SMCDN":
								type = Enums.DeepSkyObjectType.DiffuseNebula;
								break;
							case "PLNNB":
								type = Enums.DeepSkyObjectType.PlanetaryNebula;
								break;
							case "CL+NB":
							case "LMCOC":
							case "LMCCN":
							case "OPNCL":
							case "SMCOC":
							case "SMCCN":
							case "G+C+N":
								type = Enums.DeepSkyObjectType.OpenCluster;
								break;
							case "GLOCL":
							case "GX+GC":
							case "LMCGC":
							case "SMCGC":
								type = Enums.DeepSkyObjectType.GlobularCluster;
								break;
							case "ASTER":
							case "#STAR":
								type = Enums.DeepSkyObjectType.Stars;
								break;
							case "SNREM":
								type = Enums.DeepSkyObjectType.SNR;
								break;
							case "QUASR":
								type = Enums.DeepSkyObjectType.Quasar;
								break;
							case "GALCL":
								type = Enums.DeepSkyObjectType.GalaxyCluster;
								break;
							default:
								type = Enums.DeepSkyObjectType.Unknown;
								break;
						}
						constellation = lineArr[3];

						string[] raArr = lineArr[4].Split(new char[] { ' ' });
						rightAscension = (float)Math.PI * (float.Parse(raArr[0].Trim()) + float.Parse(raArr[1].Trim()) / 60.0f) / 12.0f;

						string[] declArr = lineArr[5].Split(new char[] { ' ' });
						declination = (float)Math.PI * (Math.Abs(float.Parse(declArr[0].Trim())) + float.Parse(declArr[1].Trim()) / 60.0f) / 180.0f;
						if (float.Parse(declArr[0].Trim()) < 0)
							declination *= -1;

						magnitude = float.Parse(Regex.Replace(lineArr[6].Trim(), "[^0-9.]", ""));

						longDimension = -1;
						if (lineArr[10].Trim() != "")
						{
							string unit = lineArr[10].Substring(lineArr[10].Length - 1, 1);
							if (unit == "m")
								longDimension = (float.Parse(Regex.Replace(lineArr[10].Substring(0, lineArr[10].Length - 1).Trim(), "[^0-9.]", "")) / 60f) * ((float)Math.PI / 180f);
							else
								longDimension = (float.Parse(Regex.Replace(lineArr[10].Substring(0, lineArr[10].Length - 1).Trim(), "[^0-9.]", "")) / 3600f) * ((float)Math.PI / 180f);
						}

						shortDimension = -1;
						if (lineArr[11].Trim() != "")
						{
							string unit = lineArr[11].Substring(lineArr[10].Length - 1, 1);
							if (unit == "m")
								shortDimension = (float.Parse(lineArr[11].Substring(0, lineArr[11].Length - 1).Trim()) / 60f) * ((float)Math.PI / 180f);
							else
								shortDimension = (float.Parse(lineArr[11].Substring(0, lineArr[11].Length - 1).Trim()) / 3600f) * ((float)Math.PI / 180f);
						}
						if (shortDimension <= 0)
							shortDimension = longDimension;

						positionAngle = 0.5f * (float)Math.PI;
						if (lineArr[12].Trim() != "")
						{
							positionAngle = float.Parse(lineArr[12].Trim()) * (float)Math.PI / 180.0f;
						}


						this.DeepSkyObjects.Add(new DeepSkyObject(rightAscension, declination, magnitude, "Saguaro", name, allNames, allNamesSearch, "", type, constellation, longDimension, shortDimension, positionAngle, 0));
					}
				}
			}
		}
		public void LoadDeepSky()
		{
			ProcessFile("NGC", this._ngcFilename);
			ProcessFile("IC", this._icFilename);
			ProcessSaguaro(this._saguaroFilename);
		}
	}
}
