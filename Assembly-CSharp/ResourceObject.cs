using System;
using PixelGame;
using UnityEngine;

public class ResourceObject : ObjectBase
{
	public ResourceObject(string name, object target)
	{
		this.Name = name;
		this.target = target;
	}

	public override void Release()
	{
		ResourceManager.Instance.RemoveResource(this);
		this.target = null;
		Resources.UnloadUnusedAssets();
	}
}
