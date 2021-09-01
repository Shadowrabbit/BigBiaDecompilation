using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YesOrNoPanel : MonoBehaviour
{
	public IEnumerator StartChoosing()
	{
		base.transform.gameObject.SetActive(true);
		YesOrNoPanel.InChoosing = true;
		while (YesOrNoPanel.InChoosing)
		{
			yield return null;
		}
		base.transform.gameObject.SetActive(false);
		yield break;
	}

	public void OnYes()
	{
		YesOrNoPanel.InChoosing = false;
		YesOrNoPanel.Result = true;
	}

	public void OnNo()
	{
		YesOrNoPanel.InChoosing = false;
		YesOrNoPanel.Result = false;
	}

	public static bool InChoosing;

	public static bool Result;

	public Text MainText;
}
