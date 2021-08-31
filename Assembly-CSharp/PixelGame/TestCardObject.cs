using System;
using UnityEngine;

namespace PixelGame
{
	public class TestCardObject : ObjectBase
	{
		public override void Release()
		{
			UnityEngine.Object.Destroy((GameObject)this.target);
		}
	}
}
