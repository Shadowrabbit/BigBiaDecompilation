using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiBanCaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_195");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_195"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_195");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_195"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (target.ChildCardData == null)
		{
			yield break;
		}
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		list.Add(Vector3Int.up);
		list.Add(Vector3Int.down);
		AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target != null && !DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target) && attackMsg.Target.DizzyLayer > 0)
				{
					base.ShowMe();
					attackMsg.Dmg += Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
				}
			}
		}
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.ShotEffects.Add("");
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.HitEffects.Add("Effect/Damaged");
		yield break;
	}

	private float baseDmg = 0.25f;

	private float increaseDmg = 0.25f;
}
