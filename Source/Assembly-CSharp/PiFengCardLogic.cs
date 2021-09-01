using System;
using System.Collections;

public class PiFengCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_披风");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_披风"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_披风");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_披风"), base.Layers * this.weight);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (!this.CardData.HasTag(TagMap.随从))
		{
			yield break;
		}
		base.ShowMe();
		this.CardData.AddAffix(DungeonAffix.def, base.Layers * this.weight);
		yield break;
	}

	private int weight = 1;
}
