using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayerCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_50");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_50_1") + base.Layers.ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_50_2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_50");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_50_1") + base.Layers.ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_50_2");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
		List<AttackMsg> list2 = new List<AttackMsg>();
		using (List<List<AttackMsg>>.Enumerator enumerator = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				List<AttackMsg> list3 = enumerator.Current;
				foreach (AttackMsg attackMsg in list3)
				{
					if (!DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target) && attackMsg.Target != null)
					{
						List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
						allCurrentMonsters.Remove(attackMsg.Target);
						if (allCurrentMonsters.Count > 0)
						{
							attackMsg.Target = allCurrentMonsters[SYNCRandom.Range(0, allCurrentMonsters.Count)];
							attackMsg.Dmg *= base.Layers + 1;
						}
						else
						{
							base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_草皮太湿"));
							attackMsg.Target = null;
							attackMsg.Dmg = 0;
						}
					}
					list2.Clear();
				}
			}
			yield break;
		}
		yield break;
	}
}
