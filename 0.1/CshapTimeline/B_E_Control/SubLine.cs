/*
 * 
 * User: zouli
 * Date: 2010-8-12
 * Time: 11:59
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using b_e.Common.Drawing;

namespace b_e.Common.Control
{
	/// <summary>
	/// Description of SubLine.
	/// </summary>
	public class SubLine : BaseEntity
	{
		#region 属性
		private Point m_point1;
		public Point Point1 {
			get { return m_point1; }
			set { m_point1 = value; }
		}
		
		private Point m_point2;
		public Point Point2 {
			get { return m_point2; }
			set { m_point2 = value; }
		}
		
		#region 文字
		private string m_text;
		public string Text {
			get { return m_text; }
			set { m_text = value; }
		}
		
		private Font m_textFont;
		public Font TextFont {
			get { return m_textFont; }
			set { m_textFont = value; }
		}
		
		private Brush m_textBrush;
		public Brush TextBrush {
			get { return m_textBrush; }
			set { m_textBrush = value; }
		}
		
		private float m_textHeight = 12;
		public float TextHeight {
			get { return m_textHeight; }
			set { m_textHeight = value; }
		}
		
		private int m_textWidth = 30;
		#endregion
		#endregion

		public SubLine()
		{
			this.TextFont = new Font(SystemFonts.DefaultFont.Name, this.TextHeight);
			this.TextBrush = new SolidBrush(SystemColors.MenuText);
		}
		public SubLine(Point point1, Point point2, string text) :
			this()
		{
			this.Point1 = point1;
			this.Point2 = point2;
			this.Text = text;
		}
		public SubLine(int x1, int y1, int x2, int y2, string text) :
			this(new Point(x1, y1), new Point(x2, y2), text)
		{}
		
		public override void Draw(Graphics g)
		{
			this.DrawLine(g);
			this.DrawText(g);
		}
		
		private void DrawLine(Graphics g)
		{
			int dis = Math.Abs(this.Point2.X - this.Point1.X) / 2;
			Point point1 = this.Point1;
			Point point2 = new Point(this.Point1.X + dis, this.Point1.Y);
			Point point3 = new Point(this.Point2.X - dis, this.Point2.Y);
			Point point4 = this.Point2;
			
			g.DrawBezier(this.Pen, point1, point2, point3, point4);
		}
		
		private void DrawText(Graphics g)
		{
			this.m_textWidth = DrawStringHelper.GetTextWidth(g, this.Text, this.TextFont);
			
			Point point5 = new Point(this.Point2.X + this.m_textWidth, this.Point2.Y);
			g.DrawLine(this.Pen, this.Point2, point5);
			
			//TODO:文字对齐方式，以后改为可配置
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Far;
			g.DrawString(this.Text, this.TextFont, this.TextBrush, this.Point2, stringFormat);
		}
		
		public override void Highlight(Graphics g)
		{
			throw new NotImplementedException();
		}
		
		public override bool isMouseOn(Graphics g, Point mouseLocation)
		{
			Rectangle boundingBox = 
				DrawStringHelper.GetTextBoundingBox(g, this.Text, this.TextFont, this.Point2);
			return boundingBox.Contains(mouseLocation);
		}

		public override void OnMouseDown(object sender, MouseEventArgs e, Graphics g)
		{
			base.OnMouseDown(sender, e, g);
		}
		
		public override void OnMouseMove(object sender, MouseEventArgs e, Graphics g)
		{
			base.OnMouseMove(sender, e, g);
			Rectangle boundingBox = 
				DrawStringHelper.GetTextBoundingBox(g, this.Text, this.TextFont, this.Point2);

			MessageBox.Show(boundingBox.ToString());
		}
	}
}
