using System;
using System.Collections;

public class YaQianCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_牙签");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_牙签"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_牙签");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_牙签"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
		}
		yield break;
	}
}
