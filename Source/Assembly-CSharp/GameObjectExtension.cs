using System;
using UnityEngine;

public static class GameObjectExtension
{
	public static T AddOrGetComponent<T>(this GameObject obj) where T : Component
	{
		T t = obj.GetComponent<T>();
		if (t == null)
		{
			t = obj.AddComponent<T>();
		}
		return t;
	}
}
