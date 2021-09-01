using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureManager : MonoBehaviour
{
	private void Awake()
	{
		NatureManager.Instance = this;
	}

	public void RegisterMinion(CardData minion)
	{
		this.m_AllNatureMinions.Add(minion);
	}

	public void UnRegisterMinion(CardData minion)
	{
		this.m_AllNatureMinions.Remove(minion);
	}

	public IEnumerator StartNatureEvent()
	{
		yield break;
	}

	public static NatureManager Instance;

	private List<CardData> m_AllNatureMinions = new List<CardData>();
}
