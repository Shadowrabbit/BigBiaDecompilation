using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json;
using UnityEngine;

public class CardLogic
{
	[JsonIgnore]
	public int Layers
	{
		get
		{
			return this.layers;
		}
		set
		{
			if (GameController.getInstance() != null && this.CardData != null && this.CardData.CardGameObject != null)
			{
				GameController.getInstance().ShowLogicChanged(this.CardData.CardGameObject.transform.position, this.displayName + ((value - this.layers > 0) ? ("+" + (value - this.layers).ToString()) : (value - this.layers).ToString()), this.Color);
			}
			this.layers = value;
		}
	}

	public void SetNeedEnergyCount(int blue, int red, int yellow)
	{
		this.NeedEnergyCount = new Vector3Int(blue, red, yellow);
	}

	[JsonIgnore]
	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public virtual void Init()
	{
	}

	public void ShowMe()
	{
		if (this.CardData != null && this.CardData.CardGameObject != null)
		{
			GameController.getInstance().ShowLogicChanged(this.CardData.CardGameObject.transform.position, this.displayName, this.Color);
		}
	}

	public IEnumerator ShowXuLiEffect(string effectName, bool hold = false)
	{
		ParticleObject particleObject;
		if (hold)
		{
			particleObject = ParticlePoolManager.Instance.Spawn("Effect/" + effectName, float.MaxValue);
			this.XuliEffect = particleObject;
		}
		else
		{
			particleObject = ParticlePoolManager.Instance.Spawn("Effect/" + effectName, 1f);
		}
		particleObject.transform.position = this.CardData.CardGameObject.transform.position;
		yield return new WaitForSeconds(1f);
		yield break;
	}

	public IEnumerator ShowCustomEffect(string effectName, CardSlotData target, float time)
	{
		ParticlePoolManager.Instance.Spawn("Effect/" + effectName, time).transform.position = target.CardSlotGameObject.transform.position;
		yield return new WaitForSeconds(time);
		yield break;
	}

	public void ShowLogic(string s)
	{
		if (this.CardData != null && this.CardData.CardGameObject != null)
		{
			GameController.getInstance().ShowLogicChanged(this.CardData.CardGameObject.transform.position, s, this.Color);
		}
	}

	public void Show(string s, CardData cd)
	{
		if (cd != null && cd.CardGameObject != null)
		{
			GameController.getInstance().ShowLogicChanged(cd.CardGameObject.transform.position, s, this.Color);
		}
	}

	public virtual void OnShowTips()
	{
	}

