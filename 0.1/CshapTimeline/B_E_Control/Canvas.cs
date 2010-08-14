/*
 * User: zouli
 * Date: 2010-8-9
 * Time: 14:41
 */
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using b_e.Common.Drawing;

namespace b_e.Common.Control
{
	/// <summary>
	/// Description of Canvas.
	/// </summary>
	public partial class Canvas : PictureBox
	{
		private bool m_MouseDown = false;
		private Point m_MouseDownPoint;
		private ArrayList m_EntityList = new ArrayList();
		
		public Canvas(){}
		
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			
			Graphics g = pe.Graphics;
			
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			foreach (BaseEntity entity in m_EntityList)
			{
				entity.Draw(g);
			}
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			
			if(e.Button == MouseButtons.Left)
			{
				m_MouseDown = true;
				m_MouseDownPoint = e.Location;
			}
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			
			OnMouseMoveOnEntity(e);
			
			if(e.Button == MouseButtons.Left)
			{
				if(m_MouseDown)
				{					
					Point pt = this.Location;
					pt.Offset(e.X - this.m_MouseDownPoint.X, e.Y - this.m_MouseDownPoint.Y);
					this.Location = pt;
					
					this.Refresh();
				}
			}
		}
		
		private void OnMouseMoveOnEntity(MouseEventArgs e)
		{
			Graphics g = this.CreateGraphics();
			foreach(BaseEntity entity in this.m_EntityList)
			{
				if(entity.isMouseOn(g, e.Location))
					entity.OnMouseMove(this, e, g);
			}
		}
		
		public void DrawSubLine(Point point1, Point point2, string text)
		{
			m_EntityList.Add(new SubLine(point1, point2, text));
		}
		public void DrawSubLine(int x1, int y1, int x2, int y2, string text)
		{
			DrawSubLine(new Point(x1, y1), new Point(x2, y2), text);
		}
		
		public void DrawMainLine(int y)
		{
			m_EntityList.Add(new MainLine(y));
		}
	}
}
