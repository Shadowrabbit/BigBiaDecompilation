using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

[CardLogicRequireRare(4)]
public class SiFenWeiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(1, 1, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_冷笑话");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_冷笑话");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_冷笑话");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_冷笑话");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_最好玩的游戏"));
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(2f, 1f).WaitForCompletion();
		if (base.GetAllCurrentMonsters().Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in base.GetAllCurrentMonsters())
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_太冷了"), cardData);
				cardData.AddAffix(DungeonAffix.frozen, 6);
			}
		}
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(1f, 0.5f).WaitForCompletion();
		this.CardData.IsAttacked = true;
		yield break;
	}
}
