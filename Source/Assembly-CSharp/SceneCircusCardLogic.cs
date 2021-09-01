using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCircusCardLogic : CardLogic
{
	~SceneCircusCardLogic()
	{
	}

	public override void Init()
	{
		base.Init();
	}

	private new void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public override IEnumerator OnBattleStart()
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		GameEventManager gameEventManager2 = GameController.ins.GameEventManager;
		gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		this.dic.Clear();
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (this.IconDic.ContainsKey(target))
		{
			ModelPoolManager.Instance.UnSpawnModel(this.IconDic[target]);
			this.IconDic.Remove(target);
		}
		yield break;
	}

	private void RefreshIcons()
	{
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.CardGameObject != null)
			{
				if (this.dic.ContainsKey(cardSlotData.ChildCardData) && this.dic[cardSlotData.ChildCardData] == cardSlotData)
				{
					if (!this.IconDic.ContainsKey(cardSlotData.ChildCardData))
					{
						DisplayModel displayModel = ModelPoolManager.Instance.SpawnModel("UI/Texture/待在原地");
						displayModel.SetParent(cardSlotData.ChildCardData.CardGameObject.transform, false);
						displayModel.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
						this.IconDic.Add(cardSlotData.ChildCardData, displayModel);
					}
				}
				else if (this.IconDic.ContainsKey(cardSlotData.ChildCardData))
				{
					ModelPoolManager.Instance.UnSpawnModel(this.IconDic[cardSlotData.ChildCardData]);
					this.IconDic.Remove(cardSlotData.ChildCardData);
				}
			}
		}
	}

	private void OnCardPutInSlot(CardSlotData arg1, CardData arg2)
	{
		if (arg2.HasTag(TagMap.随从) || arg2.HasTag(TagMap.怪物) || arg2.HasTag(TagMap.衍生物))
		{
			this.RefreshIcons();
		}
	}

	public override IEnumerator OnBattleEnd()
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		foreach (KeyValuePair<CardData, DisplayModel> keyValuePair in this.IconDic)
		{
			ModelPoolManager.Instance.UnSpawnModel(keyValuePair.Value);
		}
		this.IconDic.Clear();
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.RefreshIcons();
		this.flag = false;
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMinions.Count == 0 || allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMinions)
			{
				if (this.dic.ContainsKey(cardData))
				{
					if (cardData.CurrentCardSlotData == this.dic[cardData])
					{
						this.flag = true;
						this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), cardData.CardGameObject.transform.position, 1);
						DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, -Mathf.CeilToInt((float)cardData.MaxHP * this.dmg), null, false, 0, true, false));
					}
					this.dic[cardData] = cardData.CurrentCardSlotData;
				}
				else
				{
					this.dic.Add(cardData, cardData.CurrentCardSlotData);
				}
			}
			foreach (CardData cardData2 in allCurrentMonsters)
			{
				if (this.dic.ContainsKey(cardData2))
				{
					if (cardData2.CurrentCardSlotData == this.dic[cardData2])
					{
						this.flag = true;
						this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), cardData2.CardGameObject.transform.position, 1);
						DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData2, -Mathf.CeilToInt((float)cardData2.MaxHP * this.dmg), null, false, 0, true, false));
					}
					this.dic[cardData2] = cardData2.CurrentCardSlotData;
				}
				else
				{
					this.dic.Add(cardData2, cardData2.CurrentCardSlotData);
				}
			}
			if (this.flag)
			{
				yield return GameController.ins.UIController.TabooUIPunchEffect();
			}
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		int num = 0;
		Vector3Int needEnergyCount = origin.NeedEnergyCount;
		if (origin.NeedEnergyCount.x > 0)
		{
			num++;
		}
		if (origin.NeedEnergyCount.y > 0)
		{
			num++;
		}
		if (origin.NeedEnergyCount.z > 0)
		{
			num++;
		}
		if (num > 0)
		{
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in allCurrentMinions)
			{
				if (cardData != user)
				{
					list.Add(cardData);
				}
			}
			if (list.Count > 0)
			{
				CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
				DungeonOperationMgr.Instance.StartCoroutine(base.wATKUp(new Vector3(-8.7f, 0f, 8f), Mathf.CeilToInt((float)cardData2.ATK * this.buff * (float)num), cardData2));
			}
		}
		yield break;
	}

	private float dmg = 0.2f;

	private float buff = 0.2f;

	private bool flag;

	private Dictionary<CardData, CardSlotData> dic = new Dictionary<CardData, CardSlotData>();

	private Dictionary<CardData, DisplayModel> IconDic = new Dictionary<CardData, DisplayModel>();
}
