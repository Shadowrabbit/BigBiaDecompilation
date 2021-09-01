using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuiWoDeDuZi : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_捶我的肚子");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_捶我的肚子");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_捶我的肚子");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_捶我的肚子");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue < 0)
		{
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = base.GetAllCurrentMinions().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					cardData.InBattleATK++;
					string name = "Effect/HealATK";
					ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = cardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
				}
				yield break;
			}
		}
		yield break;
	}
}
