using System;
using System.Collections;
using DG.Tweening;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxelReadPanel : MonoBehaviour
	{
		private void Start()
		{
			VoxelReadPanel.Instance = this;
			this.returnWindowButton.onClick.AddListener(new UnityAction(this.ShowReadWindow));
			this.itemPurchasingCancelButton.onClick.AddListener(delegate()
			{
				this.itemPurchasingPriceWindow.SetActive(false);
			});
			this.itemPurchasingConfirmButton.onClick.AddListener(delegate()
			{
				if (this.oaccController.CheckEnoughMoney(this.curSelectedItem.price))
				{
					this.TextWarningAnim("购买成功！");
					this.oaccController.AddItemToShoppingCart(this.curSelectedItem);
				}
				else
				{
					this.TextWarningAnim("购买失败，金币不够！");
				}
				this.itemPurchasingPriceWindow.SetActive(false);
			});
			UIPanelHelper.AddTriggerListener(this.itemPurchasingPriceWindowBGClose, EventTriggerType.PointerClick, delegate(PointerEventData x)
			{
				this.itemPurchasingPriceWindow.SetActive(false);
			});
			base.StartCoroutine(this.WaitMgrInit());
		}

		private IEnumerator WaitMgrInit()
		{
			while (!VoxelBuilderMgr.OnSceneEnterDone)
			{
				yield return null;
			}
			if (!VoxelBuilderMgr.IsReadMode)
			{
				base.gameObject.SetActive(false);
				yield break;
			}
			VoxelReadPanelLoadWindowCell.SpritesBuffer.Clear();
			GameObject gameObject = new GameObject("OACCController");
			this.oaccController = gameObject.AddComponent<OACCController>();
			this.readWindow.UpdateWorksInfo();
			yield break;
		}

		public void ShowModel()
		{
			this.readWindow.gameObject.SetActive(false);
			this.returnWindowButton.gameObject.SetActive(true);
		}

		public void ShowReadWindow()
		{
			this.readWindow.gameObject.SetActive(true);
			this.returnWindowButton.gameObject.SetActive(false);
		}

		public void ShowItemCurrentPrice(string guid)
		{
			this.itemPurchasingConfirmButton.interactable = false;
			this.itemPurchasingCancelButton.interactable = false;
			base.StartCoroutine(this.query(guid, new Action<int>(this.SetPrice)));
		}

		private void SetPrice(int price)
		{
			this.itemPrice.text = price.ToString();
			this.itemPurchasingConfirmButton.interactable = true;
			this.itemPurchasingCancelButton.interactable = true;
		}

		public bool HasSameModel(string md5Str)
		{
			return this.readWindow.HasSameModel(md5Str);
		}

		public void OnSelfWorkUploaded()
		{
			this.selfWorksWindow.gameObject.SetActive(false);
			this.readWindow.joinButton.interactable = false;
		}

		public void TextWarningAnim(string content)
		{
			if (this.textWarningAnimSequence != null)
			{
				this.textWarningAnimSequence.Kill(true);
			}
			this.warningText.color = Color.white;
			this.warningText.text = content;
			this.textWarningAnimSequence = DOTween.Sequence().Append(this.warningText.DOFade(1f, 0.5f)).Append(this.warningText.DOFade(0f, 1.5f));
		}

		private IEnumerator query(string guid, Action<int> callback)
		{
			WWWForm wwwform = new WWWForm();
			wwwform.AddField("status", (!VoxelBuilderMgr.Instance.IsCardMatch()).ToString());
			wwwform.AddField("guid", guid);
			string uri = "http://59.110.49.146/PixelMatch/pixelAction_queryItem";
			using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
			{
				yield return request.SendWebRequest();
				if (request.isNetworkError || request.isHttpError)
				{
					Debug.Log(request.error);
				}
				else
				{
					this.curSelectedItem = JsonConvert.DeserializeObject<MatchItem>(request.downloadHandler.text);
					callback(this.curSelectedItem.price);
				}
			}
			UnityWebRequest request = null;
			yield break;
			yield break;
		}

		public static VoxelReadPanel Instance;

		public OACCController oaccController;

		public VoxelReadPanelLoadWindow readWindow;

		public VoxelReadPanelSelfWorksWindow selfWorksWindow;

		public GameObject itemPurchasingPriceWindow;

		public GameObject itemPurchasingPriceWindowBGClose;

		public Button returnWindowButton;

		public Button itemPurchasingConfirmButton;

		public Button itemPurchasingCancelButton;

		public TMP_Text warningText;

		public TMP_Text itemPrice;

		private Sequence textWarningAnimSequence;

		private MatchItem curSelectedItem;
	}
}
