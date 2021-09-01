using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleTavernAct : GameAct
{
	private void Start()
	{
		this.OptionNames = new List<string>();
	}

	public void InitBattleAct(string gift = "")
	{
		this.Init();
		this.DungeonLevel = GameController.ins.GameData.level;
		if (!string.IsNullOrEmpty(gift))
		{
			this.GiftName = gift;
		}
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.CardTags == 128UL && !cardData.HasTag(TagMap.特殊))
			{
				CardData cardData2 = CardData.CopyCardData(cardData, true);
				if (cardData2 != null)
				{
					switch (cardData2.Rare)
					{
					case 1:
						this.allRare1CardDatas.Add(cardData2);
						break;
					case 2:
						this.allRare2CardDatas.Add(cardData2);
						break;
					case 3:
						this.allRare3CardDatas.Add(cardData2);
						break;
					}
				}
			}
		}
		int currentBattleDifficult = DungeonOperationMgr.Instance.CurrentBattleDifficult;
		if (GameController.ins.GameData.DungeonTheme != DungeonTheme.Tutorial)
		{
			for (int i = 0; i < 100; i++)
			{
				int num = SYNCRandom.Range(0, 100);
				new Dictionary<string, int>();
				if (num < Mathf.FloorToInt((float)(currentBattleDifficult / 3) * 0.1f))
				{
					string modID = this.allRare3CardDatas[SYNCRandom.Range(0, this.allRare3CardDatas.Count)].ModID;
					if (!this.OptionNames.Contains(modID))
					{
						this.OptionNames.Add(modID);
					}
				}
				else if (num < Mathf.FloorToInt((float)(currentBattleDifficult / 3) * 1f))
				{
					string modID2 = this.allRare2CardDatas[SYNCRandom.Range(0, this.allRare2CardDatas.Count)].ModID;
					if (!this.OptionNames.Contains(modID2))
					{
						this.OptionNames.Add(modID2);
					}
				}
				else
				{
					string modID3 = this.allRare1CardDatas[SYNCRandom.Range(0, this.allRare1CardDatas.Count)].ModID;
					if (!this.OptionNames.Contains(modID3))
					{
						this.OptionNames.Add(modID3);
					}
				}
				if (this.OptionNames.Count >= ((this.DungeonLevel == 1) ? 6 : 3))
				{
					break;
				}
			}
		}
		else if (currentBattleDifficult != 2)
		{
			if (currentBattleDifficult == 3)
			{
				this.OptionNames.Add("乞丐");
			}
		}
		else
		{
			this.OptionNames.Add("流浪狗");
			this.OptionNames.Add("生命药水");
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData);
		GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_17"), 1f, 2f, 1f, 1f);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null && raycastHit.collider.GetComponent<CardSlot>().ChildCard != null)
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					return;
				}
				if (GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>().IsUseDirectionSkill)
				{
					return;
				}
				if (raycastHit.collider.GetComponent<CardSlot>())
				{
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Area)
					{
						foreach (CardLogic cardLogic in raycastHit.collider.GetComponent<CardSlot>().ChildCard.CardData.CardLogics)
						{
							cardLogic.OnLeftClick(null);
						}
						return;
					}
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Act)
					{
						return;
					}
					GameController.getInstance().StartCoroutine(this.onCardClick(raycastHit.collider.GetComponent<CardSlot>().ChildCard));
				}
			}
		}
	}

	public IEnumerator onCardClick(Card card)
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			yield break;
		}
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				this.isClicked = false;
				yield break;
			}
			CardSlotData emptySlotDataByCardTag = GameController.ins.GetEmptySlotDataByCardTag(TagMap.随从);
			if (emptySlotDataByCardTag == null)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				this.isClicked = false;
				yield break;
			}
			DungeonController.Instance.GameSettleData.GetMinionNum++;
			if (GlobalController.Instance.GameSettingController.info.language != LanguageType.ZH_CN)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志2"), ((CharacterTag_EN)card.CardData.CharactorTag).ToString(), "{origin}"), null, LocalizationMgr.Instance.GetLocalizationWord(card.CardData.Name) + card.CardData.PersonName, null, null, null, null));
			}
			else
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志2"), card.CardData.CharactorTag.ToString(), "{origin}"), null, LocalizationMgr.Instance.GetLocalizationWord(card.CardData.Name) + card.CardData.PersonName, null, null, null, null));
			}
			yield return base.StartCoroutine(card.JumpToSlot(emptySlotDataByCardTag.CardSlotGameObject, 0.3f, true));
			UIController.LockLevel = UIController.UILevel.AreaTable;
			this.HasGet++;
			if (this.HasGet > ((this.DungeonLevel == 1) ? 1 : 0))
			{
				this.OnActCancelButton();
			}
		}
		else if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			CardSlotData.Type slotType = cardSlotData.SlotType;
		}
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
	}

	public override void ActEnd()
	{
		base.ActEnd();
		UIController.LockLevel = UIController.UILevel.None;
		if (!string.IsNullOrEmpty(this.GiftName))
		{
			GameController.getInstance().DialogueController.StartGift(this.GiftName);
		}
	}

	public override void OnRefreshButton()
	{
	}

	public override void OnUpgradeButton()
	{
	}

	private void StartGiftAct()
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		(GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct).GiftNames.Add(this.GiftName);
		this.GiftName = "";
	}

	public List<string> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	public Transform SellSlotTrans;

	private List<CardData> allCardDatas = new List<CardData>();

	private List<CardData> allRare1CardDatas = new List<CardData>();

	private List<CardData> allRare2CardDatas = new List<CardData>();

	private List<CardData> allRare3CardDatas = new List<CardData>();

	private int DungeonLevel;

	public string GiftName = "";

	private bool isClicked;

	private int HasGet;
}
