using System;

public class ShellSeedLogic : CardLogic
{
	public override void Init()
	{
		this.AddAffix();
	}

	private void AddAffix()
	{
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}
}
