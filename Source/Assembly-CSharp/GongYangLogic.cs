using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GongYangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_87");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_87");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_87");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_87");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			int num = (int)((float)target.ChildCardData.MaxHP * 0.2f);
			List<CardData> list = new List<CardData>();
			foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID.Equals("幼虫"))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (list.Count > 0)
			{
				base.ShowMe();
				CardData targetE = list[SYNCRandom.Range(0, list.Count)];
				targetE.MaxHP += num;
				targetE.HP += num;
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
				particleObject.transform.position = target.ChildCardData.CardGameObject.transform.position;
				yield return particleObject.transform.DOMove(targetE.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
				string name = "Effect/HealHp";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = targetE.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
				targetE = null;
			}
		}
		yield break;
	}
}
