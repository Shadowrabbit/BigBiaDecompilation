using System;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{
	private void Start()
	{
		Main.getInstance().Producers.Add(this);
	}

	private void Update()
	{
		if (this.cooling)
		{
			this.ResidualCD -= 1f;
			this.ResidualAll -= 1f;
			if (this.ResidualCD <= 0f)
			{
				this.cooling = false;
				return;
			}
		}
		else if (this.curConsumers.Count > 0)
		{
			this.EnergyGo(this.curConsumers[0]);
		}
	}

	public float GetArrivalTime(Consumer c)
	{
		return this.ResidualAll + Vector3.Distance(base.transform.position, c.transform.position) * 100f;
	}

	public void EnergySupply(Consumer c)
	{
		this.curConsumers.Add(c);
		this.ResidualAll += this.CD;
	}

	private void EnergyGo(Consumer c)
	{
		UnityEngine.Object.Instantiate<GameObject>(this.Energy, base.transform.position, base.transform.rotation).GetComponent<Energy>().init(c.transform);
		c.requestable = true;
		this.cool();
		this.curConsumers.Remove(c);
	}

	private void cool()
	{
		this.cooling = true;
		this.ResidualCD = this.CD;
	}

	public void ListClear()
	{
		foreach (Consumer consumer in this.curConsumers)
		{
			consumer.willGet--;
		}
		this.curConsumers.Clear();
	}

	private float CD = 60f;

	private float ResidualCD;

	private float ResidualAll;

	private bool cooling;

	private int i;

	public List<Consumer> curConsumers;

	public GameObject Energy;
}
