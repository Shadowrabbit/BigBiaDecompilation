using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewLogCanvasController : MonoBehaviour
{
	private void Start()
	{
		GameController.ins.UIController.HideBlackMask(delegate
		{
		}, 0.5f);
		this.InitNewLogCanvas();
	}

	public void InitNewLogCanvas()
	{
		this.MaskPanel.SetActive(true);
		FileInfo[] files = GlobalController.Instance.LogDataController.GetFiles("*", SearchOption.AllDirectories);
		Array.Sort<FileInfo>(files, (FileInfo x, FileInfo y) => x.LastWriteTime.CompareTo(y.LastWriteTime));
		for (int i = files.Length - 1; i >= 0; i--)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogTileContent, this.LogTileContent.transform.parent);
			gameObject.SetActive(true);
			string str = files[i].Name.Split(new char[]
			{
				'.'
			})[0];
			gameObject.transform.GetComponentInChildren<TMP_Text>().text = "BIG BIA之战" + (i + 1).ToString();
			gameObject.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate()
			{
				this.OnShowLogContent(str);
			});
		}
	}

	private void OnShowLogContent(string fileName)
	{
		this.MaskPanel.SetActive(false);
		this.NewLogPanel.InitPanel(fileName);
	}

	public void OnCloseLogCanvas()
	{
		UnityEngine.Object.Destroy(base.gameObject);
		UIController.LockLevel = UIController.UILevel.None;
		GameController.ins.UIController.ShowBlackMask(delegate
		{
			GameController.ins.UIController.HideBlackMask(delegate
			{
			}, 0.5f);
		}, 0.5f);
	}

	public GameObject MaskPanel;

	public GameObject LogTileContent;

	public NewLogPanel NewLogPanel;
}
