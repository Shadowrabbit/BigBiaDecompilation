using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_形状爆破");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_形状爆破");
		if (this.CardData != null && GameController.ins != null && GameController.ins.CardDataModMap != null && GameController.ins.CardDataModMap.getCardDataByModID("形状爆破") == null)
		{
			return;
		}
		if (this.CardData != null && !this.CardData.HasAttr("TetrisCardLogic_BlockValue"))
		{
			List<bool> list = new List<bool>();
			for (int i = 0; i < 9; i++)
			{
				if (SYNCRandom.Range(0, 2) > 0)
				{
					list.Add(true);
				}
				else
				{
					list.Add(false);
				}
			}
			this.CardData.Attrs.Add("TetrisCardLogic_BlockValue", list);
		}
		if (this.CardData != null && this.CardData.CardGameObject != null && this.CardData.CardGameObject.GetComponentInChildren<TetrisCard>() != null)
		{
			this.CardData.CardGameObject.GetComponentInChildren<TetrisCard>().SetBlock(this.CardData.Attrs["TetrisCardLogic_BlockValue"] as List<bool>);
		}
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_形状爆破");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_形状爆破");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.RemoveLogic(this);
		foreach (CardLogic cardLogic in mergeBy.CardLogics)
		{
			if (cardLogic.GetType() == base.GetType() && DungeonOperationMgr.Instance.IsInBattle)
			{
				cardLogic.OnLeftClick(null);
			}
		}
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		GameController.ins.StartCoroutine(this.use());
	}

	private IEnumerator use()
	{
		UIController.LockLevel = UIController.UILevel.All;
		List<bool> targets = this.CardData.Attrs["TetrisCardLogic_BlockValue"] as List<bool>;
		if (targets == null)
		{
			yield break;
		}
		for (int j = 0; j < targets.Count; j++)
		{
			if (targets[j])
			{
				ParticlePoolManager.Instance.Spawn("Effect/BeAttack", 0.2f).transform.position = DungeonOperationMgr.Instance.BattleArea[j].CardSlotGameObject.transform.position;
			}
		}
		EffectAudioManager.Instance.PlayEffectAudio(28, null);
		yield return new WaitForSeconds(0.3f);
		int num;
		for (int i = 0; i < targets.Count; i = num + 1)
		{
			if (targets[i] && DungeonOperationMgr.Instance.BattleArea[i].ChildCardData != null && !DungeonOperationMgr.Instance.BattleArea[i].ChildCardData.HasTag(TagMap.BOSS))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(DungeonOperationMgr.Instance.BattleArea[i].ChildCardData, 0, this.CardData, false, 999, true, false);
			}
			num = i;
		}
		yield return null;
		UIController.LockLevel = UIController.UILevel.None;
		this.CardData.DeleteCardData();
		yield break;
	}
}
