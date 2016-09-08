using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public static class AstroCalculations
	{
		// Compute angular distance. Coordinates are in radians
		public static float AngularDistance(RADec pos1, RADec pos2)
		{

			float a = Math.Abs(pos1.RightAscension - pos2.RightAscension);
			float B = Math.Abs(0.5f * (float)Math.PI - pos1.Declination);
			float C = Math.Abs(0.5f * (float)Math.PI - pos2.Declination);

			float arg = (float)Math.Cos(B) * (float)Math.Cos(C) + (float)Math.Sin(B) * (float)Math.Sin(C) * (float)Math.Cos(a);

			if (arg > 1.0f)
				arg = 1.0f;
			if (arg < -1.0f)
				arg = -1.0f;
			return (float)Math.Acos(arg);
		}

		public static LM RADecToLM(RADec centre, RADec pos)
		{
			/*
    SIN projection. Converts radec (alpha, delta) with respect to
    a fieldcentre (alpha0, delta0) to direction cosines (l, m). All
    units are in radians. radec is a tuple (alpha, delta), Fieldcentre
    is a tuple (alpha0, delta0). The routine returns a tuple (l,m).
    The formulae are taken from Greisen 1983: AIPS Memo 27,
    'Non-linear Coordinate Systems in AIPS'
			 */
			float dAlpha = pos.RightAscension - centre.RightAscension;
			LM lm = new LM();
			lm.L = (float)(Math.Cos(pos.Declination) * Math.Sin(dAlpha));
			lm.M = (float)(Math.Sin(pos.Declination) * Math.Cos(centre.Declination) - Math.Cos(pos.Declination) * Math.Sin(centre.Declination) * Math.Cos(dAlpha));
			return lm;
		}
	}
}
