using System;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
	private void Awake()
	{
		Application.targetFrameRate = this.TargetFrame;
	}

	public int TargetFrame = 60;
}
