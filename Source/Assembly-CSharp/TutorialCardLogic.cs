using System;
using System.Collections;
using System.Collections.Generic;

public class TutorialCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "指引之路";
		this.Desc = "本关卡将指引你如何挑战BIGBIA的世界";
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.StartBattleCount++;
		switch (this.StartBattleCount)
		{
		case 1:
			GameController.getInstance().ShowGuideCanvas(3, 3);
			break;
		case 2:
			GameController.getInstance().ShowGuideCanvas(8, 9);
			break;
		case 3:
			GameController.getInstance().ShowGuideCanvas(10, 11);
			break;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!this.FirstEndTurn)
		{
			GameController.getInstance().ShowGuideCanvas(5, 5);
			this.FirstEndTurn = true;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (!this.HasFirstAtk)
		{
			GameController.getInstance().ShowGuideCanvas(4, 4);
			this.HasFirstAtk = true;
		}
		yield break;
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		base.OnAfterKill(cardSlot, originCarddata);
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			this.battleCount++;
		}
		if (this.battleCount == 1 && allCurrentMonsters.Count == 0)
		{
			base.GameController.DialogueController.StartGift("流浪狗,生命药水");
			GameController.getInstance().ShowGuideCanvas(6, 7);
		}
		if (this.battleCount == 2 && allCurrentMonsters.Count == 0)
		{
			base.GameController.DialogueController.StartGift("乞丐,雪球");
		}
		yield break;
	}

	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		this.MoveOnMap++;
		if (this.MoveOnMap == 1)
		{
			GameController.getInstance().ShowGuideCanvas(2, 2);
		}
		yield break;
	}

	private bool HasFirstAtk;

	private bool FirstEndTurn;

	private bool FirstTurn;

	private int battleCount;

	private int MoveOnMap;

	private int StartBattleCount;
}
