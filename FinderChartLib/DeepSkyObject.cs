using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class DeepSkyObject
	{
		public RADec Coordinates { get; set; }
		public float Magnitude { get; set; }

		public string Catalog { get; set; }
		public string Name { get; set; }
		public List<string> AllNames { get; set; }
		public List<string> AllNamesSearch { get; set; }
		public string ComponentNumber { get; set; }
		public Enums.DeepSkyObjectType Type { get; set; }
		public string Constellation { get; set; }
		public float LongDimension { get; set; } //Long dimension in radians
		public float ShortDimension { get; set; } //Short dimension in radians
		public float PositionAngle { get; set; } // Position angle in radians
		public int MessierNumber { get;	set; }
		public DeepSkyObject()
		{
			this.LongDimension = -1;
			this.ShortDimension = -1;
			this.PositionAngle = 0.5f *(float)Math.PI;
			this.MessierNumber = -1;
			this.AllNames = new List<string>();
			this.AllNamesSearch = new List<string>();
		}

		public DeepSkyObject(float rightAscension, float declination, float magnitude, string catalog, string name, List<string> allNames, List<string> allNamesSearch, string componentNumber, Enums.DeepSkyObjectType type, string constellation, float longDimension, float shortDimension, float positionAngle, int messierNumber)
		{
			this.Coordinates = new RADec(rightAscension, declination);
			this.Magnitude = magnitude;
			this.Catalog = catalog;
			this.Name = name;
			this.AllNames = allNames;
			this.AllNamesSearch = allNamesSearch;
			this.ComponentNumber = componentNumber;
			this.Type = type;
			this.Constellation = constellation;
			this.LongDimension = longDimension;
			this.ShortDimension = shortDimension;
			this.PositionAngle = positionAngle;
			this.MessierNumber = messierNumber;
		}
	}
}
