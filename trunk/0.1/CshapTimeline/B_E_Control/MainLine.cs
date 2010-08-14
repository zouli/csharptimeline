/*
 * 
 * User: zouli
 * Date: 2010-8-12
 * Time: 15:26
 */
using System;
using System.Drawing;
using b_e.Common.Drawing;

namespace b_e.Common.Control
{
	/// <summary>
	/// Description of MainLine.
	/// </summary>
	public class MainLine : BaseEntity
	{
		#region 属性
		private int m_y;		
		public int Y {
			get { return m_y; }
			set { m_y = value; }
		}
		#endregion
		
		public MainLine(int y) 
		{
			this.Y = y;
		}
		
		public override void Draw(System.Drawing.Graphics g)
		{
			g.DrawLine(this.Pen, -100, this.Y, 5000, this.Y);
		}
		
		public override void Highlight(Graphics g)
		{
			throw new NotImplementedException();
		}
		
		public override bool isMouseOn(Graphics g, Point mouseLocation)
		{
			//throw new NotImplementedException();
			return false;
		}

		public override void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e, Graphics g)
		{
			base.OnMouseDown(sender, e, g);
		}
	}
}
