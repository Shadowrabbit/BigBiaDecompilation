using System;
using UnityEngine;

public class UnLockItemBean
{
	public UnLockItemBean(CardData data, Transform trans)
	{
		this.Data = data;
		this.Trans = trans;
	}

	public CardData Data;

	public Transform Trans;
}
