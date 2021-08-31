using System;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public static Main getInstance()
	{
		return Main.ins;
	}

	private void Awake()
	{
		this.Producers = new List<Producer>();
		this.Consumers = new List<Consumer>();
		Main.ins = this;
	}

	private void Update()
	{
	}

	public static Main ins;

	public List<Producer> Producers;

	public List<Consumer> Consumers;
}
