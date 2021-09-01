using System;
using System.Collections;
using UnityEngine;

public class Coroutine<T>
{
	public T Result
	{
		get
		{
			if (this.e != null)
			{
				throw this.e;
			}
			return this.result;
		}
	}

	public IEnumerator InternalRoutine(IEnumerator coroutine)
	{
		object obj;
		for (;;)
		{
			try
			{
				if (!coroutine.MoveNext())
				{
					yield break;
				}
			}
			catch (Exception ex)
			{
				this.e = ex;
				yield break;
			}
			obj = coroutine.Current;
			if (obj != null && obj.GetType() == typeof(T))
			{
				break;
			}
			yield return coroutine.Current;
		}
		this.result = (T)((object)obj);
		yield break;
		yield break;
	}

	private T result;

	private Exception e;

	public Coroutine coroutine;
}
