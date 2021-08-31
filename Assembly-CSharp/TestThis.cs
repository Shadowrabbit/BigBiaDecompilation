using System;
using UnityEngine;

public class TestThis : TestThisBase
{
	public override void ShowNumb()
	{
		this.Numb = 5;
		Debug.Log("###########Test This :" + this.Numb.ToString());
	}
}
