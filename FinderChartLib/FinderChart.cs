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

		private Color _backgroundColor;
		private Color _foregroundColor;

		private Brush _backgroundBrush;
		private Brush _foregroundBrush;
		private Pen _foregroundPen;
		private Font _legendFont = new Font(FontFamily.GenericSerif, 10);
		public StarCatalog StarCatalog;

		public FinderChart()
		{
			this.StarCatalog = new StarCatalog();

			SetFieldView(1000, 12, MathExt.Deg2Rad(4), MathExt.Deg2Rad(0.7122222222f), (MathExt.Deg2Rad(41.26889f), "Test");
			SetDrawMode(Enums.ChartDrawMode.BlackOnWhite);
		}
		
		public void SetFieldView(float imageWidth, float limitingMagnitude, float radiusRadians, float raRadians, float declinationRadians, string title)
		{
			this._imageWidth = imageWidth;
			this._limitingMagnitude = limitingMagnitude;
			this._centre = new RADec(raRadians, declinationRadians);
			this._title = title;
			
			this._centreX = this._imageWidth / 2;
			this._centreY = this._imageWidth / 2;
			
			this._scale = this._imageWidth / 1000;
			this._margin = 20f * this._scale;
			
			this._radiusPixels = this._centreX - this._margin;
			this._radiusRadians = radiusRadians;
			this._radiusScale = this._radiusPixels / this._radiusRadians;
			
		}

		public void SetDrawMode(Enums.ChartDrawMode drawMode)
		{
			if (drawMode == Enums.ChartDrawMode.BlackOnWhite)
			{
				this._backgroundColor = Color.White;
				this._foregroundColor = Color.Black;
			}
			else
			{
				this._backgroundColor = Color.Black;
				this._foregroundColor = Color.White;
			}

			this._backgroundBrush = new SolidBrush(this._backgroundColor);
			this._foregroundBrush = new SolidBrush(this._foregroundColor);
			this._foregroundPen = new Pen(this._foregroundBrush);
		}

		public Bitmap CreateChart()
		{
			Bitmap finderChart = new Bitmap(this._imageWidth, this._imageWidth);
			Graphics g = Graphics.FromImage(finderChart);

			g.SmoothingMode = SmoothingMode.AntiAlias;

			g.FillRectangle(this._backgroundBrush, 0, 0, this._imageWidth, this._imageWidth);

			DrawStars(g);
			DrawFrame(g);
			DrawCoordinates(g);
			DrawMagnitudeScale(g);
			DrawTitle(g);
			DrawLegend(g);
			
			return finderChart;
		}
		
		private float MagnitudeToRadius(float magnitude)
		{
			return 1.0f * (float)(Math.Pow(1.27f, (Math.Floor(this._limitingMagnitude) - magnitude)));
		}

		private void DrawTitle(Graphics g)
		{
			
		}
		
		private void DrawLegend(Graphics g)
		{
			
		}
		
		private void DrawFrame(Graphics g)
		{
			g.DrawEllipse(this._foregroundPen, this._centreX - this._radiusPixels, this._centreY - this._radiusPixels, this._centreX + this._radiusPixels, this._centreY + this._radiusPixels);
		}
		
		private void DrawStar(Graphics g, float x, float y, float magnitude)
		{
			float radius = MagnitudeToRadius(magnitude);
			g.FillEllipse(this._foregroundBrush, x - radius, y - radius, radius * 2, radius * 2);
		}

		private void DrawStars(Graphics g)
		{
			for(int i = 0; i < this.StarCatalog.Stars.Length; i++)
			{
				if (this.StarCatalog.Stars[i].Magnitude <= this.LimitingMagnitude) {
					float angularDistance = AstroCalculations.AngularDistance(this.Centre, this.StarCatalog.Stars[i].Coordinates);
					if (angularDistance < this.RadiusScale)
					{
						LM lm = AstroCalculations.RADecToLM(this.Centre, this.StarCatalog.Stars[i].Coordinates);
						float x = lm.L * -1 * this._radiusScale + this._centreX;
						float y = lm.M * this._radiusScale + this._centreY;
						DrawStar(g, x, y, this.StarCatalog.Stars[i].Magnitude);
					}
				}
			}
		}
		
		private void DrawCoordinates(Graphics g)
		{
			/*

        decsign = '+'
        if dec < 0.0:
            decsign = '-'
            pass
        decd= int(abs(dec)*180/pi)
        decm = int((abs(dec)*180/pi-decd)*60)
        decs = int( ((abs(dec)*180/pi-decd)*60 -decm)*60+0.5)

        if decs == 60:
            decm += 1
            decs = 0
            pass
        if decm == 60:
            decd+=1
            decm = 0
            pass

        self.graphics.text_right(x, y, str(rah).rjust(2),begin=True, end=False)
        self.graphics.text_superscript(self.language['h'])
        self.graphics.text(str(ram))
        self.graphics.text_superscript(self.language['m'])
        self.graphics.text(str(ras))
        self.graphics.text_superscript(self.language['s'])
        dectext = ' '+decsign+str(decd)+'\312'+str(decm)+'\251'+str(decs)+'\042'
        self.graphics.text(dectext,begin=False, end=True)
			*/
			int rah = (int)Math.Floor(this._centre.RightAscension * 12 / (float)Math.PI);
			int ram = (int)Math.Floor((this._centre.RightAscension * 12 / (float)Math.PI - rah) * 60);
			int ras = (int)Math.Floor(((this._centre.RightAscension * 12 / (float)Math.PI - rah) * 60 - ram) * 60 + 0.5;
			
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
			int decs = (int)Math.Floor(((Math.Abs(this._centre.Declination) * 180 / (float)Math.PI - decd) * 60 - decm) * 60 + 0.5;
			
			if (decs == 60) {
				decm += 1;
				decs = 0;
			}
			if (decm== 60) {
				decd += 1;
				decm = 0;
			}			
			
		}

		private void DrawMagnitudeScale(Graphics g)
		{
			int yOffset = 20;

			for(int i = (int)Math.Floor(this._limitingMagnitude); i > -2; i--)
			{
				DrawStar(g, 20, this._imageHeight - yOffset + 10, i);
				g.DrawString(i.ToString(), this._legendFont, this._foregroundBrush, 30, this._imageHeight - yOffset);
				yOffset += 20;
			}
		}
	}
}
