using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeroHome1AreaLogic : AreaLogic
{
	public override void OnGameLoaded()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		base.Data.CardSlotDatas = new List<CardSlotData>();
		this.MinionSelectArea = UnityEngine.Object.FindObjectOfType<MinionSelectArea>();
		this.MinionSelectArea.logic = this;
		for (int i = 0; i < 1; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				CardSlotData cardSlotData = new CardSlotData();
				cardSlotData.SlotType = CardSlotData.Type.Freeze;
				cardSlotData.GridPositionX = j;
				cardSlotData.GridPositionY = i;
				cardSlotData.TagWhiteList = 0UL;
				cardSlotData.OnlyAcceptOneCard = true;
				cardSlotData.DisplayPositionX = (float)(j * 2) - 8.1f;
				cardSlotData.DisplayPositionZ = -5.1f;
				cardSlotData.SlotScale = 1.8f;
				cardSlotData.CurrentAreaData = base.Data;
				cardSlotData.IconIndex = 1;
				cardSlotData.ChildCardData = null;
				base.Data.CardSlotDatas.Add(cardSlotData);
				this.UnselectMinionSlotData.Add(cardSlotData);
			}
		}
		this.MinionSelectArea.FocusSprite.localPosition = new Vector3(8.1f, 0.1f, 3.7f);
		for (int k = 0; k < 0; k++)
		{
			int num = -2;
			CardSlotData cardSlotData2 = new CardSlotData();
			cardSlotData2.SlotType = CardSlotData.Type.Normal;
			cardSlotData2.GridPositionX = k;
			cardSlotData2.GridPositionY = num;
			cardSlotData2.TagWhiteList = 0UL;
			cardSlotData2.OnlyAcceptOneCard = true;
			cardSlotData2.DisplayPositionX = (float)(k + 2) - 10.5f + 7f;
			cardSlotData2.DisplayPositionZ = (float)(-(float)num) * 1f - 3.2f;
			cardSlotData2.CurrentAreaData = base.Data;
			cardSlotData2.IconIndex = 1;
			cardSlotData2.ChildCardData = null;
			base.Data.CardSlotDatas.Add(cardSlotData2);
			this.SelectedMinionSlotData.Add(cardSlotData2);
		}
	}

	public IEnumerator ShowCards()
	{
		if (GlobalController.Instance.GlobalData.SelectedMinions.Count > 1)
		{
			GlobalController.Instance.GlobalData.SelectedMinions.Clear();
		}
		List<CardData> cards = new List<CardData>();
		List<string> list = new List<string>();
		cards.Add(GameController.ins.CardDataModMap.getCardDataByModID("金箍王子"));
		list.Add("金箍王子");
		cards.Add(GameController.ins.CardDataModMap.getCardDataByModID("霸道总裁"));
		list.Add("霸道总裁");
		cards.Add(GameController.ins.CardDataModMap.getCardDataByModID("挨打王"));
		list.Add("挨打王");
		if (GameController.ins.CardDataModMap.getCardDataByModID("偶像歌手") != null)
		{
			cards.Add(GameController.ins.CardDataModMap.getCardDataByModID("偶像歌手"));
			list.Add("偶像歌手");
		}
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.英雄) && !list.Contains(cardData.ModID))
			{
				cards.Add(GameController.ins.CardDataModMap.getCardDataByModID(cardData.ModID));
				list.Add(cardData.ModID);
			}
		}
		foreach (CardData cardData2 in cards)
		{
			if (GlobalController.Instance.GetContractLevelByHeroModID(cardData2.ModID) > 10)
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_dashi);
				break;
			}
		}
		int i = 0;
		int q = 0;
		while (i < cards.Count && q < this.UnselectMinionSlotData.Count)
		{
			int num;
			if (cards[i].HasTag(TagMap.英雄) && cards[i].HasTag(TagMap.随从))
			{
				CardData cardData3 = Card.InitCardDataByID(cards[i].ModID);
				if (GameData.CurrentGameType != GameData.GameType.Endless)
				{
					cardData3 = GameController.ins.GetHeroDataByLevel(cardData3);
				}
				if (q == 0)
				{
					this.MinionSelectArea.SelectedHero = cardData3;
					this.MinionSelectArea.maxLevel = GlobalController.Instance.GetContractLevelByHeroModID(this.MinionSelectArea.SelectedHero.ModID);
					if (this.MinionSelectArea.maxLevel > 10)
					{
						this.MinionSelectArea.maxLevel = 10;
					}
					this.MinionSelectArea.currentLevel = this.MinionSelectArea.maxLevel;
					this.MinionSelectArea.HeroLevelText.text = this.MinionSelectArea.currentLevel.ToString() + "/" + this.MinionSelectArea.maxLevel.ToString();
					this.MinionSelectArea.showAgreementDESC(this.MinionSelectArea.currentLevel);
				}
				CardData cardData4 = cardData3;
				List<CardSlotData> unselectMinionSlotData = this.UnselectMinionSlotData;
				num = q;
				q = num + 1;
				cardData4.PutInSlotData(unselectMinionSlotData[num], true);
				yield return null;
			}
			else
			{
				CardData cardData5 = Card.InitCardDataByID("尚未推出");
				List<CardSlotData> unselectMinionSlotData2 = this.UnselectMinionSlotData;
				num = q;
				q = num + 1;
				cardData5.PutInSlotData(unselectMinionSlotData2[num], true);
			}
			num = i;
			i = num + 1;
		}
		for (int j = cards.Count; j < this.UnselectMinionSlotData.Count; j++)
		{
			Card.InitCardDataByID("尚未推出").PutInSlotData(this.UnselectMinionSlotData[j], true);
		}
		this.UpdateSelectedMinions();
		this.MinionSelectArea.VoxelNumText.text = "0";
		yield break;
	}

	public void UpdateSelectedMinions()
	{
		this.MinionNum = 0;
		if (GlobalController.Instance.GlobalData.SelectedMinions == null)
		{
			GlobalController.Instance.GlobalData.SelectedMinions = new List<string>();
		}
		GlobalController.Instance.GlobalData.SelectedMinions.Clear();
		foreach (CardSlotData cardSlotData in this.SelectedMinionSlotData)
		{
			if (cardSlotData.ChildCardData != null)
			{
				this.MinionNum++;
				GlobalController.Instance.GlobalData.SelectedMinions.Add(cardSlotData.ChildCardData.ModID);
			}
		}
		int minionNum = this.MinionNum;
		int requestMinionNum = this.RequestMinionNum;
	}

	public void UpdateMinionTotalValue()
	{
		this.MinionTotalValue = 0;
		foreach (CardSlotData cardSlotData in this.SelectedMinionSlotData)
		{
			if (cardSlotData.ChildCardData != null)
			{
				this.MinionTotalValue += cardSlotData.ChildCardData.Value;
			}
		}
		this.MinionSelectArea.VoxelNumText.text = this.MinionTotalValue.ToString();
	}

	public bool CheckMinionNum()
	{
		return this.MinionNum >= this.RequestMinionNum;
	}

	public override IEnumerator OnAlreadEnter()
	{
		BGMusicManager.Instance.PlayBGMusic(10, 0, null);
		this.oriCamPos = Camera.main.transform.localPosition;
		this.oriCamRot = Camera.main.transform.localEulerAngles;
		Camera.main.transform.DOLocalMove(new Vector3(0f, 11.3f, 3.4f), 0.3f, false);
		Camera.main.transform.DOLocalRotate(new Vector3(20.866f, 0f, 0f), 0.3f, RotateMode.Fast);
		GameController.ins.UIController.HideBlackMask(null, 0.5f);
		yield return this.ShowCards();
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		this.MinionSelectArea.FocusSprite.position = this.UnselectMinionSlotData[0].CardSlotGameObject.transform.position + Vector3.up * 0.1f;
		yield break;
	}

	private void OnCardPutInSlot(CardSlotData source, CardData cardData)
	{
		this.UpdateSelectedMinions();
		this.UpdateMinionTotalValue();
	}

	public override void OnExit()
	{
		Camera.main.transform.DOLocalMove(this.oriCamPos, 0.3f, false);
		Camera.main.transform.DOLocalRotate(this.oriCamRot, 0.3f, RotateMode.Fast);
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
	}

	private MinionSelectArea MinionSelectArea;

	public int RequestMinionNum = 1;

	public List<CardSlotData> SelectedMinionSlotData = new List<CardSlotData>();

	public List<CardSlotData> UnselectMinionSlotData = new List<CardSlotData>();

	public List<CardSlotData> MagicMinionSlotData = new List<CardSlotData>();

	public CardSlotData HeroSlotData;

	public string HeroModID = "隐";

	private int MinionNum;

	private int MinionTotalValue;

	public Vector3 oriCamPos;

	public Vector3 oriCamRot;
}
