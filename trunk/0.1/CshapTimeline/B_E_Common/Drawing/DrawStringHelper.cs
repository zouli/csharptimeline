/*
 * User: zouli
 * Date: 2010-8-12
 * Time: 17:55
 */
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;

namespace b_e.Common.Drawing
{
	/// <summary>
	/// Description of DrawStringHelper.
	/// </summary>
	public static class DrawStringHelper
	{
		#region Graphics Plus
		public static Size MeasureStringToSize(this Graphics g, string text, Font font)
		{
			return g.MeasureString(text, font).ToSize();
		}
		#endregion
		
		public static int GetTextWidth(Graphics g, string text, Font font)
		{
			return g.MeasureStringToSize(text, font).Width;
		}
		
		public static Rectangle GetTextBoundingBox(Graphics g, string text, Font font)
		{
			return GetTextBoundingBox(g, text, font, new Point(0, 0));
		}
		
		public static Rectangle GetTextBoundingBox(Graphics g, string text, Font font, Point location)
		{
			Size size = g.MeasureStringToSize(text, font);
			Rectangle rect = new Rectangle(location, size);
			return rect;
		}
		
		public static string[] GetSystemFonts()
		{
			ArrayList arrayFont = new ArrayList();
			FontFamily[] fonts = GetSystemFontFamilys();
			foreach(FontFamily fontFamily in fonts)
			{
				arrayFont.Add(fontFamily.Name);
			}
			return (string[])arrayFont.ToArray();
		}
		
		public static FontFamily[] GetSystemFontFamilys()
		{
			InstalledFontCollection fonts = new InstalledFontCollection();
			return fonts.Families;
		}
	}
}
