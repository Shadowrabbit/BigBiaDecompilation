using System;

public class HuntingAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (this.Source.CardData.Attrs.ContainsKey("Flag"))
		{
			this.Source.CardData.Attrs["Flag"] = 2;
		}
		else
		{
			this.Source.CardData.Attrs.Add("Flag", 2);
		}
		UIController.LockLevel = UIController.UILevel.None;
		this.ActEnd();
	}

	private void Update()
	{
	}
}
