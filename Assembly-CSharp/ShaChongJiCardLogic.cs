using System;
using System.Collections;
using System.Collections.Generic;

public class ShaChongJiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_杀虫剂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_杀虫剂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_杀虫剂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_杀虫剂");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count > 0)
			{
				foreach (CardData cardData in allCurrentMonsters)
				{
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, 0, 0.2f, false, 0, null, null));
					cardData.AddAffix(DungeonAffix.poisoning, 4);
				}
			}
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count > 0)
			{
				using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CardData cardData2 = enumerator.Current;
						DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData2, 0, 0.2f, false, 0, null, null));
						cardData2.AddAffix(DungeonAffix.poisoning, 4);
					}
					yield break;
				}
			}
		}
		yield break;
	}

	private float dmg = 0.45f;
}
