using System;

public class FuHeMoKuaiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_复合模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_复合模块");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_复合模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_复合模块");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData._ATK > 0)
		{
			this.CardData._ATK *= 2;
			this.canUse = true;
		}
		if (this.CardData.MaxHP > 0)
		{
			this.CardData.MaxHP *= 2;
			this.canUse = true;
		}
		if (this.CardData.HP > 0)
		{
			this.CardData.HP *= 2;
			this.canUse = true;
		}
		if (this.CardData.MaxArmor > 0)
		{
			this.CardData.MaxArmor *= 2;
			this.canUse = true;
		}
		if (this.CardData.Armor > 0)
		{
			this.CardData.Armor *= 2;
			this.canUse = true;
		}
		if (this.CardData._CRIT > 0)
		{
			this.CardData._CRIT *= 2;
			this.canUse = true;
		}
		if (this.CardData.EXATK > 0)
		{
			this.CardData.EXATK *= 2;
			this.canUse = true;
		}
		if (this.CardData._AttackTimes > 1)
		{
			this.CardData._AttackTimes = this.CardData._AttackTimes * 2 - 1;
			this.canUse = true;
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
		if (!this.canUse)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_使用无效"));
			CardSlotData emptySlotDataByCardTag = GameController.ins.GetEmptySlotDataByCardTag(TagMap.工具);
			if (emptySlotDataByCardTag == null)
			{
				return;
			}
			Card.InitCardDataByID("复合模块").PutInSlotData(emptySlotDataByCardTag, true);
		}
	}

	private bool canUse;
}
