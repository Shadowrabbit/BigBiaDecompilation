using System;
using System.Collections;

public class ShowCardsTableAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	private UIController.UILevel m_Lock = UIController.UILevel.All;
}
