using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHospitalAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
		foreach (KeyValuePair<CardSlotData, ParticleObject> keyValuePair in this.m_Particles)
		{
			ParticlePoolManager.Instance.UnSpawn(keyValuePair.Value);
		}
		UIController.LockLevel = this.m_Lock;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		List<CardSlotData> cardSlotDatas = base.Data.CardSlotDatas;
		this.m_SlotData = cardSlotDatas[0];
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			cardSlotData.CardSlotGameObject.SetIcon(1);
			cardSlotData.CardSlotGameObject.SetBorder(1);
			cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
			cardSlotData.TagWhiteList = 128UL;
			if (cardSlotData == this.m_SlotData)
			{
				cardSlotData.CardSlotGameObject.SetIcon(0);
				cardSlotData.CardSlotGameObject.Border.enabled = false;
				cardSlotData.SlotType = CardSlotData.Type.Freeze;
			}
			else
			{
				cardSlotData.CardSlotGameObject.transform.localPosition = new Vector3(cardSlotData.CardSlotGameObject.transform.localPosition.x, 1.212f, cardSlotData.CardSlotGameObject.transform.localPosition.z);
			}
		}
		this.m_Particles = new Dictionary<CardSlotData, ParticleObject>();
		foreach (CardSlotData cardSlotData2 in base.Data.CardSlotDatas)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.ModID != null)
			{
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HealHpLoop", 2.1474836E+09f);
				particleObject.transform.position = cardSlotData2.CardSlotGameObject.transform.position;
				this.m_Particles.Add(cardSlotData2, particleObject);
			}
		}
		GameController.ins.UIController.HideBlackMask(delegate
		{
			GameController.getInstance().UIController.ShowBackToHomeButton();
		}, 0.5f);
		yield break;
	}

	public override void OnDayPass()
	{
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HP < cardSlotData.ChildCardData.MaxHP)
			{
				cardSlotData.ChildCardData.HP = cardSlotData.ChildCardData.MaxHP;
			}
		}
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			if (card.HasTag(TagMap.英雄) || card.HasTag(TagMap.特殊))
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_49"), 1f, 2f, 1f, 1f);
				card.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(card), true);
				return;
			}
			card.CardGameObject.DMGPanel.SetActive(false);
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HealHpLoop", 2.1474836E+09f);
			particleObject.transform.position = newCardSlot.CardSlotGameObject.transform.position;
			this.m_Particles.Add(newCardSlot, particleObject);
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_住院"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(card.Name) + "·" + card.PersonName
			});
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			CardSlotData cardSlotData = null;
			ParticleObject particleObject2 = null;
			foreach (KeyValuePair<CardSlotData, ParticleObject> keyValuePair in this.m_Particles)
			{
				if (keyValuePair.Key == oldCardSlot)
				{
					cardSlotData = keyValuePair.Key;
					particleObject2 = keyValuePair.Value;
					break;
				}
			}
			if (particleObject2 != null)
			{
				ParticlePoolManager.Instance.UnSpawn(particleObject2);
			}
			if (cardSlotData != null)
			{
				this.m_Particles.Remove(cardSlotData);
			}
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_出院"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(card.Name) + "·" + card.PersonName
			});
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && (card.HasTag(TagMap.英雄) || card.HasTag(TagMap.特殊)))
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_49"), 1f, 2f, 1f, 1f);
			card.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(card), true);
			return;
		}
	}

	private CardSlotData m_SlotData;

	private Dictionary<CardSlotData, ParticleObject> m_Particles;

	private UIController.UILevel m_Lock = UIController.UILevel.All;
}
