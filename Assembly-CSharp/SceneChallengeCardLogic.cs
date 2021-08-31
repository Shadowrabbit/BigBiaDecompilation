using System;
using System.Collections;
using System.Collections.Generic;

public class SceneChallengeCardLogic : CardLogic
{
	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		this.Step++;
		if (this.Step == 3 && GameController.getInstance().GameData.Money >= 44)
		{
			this.winCount++;
		}
		if (this.Step <= 3)
		{
			YesPanel yesPanel = GameController.ins.UIController.YesPanel;
			switch (this.Step)
			{
			case 1:
				yesPanel.MainText.text = "挑战：满血通过此战斗";
				break;
			case 2:
				yesPanel.MainText.text = "挑战：投篮命中2个或以上";
				break;
			case 3:
				yesPanel.MainText.text = "挑战：战胜精英敌人";
				break;
			}
			yield return yesPanel.StartChoosing();
		}
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		CardData hero = base.GetHero();
		if (!DungeonOperationMgr.Instance.CheckCardDead(hero) && DungeonOperationMgr.Instance.EnemyDifficult == 1)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			YesPanel yesPanel = GameController.ins.UIController.YesPanel;
			yesPanel.MainText.text = "挑战成功！";
			if (allCurrentMinions.Count < 3)
			{
				yesPanel.MainText.text = "挑战失败！";
			}
			if (allCurrentMinions.Count == 3)
			{
				foreach (CardData cardData in allCurrentMinions)
				{
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData.MaxHP > cardData.HP)
					{
						yesPanel.MainText.text = "挑战失败！";
					}
				}
			}
			if (yesPanel.MainText.text == "挑战成功！")
			{
				this.winCount++;
			}
			yield return yesPanel.StartChoosing();
			ActData actData = new ActData();
			actData.Type = "Act/Gift";
			actData.Model = "ActTable/Gift";
			GiftAct giftAct = GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct;
			giftAct.GiftNames.Add("打火机");
			giftAct.GiftNames.Add("打火机");
		}
		if (!DungeonOperationMgr.Instance.CheckCardDead(hero) && DungeonOperationMgr.Instance.EnemyDifficult == 3)
		{
			this.winCount++;
			base.GetAllCurrentMinions();
			YesPanel yesPanel2 = GameController.ins.UIController.YesPanel;
			yesPanel2.MainText.text = "挑战成功！ 恭喜你通过了" + this.winCount.ToString() + "/3项挑战！";
			yield return yesPanel2.StartChoosing();
			ActData actData2 = new ActData();
			actData2.Type = "Act/Gift";
			actData2.Model = "ActTable/Gift";
			GiftAct giftAct2 = GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData2) as GiftAct;
			giftAct2.GiftNames.Add("篮球鞋");
			giftAct2.GiftNames.Add("照相机");
			giftAct2.GiftNames.Add("围棋");
		}
		yield break;
	}

	private int Step;

	private int winCount;
}
