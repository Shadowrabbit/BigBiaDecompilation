using System;
using UnityEngine;

public class InvaliBuildButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		GameController.getInstance().CreateSubtitle("你必须先拥有这处房产", 1f, 2f, 1f, 1f);
	}
}
