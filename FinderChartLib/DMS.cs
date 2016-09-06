using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
	public class DMS
	{
		private float _value;	//Value in radians

		public DMS(float degrees)
		{
			SetDegrees(degrees);
		}

		public DMS(int hours, int minutes, float seconds)
		{
			SetDMS(hours, minutes, seconds);
		}

		public void SetDegrees(float degrees)
		{
			this._value = MathExt.Deg2Rad(degrees);
		}

		public void SetRadians(float radians)
		{
			this._value = radians;
		}

		public void SetDMS(int degrees, int minutes, float seconds)
		{
			this._value = MathExt.Rad2Deg(degrees + (minutes / 60.0f) + (seconds / 3600.0f));
		}

		public float GetRadians()
		{
			return this._value;
		}

		public float GetDecDegrees()
		{
			return MathExt.Rad2Deg(this._value);
		}

		public float GetDegrees()
		{
			return (float)Math.Truncate(MathExt.Rad2Deg(this._value));
		}

		public float GetMinutes()
		{
			var dec = MathExt.Rad2Deg(this._value);
			dec = (dec - (float)Math.Truncate(dec)) * 60.0f;
			return (float)Math.Truncate(dec);
		}
		public double GetSeconds()
		{
			var dec = MathExt.Rad2Deg(this._value);
			dec = (dec - (float)Math.Truncate(dec)) * 60.0f;
			dec = (dec - (float)Math.Truncate(dec)) * 60.0f;
			return dec;
		}
	}
}
