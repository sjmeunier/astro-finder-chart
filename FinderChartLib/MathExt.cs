using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public static class MathExt
	{
		public static float Rad2Deg(float rad)
		{
			return rad * 180f / (float)Math.PI;
		}

		public static float Deg2Rad(float deg)
		{
			return deg * (float)Math.PI / 180f;
		}
	}
}
