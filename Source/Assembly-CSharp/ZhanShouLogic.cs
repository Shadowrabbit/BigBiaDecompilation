using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhanShouLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_97");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_97");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_97");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_97");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			int num = 0;
			using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((int)enumerator.Current.CurrentCardSlotData.Attrs["Col"] == num)
					{
						num++;
					}
				}
			}
			if (num < 3)
			{
				List<CardSlotData> myBattleArea = base.GetMyBattleArea();
				List<CardSlotData> list = new List<CardSlotData>();
				foreach (CardSlotData cardSlotData in myBattleArea)
				{
					if ((int)cardSlotData.Attrs["Col"] == num && cardSlotData.ChildCardData == null)
					{
						list.Add(cardSlotData);
					}
				}
				if (list.Count > 0)
				{
					yield return this.TryJump(this.CardData, list);
				}
			}
		}
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO, List<CardSlotData> targets)
	{
		base.ShowMe();
		CardSlotData target = targets[UnityEngine.Random.Range(0, targets.Count)];
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
