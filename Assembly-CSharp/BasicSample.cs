using System;
using SFB;
using UnityEngine;

public class BasicSample : MonoBehaviour
{
	private void OnGUI()
	{
		Vector3 s = new Vector3((float)Screen.width / 800f, (float)Screen.height / 600f, 1f);
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, s);
		GUILayout.Space(20f);
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		GUILayout.Space(20f);
		GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
		if (GUILayout.Button("Open File", Array.Empty<GUILayoutOption>()))
		{
			this.WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open File Async", Array.Empty<GUILayoutOption>()))
		{
			StandaloneFileBrowser.OpenFilePanelAsync("Open File", "", "", false, delegate(string[] paths)
			{
				this.WriteResult(paths);
			});
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open File Multiple", Array.Empty<GUILayoutOption>()))
		{
			this.WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", true));
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open File Extension", Array.Empty<GUILayoutOption>()))
		{
			this.WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "txt", true));
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open File Directory", Array.Empty<GUILayoutOption>()))
		{
			this.WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", Application.dataPath, "", true));
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open File Filter", Array.Empty<GUILayoutOption>()))
		{
			ExtensionFilter[] extensions = new ExtensionFilter[]
			{
				new ExtensionFilter("Image Files", new string[]
				{
					"png",
					"jpg",
					"jpeg"
				}),
				new ExtensionFilter("Sound Files", new string[]
				{
					"mp3",
					"wav"
				}),
				new ExtensionFilter("All Files", new string[]
				{
					"*"
				})
			};
			this.WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true));
		}
		GUILayout.Space(15f);
		if (GUILayout.Button("Open Folder", Array.Empty<GUILayoutOption>()))
		{
			string[] paths3 = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", true);
			this.WriteResult(paths3);
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open Folder Async", Array.Empty<GUILayoutOption>()))
		{
			StandaloneFileBrowser.OpenFolderPanelAsync("Select Folder", "", true, delegate(string[] paths)
			{
				this.WriteResult(paths);
			});
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Open Folder Directory", Array.Empty<GUILayoutOption>()))
		{
			string[] paths2 = StandaloneFileBrowser.OpenFolderPanel("Select Folder", Application.dataPath, true);
			this.WriteResult(paths2);
		}
		GUILayout.Space(15f);
		if (GUILayout.Button("Save File", Array.Empty<GUILayoutOption>()))
		{
			this._path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "");
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Save File Async", Array.Empty<GUILayoutOption>()))
		{
			StandaloneFileBrowser.SaveFilePanelAsync("Save File", "", "", "", delegate(string path)
			{
				this.WriteResult(path);
			});
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Save File Default Name", Array.Empty<GUILayoutOption>()))
		{
			this._path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", "");
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Save File Default Name Ext", Array.Empty<GUILayoutOption>()))
		{
			this._path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", "dat");
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Save File Directory", Array.Empty<GUILayoutOption>()))
		{
			this._path = StandaloneFileBrowser.SaveFilePanel("Save File", Application.dataPath, "", "");
		}
		GUILayout.Space(5f);
		if (GUILayout.Button("Save File Filter", Array.Empty<GUILayoutOption>()))
		{
			ExtensionFilter[] extensions2 = new ExtensionFilter[]
			{
				new ExtensionFilter("Binary", new string[]
				{
					"bin"
				}),
				new ExtensionFilter("Text", new string[]
				{
					"txt"
				})
			};
			this._path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", extensions2);
		}
		GUILayout.EndVertical();
		GUILayout.Space(20f);
		GUILayout.Label(this._path, Array.Empty<GUILayoutOption>());
		GUILayout.EndHorizontal();
	}

	public void WriteResult(string[] paths)
	{
		if (paths.Length == 0)
		{
			return;
		}
		this._path = "";
		foreach (string str in paths)
		{
			this._path = this._path + str + "\n";
		}
	}

	public void WriteResult(string path)
	{
		this._path = path;
	}

	private string _path;
}
