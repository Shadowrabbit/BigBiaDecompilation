using System;
using PixelGame;
using UnityEngine;

public class ObjectPoolComponent : MonoBehaviour
{
	private void Awake()
	{
		ObjectPoolComponent.Instance = this;
		this.ObjectPoolManager = new ObjectPoolManager(this.ObjectPoolCapacity, this.ExpireTile, this.AutoReleaseTime);
	}

	private void Update()
	{
		this.ObjectPoolManager.Update(Time.deltaTime);
	}

	private void OnDestroy()
	{
		this.ObjectPoolManager = null;
	}

	public static ObjectPoolComponent Instance;

	public IObjectPoolManager ObjectPoolManager;

	public int ObjectPoolCapacity = int.MaxValue;

	public int ExpireTile = int.MaxValue;

	public int AutoReleaseTime = 60;
}
