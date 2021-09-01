using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SelfHealingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_186");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_186"), Mathf.CeilToInt((float)this.CardData.MaxHP * 0.01f * (float)base.Layers), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_186");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_186"), Mathf.CeilToInt((float)this.CardData.MaxHP * 0.01f * (float)base.Layers), base.Layers);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && this.CardData.HP < this.CardData.MaxHP)
		{
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.5f);
			particleObject.transform.position = this.CardData.CardGameObject.transform.position;
			yield return particleObject.transform.DOMove(this.CardData.CardGameObject.transform.position, 0.5f, false).WaitForCompletion();
			string name = "Effect/HealHp";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, Mathf.CeilToInt(0.01f * (float)base.Layers * (float)this.CardData.MaxHP), this.CardData, false, 0, true, false);
		}
		yield break;
	}
}
