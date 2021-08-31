using System;
using System.Collections;

public class GuShuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "老树";
		this.Desc = "外表是普通大树，实际却是莫得感情的杀手。";
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (cardSlot.ChildCardData == this.CardData)
		{
			this.StartGiftAct("");
		}
		yield break;
	}

	private void StartGiftAct(string value)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		(GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct).GiftNames.Add("生菜种子");
	}
}
