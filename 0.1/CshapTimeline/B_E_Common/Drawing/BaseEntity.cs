/*
 * User: zouli
 * Date: 2010-8-12
 * Time: 11:54
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace b_e.Common.Drawing
{
	//public delegate void OnMouseDown(object sender, MouseButtonEventArgs e);
	
	/// <summary>
	/// Description of BaseEntity.
	/// </summary>
	public abstract class BaseEntity
	{
		#region 属性
		private Pen m_pen;
		public Pen Pen {
			get { return m_pen; }
			set { m_pen = value; }
		}
		
		private bool isHighlight = true;		
		public bool IsHighlight {
			get { return isHighlight; }
			set { isHighlight = value; }
		}
		
		#endregion
		
		public BaseEntity()
		{
			this.Pen = new Pen(Color.FromArgb(255, 100, 100, 100), 1);
		}

		public abstract void Draw(Graphics g);
		
		public abstract void Highlight(Graphics g);
		
		public abstract bool isMouseOn(Graphics g, Point mouseLocation);
		
		public virtual void OnMouseDown(object sender, MouseEventArgs e, Graphics g)
		{
			if(this.IsHighlight)
				this.Highlight(g);
		}
		
		public virtual void OnMouseMove(object sender, MouseEventArgs e, Graphics g)
		{}
	}
}
