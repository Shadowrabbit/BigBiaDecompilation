using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewCampArea : MonoBehaviour
{
	private void Start()
	{
		this.m_ItemRefreshCount = 1;
		this.m_MinionRefreshCount = 1;
		base.GetComponentInChildren<NewCampMinionRefreshBtn>().NewCampArea = this;
		base.GetComponentInChildren<NewCampItemRefreshBtn>().NewCampArea = this;
		base.GetComponentInChildren<NewCampExitBtn>().NewCampArea = this;
		this.ItemPriceText.text = ((20 * this.m_ItemRefreshCount).ToString() ?? "");
		this.MinionPriceText.text = ((20 * this.m_MinionRefreshCount).ToString() ?? "");
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
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
					{
						foreach (CardLogic cardLogic in raycastHit.collider.GetComponent<CardSlot>().ChildCard.CardData.CardLogics)
						{
							cardLogic.OnLeftClick(null);
						}
						return;
					}
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Area)
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
		if (this.m_IsClick)
		{
			yield break;
		}
		this.m_IsClick = true;
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			this.m_IsClick = false;
			yield break;
		}
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			if ((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate > (float)GameController.getInstance().GameData.Money)
			{
				GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_35"), Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate)), 1f, 2f, 1f, 1f);
				this.m_IsClick = false;
				yield break;
			}
			if (card.CardData.ModID.Equals("火把"))
			{
				GameController.getInstance().ShowLogicChanged(card.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_火把") + " +1", CardLogicColor.red);
				DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
				GameController.ins.GameData.TorchNum++;
				Vector3 position = GameController.getInstance().playerTableText.Money.transform.position;
				string name = "Effect/HealMoney";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = position;
				this.m_IsClick = false;
				yield break;
			}
			if (card.CardData.ModID.Equals("钥匙"))
			{
				GameController.getInstance().ShowLogicChanged(card.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_钥匙") + " +1", CardLogicColor.red);
				DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
				GameController.ins.GameData.KeyNum++;
				Vector3 position2 = GameController.getInstance().playerTableText.Money.transform.position + new Vector3(1f, 0f, 0f);
				string name2 = "Effect/HealMoney";
				ParticlePoolManager.Instance.Spawn(name2, 3f).transform.position = position2;
				this.m_IsClick = false;
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				this.m_IsClick = false;
				yield break;
			}
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(card.CardData);
			if (emptySlotDataByCardData == null)
			{
				this.m_IsClick = false;
				yield break;
			}
			DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
			if (card != null)
			{
				card.PriceText.transform.parent.gameObject.SetActive(false);
			}
			yield return base.StartCoroutine(card.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true));
			if (card.CardData.HasTag(TagMap.随从))
			{
				GameController.ins.GameData.GameSettleData.GetMinionNum++;
				this.RefreshMinionPrice();
			}
			this.m_IsClick = false;
		}
		yield break;
	}

	public void RefreshItem()
	{
		if (GameController.getInstance().GameData.Money < this.m_ItemRefreshCount * 20)
		{
			GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_36"), this.m_ItemRefreshCount * 20), 1f, 2f, 1f, 1f);
			return;
		}
		EffectAudioManager.Instance.PlayEffectAudio(16, null);
		DungeonOperationMgr.Instance.ChangeMoney(-this.m_ItemRefreshCount * 20);
		this.m_ItemRefreshCount++;
		this.Refresh(TagMap.食物);
		this.Refresh(TagMap.工具 | TagMap.药水);
		this.ItemPriceText.text = ((20 * this.m_ItemRefreshCount).ToString() ?? "");
	}

	public void RefreshMinion()
	{
		if (GameController.getInstance().GameData.Money < this.m_MinionRefreshCount * 20)
		{
			GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_36"), this.m_MinionRefreshCount * 20), 1f, 2f, 1f, 1f);
			return;
		}
		EffectAudioManager.Instance.PlayEffectAudio(16, null);
		DungeonOperationMgr.Instance.ChangeMoney(-this.m_MinionRefreshCount * 20);
		this.m_MinionRefreshCount++;
		this.Refresh(TagMap.随从);
		this.MinionPriceText.text = ((20 * this.m_MinionRefreshCount).ToString() ?? "");
	}

	private void Refresh(TagMap type)
	{
		if (type == TagMap.食物)
		{
			this.ClearSlotDatas(this.FoodSlotDatas);
			this.CreateCardToSlotDatas(this.FoodSlotDatas, type);
			return;
		}
		if (type == TagMap.随从)
		{
			this.ClearSlotDatas(this.MinionSlotDatas);
			this.CreateCardToSlotDatas(this.MinionSlotDatas, type);
			return;
		}
		if (type != (TagMap.工具 | TagMap.药水))
		{
			return;
		}
		this.ClearSlotDatas(this.MedicineOrToolSlotDatas);
		this.CreateCardToSlotDatas(this.MedicineOrToolSlotDatas, type);
	}

	private void CreateCardToSlotDatas(List<CardSlotData> slotDatas, TagMap type)
	{
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if (type == TagMap.随从)
			{
				if (cardData.HasTag(type) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.英雄))
				{
					CardData cardData2 = CardData.CopyCardData(cardData, true);
					cardData2.Price = 50 * (GameController.ins.GameData.BuyMinionCount + 1);
					list.Add(cardData2);
				}
			}
			else if (cardData.HasTag(type) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && cardData.Rare <= GameController.ins.GameData.level + 1)
			{
				CardData cardData3 = CardData.CopyCardData(cardData, true);
				cardData3.Price = cardData3.Rare * 100 + SYNCRandom.Range(-20, 21);
				if (cardData3.HasTag(TagMap.药水) || cardData3.HasTag(TagMap.工具) || cardData3.HasTag(TagMap.放置物))
				{
					cardData3.Price = Mathf.RoundToInt((float)cardData3.Price * 0.8f + (float)SYNCRandom.Range(-10, 11));
				}
				list.Add(cardData3);
			}
		}
		List<CardData> list2 = new List<CardData>();
		foreach (CardSlotData slotData in slotDatas)
		{
			CardData cardData4 = list[SYNCRandom.Range(0, list.Count)];
			while (list2.Contains(cardData4))
			{
				cardData4 = list[SYNCRandom.Range(0, list.Count)];
			}
			list2.Add(cardData4);
			cardData4.PutInSlotData(slotData, true);
			cardData4.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardData4.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
			cardData4.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
		}
	}

	private void ClearSlotDatas(List<CardSlotData> slotDatas)
	{
		foreach (CardSlotData cardSlotData in slotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				if (cardSlotData.ChildCardData.CardGameObject != null)
				{
					cardSlotData.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(false);
				}
				cardSlotData.ChildCardData.DeleteCardData();
			}
		}
	}

	private void RefreshMinionPrice()
	{
		GameController.ins.GameData.BuyMinionCount++;
		foreach (CardSlotData cardSlotData in this.MinionSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.Price = 50 * (GameController.ins.GameData.BuyMinionCount + 1);
				if (cardSlotData.ChildCardData.CardGameObject != null)
				{
					cardSlotData.ChildCardData.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardSlotData.ChildCardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
				}
			}
		}
	}

	public void ExitCampArea()
	{
		GlobalController.Instance.IsLoadGame = false;
		DungeonController.Instance.GenerateNextArea(true);
	}

	public CardSlotData SellCardSlot;

	public CardSlotData TentCardSlot;

	public CardSlotData TorchCardSlot;

	public CardSlotData KeyCardSlot;

	public List<CardSlotData> FoodSlotDatas;

	public List<CardSlotData> MedicineOrToolSlotDatas;

	public List<CardSlotData> MinionSlotDatas;

	public GameObject ItemRefreshBtn;

	public GameObject MinionRefreshBtn;

	public GameObject ExitBtn;

	public TMP_Text ItemPriceText;

	private int m_ItemRefreshCount = 1;

	public TMP_Text MinionPriceText;

	private int m_MinionRefreshCount = 1;

	private bool m_IsClick;
}
