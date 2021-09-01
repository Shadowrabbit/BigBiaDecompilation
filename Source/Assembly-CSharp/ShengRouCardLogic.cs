using System;
using System.Collections;

public class ShengRouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_生肉");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_生肉"), this.baseDmg * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_生肉");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_生肉"), this.baseDmg * base.Layers);
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (from != null && from == this.CardData && target.HasTag(TagMap.怪物))
		{
			yield return base.Cure(this.CardData, this.baseDmg * base.Layers, this.CardData);
		}
		yield break;
	}

	private int baseDmg = 2;
}
