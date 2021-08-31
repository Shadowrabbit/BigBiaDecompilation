using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class MySteamUGC : MonoBehaviour
{
	public void SetFileId(PublishedFileId_t PublishedFileId)
	{
		this.m_PublishedFileId = PublishedFileId;
	}

	public PublishedFileId_t GetFileId()
	{
		return this.m_PublishedFileId;
	}

	private SteamEvent SteamEvent
	{
		get
		{
			return global::SteamController.Instance.SteamEvent;
		}
	}

	private void OnEnable()
	{
		this.m_ItemInstalled = Callback<ItemInstalled_t>.Create(new Callback<ItemInstalled_t>.DispatchDelegate(this.OnItemInstalled));
		this.m_DownloadItemResult = Callback<DownloadItemResult_t>.Create(new Callback<DownloadItemResult_t>.DispatchDelegate(this.OnDownloadItemResult));
		this.OnSteamUGCQueryCompletedCallResult = CallResult<SteamUGCQueryCompleted_t>.Create(new CallResult<SteamUGCQueryCompleted_t>.APIDispatchDelegate(this.OnSteamUGCQueryCompleted));
		this.OnCreateItemResultCallResult = CallResult<CreateItemResult_t>.Create(new CallResult<CreateItemResult_t>.APIDispatchDelegate(this.OnCreateItemResult));
		this.OnSubmitItemUpdateResultCallResult = CallResult<SubmitItemUpdateResult_t>.Create(new CallResult<SubmitItemUpdateResult_t>.APIDispatchDelegate(this.OnSubmitItemUpdateResult));
		this.OnSetUserItemVoteResultCallResult = CallResult<SetUserItemVoteResult_t>.Create(new CallResult<SetUserItemVoteResult_t>.APIDispatchDelegate(this.OnSetUserItemVoteResult));
		this.OnGetUserItemVoteResultCallResult = CallResult<GetUserItemVoteResult_t>.Create(new CallResult<GetUserItemVoteResult_t>.APIDispatchDelegate(this.OnGetUserItemVoteResult));
		this.OnDeleteItemResultCallResult = CallResult<DeleteItemResult_t>.Create(new CallResult<DeleteItemResult_t>.APIDispatchDelegate(this.OnDeleteItemResult));
		this.OnSubscribePublishedFile = CallResult<RemoteStorageSubscribePublishedFileResult_t>.Create(new CallResult<RemoteStorageSubscribePublishedFileResult_t>.APIDispatchDelegate(this.OnUserSubscribeItem));
	}

	private void Start()
	{
		this.GetSubscribedItems();
	}

	private void Update()
	{
	}

	public void QueryAllUGC(UGCQueryCondition condition = null, uint page = 1U)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (condition == null)
		{
			condition = UGCQueryCondition.DefaultCondition;
		}
		this.m_UGCQueryHandle = SteamUGC.CreateQueryAllUGCRequest(condition.Query, condition.MatchingType, condition.CreatorAppID, condition.ConsumerAppID, page);
		if (!string.IsNullOrEmpty(condition.UgcTag))
		{
			SteamUGC.AddRequiredTag(this.m_UGCQueryHandle, condition.UgcTag);
		}
		SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(this.m_UGCQueryHandle);
		this.OnSteamUGCQueryCompletedCallResult.Set(hAPICall, null);
	}

	public void QueryUserUGC()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		this.m_UGCQueryHandle = SteamUGC.CreateQueryUserUGCRequest(GameServer.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_All, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, SteamUtils.GetAppID(), SteamUtils.GetAppID(), 1U);
		SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(this.m_UGCQueryHandle);
		this.OnSteamUGCQueryCompletedCallResult.Set(hAPICall, null);
	}

	public List<PublishedFileId_t> GetSubscribedItems()
	{
		if (!SteamManager.Initialized)
		{
			return null;
		}
		uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
		PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
		SteamUGC.GetSubscribedItems(array, numSubscribedItems);
		this.m_PlayerSubscribeItemSet.UnionWith(array);
		return new List<PublishedFileId_t>(array);
	}

	public bool IsSubscribeItem(PublishedFileId_t id)
	{
		return this.m_PlayerSubscribeItemSet.Contains(id);
	}

	public bool DownloadItem(PublishedFileId_t publishedFileId)
	{
		return SteamManager.Initialized && SteamUGC.DownloadItem(publishedFileId, true);
	}

	public void CreateItem(EWorkshopFileType type = EWorkshopFileType.k_EWorkshopFileTypeFirst)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamAPICall_t hAPICall = SteamUGC.CreateItem(SteamUtils.GetAppID(), type);
		this.OnCreateItemResultCallResult.Set(hAPICall, null);
	}

	public void UpdateItem(WorkShopItem item)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (!this.IsCreateItem)
		{
			return;
		}
		this.m_UGCUpdateHandle = SteamUGC.StartItemUpdate(SteamUtils.GetAppID(), this.m_PublishedFileId);
		SteamUGC.SetItemTitle(this.m_UGCUpdateHandle, item.Title);
		SteamUGC.SetItemDescription(this.m_UGCUpdateHandle, item.Description);
		SteamUGC.SetItemMetadata(this.m_UGCUpdateHandle, item.MetaData);
		SteamUGC.SetItemVisibility(this.m_UGCUpdateHandle, item.Visibility);
		SteamUGC.SetItemContent(this.m_UGCUpdateHandle, item.Content);
		if (!string.IsNullOrEmpty(item.PreviewFile))
		{
			SteamUGC.SetItemPreview(this.m_UGCUpdateHandle, item.PreviewFile);
		}
		if (item.TagList != null && item.TagList.Count > 0)
		{
			SteamUGC.SetItemTags(this.m_UGCUpdateHandle, item.TagList);
		}
		SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(this.m_UGCUpdateHandle, null);
		this.OnSubmitItemUpdateResultCallResult.Set(hAPICall, null);
	}

	public void SetUserItemVote(PublishedFileId_t publishedFileId, bool voteUp)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamAPICall_t hAPICall = SteamUGC.SetUserItemVote(publishedFileId, voteUp);
		this.OnSetUserItemVoteResultCallResult.Set(hAPICall, null);
	}

	public void GetUserItemVote(PublishedFileId_t publishedFileId)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamAPICall_t userItemVote = SteamUGC.GetUserItemVote(publishedFileId);
		this.OnGetUserItemVoteResultCallResult.Set(userItemVote, null);
	}

	public void CancelUpdate()
	{
		if (!SteamManager.Initialized)
		{
			this.IsCreateItem = false;
			return;
		}
		this.IsCreateItem = false;
		this.DeleteItem(this.m_PublishedFileId);
	}

	public void DeleteItem(PublishedFileId_t id)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamAPICall_t hAPICall = SteamUGC.DeleteItem(id);
		this.OnDeleteItemResultCallResult.Set(hAPICall, null);
	}

	public void Subscribe(PublishedFileId_t id)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamUGC.SubscribeItem(id);
	}

	public void UnSubscribe(PublishedFileId_t id)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamUGC.UnsubscribeItem(id);
	}

	private void OnItemInstalled(ItemInstalled_t pCallback)
	{
		PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
		Debug.Log(nPublishedFileId.ToString() + " 安装成功");
	}

	private void OnCreateItemResult(CreateItemResult_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			this.m_PublishedFileId = pCallback.m_nPublishedFileId;
			this.IsCreateItem = true;
			Action<PublishedFileId_t, bool, string> onCreateItem = this.SteamEvent.OnCreateItem;
			if (onCreateItem == null)
			{
				return;
			}
			onCreateItem(this.m_PublishedFileId, true, null);
			return;
		}
		else
		{
			Action<PublishedFileId_t, bool, string> onCreateItem2 = this.SteamEvent.OnCreateItem;
			if (onCreateItem2 == null)
			{
				return;
			}
			onCreateItem2(default(PublishedFileId_t), false, SteamEResultUtil.ResultMessage.ToString());
			return;
		}
	}

	private void OnSubmitItemUpdateResult(SubmitItemUpdateResult_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			this.IsCreateItem = false;
			Action<bool, string> onSubmitItem = this.SteamEvent.OnSubmitItem;
			if (onSubmitItem == null)
			{
				return;
			}
			onSubmitItem(true, null);
			return;
		}
		else
		{
			Action<bool, string> onSubmitItem2 = this.SteamEvent.OnSubmitItem;
			if (onSubmitItem2 == null)
			{
				return;
			}
			onSubmitItem2(false, SteamEResultUtil.ResultMessage.ToString());
			return;
		}
	}

	private void OnSteamUGCQueryCompleted(SteamUGCQueryCompleted_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			this.m_DetailList.Clear();
			int num = 0;
			while ((long)num < (long)((ulong)pCallback.m_unNumResultsReturned))
			{
				SteamUGCDetails_t item = default(SteamUGCDetails_t);
				if (SteamUGC.GetQueryUGCResult(this.m_UGCQueryHandle, (uint)num, out item))
				{
					this.m_DetailList.Add(item);
				}
				num++;
			}
			Action<List<SteamUGCDetails_t>, bool, string> onQueryItem = this.SteamEvent.OnQueryItem;
			if (onQueryItem != null)
			{
				onQueryItem(this.m_DetailList, true, null);
			}
			SteamUGC.ReleaseQueryUGCRequest(this.m_UGCQueryHandle);
			return;
		}
		Action<List<SteamUGCDetails_t>, bool, string> onQueryItem2 = this.SteamEvent.OnQueryItem;
		if (onQueryItem2 == null)
		{
			return;
		}
		onQueryItem2(this.m_DetailList, false, SteamEResultUtil.ResultMessage.ToString());
	}

	private void OnDownloadItemResult(DownloadItemResult_t pCallback)
	{
		if (pCallback.m_unAppID != SteamConstant.GameID.AppID())
		{
			return;
		}
		SteamEResultUtil.CheckEResult(pCallback.m_eResult);
	}

	private void OnUserSubscribeItem(RemoteStorageSubscribePublishedFileResult_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			this.m_PlayerSubscribeItemSet.Add(pCallback.m_nPublishedFileId);
		}
	}

	private void OnSetUserItemVoteResult(SetUserItemVoteResult_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			Action<SetUserItemVoteResult_t, bool, string> onUserItemVote = this.SteamEvent.OnUserItemVote;
			if (onUserItemVote == null)
			{
				return;
			}
			onUserItemVote(pCallback, true, null);
			return;
		}
		else
		{
			Action<SetUserItemVoteResult_t, bool, string> onUserItemVote2 = this.SteamEvent.OnUserItemVote;
			if (onUserItemVote2 == null)
			{
				return;
			}
			onUserItemVote2(pCallback, false, SteamEResultUtil.ResultMessage.ToString());
			return;
		}
	}

	private void OnGetUserItemVoteResult(GetUserItemVoteResult_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			Action<GetUserItemVoteResult_t, bool, string> onGetUserItemVote = this.SteamEvent.OnGetUserItemVote;
			if (onGetUserItemVote == null)
			{
				return;
			}
			onGetUserItemVote(pCallback, true, null);
			return;
		}
		else
		{
			Action<GetUserItemVoteResult_t, bool, string> onGetUserItemVote2 = this.SteamEvent.OnGetUserItemVote;
			if (onGetUserItemVote2 == null)
			{
				return;
			}
			onGetUserItemVote2(pCallback, false, SteamEResultUtil.ResultMessage.ToString());
			return;
		}
	}

	private void OnDeleteItemResult(DeleteItemResult_t pCallback, bool bIDFailure)
	{
		if (SteamEResultUtil.CheckEResult(pCallback.m_eResult))
		{
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			Debug.Log(nPublishedFileId.ToString() + " 删除成功");
		}
	}

	private UGCQueryHandle_t m_UGCQueryHandle;

	private PublishedFileId_t m_PublishedFileId;

	public bool IsCreateItem;

	private UGCUpdateHandle_t m_UGCUpdateHandle;

	private Callback<ItemInstalled_t> m_ItemInstalled;

	private Callback<DownloadItemResult_t> m_DownloadItemResult;

	private CallResult<SteamUGCQueryCompleted_t> OnSteamUGCQueryCompletedCallResult;

	private CallResult<SteamUGCRequestUGCDetailsResult_t> OnSteamUGCRequestUGCDetailsResultCallResult;

	private CallResult<CreateItemResult_t> OnCreateItemResultCallResult;

	private CallResult<SubmitItemUpdateResult_t> OnSubmitItemUpdateResultCallResult;

	private CallResult<UserFavoriteItemsListChanged_t> OnUserFavoriteItemsListChangedCallResult;

	private CallResult<SetUserItemVoteResult_t> OnSetUserItemVoteResultCallResult;

	private CallResult<GetUserItemVoteResult_t> OnGetUserItemVoteResultCallResult;

	private CallResult<StartPlaytimeTrackingResult_t> OnStartPlaytimeTrackingResultCallResult;

	private CallResult<StopPlaytimeTrackingResult_t> OnStopPlaytimeTrackingResultCallResult;

	private CallResult<AddUGCDependencyResult_t> OnAddUGCDependencyResultCallResult;

	private CallResult<RemoveUGCDependencyResult_t> OnRemoveUGCDependencyResultCallResult;

	private CallResult<AddAppDependencyResult_t> OnAddAppDependencyResultCallResult;

	private CallResult<RemoveAppDependencyResult_t> OnRemoveAppDependencyResultCallResult;

	private CallResult<GetAppDependenciesResult_t> OnGetAppDependenciesResultCallResult;

	private CallResult<DeleteItemResult_t> OnDeleteItemResultCallResult;

	private CallResult<RemoteStorageSubscribePublishedFileResult_t> OnSubscribePublishedFile;

	private List<SteamUGCDetails_t> m_DetailList = new List<SteamUGCDetails_t>();

	private HashSet<PublishedFileId_t> m_PlayerSubscribeItemSet = new HashSet<PublishedFileId_t>();
}
