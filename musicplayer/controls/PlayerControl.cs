using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicplayer.controls
{
	public partial class PlayerControl : UserControl
	{
		private static PlayerControl? s_instance;
		private static object s_instanceLock = new object();

		public static PlayerControl GetPlayerControl()
		{
			lock (s_instanceLock)
			{
				if (s_instance == null) s_instance = new PlayerControl();
				return s_instance;
			}
		}

		private PlayerControl()
		{
			InitializeComponent();
			Disable();
		}

		public void Disable()
		{
			bBack.Enabled = false;
			bPlayPause.Enabled = false;
			bNext.Enabled = false;

			trbProgress.Enabled = false;
		}

		public void SetProgress(float progress)
		{
			trbProgress.Value = (int)(progress * 100);
		}
	}
}
