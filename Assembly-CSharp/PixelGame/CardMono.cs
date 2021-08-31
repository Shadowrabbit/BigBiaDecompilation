using System;
using UnityEngine;

namespace PixelGame
{
	public class CardMono : MonoBehaviour
	{
		private void OnMouseDown()
		{
			this.ObjectPoolTest.ObjectPool.UnSpawn(this.Object);
			base.gameObject.SetActive(false);
		}

		public ObjectPoolTest ObjectPoolTest;

		public TestCardObject Object;
	}
}
