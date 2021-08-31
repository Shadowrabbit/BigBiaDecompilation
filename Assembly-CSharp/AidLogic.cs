using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(1, 0, 1);
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_27");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_27_1") + Mathf.CeilToInt((float)this.CardData.ATK).ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_27_2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_27");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_27_1") + Mathf.CeilToInt((float)this.CardData.ATK).ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_27_2");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		List<CardData> list = new List<CardData>();
		if (slotsOnPlayerTable.Contains(this.CardData.CurrentCardSlotData))
		{
			int num = slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData);
			if (num < slotsOnPlayerTable.Count / 3)
			{
				for (int i = 0; i < slotsOnPlayerTable.Count / 3; i++)
				{
					if (slotsOnPlayerTable[i].ChildCardData != null && slotsOnPlayerTable[i].ChildCardData.HasTag(TagMap.随从) && slotsOnPlayerTable[i].ChildCardData != this.CardData && slotsOnPlayerTable[i].ChildCardData.HP < slotsOnPlayerTable[i].ChildCardData.MaxHP)
					{
						list.Add(slotsOnPlayerTable[i].ChildCardData);
					}
				}
			}
			else if (num < slotsOnPlayerTable.Count / 3 * 2)
			{
				for (int j = slotsOnPlayerTable.Count / 3; j < slotsOnPlayerTable.Count / 3 * 2; j++)
				{
					if (slotsOnPlayerTable[j].ChildCardData != null && slotsOnPlayerTable[j].ChildCardData.HasTag(TagMap.随从) && slotsOnPlayerTable[j].ChildCardData != this.CardData && slotsOnPlayerTable[j].ChildCardData.HP < slotsOnPlayerTable[j].ChildCardData.MaxHP)
					{
						list.Add(slotsOnPlayerTable[j].ChildCardData);
					}
				}
			}
			else
			{
				for (int k = slotsOnPlayerTable.Count / 3 * 2; k < slotsOnPlayerTable.Count; k++)
				{
					if (slotsOnPlayerTable[k].ChildCardData != null && slotsOnPlayerTable[k].ChildCardData.HasTag(TagMap.随从) && slotsOnPlayerTable[k].ChildCardData != this.CardData && slotsOnPlayerTable[k].ChildCardData.HP < slotsOnPlayerTable[k].ChildCardData.MaxHP)
					{
						list.Add(slotsOnPlayerTable[k].ChildCardData);
					}
				}
			}
		}
		if (list.Count > 0)
		{
			base.ShowLogic("救赎！");
			using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData target = enumerator.Current;
					DungeonOperationMgr.Instance.StartCoroutine(base.Cure(this.CardData, this.CardData.ATK, target));
				}
				yield break;
			}
		}
		yield break;
	}
}
