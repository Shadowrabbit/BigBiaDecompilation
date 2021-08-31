using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeRecoveryHp : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇8");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇8");
		this.m_ATK = 3;
		this.m_ATKTimes = 3;
		if (GameController.ins.GameData.Agreenment >= 5)
		{
			this.m_Count = 1;
		}
		if (GameController.ins.GameData.Agreenment >= 10)
		{
			this.m_Count = 2;
		}
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇8");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇8");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData && value.value < 0 && this.CardData.HP + value.value <= 0)
		{
			this.m_Count--;
			if (this.m_Count >= 0)
			{
				if (GameController.ins.GameData.Agreenment >= 4 && GameController.ins.GameData.Agreenment < 7)
				{
					string name = "Effect/Exile";
					ParticlePoolManager.Instance.Spawn(name, 2f).transform.position = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position;
					Camera.main.GetComponent<CameraEffect>().NameText.text = "第二阶段";
					Camera.main.GetComponent<CameraEffect>().DescText.text = "";
					Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
					this.ChangeSnakeType(2);
					value.value = 0;
				}
				else if (GameController.ins.GameData.Agreenment >= 7)
				{
					int count = this.m_Count;
					if (count != 0)
					{
						if (count == 1)
						{
							string name2 = "Effect/Exile";
							ParticlePoolManager.Instance.Spawn(name2, 2f).transform.position = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position;
							Camera.main.GetComponent<CameraEffect>().NameText.text = "第二阶段";
							Camera.main.GetComponent<CameraEffect>().DescText.text = "";
							Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
							this.ChangeSnakeType(2);
							value.value = 0;
						}
					}
					else
					{
						string name3 = "Effect/Exile";
						ParticlePoolManager.Instance.Spawn(name3, 2f).transform.position = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position;
						Camera.main.GetComponent<CameraEffect>().NameText.text = "第三阶段";
						Camera.main.GetComponent<CameraEffect>().DescText.text = "";
						Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
						this.ChangeSnakeType(3);
						value.value = 0;
					}
				}
			}
		}
		yield break;
	}

	private void ChangeSnakeType(int type)
	{
		switch (type)
		{
		case 1:
			this.CardData._ATK = 3;
			this.CardData._AttackTimes = 1;
			this.AddLogic("BossSnakeRecoveryHp");
			this.AddLogic("BossSnakeMakeRock");
			this.AddLogic("BossSnakeAOEAttack");
			return;
		case 2:
		{
			this.CardData._ATK = 4;
			this.CardData._AttackTimes = 2;
			this.CardData.HP = this.CardData.MaxHP;
			this.CardData.Armor = (this.CardData.MaxArmor = 4);
			List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
			for (int i = 0; i < 2; i++)
			{
				List<CardSlotData> list = new List<CardSlotData>();
				foreach (CardSlotData cardSlotData in battleArea)
				{
					if (cardSlotData.ChildCardData == null)
					{
						list.Add(cardSlotData);
					}
				}
				if (list.Count <= 0)
				{
					break;
				}
				int index = UnityEngine.Random.Range(0, list.Count);
				CardData cardData = CardData.CopyCardData(Card.InitCardDataByID("沙虫"), true);
				cardData.HP = (cardData.MaxHP = SYNCRandom.Range(35, 51));
				cardData._ATK = SYNCRandom.Range(5, 11);
				cardData.Armor = (cardData.MaxArmor = SYNCRandom.Range(0, 3));
				cardData.PutInSlotData(list[index], true);
			}
			this.AddLogic("BossSnakeCallTaunt");
			return;
		}
		case 3:
		{
			this.RemoveLogic("BossSnakeCallTaunt");
			this.CardData._ATK = 4;
			this.CardData._AttackTimes = 3;
			this.CardData.HP = this.CardData.MaxHP;
			this.CardData.Armor = (this.CardData.MaxArmor = 4);
			List<CardSlotData> battleArea2 = DungeonOperationMgr.Instance.BattleArea;
			for (int j = 0; j < 3; j++)
			{
				List<CardSlotData> list2 = new List<CardSlotData>();
				foreach (CardSlotData cardSlotData2 in battleArea2)
				{
					if (cardSlotData2.ChildCardData == null)
					{
						list2.Add(cardSlotData2);
					}
				}
				if (list2.Count <= 0)
				{
					break;
				}
				UnityEngine.Random.Range(0, list2.Count);
				Card.InitCardDataByID("血祭之卵").PutInSlotData(list2[j], true);
			}
			this.AddLogic("BossSnakeCallSacrifice");
			this.AddLogic("BossSnakeEat");
			return;
		}
		default:
			return;
		}
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}

	private void RemoveLogic(string logicName)
	{
		Activator.CreateInstance(Type.GetType(logicName));
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			if (cardLogic.GetType().Name.Equals(logicName))
			{
				for (int i = this.CardData.CardLogicClassNames.Count - 1; i >= 0; i--)
				{
					if (this.CardData.CardLogicClassNames[i].Split(new char[]
					{
						' '
					})[0].Equals(logicName))
					{
						this.CardData.CardLogicClassNames.Remove(this.CardData.CardLogicClassNames[i]);
					}
				}
				this.CardData.CardLogics.Remove(cardLogic);
				break;
			}
		}
	}

	private int m_Count;

	private int m_ATK;

	private int m_ATKTimes;
}
