using System;
using System.Collections;

public class XiaoCaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小草");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_小草"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小草");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_小草"), base.Layers);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (this.CardData.HasTag(TagMap.随从))
		{
			this.CardData.AddAffix(DungeonAffix.heal, base.Layers);
		}
		yield break;
	}
}
