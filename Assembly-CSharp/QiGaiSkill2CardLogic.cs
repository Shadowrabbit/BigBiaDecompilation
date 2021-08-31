using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class QiGaiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_128");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_128");
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_128");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_128");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		List<CardData> targets = base.GetAllCurrentMonsters();
		if (targets.Count == 0)
		{
			yield break;
		}
		if (base.GetLogic(this.CardData, typeof(QiGaiCardLogic)) == null)
		{
			yield break;
		}
		base.ShowMe();
		int dmg = Mathf.CeilToInt((this.baseDmg1 + this.increaseDmg1 * (float)base.GetLogic(this.CardData, typeof(QiGaiCardLogic)).Layers) * (float)this.CardData.ATK);
		foreach (CardData cardData in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, cardData, 1f, null, null, new AttackMsg(cardData, dmg, false, true, 0, 0, null));
			}
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield return new WaitForSeconds(0.3f);
		foreach (CardData target in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(target))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, -dmg, this.CardData, false, 0, true, false);
				yield return base.Shifting(target.CurrentCardSlotData, Vector3Int.down, base.GetEnemiesBattleArea());
			}
			target = null;
		}
		enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}

	private float baseDmg1 = 1f;

	private float increaseDmg1 = 0.5f;
}
