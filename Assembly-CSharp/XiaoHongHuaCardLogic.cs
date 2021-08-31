using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class XiaoHongHuaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小红花");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_小红花");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小红花");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_小红花");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData flower = null;
		switch (SYNCRandom.Range(0, 3))
		{
		case 0:
			flower = Card.InitCardDataByID("小熊");
			break;
		case 1:
			flower = Card.InitCardDataByID("发卡");
			break;
		case 2:
			flower = Card.InitCardDataByID("红鞋子");
			break;
		}
		CardSlotData targetSlot = GameController.ins.GetEmptySlotDataByCardData(flower);
		if (targetSlot == null || !GameController.ins.PlayerSlotSets.Contains(targetSlot))
		{
			yield break;
		}
		GameObject tempCard = Card.InitWithOutData(flower, true);
		tempCard.transform.position = this.CardData.CardGameObject.transform.position;
		yield return tempCard.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
		UnityEngine.Object.DestroyImmediate(tempCard);
		flower.PutInSlotData(targetSlot, true);
		yield break;
	}
}
