using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ShengGuangBiHuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 3);
		this.displayName = "圣光庇护";
		this.Desc = "同排所有单位+1护甲。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		foreach (CardSlotData cardSlotData in GameController.getInstance().YellowLineSlots)
		{
			if (cardSlotData.ChildCardData != null)
			{
				base.ShowMe();
				cardSlotData.ChildCardData.Armor++;
			}
		}
		this.CardData.IsAttacked = true;
		GameController.ins.UIController.AreaAdvocateDesc.transform.parent.DOPunchPosition(Vector3.right * 30f, 0.4f, 10, 1f, false);
		yield break;
	}
}
