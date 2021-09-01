using System;
using System.Collections.Generic;

public class ChestAct : GameAct
{
	private void Start()
	{
		this.Init();
		this.StartGiftAct();
		this.Source.CardData.CurrentCardSlotData.CanClick = true;
		this.Source.CardData.DeleteCardData();
		this.ActEnd();
	}

	private void StartGiftAct()
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		GiftAct giftAct = GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct;
		List<string> list = new List<string>();
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if ((cardData.HasTag(TagMap.食物) || cardData.HasTag(TagMap.药水)) && !cardData.HasTag(TagMap.特殊) && cardData.Rare == ((GameController.ins.GameData.level + 1 > 4) ? 4 : (GameController.ins.GameData.level + 1)) && (GlobalController.Instance.AdvanceDataController.GetChouWaZi() || !cardData.ModID.Equals("臭袜子")))
			{
				list.Add(cardData.ModID);
			}
		}
		if (list.Count > 0)
		{
			int num = SYNCRandom.Range(1, 2);
			for (int i = 0; i < num; i++)
			{
				string item = list[SYNCRandom.Range(0, list.Count)];
				while (giftAct.GiftNames.Contains(item))
				{
					item = list[SYNCRandom.Range(0, list.Count)];
				}
				giftAct.GiftNames.Add(item);
			}
		}
	}

	public bool IsOpen;
}
