using System;

namespace SFB
{
	public class StandaloneFileBrowser
	{
		public static string[] OpenFilePanel(string title, string directory, string extension, bool multiselect)
		{
			ExtensionFilter[] array;
			if (!string.IsNullOrEmpty(extension))
			{
				(array = new ExtensionFilter[1])[0] = new ExtensionFilter("", new string[]
				{
					extension
				});
			}
			else
			{
				array = null;
			}
			ExtensionFilter[] extensions = array;
			return StandaloneFileBrowser.OpenFilePanel(title, directory, extensions, multiselect);
		}

		public static string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiselect)
		{
			return StandaloneFileBrowser._platformWrapper.OpenFilePanel(title, directory, extensions, multiselect);
		}

		public static void OpenFilePanelAsync(string title, string directory, string extension, bool multiselect, Action<string[]> cb)
		{
			ExtensionFilter[] array;
			if (!string.IsNullOrEmpty(extension))
			{
				(array = new ExtensionFilter[1])[0] = new ExtensionFilter("", new string[]
				{
					extension
				});
			}
			else
			{
				array = null;
			}
			ExtensionFilter[] extensions = array;
			StandaloneFileBrowser.OpenFilePanelAsync(title, directory, extensions, multiselect, cb);
		}

		public static void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb)
		{
			StandaloneFileBrowser._platformWrapper.OpenFilePanelAsync(title, directory, extensions, multiselect, cb);
		}

		public static string[] OpenFolderPanel(string title, string directory, bool multiselect)
		{
			return StandaloneFileBrowser._platformWrapper.OpenFolderPanel(title, directory, multiselect);
		}

		public static void OpenFolderPanelAsync(string title, string directory, bool multiselect, Action<string[]> cb)
		{
			StandaloneFileBrowser._platformWrapper.OpenFolderPanelAsync(title, directory, multiselect, cb);
		}

		public static string SaveFilePanel(string title, string directory, string defaultName, string extension)
		{
			ExtensionFilter[] array;
			if (!string.IsNullOrEmpty(extension))
			{
				(array = new ExtensionFilter[1])[0] = new ExtensionFilter("", new string[]
				{
					extension
				});
			}
			else
			{
				array = null;
			}
			ExtensionFilter[] extensions = array;
			return StandaloneFileBrowser.SaveFilePanel(title, directory, defaultName, extensions);
		}

		public static string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions)
		{
			return StandaloneFileBrowser._platformWrapper.SaveFilePanel(title, directory, defaultName, extensions);
		}

		public static void SaveFilePanelAsync(string title, string directory, string defaultName, string extension, Action<string> cb)
		{
			ExtensionFilter[] array;
			if (!string.IsNullOrEmpty(extension))
			{
				(array = new ExtensionFilter[1])[0] = new ExtensionFilter("", new string[]
				{
					extension
				});
			}
			else
			{
				array = null;
			}
			ExtensionFilter[] extensions = array;
			StandaloneFileBrowser.SaveFilePanelAsync(title, directory, defaultName, extensions, cb);
		}

		public static void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
		{
			StandaloneFileBrowser._platformWrapper.SaveFilePanelAsync(title, directory, defaultName, extensions, cb);
		}

		private static IStandaloneFileBrowser _platformWrapper = new StandaloneFileBrowserWindows();
	}
}
