using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class YanWuMiZhangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_96");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_96");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_96");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_96");
	}

	public override IEnumerator OnTurnStart()
	{
		this.CardData.MP = 2;
		yield break;
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData && value.value < 0 && this.CardData.MP > 0)
		{
			base.ShowMe();
			value.value = 0;
			this.CardData.MP--;
			yield return this.FadeCoroutine();
			string value2 = "\n<color=#00d7ff>" + -1.ToString() + "</color>";
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, value2, UnityEngine.Color.white, 0, false, false);
		}
		yield break;
	}

	private IEnumerator FadeCoroutine()
	{
		GameObject copyGo = UnityEngine.Object.Instantiate<GameObject>(this.CardData.CardGameObject.gameObject);
		copyGo.transform.SetParent(this.CardData.CardGameObject.transform.parent);
		copyGo.transform.localPosition = this.CardData.CardGameObject.transform.localPosition;
		copyGo.transform.localScale = this.CardData.CardGameObject.transform.localScale;
		UnityEngine.Object.Destroy(copyGo.GetComponent<Card>());
		new FadeModel(copyGo, 0.5f).HideModel();
		copyGo.transform.DOScale(Vector3.one * 3f, 0.5f).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(copyGo);
		});
		yield break;
	}
}
