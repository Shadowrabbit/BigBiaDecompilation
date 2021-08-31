using System;
using System.Collections;
using UnityEngine;

public class BossSnakeHpMax : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇7");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇7");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇7");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇7");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData && value.value < 0 && Mathf.Abs(value.value) > Mathf.CeilToInt((float)this.CardData.MaxHP / 5f))
		{
			int value2 = Mathf.CeilToInt((float)(-(float)this.CardData.MaxHP) / 5f);
			string name = "Effect/Exile";
			ParticlePoolManager.Instance.Spawn(name, 2f).transform.position = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position;
			value.value = value2;
		}
		yield break;
	}
}
