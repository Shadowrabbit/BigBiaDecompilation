using System;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorkshopItemDetail : MonoBehaviour
{
	private MySteamUGC SteamUGC
	{
		get
		{
			return global::SteamController.Instance.SteamUGC;
		}
	}

	private void Start()
	{
		this.describe.onValueChanged.AddListener(new UnityAction<bool>(this.OnValueChange));
	}

	public void OnValueChange(bool value)
	{
		if (value)
		{
			this.SteamUGC.Subscribe(this.publishedFileId);
			return;
		}
		this.SteamUGC.UnSubscribe(this.publishedFileId);
	}

	public void SetMessage(SteamUGCDetails_t itemDetails_T)
	{
		this.publishedFileId = itemDetails_T.m_nPublishedFileId;
		this.title.text = itemDetails_T.m_rgchTitle;
		this.describeNum.text = itemDetails_T.m_unVotesDown.ToString();
		this.describe.isOn = this.SteamUGC.IsSubscribeItem(itemDetails_T.m_nPublishedFileId);
	}

	public PublishedFileId_t publishedFileId;

	public Text title;

	public Text type;

	public Text describeNum;

	public Text favorable;

	public Toggle describe;
}
