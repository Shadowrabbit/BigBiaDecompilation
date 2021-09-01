using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuBlackFogLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_墨潮");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_墨潮") + this.round.ToString();
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.round--;
			if (this.round == 0)
			{
				this.CardData.CardLogics.Remove(this);
			}
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_墨潮");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_墨潮") + this.round.ToString();
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		if (!this.isClick)
		{
			this.isClick = true;
		}
		else
		{
			this.isClick = false;
		}
		BossCSLArea bossCSLArea = UnityEngine.Object.FindObjectOfType<BossCSLArea>();
		this.HideAndShow(bossCSLArea.Boss, false, bossCSLArea.BossCard.CardGameObject.gameObject);
	}

	public override bool OnUse(List<Vector2[]> res)
	{
		BossCSLArea bossCSLArea = UnityEngine.Object.FindObjectOfType<BossCSLArea>();
		this.HideAndShow(bossCSLArea.Boss, true, bossCSLArea.BossCard.CardGameObject.gameObject);
		return true;
	}

	public override void OnCalcelUse()
	{
		BossCSLArea bossCSLArea = UnityEngine.Object.FindObjectOfType<BossCSLArea>();
		this.HideAndShow(bossCSLArea.Boss, true, bossCSLArea.BossCard.CardGameObject.gameObject);
	}

	private void HideAndShow(GameObject target, bool isShow, GameObject cardObj = null)
	{
		SkinnedMeshRenderer[] componentsInChildren = target.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = isShow;
		}
		if (cardObj != null)
		{
			cardObj.transform.parent.GetComponent<BoxCollider>().enabled = isShow;
			int childCount = cardObj.transform.childCount;
			cardObj.transform.GetChild(0).gameObject.SetActive(isShow);
			cardObj.transform.GetChild(childCount - 1).gameObject.SetActive(isShow);
		}
	}

	private bool isClick;

	private int round = 3;
}
