using System;
using System.IO;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSubmitPanel : MonoBehaviour
{
	public global::SteamController SteamController
	{
		get
		{
			return global::SteamController.Instance;
		}
	}

	public SteamEvent SteamEvent
	{
		get
		{
			return this.SteamController.SteamEvent;
		}
	}

	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	private void Start()
	{
		this.submit.onClick.AddListener(new UnityAction(this.Submit));
		SteamEvent steamEvent = this.SteamEvent;
		steamEvent.OnCreateItem = (Action<PublishedFileId_t, bool, string>)Delegate.Combine(steamEvent.OnCreateItem, new Action<PublishedFileId_t, bool, string>(this.OnCreateItemSuccess));
		SteamEvent steamEvent2 = this.SteamEvent;
		steamEvent2.OnSubmitItem = (Action<bool, string>)Delegate.Combine(steamEvent2.OnSubmitItem, new Action<bool, string>(this.OnSubmitItem));
		this.StatePanel.SetActive(false);
	}

	private void Submit()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (!this.itemFilePath.HasValue())
		{
			return;
		}
		this.submit.enabled = false;
		this.workshopItem = new WorkShopItem();
		this.workshopItem.Title = this.title.text.ToString();
		this.workshopItem.Visibility = (ERemoteStoragePublishedFileVisibility)this.dropDown.value;
		this.workshopItem.Content = this.itemFilePath.filePath;
		this.workshopItem.Description = this.description.text.ToString();
		this.workshopItem.TagList.Add(SteamUGCTag.Card.ToString());
		this.workshopItem.PreviewFile = this.preViewFile.Path;
		FileInfo fileInfo = new FileInfo(this.itemFilePath.filePath + "//mod.info");
		if (fileInfo.Exists)
		{
			string s = File.ReadAllText(fileInfo.FullName);
			try
			{
				ulong value = ulong.Parse(s);
				global::SteamController.Instance.SteamUGC.IsCreateItem = true;
				global::SteamController.Instance.SteamUGC.SetFileId(new PublishedFileId_t(value));
				global::SteamController.Instance.SteamUGC.UpdateItem(this.workshopItem);
				this.StatePanel.SetActive(true);
				this.StateText.text = "发现MOD版本标识，准备更新Steam创意工坊物品 ...\n";
				return;
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
			}
		}
		global::SteamController.Instance.SteamUGC.CreateItem(EWorkshopFileType.k_EWorkshopFileTypeFirst);
		this.StatePanel.SetActive(true);
		this.StateText.text = "开始创建Steam创意工坊物品 ...\n";
	}

	private void OnCreateItemSuccess(PublishedFileId_t id, bool create, string message)
	{
		if (!create)
		{
			return;
		}
		File.WriteAllText(new FileInfo(this.itemFilePath.filePath + "//mod.info").FullName, id.m_PublishedFileId.ToString());
		Text stateText = this.StateText;
		stateText.text += "\n创建物品成功\n";
		Text stateText2 = this.StateText;
		stateText2.text += message;
		Debug.Log("创建物品成功");
		this.SteamController.SteamUGC.UpdateItem(this.workshopItem);
		Text stateText3 = this.StateText;
		stateText3.text += "\n正在上传MOD文件 ...";
	}

	private void OnSubmitItem(bool success, string message)
	{
		Debug.Log(success);
		if (success)
		{
			Text stateText = this.StateText;
			stateText.text += "\nMOD物品上传成功！\n";
			Text stateText2 = this.StateText;
			stateText2.text += message;
		}
		else
		{
			Text stateText3 = this.StateText;
			stateText3.text += "\nMOD物品上传失败\n";
			Text stateText4 = this.StateText;
			stateText4.text += message;
		}
		this.submit.enabled = true;
		Text stateText5 = this.StateText;
		stateText5.text += "\n创意工坊物品上传完毕，请关闭窗口\n";
	}

	public void OnCancle()
	{
		base.gameObject.SetActive(false);
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
	}

	public void CloseStatePanel()
	{
		this.StatePanel.SetActive(false);
	}

	public InputField title;

	public ItemFilePath itemFilePath;

	public PreViewFile preViewFile;

	public Dropdown dropDown;

	public InputField description;

	public Button submit;

	private WorkShopItem workshopItem;

	public Text StateText;

	public GameObject StatePanel;
}
