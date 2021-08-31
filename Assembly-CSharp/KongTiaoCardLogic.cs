using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KongTiaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_空调");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_空调"), base.Layers + this.buff);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_空调");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_空调"), base.Layers + this.buff);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						ParticlePoolManager.Instance.Spawn(this.particleName, 1f).transform.position = cardData.CardGameObject.transform.position + new Vector3(0f, 0.2f, 0f);
						cardData.AddAffix(DungeonAffix.frozen, base.Layers + this.buff);
					}
				}
				yield break;
			}
		}
		yield break;
	}

	private int buff = 2;

	public string particleName = "Effect/snowball";

	public string particleName1 = "Effect/snowball_hero";
}
