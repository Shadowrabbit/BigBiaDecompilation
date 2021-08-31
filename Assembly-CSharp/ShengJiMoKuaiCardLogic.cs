using System;
using System.Collections.Generic;

public class ShengJiMoKuaiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_升级模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_升级模块");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_升级模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_升级模块");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData.CardLogics.Count == 0)
		{
			this.canUse = false;
		}
		using (List<CardLogic>.Enumerator enumerator = this.CardData.CardLogics.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Layers > 0)
				{
					this.canUse = true;
				}
			}
		}
		if (this.canUse)
		{
			GameController.ins.UIController.ShowUpdateCardLogicPanel(this.CardData, 1, 1);
		}
		else
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_使用无效"));
			CardSlotData emptySlotDataByCardTag = GameController.ins.GetEmptySlotDataByCardTag(TagMap.工具);
			if (emptySlotDataByCardTag == null)
			{
				return;
			}
			Card.InitCardDataByID("升级模块").PutInSlotData(emptySlotDataByCardTag, true);
		}
		this.CardData.RemoveLogic(this);
		if (this.CardData.HasTag(TagMap.模块))
		{
			this.CardData.RemoveTag(TagMap.模块);
		}
		if (this.CardData.HasTag(TagMap.工具))
		{
			this.CardData.RemoveTag(TagMap.工具);
		}
	}

	private bool canUse;
}
