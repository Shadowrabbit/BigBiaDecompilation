using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoDanPaoXiaoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 2);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_4");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_4"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_4");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_4"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		base.ShowMe();
		ParticlePoolManager.Instance.Spawn("Effect/捶胸大吼", 1f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		yield return new WaitForSeconds(1f);
		int num;
		for (int i = CardSlots.Count - 1; i >= 0; i = num - 1)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				string name = "Effect/捶胸大吼命中";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = CardSlots[i].ChildCardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(CardSlots[i].ChildCardData, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), this.CardData, false, 0, true, false);
				if (!DungeonOperationMgr.Instance.CheckCardDead(CardSlots[i].ChildCardData))
				{
					CardSlots[i].ChildCardData.wATK = Mathf.CeilToInt((float)CardSlots[i].ChildCardData.ATK * this.debuff) - CardSlots[i].ChildCardData.ATK;
				}
			}
			num = i;
		}
		this.CardData.IsAttacked = true;
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "捶胸大吼释放";
	}

	private float baseDmg = 0.5f;

	private float increaseDmg = 0.3f;

	private float debuff = 0.5f;
}
