using System;

public class ChanRuoZhanShiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "成长";
		this.Desc = "该单位合成后只增长自身特效。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.AddLogic("BiaoZhunLogic");
		this.CardData.CardLogics.Remove(this);
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		this.CardData.Name = "标准战士";
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}
}
