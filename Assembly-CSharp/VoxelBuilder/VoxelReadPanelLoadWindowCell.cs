using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxelReadPanelLoadWindowCell : MonoBehaviour
	{
		private void Start()
		{
			UIPanelHelper.AddTriggerListener(this.screenShotImg.gameObject, EventTriggerType.PointerClick, new CustomEventTrriger.TriggerAction(this.OnScreenShotImgClicked));
			this.likeButton.onClick.AddListener(delegate()
			{
				VoxelReadPanel.Instance.oaccController.status = !VoxelBuilderMgr.Instance.IsCardMatch();
				VoxelReadPanel.Instance.oaccController.Vote(this.md5Str, this.id, 1);
				TMP_Text tmp_Text = this.likeCountTxt;
				int num = this.likeCount + 1;
				this.likeCount = num;
				tmp_Text.text = num.ToString() + ":" + this.disLikeCount.ToString();
				this.LockButtons();
			});
			this.disLikeButton.onClick.AddListener(delegate()
			{
				VoxelReadPanel.Instance.oaccController.status = !VoxelBuilderMgr.Instance.IsCardMatch();
				VoxelReadPanel.Instance.oaccController.Vote(this.md5Str, this.id, 0);
				TMP_Text tmp_Text = this.likeCountTxt;
				string str = this.likeCount.ToString();
				string str2 = ":";
				int num = this.disLikeCount + 1;
				this.disLikeCount = num;
				tmp_Text.text = str + str2 + num.ToString();
				this.LockButtons();
			});
			this.PurchasingButton.onClick.AddListener(delegate()
			{
				if (VoxelReadPanel.Instance.oaccController.CheckHasPutableSlot())
				{
					VoxelReadPanel.Instance.itemPurchasingPriceWindow.SetActive(true);
					VoxelReadPanel.Instance.ShowItemCurrentPrice(this.md5Str);
					return;
				}
				VoxelReadPanel.Instance.TextWarningAnim("卡牌格子已满！");
			});
		}

		private void LockButtons()
		{
			this.likeButton.interactable = false;
			this.disLikeButton.interactable = false;
		}

		private void OnScreenShotImgClicked(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				VoxelBuilderMgr.Instance.Clear();
				VoxelBuilderMgr.Instance.LoadModel(BuilderHelper.StringToMeshData(this.modelStr));
				VoxelReadPanel.Instance.ShowModel();
			}
		}

		public void UpdateCell(MatchItem item)
		{
			this.md5Str = item.guid;
			this.id = item.id;
			this.modelStr = item.pixelContent;
			this.likeCount = item.voteUp;
			this.disLikeCount = item.voteDown;
			this.nameTxt.text = item.cardMessage.Name;
			this.likeCountTxt.text = item.voteUp.ToString() + ":" + item.voteDown.ToString();
			this.screenShotImg.sprite = this.GetSprite(item.guid, item.snapshot);
			if (item.currentUserVote >= 0)
			{
				this.LockButtons();
			}
		}

		private Sprite GetSprite(string md5Str, string screenShotStr)
		{
			Sprite sprite;
			if (VoxelReadPanelLoadWindowCell.SpritesBuffer.ContainsKey(md5Str))
			{
				sprite = VoxelReadPanelLoadWindowCell.SpritesBuffer[md5Str];
			}
			else
			{
				Texture2D texture2D = BuilderHelper.Base64StringToTexture2D(screenShotStr);
				sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), Vector2.one * 0.5f);
				VoxelReadPanelLoadWindowCell.SpritesBuffer.Add(md5Str, sprite);
			}
			return sprite;
		}

		public static Dictionary<string, Sprite> SpritesBuffer = new Dictionary<string, Sprite>();

		public Image screenShotImg;

		public Button likeButton;

		public Button disLikeButton;

		public Button PurchasingButton;

		public TMP_Text nameTxt;

		public TMP_Text likeCountTxt;

		private string modelStr;

		private string md5Str;

		private int id;

		private int likeCount;

		private int disLikeCount;
	}
}
