using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
	public class ErrorHandler
	{
		public static void HandleException(Exception ex)
		{
			HandleException(ex, ex.ToString(), ex.Message);
		}

		public static void HandleException(Exception ex, string title)
		{
			HandleException(ex, title, ex.Message);
		}

		public static void HandleException(Exception ex, string title, string text)
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				//throw ex;
				MessageBox.Show(text, "Error: " + title);
				if (MessageBox.Show(ex.Message + "\n" + ex.StackTrace + "\n\nDo you wish to throw this exception?", ex.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes) throw ex;
			}
			else
			{
				MessageBox.Show(text, "Error: " + title);
			}
		}
	}
}
