using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderChartLib
{
    public class FinderChart
    {
		private RADec _centre { get; set; }
		private int _imageWidth { get; set; }
		private float _limitingMagnitude { get; set; }
		private float _radiusRadians { get; set; }
		private float _radiusPixels { get; set; }
		private string _title { get; set; }
		private float _margin { get; set; }

		private int _centreX;
		private int _centreY;
		private float _scale;
		private float _radiusScale;

		private bool _limitDeepSkyMag;
		private bool _showLabels;

		private Color _backgroundColor = Color.White;
        private Color _foregroundColor = Color.Black;
		private Color _outlineColor = Color.Gray;

		private Brush _backgroundBrush;
		private Brush _foregroundBrush;
		private Brush _outlineBrush;
		private Pen _framePen;
		private Pen _galaxyPen;
		private Pen _globularClusterPen;
		private Pen _planetaryNebulaPen;
		private Pen _supernovaRemnantPen;
		private Pen _openClusterPen;
		private Pen _diffuseNebulaPen;
		private Pen _asterismPen;
		private Pen _unknownObjectPen;
		private Pen _outlinePen;
        private Pen _scalePen;
		
		private Pen _fontPen;
		private Font _legendFont;
		private Font _titleFont;
		private Font _magnitudeFont;
		private Font _labelFont;

		private List<Label> _labels;
		private List<StarObject> _starsToDraw;

		public StarCatalog StarCatalog;
		public DeepSkyCatalog DeepSkyCatalog;
		public StarLabels StarLabels;
	
		public FinderChart()
		{
			this.StarCatalog = new StarCatalog();
			this.DeepSkyCatalog = new DeepSkyCatalog();
			this.StarLabels = new StarLabels();

			this._labels = new List<Label>();
			this._starsToDraw = new List<StarObject>();

            this._backgroundBrush = new SolidBrush(this._backgroundColor);
            this._foregroundBrush = new SolidBrush(this._foregroundColor);
			this._outlineBrush = new SolidBrush(this._outlineColor);

			SetFieldView(1000, 12, MathExt.Deg2Rad(4), MathExt.Deg2Rad(0.7122222222f * 15f), MathExt.Deg2Rad(41.26889f), "Test", true, true);
		}
		
		public void SetFieldView(int imageWidth, float limitingMagnitude, float radiusRadians, float raRadians, float declinationRadians, string title, bool limitDeepSkyMag, bool showLabels)
		{
			this._imageWidth = imageWidth;
			this._limitingMagnitude = limitingMagnitude;
			this._centre = new RADec(raRadians, declinationRadians);
			this._title = title;
			this._limitDeepSkyMag = limitDeepSkyMag;
			this._showLabels = showLabels;

			this._centreX = this._imageWidth / 2;
			this._centreY = this._imageWidth / 2;
			
			this._scale = this._imageWidth / 1000;
			this._margin = 40f * this._scale;
			
			this._radiusPixels = this._centreX - this._margin;
			this._radiusRadians = radiusRadians;
			this._radiusScale = this._radiusPixels / this._radiusRadians;

			this._framePen = new Pen(this._foregroundBrush, 3 * this._scale);
			this._galaxyPen = new Pen(this._foregroundBrush, 1.3f * this._scale);
			this._globularClusterPen = new Pen(this._foregroundBrush, 1.8f * this._scale);
			this._planetaryNebulaPen = new Pen(this._foregroundBrush, 1.8f * this._scale);
			this._supernovaRemnantPen = new Pen(this._foregroundBrush, 2.3f * this._scale);
			this._openClusterPen = new Pen(this._foregroundBrush, 1.8f * this._scale);
			this._asterismPen = new Pen(this._foregroundBrush, 1.8f * this._scale);
			this._diffuseNebulaPen = new Pen(this._foregroundBrush, 1.8f * this._scale);
			this._unknownObjectPen = new Pen(this._foregroundBrush, 1.8f * this._scale);
			this._fontPen = new Pen(this._foregroundBrush, 3 * this._scale);
            this._scalePen = new Pen(this._foregroundBrush, 3 * this._scale);
            this._outlinePen = new Pen(this._outlineBrush, 0.6f * this._scale);

			this._legendFont = new Font(FontFamily.GenericSerif, 16 * this._scale);
			this._titleFont = new Font(FontFamily.GenericSerif, 20 * this._scale);
			this._magnitudeFont = new Font(FontFamily.GenericSerif, 14 * this._scale);
			this._labelFont = new Font(FontFamily.GenericSansSerif, 12 * this._scale, FontStyle.Bold);

		}

		public Bitmap CreateChart()
		{
			this._labels = new List<Label>();

			Bitmap finderChart = new Bitmap(this._imageWidth, this._imageWidth);
			Graphics g = Graphics.FromImage(finderChart);

			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.FillRectangle(this._backgroundBrush, 0, 0, this._imageWidth, this._imageWidth);


			SetClipToChart(g);
			DrawStars(g);
			DrawDeepSky(g);
			DrawLabels(g);
			DrawStarLabels(g);

			ClearClip(g);
			DrawFrame(g);
			DrawCoordinates(g);
			DrawMagnitudeScale(g);
            DrawScale(g);
			DrawTitle(g);
			DrawLegend(g);
			DrawLegend(g);

			return finderChart;
		}

		private void ClearClip(Graphics g)
		{
			RectangleF r = new RectangleF(0, 0, this._imageWidth, this._imageWidth);
			g.Clip = new Region(r);
		}

		private void SetClipToChart(Graphics g)
		{
			RectangleF r = new RectangleF(this._centreX - this._radiusPixels, this._centreY - this._radiusPixels, this._radiusPixels * 2, this._radiusPixels * 2);
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(r);
			g.Clip = new Region(path);
		}

		private void DrawScale(Graphics g)
        {
            float yOffset = 50 * this._scale;
            float xOffset = this._margin / 2f;

            g.DrawLine(this._scalePen, xOffset, yOffset, xOffset + this._radiusPixels / 2f, yOffset);
            g.DrawLine(this._scalePen, xOffset, yOffset - 10 * this._scale, xOffset, yOffset + 10 * this._scale);
            g.DrawLine(this._scalePen, xOffset + this._radiusPixels / 2f, yOffset - 10 * this._scale, xOffset + this._radiusPixels / 2f, yOffset + 10 * this._scale);

            string label = string.Format("{0}°", Math.Round((this._radiusRadians  / 2f)* 180f / (float)Math.PI * 100f) / 100f);
            SizeF stringSize = g.MeasureString(label, this._legendFont);

            g.DrawString(label, this._legendFont, this._foregroundBrush, xOffset - stringSize.Width + this._radiusPixels / 4f, yOffset + 15 * this._scale);

        }

		private float MagnitudeToRadius(float magnitude)
		{
			return 1.0f * (float)(Math.Pow(1.25f, (Math.Floor(Math.Max(this._limitingMagnitude, 9)) - magnitude))) * this._scale;
		}

		private void DrawTitle(Graphics g)
		{
			SizeF stringSize = g.MeasureString(this._title, this._legendFont);
			g.DrawString(this._title, this._titleFont, this._foregroundBrush, this._centreX - stringSize.Width, 10 * this._scale);
		}
		
		private void DrawLegend(Graphics g)
		{
			SizeF stringSize;
			float yOffset = 100 * this._scale;
			float yIncrement = 20 * this._scale;
			float xOffset = 60 * this._scale;
			float x = this._imageWidth - xOffset;
			float y = yOffset;

			stringSize = g.MeasureString("Globular Cluster", this._legendFont);
			g.DrawString("Globular Cluster", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawGlobularCluster(g, x + 10 * this._scale, y, 0, "");
			y += yIncrement;

			stringSize = g.MeasureString("Open Cluster", this._legendFont);
			g.DrawString("Open Cluster", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawOpenCluster(g, x + 10 * this._scale, y, 0, "");
			y += yIncrement;

			stringSize = g.MeasureString("Asterism", this._legendFont);
			g.DrawString("Asterism", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawAsterism(g, x + 10 * this._scale, y, 0, "");
			y += yIncrement;

			stringSize = g.MeasureString("Galaxy", this._legendFont);
			g.DrawString("Galaxy", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawGalaxy(g, x + 10 * this._scale, y, 0, 0, 0, "");
			y = this._imageWidth - yOffset + yIncrement;

			stringSize = g.MeasureString("Part of External Galaxy", this._legendFont);
			g.DrawString("Part of External Galaxy", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawUnknown(g, x + 10 * this._scale, y, 0, "");
			y -= yIncrement;

			stringSize = g.MeasureString("Supernova Remnant", this._legendFont);
			g.DrawString("Supernova Remnant", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawSupernovaRemnant(g, x + 10 * this._scale, y, 0, "");
			y -= yIncrement;

			stringSize = g.MeasureString("Planetary Nebula", this._legendFont);
			g.DrawString("Planetary Nebula", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawPlanetaryNebula(g, x + 10 * this._scale, y, 0, "");
			y -= yIncrement;

			stringSize = g.MeasureString("Diffuse Nebula", this._legendFont);
			g.DrawString("Diffuse Nebula", this._legendFont, this._foregroundBrush, x - stringSize.Width, y - stringSize.Height / 2f);
			DrawDiffuseNebula(g, x + 10 * this._scale, y, 0, 0, "");

		}

		private void DrawFrame(Graphics g)
		{
			g.DrawEllipse(this._framePen, this._centreX - this._radiusPixels, this._centreY - this._radiusPixels, this._radiusPixels * 2, this._radiusPixels * 2);
		}
		
		private void DrawStar(Graphics g, float x, float y, float magnitude)
		{
			float radius = MagnitudeToRadius(magnitude);
			g.FillEllipse(this._foregroundBrush, x - radius, y - radius, radius * 2, radius * 2);
			g.DrawEllipse(this._outlinePen, x - radius, y - radius, radius * 2, radius * 2);
		}

		private void DrawStars(Graphics g)
		{
			this._starsToDraw = new List<StarObject>();

			for (int i = 0; i < this.StarCatalog.Stars.Length; i++)
			{
				if (this.StarCatalog.Stars[i].Magnitude <= this._limitingMagnitude) {
					float angularDistance = AstroCalculations.AngularDistance(this._centre, this.StarCatalog.Stars[i].Coordinates);
					if (angularDistance < this._radiusRadians)
					{
						this._starsToDraw.Add(this.StarCatalog.Stars[i]);					
					}
				}
			}
			foreach(StarObject star in this._starsToDraw.OrderBy(x => x.Magnitude))
			{
				LM lm = AstroCalculations.RADecToLM(this._centre, star.Coordinates);
				float x = lm.L * -1 * this._radiusScale + this._centreX;
				float y = lm.M * -1 * this._radiusScale + this._centreY;
				DrawStar(g, x, y, star.Magnitude);
			}
		}

		private void DrawStarLabels(Graphics g)
		{
			if (!this._showLabels)
				return;

			foreach(StarLabel star in this.StarLabels.Stars)
			{
				if (star.Magnitude <= this._limitingMagnitude)
				{
					float angularDistance = AstroCalculations.AngularDistance(this._centre, star.Coordinates);
					if (angularDistance < this._radiusRadians)
					{
						LM lm = AstroCalculations.RADecToLM(this._centre, star.Coordinates);
						float x = lm.L * -1 * this._radiusScale + this._centreX;
						float y = lm.M * -1 * this._radiusScale + this._centreY;

						float offset = MagnitudeToRadius(star.Magnitude);
						g.DrawString(star.Name, this._labelFont, this._foregroundBrush, x + offset + 3f * this._scale, y - 6f * this._scale);
					}
				}
			}
		}

		private void DrawLabels(Graphics g)
		{
			if (!this._showLabels)
				return;

			foreach(Label label in this._labels)
			{
				if (label.Angle != 0)
				{
					using (Matrix rotate = new Matrix())
					{
						GraphicsContainer container = g.BeginContainer();

						rotate.RotateAt(label.Angle, new PointF(label.RotateX, label.RotateY));
						g.Transform = rotate;
						g.DrawString(label.Text, this._labelFont, this._foregroundBrush, label.X, label.Y);
						g.EndContainer(container);
					}
				} else
				{
					g.DrawString(label.Text, this._labelFont, this._foregroundBrush, label.X, label.Y);
				}
			}
		}
		private void DrawGalaxy(Graphics g, float x, float y, float longDimension, float shortDimension, float positionAngle, string label)
		{
			float longDim = 0;
			float shortDim = 0;

			longDim = Math.Max(this._radiusScale * longDimension, 10 * this._scale);
			shortDim = Math.Max(this._radiusScale * shortDimension, 5 * this._scale);
			float posAngle = (positionAngle * -180f / (float)Math.PI) + 90;
			using (Matrix rotate = new Matrix())
			{
				GraphicsContainer container = g.BeginContainer();

				rotate.RotateAt(posAngle, new PointF(x, y));
				g.Transform = rotate;
				g.DrawEllipse(this._galaxyPen, x - longDim / 2, y - shortDim / 2, longDim, shortDim); 
				g.EndContainer(container);
			}

			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + longDim / 2 + (1 * this._scale), y - (10 * this._scale), x, y, posAngle, label));
		}

		private void DrawDiffuseNebula(Graphics g, float x, float y, float longDimension, float shortDimension, string label)
		{
			float longDim = 0;
			float shortDim = 0;

			longDim = Math.Max(this._radiusScale * longDimension, 7 * this._scale);
			shortDim = Math.Max(this._radiusScale * shortDimension, 7 * this._scale);
			g.DrawRectangle(this._diffuseNebulaPen, x - longDim / 2f, y - shortDim / 2f, longDim, shortDim);
			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + longDim + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));
		}

		private void DrawPlanetaryNebula(Graphics g, float x, float y, float radius, string label)
		{
			radius = Math.Max(this._radiusScale * radius, 6 * this._scale);

			g.DrawEllipse(this._planetaryNebulaPen, x - (radius * 0.75f), y - (radius * 0.75f), (radius * 0.75f) * 2, (radius * 0.75f) * 2);
			g.DrawLine(this._planetaryNebulaPen, x - (radius * 0.75f), y, x - (radius * 1.5f), y);
			g.DrawLine(this._planetaryNebulaPen, x + (radius * 0.75f), y, x + (radius * 1.5f), y);
			g.DrawLine(this._globularClusterPen, x, y - (radius * 0.75f), x, y - (radius * 1.5f));
			g.DrawLine(this._globularClusterPen, x, y + (radius * 0.75f), x, y + (radius * 1.5f));

			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + radius * 1.5f + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));
		}

		private void DrawGlobularCluster(Graphics g, float x, float y, float radius, string label)
		{
			radius = Math.Max(this._radiusScale * radius, 6 * this._scale);

			g.DrawEllipse(this._globularClusterPen, x - radius, y - radius, radius * 2, radius * 2);
			g.DrawLine(this._globularClusterPen, x - radius, y, x + radius, y);
			g.DrawLine(this._globularClusterPen, x, y - radius, x, y + radius);
			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + radius + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));

		}

		private void DrawOpenCluster(Graphics g, float x, float y, float radius, string label)
		{
			radius = Math.Max(this._radiusScale * radius, 6 * this._scale);
			this._openClusterPen.DashStyle = DashStyle.Dash;
			g.DrawEllipse(this._openClusterPen, x - radius, y - radius, radius * 2, radius * 2);
			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + radius + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));
		}

		private void DrawAsterism(Graphics g, float x, float y, float radius, string label)
		{
			radius = Math.Max(this._radiusScale * radius, 6 * this._scale);
			float w2 = (float)Math.Pow(2, 0.5);
			float d = radius / 2.0f * w2;
			this._asterismPen.DashStyle = DashStyle.Dash;

			g.DrawLine(this._asterismPen, x - radius, y, x, y - radius);
			g.DrawLine(this._asterismPen, x, y - radius, x + radius, y);
			g.DrawLine(this._asterismPen, x + radius, y, x, y + radius);
			g.DrawLine(this._asterismPen, x , y + radius, x - radius, y);
			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + radius + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));
		}

		private void DrawSupernovaRemnant(Graphics g, float x, float y, float radius, string label)
		{
			radius = Math.Max(this._radiusScale * radius, 6 * this._scale);

			g.DrawEllipse(this._supernovaRemnantPen, x - radius, y - radius, radius * 2, radius * 2);
			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + radius + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));
		}
		private void DrawUnknown(Graphics g, float x, float y, float radius, string label)
		{
			radius = Math.Max(this._radiusScale * radius, 6 * this._scale);

			g.DrawLine(this._unknownObjectPen, x - radius, y - radius, x + radius, y + radius);
			g.DrawLine(this._unknownObjectPen, x - radius, y + radius, x + radius, y - radius);
			if (label.Trim().Length > 0)
				this._labels.Add(new Label(x + radius + (1 * this._scale), y - (10 * this._scale), 0, 0, 0, label));
		}

		private void DrawDeepSky(Graphics g)
		{
			foreach(DeepSkyObject deepSkyObject in this.DeepSkyCatalog.DeepSkyObjects)
			{
				if ((this._limitDeepSkyMag && deepSkyObject.Magnitude < this._limitingMagnitude) || !this._limitDeepSkyMag) { 
					float angularDistance = AstroCalculations.AngularDistance(this._centre, deepSkyObject.Coordinates);
					if (angularDistance < this._radiusRadians)
					{
						LM lm = AstroCalculations.RADecToLM(this._centre, deepSkyObject.Coordinates);
						float x = lm.L * -1 * this._radiusScale + this._centreX;
						float y = lm.M * -1 * this._radiusScale + this._centreY;
						string name = deepSkyObject.Catalog + deepSkyObject.Name;
						switch (deepSkyObject.Type)
						{
							case Enums.DeepSkyObjectType.Galaxy:
								DrawGalaxy(g, x, y, deepSkyObject.LongDimension, deepSkyObject.ShortDimension, deepSkyObject.PositionAngle, name);
								break;
							case Enums.DeepSkyObjectType.DiffuseNebula:
								DrawDiffuseNebula(g, x, y, deepSkyObject.LongDimension * 2f, deepSkyObject.ShortDimension * 2f, name);
								break;
							case Enums.DeepSkyObjectType.PlanetaryNebula:
								DrawPlanetaryNebula(g, x, y, deepSkyObject.LongDimension, name);
								break;
							case Enums.DeepSkyObjectType.OpenCluster:
								DrawOpenCluster(g, x, y, deepSkyObject.LongDimension / 2f, name);
								break;
							case Enums.DeepSkyObjectType.GlobularCluster:
								DrawGlobularCluster(g, x, y, deepSkyObject.LongDimension / 2f, name);
								break;
							case Enums.DeepSkyObjectType.Stars:
								DrawAsterism(g, x, y, deepSkyObject.LongDimension / 2f, name);
								break;
							case Enums.DeepSkyObjectType.SNR:
								DrawSupernovaRemnant(g, x, y, deepSkyObject.LongDimension / 2f, name);
								break;
							case Enums.DeepSkyObjectType.AlreadyInNGCorIC:
							case Enums.DeepSkyObjectType.ICAlreadyInNGC:
								//Do nothing since it is a duplicate
								break;
							default:
								DrawUnknown(g, x, y, deepSkyObject.LongDimension / 2f, name);
								break;
						}
					}
				}
			}
		}

		private void DrawCoordinates(Graphics g)
		{
			int rah = (int)Math.Floor(this._centre.RightAscension * 12 / (float)Math.PI);
			int ram = (int)Math.Floor((this._centre.RightAscension * 12 / (float)Math.PI - rah) * 60);
			int ras = (int)Math.Floor(((this._centre.RightAscension * 12 / (float)Math.PI - rah) * 60 - ram) * 60 + 0.5);
			
			if (ras == 60) {
				ram += 1;
				ras = 0;
			}
			if (ram== 60) {
				rah += 1;
				ram = 0;
			}
			if (rah == 24) {
				rah = 0;
			}
			
			string decSign = "+";
			if (this._centre.Declination < 0)
				decSign = "-";
			
			int decd = (int)Math.Floor(Math.Abs(this._centre.Declination) * 180 / (float)Math.PI);
			int decm = (int)Math.Floor((Math.Abs(this._centre.Declination) * 180 / (float)Math.PI - decd) * 60);
			int decs = (int)Math.Floor(((Math.Abs(this._centre.Declination) * 180 / (float)Math.PI - decd) * 60 - decm) * 60 + 0.5);
			
			if (decs == 60) {
				decm += 1;
				decs = 0;
			}
			if (decm== 60) {
				decd += 1;
				decm = 0;
			}
			g.DrawString(string.Format("{0}h{1}m{2}s {3}{4}°{5}'{6}\"", rah, ram, ras, decSign, decd, decm, decs), this._legendFont, this._foregroundBrush, this._margin / 2f, this._imageWidth / 8f);
		}

		private void DrawMagnitudeScale(Graphics g)
		{
			float yOffset = 40 * this._scale;

			for(int i = (int)Math.Floor(this._limitingMagnitude); i > -2; i--)
			{
				DrawStar(g, 25 * this._scale, this._imageWidth - yOffset + 10 * this._scale, i);
				g.DrawString(i.ToString(), this._magnitudeFont, this._foregroundBrush, 45 * this._scale, this._imageWidth - yOffset);
				yOffset += 20 * this._scale;
			}
		}
	}
}
