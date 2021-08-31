using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossTreeSkill4CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树6");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树6");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null)
		{
			if (logic.Layers == 1)
			{
				this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树6");
				this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树6");
				return;
			}
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树7");
			this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树7");
		}
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null && logic.Layers == 1)
		{
			base.ShowMe();
			for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
			{
				foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
				{
					attackMsg.Target.AddAffix(DungeonAffix.frail, 1);
				}
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null && logic.Layers == 2)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			List<CardData> list = new List<CardData>();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMonsters)
			{
				if (!cardData.HasTag(TagMap.BOSS) && cardData.HasTag(TagMap.怪物) && cardData.HasTag(TagMap.衍生物) && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					list.Add(cardData);
				}
			}
			if (list.Count == 0)
			{
				yield break;
			}
			base.ShowMe();
			CardData target = list[SYNCRandom.Range(0, list.Count)];
			Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
			yield return target.CardGameObject.transform.DOJump(this.CardData.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
			yield return this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
			yield return this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
			this.CardData._ATK += target._ATK;
			this.CardData.MaxHP += target.MaxHP;
			this.CardData.HP += target.HP;
			this.CardData.MaxArmor += target.MaxArmor;
			this.CardData.Armor = target.Armor;
			this.CardData._AttackTimes += ((target._AttackTimes > 0) ? (target._AttackTimes - 1) : 0);
			target.DeleteCardData();
			target = null;
			oldScale = default(Vector3);
		}
		yield break;
	}
}
