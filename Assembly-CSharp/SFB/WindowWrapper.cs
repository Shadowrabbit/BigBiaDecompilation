using System;
using System.Windows.Forms;

namespace SFB
{
	public class WindowWrapper : IWin32Window
	{
		public WindowWrapper(IntPtr handle)
		{
			this._hwnd = handle;
		}

		public IntPtr Handle
		{
			get
			{
				return this._hwnd;
			}
		}

		private IntPtr _hwnd;
	}
}
