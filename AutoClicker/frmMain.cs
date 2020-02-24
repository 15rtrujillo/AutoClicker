using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker
{
	public partial class frmMain : Form
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

		//Mouse actions
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;

		public frmMain()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			tmrClick.Enabled = true;
		}

		public void DoMouseClick()
		{
			//Call the imported function with the cursor's current position
			uint X = (uint)Cursor.Position.X;
			uint Y = (uint)Cursor.Position.Y;
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			tmrClick.Enabled = false;
		}

		private void tmrClick_Tick(object sender, EventArgs e)
		{
			DoMouseClick();
		}

		private void numInterval_ValueChanged(object sender, EventArgs e)
		{
			tmrClick.Interval = Convert.ToInt32(numInterval.Value);
		}
	}
}
