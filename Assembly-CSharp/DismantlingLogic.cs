using System;
using System.Collections;
using UnityEngine;

public class DismantlingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData == null || (this.CardData != null && this.CardData.HasTag(TagMap.随从)))
		{
			this.Color = CardLogicColor.red;
		}
		this.displayName = "拆解";
		this.Desc = "击杀时，30%获得金币增加" + (base.Layers * 100).ToString() + "%";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (from != null && from == this.CardData && UnityEngine.Random.Range(0, 100) < 30)
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.GetMoneyAnimate(target.Price * base.Layers, target.CardGameObject.transform.position, Vector3.zero);
		}
		yield break;
	}
}
