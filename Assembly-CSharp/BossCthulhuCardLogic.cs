using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCthulhuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			yield return this.ChangeColorB();
			UnityEngine.Object.FindObjectOfType<BossCSLArea>().Boss.GetComponent<Animator>().SetTrigger("Die");
			if (GameController.ins.GameData.Agreenment < 10)
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_shenhualieshou);
			}
			else
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhongjishenhualieshou);
			}
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData != this.CardData && player == cardSlotData.ChildCardData)
			{
				cardSlotData.ChildCardData.CardGameObject.transform.GetComponentInChildren<Animator>().SetTrigger("BeAttack");
			}
		}
		if (player == this.CardData && changedValue <= 0 && !DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			UnityEngine.Object.FindObjectOfType<BossCSLArea>().Boss.GetComponentInChildren<Animator>().SetTrigger("BeAttacked");
		}
		if ((float)this.CardData.HP <= (float)this.CardData.MaxHP * 0.4f)
		{
			if (this.CurType >= 2)
			{
				yield break;
			}
			yield return base.ShowMePlus("！！！");
			yield return base.ShowXuLiEffect("居合释放", false);
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
			this.ChangeCthulhuType(2);
			this.CurType = 2;
		}
		else
		{
			if (this.CurType >= 1)
			{
				yield break;
			}
			this.ChangeCthulhuType(1);
			this.CurType = 1;
		}
		yield break;
	}

	public override IEnumerator OnEnterArea(string areaID)
	{
		if (areaID.Equals("BossCthulhu"))
		{
			if (this.CurType >= 1)
			{
				yield break;
			}
			this.ChangeCthulhuType(1);
			this.CurType = 1;
			this.CardData = DungeonOperationMgr.Instance.InitDungeonMonster(this.CardData, 30);
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		int num = 1;
		this.playerSlots = base.GetEnemiesBattleArea();
		for (int i = 0; i < num; i++)
		{
			CardSlotData item = this.playerSlots[SYNCRandom.Range(0, this.playerSlots.Count)];
			this.targetSlots.Add(item);
		}
		if (this.targetSlots.Count > 0)
		{
			foreach (CardSlotData cardSlotData in this.targetSlots)
			{
				string name = "Effect/Insight_white";
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
				particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
				this.particleList.Add(particleObject);
			}
		}
		List<CardData> allHurtedMinions = base.GetAllHurtedMinions();
		if (allHurtedMinions.Count == 0)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in allHurtedMinions)
		{
			int num2 = Mathf.CeilToInt((float)cardData.HP / (float)cardData.MaxHP * 120f);
			if (SYNCRandom.Range(1, 101) > num2)
			{
				list.Add(cardData);
			}
		}
		base.ShowLogic("ah hlirgh.vulgtagln ya.y-yar.shogg..h'hah");
		if (list.Count == 0)
		{
			yield break;
		}
		using (List<CardData>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				CardData cardData2 = enumerator2.Current;
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					List<string> list2 = new List<string>();
					if (base.GetLogic(cardData2, typeof(Logic_FaFeng)) == null)
					{
						list2.Add("Logic_FaFeng");
					}
					if (base.GetLogic(cardData2, typeof(Logic_BuGaoXing)) == null)
					{
						list2.Add("Logic_BuGaoXing");
					}
					if (base.GetLogic(cardData2, typeof(Logic_ZiCan)) == null)
					{
						list2.Add("Logic_ZiCan");
					}
					if (base.GetLogic(cardData2, typeof(Logic_BuZhong)) == null)
					{
						list2.Add("Logic_BuZhong");
					}
					if (list2.Count != 0)
					{
						PersonCardLogic personCardLogic = Activator.CreateInstance(Type.GetType(list2[SYNCRandom.Range(0, list2.Count)])) as PersonCardLogic;
						cardData2.CardLogics.Add(personCardLogic);
						personCardLogic.CardData = cardData2;
						personCardLogic.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_脑海低语");
						personCardLogic.Init();
						personCardLogic.OnMerge(cardData2);
						base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_呃啊"), cardData2);
					}
				}
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			if (this.particleList.Count > 0)
			{
				foreach (ParticleObject particle in this.particleList)
				{
					ParticlePoolManager.Instance.UnSpawn(particle);
				}
			}
			this.particleList.Clear();
			if (this.targetSlots.Count > 0)
			{
				foreach (CardSlotData cardSlotData in this.targetSlots)
				{
					if (cardSlotData != null && !DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData) && cardSlotData.ChildCardData.HasTag(TagMap.随从))
					{
						CardData t = cardSlotData.ChildCardData;
						if (base.GetLogic(t, typeof(Logic_FaFeng)) != null)
						{
							t.RemoveCardLogic(base.GetLogic(t, typeof(Logic_FaFeng)));
						}
						if (base.GetLogic(t, typeof(Logic_BuGaoXing)) != null)
						{
							t.RemoveCardLogic(base.GetLogic(t, typeof(Logic_BuGaoXing)));
						}
						if (base.GetLogic(t, typeof(Logic_ZiCan)) != null)
						{
							t.RemoveCardLogic(base.GetLogic(t, typeof(Logic_ZiCan)));
						}
						if (base.GetLogic(t, typeof(Logic_BuZhong)) != null)
						{
							t.RemoveCardLogic(base.GetLogic(t, typeof(Logic_BuZhong)));
						}
						yield return base.Cure(t, 0, t);
						base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_舒服多了"), t);
						t = null;
					}
				}
				List<CardSlotData>.Enumerator enumerator2 = default(List<CardSlotData>.Enumerator);
			}
			this.targetSlots.Clear();
		}
		yield break;
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		int num = 1;
		this.playerSlots = base.GetEnemiesBattleArea();
		for (int i = 0; i < num; i++)
		{
			CardSlotData item = this.playerSlots[SYNCRandom.Range(0, this.playerSlots.Count)];
			this.targetSlots.Add(item);
		}
		if (this.targetSlots.Count > 0)
		{
			foreach (CardSlotData cardSlotData in this.targetSlots)
			{
				string name = "Effect/Insight_white";
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
				particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
				this.particleList.Add(particleObject);
			}
		}
		List<CardData> allHurtedMinions = base.GetAllHurtedMinions();
		if (allHurtedMinions.Count == 0)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in allHurtedMinions)
		{
			int num2 = Mathf.CeilToInt((float)cardData.HP / (float)cardData.MaxHP * 150f);
			if (SYNCRandom.Range(1, 101) > num2)
			{
				list.Add(cardData);
			}
		}
		base.ShowLogic("Sa La'Dia MuSi'hwa....");
		if (list.Count == 0)
		{
			yield break;
		}
		using (List<CardData>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				CardData cardData2 = enumerator2.Current;
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					List<string> list2 = new List<string>();
					if (base.GetLogic(cardData2, typeof(Logic_FaFeng)) == null)
					{
						list2.Add("Logic_FaFeng");
					}
					if (base.GetLogic(cardData2, typeof(Logic_BuGaoXing)) == null)
					{
						list2.Add("Logic_BuGaoXing");
					}
					if (base.GetLogic(cardData2, typeof(Logic_ZiCan)) == null)
					{
						list2.Add("Logic_ZiCan");
					}
					if (base.GetLogic(cardData2, typeof(Logic_BuZhong)) == null)
					{
						list2.Add("Logic_BuZhong");
					}
					if (list2.Count != 0)
					{
						PersonCardLogic personCardLogic = Activator.CreateInstance(Type.GetType(list2[SYNCRandom.Range(0, list2.Count)])) as PersonCardLogic;
						cardData2.CardLogics.Add(personCardLogic);
						personCardLogic.CardData = cardData2;
						personCardLogic.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_脑海低语");
						personCardLogic.Init();
						personCardLogic.OnMerge(cardData2);
						base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_呃啊"), cardData2);
					}
				}
			}
			yield break;
		}
		yield break;
	}

	private void ChangeCthulhuType(int type)
	{
		if (type != 1)
		{
			if (type != 2)
			{
				return;
			}
			UnityEngine.Object.FindObjectOfType<BossCSLArea>().Boss.GetComponentInChildren<Animator>().SetTrigger("Rage");
			GameController.ins.StartCoroutine(this.ChangeColorN());
			if (this.CardData.HasAffix(DungeonAffix.poisoning))
			{
				this.CardData.RemoveAffix(DungeonAffix.poisoning);
			}
			if (this.CardData.HasAffix(DungeonAffix.bleeding))
			{
				this.CardData.RemoveAffix(DungeonAffix.bleeding);
			}
			if (this.CardData.HasAffix(DungeonAffix.frail))
			{
				this.CardData.RemoveAffix(DungeonAffix.frail);
			}
			if (this.CardData.HasAffix(DungeonAffix.weak))
			{
				this.CardData.RemoveAffix(DungeonAffix.weak);
			}
			this.CardData._ATK += 3;
			if (base.GetLogic(this.CardData, typeof(JingShenKuiShiCardLogic)) == null)
			{
				base.GetLogic(this.CardData, typeof(JingShenKuiShiCardLogic)).Layers++;
			}
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_精神窥视"));
			if (base.GetLogic(this.CardData, typeof(ZheMoCardLogic)) == null)
			{
				this.CardData.AddLogic("ZheMoCardLogic", 1);
			}
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
				CardSlotData cardSlotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
				CardData cardData = Card.InitCardDataByID("克苏鲁触手");
				cardData = DungeonOperationMgr.Instance.InitDungeonMonster(cardData, 25);
				cardData.PutInSlotData(cardSlotData, true);
				string name = "Effect/WaterBall";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = cardSlotData.ChildCardData.CardGameObject.transform.position;
			}
			if (base.GetLogic(this.CardData, typeof(JingShenKuiShiCardLogic)) == null)
			{
				this.CardData.AddLogic("JingShenKuiShiCardLogic", 1);
			}
			if (base.GetLogic(this.CardData, typeof(XieEZhanFangCardLogic)) == null)
			{
				this.CardData.AddLogic("XieEZhanFangCardLogic", 0);
				return;
			}
		}
	}

	private IEnumerator ChangeColorN()
	{
		float intensity = 0f;
		Color c = UnityEngine.Object.FindObjectOfType<BossCSLArea>().OldEyeColor;
		Material i = UnityEngine.Object.FindObjectOfType<BossCSLArea>().CTLeMaterial;
		while (intensity < 15f)
		{
			float num = Mathf.Pow(2f, intensity);
			Color value = new Color(c.r * num, c.g * num, c.b * num);
			i.SetColor("_EmissionColor", value);
			intensity += 1f;
			yield return new WaitForSeconds(0.033333335f);
		}
		Color value2 = new Color(c.r * Mathf.Pow(2f, 15f), c.g * Mathf.Pow(2f, 15f), c.b * Mathf.Pow(2f, 15f));
		i.SetColor("_EmissionColor", value2);
		yield break;
	}

	private IEnumerator ChangeColorB()
	{
		float intensity = 20f;
		Color c = UnityEngine.Object.FindObjectOfType<BossCSLArea>().OldEyeColor;
		Material i = UnityEngine.Object.FindObjectOfType<BossCSLArea>().CTLeMaterial;
		while (intensity > 0f)
		{
			float num = Mathf.Pow(2f, intensity);
			Color value = new Color(c.r * num, c.g * num, c.b * num);
			i.SetColor("_EmissionColor", value);
			intensity -= 1f;
			yield return new WaitForSeconds(0.025f);
		}
		Color value2 = new Color(c.r * Mathf.Pow(2f, 0f), c.g * Mathf.Pow(2f, 0f), c.b * Mathf.Pow(2f, 0f));
		i.SetColor("_EmissionColor", value2);
		yield break;
	}

	public int CurType;

	private List<CardSlotData> playerSlots = new List<CardSlotData>();

	private List<CardSlotData> targetSlots = new List<CardSlotData>();

	private List<ParticleObject> particleList = new List<ParticleObject>();
}
