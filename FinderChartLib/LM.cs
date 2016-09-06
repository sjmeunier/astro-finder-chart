using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class LM
	{
		public float L { get; set; }
		public float M { get; set; }

		public LM(float l, float m)
		{
			this.L = l;
			this.M = m;
		}
		public LM()
		{
			this.L = 0;
			this.M = 0;
		}
	}
}
