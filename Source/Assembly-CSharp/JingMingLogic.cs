using System;

public class JingMingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "精明";
		this.Desc = "久历沙场，并精通战场节奏。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.AddLogic("YingYongLogic");
		this.CardData.CardLogics.Remove(this);
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		this.CardData.Name = "英勇战将";
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}
}
