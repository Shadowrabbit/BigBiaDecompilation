using System;
using UnityEngine;

public class RingShotCommonTool : MonoBehaviour
{
	private void Start()
	{
		this.isGot = false;
		this.effect = base.GetComponentInChildren<ParticleSystem>();
		float x = UnityEngine.Random.Range(-0.5f, 0.5f);
		float z = UnityEngine.Random.Range(-0.5f, 0.5f);
		base.transform.Translate(x, base.transform.position.y, z);
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!this.isGot && other.gameObject.name == "RingTrigger")
		{
			this.isGot = true;
			this.effect.Play();
			this.RingShotSpecialToy.NeedStay = true;
			this.RingShotSpecialToy.gotNum++;
			DungeonOperationMgr.Instance.ChangeMoney(20);
		}
	}

	public RingShotSpecialToy RingShotSpecialToy;

	private bool isGot;

	private ParticleSystem effect;
}