	public IEnumerator ShowMePlus(string text = null)
	{
		if (this.CardData != null && this.CardData.CardGameObject != null)
		{
			UIController.UILevel myLock = UIController.LockLevel;
			UIController.LockLevel = UIController.UILevel.All;
			int intensity = 1;
			GameController.ins.UIController.MainLight.DOIntensity(0.5f, 0.2f);
			GameController.ins.UIController.SpotLightController.ShowSpotLight(this.CardData.CardGameObject.transform.position);
			if (text != null)
			{
				GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, text, UnityEngine.Color.white, 0, false, true);
			}
			else
			{
				GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, this.displayName, UnityEngine.Color.white, 0, false, true);
			}
			bool isClick = false;
			while (!isClick)
			{
				yield return 1;
				if (Input.GetMouseButtonDown(0))
				{
					isClick = true;
				}
			}
			GameController.ins.UIController.SpotLightController.HideSpotLight();
			yield return GameController.ins.UIController.MainLight.DOIntensity((float)intensity, 0.2f).WaitForCompletion();
			yield return new WaitForSeconds(1f);
			UIController.LockLevel = myLock;
		}
		yield break;
	}

	public virtual IEnumerator Terminate(CardSlotData cardSlotData)
	{
		yield break;
	}

	public virtual void OnGameObjectInit()
	{
	}

	public virtual void OnLeftClick(List<Vector2[]> res)
	{
	}

	public virtual void OnRightClick(List<Vector2[]> res)
	{
	}

	public virtual bool OnUse(List<Vector2[]> res)
	{
		return false;
	}

	public virtual void OnCalcelUse()
	{
	}

	public virtual void OnDayPass()
	{
	}

	public virtual void OnPlayerExitArea()
	{
	}

	public virtual void OnActEnd()
	{
	}

	public static int GetRowInBattleArea(CardData CardData)
	{
		List<CardSlotData> list = null;
		if (CardData.HasTag(TagMap.BOSS))
		{
			list = DungeonOperationMgr.Instance.BattleArea;
		}
		if (DungeonOperationMgr.Instance != null)
		{
			if (DungeonOperationMgr.Instance.PlayerBattleArea != null && DungeonOperationMgr.Instance.PlayerBattleArea.Contains(CardData.CurrentCardSlotData))
			{
				list = DungeonOperationMgr.Instance.PlayerBattleArea;
			}
			else if (DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.BattleArea.Contains(CardData.CurrentCardSlotData))
			{
				list = DungeonOperationMgr.Instance.BattleArea;
			}
		}
		if (list == null)
		{
			return -1;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == CardData.CurrentCardSlotData)
			{
				return i / 3;
			}
		}
		return -1;
	}

	public static int GetColInBattleArea(CardData CardData)
	{
		List<CardSlotData> list = null;
		if (CardData.HasTag(TagMap.BOSS))
		{
			list = DungeonOperationMgr.Instance.BattleArea;
		}
		if (DungeonOperationMgr.Instance != null)
		{
			if (DungeonOperationMgr.Instance.PlayerBattleArea != null && DungeonOperationMgr.Instance.PlayerBattleArea.Contains(CardData.CurrentCardSlotData))
			{
				list = DungeonOperationMgr.Instance.PlayerBattleArea;
			}
			else if (DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.BattleArea.Contains(CardData.CurrentCardSlotData))
			{
				list = DungeonOperationMgr.Instance.BattleArea;
			}
		}
		if (list == null)
		{
			return -1;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == CardData.CurrentCardSlotData)
			{
				return i % 3;
			}
		}
		return -1;
	}

	public virtual int GetATKBonus()
	{
		return 0;
	}

	public CardSlot FindClosestTargetInRange(CardSlot[,] CardSlots, Card Actor, CardLogic.MyPoint Mp)
	{
		CardSlot result = null;
		int num = 12;
		for (int i = 0; i < CardSlots.GetLength(0); i++)
		{
			for (int j = 0; j < CardSlots.GetLength(1); j++)
			{
				if (CardSlots[i, j].ChildCard != null && (bool)CardSlots[i, j].ChildCard.CardData.HiddenAttrs["IsEnemy"] != (bool)Actor.CardData.HiddenAttrs["IsEnemy"])
				{
					int num2 = Math.Abs(i - Mp.X) + Math.Abs(j - Mp.Y);
					if (num2 <= num)
					{
						num = num2;
						if (num <= Actor.CardData.ATKRange)
						{
							result = CardSlots[i, j];
						}
					}
				}
			}
		}
		return result;
	}

	public virtual float GetSkillDmg()
	{
		return 0f;
	}

	public virtual IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield break;
	}

	public virtual List<ExtraAttackData> GetExtraAttackDatas(CardData center, CardData attackCard)
	{
		return null;
	}

	public virtual void OnKillEnemy(CardData cardData)
	{
	}

	public virtual List<Vector2Int> GetSkillScope()
	{
		return null;
	}

	public virtual IEnumerator CustomAttack(CardSlotData target)
	{
		yield break;
	}

	public virtual IEnumerator OnTurnStart()
	{
		yield break;
	}

	public virtual IEnumerator OnAttackEffect(CardData origin, CardData target)
	{
		yield break;
	}

	public virtual IEnumerator OnMpChange(CardData player, int changedValue)
	{
		yield break;
	}

	public virtual IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		yield break;
	}

	public virtual IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		yield break;
	}

	public virtual void OnBeforeUseMagic(CardData player)
	{
	}

	public virtual void OnAfterUseMagic(CardData player)
	{
	}

	public virtual IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		yield break;
	}

	public virtual IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		yield break;
	}

	public virtual IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		yield break;
	}

	public virtual IEnumerator OnKill(CardData target, int value, CardData from)
	{
		yield break;
	}

	public virtual IEnumerator OnUseItems(CardData player, CardData target)
	{
		yield break;
	}

	public virtual void OnMerge(CardData mergeBy)
	{
	}

	public virtual IEnumerator OnPlayerGetCard(CardData player, CardData target)
	{
		yield break;
	}

	public virtual IEnumerator OnPlayerLoseCard(CardData player, CardData target)
	{
		yield break;
	}

	public virtual void OnGetCard(object data)
	{
	}

	public virtual void OnLoseCard(object data)
	{
	}

	protected void CallOnBeforeUseMagic(CardData playerCard)
	{
		foreach (CardLogic cardLogic in playerCard.CardLogics)
		{
			cardLogic.OnBeforeUseMagic(playerCard);
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic2 in cardSlotData.ChildCardData.CardLogics)
				{
					cardLogic2.OnBeforeUseMagic(playerCard);
				}
			}
		}
	}

	protected void CallOnAfterUseMagic(CardData playerCard)
	{
		foreach (CardLogic cardLogic in playerCard.CardLogics)
		{
			cardLogic.OnAfterUseMagic(playerCard);
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic2 in cardSlotData.ChildCardData.CardLogics)
				{
					cardLogic2.OnAfterUseMagic(playerCard);
				}
			}
		}
	}

	public virtual IEnumerator OnMoneyChanged(int value)
	{
		yield break;
	}

	public virtual IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		yield break;
	}

	public List<CardData> GetAllCurrentMonsters()
	{
		List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in battleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.怪物) && !DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return list;
	}

	public IEnumerator FeiDan(CardData from, int num)
	{
		List<CardData> allCurrentMonsters = this.GetAllCurrentMonsters();
		if (allCurrentMonsters == null || allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		this.ShowMe();
		int num5;
		for (int i = 0; i < num; i = num5 + 1)
		{
			allCurrentMonsters = this.GetAllCurrentMonsters();
			if (allCurrentMonsters == null || allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			for (int j = 0; j < allCurrentMonsters.Count; j++)
			{
				CardData cardData = allCurrentMonsters[j];
				if (DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					allCurrentMonsters.Remove(cardData);
				}
			}
			CardData SelectedMonster = allCurrentMonsters[SYNCRandom.Range(0, allCurrentMonsters.Count)];
			if (!DungeonOperationMgr.Instance.CheckCardDead(SelectedMonster) && from.CardGameObject != null)
			{
				ParticleObject partical = ParticlePoolManager.Instance.Spawn("Particles/飞弹", float.MaxValue);
				partical.gameObject.transform.position = from.CardGameObject.transform.position;
				float num2;
				if (i % 2 == 0)
				{
					num2 = 1f;
				}
				else
				{
					num2 = -1f;
				}
				Sequence sequence = DOTween.Sequence();
				float num3 = 1f - (float)(i / 3) * 0.2f;
				if (num3 < 0.1f)
				{
					num3 = 0.1f;
				}
				sequence.Append(partical.gameObject.transform.DOMoveZ(SelectedMonster.CardGameObject.transform.position.z, 0.3f * num3, false).SetEase(Ease.InQuad));
				sequence.Insert(0f, partical.gameObject.transform.DOMoveX(SelectedMonster.CardGameObject.transform.position.x + num2, 0.15f * num3, false).SetEase(Ease.OutQuad));
				sequence.Insert(0.15f, partical.gameObject.transform.DOMoveX(SelectedMonster.CardGameObject.transform.position.x, 0.15f * num3, false).SetEase(Ease.InQuad));
				yield return sequence.Play<Sequence>().WaitForCompletion();
				ParticlePoolManager.Instance.UnSpawn(partical);
				ParticlePoolManager.Instance.Spawn("Effect/风暴教主02", 0.2f).transform.position = SelectedMonster.CardGameObject.transform.position;
				Camera.main.transform.DOShakePosition(0.1f, 0.2f, 10, 90f, false, true);
				SelectedMonster.CardGameObject.transform.DOPunchRotation(new Vector3(10f, 0f, 0f), 0.1f, 10, 1f);
				int num4 = -1;
				if (this.GetLogic(from, typeof(DaQiTongCardLogic)) != null && from.HasAffix(DungeonAffix.strength))
				{
					this.ShowLogic("打气筒");
					num4 -= from.GetAffixData(DungeonAffix.strength);
				}
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(SelectedMonster, num4, from, false, 0, true, false);
				partical = null;
			}
			SelectedMonster = null;
			num5 = i;
		}
		yield break;
	}

	public List<CardData> GetAllCurrentMinions()
	{
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return list;
	}

	public CardData GetHero()
	{
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		CardData result = null;
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.英雄))
			{
				result = cardSlotData.ChildCardData;
			}
		}
		return result;
	}

	public List<CardData> GetAllCardsInBattleArea()
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		List<CardData> allCurrentMonsters = this.GetAllCurrentMonsters();
		List<CardData> list = new List<CardData>();
		if (allCurrentMinions.Count > 0)
		{
			foreach (CardData item in allCurrentMinions)
			{
				list.Add(item);
			}
		}
		if (allCurrentMonsters.Count > 0)
		{
			foreach (CardData item2 in allCurrentMonsters)
			{
				list.Add(item2);
			}
		}
		return list;
	}

	public List<CardData> GetAllCurrentMinionsExceptHero()
	{
		List<CardSlotData> myBattleArea = this.GetMyBattleArea();
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in myBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && !cardSlotData.ChildCardData.HasTag(TagMap.英雄))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return list;
	}

	public List<CardData> GetAllHurtedMinions()
	{
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && cardSlotData.ChildCardData.HP < cardSlotData.ChildCardData.MaxHP)
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return list;
	}

	public List<CardSlotData> GetAllEmptyAreaSlots()
	{
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData == null && (areaData as SpaceAreaData).GridOpenState[cardSlotDatas.IndexOf(cardSlotData)] >= 1 && cardSlotData != DungeonOperationMgr.Instance.CurrentPositionInMap)
			{
				list.Add(cardSlotData);
			}
		}
		return list;
	}

	public List<CardSlotData> GetAllEmptySlotsInEnemiesBattleArea()
	{
		List<CardSlotData> enemiesBattleArea = this.GetEnemiesBattleArea();
		List<CardSlotData> list = new List<CardSlotData>();
		if (enemiesBattleArea == null)
		{
			return null;
		}
		foreach (CardSlotData cardSlotData in enemiesBattleArea)
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
		}
		return list;
	}

	public List<CardSlotData> GetAllEmptySlotsInMyBattleArea()
	{
		List<CardSlotData> myBattleArea = this.GetMyBattleArea();
		List<CardSlotData> list = new List<CardSlotData>();
		if (myBattleArea == null)
		{
			return null;
		}
		foreach (CardSlotData cardSlotData in myBattleArea)
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
		}
		return list;
	}

	public int GetMinionLine(CardData cd)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets != null && playerSlotSets.Contains(cd.CurrentCardSlotData))
		{
			if (playerSlotSets.IndexOf(cd.CurrentCardSlotData) >= playerSlotSets.Count / 3 * 2)
			{
				return 0;
			}
			if (playerSlotSets.IndexOf(cd.CurrentCardSlotData) < playerSlotSets.Count / 3 * 2 && playerSlotSets.IndexOf(cd.CurrentCardSlotData) >= playerSlotSets.Count / 3)
			{
				return 1;
			}
			if (playerSlotSets.IndexOf(cd.CurrentCardSlotData) <= playerSlotSets.Count / 3)
			{
				return 2;
			}
		}
		return -1;
	}

	public int GetMonsterLine(CardData cd)
	{
		List<CardSlotData> enemiesBattleArea = this.GetEnemiesBattleArea();
		if (enemiesBattleArea != null && enemiesBattleArea.Contains(cd.CurrentCardSlotData))
		{
			if (enemiesBattleArea.IndexOf(cd.CurrentCardSlotData) >= enemiesBattleArea.Count / 3 * 2)
			{
				return 0;
			}
			if (enemiesBattleArea.IndexOf(cd.CurrentCardSlotData) < enemiesBattleArea.Count / 3 * 2 && enemiesBattleArea.IndexOf(cd.CurrentCardSlotData) >= enemiesBattleArea.Count / 3)
			{
				return 1;
			}
			if (enemiesBattleArea.IndexOf(cd.CurrentCardSlotData) < enemiesBattleArea.Count / 3)
			{
				return 2;
			}
		}
		return -1;
	}

	public IEnumerator AOE(Dictionary<CardData, int> targets, CardData origin, bool isRealDmg = false, int reduceArmor = 0, bool isWakeUpDmg = true)
	{
		if (DungeonOperationMgr.Instance.CheckCardDead(origin))
		{
			yield break;
		}
		foreach (KeyValuePair<CardData, int> keyValuePair in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair.Key))
			{
				if (keyValuePair.Value < 0)
				{
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.PlayerAttackEffect(origin, keyValuePair.Key, 1f, null, null, new AttackMsg(keyValuePair.Key, keyValuePair.Value, isRealDmg, isWakeUpDmg, reduceArmor, 0, null)));
				}
				else
				{
					DungeonOperationMgr.Instance.StartCoroutine(this.PlayCureEffect(origin, keyValuePair.Key));
				}
			}
		}
		yield return new WaitForSeconds(0.3f);
		foreach (KeyValuePair<CardData, int> keyValuePair2 in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair2.Key))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(keyValuePair2.Key, keyValuePair2.Value, origin, isRealDmg, reduceArmor, isWakeUpDmg, false);
			}
		}
		Dictionary<CardData, int>.Enumerator enumerator2 = default(Dictionary<CardData, int>.Enumerator);
		yield break;
		yield break;
	}

	public IEnumerator PlayCureEffect(CardData origin, CardData target)
	{
		ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
		particleObject.transform.position = origin.CardGameObject.transform.position;
		yield return particleObject.transform.DOMove(target.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
		string name = "Effect/HealHp";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = target.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		yield break;
	}

	public IEnumerator Cure(CardData origin, int val, CardData target)
	{
		if (DungeonOperationMgr.Instance.CheckCardDead(origin) || DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		if (target.HP >= target.MaxHP)
		{
			yield break;
		}
		yield return this.PlayCureEffect(origin, target);
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, val, origin, false, 0, true, false);
		yield break;
	}

	public IEnumerator wATKUp(Vector3 origin, int val, CardData target)
	{
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellMpBall", 0.3f);
		particleObject.transform.position = origin;
		yield return particleObject.transform.DOMove(target.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
		string name = "Effect/HealATK";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = target.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		target.wATK += val;
		yield break;
	}

	public List<CardData> GetMonstersNearBy(CardSlotData origin, List<Vector3Int> dirs)
	{
		List<CardData> list = new List<CardData>();
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (Vector3Int vector3Int in dirs)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(origin.GridPositionX, origin.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData != null)
			{
				list.Add(ralitiveCardSlotData.ChildCardData);
			}
		}
		return list;
	}

	public CardLogic GetLogic(CardData cd, Type type)
	{
		foreach (CardLogic cardLogic in cd.CardLogics)
		{
			if (cardLogic.GetType() == type)
			{
				return cardLogic;
			}
		}
		return null;
	}

	public void AddLogic(string logicName, int layers, CardData target)
	{
		CardLogic cardLogic;
		if (GameController.ins.LuaLogicCache.ContainsKey(logicName))
		{
			cardLogic = new CardLogicAdapter
			{
				LuaString = logicName
			};
		}
		else
		{
			cardLogic = (Activator.CreateInstance(Type.GetType(logicName)) as CardLogic);
		}
		if (cardLogic == null)
		{
			return;
		}
		cardLogic.Init();
		cardLogic.Layers = layers;
		cardLogic.CardData = target;
		target.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(target);
	}

	public void RemoveCardLogic(CardData cd, Type targetLogicType, string targetLogicName)
	{
		if (cd == null || cd.CardLogics.Count == 0)
		{
			return;
		}
		for (int i = cd.CardLogics.Count - 1; i >= 0; i--)
		{
			if (cd.CardLogics[i].GetType() == targetLogicType)
			{
				cd.CardLogics.RemoveAt(i);
			}
		}
	}

	public IEnumerator Shifting(CardSlotData csd, Vector3Int dir, List<CardSlotData> CardSlots)
	{
		if (csd == null || CardSlots == null || csd.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(csd.ChildCardData))
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		CardSlotData checkedNeighbourSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, dir.x, dir.y, false);
		if (checkedNeighbourSlotData == null || !CardSlots.Contains(checkedNeighbourSlotData))
		{
			yield break;
		}
		if (checkedNeighbourSlotData != null && checkedNeighbourSlotData.ChildCardData == null)
		{
			if (csd.ChildCardData.HasTag(TagMap.BOSS))
			{
				yield break;
			}
			if (csd.ChildCardData.CardGameObject != null)
			{
				yield return csd.ChildCardData.CardGameObject.JumpToSlot(checkedNeighbourSlotData.CardSlotGameObject, 0.2f, true);
				yield break;
			}
		}
		else if (checkedNeighbourSlotData != null && checkedNeighbourSlotData.ChildCardData != null)
		{
			if (checkedNeighbourSlotData.ChildCardData.HasTag(TagMap.BOSS) || csd.ChildCardData.HasTag(TagMap.BOSS))
			{
				yield break;
			}
			Vector3 oldScale = checkedNeighbourSlotData.ChildCardData.CardGameObject.transform.localScale;
			yield return csd.ChildCardData.CardGameObject.transform.DOJump(checkedNeighbourSlotData.ChildCardData.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
			yield return checkedNeighbourSlotData.ChildCardData.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
			checkedNeighbourSlotData.ChildCardData.MergeBy(csd.ChildCardData, true, false);
			yield return checkedNeighbourSlotData.ChildCardData.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
			csd.ChildCardData.DeleteCardData();
			yield break;
		}
		yield break;
	}

	public virtual IEnumerator OnBattleStart()
	{
		yield break;
	}

	public virtual IEnumerator OnBattleEnd()
	{
		yield break;
	}

	public virtual IEnumerator OnUseSkill()
	{
		if (DungeonOperationMgr.Instance.IsInBattle)
		{
			this.CardData.IsAttacked = true;
		}
		yield break;
	}

	public virtual IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		yield break;
	}

	public CardData GetDefaultTarget()
	{
		CardData cardData = null;
		List<CardSlotData> enemiesBattleArea = this.GetEnemiesBattleArea();
		List<CardSlotData> cardSlotDatas = GameController.ins.GetCurrentAreaData().CardSlotDatas;
		if (enemiesBattleArea == null)
		{
			return null;
		}
		for (int i = enemiesBattleArea.Count - 1; i >= 0; i--)
		{
			if (enemiesBattleArea[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && enemiesBattleArea[i].ChildCardData != null && (enemiesBattleArea[i].ChildCardData.HasTag(TagMap.怪物) || enemiesBattleArea[i].ChildCardData.HasTag(TagMap.衍生物) || enemiesBattleArea[i].ChildCardData.HasTag(TagMap.放置物) || enemiesBattleArea[i].ChildCardData.HasTag(TagMap.装备)))
			{
				cardData = enemiesBattleArea[i].ChildCardData;
				break;
			}
		}
		if (cardData == null)
		{
			for (int j = cardSlotDatas.Count - 1; j >= 0; j--)
			{
				if (cardSlotDatas[j].ChildCardData != null && cardSlotDatas[j].ChildCardData.HasTag(TagMap.BOSS) && cardSlotDatas[j].ChildCardData.HasTag(TagMap.怪物))
				{
					cardData = cardSlotDatas[j].ChildCardData;
				}
			}
		}
		return cardData;
	}

	public bool IsFirstAction(CardData me)
	{
		foreach (CardData cardData in this.GetAllCurrentMinions())
		{
			if (cardData != me && cardData.IsAttacked)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsLastAction(CardData me)
	{
		foreach (CardData cardData in this.GetAllCurrentMinions())
		{
			if (cardData != me && !cardData.IsAttacked)
			{
				return false;
			}
		}
		return true;
	}

	public virtual IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		yield break;
	}

	public virtual IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		yield break;
	}

	public virtual IEnumerator OnEnterArea(string areaID)
	{
		yield break;
	}

	public virtual IEnumerator OnMoveOnMap()
	{
		yield break;
	}

	public virtual void RemakeSkillEffect()
	{
	}

	public void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public List<CardSlotData> GetMyBattleArea()
	{
		if (this.CardData.HasTag(TagMap.BOSS))
		{
			return DungeonOperationMgr.Instance.BattleArea;
		}
		if (DungeonOperationMgr.Instance != null)
		{
			if (DungeonOperationMgr.Instance.PlayerBattleArea != null && DungeonOperationMgr.Instance.PlayerBattleArea.Contains(this.CardData.CurrentCardSlotData))
			{
				return DungeonOperationMgr.Instance.PlayerBattleArea;
			}
			if (DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.BattleArea.Contains(this.CardData.CurrentCardSlotData))
			{
				return DungeonOperationMgr.Instance.BattleArea;
			}
		}
		return null;
	}

	public List<CardSlotData> GetEnemiesBattleArea()
	{
		if (this.CardData.HasTag(TagMap.BOSS))
		{
			return DungeonOperationMgr.Instance.PlayerBattleArea;
		}
		if (DungeonOperationMgr.Instance != null)
		{
			if (DungeonOperationMgr.Instance.PlayerBattleArea != null && DungeonOperationMgr.Instance.PlayerBattleArea.Contains(this.CardData.CurrentCardSlotData))
			{
				return DungeonOperationMgr.Instance.BattleArea;
			}
			if (DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.BattleArea.Contains(this.CardData.CurrentCardSlotData))
			{
				return DungeonOperationMgr.Instance.PlayerBattleArea;
			}
		}
		return null;
	}

	public List<CardSlotData> GetPath(List<CardSlotData> grid, CardSlotData start, CardSlotData end)
	{
		List<CardSlotData> list = new List<CardSlotData>();
		int[,] array = new int[3, 3];
		int num = 0;
		int num2 = 0;
		int[] array2 = new int[9];
		for (int i = 0; i < 9; i++)
		{
			array2[i] = -1;
		}
		for (int j = 0; j < grid.Count; j++)
		{
			if (grid[j].ChildCardData != null)
			{
				array[j / 3, j % 3] = 1;
			}
			else
			{
				array[j / 3, j % 3] = 0;
			}
			if (grid[j] == start)
			{
				num = j;
			}
			if (grid[j] == end)
			{
				num2 = j;
			}
		}
		Queue<int> queue = new Queue<int>();
		queue.Enqueue(num);
		while (queue.Count != 0)
		{
			int num3 = queue.Dequeue();
			if (num3 == num2)
			{
				list.Add(grid[num3]);
				for (int num4 = array2[num3]; num4 != num; num4 = array2[num4])
				{
					list.Add(grid[num4]);
				}
				break;
			}
			if (array[num3 / 3, num3 % 3] != 1 || num3 == num)
			{
				if (num3 / 3 != 0 && array2[num3 - 3] == -1)
				{
					array2[num3 - 3] = num3;
					queue.Enqueue(num3 - 3);
				}
				if (num3 / 3 != 2 && array2[num3 + 3] == -1)
				{
					array2[num3 + 3] = num3;
					queue.Enqueue(num3 + 3);
				}
				if (num3 % 3 != 0 && array2[num3 - 1] == -1)
				{
					array2[num3 - 1] = num3;
					queue.Enqueue(num3 - 1);
				}
				if (num3 % 3 != 2 && array2[num3 + 1] == -1)
				{
					array2[num3 + 1] = num3;
					queue.Enqueue(num3 + 1);
				}
			}
		}
		list.Reverse();
		return list;
	}

	public virtual IEnumerator BeforeFact()
	{
		yield break;
	}

	public CardData GetCardByID(string ID)
	{
		CardData result = null;
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ID.Equals(ID))
			{
				result = cardSlotData.ChildCardData;
			}
		}
		return result;
	}

	public bool IsHavePersonLogic(TwoPeopleCardLogic logic, CardData target = null)
	{
		if (target == null)
		{
			target = this.CardData;
		}
		foreach (CardLogic cardLogic in target.CardLogics)
		{
			if (logic.GetType() == cardLogic.GetType() && ((TwoPeopleCardLogic)cardLogic).TargetID == logic.TargetID)
			{
				return true;
			}
		}
		return false;
	}

	public static CardData GetNeighboursCardData(List<CardSlotData> BattleArea, CardData CardData, Vector2Int relative)
	{
		int num = -1;
		if (CardData == null || CardData.CurrentCardSlotData == null)
		{
			return null;
		}
		for (int i = 0; i < BattleArea.Count; i++)
		{
			if (BattleArea[i] == CardData.CurrentCardSlotData)
			{
				num = i;
			}
		}
		int num2 = num % 3;
		int num3 = num / 3;
		num2 -= relative.x;
		num = (num3 - relative.y) * 3 + num2;
		if (num >= 0 && num < BattleArea.Count && BattleArea[num] != null && BattleArea[num].ChildCardData != null)
		{
			return BattleArea[num].ChildCardData;
		}
		return null;
	}

	public static int RequireRare;

	public int basicAtk;

	[JsonProperty]
	private int layers;

	public CardLogicColor Color = CardLogicColor.white;

	public int ExistsRound = -1;

	public float basicAtkPercent;

	public int basicMagicAtk;

	public int basicAddAtk;

	public int maxHp;

	public int maxMana;

	public int exploreGirdHpEffect;

	public int exploreGirdMpEffect;

	public float exploreGirdHpEffectPercent;

	public float exploreGirdMpEffectPercent;

	public int recoverLevelEffect;

	public float dmgPercentEffect;

	public float expPercentEffect;

	public float physicsDmgReduction;

	public float manaDmgReduction;

	public int flipHpRecover;

	public int attackFromSacrificeRate;

	public string displayName;

	public int RemainMoveRange;

	[NonSerialized]
	public Card me;

	[NonSerialized]
	public CardData CardData;

	public string Desc;

	public Vector3Int NeedEnergyCount;

	[NonSerialized]
	public ParticleObject XuliEffect;

	public string SkillEffect = "蓄力";

	public bool SkillEffectHold;

	public class MyPoint
	{
		public CardLogic.MyPoint parent { get; set; }

		public int X { get; set; }

		public int Y { get; set; }

		public MyPoint(int a, int b)
		{
			this.X = a;
			this.Y = b;
		}

		public CardSlot cs;
	}
}
