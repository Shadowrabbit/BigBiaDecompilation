using System;
using System.Collections;

public class TanHuangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_弹簧");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_弹簧"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_弹簧");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_弹簧"), base.Layers * this.weight);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.strength, base.Layers * this.weight);
		}
		yield break;
	}

	private int weight = 1;
}
