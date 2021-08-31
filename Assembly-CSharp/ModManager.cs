using System;
using System.IO;
using UnityEngine;

public class ModManager : MonoBehaviour
{
	public static void SetLockModWorking(string modFilePath)
	{
		int num = modFilePath.LastIndexOf('/');
		if (num < 0)
		{
			num = modFilePath.Length;
		}
		if (!Directory.Exists(modFilePath.Substring(0, num)))
		{
			Directory.CreateDirectory(Application.streamingAssetsPath + "/Mods/Unlock" + modFilePath.Substring(0, num));
		}
		try
		{
			File.Copy(Application.streamingAssetsPath + "/Lock" + modFilePath, Application.streamingAssetsPath + "/Mods/Unlock" + modFilePath);
		}
		catch
		{
			Debug.LogError("移动MOD失败");
		}
	}

	public static void SetModNotWorking(string modFilePath)
	{
	}

	public static bool IsModWorking(string modFilePath)
	{
		return File.Exists(Application.streamingAssetsPath + "/Mods/Unlock" + modFilePath);
	}

	private static void moveFiles(string srcFolder, string destFolder)
	{
		foreach (FileInfo fileInfo in new DirectoryInfo(srcFolder).GetFiles())
		{
			if (fileInfo.Extension == ".png")
			{
				fileInfo.MoveTo(Path.Combine(destFolder, fileInfo.Name));
			}
		}
	}
}
