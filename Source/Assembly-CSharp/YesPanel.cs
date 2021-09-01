using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YesPanel : MonoBehaviour
{
	public IEnumerator StartChoosing()
	{
		base.transform.gameObject.SetActive(true);
		YesPanel.InChoosing = true;
		while (YesPanel.InChoosing)
		{
			yield return null;
		}
		base.transform.gameObject.SetActive(false);
		yield break;
	}

	public void OnYes()
	{
		YesPanel.InChoosing = false;
		YesPanel.Result = true;
	}

	public static bool InChoosing;

	public static bool Result;

	public Text MainText;
}
