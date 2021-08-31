using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

[CardLogicRequireRare(4)]
public class KuXingSengSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_念经");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_念经"), 3);
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 3 - base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_念经");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_念经"), 3);
		this.NeedEnergyCount = new Vector3Int(0, 0, 3 - base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_吃葡萄"));
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(2f, 1f).WaitForCompletion();
		if (base.GetAllCurrentMonsters().Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in base.GetAllCurrentMonsters())
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_师傅莫念"), cardData);
				cardData.AddAffix(DungeonAffix.weak, 3);
				cardData.AddAffix(DungeonAffix.frail, 3);
			}
		}
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(1f, 0.5f).WaitForCompletion();
		this.CardData.IsAttacked = true;
		yield break;
	}

	private int baseDmg = 3;
}
