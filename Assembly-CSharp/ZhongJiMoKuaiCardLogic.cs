using System;

public class ZhongJiMoKuaiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_终极模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_终极模块");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_终极模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_终极模块");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData.HasTag(TagMap.食物))
		{
			if (this.CardData.HasTag(TagMap.模块))
			{
				this.CardData.RemoveTag(TagMap.模块);
			}
			if (this.CardData.HasTag(TagMap.工具))
			{
				this.CardData.RemoveTag(TagMap.工具);
			}
			this.CardData.RemoveLogic(this);
		}
	}
}
