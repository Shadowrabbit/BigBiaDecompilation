using System;
using System.Collections;
using System.Collections.Generic;

public class PoJianLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		base.Layers = 2;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_86");
		this.Desc = base.Layers.ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_86");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.m_Round++;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		if (this.m_Round > base.Layers)
		{
			this.displayName = "变！变！变！";
			base.ShowMe();
			CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
			CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.targets[SYNCRandom.Range(0, this.targets.Count)]), true);
			cardData.Armor = 0;
			cardData.MaxArmor = 0;
			cardData.HP = this.CardData.HP;
			cardData.MaxHP = this.CardData.MaxHP;
			this.CardData.DeleteCardData();
			cardData.PutInSlotData(currentCardSlotData, true);
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_86");
		this.Desc = (base.Layers - this.m_Round).ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_86");
	}

	private int m_Round = 1;

	private List<string> targets = new List<string>
	{
		"工兵虫",
		"哨兵虫"
	};
}
