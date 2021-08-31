using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiaoZhunLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_20");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_20_1"),
			Mathf.CeilToInt((1f + 0.35f * (float)base.Layers) * (float)this.CardData.ATK).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_20_2"),
			(100 + 35 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_20_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_20");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_20_1"),
			Mathf.CeilToInt((1f + 0.35f * (float)base.Layers) * (float)this.CardData.ATK).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_20_2"),
			(100 + 35 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_20_3")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		this.isUsing = true;
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "神引箭释放";
		this.SkillEffectHold = true;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn || !this.isUsing)
		{
			yield break;
		}
		this.isUsing = false;
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null)
		{
			yield break;
		}
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) < myBattleArea.Count / 3 * 2)
		{
			CardSlotData cardSlotData = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + myBattleArea.Count / 3];
			if (cardSlotData.ChildCardData == null || !cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				base.ShowMe();
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, Mathf.CeilToInt((1f + 0.35f * (float)base.Layers) * (float)this.CardData.ATK), 0.2f, true, 0, "Effect/神引箭", "Effect/神引箭命中");
			}
			else
			{
				base.ShowLogic("喂！让开!");
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, Mathf.CeilToInt((1f + 0.35f * (float)base.Layers) * (float)this.CardData.ATK), 0.2f, false, 0, "Effect/神引箭", "Effect/神引箭命中");
			}
			if (this.XuliEffect != null)
			{
				ParticlePoolManager.Instance.UnSpawn(this.XuliEffect);
				this.XuliEffect = null;
			}
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData && this.XuliEffect != null)
		{
			ParticlePoolManager.Instance.UnSpawn(this.XuliEffect);
			this.isUsing = false;
			this.XuliEffect = null;
		}
		yield break;
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		base.OnAfterKill(cardSlot, originCarddata);
		if (base.GetAllCurrentMonsters().Count == 0 && this.XuliEffect != null)
		{
			ParticlePoolManager.Instance.UnSpawn(this.XuliEffect);
			this.isUsing = false;
			this.XuliEffect = null;
		}
		yield break;
	}

	public bool isUsing;
}
