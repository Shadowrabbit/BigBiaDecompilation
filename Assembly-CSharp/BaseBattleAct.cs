using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseBattleAct : GameAct
{
	private void Start()
	{
		this.Init();
	}

	public override void Init()
	{
		base.Init();
		this.AliveRoles = new List<Card>();
		this.AllCardSlot = new CardSlot[6, 6];
		for (int i = 0; i < 6; i++)
		{
			List<CardSlot> list = new List<CardSlot>();
			base.InitCardSlotOnActTable(this.SlotTrans, new Vector3(1.3f, 0f, 0f), 6, false, null, list, null);
			for (int j = 0; j < 6; j++)
			{
				this.AllCardSlot[i, j] = list[j];
				if (i < 4)
				{
					list[j].CardSlotData.TagWhiteList = 1UL;
				}
				else
				{
					list[j].CardSlotData.TagWhiteList = 144UL;
				}
				list[j].CardSlotData.SlotType = CardSlotData.Type.Normal;
			}
			this.SlotTrans.position += new Vector3(0f, 0f, -1.3f);
		}
	}

	private bool m_IsSimulate;

	private int m_SimulationTimes;

	private Dictionary<string, int> m_DamageDealtRecord = new Dictionary<string, int>();

	public CardSlot[,] AllCardSlot;

	public List<Card> AliveRoles;

	public Transform SlotTrans;
}
