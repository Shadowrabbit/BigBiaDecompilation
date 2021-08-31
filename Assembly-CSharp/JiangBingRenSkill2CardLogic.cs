using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class JiangBingRenSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_你不爱曲奇");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_你不爱曲奇");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_你不爱曲奇");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_你不爱曲奇");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.canUse = true;
		yield break;
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (!this.canUse)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_无法再使用了"));
			yield break;
		}
		this.canUse = false;
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null || defaultTarget.HasTag(TagMap.BOSS) || defaultTarget.Level > 1)
		{
			yield break;
		}
		CardSlotData currentCardSlotData = defaultTarget.CurrentCardSlotData;
		base.ShowMe();
		defaultTarget.DeleteCardData();
		ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = currentCardSlotData.CardSlotGameObject.transform.position;
		CardData cardData = Card.InitCardDataByID(this.CardData.ModID);
		cardData.CardTags = 134250496UL;
		cardData._ATK = this.CardData._ATK;
		cardData.MaxArmor = this.CardData.MaxArmor;
		cardData.Armor = this.CardData.Armor;
		cardData.MaxHP = this.CardData.MaxHP;
		cardData.HP = this.CardData.HP;
		cardData._AttackTimes = this.CardData._AttackTimes;
		cardData.Price = 0;
		cardData.CardLogics.Clear();
		cardData.PutInSlotData(currentCardSlotData, true);
		yield break;
	}

	private bool canUse;
}
