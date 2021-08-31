using System;
using System.Collections;

public class BankHouse : AreaLogic
{
	public object GetCardAttr(CardData cs, string name)
	{
		if (cs.Attrs.ContainsKey(name))
		{
			if (cs.Attrs[name] != null)
			{
				return cs.Attrs[name];
			}
			if (cs.HiddenAttrs[name] != null)
			{
				return cs.HiddenAttrs[name];
			}
		}
		return 1;
	}

	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
		UIController.LockLevel = this.m_Lock;
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		GameController.ins.UIController.HideBlackMask(delegate
		{
			GameController.getInstance().UIController.ShowBackToHomeButton();
		}, 0.5f);
		yield break;
	}

	private UIController.UILevel m_Lock = UIController.UILevel.All;
}
