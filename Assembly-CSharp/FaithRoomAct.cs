using System;

public class FaithRoomAct : GameAct
{
	private void Start()
	{
		this.Init();
		this.Source.CardData.DeleteCardData();
		this.ActEnd();
		GameController.ins.UIController.ShowFaithPanel();
	}
}
