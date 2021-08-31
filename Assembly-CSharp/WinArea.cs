using System;
using UnityEngine;

public class WinArea : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Ball")
		{
			this.noBoundarySpecialToy.OnGameWin();
		}
	}

	public NoBoundarySpecialToy noBoundarySpecialToy;
}
