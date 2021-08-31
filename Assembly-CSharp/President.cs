using System;
using PixelCrushers.DialogueSystem;

public class President : CardLogic
{
	public override void OnDayPass()
	{
		switch (GameController.getInstance().GameData.Days % 7)
		{
		case 0:
			this.SetAttr("TradeMeetingFlag", "false");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "周日");
			return;
		case 1:
			this.SetAttr("TradeMeetingFlag", "true");
			DialogueLua.SetVariable("IsMeetingDay", true);
			DialogueLua.SetVariable("Date", "周一");
			return;
		case 2:
			this.SetAttr("TradeMeetingFlag", "false");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "周二");
			return;
		case 3:
			this.SetAttr("TradeMeetingFlag", "true");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "周三");
			return;
		case 4:
			this.SetAttr("TradeMeetingFlag", "true");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "周四");
			return;
		case 5:
			this.SetAttr("TradeMeetingFlag", "true");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "周五");
			return;
		case 6:
			this.SetAttr("TradeMeetingFlag", "true");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "周六");
			return;
		default:
			this.SetAttr("TradeMeetingFlag", "false");
			DialogueLua.SetVariable("IsMeetingDay", false);
			DialogueLua.SetVariable("Date", "二月三十");
			return;
		}
	}

	public void SetAttr(string key, string value)
	{
		if (this.CardData.Attrs.ContainsKey(key))
		{
			this.CardData.Attrs[key] = value;
			return;
		}
		this.CardData.Attrs.Add(key, value);
	}
}
