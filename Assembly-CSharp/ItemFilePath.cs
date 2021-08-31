using System;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemFilePath : MonoBehaviour
{
	private void Start()
	{
		this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
		this.fileType.onValueChanged.AddListener(new UnityAction<int>(this.OnFileTypeChange));
	}

	public bool HasValue()
	{
		return !string.IsNullOrEmpty(this.filePath);
	}

	private void OnButtonClick()
	{
		string text = null;
		if (this.m_SubmitType == ItemFilePath.SubmitType.SingleFile)
		{
			string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
			if (array != null && array.Length != 0)
			{
				text = array[0];
			}
		}
		else
		{
			string[] array2 = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", true);
			if (array2 != null && array2.Length != 0)
			{
				text = array2[0];
			}
		}
		this.text.text = text;
		this.filePath = text;
	}

	private void OnFileTypeChange(int val)
	{
		this.m_SubmitType = (ItemFilePath.SubmitType)val;
	}

	public Button button;

	public Text text;

	public Dropdown fileType;

	[HideInInspector]
	public string filePath;

	private ItemFilePath.SubmitType m_SubmitType;

	private enum SubmitType
	{
		SingleFile,
		Folder
	}
}
