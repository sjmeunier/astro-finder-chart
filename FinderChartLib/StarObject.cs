using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class StarObject
	{
		public RADec Coordinates { get; set; }
		public float Magnitude { get; set; }

		public StarObject(float rightAscension, float declination, float magnitude)
		{
			this.Coordinates = new RADec(rightAscension, declination);
			this.Magnitude = magnitude;
		}
	}
}
