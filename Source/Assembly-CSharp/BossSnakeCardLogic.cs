using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("Die");
			if (GameController.ins.GameData.Agreenment < 10)
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_busheren);
			}
			else
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhongjibusheren);
			}
		}
		if (target.HasTag(TagMap.怪物) && this.CurType == 2 && base.GetAllCurrentMonsters().Count == 0)
		{
			this.ChangeSnakeType(1, true);
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue <= 0 && !DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("BeAttacked");
			if (this.CurType == 1)
			{
				int num = 0;
				if (this.CardData.HP > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f))
				{
					num = this.CardData.HP - Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f);
				}
				if (this.CardData.HP > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f))
				{
					num = this.CardData.HP - Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f);
				}
				if (this.CardData.HP > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f))
				{
					num = this.CardData.HP - Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f);
				}
				GameController.ins.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_36"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚1"),
					"\n<size=16>\n ",
					string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚4"), num),
					"</size>"
				});
				if (this.CardData.HP < Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f))
				{
					GameController.ins.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
					{
						LocalizationMgr.Instance.GetLocalizationWord("T_36"),
						" - ",
						LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚1"),
						"\n<size=16>\n ",
						LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚3"),
						"</size>"
					});
				}
			}
			if (this.CurType == 1 && ((this.CardData.HP <= Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f) && this.CardData.HP - changedValue > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f)) || (this.CardData.HP <= Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f) && this.CardData.HP - changedValue > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f)) || (this.CardData.HP <= Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f) && this.CardData.HP - changedValue > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f))))
			{
				this.ChangeSnakeType(2, true);
			}
		}
		yield break;
	}

	public override IEnumerator OnEnterArea(string areaID)
	{
		if (areaID.Equals("BossSnake"))
		{
			this.CardData = DungeonOperationMgr.Instance.InitDungeonMonster(this.CardData, 30);
			this.ChangeSnakeType(1, false);
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && target.ChildCardData == this.CardData && !this.HaveJumped)
		{
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
			this.HaveJumped = true;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && target.ChildCardData == this.CardData)
		{
			this.HaveJumped = false;
			yield break;
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.up);
		list.Add(Vector3Int.down);
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && myBattleArea.Contains(ralitiveCardSlotData))
			{
				list2.Add(ralitiveCardSlotData);
			}
		}
		if (list2.Count == 0)
		{
			yield break;
		}
		CardSlotData target = list2[SYNCRandom.Range(0, list2.Count)];
		if (csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		}
		if (csd.ChildCardData != null && csd.ChildCardData.Attrs.ContainsKey("Col"))
		{
			csd.ChildCardData.Attrs["Col"] = target.Attrs["Col"];
		}
		CardData cardData = Card.InitCardDataByID("蛇");
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.step);
		}
		else
		{
			DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.level * 5);
		}
		cardData.PutInSlotData(csd, true);
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (this.isFirstTimeToType2 && this.CurType == 2)
		{
			this.isFirstTimeToType2 = false;
			CardData hero = base.GetHero();
			JournalsConversation journalsConversation = new JournalsConversation();
			JournalsConversationManager.role1 = hero;
			journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("SM_大蛇1"), null));
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
		}
		yield break;
	}

	private void ChangeSnakeType(int type, bool isAnimate = true)
	{
		if (type != 1)
		{
			if (type != 2)
			{
				return;
			}
			this.CurType = 2;
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("SM_大蛇2"));
			DungeonOperationMgr.Instance.StartCoroutine(base.ShowCustomEffect("沙之祭祀释放", this.CardData.CurrentCardSlotData, 1f));
			this.CardData.CardGameObject.gameObject.SetActive(false);
			this.CardData.CardTags = 268435456UL;
			if (base.GetLogic(this.CardData, typeof(DengShiCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(DengShiCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(SheYaCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(SheYaCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(XieYanCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(XieYanCardLogic)));
			}
			this.CardData.AddLogic("DuWuCardLogic", 0);
			this.CardData.AddLogic("HuanSheCardLogic", 0);
			for (int i = 0; i < 3; i++)
			{
				List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
				if (allEmptySlotsInMyBattleArea != null && allEmptySlotsInMyBattleArea.Count > 0)
				{
					CardSlotData slotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
					CardData cardData = Card.InitCardDataByID("蛇");
					if (GameData.CurrentGameType == GameData.GameType.Endless)
					{
						DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.step);
					}
					else
					{
						DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.level * 5);
					}
					cardData.PutInSlotData(slotData, true);
				}
			}
			if (isAnimate)
			{
				UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("Leave");
			}
		}
		else
		{
			this.CurType = 1;
			int num = 0;
			if (this.CardData.HP > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f))
			{
				num = this.CardData.HP - Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f);
			}
			if (this.CardData.HP > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f))
			{
				num = this.CardData.HP - Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f);
			}
			if (this.CardData.HP > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f))
			{
				num = this.CardData.HP - Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f);
			}
			GameController.ins.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("T_36"),
				" - ",
				LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚1"),
				"\n<size=16>\n ",
				string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚4"), num),
				"</size>"
			});
			if (this.CardData.HP < Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f))
			{
				GameController.ins.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_36"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚1"),
					"\n<size=16>\n ",
					LocalizationMgr.Instance.GetLocalizationWord("T_大蛇崇尚3"),
					"</size>"
				});
			}
			DungeonOperationMgr.Instance.StartCoroutine(base.ShowCustomEffect("沙之祭祀释放", this.CardData.CurrentCardSlotData, 1f));
			this.CardData.CardGameObject.gameObject.SetActive(true);
			this.CardData.CardTags = 268468224UL;
			if (base.GetLogic(this.CardData, typeof(DuWuCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(DuWuCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(HuanSheCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(HuanSheCardLogic)));
			}
			this.CardData.AddLogic("DengShiCardLogic", 0);
			this.CardData.AddLogic("SheYaCardLogic", 0);
			this.CardData.AddLogic("XieYanCardLogic", 0);
			if (isAnimate)
			{
				UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("Back");
				return;
			}
		}
	}

	public int CurType = 1;

	private bool HaveJumped;

	private bool isFirstTimeToType2 = true;
}
