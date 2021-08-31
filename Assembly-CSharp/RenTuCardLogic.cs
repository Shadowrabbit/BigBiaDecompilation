using System;
using System.Collections;

public class RenTuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_忍兔");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_忍兔");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData)
		{
			CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
			CardData cardData = (CardData)this.CardData.Attrs["Source"];
			this.CardData.DeleteCardData();
			cardData.PutInSlotData(currentCardSlotData, true);
			cardData.IsAttacked = false;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
		CardData cardData = (CardData)this.CardData.Attrs["Source"];
		this.CardData.DeleteCardData();
		cardData.PutInSlotData(currentCardSlotData, true);
		cardData.IsAttacked = false;
		yield break;
	}
}
