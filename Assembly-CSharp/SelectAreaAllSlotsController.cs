using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectAreaAllSlotsController : MonoBehaviour
{
	private void OnDestroy()
	{
		this.AllMinionSlots.Clear();
		this.AllItemSlots.Clear();
		this.AllMagicSlots.Clear();
	}

	public List<CardSlot> AllMinionSlots = new List<CardSlot>();

	public List<CardSlot> AllItemSlots = new List<CardSlot>();

	public List<CardSlot> AllMagicSlots = new List<CardSlot>();
}
