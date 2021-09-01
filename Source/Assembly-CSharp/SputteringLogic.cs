using System;
using System.Collections.Generic;
using UnityEngine;

public class SputteringLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "溅射";
		this.Desc = "攻击会溅射到与当前攻击范围相邻的一个额外目标上";
	}

	public override void OnMerge(CardData mergeBy)
	{
		if (this.CardData != null)
		{
			List<Vector3Int> list = new List<Vector3Int>
			{
				Vector3Int.left,
				Vector3Int.right,
				Vector3Int.up,
				Vector3Int.down
			};
			if (this.CardData.AttackExtraRange == null)
			{
				this.CardData.AttackExtraRange = new List<Vector3Int>
				{
					list[UnityEngine.Random.Range(0, list.Count)]
				};
			}
			else if (this.CardData.AttackExtraRange.Count == 0)
			{
				this.CardData.AttackExtraRange = new List<Vector3Int>
				{
					list[UnityEngine.Random.Range(0, list.Count)]
				};
			}
			else
			{
				List<Vector3Int> attackExtraRange = this.CardData.AttackExtraRange;
				List<Vector3Int> list2 = new List<Vector3Int>();
				attackExtraRange.Add(Vector3Int.zero);
				foreach (Vector3Int a in attackExtraRange)
				{
					if (!attackExtraRange.Contains(a + Vector3Int.left))
					{
						list2.Add(a + Vector3Int.left);
					}
					if (!attackExtraRange.Contains(a + Vector3Int.right))
					{
						list2.Add(a + Vector3Int.right);
					}
					if (!attackExtraRange.Contains(a + Vector3Int.up))
					{
						list2.Add(a + Vector3Int.up);
					}
					if (!attackExtraRange.Contains(a + Vector3Int.down))
					{
						list2.Add(a + Vector3Int.down);
					}
				}
				if (list2.Count > 0)
				{
					this.CardData.AttackExtraRange.Add(list2[UnityEngine.Random.Range(0, list2.Count)]);
				}
			}
		}
		base.OnMerge(mergeBy);
	}
}
