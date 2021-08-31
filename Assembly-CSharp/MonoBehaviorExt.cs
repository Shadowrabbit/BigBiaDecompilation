using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviorExt
{
	public static Coroutine<T> StartCoroutine<T>(this MonoBehaviour obj, IEnumerator coroutine)
	{
		Coroutine<T> coroutine2 = new Coroutine<T>();
		coroutine2.coroutine = obj.StartCoroutine(coroutine2.InternalRoutine(coroutine));
		return coroutine2;
	}
}
