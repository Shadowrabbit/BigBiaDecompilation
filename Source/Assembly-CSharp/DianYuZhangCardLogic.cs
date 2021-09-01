using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DianYuZhangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_吞咽");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_吞咽");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_吞咽");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_吞咽");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn && !this.HasJumped)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Contains(this.CardData))
			{
				allCurrentMonsters.Remove(this.CardData);
			}
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			base.ShowMe();
			CardData target = allCurrentMonsters[SYNCRandom.Range(0, allCurrentMonsters.Count)];
			CardSlotData targetSlot = target.CurrentCardSlotData;
			Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
			yield return this.CardData.CardGameObject.transform.DOJump(target.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
			yield return this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
			this.CardData.MergeBy(target, true, true);
			this.CardData.CardTags = 32768UL;
			yield return this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
			target.DeleteCardData();
			this.CardData.PutInSlotData(targetSlot, true);
			this.HasJumped = true;
			target = null;
			targetSlot = null;
			oldScale = default(Vector3);
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.HasJumped = false;
		yield break;
	}

	private bool HasJumped;
}
