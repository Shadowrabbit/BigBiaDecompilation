using System;
using System.Collections;

public class ShouBiaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_手表");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_手表"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_手表");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_手表"), base.Layers * this.weight);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (!this.CardData.HasTag(TagMap.随从))
		{
			yield break;
		}
		base.ShowMe();
		this.CardData.AddAffix(DungeonAffix.guard, base.Layers * this.weight);
		yield break;
	}

	private int weight = 3;
}
