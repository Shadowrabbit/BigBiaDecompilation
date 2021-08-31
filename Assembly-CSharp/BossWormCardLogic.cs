using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossWormCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.CurType = 1;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("Die");
			yield break;
		}
		if (target == this.LockedTarget && this.CurType == 2)
		{
			yield return this.ChangeWormType(3, true);
		}
		if (base.GetAllCurrentMonsters().Count == 0 && this.CurType == 3)
		{
			this.ChangeWormType(1, true);
		}
		yield break;
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (this.CurType == 2 && value.value < 0 && player == this.CardData)
		{
			value.value *= 2;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue <= 0 && !DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("BeAttacked");
		}
		if (player == this.CardData && this.CurType == 1 && changedValue <= -3)
		{
			this.OpenEyeCount++;
			GameController.ins.UIController.AreaTabooDesc.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("T_36"),
				" - ",
				LocalizationMgr.Instance.GetLocalizationWord("T_白胖禁忌1"),
				"\n<size=16>\n ",
				string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_白胖禁忌3"), 12 - this.OpenEyeCount),
				"</size>"
			});
			if (this.OpenEyeCount == 4)
			{
				UnityEngine.Object.FindObjectOfType<BossWarmArea>().BossEye.GetComponent<Animator>().SetTrigger("Open1");
			}
			if (this.OpenEyeCount == 8)
			{
				UnityEngine.Object.FindObjectOfType<BossWarmArea>().BossEye.GetComponent<Animator>().SetTrigger("Open2");
			}
			if (this.OpenEyeCount >= 12)
			{
				this.OpenEyeCount = 0;
				if (from == null)
				{
					List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
					from = allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)];
				}
				this.LockedTarget = from;
				if (this.line != null)
				{
					UVChainLightning component = this.line.GetComponent<UVChainLightning>();
					component.target = this.LockedTarget;
					component.gameObject.SetActive(true);
				}
				else
				{
					this.line = this.GetChainLighting(this.CardData, this.LockedTarget);
				}
				yield return this.ChangeWormType(2, true);
			}
			yield break;
		}
		if (this.CurType == 2 && ((this.CardData.HP <= Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f) && this.CardData.HP - changedValue > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.75f)) || (this.CardData.HP <= Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f) && this.CardData.HP - changedValue > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.5f)) || (this.CardData.HP <= Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f) && this.CardData.HP - changedValue > Mathf.CeilToInt((float)this.CardData.MaxHP * 0.25f))))
		{
			yield return this.ChangeWormType(3, true);
		}
		yield break;
	}

	public override IEnumerator OnEnterArea(string areaID)
	{
		if (areaID.Equals("BossWorm"))
		{
			this.CardData = DungeonOperationMgr.Instance.InitDungeonMonster(this.CardData, 30);
			UnityEngine.Object.FindObjectOfType<BossWarmArea>().BossEye.GetComponent<Animator>().SetTrigger("Close");
			yield return this.ChangeWormType(1, false);
			yield break;
		}
		yield break;
	}

	private GameObject GetChainLighting(CardData from, CardData to)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainPosLine"));
		UVChainLightning component = gameObject.GetComponent<UVChainLightning>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
		return gameObject;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (this.CurType == 1 || this.CurType == 0)
		{
			if (base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)));
			}
			switch (SYNCRandom.Range(0, 3))
			{
			case 0:
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖1"));
				this.CardData.AddLogic("PenTuSuanYeCardLogic", 0);
				yield return null;
				PenTuSuanYeCardLogic penTuSuanYeCardLogic = base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)) as PenTuSuanYeCardLogic;
				yield return penTuSuanYeCardLogic.OnTurnStart();
				break;
			}
			case 1:
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖2"));
				this.CardData.AddLogic("SuanYePaoCardLogic", 0);
				yield return null;
				SuanYePaoCardLogic suanYePaoCardLogic = base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)) as SuanYePaoCardLogic;
				yield return suanYePaoCardLogic.OnTurnStart();
				break;
			}
			case 2:
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖3"));
				this.CardData.AddLogic("WeiSheDeYuGuangCardLogic", 0);
				yield return null;
				WeiSheDeYuGuangCardLogic weiSheDeYuGuangCardLogic = base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)) as WeiSheDeYuGuangCardLogic;
				yield return weiSheDeYuGuangCardLogic.OnTurnStart();
				break;
			}
			}
		}
		if (this.CurType == 2)
		{
			if (base.GetLogic(this.CardData, typeof(TongJiCardLogic)) != null && (base.GetLogic(this.CardData, typeof(TongJiCardLogic)) as TongJiCardLogic).Count > 0)
			{
				yield break;
			}
			if (base.GetLogic(this.CardData, typeof(YanShenSuoDingCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(YanShenSuoDingCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(TongJiCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(TongJiCardLogic)));
			}
			int num = SYNCRandom.Range(0, 2);
			if (num != 0)
			{
				if (num == 1)
				{
					base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖5"));
					this.CardData.AddLogic("TongJiCardLogic", 0);
					yield return null;
					TongJiCardLogic tongJiCardLogic = base.GetLogic(this.CardData, typeof(TongJiCardLogic)) as TongJiCardLogic;
					yield return tongJiCardLogic.OnTurnStart();
				}
			}
			else
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖4"));
				this.CardData.AddLogic("YanShenSuoDingCardLogic", 0);
			}
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (this.CurType == 1 || this.CurType == 0)
		{
			if (base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)));
			}
			switch (SYNCRandom.Range(0, 2))
			{
			case 0:
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖1"));
				this.CardData.AddLogic("PenTuSuanYeCardLogic", 0);
				yield return null;
				PenTuSuanYeCardLogic penTuSuanYeCardLogic = base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)) as PenTuSuanYeCardLogic;
				yield return penTuSuanYeCardLogic.OnTurnStart();
				break;
			}
			case 1:
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖2"));
				this.CardData.AddLogic("SuanYePaoCardLogic", 0);
				yield return null;
				SuanYePaoCardLogic suanYePaoCardLogic = base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)) as SuanYePaoCardLogic;
				yield return suanYePaoCardLogic.OnTurnStart();
				break;
			}
			case 2:
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖3"));
				this.CardData.AddLogic("WeiSheDeYuGuangCardLogic", 0);
				yield return null;
				WeiSheDeYuGuangCardLogic weiSheDeYuGuangCardLogic = base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)) as WeiSheDeYuGuangCardLogic;
				yield return weiSheDeYuGuangCardLogic.OnTurnStart();
				break;
			}
			}
		}
		if (this.CurType == 2)
		{
			if (base.GetLogic(this.CardData, typeof(TongJiCardLogic)) != null)
			{
				TongJiCardLogic tongJiCardLogic = base.GetLogic(this.CardData, typeof(TongJiCardLogic)) as TongJiCardLogic;
				if (!tongJiCardLogic.CanAttack)
				{
					tongJiCardLogic.CanAttack = true;
					yield break;
				}
			}
			if (base.GetLogic(this.CardData, typeof(YanShenSuoDingCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(YanShenSuoDingCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(TongJiCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(TongJiCardLogic)));
			}
			int num = SYNCRandom.Range(0, 2);
			if (num != 0)
			{
				if (num == 1)
				{
					base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖5"));
					this.CardData.AddLogic("TongJiCardLogic", 0);
					yield return null;
					TongJiCardLogic tongJiCardLogic2 = base.GetLogic(this.CardData, typeof(TongJiCardLogic)) as TongJiCardLogic;
					yield return tongJiCardLogic2.OnTurnStart();
				}
			}
			else
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖4"));
				this.CardData.AddLogic("YanShenSuoDingCardLogic", 0);
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn && this.CurType == 3)
		{
			this.BackCount++;
			if (this.BackCount >= 3)
			{
				this.BackCount = 0;
				yield return this.ChangeWormType(1, true);
			}
		}
		yield break;
	}

	private IEnumerator ChangeWormType(int type, bool isAnimate = true)
	{
		switch (type)
		{
		case 1:
			if (base.GetLogic(this.CardData, typeof(LiaoYuCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(LiaoYuCardLogic)));
			}
			if (this.CurType == 3)
			{
				if (base.GetLogic(this.CardData, typeof(LiaoYuCardLogic)) != null)
				{
					this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(LiaoYuCardLogic)));
				}
				DungeonOperationMgr.Instance.StartCoroutine(base.ShowCustomEffect("沙之祭祀释放", this.CardData.CurrentCardSlotData, 1f));
				this.CardData.CardGameObject.gameObject.SetActive(true);
				UnityEngine.Object.FindObjectOfType<BossWarmArea>().BossEye.GetComponent<Animator>().SetTrigger("Close");
				UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("Back");
				this.CardData.CardTags = 268468224UL;
				List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
				if (allCurrentMonsters.Count > 1)
				{
					foreach (CardData cd in allCurrentMonsters)
					{
						if (!cd.HasTag(TagMap.BOSS) && !DungeonOperationMgr.Instance.CheckCardDead(cd))
						{
							Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
							yield return cd.CardGameObject.transform.DOJump(this.CardData.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
							yield return this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
							yield return this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
							yield return base.Cure(this.CardData, cd.HP, this.CardData);
							cd.DeleteCardData();
							oldScale = default(Vector3);
						}
						cd = null;
					}
					List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
				}
			}
			GameController.ins.UIController.AreaTabooDesc.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("T_36"),
				" - ",
				LocalizationMgr.Instance.GetLocalizationWord("T_白胖禁忌1"),
				"\n<size=16>\n ",
				string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_白胖禁忌3"), 12 - this.OpenEyeCount),
				"</size>"
			});
			this.CurType = 1;
			break;
		case 2:
			this.CurType = 2;
			if (base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)));
			}
			UnityEngine.Object.FindObjectOfType<BossWarmArea>().BossEye.GetComponent<Animator>().SetTrigger("Open3");
			yield return this.OnTurnStart();
			break;
		case 3:
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("SM_白胖1"));
			UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("Leave");
			if (base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(PenTuSuanYeCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(SuanYePaoCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(WeiSheDeYuGuangCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(YanShenSuoDingCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(YanShenSuoDingCardLogic)));
			}
			if (base.GetLogic(this.CardData, typeof(TongJiCardLogic)) != null)
			{
				this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(TongJiCardLogic)));
			}
			this.CardData.AddLogic("LiaoYuCardLogic", 0);
			DungeonOperationMgr.Instance.StartCoroutine(base.ShowCustomEffect("沙之祭祀释放", this.CardData.CurrentCardSlotData, 1f));
			this.CardData.CardGameObject.gameObject.SetActive(false);
			this.CardData.CardTags = 268435456UL;
			UnityEngine.Object.DestroyImmediate(this.line);
			this.line = null;
			this.LockedTarget = null;
			this.CurType = 3;
			for (int i = 0; i < 4; i++)
			{
				List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
				if (allEmptySlotsInMyBattleArea != null && allEmptySlotsInMyBattleArea.Count > 0)
				{
					CardSlotData slotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
					CardData cardData = Card.InitCardDataByID("幼虫");
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
			break;
		}
		yield break;
		yield break;
	}

	public int CurType;

	public int OpenEyeCount;

	public int BackCount;

	public CardData LockedTarget;

	public GameObject line;
}
