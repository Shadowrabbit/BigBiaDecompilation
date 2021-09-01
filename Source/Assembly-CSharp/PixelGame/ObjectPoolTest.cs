using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
	public class ObjectPoolTest : MonoBehaviour
	{
		private void Start()
		{
			this.ObjectPool = ObjectPoolComponent.Instance.ObjectPoolManager.CreateSingleObjectPool<TestCardObject>("CardPool");
			ObjectPoolComponent.Instance.ObjectPoolManager.CreateSingleObjectPool<TestCardObject>("TestPool");
		}

		private void Update()
		{
		}

		public void CreateCard(string name)
		{
			TestCardObject testCardObject = this.ObjectPool.Spawn(name);
			if (testCardObject == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(name)) as GameObject;
				testCardObject = new TestCardObject();
				testCardObject.Name = name;
				testCardObject.target = gameObject;
				testCardObject.LastUseTime = DateTime.Now;
				CardMono cardMono = gameObject.AddComponent<CardMono>();
				gameObject.AddComponent<BoxCollider>();
				cardMono.Object = testCardObject;
				cardMono.ObjectPoolTest = this;
				cardMono.transform.SetParent(base.transform);
				cardMono.transform.localPosition = new Vector3((float)UnityEngine.Random.Range(0, 10), 0f, (float)UnityEngine.Random.Range(0, 10));
				this.ObjectPool.Register(testCardObject, true);
			}
			((GameObject)testCardObject.target).SetActive(true);
			this.list.Add(testCardObject);
		}

		public IObjectPool<TestCardObject> ObjectPool;

		public List<TestCardObject> list = new List<TestCardObject>();
	}
}
