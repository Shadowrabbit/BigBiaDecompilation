using System;
using System.Collections;

public abstract class AreaLogic
{
	public AreaData Data
	{
		get
		{
			return this.m_Data;
		}
		set
		{
			this.m_Data = value;
		}
	}

	public bool IsDone
	{
		get
		{
			return this.m_IsDone;
		}
		set
		{
			this.m_IsDone = value;
		}
	}

	public abstract void BeforeInit();

	public abstract void BeforeEnter();

	public abstract void OnExit();

	public virtual IEnumerator OnAlreadEnter()
	{
		if (!GameController.ins.GameData.isInDungeon)
		{
			yield break;
		}
		if (this.IsFirstEnter)
		{
			DungeonOperationMgr.Instance.FlipAllFlopableCards();
			this.IsFirstEnter = false;
		}
		else
		{
			DungeonOperationMgr.Instance.FlipAllFlopableCards();
		}
		yield break;
	}

	public virtual IEnumerator ExitProcess()
	{
		yield break;
	}

	public virtual void OnTick()
	{
	}

	public virtual void OnDayPass()
	{
	}

	public virtual void OnActEnd()
	{
	}

	public virtual void OnGameLoaded()
	{
	}

	public virtual void OnGameStart()
	{
	}

	public AreaLogic()
	{
	}

	~AreaLogic()
	{
	}

	protected AreaData m_Data;

	protected bool m_IsDone;

	public bool IsFirstEnter = true;
}
