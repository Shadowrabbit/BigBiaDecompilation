using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.InputSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		cardSlotData.TagWhiteList = 8UL;
		base.InitCardSlotOnActTable(this.InputTrans, new Vector3(1.3f, 0f, 0f), 2, false, null, this.InputSlots, cardSlotData);
		this.m_WeaponName = this.Source.CardData.GetAttr("Weapon");
		string.IsNullOrEmpty(this.m_WeaponName);
		this.m_ArmorName = this.Source.CardData.GetAttr("Armor");
		string.IsNullOrEmpty(this.m_ArmorName);
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		if (!string.IsNullOrEmpty(this.m_WeaponName))
		{
			CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_WeaponName);
			this.Source.CardData.MaxHP -= cardDataByModID.MaxHP;
			this.Source.CardData._ATK -= cardDataByModID.ATK;
			this.Source.CardData.MoveRange -= cardDataByModID.MoveRange;
			this.Source.CardData.ATKRange = 1;
			this.Source.CardData._CRIT -= cardDataByModID.CRIT;
			this.Source.CardData.SPD -= cardDataByModID.SPD;
			foreach (string item in cardDataByModID.CardLogicClassNames)
			{
				if (this.Source.CardData.CardLogicClassNames.Contains(item))
				{
					this.Source.CardData.CardLogicClassNames.Remove(item);
				}
			}
		}
		if (!string.IsNullOrEmpty(this.m_ArmorName))
		{
			CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_ArmorName);
			this.Source.CardData.MaxHP -= cardDataByModID2.MaxHP;
			this.Source.CardData._ATK -= cardDataByModID2.ATK;
			this.Source.CardData.MoveRange -= cardDataByModID2.MoveRange;
			this.Source.CardData._CRIT -= cardDataByModID2.CRIT;
			this.Source.CardData.SPD -= cardDataByModID2.SPD;
			foreach (string item2 in cardDataByModID2.CardLogicClassNames)
			{
				if (this.Source.CardData.CardLogicClassNames.Contains(item2))
				{
					this.Source.CardData.CardLogicClassNames.Remove(item2);
				}
			}
		}
		if (this.InputSlots[0].ChildCard != null)
		{
			this.Source.CardData.SetAttr("Weapon", this.InputSlots[0].ChildCard.CardData.Name);
			CardData cardData = this.InputSlots[0].ChildCard.CardData;
			this.Source.CardData.MaxHP += cardData.MaxHP;
			this.Source.CardData._ATK += cardData.ATK;
			this.Source.CardData.MoveRange += cardData.MoveRange;
			this.Source.CardData.ATKRange = cardData.ATKRange;
			this.Source.CardData._CRIT += cardData.CRIT;
			this.Source.CardData.SPD += cardData.SPD;
			using (List<string>.Enumerator enumerator = cardData.CardLogicClassNames.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string item3 = enumerator.Current;
					if (!this.Source.CardData.CardLogicClassNames.Contains(item3))
					{
						this.Source.CardData.CardLogicClassNames.Add(item3);
					}
				}
				goto IL_3D0;
			}
		}
		this.Source.CardData.SetAttr("Weapon", "");
		IL_3D0:
		if (this.InputSlots[1].ChildCard != null)
		{
			this.Source.CardData.SetAttr("Armor", this.InputSlots[1].ChildCard.CardData.Name);
			CardData cardData2 = this.InputSlots[1].ChildCard.CardData;
			this.Source.CardData.MaxHP += cardData2.MaxHP;
			this.Source.CardData._ATK += cardData2.ATK;
			this.Source.CardData.MoveRange += cardData2.MoveRange;
			this.Source.CardData._CRIT += cardData2.CRIT;
			this.Source.CardData.SPD += cardData2.SPD;
			using (List<string>.Enumerator enumerator = cardData2.CardLogicClassNames.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string item4 = enumerator.Current;
					if (!this.Source.CardData.CardLogicClassNames.Contains(item4))
					{
						this.Source.CardData.CardLogicClassNames.Add(item4);
					}
				}
				goto IL_545;
			}
		}
		this.Source.CardData.SetAttr("Armor", "");
		IL_545:
		this.Source.CardData.HP = this.Source.CardData.MaxHP;
		this.Source.HPText.text = this.Source.CardData.HP.ToString();
		this.Source.ATKText.text = this.Source.CardData.ATK.ToString();
		this.Source.CardData.ReloadLogics();
	}

	public List<CardSlot> InputSlots;

	public Transform InputTrans;

	public List<CardData> Reward;

	public Transform ResultTrans;

	public CardSlot[] RewardSlot;

	public List<bool> Result;

	private string m_WeaponName = "";

	private string m_ArmorName = "";
}
