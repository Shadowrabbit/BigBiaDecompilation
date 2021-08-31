using System;
using UnityEngine;

public class TestThisBase
{
	public virtual void ShowNumb()
	{
		this.Numb = 0;
		Debug.Log("###########Test This :" + this.Numb.ToString());
	}

	public int Numb;
}
