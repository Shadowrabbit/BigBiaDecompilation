using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class TiaoJiuShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_秘制鸡尾酒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_秘制鸡尾酒");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_秘制鸡尾酒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_秘制鸡尾酒");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData target = base.GetDefaultTarget();
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		base.ShowMe();
		yield return base.ShowCustomEffect("鸡尾酒释放", this.CardData.CurrentCardSlotData, 0.5f);
		ParticlePoolManager.Instance.Spawn("Effect/鸡尾酒命中", 0.5f).transform.position = target.CurrentCardSlotData.CardSlotGameObject.transform.position;
		target.AddAffix(DungeonAffix.poisoning, base.Layers + 3);
		target.AddAffix(DungeonAffix.weak, base.Layers + 3);
		target.AddAffix(DungeonAffix.bleeding, base.Layers + 3);
		target.AddAffix(DungeonAffix.frozen, base.Layers + 3);
		target.AddAffix(DungeonAffix.frail, base.Layers + 3);
		target.DizzyLayer = 1;
		yield break;
	}

	private float baseDmg = 0.75f;

	private float increaseDmg = 0.25f;

	private float baseChance = 50f;

	private float increaseChance = 10f;
}
