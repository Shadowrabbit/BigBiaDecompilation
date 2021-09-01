using System;
using System.Collections;
using System.Collections.Generic;

public class HaoXiBuDuanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_好戏不断");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_好戏不断");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_好戏不断");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_好戏不断");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target.HasTag(TagMap.怪物) && target != this.CardData)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_接下来更精彩"));
			using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						DungeonOperationMgr.Instance.StartCoroutine(base.wATKUp(this.CardData.CardGameObject.transform.position, 0, cardData));
					}
					cardData.MaxArmor++;
					cardData.Armor++;
					cardData.AddAffix(DungeonAffix.strength, 1);
				}
				yield break;
			}
		}
		yield break;
	}

	private float buff = 0.1f;
}
