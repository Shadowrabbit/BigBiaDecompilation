using System;
using System.Collections;

public class ChaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_茶");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_茶"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_茶");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_茶"), base.Layers);
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		if (!this.CardData.HasTag(TagMap.随从))
		{
			yield break;
		}
		base.ShowMe();
		this.CardData.MaxHP += base.Layers;
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.1f;
}
