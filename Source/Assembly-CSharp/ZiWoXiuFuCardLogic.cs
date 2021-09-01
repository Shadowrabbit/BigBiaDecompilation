using System;
using System.Collections;

public class ZiWoXiuFuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_自我修复");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_自我修复"), 4 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_自我修复");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_自我修复"), 4 + base.Layers);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.currentCardSlot = null;
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			if (this.currentCardSlot == null || this.CardData.CurrentCardSlotData != this.currentCardSlot)
			{
				this.currentCardSlot = this.CardData.CurrentCardSlotData;
				yield break;
			}
			if (this.CardData.CurrentCardSlotData == this.currentCardSlot)
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.heal, 4 + base.Layers);
			}
		}
		yield break;
	}

	private CardSlotData currentCardSlot;
}
