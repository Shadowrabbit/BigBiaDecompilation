using System;
using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Rigidbody>().velocity.y < 0f)
		{
			this.BasketballSpecialToy.OnGetPoint();
		}
	}

	public BasketballSpecialToy BasketballSpecialToy;
}
