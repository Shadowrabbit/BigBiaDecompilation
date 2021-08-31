using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuiMieCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_毁灭");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_毁灭"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f, 4 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_毁灭");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_毁灭"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f, 4 + base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		CardData defaultTarget = base.GetDefaultTarget();
		this.CardData.IsAttacked = true;
		if (DungeonOperationMgr.Instance.CheckCardDead(defaultTarget))
		{
			yield break;
		}
		Dictionary<CardData, int> targets = new Dictionary<CardData, int>();
		int num = -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
		targets.Add(defaultTarget, num);
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		list.Add(Vector3Int.down);
		list.Add(Vector3Int.up);
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		base.ShowMe();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(defaultTarget.CurrentCardSlotData.GridPositionX, defaultTarget.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData))
			{
				targets.Add(ralitiveCardSlotData.ChildCardData, Mathf.CeilToInt((float)num));
			}
		}
		yield return base.AOE(targets, this.CardData, false, 0, true);
		using (Dictionary<CardData, int>.Enumerator enumerator2 = targets.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				KeyValuePair<CardData, int> keyValuePair = enumerator2.Current;
				if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair.Key))
				{
					keyValuePair.Key.AddAffix(DungeonAffix.bleeding, 4 + base.Layers);
				}
			}
			yield break;
		}
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 0.5f;
}
