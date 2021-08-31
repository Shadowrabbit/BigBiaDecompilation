using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class DungeonHandler
{
	public int CheckDmg(AttackMsg msg, MinionTempData tempdata)
	{
		int armor = tempdata.Armor;
		int num = -msg.Dmg;
		if (!msg.IsRealDmg && ((tempdata.Armor > 0 && num < 0) || (tempdata.Armor > 0 && msg.reduceArmor > 0)))
		{
			if (tempdata.Armor - msg.reduceArmor > 0)
			{
				tempdata.Armor -= msg.reduceArmor;
				num = 0;
			}
			else
			{
				tempdata.Armor--;
			}
		}
		return num;
	}

	public IEnumerator ChangeHp(AttackMsg msg, CardData origin)
	{
		yield return this.ChangeHp(msg.Target, -msg.Dmg, origin, msg.IsRealDmg, msg.reduceArmor, msg.IsWakeUpAttack, false);
		yield break;
	}

	public IEnumerator ChangeHp(CardData target, int value, CardData from, bool isRealDamage = false, int reduceArmor = 0, bool isWakeUp = true, bool isNormalAttack = false)
	{
		if (target == null)
		{
			yield break;
		}
		bool isCrit = false;
		if (target.affixesDic != null && value < 0 && target.affixesDic.ContainsKey(DungeonAffix.frail))
		{
			value -= target.affixesDic[DungeonAffix.frail];
		}
		if (target.affixesDic != null && value < 0 && target.affixesDic.ContainsKey(DungeonAffix.def))
		{
			value += target.affixesDic[DungeonAffix.def];
			if (value > 0)
			{
				value = 0;
			}
		}
		if (from != null && from.CRIT > 0 && SYNCRandom.Range(0, 100) < from.CRIT)
		{
			float num = 2f;
			if (DungeonOperationMgr.Instance.GetLogic(from, typeof(BiShengTouDaiCardLogic)) != null && from.HasAffix(DungeonAffix.crit))
			{
				BiShengTouDaiCardLogic biShengTouDaiCardLogic = DungeonOperationMgr.Instance.GetLogic(from, typeof(BiShengTouDaiCardLogic)) as BiShengTouDaiCardLogic;
				num += (float)from.GetAffixData(DungeonAffix.crit) * biShengTouDaiCardLogic.pow;
			}
			isCrit = true;
			value = Mathf.CeilToInt(num * (float)value);
			isRealDamage = true;
		}
		if (value < 0)
		{
			List<CardData> cardDataNearBy = DungeonOperationMgr.Instance.GetCardDataNearBy(target, new List<Vector3Int>
			{
				Vector3Int.left + Vector3Int.left,
				Vector3Int.left,
				Vector3Int.right,
				Vector3Int.right + Vector3Int.right
			});
			if (cardDataNearBy.Count > 0)
			{
				foreach (CardData cardData in cardDataNearBy)
				{
					if (cardData.HasAffix(DungeonAffix.guard) && Mathf.Abs(value) > cardData.GetAffixData(DungeonAffix.guard))
					{
						value += cardData.GetAffixData(DungeonAffix.guard);
						if (value > 0)
						{
							value = 0;
						}
						yield return this.ChangeHp(cardData, -cardData.GetAffixData(DungeonAffix.guard), from, false, 0, true, false);
					}
				}
				List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
			}
		}
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		int num2;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num2 + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num2 + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnBeforeHpChange").DeclaringType == cardLogic.GetType())
						{
							RefInt refInt = new RefInt();
							refInt.value = value;
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnBeforeHpChange(target, refInt, from));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							value = refInt.value;
							refInt = null;
							routine = null;
						}
					}
					num2 = i2;
				}
				slotCardData = null;
			}
			num2 = i;
		}
		foreach (CardSlotData cardSlotData in csl)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num2 - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnBeforeHpChange").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						RefInt refInt = new RefInt();
						refInt.value = value;
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnBeforeHpChange(target, refInt, from));
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
						}
						value = refInt.value;
						refInt = null;
						routine = null;
					}
					num2 = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator2 = default(List<CardSlotData>.Enumerator);
		int armor = target.Armor;
		if (!isRealDamage)
		{
			if (target.DizzyLayer > 0 && value < 0)
			{
				if (isWakeUp)
				{
					if (target.MaxArmor > 0)
					{
						target.MaxArmor--;
					}
					target.Armor = target.MaxArmor;
					target.DizzyLayer--;
					isCrit = true;
					value *= 2;
					isRealDamage = true;
				}
				else
				{
					isCrit = true;
					value *= 2;
					isRealDamage = true;
				}
			}
			else if ((target.Armor > 0 && value < 0) || (target.Armor > 0 && reduceArmor > 0))
			{
				target.Armor -= reduceArmor;
				if (target.Armor > 0)
				{
					if (value < 0)
					{
						value = 0;
					}
					target.Armor--;
				}
				if (target.Armor <= 0)
				{
					target.Armor = 0;
					if ((target.HasTag(TagMap.怪物) || target.HasTag(TagMap.衍生物)) && !target.HasTag(TagMap.BOSS))
					{
						target.DizzyLayer = 1;
					}
				}
			}
		}
		else if (target.DizzyLayer > 0 && value < 0 && isWakeUp)
		{
			if (target.DizzyLayer <= 0)
			{
				if (target.MaxArmor > 0)
				{
					target.MaxArmor--;
				}
				target.Armor = target.MaxArmor;
			}
			target.DizzyLayer--;
		}
		int num3 = target.Armor - armor;
		int resultValue = (target.HP + value > 0) ? value : (-target.HP);
		if (value < 0 && (target.HasTag(TagMap.怪物) || target.HasTag(TagMap.衍生物)))
		{
			DungeonController.Instance.GameSettleData.totalPhysicsDmg += -resultValue;
		}
		if (target.CardGameObject != null)
		{
			if (resultValue == 0)
			{
				GameController.getInstance().ShowAmountText(target.CardGameObject.transform.position, num3.ToString(), Color.yellow, 0, isCrit, false);
			}
			else if (resultValue > 0)
			{
				GameController.getInstance().ShowAmountText(target.CardGameObject.transform.position, resultValue.ToString(), Color.green, 0, isCrit, false);
			}
			else
			{
				GameController.getInstance().ShowAmountText(target.CardGameObject.transform.position, value.ToString() ?? "", Color.red, 0, isCrit, false);
			}
		}
		target.HP += resultValue;
		if (target.HP > target.MaxHP)
		{
			target.HP = target.MaxHP;
		}
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num2 + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num2 + 1)
				{
					CardLogic cardLogic2 = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic2.Color >= CardLogicColor.white || cardLogic2.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic2.GetType().GetMethod("OnHpChange").DeclaringType == cardLogic2.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnHpChange(target, resultValue, from));
							yield return routine.coroutine;
							try
							{
								int result3 = routine.Result;
							}
							catch (Exception ex3)
							{
								Debug.LogError(ex3.Message);
								Debug.LogError(ex3.StackTrace);
							}
							routine = null;
						}
					}
					num2 = i2;
				}
				slotCardData = null;
			}
			num2 = i;
		}
		foreach (CardSlotData cardSlotData2 in csl)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData2.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num2 - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnHpChange").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnHpChange(target, resultValue, from));
						yield return routine.coroutine;
						try
						{
							int result4 = routine.Result;
						}
						catch (Exception ex4)
						{
							Debug.LogError(ex4.Message);
						}
						routine = null;
					}
					num2 = i;
				}
				slotCardData = null;
			}
		}
		enumerator2 = default(List<CardSlotData>.Enumerator);
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield return GameController.getInstance().StartCoroutine(this.Die(target, resultValue, from));
		}
		yield break;
		yield break;
	}

	public IEnumerator Die(CardData target, int value, CardData from)
	{
		if (target.HasTag(TagMap.随从))
		{
			DungeonController.Instance.GameSettleData.DeathMinionNum++;
			int num = SYNCRandom.Range(0, 5);
			if (num == 0)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志13"), LocalizationMgr.Instance.GetLocalizationWord(target.Name) + target.PersonName), null, null, null, null, null, null));
			}
			else if (num == 1)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志14"), LocalizationMgr.Instance.GetLocalizationWord(target.Name) + target.PersonName), null, null, null, null, null, null));
			}
			else if (num == 2)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志15"), LocalizationMgr.Instance.GetLocalizationWord(target.Name) + target.PersonName), null, null, null, null, null, null));
			}
			else if (num == 3)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志16"), LocalizationMgr.Instance.GetLocalizationWord(target.Name) + target.PersonName), null, null, null, null, null, null));
			}
			else if (num == 4)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord(target.Name) + target.PersonName + LocalizationMgr.Instance.GetLocalizationWord("SM_日志17"), null, null, null, null, null, null));
			}
		}
		bool isBoss = false;
		if (target.HasTag(TagMap.BOSS))
		{
			isBoss = true;
			DungeonController.Instance.GameSettleData.KillBossNum++;
			int value2 = 100;
			if (GlobalController.Instance.AdvanceDataController.GetBossShouJi())
			{
				value2 = Mathf.CeilToInt(120.00001f);
			}
			GameController.getInstance().StartCoroutine(this.GetVoxelAnimate(value2, target.CardGameObject.transform.position, Vector3.zero));
		}
		if (target.HasTag(TagMap.怪物) || target.HasTag(TagMap.衍生物))
		{
			DungeonController.Instance.GameSettleData.KillNum++;
			SteamController.Instance.SteamAchievementsController.SetAchievementStatus(AchievementType.NEW_ACHIEVEMENT_guaiwujiaorouji, 1);
		}
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		int num2;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num2 + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num2 + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (slotCardData.CardLogics[i2].GetType().GetMethod("OnKill").DeclaringType == slotCardData.CardLogics[i2].GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnKill(target, value, from));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							routine = null;
						}
					}
					num2 = i2;
				}
				slotCardData = null;
			}
			num2 = i;
		}
		foreach (CardSlotData cardSlotData in csl)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = 0; i < slotCardData.CardLogics.Count; i = num2 + 1)
				{
					CardLogic cardLogic2 = slotCardData.CardLogics[i];
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnKill").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnKill(target, value, from));
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
							Debug.LogError(ex2.StackTrace);
						}
						routine = null;
					}
					num2 = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		CardSlotData diedSlot = target.CurrentCardSlotData;
		if (target != null && target.HasTag(TagMap.怪物))
		{
			if (diedSlot != null)
			{
				if (!GameController.ins.GameData.GameSettleData.IsFirstKilled)
				{
					SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.ACHIEVEMENT_FirstBlood);
					GameController.ins.GameData.GameSettleData.IsFirstKilled = true;
				}
				if (DungeonController.Instance.GameSettleData.NowTurn == DungeonController.Instance.GameSettleData.Turns)
				{
					DungeonController.Instance.GameSettleData.TurnKills++;
				}
				GameController.getInstance().UIController.ShowComboPanel(DungeonController.Instance.GameSettleData.TurnKills);
				int num3 = target.Price;
				if (GameController.ins.GameData.Agreenment >= 6)
				{
					num3 = Mathf.CeilToInt((float)num3 * 0.75f);
				}
				if (num3 > 0)
				{
					int value3 = UnityEngine.Random.Range(0, 2 + GameController.ins.GameData.Agreenment / 2);
					GameController.getInstance().StartCoroutine(this.GetVoxelAnimate(value3, target.CardGameObject.transform.position, Vector3.zero));
				}
				num3 = Mathf.CeilToInt((float)num3 * (1f + 0.1f * (float)(DungeonController.Instance.GameSettleData.TurnKills - 1)) * DungeonOperationMgr.Instance.MoneyAddition);
				GameController.getInstance().StartCoroutine(this.GetMoneyAnimate(num3, target.CardGameObject.transform.position, Vector3.zero));
				if (GameController.getInstance().GameData.GameSettleData.KilledMonsterIDList == null)
				{
					GameController.getInstance().GameData.GameSettleData.KilledMonsterIDList = new List<string>();
				}
				GameController.getInstance().GameData.GameSettleData.KilledMonsterIDList.Add(target.ModID);
				int i = SYNCRandom.Range(0, 200);
				if (GameData.CurrentGameType == GameData.GameType.Endless && i >= 20 && i < 200)
				{
					CardSlotData targetSlot = GameController.ins.GetEmptySlotDataByCardTag(TagMap.奇遇);
					CardData slotCardData;
					if (targetSlot != null)
					{
						List<CardData> list = new List<CardData>();
						foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
						{
							if (cardData.HasTag(TagMap.奇遇))
							{
								list.Add(cardData);
							}
						}
						slotCardData = list[SYNCRandom.Range(0, list.Count)];
						slotCardData = CardData.CopyCardData(slotCardData, true);
						if (target != null && target.CardGameObject != null)
						{
							GameObject tempGo = Card.InitWithOutData(slotCardData, true);
							tempGo.transform.position = target.CardGameObject.transform.position;
							yield return tempGo.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 1f, 1, 0.5f, false).WaitForCompletion();
							UnityEngine.Object.DestroyImmediate(tempGo.gameObject);
							tempGo = null;
						}
						slotCardData.PutInSlotData(targetSlot, true);
					}
					slotCardData = null;
					targetSlot = null;
				}
				if (i < 20 && GameController.ins.GetEmptySlotDataByCardTag(TagMap.工具) != null && GameController.ins.GameData.DungeonTheme != DungeonTheme.Arena)
				{
					CardData slotCardData = null;
					CardSlotData targetSlot = GameController.ins.GetEmptySlotDataByCardTag(TagMap.工具);
					if (targetSlot == null)
					{
						yield break;
					}
					if (i < 20 && i >= 18)
					{
						slotCardData = Card.InitCardDataByID("形状爆破");
					}
					else if (i < 18 && i >= 16)
					{
						slotCardData = Card.InitCardDataByID("形状斩杀");
					}
					else if (i < 16 && i >= 13)
					{
						slotCardData = Card.InitCardDataByID("上");
					}
					else if (i < 13 && i >= 10)
					{
						slotCardData = Card.InitCardDataByID("下");
					}
					else if (i < 10 && i >= 7)
					{
						slotCardData = Card.InitCardDataByID("左");
					}
					else if (i < 7 && i >= 4)
					{
						slotCardData = Card.InitCardDataByID("右");
					}
					else
					{
						List<CardData> list2 = new List<CardData>();
						foreach (CardData cardData2 in GameController.ins.CardDataModMap.Cards)
						{
							if ((cardData2.HasTag(TagMap.药水) || cardData2.HasTag(TagMap.工具) || cardData2.HasTag(TagMap.放置物)) && !cardData2.HasTag(TagMap.特殊))
							{
								list2.Add(cardData2);
							}
						}
						slotCardData = list2[SYNCRandom.Range(0, list2.Count)];
					}
					slotCardData = CardData.CopyCardData(slotCardData, true);
					if (target != null && target.CardGameObject != null)
					{
						GameObject tempGo = Card.InitWithOutData(slotCardData, true);
						tempGo.transform.position = target.CardGameObject.transform.position;
						yield return tempGo.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 1f, 1, 0.5f, false).WaitForCompletion();
						UnityEngine.Object.DestroyImmediate(tempGo.gameObject);
						tempGo = null;
					}
					slotCardData.PutInSlotData(targetSlot, true);
					slotCardData = null;
					targetSlot = null;
				}
				if (target.affixesDic.Count > 0)
				{
					List<DungeonAffix> list3 = new List<DungeonAffix>();
					foreach (KeyValuePair<DungeonAffix, int> keyValuePair in target.affixesDic)
					{
						list3.Add(keyValuePair.Key);
					}
					if (list3.Count > 0)
					{
						for (int j = list3.Count - 1; j >= 0; j--)
						{
							try
							{
								target.RemoveAffix(list3[j]);
							}
							catch (Exception ex3)
							{
								Debug.LogError("死亡时移除BUFF错误" + ex3.Message);
								Debug.LogError(ex3.StackTrace);
							}
						}
					}
				}
				target.DeleteCardData();
			}
		}
		else if (target != null && target.HasTag(TagMap.随从))
		{
			if (GameController.ins.GameData.DeadMinionsList != null)
			{
				GameController.ins.GameData.DeadMinionsList.Add(CardData.CopyCardData(target, true));
			}
			else
			{
				GameController.ins.GameData.DeadMinionsList = new List<CardData>();
				GameController.ins.GameData.DeadMinionsList.Add(CardData.CopyCardData(target, true));
			}
			if (target.HasTag(TagMap.英雄))
			{
				if (this.m_IsFuHuo)
				{
					target.DeleteCardData();
				}
				else if (GlobalController.Instance.AdvanceDataController.GetFuHuo())
				{
					ParticlePoolManager.Instance.Spawn("Effect/Revive", 3f).transform.position = target.CardGameObject.transform.position;
					target.HP = 1;
					this.m_IsFuHuo = true;
				}
			}
			else
			{
				target.DeleteCardData();
			}
		}
		else
		{
			target.DeleteCardData();
		}
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num2 + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num2 + 1)
				{
					CardLogic cardLogic3 = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic3.Color >= CardLogicColor.white || cardLogic3.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (slotCardData.CardLogics[i2].GetType().GetMethod("OnAfterKill").DeclaringType == slotCardData.CardLogics[i2].GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic3.OnAfterKill(diedSlot, from));
							yield return routine.coroutine;
							try
							{
								int result3 = routine.Result;
							}
							catch (Exception ex4)
							{
								Debug.LogError(ex4.Message);
								Debug.LogError(ex4.StackTrace);
							}
							routine = null;
						}
					}
					num2 = i2;
				}
				slotCardData = null;
			}
			num2 = i;
		}
		foreach (CardSlotData cardSlotData2 in csl)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData2.ChildCardData;
				for (int i = 0; i < slotCardData.CardLogics.Count; i = num2 + 1)
				{
					CardLogic cardLogic4 = slotCardData.CardLogics[i];
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnAfterKill").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic4.OnAfterKill(diedSlot, from));
						yield return routine.coroutine;
						try
						{
							int result4 = routine.Result;
						}
						catch (Exception ex5)
						{
							Debug.LogError(ex5.Message);
							Debug.LogError(ex5.StackTrace);
						}
						routine = null;
					}
					num2 = i;
				}
				slotCardData = null;
			}
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		if (isBoss)
		{
			DungeonOperationMgr.Instance.IsWinCurrentFloor = true;
		}
		if (DungeonOperationMgr.Instance.IsWinCurrentFloor)
		{
			yield return new WaitForSeconds(5f);
			if (GameController.ins.GameData.DungeonTheme == DungeonTheme.Normal)
			{
				DungeonController.Instance.GenerateNextArea(true);
			}
			else
			{
				DungeonOperationMgr.Instance.StartCoroutine(DungeonController.Instance.GameOver(true));
			}
			DungeonOperationMgr.Instance.IsWinCurrentFloor = false;
		}
		else
		{
			DungeonOperationMgr.Instance.FlipAllFlopableCards();
		}
		if (DungeonOperationMgr.Instance.CheckWinBattle())
		{
			DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.EndBattleProcess());
		}
		this.CheckGameOver(target);
		yield break;
		yield break;
	}

	public IEnumerator ChangeMoney(int value)
	{
		EffectAudioManager.Instance.PlayEffectAudio(14, null);
		if (value > 0)
		{
			DungeonController.Instance.GameSettleData.money += value;
		}
		GameController.getInstance().GameData.Money += value;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		int num;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnMoneyChanged").DeclaringType == cardLogic.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnMoneyChanged(value));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = 0; i < slotCardData.CardLogics.Count; i = num + 1)
				{
					CardLogic cardLogic2 = slotCardData.CardLogics[i];
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnMoneyChanged").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnMoneyChanged(value));
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
							Debug.LogError(ex2.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield return null;
		yield break;
		yield break;
	}

	public bool CheckGameOver(CardData target)
	{
		bool flag = false;
		if (target != null && target.HasTag(TagMap.英雄) && DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			flag = true;
		}
		if (!flag)
		{
			flag = true;
			foreach (CardSlotData cardSlotData in GameController.ins.GameData.SlotsOnPlayerTable)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					flag = false;
				}
			}
		}
		if (flag)
		{
			GameController.ins.StartCoroutine(DungeonController.Instance.GameOver(false));
		}
		return flag;
	}

	public IEnumerator CheckTargetCount(CardData target, int count = 3)
	{
		if (target == null || !target.HasTag(TagMap.随从))
		{
			yield break;
		}
		DungeonOperationMgr.Instance.SetLockOperation(true);
		UIController.UILevel tempLock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		List<CardSlotData> targetList = new List<CardSlotData>();
		int num = 0;
		targetList.Add(target.CurrentCardSlotData);
		num++;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData childCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				if (childCardData.ModID == target.ModID && childCardData.Rare == target.Rare && target != childCardData)
				{
					targetList.Add(GameController.getInstance().PlayerSlotSets[i]);
					num++;
				}
			}
		}
		if (num >= count)
		{
			CardData newCardData = CardData.ThreeCombo(targetList[0].ChildCardData, targetList[1].ChildCardData, targetList[2].ChildCardData);
			yield return DOTween.Sequence().Append(targetList[0].ChildCardData.CardGameObject.transform.DOLocalMoveY(1f, 0.3f, false).SetEase(Ease.OutBack)).Insert(0f, targetList[1].ChildCardData.CardGameObject.transform.DOLocalMoveY(1f, 0.3f, false).SetEase(Ease.OutBack)).Insert(0f, targetList[2].ChildCardData.CardGameObject.transform.DOLocalMoveY(1f, 0.3f, false).SetEase(Ease.OutBack)).Append(targetList[0].ChildCardData.CardGameObject.transform.DOMove(targetList[1].ChildCardData.CardGameObject.transform.position, 0.5f, false).SetEase(Ease.InBack)).Insert(0.3f, targetList[2].ChildCardData.CardGameObject.transform.DOMove(targetList[1].ChildCardData.CardGameObject.transform.position, 0.5f, false).SetEase(Ease.InBack)).InsertCallback(0.8f, delegate
			{
				targetList[0].ChildCardData.DeleteCardData();
				targetList[2].ChildCardData.DeleteCardData();
			}).Append(targetList[1].ChildCardData.CardGameObject.transform.DOLocalMoveY(0f, 0.1f, false).SetEase(Ease.InBack)).OnComplete(delegate
			{
				targetList[1].ChildCardData.DeleteCardData();
				newCardData.PutInSlotData(targetList[1], true);
				int rare = newCardData.Rare;
				if (rare != 2)
				{
					if (rare == 3)
					{
						DungeonController.Instance.GameSettleData.NineComboTimes++;
					}
				}
				else
				{
					DungeonController.Instance.GameSettleData.ThreeComboTimes++;
				}
				targetList = new List<CardSlotData>();
			}).WaitForCompletion();
			UIController.LockLevel = tempLock;
			yield return this.CheckTargetCount(newCardData, 3);
			yield break;
		}
		UIController.LockLevel = tempLock;
		DungeonOperationMgr.Instance.SetLockOperation(false);
		yield return null;
		yield break;
	}

	public bool CheckTargetCardCount(CardData target, int count = 3)
	{
		return false;
	}

	public bool CheckHaveEnemy()
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				CardData childCardData = cardSlotData.ChildCardData;
				if ((childCardData.HasTag(TagMap.怪物) && !childCardData.HasTag(TagMap.衍生物)) || (DungeonOperationMgr.Instance.CanFlip(childCardData) && !childCardData.HasTag(TagMap.事件)))
				{
					return true;
				}
			}
		}
		return false;
	}

	public IEnumerator GetMoneyAnimate(int value, Vector3 targetPos, Vector3 toPos)
	{
		if (value <= 0)
		{
			yield break;
		}
		int num = Mathf.CeilToInt((float)value / 10f);
		Vector3 toPoint = Vector3.zero;
		if (toPos == Vector3.zero)
		{
			Vector3 position = GameController.getInstance().playerTableText.Money.transform.position;
			toPoint = new Vector3(position.x - 0.5f, position.y, position.z);
		}
		else
		{
			toPoint = toPos;
		}
		int num2;
		for (int i = num; i > 0; i = num2 - 1)
		{
			DisplayModel go = ModelPoolManager.Instance.SpawnModel("UI/Coin");
			go.transform.localScale = Vector3.one * 0.7f;
			go.transform.position = targetPos + new Vector3(UnityEngine.Random.Range(-0.4f, 0.4f), 0.16f, UnityEngine.Random.Range(-0.4f, 0.4f));
			ParticleObject par = ParticlePoolManager.Instance.Spawn("Effect/GetMoney", float.MaxValue);
			par.transform.position = go.transform.position;
			go.transform.GetChild(0).rotation = Quaternion.Euler(70f, 0f, 0f);
			go.GameObject.AddComponent<RotateObject>().Speed = 500f;
			go.transform.DOScale(Vector3.zero, 5f);
			par.transform.DOMove(toPoint, 1f, false);
			go.transform.DOMove(toPoint, 1f, false).OnComplete(delegate
			{
				ParticlePoolManager.Instance.UnSpawn(par);
				ModelPoolManager.Instance.UnSpawnModel(go);
			});
			yield return new WaitForSeconds(0.07f);
			num2 = i;
		}
		string name = "Effect/HealMoney";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = toPoint;
		if (toPos == Vector3.zero)
		{
			yield return GameController.getInstance().StartCoroutine(this.ChangeMoney(value));
		}
		yield return null;
		yield break;
	}

	public IEnumerator GetVoxelAnimate(int value, Vector3 targetPos, Vector3 toPos)
	{
		if (value <= 0)
		{
			yield break;
		}
		int num = Mathf.CeilToInt((float)value / 10f);
		Vector3 toPoint = Vector3.zero;
		if (toPos == Vector3.zero)
		{
			toPoint = new Vector3(10.599f, 2.008f, 12.3f);
		}
		else
		{
			toPoint = toPos;
		}
		int num2;
		for (int i = num; i > 0; i = num2 - 1)
		{
			DisplayModel go = ModelPoolManager.Instance.SpawnModel("UI/Voxel");
			go.transform.localScale = Vector3.one * 0.7f;
			go.transform.position = targetPos + new Vector3(UnityEngine.Random.Range(-0.4f, 0.4f), 0.16f, UnityEngine.Random.Range(-0.4f, 0.4f));
			ParticleObject par = ParticlePoolManager.Instance.Spawn("Effect/GetVoxel", float.MaxValue);
			par.transform.position = go.transform.position;
			go.transform.GetChild(0).rotation = Quaternion.Euler(70f, 0f, 0f);
			go.GameObject.AddComponent<RotateObject>().Speed = 300f;
			go.transform.DOScale(Vector3.zero, 5f);
			par.transform.DOMove(toPoint, 1f, false);
			go.transform.DOMove(toPoint, 1f, false).OnComplete(delegate
			{
				ParticlePoolManager.Instance.UnSpawn(par);
				ModelPoolManager.Instance.UnSpawnModel(go);
			});
			yield return new WaitForSeconds(0.07f);
			num2 = i;
		}
		if (toPos == Vector3.zero)
		{
			GlobalController.Instance.ChangeGlobalMoney(value);
		}
		yield return null;
		yield break;
	}

	private bool m_IsFuHuo;
}
