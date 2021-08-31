using System;

public class SubScreenBase
{
	public UISubControlBase SubControlBase
	{
		get
		{
			return this.subControlBase;
		}
	}

	public SubScreenBase(UISubControlBase subControlBase)
	{
		this.subControlBase = subControlBase;
	}

	public virtual void Init()
	{
	}

	public virtual void Dispose()
	{
	}

	protected UISubControlBase subControlBase;
}
