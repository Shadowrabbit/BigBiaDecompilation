using System;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
	private void Start()
	{
		Main.getInstance().Consumers.Add(this);
	}

	private void GetReady()
	{
		this.willGet = 1;
	}

	private void OnMouseDown()
	{
		if (this.now == this.need)
		{
			this.now = 0;
			this.willGet = 0;
		}
		foreach (Producer producer in Main.getInstance().Producers)
		{
			producer.ListClear();
		}
	}

	private void Update()
	{
		base.GetComponentInChildren<TextMesh>().text = this.now.ToString() + "/" + this.need.ToString();
		if (this.willGet < this.need)
		{
			float num = float.MaxValue;
			List<Producer> producers = Main.getInstance().Producers;
			Producer producer = null;
			for (int i = 0; i < producers.Count; i++)
			{
				float arrivalTime = producers[i].GetArrivalTime(this);
				if (arrivalTime < num)
				{
					num = arrivalTime;
					producer = producers[i];
				}
			}
			if (producer != null)
			{
				producer.EnergySupply(this);
				this.willGet++;
			}
		}
	}

	public int need = 10;

	public int now;

	public int willGet;

	public bool requestable = true;
}
