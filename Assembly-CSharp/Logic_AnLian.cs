using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Logic_AnLian : TwoPeopleCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_156");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_156");
	}

	public override IEnumerator OnBattleEnd()
	{
		CardData target = base.GetCardByID(this.TargetID);
		if (target != null)
		{
			if (target == this.CardData)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_暗恋1"));
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
			if (target.HP < target.MaxHP)
			{
				yield break;
			}
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_45"));
			yield return this.Cure(this.CardData, 3, target);
		}
		else
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_暗恋2"));
			this.CardData.RemoveCardLogic(this);
		}
		yield break;
	}

	private new IEnumerator Cure(CardData origin, int val, CardData target)
	{
		if (target.HP >= target.MaxHP)
		{
			yield break;
		}
		ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
		particleObject.transform.position = origin.CardGameObject.transform.position;
		yield return particleObject.transform.DOMove(target.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
		string name = "Effect/HealHp";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = target.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, val, origin, false, 0, true, false);
		yield break;
	}
}
