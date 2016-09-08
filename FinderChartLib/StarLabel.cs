using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class StarLabel
	{
		public RADec Coordinates { get; set; }
		public float Magnitude { get; set; }
		public string Name { get; set; }
		public string SpectralType { get; set; }
		public List<string> AllNames { get; set; }
		public List<string> AllNamesSearch { get; set; }

		public StarLabel(float rightAscension, float declination, float magnitude, string name, List<string> allNames, List<string> allNamesSearch, string spectralType)
		{
			this.Coordinates = new RADec(rightAscension, declination);
			this.Magnitude = magnitude;
			this.SpectralType = spectralType;
			this.Name = name;
			this.AllNames = allNames;
			this.AllNamesSearch = allNamesSearch;
		}
	}
}
