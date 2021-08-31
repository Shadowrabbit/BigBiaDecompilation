using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelImporter
{
	public class ColliderTest : MonoBehaviour
	{
		private void Update()
		{
			if (this.autoBirth)
			{
				float num = UnityEngine.Random.Range(this.sepalateTimeMin, this.sepalateTimeMax);
				if (this.timer - this.timerBeforeBirth > num)
				{
					this.Add();
					this.timerBeforeBirth = this.timer;
				}
			}
			for (int i = 0; i < this.createList.Count; i++)
			{
				GameObject gameObject = this.createList[i];
				if (gameObject.transform.position.y < this.groundY)
				{
					UnityEngine.Object.Destroy(gameObject);
					this.createList.RemoveAt(i--);
				}
			}
			this.timer += Time.deltaTime;
		}

		public void Add()
		{
			GameObject gameObject;
			if (this.addObject != null)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.addObject);
			}
			else
			{
				PrimitiveType type;
				if (this.primitive == ColliderTest.Primitive.Random)
				{
					int num = UnityEngine.Random.Range(0, 3);
					if (num != 0)
					{
						if (num != 1)
						{
							type = PrimitiveType.Cube;
						}
						else
						{
							type = PrimitiveType.Capsule;
						}
					}
					else
					{
						type = PrimitiveType.Sphere;
					}
				}
				else
				{
					type = (PrimitiveType)this.primitive;
				}
				gameObject = GameObject.CreatePrimitive(type);
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f, 1f) * this.randomRadius, UnityEngine.Random.Range(-1f, 1f) * this.randomRadius, UnityEngine.Random.Range(-1f, 1f) * this.randomRadius);
			gameObject.transform.localRotation = UnityEngine.Random.rotation;
			float num2 = UnityEngine.Random.Range(this.randomScaleMin, this.randomScaleMax);
			gameObject.transform.localScale = new Vector3(num2, num2, num2);
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			if (component != null)
			{
				rigidbody.mass = num2 * (component.sharedMesh.bounds.size.x * component.sharedMesh.bounds.size.y * component.sharedMesh.bounds.size.z);
			}
			else
			{
				rigidbody.mass = num2;
			}
			GameObject gameObject2 = gameObject;
			gameObject2.name += this.count.ToString();
			this.createList.Add(gameObject);
			this.count++;
		}

		public GameObject addObject;

		public ColliderTest.Primitive primitive = ColliderTest.Primitive.Random;

		public bool autoBirth = true;

		public float sepalateTimeMin = 0.5f;

		public float sepalateTimeMax = 1f;

		public float randomRadius = 1f;

		public float randomScaleMin = 0.5f;

		public float randomScaleMax = 1.5f;

		public float groundY = -10f;

		private float timer;

		private float timerBeforeBirth;

		private List<GameObject> createList = new List<GameObject>();

		private int count;

		public enum Primitive
		{
			Random = -1,
			Sphere,
			Capsule,
			Cube = 3
		}
	}
}
