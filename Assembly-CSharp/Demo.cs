using System;
using System.Collections;
using UnityEngine;

public class Demo : MonoBehaviour
{
	private IEnumerator Start()
	{
		Coroutine<int> routine = GlobalController.Instance.StartCoroutine(this.TestNewRoutineGivesException());
		yield return routine.coroutine;
		try
		{
			int result = routine.Result;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
		}
		Debug.Log("Continue------------------------->");
		yield break;
	}

	private IEnumerator TestNewRoutineGivesException()
	{
		yield return null;
		Debug.LogError("test erro!");
		yield return new WaitForSeconds(2f);
		throw new Exception("Bad thing!");
		yield break;
	}
}
