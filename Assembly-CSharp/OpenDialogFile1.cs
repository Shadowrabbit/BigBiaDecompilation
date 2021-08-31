using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class OpenDialogFile1 : MonoBehaviour
{
	private void Update()
	{
	}

	public string ChoosePath()
	{
		IntPtr pidl = OpenDialogFile1.DllOpenFileDialog.SHBrowseForFolder(new OpenDialogFile1.OpenDialogDir
		{
			pszDisplayName = new string(new char[2000]),
			lpszTitle = "Open Project"
		});
		char[] array = new char[2000];
		for (int i = 0; i < 2000; i++)
		{
			array[i] = '\0';
		}
		OpenDialogFile1.DllOpenFileDialog.SHGetPathFromIDList(pidl, array);
		this.fullDirPath = new string(array);
		this.fullDirPath = this.fullDirPath.Substring(0, this.fullDirPath.IndexOf('\0'));
		return this.fullDirPath;
	}

	public string OpenDialog()
	{
		OpenDialogFile1.OpenDialogFile openDialogFile = new OpenDialogFile1.OpenDialogFile();
		openDialogFile.structSize = Marshal.SizeOf<OpenDialogFile1.OpenDialogFile>(openDialogFile);
		openDialogFile.filter = "All Files\0*.*\0\0";
		openDialogFile.file = new string(new char[256]);
		openDialogFile.maxFile = openDialogFile.file.Length;
		openDialogFile.fileTitle = new string(new char[64]);
		openDialogFile.maxFileTitle = openDialogFile.fileTitle.Length;
		openDialogFile.initialDir = Application.dataPath;
		openDialogFile.title = "Open Project";
		openDialogFile.defExt = "*";
		openDialogFile.flags = 530952;
		if (OpenDialogFile1.DllOpenFileDialog.GetOpenFileName(openDialogFile))
		{
			return openDialogFile.file;
		}
		return null;
	}

	private string fullDirPath;

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class OpenDialogFile
	{
		public int structSize;

		public IntPtr dlgOwner = IntPtr.Zero;

		public IntPtr instance = IntPtr.Zero;

		public string filter;

		public string customFilter;

		public int maxCustFilter;

		public int filterIndex;

		public string file;

		public int maxFile;

		public string fileTitle;

		public int maxFileTitle;

		public string initialDir;

		public string title;

		public int flags;

		public short fileOffset;

		public short fileExtension;

		public string defExt;

		public IntPtr custData = IntPtr.Zero;

		public IntPtr hook = IntPtr.Zero;

		public string templateName;

		public IntPtr reservedPtr = IntPtr.Zero;

		public int reservedInt;

		public int flagsEx;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class OpenDialogDir
	{
		public IntPtr hwndOwner = IntPtr.Zero;

		public IntPtr pidlRoot = IntPtr.Zero;

		public string pszDisplayName;

		public string lpszTitle;

		public uint ulFlags;

		public IntPtr lpfn = IntPtr.Zero;

		public IntPtr lParam = IntPtr.Zero;

		public int iImage;
	}

	public class DllOpenFileDialog
	{
		[DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
		public static extern bool GetOpenFileName([In] [Out] OpenDialogFile1.OpenDialogFile ofn);

		[DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
		public static extern bool GetSaveFileName([In] [Out] OpenDialogFile1.OpenDialogFile ofn);

		[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
		public static extern IntPtr SHBrowseForFolder([In] [Out] OpenDialogFile1.OpenDialogDir ofn);

		[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
		public static extern bool SHGetPathFromIDList([In] IntPtr pidl, [In] [Out] char[] fileName);
	}
}
