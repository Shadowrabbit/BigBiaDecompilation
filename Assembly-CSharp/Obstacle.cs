using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
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
			if (this.noBoundarySpecialToy.Gold >= 10)
			{
				this.noBoundarySpecialToy.Gold -= 10;
				return;
			}
			this.noBoundarySpecialToy.Gold = 0;
		}
	}

	public NoBoundarySpecialToy noBoundarySpecialToy;
}
