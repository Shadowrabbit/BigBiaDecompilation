using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_11");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_11_1"),
			Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_11_2"),
			(100 + 50 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_11_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_11_1"),
			Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_11_2"),
			(100 + 50 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_11_3")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		this.isUsing = true;
		yield break;
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
		CardData t = base.GetDefaultTarget();
		if (t == null)
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
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, t, Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK), 0.2f, false, 0, "", "Effect/居合");
				t.DizzyLayer += 2;
			}
			else
			{
				base.ShowLogic("喂！让开!");
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, t, Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK), 0.2f, false, 0, "", "Effect/居合");
			}
			if (this.XuliEffect != null)
			{
				ParticlePoolManager.Instance.UnSpawn(this.XuliEffect);
				this.isUsing = false;
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

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "居合释放";
		this.SkillEffectHold = true;
	}

	public bool isUsing;
}
