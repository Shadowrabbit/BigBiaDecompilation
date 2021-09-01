using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using MK.Glow.Example;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DungeonController : MonoBehaviour
{
	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public Hero Hero
	{
		get
		{
			return this.m_Hero;
		}
	}

	private void Awake()
	{
		DungeonController.Instance = this;
		GameController.ins.GameData.level = 1;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GetHero()
	{
		this.m_Hero = this.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
	}

	public void GenerateNextArea(bool isDungeonLevelUp = true)
	{
		GameController.ins.GameData.CurrentDungeonIndex++;
		if (isDungeonLevelUp)
		{
			GameData gameData = GameController.ins.GameData;
			int level = gameData.level;
			gameData.level = level + 1;
		}
		CardData cardData = GameController.ins.GameData.DungeonArea[GameController.ins.GameData.CurrentDungeonIndex % GameController.ins.GameData.DungeonArea.Count];
		if (cardData.Attrs.ContainsKey("AreaDataID"))
		{
			GameController.ins.StartCoroutine(DungeonOperationMgr.Instance.EndTurnProcess(true));
			AreaData areaData = GameController.getInstance().GameData.AreaMap[cardData.Attrs["AreaDataID"].ToString()];
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
		}
		if (GlobalController.Instance.AdvanceDataController.GetHuiFuShengMing())
		{
			this.m_Hero.HeroCard.HP = ((this.m_Hero.HeroCard.HP + 5 > this.m_Hero.HeroCard.MaxHP) ? this.m_Hero.HeroCard.MaxHP : (this.m_Hero.HeroCard.HP + 5));
		}
		if (GlobalController.Instance.AdvanceDataController.GetChaoJiHuoBa())
		{
			GameController.ins.GameData.TorchNum++;
		}
	}

	public void StartNewDungeon()
	{
		GameController.ins.GameData.DungeonGUID = Guid.NewGuid().ToString();
		GameController.ins.GameData.GameSettleData = new GameSettleData();
		GameController.ins.GameData.step = 0;
		GameController.ins.GameData.EventStep = 0;
		GameData.MAX_EventStep = 5;
		GameController.ins.GameData.FaithData = new FaithData();
		this.GameSettleData = GameController.ins.GameData.GameSettleData;
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			SYNCRandom.Rebuild(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day);
		}
		else
		{
			SYNCRandom.Rebuild(DateTime.Now.Millisecond);
		}
		GameController.getInstance().GameData.isInDungeon = true;
		GameController.ins.UIController.JournalsText.text = "";
		JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志12"), GlobalController.Instance.GlobalData.DungeonWinTimes, GameController.ins.GameData.Agreenment), null, null, null, null, null, null));
		GameController.ins.GameData.level = 1;
		DungeonController.Instance.GameSettleData.totalTime = DateTime.UtcNow;
		GlobalController.Instance.GlobalData.DungeonWinTimes++;
		GameController.getInstance().GameData.Money = 0;
		switch (GlobalController.Instance.AdvanceDataController.GetEWaiJinBi())
		{
		case 1:
			GameController.getInstance().GameData.Money = 85;
			break;
		case 2:
			GameController.getInstance().GameData.Money = 90;
			break;
		case 3:
			GameController.getInstance().GameData.Money = 95;
			break;
		case 4:
			GameController.getInstance().GameData.Money = 100;
			break;
		}
		GameController.ins.GameData.StepInDungeon = 0;
		GameController.ins.GameData.TorchNum = 20;
		switch (GlobalController.Instance.AdvanceDataController.GetHuoBa())
		{
		case 1:
			GameController.ins.GameData.TorchNum++;
			return;
		case 2:
			GameController.ins.GameData.TorchNum += 2;
			return;
		case 3:
			GameController.ins.GameData.TorchNum += 3;
			return;
		case 4:
			GameController.ins.GameData.TorchNum += 4;
			return;
		default:
			return;
		}
	}

	public void StartCOOPDungeon()
	{
		GameController.ins.GameData.GameSettleData = new GameSettleData();
		this.GameSettleData = GameController.ins.GameData.GameSettleData;
		GameController.getInstance().GameData.isInDungeon = true;
		DungeonController.Instance.GameSettleData.totalTime = DateTime.UtcNow;
		GlobalController.Instance.GlobalData.DungeonWinTimes++;
		GameController.getInstance().GameData.Money = 0;
		GameController.getInstance().InitCOOPPlayerTable();
		GameController.ins.GameData.StepInDungeon = 0;
		GameController.getInstance().gameObject.AddComponent<ResponseMultiPlayMsgManager>();
	}

	public void StartVSDungeon()
	{
		GameController.ins.GameData.GameSettleData = new GameSettleData();
		this.GameSettleData = GameController.ins.GameData.GameSettleData;
		GameController.getInstance().GameData.isInDungeon = true;
		DungeonController.Instance.GameSettleData.totalTime = DateTime.UtcNow;
		GlobalController.Instance.GlobalData.DungeonWinTimes++;
		GameController.getInstance().GameData.Money = 0;
		GameController.getInstance().InitVSPlayerTable();
		GameController.ins.GameData.StepInDungeon = 0;
		GameController.getInstance().gameObject.AddComponent<ResponseVSPlayMsgManager>();
	}

	public bool IsCurrentDungeonSlot(CardSlotData slotData)
	{
		return this.CurrentDungeonLogic.Data.CardSlotDatas.Contains(slotData);
	}

	public IEnumerator GameOver(bool isWin = false)
	{
		UIController.LockLevel = UIController.UILevel.All;
		GameController.ins.UIController.LogPanel.CloseLogBtn();
		GameController.ins.GameData.isInDungeon = false;
		GlobalController.Instance.IsLoadGame = false;
		GameController.ins.DeleteAllSaveData();
		if (!isWin)
		{
			Camera.main.GetComponent<CameraEffect>().NameText.text = "Game Over";
			Camera.main.GetComponent<CameraEffect>().DescText.text = "";
			Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
			yield return base.StartCoroutine(Camera.main.GetComponent<CameraEffect>().GameOver());
		}
		else
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_22"), 1f, 2f, 1f, 1f);
			GlobalController.Instance.ChangeTwistedEggCoupon(1);
			GlobalController.Instance.LogDataController.CreateLogDataInfo(GameController.ins.GameData.DungeonGUID, GameController.ins.GameData.JournalsList);
			if (GameController.ins.GameData.InnerMinionCardData != null)
			{
				GameController.ins.GameData.InnerMinionCardData.Rare++;
				GameController.ins.GameData.InnerMinionCardData = null;
			}
			if (GameController.ins.GameData.Agreenment == 10)
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_dashi);
			}
		}
		DungeonController.Instance.GameSettleData.FinalFloor = GameController.ins.GameData.level;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LocalizationMgr.Instance.GetLocalizationWord("UI_总层数") + ":" + DungeonController.Instance.GameSettleData.FinalFloor.ToString());
		TimeSpan timeSpan = DateTime.UtcNow - DungeonController.Instance.GameSettleData.totalTime;
		stringBuilder.Append(string.Concat(new string[]
		{
			"\n",
			LocalizationMgr.Instance.GetLocalizationWord("UI_总时长"),
			":",
			timeSpan.Hours.ToString(),
			":",
			timeSpan.Minutes.ToString(),
			":",
			timeSpan.Seconds.ToString()
		}));
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_总伤害") + ":" + DungeonController.Instance.GameSettleData.totalPhysicsDmg.ToString());
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_回合数") + ":" + DungeonController.Instance.GameSettleData.Turns.ToString());
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_获取金币") + ":" + DungeonController.Instance.GameSettleData.money.ToString());
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_击杀数") + ":" + DungeonController.Instance.GameSettleData.KillNum.ToString());
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_招募随从") + ":" + DungeonController.Instance.GameSettleData.GetMinionNum.ToString());
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_牺牲随从") + ":" + DungeonController.Instance.GameSettleData.DeathMinionNum.ToString());
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("UI_击杀Boss") + ":" + DungeonController.Instance.GameSettleData.KillBossNum.ToString());
		GameController.ins.UIController.FinalLabel.text = stringBuilder.ToString();
		if (GameController.ins.GameData.DungeonTheme == DungeonTheme.Normal)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/排行榜/LeaderBoard"));
			gameObject.transform.SetParent(GameController.ins.UIController.FullScreenCanvasTrans.transform, false);
			if (GameController.ins.GameData.isFake)
			{
				gameObject.GetComponent<LeaderBoardUIWindow>().Score = 0;
			}
			else
			{
				gameObject.GetComponent<LeaderBoardUIWindow>().Score = GameController.ins.GameData.level;
			}
			while (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject())
			{
				yield return null;
			}
		}
		List<GameObject> showCardList = new List<GameObject>();
		GainsItemData gainsItemData = new GainsItemData();
		int num = 0;
		int num2 = 0;
		if (GameController.ins.GameData.GameSettleData.KilledMonsterIDList != null)
		{
			foreach (string modId in GameController.ins.GameData.GameSettleData.KilledMonsterIDList)
			{
				int level = GameController.ins.CardDataModMap.getCardDataByModID(modId).Level;
				GameController.ins.CardDataModMap.getCardDataByModID(modId).HasTag(TagMap.BOSS);
				showCardList.Add(Card.InitWithOutData(GameController.ins.CardDataModMap.getCardDataByModID(modId), true));
				showCardList[showCardList.Count - 1].transform.position = new Vector3(9999f, 0f, 0f);
			}
		}
		if (num > 0)
		{
			gainsItemData.ModID = "能量卡片";
			gainsItemData.Count = num;
			gainsItemData.Source = GainsItemData.SourceType.KillElite;
			GameController.ins.GameData.GameSettleData.GainItems.Add(gainsItemData);
		}
		if (num2 > 0)
		{
			gainsItemData.ModID = "能量卡片";
			gainsItemData.Count = num2;
			gainsItemData.Source = GainsItemData.SourceType.KillBoss;
			GameController.ins.GameData.GameSettleData.GainItems.Add(gainsItemData);
		}
		if (GameController.ins.GameData.FaithData.AoMi == 3)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_29"), 1f, 2f, 1f, 1f);
			GameController.ins.UIController.ShowHadItemTable();
			while (!GameController.ins.GameData.FaithData.IsTakeItem)
			{
				yield return 1;
			}
		}
		yield return Camera.main.transform.DOMove(GameController.ins.UIController.SettleCamerTrans.position, 1f, false);
		GameController.ins.UICamera.enabled = false;
		yield return Camera.main.transform.DORotate(GameController.ins.UIController.SettleCamerTrans.rotation.eulerAngles, 1f, RotateMode.Fast);
		Vector3 startPos = GameController.ins.UIController.FinalCardListStartTransform.position;
		if (showCardList != null)
		{
			int num3;
			for (int i = 0; i < showCardList.Count; i = num3 + 1)
			{
				showCardList[i].transform.position = startPos + Vector3.right * ((float)(i % 25) * 0.5f) + Vector3.back * ((float)(i / 25) * 0.5f);
				showCardList[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				showCardList[i].transform.DOShakeRotation(0.1f, 90f, 10, 90f, true);
				yield return new WaitForSeconds(0.1f);
				num3 = i;
			}
		}
		while (!Input.GetMouseButtonDown(0))
		{
			yield return null;
		}
		if (GameController.ins.GameData.GameSettleData.GainItems.Count > 0)
		{
			GameObject Bigbox = GameController.ins.UIController.BigBox;
			Bigbox.SetActive(true);
			yield return Bigbox.transform.DOMove(new Vector3(-9.97f, 0f, -2.31f), 0.5f, false).WaitForCompletion();
			Bigbox.GetComponentInChildren<ParticleSystem>().Play();
			EffectAudioManager.Instance.PlayEffectAudio(22, null);
			yield return new WaitForSeconds(1f);
			Bigbox.GetComponent<Animator>().SetTrigger("play");
			EffectAudioManager.Instance.PlayEffectAudio(23, null);
			yield return new WaitForSeconds(0.5f);
			foreach (GainsItemData unlockID in GameController.ins.GameData.GameSettleData.GainItems)
			{
				if (unlockID != null && unlockID.ModID != null)
				{
					GameObject go = null;
					if (!string.IsNullOrEmpty(unlockID.ModID))
					{
						go = Card.InitWithOutData(GameController.getInstance().CardDataModMap.getCardDataByModID(unlockID.ModID), true);
						go.transform.position = new Vector3(0.2f, 0f, -2.31f);
						go.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
						go.transform.DORotate(new Vector3(21.392f, -90f, 0f), 0.5f, RotateMode.Fast);
						go.transform.DOScale(Vector3.one, 0.5f);
						go.transform.DOMoveZ(-7.7f, 0.5f, false).SetEase(Ease.InExpo);
						yield return go.transform.DOMoveY(6.3f, 0.5f, false).WaitForCompletion();
					}
					GameObject unlockPanel = UnityEngine.Object.Instantiate<GameObject>(ResourceManager.Instance.LoadResource("UI/Canvas/UnlockPanel"));
					unlockPanel.GetComponentInChildren<SpaceProgressBarTool>().gameObject.SetActive(false);
					unlockPanel.transform.localScale = new Vector3(1f, 0.01f, 1f);
					string text = "";
					switch (unlockID.Source)
					{
					case GainsItemData.SourceType.KillBoss:
						text = "通过击杀Boss 获得 " + GameController.getInstance().CardDataModMap.getCardDataByModID(unlockID.ModID).ModID + ((unlockID.Count > 0) ? ("x" + unlockID.Count.ToString()) : "");
						if (!string.IsNullOrEmpty(unlockID.DESC))
						{
							text += unlockID.DESC;
						}
						break;
					case GainsItemData.SourceType.PassFloor:
						text = string.Concat(new string[]
						{
							"共通过",
							(DungeonController.Instance.GameSettleData.FinalFloor - 1).ToString(),
							"层获得 ",
							GameController.getInstance().CardDataModMap.getCardDataByModID(unlockID.ModID).ModID,
							(unlockID.Count > 0) ? ("x" + unlockID.Count.ToString()) : ""
						});
						if (!string.IsNullOrEmpty(unlockID.DESC))
						{
							text += unlockID.DESC;
						}
						break;
					case GainsItemData.SourceType.KillElite:
						text = "通过击杀精英 获得 " + GameController.getInstance().CardDataModMap.getCardDataByModID(unlockID.ModID).ModID + ((unlockID.Count > 0) ? ("x" + unlockID.Count.ToString()) : "");
						if (!string.IsNullOrEmpty(unlockID.DESC))
						{
							text += unlockID.DESC;
						}
						break;
					case GainsItemData.SourceType.Event:
						text = "通过事件 获得 " + GameController.getInstance().CardDataModMap.getCardDataByModID(unlockID.ModID).ModID + ((unlockID.Count > 0) ? ("x" + unlockID.Count.ToString()) : "");
						if (!string.IsNullOrEmpty(unlockID.DESC))
						{
							text += unlockID.DESC;
						}
						break;
					case GainsItemData.SourceType.Win:
						text = "你解锁了一个随从！它偶尔会光顾你的酒馆。";
						break;
					case GainsItemData.SourceType.Other:
						if (!string.IsNullOrEmpty(unlockID.DESC))
						{
							text += unlockID.DESC;
						}
						break;
					}
					unlockPanel.GetComponentInChildren<TextMeshProUGUI>().text = text;
					yield return unlockPanel.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack).WaitForCompletion();
					if (go != null)
					{
						go.AddComponent<MK.Glow.Example.RotateObject>()._rotation = new Vector3(0f, 0f, 60f);
					}
					CardData cardData = Card.InitCardDataByID(unlockID.ModID);
					if (!cardData.HasTag(TagMap.随从))
					{
						List<CardSlotData> playerTableCardSlotDatasToHomeData = GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData();
						bool flag = false;
						foreach (CardSlotData cardSlotData in playerTableCardSlotDatasToHomeData)
						{
							if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID == unlockID.ModID)
							{
								cardSlotData.ChildCardData.Count += unlockID.Count;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							using (List<CardSlotData>.Enumerator enumerator3 = playerTableCardSlotDatasToHomeData.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									CardSlotData cardSlotData2 = enumerator3.Current;
									if (cardSlotData2.ChildCardData == null)
									{
										cardSlotData2.ChildCardData = cardData;
										cardSlotData2.ChildCardData.Count = unlockID.Count;
										break;
									}
								}
								goto IL_10A4;
							}
							goto IL_1086;
						}
					}
					IL_10A4:
					if (Input.GetMouseButtonDown(0))
					{
						UnityEngine.Object.DestroyImmediate(unlockPanel.gameObject);
						if (go != null)
						{
							UnityEngine.Object.DestroyImmediate(go.gameObject);
						}
						go = null;
						unlockPanel = null;
						goto IL_10E8;
					}
					IL_1086:
					yield return null;
					goto IL_10A4;
				}
				IL_10E8:
				unlockID = null;
			}
			List<GainsItemData>.Enumerator enumerator2 = default(List<GainsItemData>.Enumerator);
			Bigbox = null;
		}
		GameController.ins.GameData.isInDungeon = false;
		while (!Input.GetMouseButtonDown(0))
		{
			yield return null;
		}
		foreach (KeyValuePair<string, AreaData> keyValuePair in GlobalController.Instance.HomeDataController.info.PhysicsAreaData)
		{
			if (keyValuePair.Value.Logics != null)
			{
				foreach (AreaLogic areaLogic in keyValuePair.Value.Logics)
				{
					areaLogic.OnDayPass();
				}
			}
		}
		if (isWin)
		{
			if (GameController.ins.GameData.Agreenment == GlobalController.Instance.GetContractLevelByHeroModID(GameController.getInstance().GameData.StartHeroModID))
			{
				GlobalController.Instance.SetContractLevelByHeroModID(GameController.getInstance().GameData.StartHeroModID, GlobalController.Instance.GetContractLevelByHeroModID(GameController.getInstance().GameData.StartHeroModID) + 1);
			}
			GlobalController.Instance.SaveGlobalData();
			GameController.getInstance().UIController.ShowBlackMask(delegate
			{
				AreaData areaData = GameController.getInstance().GameData.AreaMap["PaiPai"];
				areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
				GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
				GameController.getInstance().OnTableChange(areaData, true);
			}, 0.5f);
		}
		else
		{
			GlobalController.Instance.SaveGlobalData();
			GameController.getInstance().UIController.ShowBlackMask(delegate
			{
				SceneManager.LoadScene("Main");
			}, 0.5f);
		}
		yield break;
		yield break;
	}

	public IEnumerator GetAndPickTheFlipedCards(List<CardData> cards, bool callEvent = true)
	{
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if (cardData != null)
			{
				if (cardData.ActDatas != null && cardData.ActDatas.Count > 0)
				{
					list.Add(cardData);
				}
				if (cardData.HasTag(TagMap.怪物))
				{
					list2.Add(cardData);
				}
			}
		}
		UIController.LockLevel = UIController.UILevel.All;
		yield return this.AfterFlipCardsCorotine(list, list2, callEvent);
		yield break;
	}

	private IEnumerator AfterFlipCardsCorotine(List<CardData> acts, List<CardData> enemies, bool callEvent = true)
	{
		yield return null;
		UIController.LockLevel = UIController.UILevel.All;
		int num;
		for (int i = 0; i < acts.Count; i = num + 1)
		{
			int j = 0;
			while (j < acts[i].ActDatas.Count)
			{
				Sequence sequence = DOTween.Sequence();
				try
				{
					sequence.Append(acts[i].CardGameObject.transform.DOLocalMoveY(2f, 0.3f, false));
					sequence.Append(acts[i].CardGameObject.transform.DOShakePosition(1f, new Vector3(0.2f, 0f, 0.2f), 100, 90f, false, true).SetEase(Ease.OutCubic));
				}
				catch (Exception)
				{
					Debug.LogError(acts[i].ModID + ":卡牌没有实体！");
				}
				yield return sequence.Play<Sequence>().WaitForCompletion();
				yield return new WaitForSeconds(0.1f);
				while (GameController.getInstance().CurrentAct != null)
				{
					yield return 0;
				}
				try
				{
					acts[i].CardGameObject.StartAct(acts[i].ActDatas[j]);
					goto IL_230;
				}
				catch (Exception)
				{
					Debug.LogError(acts[i].ModID + ":卡牌没有实体！");
					goto IL_230;
				}
				goto IL_20F;
				IL_230:
				if (!(GameController.getInstance().CurrentAct != null))
				{
					num = j;
					j = num + 1;
					continue;
				}
				IL_20F:
				yield return 0;
				goto IL_230;
			}
			num = i;
		}
		if (acts.Count == 0)
		{
			UIController.LockLevel = UIController.UILevel.None;
		}
		foreach (CardData origin in enemies)
		{
			yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(origin, callEvent);
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}

	public static DungeonController Instance;

	public Transform Chessman;

	public List<BrookAreaLogic> DungeonLogic = new List<BrookAreaLogic>();

	public BrookAreaLogic CurrentDungeonLogic;

	public GameSettleData GameSettleData;

	public Hero m_Hero;

	public bool IsSelectedMinionAndScenes;

	public int BattleLevel;
}
