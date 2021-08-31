using System;
using System.Collections;
using System.Collections.Generic;

public class DayRoomAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
		foreach (KeyValuePair<CardSlotData, ParticleObject> keyValuePair in this.m_Particles)
		{
			ParticlePoolManager.Instance.UnSpawn(keyValuePair.Value);
		}
		UIController.LockLevel = this.m_Lock;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			cardSlotData.CardSlotGameObject.SetIcon(1);
			cardSlotData.CardSlotGameObject.SetBorder(1);
			cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
			cardSlotData.TagWhiteList = 128UL;
		}
		this.m_Particles = new Dictionary<CardSlotData, ParticleObject>();
		for (int i = 0; i < base.Data.CardSlotDatas.Count; i++)
		{
			if (base.Data.CardSlotDatas[i].ChildCardData != null && base.Data.CardSlotDatas[i].ChildCardData.ModID != null)
			{
				if (base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[0])
				{
					ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject.transform.position = base.Data.CardSlotDatas[i].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[0], particleObject);
					i = 1;
				}
				else if (base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[1] || base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[2])
				{
					if (base.Data.CardSlotDatas[1].ChildCardData != null && base.Data.CardSlotDatas[2].ChildCardData != null)
					{
						ParticleObject particleObject2 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
						particleObject2.transform.position = base.Data.CardSlotDatas[1].CardSlotGameObject.transform.position;
						this.m_Particles.Add(base.Data.CardSlotDatas[1], particleObject2);
						ParticleObject particleObject3 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
						particleObject3.transform.position = base.Data.CardSlotDatas[2].CardSlotGameObject.transform.position;
						this.m_Particles.Add(base.Data.CardSlotDatas[2], particleObject3);
						i = 3;
					}
				}
				else if ((base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[3] || base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[4] || base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[5]) && base.Data.CardSlotDatas[3].ChildCardData != null && base.Data.CardSlotDatas[4].ChildCardData != null && base.Data.CardSlotDatas[5].ChildCardData != null)
				{
					ParticleObject particleObject4 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject4.transform.position = base.Data.CardSlotDatas[3].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[3], particleObject4);
					ParticleObject particleObject5 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject5.transform.position = base.Data.CardSlotDatas[4].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[4], particleObject5);
					ParticleObject particleObject6 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject6.transform.position = base.Data.CardSlotDatas[5].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[5], particleObject6);
					i = 5;
				}
			}
		}
		yield break;
	}

	public override void OnDayPass()
	{
		for (int i = 0; i < base.Data.CardSlotDatas.Count; i++)
		{
			if (base.Data.CardSlotDatas[i].ChildCardData != null && base.Data.CardSlotDatas[i].ChildCardData.ModID != null)
			{
				if (base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[0])
				{
					if (base.Data.CardSlotDatas[i].ChildCardData.UnHappy > 0)
					{
						base.Data.CardSlotDatas[i].ChildCardData.UnHappy = ((base.Data.CardSlotDatas[i].ChildCardData.UnHappy - 70 > 0) ? base.Data.CardSlotDatas[i].ChildCardData.UnHappy : 0);
					}
					i = 1;
				}
				else if (base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[1] || base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[2])
				{
					if (base.Data.CardSlotDatas[1].ChildCardData != null && base.Data.CardSlotDatas[2].ChildCardData != null)
					{
						if (base.Data.CardSlotDatas[1].ChildCardData.UnHappy > 0)
						{
							base.Data.CardSlotDatas[1].ChildCardData.UnHappy = ((base.Data.CardSlotDatas[1].ChildCardData.UnHappy - 70 > 0) ? base.Data.CardSlotDatas[1].ChildCardData.UnHappy : 0);
						}
						if (base.Data.CardSlotDatas[2].ChildCardData.UnHappy > 0)
						{
							base.Data.CardSlotDatas[2].ChildCardData.UnHappy = ((base.Data.CardSlotDatas[2].ChildCardData.UnHappy - 70 > 0) ? base.Data.CardSlotDatas[2].ChildCardData.UnHappy : 0);
						}
						i = 3;
					}
				}
				else if ((base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[3] || base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[4] || base.Data.CardSlotDatas[i] == base.Data.CardSlotDatas[5]) && base.Data.CardSlotDatas[3].ChildCardData != null && base.Data.CardSlotDatas[4].ChildCardData != null && base.Data.CardSlotDatas[5].ChildCardData != null)
				{
					if (base.Data.CardSlotDatas[3].ChildCardData.UnHappy > 0)
					{
						base.Data.CardSlotDatas[3].ChildCardData.UnHappy = ((base.Data.CardSlotDatas[3].ChildCardData.UnHappy - 70 > 0) ? base.Data.CardSlotDatas[3].ChildCardData.UnHappy : 0);
					}
					if (base.Data.CardSlotDatas[4].ChildCardData.UnHappy > 0)
					{
						base.Data.CardSlotDatas[4].ChildCardData.UnHappy = ((base.Data.CardSlotDatas[4].ChildCardData.UnHappy - 70 > 0) ? base.Data.CardSlotDatas[4].ChildCardData.UnHappy : 0);
					}
					if (base.Data.CardSlotDatas[5].ChildCardData.UnHappy > 0)
					{
						base.Data.CardSlotDatas[5].ChildCardData.UnHappy = ((base.Data.CardSlotDatas[5].ChildCardData.UnHappy - 70 > 0) ? base.Data.CardSlotDatas[5].ChildCardData.UnHappy : 0);
					}
					i = 5;
				}
			}
		}
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			if (newCardSlot == base.Data.CardSlotDatas[0])
			{
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject.transform.position = newCardSlot.CardSlotGameObject.transform.position;
				this.m_Particles.Add(newCardSlot, particleObject);
			}
			else if (newCardSlot == base.Data.CardSlotDatas[1] || newCardSlot == base.Data.CardSlotDatas[2])
			{
				if (base.Data.CardSlotDatas[1].ChildCardData != null && base.Data.CardSlotDatas[2].ChildCardData != null)
				{
					ParticleObject particleObject2 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject2.transform.position = base.Data.CardSlotDatas[1].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[1], particleObject2);
					ParticleObject particleObject3 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject3.transform.position = base.Data.CardSlotDatas[2].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[2], particleObject3);
				}
			}
			else if ((newCardSlot == base.Data.CardSlotDatas[3] || newCardSlot == base.Data.CardSlotDatas[4] || newCardSlot == base.Data.CardSlotDatas[5]) && base.Data.CardSlotDatas[3].ChildCardData != null && base.Data.CardSlotDatas[4].ChildCardData != null && base.Data.CardSlotDatas[5].ChildCardData != null)
			{
				ParticleObject particleObject4 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject4.transform.position = base.Data.CardSlotDatas[3].CardSlotGameObject.transform.position;
				this.m_Particles.Add(base.Data.CardSlotDatas[3], particleObject4);
				ParticleObject particleObject5 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject5.transform.position = base.Data.CardSlotDatas[4].CardSlotGameObject.transform.position;
				this.m_Particles.Add(base.Data.CardSlotDatas[4], particleObject5);
				ParticleObject particleObject6 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject6.transform.position = base.Data.CardSlotDatas[5].CardSlotGameObject.transform.position;
				this.m_Particles.Add(base.Data.CardSlotDatas[5], particleObject6);
			}
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
		{
			List<CardSlotData> list = new List<CardSlotData>();
			List<ParticleObject> list2 = new List<ParticleObject>();
			List<CardSlotData> list3 = new List<CardSlotData>();
			if (oldCardSlot == base.Data.CardSlotDatas[0])
			{
				list3.Add(base.Data.CardSlotDatas[0]);
			}
			else if (oldCardSlot == base.Data.CardSlotDatas[1] || oldCardSlot == base.Data.CardSlotDatas[2])
			{
				list3.Add(base.Data.CardSlotDatas[1]);
				list3.Add(base.Data.CardSlotDatas[2]);
			}
			else if (oldCardSlot == base.Data.CardSlotDatas[3] || oldCardSlot == base.Data.CardSlotDatas[4] || oldCardSlot == base.Data.CardSlotDatas[5])
			{
				list3.Add(base.Data.CardSlotDatas[3]);
				list3.Add(base.Data.CardSlotDatas[4]);
				list3.Add(base.Data.CardSlotDatas[5]);
			}
			foreach (CardSlotData cardSlotData in list3)
			{
				foreach (KeyValuePair<CardSlotData, ParticleObject> keyValuePair in this.m_Particles)
				{
					if (keyValuePair.Key == cardSlotData)
					{
						list.Add(keyValuePair.Key);
						list2.Add(keyValuePair.Value);
						break;
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (ParticleObject particle in list2)
				{
					ParticlePoolManager.Instance.UnSpawn(particle);
				}
			}
			if (list.Count > 0)
			{
				foreach (CardSlotData key in list)
				{
					this.m_Particles.Remove(key);
				}
			}
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			if (newCardSlot == base.Data.CardSlotDatas[0])
			{
				ParticleObject particleObject7 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject7.transform.position = newCardSlot.CardSlotGameObject.transform.position;
				this.m_Particles.Add(newCardSlot, particleObject7);
			}
			else if (newCardSlot == base.Data.CardSlotDatas[1] || newCardSlot == base.Data.CardSlotDatas[2])
			{
				if (base.Data.CardSlotDatas[1].ChildCardData != null && base.Data.CardSlotDatas[2].ChildCardData != null)
				{
					ParticleObject particleObject8 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject8.transform.position = base.Data.CardSlotDatas[1].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[1], particleObject8);
					ParticleObject particleObject9 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
					particleObject9.transform.position = base.Data.CardSlotDatas[2].CardSlotGameObject.transform.position;
					this.m_Particles.Add(base.Data.CardSlotDatas[2], particleObject9);
				}
			}
			else if ((newCardSlot == base.Data.CardSlotDatas[3] || newCardSlot == base.Data.CardSlotDatas[4] || newCardSlot == base.Data.CardSlotDatas[5]) && base.Data.CardSlotDatas[3].ChildCardData != null && base.Data.CardSlotDatas[4].ChildCardData != null && base.Data.CardSlotDatas[5].ChildCardData != null)
			{
				ParticleObject particleObject10 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject10.transform.position = base.Data.CardSlotDatas[3].CardSlotGameObject.transform.position;
				this.m_Particles.Add(base.Data.CardSlotDatas[3], particleObject10);
				ParticleObject particleObject11 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject11.transform.position = base.Data.CardSlotDatas[4].CardSlotGameObject.transform.position;
				this.m_Particles.Add(base.Data.CardSlotDatas[4], particleObject11);
				ParticleObject particleObject12 = ParticlePoolManager.Instance.Spawn("Effect/HealHappyLoop", 2.1474836E+09f);
				particleObject12.transform.position = base.Data.CardSlotDatas[5].CardSlotGameObject.transform.position;
				this.m_Particles.Add(base.Data.CardSlotDatas[5], particleObject12);
			}
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			List<CardSlotData> list4 = new List<CardSlotData>();
			List<ParticleObject> list5 = new List<ParticleObject>();
			List<CardSlotData> list6 = new List<CardSlotData>();
			if (oldCardSlot == base.Data.CardSlotDatas[0])
			{
				list6.Add(base.Data.CardSlotDatas[0]);
			}
			else if (oldCardSlot == base.Data.CardSlotDatas[1] || oldCardSlot == base.Data.CardSlotDatas[2])
			{
				list6.Add(base.Data.CardSlotDatas[1]);
				list6.Add(base.Data.CardSlotDatas[2]);
			}
			else if (oldCardSlot == base.Data.CardSlotDatas[3] || oldCardSlot == base.Data.CardSlotDatas[4] || oldCardSlot == base.Data.CardSlotDatas[5])
			{
				list6.Add(base.Data.CardSlotDatas[3]);
				list6.Add(base.Data.CardSlotDatas[4]);
				list6.Add(base.Data.CardSlotDatas[5]);
			}
			foreach (CardSlotData cardSlotData2 in list6)
			{
				foreach (KeyValuePair<CardSlotData, ParticleObject> keyValuePair2 in this.m_Particles)
				{
					if (keyValuePair2.Key == cardSlotData2)
					{
						list4.Add(keyValuePair2.Key);
						list5.Add(keyValuePair2.Value);
						break;
					}
				}
			}
			if (list5.Count > 0)
			{
				foreach (ParticleObject particle2 in list5)
				{
					ParticlePoolManager.Instance.UnSpawn(particle2);
				}
			}
			if (list4.Count > 0)
			{
				foreach (CardSlotData key2 in list4)
				{
					this.m_Particles.Remove(key2);
				}
			}
		}
	}

	private Dictionary<CardSlotData, ParticleObject> m_Particles;

	private UIController.UILevel m_Lock = UIController.UILevel.All;
}
