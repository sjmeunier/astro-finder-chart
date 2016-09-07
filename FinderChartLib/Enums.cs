using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public static class Enums {
		public enum DeepSkyObjectType
		{
			Unknown = 0,
			Galaxy = 1,
			DiffuseNebula = 2,
			PlanetaryNebula = 3,
			OpenCluster = 4,
			GlobularCluster = 5,
			PartOfGalaxy = 6,
			AlreadyInNGCorIC = 7,
			ICAlreadyInNGC = 8,
			Stars = 9,
			NotFound = 10,
			SNR = 11,
			Quasar = 12,
			GalaxyCluster = 13
		}
	}
}
