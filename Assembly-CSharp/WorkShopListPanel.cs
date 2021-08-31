using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class WorkShopListPanel : MonoBehaviour
{
	public global::SteamController SteamController
	{
		get
		{
			return global::SteamController.Instance;
		}
	}

	public MySteamUGC SteamUGC
	{
		get
		{
			return this.SteamController.SteamUGC;
		}
	}

	public SteamEvent SteamEvent
	{
		get
		{
			return this.SteamController.SteamEvent;
		}
	}

	private void Start()
	{
		this.CellHeigth = this.ScrollContent.GetComponent<GridLayoutGroup>().cellSize.y;
		SteamEvent steamEvent = this.SteamEvent;
		steamEvent.OnQueryItem = (Action<List<SteamUGCDetails_t>, bool, string>)Delegate.Combine(steamEvent.OnQueryItem, new Action<List<SteamUGCDetails_t>, bool, string>(this.OnQuerySuccess));
		this.SteamUGC.QueryAllUGC(null, 1U);
	}

	private void Update()
	{
	}

	public void QueryAllWorkShop()
	{
	}

	private void OnQuerySuccess(List<SteamUGCDetails_t> list, bool success, string message)
	{
		if (list != null && list.Count > 0)
		{
			if (this.detailList.Count < list.Count)
			{
				for (int i = this.detailList.Count; i < list.Count; i++)
				{
					WorkshopItemDetail workshopItemDetail = UnityEngine.Object.Instantiate<WorkshopItemDetail>(this.detailPrefab);
					this.detailList.Add(workshopItemDetail);
					workshopItemDetail.transform.SetParent(this.ScrollContent);
					workshopItemDetail.transform.localScale = Vector3.one;
				}
				for (int j = 0; j < list.Count; j++)
				{
					this.detailList[j].gameObject.SetActive(true);
					this.detailList[j].SetMessage(list[j]);
				}
				for (int k = list.Count; k < this.detailList.Count; k++)
				{
					this.detailList[k].gameObject.SetActive(false);
				}
				return;
			}
		}
	}

	public List<WorkshopItemDetail> detailList;

	public RectTransform ScrollContent;

	public WorkshopItemDetail detailPrefab;

	private float CellHeigth;
}
