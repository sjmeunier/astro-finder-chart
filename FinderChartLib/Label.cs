using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class Label
	{
		public float X { get; set; }
		public float Y { get; set; }
		public float RotateX { get; set; }
		public float RotateY { get; set; }
		public float Angle { get; set; }

		public string Text { get; set; }

		public Label(float x, float y, float rotateX, float rotateY, float angle, string text)
		{
			this.X = x;
			this.Y = y;
			this.RotateX = rotateX;
			this.RotateY = rotateY;
			this.Angle = angle;
			this.Text = text;
		}

	}
}
