using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CardLogicRequireRare(4)]
public class GuGuaGuGuaGuGuaCardLogic : CardLogic
{
	public override void Init()
	{
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 0, 4);
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_咕呱咕呱咕呱");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_咕呱咕呱咕呱"), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		this.CardData.IsAttacked = true;
		List<CardData> allMonsters = base.GetAllCurrentMonsters();
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_孤寡孤寡孤寡"));
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(2f, 1f).WaitForCompletion();
		if (allMonsters.Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in allMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && base.GetLogic(cardData, typeof(BiXuGuGuaCardLogic)) == null)
			{
				base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_什么"), cardData);
				cardData.AddLogic("BiXuGuGuaCardLogic", base.Layers);
			}
		}
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(1f, 0.5f).WaitForCompletion();
		yield break;
	}

	private float baseDmg = 0.25f;

	private float increaseDmg = 0.25f;
}
