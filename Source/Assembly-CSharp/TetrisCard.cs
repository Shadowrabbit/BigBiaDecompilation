using System;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCard : MonoBehaviour
{
	private void Start()
	{
		Card componentInParent = base.GetComponentInParent<Card>();
		if (componentInParent != null && componentInParent.CardData != null && componentInParent.CardData.Attrs.ContainsKey("TetrisCardLogic_BlockValue"))
		{
			this.SetBlock(componentInParent.CardData.Attrs["TetrisCardLogic_BlockValue"] as List<bool>);
		}
	}

	private void OnEnable()
	{
		Card componentInParent = base.GetComponentInParent<Card>();
		if (componentInParent != null && componentInParent.CardData != null && componentInParent.CardData.Attrs.ContainsKey("TetrisCardLogic_BlockValue"))
		{
			this.SetBlock(componentInParent.CardData.Attrs["TetrisCardLogic_BlockValue"] as List<bool>);
		}
	}

	public void SetBlock(List<bool> blockValue)
	{
		int num = 0;
		while (num < blockValue.Count && num < this.BlockList.Count)
		{
			this.BlockList[num].SetActive(blockValue[num]);
			num++;
		}
	}

	public List<GameObject> BlockList;
}
