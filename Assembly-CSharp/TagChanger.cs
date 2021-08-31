using System;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
	public void PlayerTagChanger()
	{
		base.tag = "Player";
	}

	public void UntaggedTagChanger()
	{
		base.tag = "Untagged";
	}
}
