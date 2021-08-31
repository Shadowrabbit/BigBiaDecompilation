using System;
using System.Collections;

public class MoneyPlusLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_48");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_48"), base.Layers * 100);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_48");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_48"), base.Layers * 100);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player != this.CardData)
		{
			yield break;
		}
		if (changedValue < 0 && SYNCRandom.Range(0, 100) < 5)
		{
			base.ShowMe();
			DungeonOperationMgr.Instance.ChangeMoney(base.Layers * 100);
		}
		yield break;
	}

	private int type;
}
