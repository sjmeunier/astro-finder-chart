using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class RADec
	{
		public float RightAscension { get; set; }
		public float Declination { get; set; }

		public RADec(float rightAscension, float declination)
		{
			this.RightAscension = rightAscension;
			this.Declination = declination;
		}
		public RADec()
		{
			this.RightAscension = 0;
			this.Declination = 0;
		}
	}
}
