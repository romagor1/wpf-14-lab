using System.Drawing;
using System.Windows.Forms;
using System;

namespace wpf_14_lab {
	public partial class Form1 : Form
	{
		const int initialRadius = 120;
		const int centerX = 500;
		const int centerY = 380;
		const double factor = 0.45; // Factor to determine the size of the next smaller radius 

		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			DrawRecursionStage(centerX, centerY, initialRadius, e.Graphics);
		}

		private void DrawRecursionStage(int x, int y, int radius, Graphics g)
		{
			if (IsRecursionDepthReached(radius))
				return;

			DrawCircle(x, y, radius, g);
			double h;

			h = radius * 2 + Math.Cos(3.14 / 6) - 40;
			float ang2 = (float)(radius + (3.14 * 6 * 2));


			int newRadius = (int)(radius * factor);

			DrawRecursionStage((int)(x + h * Math.Cos(ang2)), (int)(y + h * Math.Sin(ang2)), newRadius, g);
			DrawRecursionStage((int)(x - h * Math.Cos(ang2)), (int)(y - h * Math.Sin(ang2)), newRadius, g);

			DrawRecursionStage(x, (int)(y + h), newRadius, g);
			DrawRecursionStage(x, (int)(y - h), newRadius, g);
			DrawRecursionStage((int)(x + h * Math.Cos(ang2)), (int)(y - h * Math.Sin(ang2)), newRadius, g);
			DrawRecursionStage((int)(x - h * Math.Cos(ang2)), (int)(y + h * Math.Sin(ang2)), newRadius, g);

		}

		private void DrawCircle(int x, int y, int radius, Graphics g)
		{
			var shape = new PointF[6];
			for (int a = 0; a < 6; a++)
			{
				shape[a] = new PointF(
				x + radius * (float)Math.Cos(a * 60 * Math.PI / 180f),
				y + radius * (float)Math.Sin(a * 60 * Math.PI / 180f));
			}

			g.DrawPolygon(Pens.Red, shape);
  }

		private static bool IsRecursionDepthReached(int radius)
		{
  return radius < Math.Pow(factor, 3) * initialRadius;
		}
	}
}
