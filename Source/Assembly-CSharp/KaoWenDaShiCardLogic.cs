using System;
using System.Collections;

public class KaoWenDaShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_撕裂伤口");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_撕裂伤口");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_撕裂伤口");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_撕裂伤口");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				CardLogic logic = base.GetLogic(attackMsg.Target, typeof(BleedingCardLogic));
				if (logic != null)
				{
					logic.Layers *= 2;
				}
			}
		}
		yield break;
	}

	private bool HaveJumped = true;
}
