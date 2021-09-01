using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using HighlightingSystem;
using Newtonsoft.Json;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CardData : ItemData
{
	[JsonIgnore]
	public CharacterTag CharactorTag
	{
		get
		{
			return this._charactorTag;
		}
		set
		{
			this._charactorTag = value;
		}
	}

	[JsonIgnore]
	public string PersonName
	{
		get
		{
			return this._personName;
		}
		set
		{
			this._personName = value;
		}
	}

	[JsonIgnore]
	public int ATK
	{
		get
		{
			int num = this._ATK;
			if (this.affixesDic != null && this.affixesDic.ContainsKey(DungeonAffix.strength))
			{
				int num2 = 1;
				foreach (CardLogic cardLogic in this.CardLogics)
				{
					if (cardLogic.GetType() == typeof(GangBiCardLogic))
					{
						num2 = cardLogic.Layers * 3;
					}
				}
				num += this.affixesDic[DungeonAffix.strength] * num2;
			}
			if (this.affixesDic != null && this.affixesDic.ContainsKey(DungeonAffix.weak))
			{
				num -= this.affixesDic[DungeonAffix.weak];
			}
			num += this.wATK + this.InBattleATK + Mathf.CeilToInt((float)(this._ATK * this.EXATK) / 100f);
			if (num < 0 && this.HasTag(TagMap.随从))
			{
				return 0;
			}
			return num;
		}
	}

	[JsonIgnore]
	public int AttackTimes
	{
		get
		{
			return this._AttackTimes + this.NextAttackTimes + this.wAttackTimes;
		}
	}

	[JsonIgnore]
	public int CRIT
	{
		get
		{
			int num = this._CRIT;
			if (this.affixesDic != null && this.affixesDic.ContainsKey(DungeonAffix.crit))
			{
				num += this.affixesDic[DungeonAffix.crit] * 5;
			}
			num += this.wCRIT + this.InBattleCRIT;
			if (num < 0)
			{
				return 0;
			}
			return num;
		}
	}

	public Dictionary<DungeonAffix, int> affixesDic { get; private set; } = new Dictionary<DungeonAffix, int>();

	public void PutInSlotData(CardSlotData slotData, bool CallEvent = true)
	{
		if (slotData == null)
		{
			return;
		}
		if (slotData.ChildCardData != null && slotData.ChildCardData == this)
		{
			return;
		}
		if (CardData.CheckOverLay(this, slotData))
		{
			slotData.ChildCardData.Count += this.Count;
			this.DeleteCardData();
			return;
		}
		CardSlotData currentCardSlotData = this.CurrentCardSlotData;
		if (this.CurrentCardSlotData != null)
		{
			this.CurrentCardSlotData.ClearCardData();
		}
		this.CurrentCardSlotData = slotData;
		if (slotData.CurrentAreaData != null)
		{
			this.CurrentAreaID = slotData.CurrentAreaData.ID;
		}
		slotData.SetChildCardData(this);
		if (this.CardGameObject != null)
		{
			this.CardGameObject.PutInSlot(slotData.CardSlotGameObject);
		}
		if (CallEvent)
		{
			GameController.getInstance().GameEventManager.CardPutInSlot(currentCardSlotData, this);
			GameController.getInstance().GameEventManager.CardDataChangeSlot(currentCardSlotData, slotData, this);
		}
	}

	public static bool CheckOverLay(CardData cardData, CardSlotData slotData)
	{
		if (slotData == null || slotData.ChildCardData == null)
		{
			return false;
		}
		if (slotData.OnlyAcceptOneCard)
		{
			return false;
		}
		CardData childCardData = slotData.ChildCardData;
		if (cardData == slotData.ChildCardData)
		{
			return false;
		}
		if (cardData.Count + childCardData.Count > cardData.MaxCount)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(childCardData.ModID))
		{
			return childCardData.ModID.Equals(cardData.ModID);
		}
		return string.IsNullOrEmpty(childCardData.StructBase64String) || childCardData.StructBase64String.Equals(cardData.StructBase64String);
	}

	public void DoAllLogic(string funcName, params object[] parameterValues)
	{
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			MethodInfo method = cardLogic.GetType().GetMethod(funcName.Trim());
			if (method == null)
			{
				Debug.LogError("方法不存在!" + funcName.Trim());
			}
			else
			{
				method.GetParameters();
				if (parameterValues != null && parameterValues.Length != 0)
				{
					method.Invoke(cardLogic, parameterValues);
				}
				else
				{
					method.Invoke(cardLogic, new object[0]);
				}
			}
		}
	}

	public void ChangeCardSlot(CardSlotData target)
	{
		if (this.CurrentCardSlotData != null)
		{
			this.CurrentCardSlotData.SetChildCardData(null);
		}
		if (target != null)
		{
			target.SetChildCardData(this);
		}
		this.CurrentCardSlotData = target;
	}

	public void MoveToArea(string id, float x, float z, float rot, bool withCardSlot)
	{
		Dictionary<string, AreaData> areaMap = GameController.getInstance().GameData.AreaMap;
		if (!areaMap.ContainsKey(id))
		{
			return;
		}
		AreaData areaData = areaMap[this.CurrentAreaID];
		CardSlotData currentCardSlotData = this.CurrentCardSlotData;
		if (withCardSlot)
		{
			areaData.CardSlotDatas.Remove(currentCardSlotData);
		}
		AreaData areaData2 = areaMap[id];
		CardSlotData cardSlotData = JsonConvert.DeserializeObject<CardSlotData>(JsonConvert.SerializeObject(currentCardSlotData));
		cardSlotData.DisplayPositionX = x;
		cardSlotData.DisplayPositionZ = z;
		cardSlotData.SetChildCardData(this);
		this.DisplayRotationY = rot;
		areaData2.CardSlotDatas.Add(cardSlotData);
	}

	public void MergeBy(CardData cardData, bool callEvent = true, bool Force = false)
	{
		if (cardData == GameController.ins.GameData.PlayerCardData)
		{
			DungeonController.Instance.StartCoroutine(DungeonController.Instance.GameOver(false));
		}
		if (Force || (cardData.HasTag(TagMap.食物) && this.HasTag(TagMap.随从)) || (cardData.HasTag(TagMap.食物) && this.HasTag(TagMap.食物)) || (GameController.ins.GameData.FaithData.TanYu > 2 && cardData.HasTag(TagMap.随从) && this.HasTag(TagMap.随从)) || (cardData.HasTag(TagMap.奇遇) && this.HasTag(TagMap.奇遇)))
		{
			if (this.HasTag(TagMap.食物) && this.Rare == 4 && !Force)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
				return;
			}
			if (this.Rare == 5 && GameController.ins.GameData.FaithData.TanYu < 3 && !Force)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
				return;
			}
			if (this.Rare == 6 && GameController.ins.GameData.FaithData.TanYu > 2 && !Force)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
				return;
			}
			if (!Force)
			{
				this.Rare++;
				if (this.HasTag(TagMap.随从) && this.CardGameObject != null)
				{
					JournalsConversationManager.PutJournals(new JournalsBean(string.Concat(new string[]
					{
						LocalizationMgr.Instance.GetLocalizationWord(this.Name),
						this.PersonName,
						LocalizationMgr.Instance.GetLocalizationWord("SM_日志11"),
						LocalizationMgr.Instance.GetLocalizationWord(cardData.Name),
						"。"
					}), null, null, null, null, null, null));
					if (this.Rare == 5)
					{
						SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_jinsechuanshuo);
					}
				}
			}
			if (this.CardGameObject != null)
			{
				ModelPoolManager.Instance.UnSpawnModel(this.CardGameObject.BottomGameObject);
				string cardBottomName = this.GetCardBottomName();
				this.CardGameObject.BottomGameObject = ModelPoolManager.Instance.SpawnModel(cardBottomName);
				this.CardGameObject.BottomGameObject.transform.SetParent(this.CardGameObject.transform, false);
				if (this.HasTag(TagMap.随从))
				{
					ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = this.CardGameObject.transform.position;
					ParticlePoolManager.Instance.Spawn("Effect/LevelUP", 1f).gameObject.transform.position = this.CardGameObject.transform.position;
				}
				else
				{
					ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = this.CardGameObject.transform.position;
				}
				ParticlePoolManager.Instance.Spawn("Effect/Insight_yellow", 1f).transform.position = this.CardGameObject.transform.position;
			}
		}
		int m;
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			CardData cardData2 = Card.InitCardDataByID(this.ModID);
			if (this.HasTag(TagMap.随从) && cardData.HasTag(TagMap.食物) && cardLogic.Layers > 0)
			{
				foreach (CardLogic cardLogic2 in cardData2.CardLogics)
				{
					if (cardLogic2.GetType().Equals(cardLogic.GetType()))
					{
						if (!(cardLogic2.GetType() == typeof(CardLogicAdapter)))
						{
							CardLogic cardLogic3 = cardLogic;
							m = cardLogic3.Layers;
							cardLogic3.Layers = m + 1;
							break;
						}
						if ((cardLogic2 as CardLogicAdapter).LuaString == (cardLogic as CardLogicAdapter).LuaString)
						{
							CardLogic cardLogic4 = cardLogic;
							m = cardLogic4.Layers;
							cardLogic4.Layers = m + 1;
							break;
						}
					}
				}
			}
		}
		if (cardData.Attrs != null && cardData.Attrs.ContainsKey("Theme") && this.Attrs != null && this.Attrs.ContainsKey("Theme"))
		{
			try
			{
				this.Attrs["Theme"] = this.Attrs["Theme"].ToString() + "," + cardData.Attrs["Theme"].ToString();
				List<string> list = new List<string>();
				foreach (string item in this.Attrs["Theme"].ToString().Split(new char[]
				{
					','
				}))
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
				string text = "";
				for (int j = 0; j < list.Count; j++)
				{
					if (j == 0)
					{
						text = list[j];
					}
					else
					{
						text = text + "," + list[j];
					}
				}
				this.Attrs["Theme"] = text;
			}
			catch
			{
				Debug.LogError("卡片Merge时情景拼接错误:" + this.ModID);
			}
		}
		if (cardData.Attrs != null && cardData.Attrs.ContainsKey("JieJieName") && this.Attrs != null && this.Attrs.ContainsKey("JieJieName"))
		{
			this.Attrs["JieJieName"] = this.Attrs["JieJieName"].ToString() + "," + cardData.Attrs["JieJieName"].ToString();
			List<string> list2 = new List<string>();
			foreach (string item2 in this.Attrs["JieJieName"].ToString().Split(new char[]
			{
				','
			}))
			{
				if (!list2.Contains(item2))
				{
					list2.Add(item2);
				}
			}
			string text2 = "";
			for (int k = 0; k < list2.Count; k++)
			{
				if (k == 0)
				{
					text2 = list2[k];
				}
				else
				{
					text2 = text2 + "," + list2[k];
				}
			}
			this.Attrs["JieJieName"] = text2;
		}
		if (this.CardLogicClassNames != null)
		{
			foreach (string text3 in this.CardLogicClassNames)
			{
				try
				{
					string[] array2 = text3.Trim().Split(new char[]
					{
						' '
					});
					int layers = 0;
					if (array2.Length > 1)
					{
						layers = int.Parse(array2[1]);
					}
					Type type = Type.GetType(array2[0]);
					if (type.GetCustomAttribute<CardLogicRequireAgreementAttribute>() == null || type.GetCustomAttribute<CardLogicRequireAgreementAttribute>().Agreement <= GameController.ins.GameData.Agreenment)
					{
						if (type.GetCustomAttribute<CardLogicRequireRareAttribute>() != null)
						{
							if (type.GetCustomAttribute<CardLogicRequireRareAttribute>().Rare == this.Rare)
							{
								CardLogic cardLogic5 = null;
								foreach (CardLogic cardLogic6 in this.CardLogics)
								{
									if (cardLogic6.GetType().Name.Equals(type.Name))
									{
										cardLogic5 = cardLogic6;
										break;
									}
								}
								if (cardLogic5 == null)
								{
									cardLogic5 = (Activator.CreateInstance(type) as CardLogic);
									cardLogic5.CardData = this;
									cardLogic5.Layers = layers;
									cardLogic5.Init();
									this.CardLogics.Add(cardLogic5);
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("加载CardLogic类时类名不匹配: " + text3 + " 文件: " + this.Name);
					Debug.LogError(ex.Message);
					Debug.LogError(ex.StackTrace);
				}
			}
		}
		this.MaxHP += cardData.MaxHP;
		this.HP += cardData.MaxHP + cardData.HP;
		if (this.HP > this.MaxHP)
		{
			this.HP = this.MaxHP;
		}
		this._ATK += cardData._ATK;
		if (this.HasTag(TagMap.随从) && this._ATK < 0)
		{
			this._ATK = 0;
			this.wATK = 0;
		}
		this.Armor += cardData.Armor;
		this.MaxArmor += cardData.MaxArmor;
		this.MP += cardData.MP;
		this.EXATK += cardData.EXATK;
		this._CRIT += cardData.CRIT;
		if (this._CRIT < 0)
		{
			this._CRIT = 0;
			this.wCRIT = 0;
		}
		this.wATK += cardData.wATK;
		this.wCRIT += cardData.wCRIT;
		this.wHP += cardData.wHP;
		this.wArmor += cardData.wArmor;
		this.wAttackTimes += cardData.wAttackTimes;
		this.NextAttackTimes += cardData.NextAttackTimes;
		if (cardData._AttackTimes <= 0)
		{
			cardData._AttackTimes = 1;
		}
		this._AttackTimes += ((cardData._AttackTimes > 0) ? (cardData._AttackTimes - 1) : 0);
		this.ATKRange += cardData.ATKRange;
		this.EXATKTimes += cardData.EXATKTimes;
		if (this.MaxHP <= 0 && this.HasTag(TagMap.随从))
		{
			this.MaxHP = 1;
		}
		if (this.HasTag(TagMap.随从) && this.HP <= 0)
		{
			this.HP = 1;
		}
		if (!this.HasTag(TagMap.随从))
		{
			this.CardTags |= cardData.CardTags;
		}
		if (this.ActDatas == null)
		{
			this.ActDatas = new List<ActData>();
		}
		if (cardData.ActDatas != null && cardData.ActDatas.Count > 0)
		{
			foreach (ActData item3 in cardData.ActDatas)
			{
				this.ActDatas.Add(item3);
			}
			if (this.ActDatas != null && this.CardGameObject != null)
			{
				for (int l = 0; l < this.ActDatas.Count; l++)
				{
					this.CardGameObject.options.Add(new Dropdown.OptionData(this.ActDatas[l].Name));
				}
			}
		}
		foreach (KeyValuePair<string, object> keyValuePair in cardData.Attrs)
		{
			if (!this.Attrs.ContainsKey(keyValuePair.Key))
			{
				this.Attrs.Add(keyValuePair.Key, keyValuePair.Value);
			}
			else if (keyValuePair.Key == "MaxValue" || keyValuePair.Key == "MaxValue" || keyValuePair.Key == "MaxValue")
			{
				this.Attrs[keyValuePair.Key] = int.Parse(keyValuePair.Value.ToString()) + int.Parse(this.Attrs[keyValuePair.Key].ToString());
			}
		}
		if (cardData.PreNameList != null)
		{
			if (!string.IsNullOrEmpty(cardData.PreName) && !this.PreNameList.Contains(cardData.PreName) && !this.Name.Contains(cardData.PreName))
			{
				this.PreNameList.Insert(0, cardData.PreName);
			}
			foreach (string text4 in cardData.PreNameList)
			{
				if (!this.PreNameList.Contains(text4) && !this.Name.Contains(text4))
				{
					this.PreNameList.Insert(0, text4);
				}
			}
			string str = "";
			foreach (string str2 in this.PreNameList)
			{
				str += str2;
			}
		}
		if (this.MergedCardModIDs == null)
		{
			this.MergedCardModIDs = new List<string>();
		}
		this.MergedCardModIDs.Add(cardData.Name);
		if (cardData.MergedCardModIDs != null && cardData.MergedCardModIDs.Count > 0)
		{
			this.MergedCardModIDs.AddRange(cardData.MergedCardModIDs);
		}
		int i;
		Predicate<CardLogic> <>9__0;
		for (i = 0; i < cardData.CardLogics.Count; i = m + 1)
		{
			if (!(cardData.CardLogics[i] is NatureLogic))
			{
				if (cardData.CardLogics[i].Layers == 0)
				{
					CardLogic cardLogic7 = null;
					foreach (CardLogic cardLogic8 in this.CardLogics)
					{
						if (cardLogic8 is CardLogicAdapter && cardData.CardLogics[i] is CardLogicAdapter && (cardLogic8 as CardLogicAdapter).LuaString == (cardData.CardLogics[i] as CardLogicAdapter).LuaString)
						{
							cardLogic7 = cardLogic8;
						}
						else if (!(cardLogic8 is CardLogicAdapter) && cardLogic8.GetType() == cardData.CardLogics[i].GetType())
						{
							cardLogic7 = cardLogic8;
						}
					}
					if (cardLogic7 == null)
					{
						CardLogic cardLogic9 = JsonConvert.DeserializeObject<CardLogic>(JsonConvert.SerializeObject(cardData.CardLogics[i]));
						cardLogic9.CardData = this;
						this.CardLogics.Add(cardLogic9);
						cardLogic9.Init();
						cardLogic9.Color = cardData.CardLogics[i].Color;
						cardLogic9.OnMerge(cardData);
					}
					else
					{
						List<CardLogic> cardLogics = this.CardLogics;
						Predicate<CardLogic> match;
						if ((match = <>9__0) == null)
						{
							match = (<>9__0 = ((CardLogic a) => a.GetType() == cardData.CardLogics[i].GetType()));
						}
						int index = cardLogics.FindIndex(match);
						this.CardLogics[index].OnMerge(cardData);
					}
				}
				else
				{
					bool flag = false;
					CardLogic cardLogic10 = null;
					foreach (CardLogic cardLogic11 in this.CardLogics)
					{
						if (cardLogic11.GetType() == cardData.CardLogics[i].GetType())
						{
							if (!(cardLogic11.GetType() == typeof(CardLogicAdapter)))
							{
								cardLogic11.Layers += cardData.CardLogics[i].Layers;
								flag = true;
								cardLogic10 = cardLogic11;
								break;
							}
							if ((cardLogic11 as CardLogicAdapter).LuaString == (cardData.CardLogics[i] as CardLogicAdapter).LuaString)
							{
								cardLogic11.Layers += cardData.CardLogics[i].Layers;
								flag = true;
								cardLogic10 = cardLogic11;
								break;
							}
							flag = false;
						}
						else
						{
							flag = false;
						}
					}
					if (!flag)
					{
						cardLogic10 = JsonConvert.DeserializeObject<CardLogic>(JsonConvert.SerializeObject(cardData.CardLogics[i]));
						cardLogic10.CardData = this;
						this.CardLogics.Add(cardLogic10);
					}
					cardLogic10.Init();
					cardLogic10.OnMerge(cardData);
				}
			}
			m = i;
		}
		if (DungeonOperationMgr.Instance != null && GameController.ins.GameData.isInDungeon && DungeonOperationMgr.Instance.PlayerBattleArea != null)
		{
			foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.CardLogics != null)
				{
					foreach (CardLogic cardLogic12 in cardSlotData.ChildCardData.CardLogics)
					{
						if (cardLogic12 is TwoPeopleCardLogic && !string.IsNullOrEmpty((cardLogic12 as TwoPeopleCardLogic).TargetID) && (cardLogic12 as TwoPeopleCardLogic).TargetID == cardData.ID)
						{
							(cardLogic12 as TwoPeopleCardLogic).TargetID = this.ID;
						}
					}
				}
			}
		}
		if (cardData.HasTag(TagMap.随从))
		{
			m = cardData.Rare;
			if (m != 1)
			{
			}
		}
		if (callEvent)
		{
			GameController.getInstance().GameEventManager.OnMerBy(this, cardData);
		}
		Card cardGameObject = this.CardGameObject;
		if (((cardGameObject != null) ? cardGameObject.GetComponent<Highlighter>() : null) != null)
		{
			this.CardGameObject.GetComponent<Highlighter>().enabled = false;
			this.CardGameObject.GetComponent<Highlighter>().enabled = true;
		}
	}

	public static CardData CopyCardData(CardData cardData, bool deep = true)
	{
		CardData cardData2 = null;
		try
		{
			cardData2 = (JsonConvert.DeserializeObject(JsonConvert.SerializeObject(cardData)) as CardData);
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
		}
		cardData2.ID = Guid.NewGuid().ToString();
		GameController.getInstance().CardDataInWorldMap.Add(cardData2.ID, cardData2);
		if (cardData2.HasTag(TagMap.随从))
		{
			cardData2.PersonName = CardData.GetChinessName();
			cardData2.CharactorTag = (CharacterTag)(1L << (SYNCRandom.Range(0, Enum.GetValues(typeof(CharacterTag)).Length) & 31));
			while (cardData2.HasTag(TagMap.英雄) && cardData2.CharactorTag == CharacterTag.忠诚)
			{
				cardData2.CharactorTag = (CharacterTag)(1L << (SYNCRandom.Range(0, Enum.GetValues(typeof(CharacterTag)).Length) & 31));
			}
			CharacterTag charactorTag = cardData2.CharactorTag;
		}
		return cardData2;
	}

	public void Terminate()
	{
		this.CardGameObject = null;
	}

	public void DeleteCardData()
	{
		if (this.CardGameObject != null)
		{
			this.CardGameObject.DeleteCard();
		}
		if (GameController.getInstance().CardDataInWorldMap.ContainsKey(this.ID))
		{
			GameController.getInstance().CardDataInWorldMap.Remove(this.ID);
		}
		CardSlotData currentCardSlotData = this.CurrentCardSlotData;
		if (this.CurrentCardSlotData != null)
		{
			this.CurrentCardSlotData.ClearCardData();
		}
		if (!string.IsNullOrEmpty(base.GetAttr("AreaDataID")))
		{
			AreaData areaDataByModID = GameController.getInstance().AreaDataModMap.getAreaDataByModID(base.GetAttr("AreaDataID"));
			if (areaDataByModID != null && this.IsCopy)
			{
				GameController.getInstance().AreaDataModMap.Areas.Remove(areaDataByModID);
			}
		}
		this.CurrentCardSlotData = null;
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			GameController.ins.StartCoroutine(cardLogic.Terminate(currentCardSlotData));
		}
		this.affixesDic = new Dictionary<DungeonAffix, int>();
	}

	public void Consume(int count = 1)
	{
		if (this.Count == count || count > this.Count)
		{
			this.DeleteCardData();
			return;
		}
		this.Count -= count;
		if (this.CardGameObject != null)
		{
			this.CardGameObject.RefreshCountText();
		}
	}

	public CardData MergeWith(CardData cardData)
	{
		return new CardData
		{
			_ATK = this.ATK + cardData.ATK
		};
	}

	public static CardData ThreeCombo(CardData cardData1, CardData cardData2, CardData cardData3)
	{
		CardData cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(cardData1.ModID), true);
		for (int i = cardData1.CardLogics.Count - 1; i >= 0; i--)
		{
			for (int j = cardData4.CardLogics.Count - 1; j >= 0; j--)
			{
				if (cardData4.CardLogics[j].GetType() == cardData1.CardLogics[i].GetType())
				{
					cardData1.CardLogics.Remove(cardData1.CardLogics[i]);
					break;
				}
				cardData1.CardLogics[i].Layers -= cardData4.CardLogics[j].Layers;
			}
		}
		cardData1.HP = 0;
		cardData1.MaxHP = 0;
		cardData1.Armor = 0;
		cardData1.MaxArmor = 0;
		cardData1._ATK = 0;
		CardData cardData5;
		if (cardData1.HasAttr("Upgrade") && GameController.getInstance().CardDataModMap.getCardDataByModID(cardData1.GetAttr("Upgrade")) != null)
		{
			cardData5 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(cardData1.GetAttr("Upgrade")), true);
			if (cardData5 != null)
			{
				cardData5.MergeBy(cardData1, true, false);
				cardData5.MergeBy(cardData2, true, false);
				cardData5.MergeBy(cardData3, true, false);
			}
			else
			{
				cardData5 = CardData.CopyCardData(cardData2, true);
				cardData5.MergeBy(cardData1, true, false);
				cardData5.MergeBy(cardData3, true, false);
				cardData5.Rare++;
			}
		}
		else
		{
			cardData5 = CardData.CopyCardData(cardData2, true);
			cardData5.MergeBy(cardData1, true, false);
			cardData5.MergeBy(cardData3, true, false);
			cardData5.Rare++;
		}
		return cardData5;
	}

	public void SetLevel(int level)
	{
		if (level > 30)
		{
			level = 30;
		}
		base.SetAttr("Level", level.ToString());
		string attr = base.GetAttr(Constant.CardAttributeName.LevelHP);
		if (!string.IsNullOrEmpty(attr))
		{
			string[] array = attr.Split(new char[]
			{
				','
			});
			this.MaxHP = (this.HP = Convert.ToInt32(array[level - 1]));
		}
		attr = base.GetAttr(Constant.CardAttributeName.LevelATK);
		if (!string.IsNullOrEmpty(attr))
		{
			string[] array2 = attr.Split(new char[]
			{
				','
			});
			this._ATK = Convert.ToInt32(array2[level - 1]);
		}
		attr = base.GetAttr(Constant.CardAttributeName.LevelLeadership);
		if (!string.IsNullOrEmpty(attr))
		{
			string[] array3 = attr.Split(new char[]
			{
				','
			});
			base.SetAttr("Leadership", array3[level - 1]);
		}
	}

	public void AddExp(int amount)
	{
		int num = base.GetIntAttr(Constant.CardAttributeName.EXP);
		num += amount;
		base.SetAttr(Constant.CardAttributeName.EXP, num.ToString());
		int intAttr = base.GetIntAttr(Constant.CardAttributeName.Level);
		int levelByExp = this.GetLevelByExp(num);
		if (intAttr < 30 && levelByExp > intAttr)
		{
			this.SetLevel(levelByExp);
			GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_26"), levelByExp), 1f, 2f, 1f, 1f);
		}
	}

	public int GetLevelExp(int level)
	{
		if (level <= 1)
		{
			return 0;
		}
		return (1 + (level - 1)) * (level - 1) / 2 * 10;
	}

	public int GetLevelByExp(int exp)
	{
		for (int i = 30; i >= 1; i--)
		{
			if (exp >= this.GetLevelExp(i))
			{
				return i;
			}
		}
		return 1;
	}

	public bool HasTag(TagMap tagMask)
	{
		return (this.CardTags & (ulong)tagMask) > 0UL;
	}

	public bool HasTag(int tagMask)
	{
		return (this.CardTags & (ulong)((long)tagMask)) > 0UL;
	}

	public void AddTag(TagMap tagMask)
	{
		this.CardTags |= (ulong)tagMask;
	}

	public void RemoveTag(TagMap tagMask)
	{
		this.CardTags &= (ulong)(~(ulong)tagMask);
	}

	public bool HasConversation()
	{
		return this.HasTag(TagMap.角色) && DialogueManager.MasterDatabase.GetConversation(this.Name) != null;
	}

	public void ReloadLogics()
	{
		this.CardLogics = new List<CardLogic>();
		foreach (string text in this.CardLogicClassNames)
		{
			try
			{
				string[] array = text.Trim().Split(new char[]
				{
					' '
				});
				int layers = 0;
				if (array.Length > 1)
				{
					layers = int.Parse(array[1]);
				}
				string text2 = array[0];
				Type type;
				if (GameController.ins.LuaLogicCache.ContainsKey(text2))
				{
					type = new CardLogicAdapter
					{
						LuaString = text2,
						Layers = layers
					}.GetType();
				}
				else
				{
					type = Type.GetType(text2);
				}
				if (type.GetCustomAttribute<CardLogicRequireAgreementAttribute>() == null || type.GetCustomAttribute<CardLogicRequireAgreementAttribute>().Agreement <= GameController.ins.GameData.Agreenment)
				{
					if (type.GetCustomAttribute<CardLogicRequireRareAttribute>() == null || type.GetCustomAttribute<CardLogicRequireRareAttribute>().Rare <= this.Rare)
					{
						CardLogic cardLogic = null;
						foreach (CardLogic cardLogic2 in this.CardLogics)
						{
							if (cardLogic2.GetType().Name.Equals(type.Name) && type != typeof(CardLogicAdapter))
							{
								cardLogic = cardLogic2;
								break;
							}
						}
						if (cardLogic == null)
						{
							if (GameController.ins.LuaLogicCache.ContainsKey(text2))
							{
								cardLogic = new CardLogicAdapter
								{
									LuaString = text2,
									Layers = layers
								};
							}
							else
							{
								cardLogic = (Activator.CreateInstance(type) as CardLogic);
							}
							if (cardLogic == null)
							{
								cardLogic = (ModLoader.CompilerResults.CompiledAssembly.CreateInstance(text2) as CardLogic);
							}
							cardLogic.CardData = this;
							cardLogic.Layers = layers;
							cardLogic.Init();
							this.CardLogics.Add(cardLogic);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("加载CardLogic类时类名不匹配: " + text + " 文件: " + this.Name);
				Debug.LogError(ex.Message);
				Debug.LogError(ex.StackTrace);
			}
		}
	}

	public static CardData GetCardDataByStructTexture(Texture2D tex)
	{
		Color32[] pixels = tex.GetPixels32();
		for (int i = 0; i < pixels.Length; i++)
		{
			Color32 color = pixels[i];
			if (color.a > 0 && color.a < 255)
			{
				pixels[i] = new Color32(color.r, color.g, color.b, byte.MaxValue);
			}
		}
		tex.SetPixels32(pixels);
		tex.Apply();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (!(cardData.StructTexture == null))
			{
				Texture2D structTexture = cardData.StructTexture;
				if (!(tex.texelSize != structTexture.texelSize))
				{
					int j;
					for (j = 0; j < structTexture.width; j++)
					{
						int num = 0;
						while (num < structTexture.height && ((tex.GetPixel(j, num).a <= 0f && structTexture.GetPixel(j, num).a <= 0f) || tex.GetPixel(j, num).Equals(structTexture.GetPixel(j, num))))
						{
							num++;
						}
						if (num != structTexture.height)
						{
							break;
						}
					}
					if (j == structTexture.width)
					{
						return CardData.CopyCardData(cardData, true);
					}
				}
			}
		}
		CardData cardData2 = CardData.CopyCardData(new CardData
		{
			ModID = null,
			Name = "材料",
			ItemType = ItemData.ItemTypes.material,
			Rare = 1
		}, true);
		Color32[] pixels2 = tex.GetPixels32();
		cardData2.Struct = new string[tex.width * tex.height];
		for (int k = 0; k < pixels2.Length; k++)
		{
			for (int l = 0; l < CommonAttribute.MaterialColors.Length; l++)
			{
				if (pixels2[k].Equals(CommonAttribute.MaterialColors[l]))
				{
					cardData2.Struct[k] = CommonAttribute.MaterialNames[l];
				}
			}
		}
		cardData2.StructWidth = tex.width;
		cardData2.StructHeight = tex.height;
		cardData2.StructTexture = tex;
		return cardData2;
	}

	public int GetHP()
	{
		if (this.HasTag(TagMap.随从))
		{
			return (this.Count - 1) * this.MaxHP + this.HP;
		}
		return this.HP;
	}

	public int GetATK()
	{
		int num = 0;
		if (this.HasTag(TagMap.随从))
		{
			num = this.Count * this.ATK;
		}
		else
		{
			num = this.ATK;
		}
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			num += cardLogic.GetATKBonus();
		}
		return num;
	}

	public void TakeDamage(int amount)
	{
		int num = this.GetHP();
		num -= amount;
		if (num <= 0)
		{
			num = 0;
		}
		if (this.HasTag(TagMap.随从))
		{
			if (num == 0)
			{
				this.Count = 1;
			}
			else
			{
				this.Count = num / this.MaxHP + ((num % this.MaxHP > 0) ? 1 : 0);
			}
			this.HP = num - this.MaxHP * (this.Count - 1);
			return;
		}
		this.HP = num;
	}

	[OnSerializing]
	public void OnSerializing(StreamingContext context)
	{
		this.CharactorTagUlong = (ulong)this.CharactorTag;
		if (this.StructTexture != null && string.IsNullOrEmpty(this.StructBase64String))
		{
			this.StructBase64String = Convert.ToBase64String(this.StructTexture.EncodeToPNG());
		}
		List<string> list = new List<string>();
		foreach (string text in this.CardLogicClassNames)
		{
			try
			{
				string[] array = text.Trim().Split(new char[]
				{
					' '
				});
				int layers = 0;
				if (array.Length > 1)
				{
					layers = int.Parse(array[1]);
				}
				string text2 = array[0];
				Type type;
				if (GameController.ins.LuaLogicCache.ContainsKey(text2))
				{
					type = new CardLogicAdapter
					{
						LuaString = text2,
						Layers = layers
					}.GetType();
				}
				else
				{
					type = Type.GetType(text2);
				}
				if (type == null)
				{
					type = ModLoader.CompilerResults.CompiledAssembly.GetType(text2);
				}
				if (type.GetCustomAttribute<CardLogicRequireAgreementAttribute>() == null || type.GetCustomAttribute<CardLogicRequireAgreementAttribute>().Agreement <= GameController.ins.GameData.Agreenment)
				{
					if (type.GetCustomAttribute<CardLogicRequireRareAttribute>() != null && type.GetCustomAttribute<CardLogicRequireRareAttribute>().Rare > this.Rare)
					{
						list.Add(text);
					}
				}
			}
			catch
			{
				Debug.LogError("解析Logic失败");
			}
		}
		this.CardLogicClassNames = new List<string>();
		this.CardLogicClassNames.AddRange(list);
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			if (cardLogic.Layers > 0)
			{
				this.CardLogicClassNames.Add(cardLogic.GetType().Name + " " + cardLogic.Layers.ToString());
			}
			else
			{
				this.CardLogicClassNames.Add(cardLogic.GetType().Name);
			}
		}
	}

	[OnDeserialized]
	public void OnDeserialized(StreamingContext context)
	{
		this.CharactorTag = (CharacterTag)this.CharactorTagUlong;
		if (this.Attrs == null)
		{
			this.Attrs = new Dictionary<string, object>();
		}
		if (this.Model == null)
		{
			this.Model = "Unknown";
		}
		if (this.CardLogics == null)
		{
			this.CardLogics = new List<CardLogic>();
		}
		if (this.PreNameList == null)
		{
			this.PreNameList = new List<string>();
		}
		if (string.IsNullOrEmpty(this.ID) || this.ID.Length < 16)
		{
			this.ID = Guid.NewGuid().ToString();
			if (GameController.getInstance().CardDataInWorldMap != null && !GameController.getInstance().CardDataInWorldMap.ContainsKey(this.ID))
			{
				GameController.getInstance().CardDataInWorldMap.Add(this.ID, this);
			}
		}
		else if (GameController.getInstance() != null && GameController.getInstance().CardDataInWorldMap != null && !GameController.getInstance().CardDataInWorldMap.ContainsKey(this.ID))
		{
			GameController.getInstance().CardDataInWorldMap.Add(this.ID, this);
		}
		if (this.CardLogicClassNames != null && (this.CardLogics == null || this.CardLogics.Count == 0))
		{
			this.ReloadLogics();
		}
		if (this.CardLogics != null && this.CardLogics.Count != 0)
		{
			foreach (CardLogic cardLogic in this.CardLogics)
			{
				cardLogic.CardData = this;
				cardLogic.Init();
			}
		}
	}

	public void OnGameLoaded()
	{
	}

	public CardLogic AddLogic(string logicName, int layer = 0)
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
			return null;
		}
		cardLogic.Layers = layer;
		cardLogic.CardData = this;
		this.CardLogics.Add(cardLogic);
		cardLogic.Init();
		cardLogic.OnMerge(this);
		return cardLogic;
	}

	public void AddLogic(CardLogic cardLogic)
	{
		this.CardLogics.Add(cardLogic);
		cardLogic.CardData = this;
		cardLogic.Init();
		cardLogic.OnMerge(this);
	}

	public bool RemoveLogic(CardLogic cardLogic)
	{
		if (cardLogic != null)
		{
			cardLogic.Terminate(this.CurrentCardSlotData);
			return this.CardLogics.Remove(cardLogic);
		}
		return false;
	}

	public bool RemoveLogic(string cardLogicName)
	{
		for (int i = this.CardLogics.Count - 1; i >= 0; i--)
		{
			if (this.CardLogics[i].GetType().Name == cardLogicName || (this.CardLogics[i].GetType() == typeof(CardLogicAdapter) && (this.CardLogics[i] as CardLogicAdapter).LuaString == cardLogicName))
			{
				this.CardLogics.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public void AddPersonLogic(PersonCardLogic logic)
	{
		this.CardLogics.Add(logic);
		logic.CardData = this;
		logic.Init();
		logic.OnMerge(this);
	}

	public bool HasAffix(DungeonAffix affix)
	{
		return this.affixesDic.ContainsKey(affix);
	}

	public int GetAffixData(DungeonAffix affix)
	{
		int result = 0;
		this.affixesDic.TryGetValue(affix, out result);
		return result;
	}

	public void AddAffix(DungeonAffix affix, int num)
	{
		if (this.HasAffix(affix))
		{
			Dictionary<DungeonAffix, int> affixesDic = this.affixesDic;
			DungeonAffix key = affix;
			affixesDic[key] += num;
		}
		else
		{
			this.affixesDic.Add(affix, num);
			if (this.CardGameObject != null)
			{
				Transform transform = UnityEngine.Object.Instantiate<Transform>(this.CardGameObject.AffixTrans);
				transform.SetParent(this.CardGameObject.AffixTrans.parent);
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				DungeonAffixInfoAttribute dungeonAffixInfoAttribute = (DungeonAffixInfoAttribute)Attribute.GetCustomAttribute(typeof(DungeonAffix).GetMember(affix.ToString())[0], typeof(DungeonAffixInfoAttribute));
				transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(dungeonAffixInfoAttribute.defaultSpritePath);
				transform.gameObject.SetActive(true);
				this.CardGameObject.affixesImg.Add(affix, transform.gameObject);
			}
		}
		if (affix == DungeonAffix.frozen && this.GetAffixData(DungeonAffix.frozen) >= 10 && this.DizzyLayer <= 0)
		{
			this.RemoveAffix(DungeonAffix.frozen);
			this.DizzyLayer = 1;
		}
		if (affix == DungeonAffix.vitality && this.GetAffixData(DungeonAffix.vitality) >= 10)
		{
			this.RemoveAffix(DungeonAffix.vitality);
			this.IsAttacked = false;
		}
	}

	public void RemoveAffix(DungeonAffix affix)
	{
		if (this.HasAffix(affix))
		{
			this.affixesDic.Remove(affix);
			if (this.CardGameObject == null)
			{
				return;
			}
			if (this.CardGameObject.affixesImg != null && this.CardGameObject.affixesImg.ContainsKey(affix))
			{
				UnityEngine.Object.Destroy(this.CardGameObject.affixesImg[affix]);
				this.CardGameObject.affixesImg.Remove(affix);
			}
		}
	}

	public void RemoveCardLogic(CardLogic cl)
	{
		if (this.CardLogics != null)
		{
			DungeonOperationMgr.Instance.StartCoroutine(cl.Terminate(this.CurrentCardSlotData));
			this.CardLogics.Remove(cl);
		}
	}

	public static string GetChinessName()
	{
		string[] array = new string[]
		{
			"白",
			"毕",
			"卞",
			"蔡",
			"曹",
			"岑",
			"常",
			"车",
			"陈",
			"成",
			"程",
			"池",
			"邓",
			"丁",
			"范",
			"方",
			"樊",
			"闫",
			"倪",
			"周",
			"费",
			"冯",
			"符",
			"元",
			"袁",
			"岳",
			"云",
			"曾",
			"詹",
			"张",
			"章",
			"赵",
			"郑",
			"钟",
			"周",
			"邹",
			"朱",
			"褚",
			"庄",
			"卓",
			"傅",
			"甘",
			"高",
			"葛",
			"龚",
			"古",
			"关",
			"郭",
			"韩",
			"何",
			"贺",
			"洪",
			"侯",
			"胡",
			"华",
			"黄",
			"霍",
			"姬",
			"简",
			"姜",
			"蒋",
			"金",
			"康",
			"柯",
			"孔",
			"赖",
			"郎",
			"乐",
			"雷",
			"黎",
			"李",
			"连",
			"廉",
			"梁",
			"廖",
			"林",
			"凌",
			"刘",
			"柳",
			"龙",
			"卢",
			"鲁",
			"陆",
			"路",
			"吕",
			"罗",
			"骆",
			"马",
			"梅",
			"孟",
			"莫",
			"母",
			"穆",
			"倪",
			"宁",
			"欧",
			"区",
			"潘",
			"彭",
			"蒲",
			"皮",
			"齐",
			"戚",
			"钱",
			"强",
			"秦",
			"丘",
			"邱",
			"饶",
			"任",
			"沈",
			"盛",
			"施",
			"石",
			"时",
			"史",
			"司徒",
			"苏",
			"孙",
			"谭",
			"汤",
			"唐",
			"陶",
			"田",
			"童",
			"涂",
			"王",
			"危",
			"韦",
			"卫",
			"魏",
			"温",
			"文",
			"翁",
			"巫",
			"邬",
			"吴",
			"伍",
			"武",
			"席",
			"夏",
			"萧",
			"谢",
			"辛",
			"邢",
			"徐",
			"许",
			"薛",
			"严",
			"颜",
			"杨",
			"叶",
			"易",
			"殷",
			"尤",
			"于",
			"余",
			"俞",
			"虞"
		};
		string text = "大小二三大二三四四雷铁蛋硬钢春奔牛驴头烈刀笑狗翠花锤铲建娘千百如妞柱麻红喜拴凤彩莽";
		string text2 = array[SYNCRandom.Range(0, array.Length - 1)] + text[SYNCRandom.Range(0, text.Length - 1)].ToString();
		if (SYNCRandom.Range(0, 100) > 49)
		{
			text2 += text[SYNCRandom.Range(0, text.Length - 1)].ToString();
		}
		return text2;
	}

	public void ChangeHeroHp(int value, bool isSimulation = false)
	{
		int changedValue = value - this.HP;
		this.HP = value;
		if (isSimulation)
		{
			return;
		}
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			cardLogic.OnHpChange(this, changedValue, null);
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				CardData childCardData = cardSlotData.ChildCardData;
			}
		}
	}

	public void ChangeHeroMp(int value, bool isSimulation = false)
	{
		int changedValue = value - this.MP;
		this.MP = value;
		if (isSimulation)
		{
			return;
		}
		foreach (CardLogic cardLogic in this.CardLogics)
		{
			cardLogic.OnMpChange(this, changedValue);
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				CardData childCardData = cardSlotData.ChildCardData;
				foreach (CardLogic cardLogic2 in this.CardLogics)
				{
					cardLogic2.OnMpChange(this, changedValue);
				}
			}
		}
	}

	[NonSerialized]
	public MinionTempData TempData;

	[NonSerialized]
	private CardData TempCardData;

	[NonSerialized]
	public Card CardGameObject;

	[NonSerialized]
	public CardSlotData CurrentCardSlotData;

	[NonSerialized]
	public bool IsToy;

	public string CurrentAreaID;

	public string PreName;

	public List<string> MergedCardModIDs;

	public string ADJ_Affix;

	public string ADV_Affix;

	public string V_Affix;

	[JsonProperty("CharactorTag"), NonSerialized]
	private CharacterTag _charactorTag;

	public ulong CharactorTagUlong;

	[JsonProperty("PersonName"), NonSerialized]
	private string _personName;

	public ArmsUsagePositionType ArmsUsagePosition;

	public int UsageTimes;

	public int MaxUsageTimes;

	public int TotalTime;

	public int RemainTime;

	public CardData.LifeType Life;

	public float LimitedTime;

	public int Frequency;

	public int killEnemyCount;

	public int MaxCount = 1;

	public int Count = 1;

	public int Rare;

	public ulong CardTags;

	public ulong AcceptTags;

	public string desc;

	public int UnHappy;

	public int Charm;

	public int Production;

	public int Intelligence;

	[NonSerialized]
	public string[] Struct;

	[NonSerialized]
	public int StructWidth;

	[NonSerialized]
	public int StructHeight;

	[NonSerialized]
	public Texture2D StructTexture;

	[NonSerialized]
	public string StructBase64String;

	[NonSerialized]
	public int StructId;

	public int Clock = -1;

	public string Logic;

	public List<string> CardLogicClassNames = new List<string>();

	public List<CardLogic> CardLogics = new List<CardLogic>();

	public CardData ammoContainer;

	public List<ActData> ActDatas;

	public int sacrificeVal;

	public int rotateTime;

	[NonSerialized]
	public bool IsFlipAnimDone;

	public bool IsAttacked;

	public int Level = 1;

	public int MaxHP;

	public int HP;

	public float HB;

	public int EXATK;

	public int EXATKTimes;

	public List<int> EXRange;

	public int AddHP;

	public int InBattleATK;

	public int AttackColor;

	public int Armor;

	public int wArmor;

	public int MaxArmor;

	public float DArmor;

	public int DizzyLayer;

	[JsonProperty("ATK")]
	public int _ATK;

	[JsonProperty("AttackTimes")]
	public int _AttackTimes = 1;

	public int wAttackTimes;

	public int NextAttackTimes;

	public float AB;

	public int MP;

	public int BasicMaxMp;

	public int ManaCost;

	public int MaxMP;

	public float DHP;

	public float wDHP;

	public int wHP;

	public float DATK;

	public float wDATK;

	public int wATK;

	public int ATKRange;

	[JsonProperty("CRIT")]
	public int _CRIT;

	public int wCRIT;

	public int InBattleCRIT;

	public int SPD;

	public int RemainSPD;

	public int MoveRange;

	public List<Vector3Int> AttackExtraRange;

	public int Exp;

	public string ShotEffect = "Effect/Attack";

	public string HitEffect = "Effect/BeAttack";

	public int BlueLine;

	public int RedLine;

	public int YellowLine;

	public int Value;

	public int Price = 1;

	[NonSerialized]
	public int PriceMaxFluctuation;

	[NonSerialized]
	public int ContainsNumber;

	[NonSerialized]
	public List<string> ContainsIDs;

	public bool IsCopy;

	[NonSerialized]
	public List<string> Belongings;

	[NonSerialized]
	public List<string> DefaultBelongings;

	public List<string> PreNameList;

	public int CoveredWidth = 1;

	public int CoveredHeight = 1;

	public enum LifeType
	{
		Infinite,
		Limited,
		Frequen,
		Timer
	}
}
