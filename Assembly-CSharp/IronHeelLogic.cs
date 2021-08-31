using System;
using System.Collections;

public class IronHeelLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "摧坚";
		this.Desc = "攻击有护甲的单位前，同时扣除自身生命值与目标护甲值X点。X为二者中较小者。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (target.ChildCardData != null && target.ChildCardData.Armor <= 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		else
		{
			int Value = (this.CardData.HP > target.ChildCardData.Armor) ? target.ChildCardData.Armor : this.CardData.HP;
			yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, target.ChildCardData, 1f, null, null, null);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target.ChildCardData, 0, this.CardData, false, Value, true, false);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -Value, this.CardData, false, 0, true, false);
		}
		yield break;
	}
}
