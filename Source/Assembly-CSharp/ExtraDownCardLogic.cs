using System;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDownCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_56");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_56"), base.Layers);
		Vector3Int vector3Int = Vector3Int.down + Vector3Int.left;
		if (this.CardData != null)
		{
			for (int i = 0; i < base.Layers; i++)
			{
				if (this.CardData.AttackExtraRange == null)
				{
					this.CardData.AttackExtraRange = new List<Vector3Int>
					{
						Vector3Int.down + Vector3Int.left
					};
				}
				else
				{
					if (!this.CardData.AttackExtraRange.Contains(vector3Int))
					{
						this.CardData.AttackExtraRange.Add(vector3Int);
					}
					vector3Int += Vector3Int.down + Vector3Int.left;
				}
			}
		}
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_56");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_56"), base.Layers);
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		Vector3Int vector3Int = Vector3Int.down + Vector3Int.left;
		if (this.CardData != null)
		{
			for (int i = 0; i < base.Layers; i++)
			{
				if (this.CardData.AttackExtraRange == null)
				{
					this.CardData.AttackExtraRange = new List<Vector3Int>
					{
						Vector3Int.down + Vector3Int.left
					};
				}
				else
				{
					if (!this.CardData.AttackExtraRange.Contains(vector3Int))
					{
						this.CardData.AttackExtraRange.Add(vector3Int);
					}
					vector3Int += Vector3Int.down + Vector3Int.left;
				}
			}
		}
	}
}
