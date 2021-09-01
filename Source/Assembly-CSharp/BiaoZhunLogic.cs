using System;

public class BiaoZhunLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "标准";
		this.Desc = "一位符合标准的战士。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.AddLogic("JingMingLogic");
		this.CardData.CardLogics.Remove(this);
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		this.CardData.Name = "精明战士";
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}
}
