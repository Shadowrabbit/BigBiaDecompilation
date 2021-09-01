using System;
using UnityEngine;

public class Altar : MonoBehaviour
{
	private void Awake()
	{
		Altar.Instance = this;
	}

	private void Start()
	{
		this.lastSacrifice = this.sacrificeData.val;
	}

	private void Update()
	{
	}

	public static Altar Instance;

	public SacrificeData sacrificeData;

	private int lastSacrifice;
}
