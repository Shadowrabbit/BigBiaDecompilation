using System;
using System.Collections;

public class MaoBiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_狼毫笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_狼毫笔"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_狼毫笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_狼毫笔"), base.Layers);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Count > 0)
			{
				foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
				{
					int num = 0;
					if (this.CardData.affixesDic != null && this.CardData.affixesDic.ContainsKey(DungeonAffix.strength))
					{
						num = this.CardData.affixesDic[DungeonAffix.strength] / 3;
					}
					attackMsg.reduceArmor += num * base.Layers;
				}
			}
		}
		yield break;
	}
}
