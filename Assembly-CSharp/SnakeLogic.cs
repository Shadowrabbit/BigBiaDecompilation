using System;
using System.Collections;

public class SnakeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "蛇毒";
		this.Desc = "攻击时，若目标未石化，50%使其石化2回合。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && player == this.CardData && base.GetLogic(target.ChildCardData, typeof(SnakeRockLogic)) == null && SYNCRandom.Range(1, 11) <= 5)
		{
			target.ChildCardData.RemainTime = 2;
			this.AddLogic("SnakeRockLogic", target.ChildCardData);
			yield break;
		}
		yield break;
	}

	private void AddLogic(string logicName, CardData cd)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.ExistsRound = 1;
		cardLogic.CardData = this.CardData;
		cd.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
		cardLogic.Init();
	}

	private CardData CurrentData;
}
