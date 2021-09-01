using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class FaMaLeFaMaLeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "发码了发码了";
		this.Desc = "一个超级强大的技能。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "发码了发码了";
		this.Desc = "一个超级强大的技能。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			FaMaLeFaMaLeLogic.<>c__DisplayClass2_0 CS$<>8__locals1 = new FaMaLeFaMaLeLogic.<>c__DisplayClass2_0();
			base.ShowMe();
			CS$<>8__locals1.obj = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/Canvas/FaMaLeCanvas"));
			Transform trans = CS$<>8__locals1.obj.transform.GetChild(1);
			trans.localScale = Vector3.zero;
			yield return trans.DOScale(1f, 0.2f).WaitForCompletion();
			yield return new WaitForSeconds(2f);
			yield return trans.DOScale(0f, 0.2f).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(CS$<>8__locals1.obj);
			}).WaitForCompletion();
			CS$<>8__locals1 = null;
			trans = null;
		}
		yield break;
	}
}
