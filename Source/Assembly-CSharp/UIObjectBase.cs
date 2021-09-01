using System;
using PixelGame;

public class UIObjectBase : ObjectBase
{
	public UIObjectBase(string name, object target, object asset)
	{
		this.Name = name;
		this.target = target;
		this.LastUseTime = DateTime.Now;
		this.asset = asset;
	}

	public void CloseUI()
	{
		((ScreenBase)this.target).OnClose();
	}

	public override void Release()
	{
		ResourceManager.Instance.UnLoadResource(this.asset);
		((ScreenBase)this.target).Dispose();
	}

	public object asset;
}
