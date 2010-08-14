/*
 * User: zouli
 * Date: 2010-8-3
 * Time: 12:50
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using b_e.Common;
using b_e.Common.Data;

namespace CshapTimeline
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
		}
//			DBHelper dbHelper = new DBHelper();
//			DataTable dt = dbHelper.ExecuteReaderDataTable("SELECT * FROM test");
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			this.picPanel.DrawMainLine(200);
			this.picPanel.DrawSubLine(100, 200, 500, 300, "31");
			this.picPanel.DrawSubLine(200, 200, 300, 300, "32");
			this.picPanel.DrawSubLine(300, 200, 500, 30, "33");
			this.picPanel.DrawSubLine(400, 200, 150, 300, "34");
			this.picPanel.Refresh();
		}
		void PicPanelMouseMove(object sender, MouseEventArgs e)
		{
			Thread.Sleep(6);
			toolStripLabel1.Text = e.Location.ToString();
		}
	}
}
