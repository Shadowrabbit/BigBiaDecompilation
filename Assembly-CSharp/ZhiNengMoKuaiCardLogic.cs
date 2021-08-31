using System;

public class ZhiNengMoKuaiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_智能模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_智能模块");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_智能模块");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_智能模块");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		CardSlotData emptySlotDataByCardTag = GameController.ins.GetEmptySlotDataByCardTag(TagMap.随从);
		if (emptySlotDataByCardTag == null)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"));
			return;
		}
		this.CardData.CardTags = 134217856UL;
		this.CardData.AddLogic("MinionLogic", 0);
		this.CardData._ATK++;
		if (this.CardData._ATK <= 0)
		{
			this.CardData._ATK = 1;
		}
		this.CardData.MaxHP += 10;
		if (this.CardData.MaxHP <= 0)
		{
			this.CardData.MaxHP = 1;
		}
		this.CardData.HP += 10;
		if (this.CardData.HP <= 0)
		{
			this.CardData.HP = 1;
		}
		this.CardData.RemoveLogic(this);
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_你好世界"));
		this.CardData.CardGameObject.IsHideUI = false;
		this.CardData.CardGameObject.ShowUI();
		ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = emptySlotDataByCardTag.CardSlotGameObject.transform.position;
		this.CardData.PutInSlotData(emptySlotDataByCardTag, true);
		if (this.CardData.HasTag(TagMap.模块))
		{
			this.CardData.RemoveTag(TagMap.模块);
		}
		if (this.CardData.HasTag(TagMap.工具))
		{
			this.CardData.RemoveTag(TagMap.工具);
		}
	}
}
