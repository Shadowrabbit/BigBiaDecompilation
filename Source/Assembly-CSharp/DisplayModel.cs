using System;
using PixelGame;
using UnityEngine;

public class DisplayModel : ObjectBase
{
	public GameObject GameObject
	{
		get
		{
			return this.target as GameObject;
		}
	}

	public Transform transform
	{
		get
		{
			return this.GameObject.transform;
		}
	}

	public DisplayModel(string name, object target)
	{
		this.Name = name;
		this.target = target;
	}

	public override void Release()
	{
		GameObject obj = this.target as GameObject;
		ModelPoolManager.Instance.RemoveObject(obj);
		UnityEngine.Object.Destroy(obj);
	}

	public void SetParent(Transform parent, bool worldPositionStays = false)
	{
		GameObject gameObject = this.target as GameObject;
		if (gameObject == null)
		{
			return;
		}
		gameObject.transform.SetParent(parent, worldPositionStays);
	}

	public void SetActive(bool active)
	{
		if (this.GameObject != null)
		{
			this.GameObject.SetActive(active);
		}
	}

	public void OnSpawn()
	{
		if (!this.GameObject.activeInHierarchy)
		{
			this.GameObject.SetActive(true);
		}
		this.transform.localPosition = Vector3.zero;
		this.transform.localRotation = Quaternion.identity;
	}

	public void OnUnSpawn()
	{
		if (this.GameObject.activeInHierarchy)
		{
			this.GameObject.SetActive(false);
		}
	}
}
