using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class StarCatalog
	{
		private string _starFilename = "data/catalogs/tyc2.bin";
		private int _recordNum = 2558647;
		public StarObject[] Stars;

		public StarCatalog()
		{
			LoadStars();
		}

		public void LoadStars()
		{
			this.Stars = new StarObject[this._recordNum];
			using (BinaryReader reader = new BinaryReader(File.Open(this._starFilename, FileMode.Open)))
			{
				for(int i = 0; i < this._recordNum; i++)
				{
					this.Stars[i] = new StarObject(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
				}
			}
		}
	}
}
