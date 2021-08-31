using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipsUI : MonoBehaviour
{
	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public void OpenTips(CardData cardData, Vector3 position)
	{
		if (this.m_CurrentTipsCardData != cardData)
		{
			this.m_CurrentTipsCardData = cardData;
		}
		else
		{
			if (this.p_CurrentTipsCardData == cardData)
			{
				return;
			}
			this.p_CurrentTipsCardData = cardData;
		}
		if (cardData.HasTag(TagMap.玩具))
		{
			return;
		}
		this.m_CurrentTipsCardData = cardData;
		base.gameObject.SetActive(true);
		this.m_StringBuilder.Clear();
		this.m_SecondStringBuilder.Clear();
		if (cardData.HasTag(TagMap.奇遇))
		{
			cardData.desc = "<size=18><color=yellow>";
			if (cardData.ModID.Equals("战斗卡"))
			{
				if (cardData.Attrs.ContainsKey("Theme"))
				{
					string[] array = cardData.Attrs["Theme"].ToString().Split(new char[]
					{
						','
					});
					cardData.desc += LocalizationMgr.Instance.GetLocalizationWord("T_怪物类型");
					foreach (string s in array)
					{
						cardData.desc = cardData.desc + ((DungeonTheme)int.Parse(s)).ToString() + " ";
					}
				}
				cardData.desc = string.Concat(new string[]
				{
					cardData.desc,
					"\n",
					LocalizationMgr.Instance.GetLocalizationWord("T_怪物强度"),
					cardData.Rare.ToString(),
					"\n",
					LocalizationMgr.Instance.GetLocalizationWord("T_胜利后可获得"),
					((1 << cardData.Rare - 1) * 50).ToString(),
					LocalizationMgr.Instance.GetLocalizationWord("T_战斗卡的等级越高")
				});
			}
			if (cardData.ModID.Equals("酒馆卡"))
			{
				cardData.desc = string.Concat(new string[]
				{
					cardData.desc,
					LocalizationMgr.Instance.GetLocalizationWord("T_酒馆中的随从数量"),
					(cardData.Rare + 2).ToString(),
					"\n\n",
					LocalizationMgr.Instance.GetLocalizationWord("T_随从基础属性提升"),
					cardData.Rare.ToString(),
					"%"
				});
			}
			if (cardData.ModID.Equals("商铺卡"))
			{
				cardData.desc = string.Concat(new string[]
				{
					cardData.desc,
					LocalizationMgr.Instance.GetLocalizationWord("T_当前商店等级"),
					(cardData.Rare + 2).ToString(),
					"\n\n",
					LocalizationMgr.Instance.GetLocalizationWord("T_商店的等级越高")
				});
			}
			if (cardData.ModID.Equals("玩具卡"))
			{
				cardData.desc += LocalizationMgr.Instance.GetLocalizationWord("T_玩具卡还没有做完");
			}
			if (cardData.ModID.Equals("帐篷卡"))
			{
				cardData.desc = string.Concat(new string[]
				{
					cardData.desc,
					LocalizationMgr.Instance.GetLocalizationWord("T_当前帐篷等级"),
					cardData.Rare.ToString(),
					"\n",
					LocalizationMgr.Instance.GetLocalizationWord("T_全员回复"),
					(10 + 20 * cardData.Rare).ToString(),
					LocalizationMgr.Instance.GetLocalizationWord("T_帐篷的等级越高")
				});
			}
			cardData.desc = cardData.desc + "</color></size>\n<color=green>" + LocalizationMgr.Instance.GetLocalizationWord("T_同样的地点卡片") + "</color>";
		}
		this.AddNameAndDesc(cardData);
		if (cardData.HasTag(TagMap.怪物))
		{
			this.OpenEnemyTips(cardData);
		}
		else if (cardData.HasTag(TagMap.随从))
		{
			this.OpenMinionTips(cardData);
		}
		else if (cardData.HasTag(TagMap.地下城入口))
		{
			this.OpenEnterTips(cardData);
		}
		else if (cardData.HasTag(TagMap.法术))
		{
			this.AddManaConsume(cardData);
		}
		else if (cardData.HasTag(TagMap.装备))
		{
			this.OpenMedicineTips(cardData);
		}
		else if (cardData.HasTag(TagMap.道具) || cardData.HasTag(TagMap.符文))
		{
			this.OpenMedicineTips(cardData);
		}
		this.Panel.GetComponentInChildren<TextMeshProUGUI>().text = this.m_StringBuilder.ToString();
		this.NamePanel.anchoredPosition = new Vector2(0f, this.Panel.sizeDelta.y);
		this.SetPanelPosition(cardData, position);
	}

	public void CloseTips()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		this.SecondPanel.gameObject.SetActive(false);
		this.StructPanel.gameObject.SetActive(false);
		base.gameObject.SetActive(false);
		this.m_CurrentTipsCardData = null;
	}

	private void OpenEnemyTips(CardData cardData)
	{
		this.AddArmor(cardData);
		this.m_StringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("T_攻击") + ":" + cardData.ATK.ToString());
		this.AddAffix(cardData);
	}

	private void OpenEnterTips(CardData cardData)
	{
		this.AddAffix(cardData);
	}

	private void OpenMinionTips(CardData cardData)
	{
		this.m_StringBuilder.Append("<size=20>");
		this.AddArmor(cardData);
		this.AddHp(cardData, this.m_StringBuilder);
		this.m_StringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("T_等级") + ":" + cardData.Rare.ToString());
		this.m_StringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("T_攻击") + ":" + cardData.ATK.ToString());
		this.m_StringBuilder.Append(string.Concat(new string[]
		{
			"\n",
			LocalizationMgr.Instance.GetLocalizationWord("T_攻击力加成"),
			":",
			cardData.EXATK.ToString(),
			"%"
		}));
		this.m_StringBuilder.Append(string.Concat(new string[]
		{
			"\n",
			LocalizationMgr.Instance.GetLocalizationWord("T_暴击率"),
			":",
			cardData.CRIT.ToString(),
			"%"
		}));
		this.m_StringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("T_攻击距离") + ":" + cardData.ATKRange.ToString());
		this.m_StringBuilder.Append("</size>");
		this.AddAffix(cardData);
	}

	private void OpenMedicineTips(CardData cardData)
	{
		this.AddAffix(cardData);
	}

	private void AddLevelChange(Hero hero, CardData copyHeroData)
	{
		string text = "\n等级:" + hero.HeroCard.Level.ToString() + "→" + copyHeroData.Level.ToString();
		if (copyHeroData.Level > hero.HeroCard.Level)
		{
			this.AddGreenFontSetting(this.m_SecondStringBuilder, text);
			return;
		}
		this.m_SecondStringBuilder.Append(text);
	}

	private void AddHpChange(CardData cardData, CardData copyCardData)
	{
		if (copyCardData.HP <= 0)
		{
			this.AddRedFontStart(this.m_SecondStringBuilder);
		}
		else
		{
			this.AddGreenFontStart(this.m_SecondStringBuilder);
		}
		this.AddHp(cardData, this.m_SecondStringBuilder);
		this.m_SecondStringBuilder.Append("→" + Mathf.Max(0, copyCardData.HP).ToString());
		this.m_SecondStringBuilder.Append("      " + ((copyCardData.HP <= 0) ? "死亡" : "存活"));
		this.AddColorFontEnd(this.m_SecondStringBuilder);
	}

	private void AddExpChange(CardData cardData, CardData copyCardData)
	{
		string text = "\n经验:" + cardData.Exp.ToString() + "→" + copyCardData.Exp.ToString();
		if (copyCardData.Exp > cardData.Exp)
		{
			this.AddGreenFontSetting(this.m_SecondStringBuilder, text);
			return;
		}
		if (cardData.HasTag(TagMap.随从))
		{
			text = "\n经验:" + cardData.Exp.ToString();
			this.m_StringBuilder.Append(text);
			return;
		}
		this.m_SecondStringBuilder.Append(text);
	}

	private void AddSecondPanelChangeData(Hero hero, CardData attackCard, CardData copyHeroData, CardData copyAttackCard)
	{
		this.m_SecondStringBuilder.Append("\n");
		this.m_SecondStringBuilder.Append("\n<size=+4>" + hero.HeroCard.Name + "属性变化</size>");
		string text = "\n等级:" + hero.HeroCard.Level.ToString() + "→" + copyHeroData.Level.ToString();
		if (copyHeroData.Level > hero.HeroCard.Level)
		{
			this.AddGreenFontSetting(this.m_SecondStringBuilder, text);
		}
		else
		{
			this.m_SecondStringBuilder.Append(text);
		}
		if (copyHeroData.HP <= 0)
		{
			this.AddRedFontStart(this.m_SecondStringBuilder);
		}
		else
		{
			this.AddGreenFontStart(this.m_SecondStringBuilder);
		}
		this.AddHp(hero.HeroCard, this.m_SecondStringBuilder);
		this.m_SecondStringBuilder.Append("→" + copyHeroData.HP.ToString());
		this.m_SecondStringBuilder.Append("      " + ((copyHeroData.HP <= 0) ? "死亡" : "存活"));
		this.AddColorFontEnd(this.m_SecondStringBuilder);
		if (hero.HeroCard != attackCard)
		{
			this.m_SecondStringBuilder.Append("\n");
			this.m_SecondStringBuilder.Append("\n<size=+4>" + attackCard.Name + "属性变化</size>");
			if (copyAttackCard.HP <= 0)
			{
				this.AddRedFontStart(this.m_SecondStringBuilder);
			}
			else
			{
				this.AddGreenFontStart(this.m_SecondStringBuilder);
			}
			this.AddHp(attackCard, this.m_SecondStringBuilder);
			this.m_SecondStringBuilder.Append("→" + copyAttackCard.HP.ToString());
			this.m_SecondStringBuilder.Append("      " + ((copyAttackCard.HP <= 0) ? "死亡" : "存活"));
			this.AddColorFontEnd(this.m_SecondStringBuilder);
		}
	}

	private void SetPanelPosition(CardData cardData, Vector3 position)
	{
		bool activeInHierarchy = this.SecondPanel.gameObject.activeInHierarchy;
		base.transform.position = CameraUtils.MainCamera.WorldToScreenPoint(position + new Vector3(0.5f, 0f, 0f));
		Vector2 size = base.GetComponent<RectTransform>().rect.size;
		if (activeInHierarchy)
		{
			size.x *= 3f;
		}
		if (base.transform.position.x + size.x > (float)Screen.width)
		{
			base.transform.position = CameraUtils.MainCamera.WorldToScreenPoint(position - new Vector3(0.5f, 0f, 0f)) - new Vector3(size.x, 0f, 0f);
		}
		else
		{
			base.transform.position = CameraUtils.MainCamera.WorldToScreenPoint(position + new Vector3(0.5f, 0f, 0f));
		}
		if (activeInHierarchy)
		{
			Vector2 sizeDelta = this.Panel.sizeDelta;
			this.SecondPanel.transform.localPosition = new Vector3(215.4f, -15.36011f, 0f);
			Vector3 position2 = this.SecondPanel.transform.position;
			size.y = this.SecondPanel.sizeDelta.y;
			if (position2.y + size.y > (float)Screen.height)
			{
				position2.y -= position2.y + size.y - (float)Screen.height;
			}
			this.SecondPanel.transform.position = position2;
		}
		RectTransform[] componentsInChildren = base.gameObject.GetComponentsInChildren<RectTransform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[i]);
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(this.NamePanel.GetComponent<RectTransform>());
		if (this.SecondPanel.gameObject.activeInHierarchy)
		{
			this.SecondPanel.gameObject.SetActive(false);
			this.SecondPanel.gameObject.SetActive(true);
		}
		if (base.gameObject.activeInHierarchy)
		{
			base.gameObject.SetActive(false);
			base.gameObject.SetActive(true);
		}
	}

	private void AddAffix(CardData cardData)
	{
		this.affixCount = 0;
		foreach (KeyValuePair<DungeonAffix, int> keyValuePair in cardData.affixesDic)
		{
			DungeonAffixInfoAttribute dungeonAffixInfo = DungeonOperationMgr.GetDungeonAffixInfo(keyValuePair.Key);
			if (dungeonAffixInfo != null)
			{
				this.AddDividingLineToFirst();
				this.m_StringBuilder.Append(string.Concat(new string[]
				{
					"\n<color=green>[",
					LocalizationMgr.Instance.GetLocalizationWord("A_N_" + dungeonAffixInfo.defaultName),
					"(",
					keyValuePair.Value.ToString(),
					")]</color>"
				}));
				this.m_StringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("A_D_" + dungeonAffixInfo.defaultName));
			}
		}
		if (cardData.CardLogics.Count > 0 || (cardData.HasTag(TagMap.食物) && (cardData.ATK > 0 || cardData.MaxHP > 0 || cardData.AttackTimes > 1 || cardData.HP > 0 || cardData.CRIT > 0 || cardData.EXATK > 0)))
		{
			this.SecondPanel.gameObject.SetActive(true);
			foreach (RectTransform rectTransform in this.LogicLabelList)
			{
				rectTransform.gameObject.SetActive(false);
			}
			int num = 0;
			int num2 = 0;
			if (cardData.CardLogics.Count > 0)
			{
				while (num2 < cardData.CardLogics.Count && num2 < 9)
				{
					CardLogic cardLogic = cardData.CardLogics[num2];
					cardLogic.OnShowTips();
					string text = cardData.CardLogics[num2].displayName;
					string text2 = cardData.CardLogics[num2].Desc;
					if (!string.IsNullOrEmpty(cardLogic.displayName) && !string.IsNullOrEmpty(cardLogic.Desc))
					{
						if (cardData.CardLogics[num2] is PersonCardLogic)
						{
							if (cardData.CardLogics[num2] is TwoPeopleCardLogic && (cardData.CardLogics[num2] as TwoPeopleCardLogic).TargetID != null)
							{
								try
								{
									CardData cardData2 = GameController.ins.CardDataInWorldMap[(cardData.CardLogics[num2] as TwoPeopleCardLogic).TargetID];
									text = string.Concat(new string[]
									{
										text,
										" 目标:",
										LocalizationMgr.Instance.GetLocalizationWord(cardData2.Name),
										" ",
										cardData2.PersonName
									});
								}
								catch (Exception)
								{
								}
							}
							if ((cardData.CardLogics[num2] as PersonCardLogic).Desc != null)
							{
								try
								{
									text2 = text2 + "\n" + LocalizationMgr.Instance.GetLocalizationWord("T_52") + (cardData.CardLogics[num2] as PersonCardLogic).Reason;
								}
								catch (Exception)
								{
								}
							}
						}
						this.LogicLabelList[num].gameObject.SetActive(true);
						this.affixCount++;
						this.LogicLabelList[num].GetComponent<Image>().color = GameController.RowColor[(int)cardLogic.Color];
						Vector3Int needEnergyCount = cardLogic.NeedEnergyCount;
						if (cardLogic.NeedEnergyCount.magnitude > 0f)
						{
							string text3 = "";
							if (cardLogic.NeedEnergyCount.x > 0)
							{
								text3 = text3 + "<color=#008EFF>  ●" + cardLogic.NeedEnergyCount.x.ToString() + "</color>";
							}
							if (cardLogic.NeedEnergyCount.y > 0)
							{
								text3 = text3 + "<color=#ff0000>  ●" + cardLogic.NeedEnergyCount.y.ToString() + "</color>";
							}
							if (cardLogic.NeedEnergyCount.z > 0)
							{
								text3 = text3 + "<color=#ffcc00>  ●" + cardLogic.NeedEnergyCount.z.ToString() + "</color>";
							}
							this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>().text = string.Concat(new string[]
							{
								"<size=20><color=#ffffff>[",
								text,
								" ",
								(cardLogic.Layers > 0) ? cardLogic.Layers.ToString() : "",
								"]  </color>  ",
								text3,
								"</size>\n(",
								LocalizationMgr.Instance.GetLocalizationWord("T_右键释放"),
								")"
							});
						}
						else if (cardLogic.ExistsRound > 0 && cardLogic.ExistsRound < 1000)
						{
							this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>().text = string.Concat(new string[]
							{
								"<size=20><color=#ffffff>[",
								text,
								" ",
								(cardLogic.Layers > 0) ? cardLogic.Layers.ToString() : "",
								"] </color></size><color=#000000>\n (",
								string.Format(LocalizationMgr.Instance.GetLocalizationWord("UI_持续"), cardLogic.ExistsRound),
								")</color>"
							});
						}
						else
						{
							this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>().text = string.Concat(new string[]
							{
								"<b><size=20><color=#ffffff>[",
								text,
								" ",
								(cardLogic.Layers > 0) ? cardLogic.Layers.ToString() : "",
								"]</color></size></b>"
							});
						}
						if (!string.IsNullOrEmpty(text2))
						{
							TextMeshProUGUI componentInChildren = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
							componentInChildren.text = componentInChildren.text + "\n" + text2;
						}
						float preferredHeight = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>().preferredHeight;
						this.LogicLabelList[num].sizeDelta = new Vector2(this.LogicLabelList[num].sizeDelta.x, preferredHeight + 15f);
						num++;
					}
					num2++;
				}
			}
			if (cardData.HasTag(TagMap.食物) && (cardData.ATK != 0 || cardData.MaxHP != 0 || cardData.AttackTimes > 1 || cardData.HP != 0 || cardData.CRIT != 0 || cardData.EXATK != 0 || cardData.ATKRange != 0))
			{
				this.LogicLabelList[num].gameObject.SetActive(true);
				this.affixCount++;
				this.LogicLabelList[num].GetComponent<Image>().color = GameController.RowColor[3];
				this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>().text = "<b><size=20><color=#ffffff>[" + LocalizationMgr.Instance.GetLocalizationWord("T_属性提升") + "]</color></size></b>";
				if (cardData.ATK != 0)
				{
					TextMeshProUGUI componentInChildren2 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren2.text = componentInChildren2.text + "\n" + LocalizationMgr.Instance.GetLocalizationWord("T_攻击力") + " ";
					if (cardData.ATK > 0)
					{
						TextMeshProUGUI componentInChildren3 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
						componentInChildren3.text = componentInChildren3.text + "+" + cardData.ATK.ToString();
					}
					else
					{
						TextMeshProUGUI componentInChildren4 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
						componentInChildren4.text += cardData.ATK.ToString();
					}
				}
				if (cardData.HP > 0)
				{
					TextMeshProUGUI componentInChildren5 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren5.text = string.Concat(new string[]
					{
						componentInChildren5.text,
						"\n",
						LocalizationMgr.Instance.GetLocalizationWord("T_回复"),
						" ",
						cardData.HP.ToString(),
						LocalizationMgr.Instance.GetLocalizationWord("T_生命值"),
						" "
					});
				}
				if (cardData.MaxHP != 0)
				{
					TextMeshProUGUI componentInChildren5 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren5.text = string.Concat(new string[]
					{
						componentInChildren5.text,
						"\n",
						LocalizationMgr.Instance.GetLocalizationWord("T_生命值"),
						" ",
						(cardData.MaxHP > 0) ? ("+" + cardData.MaxHP.ToString()) : cardData.MaxHP.ToString()
					});
				}
				if (cardData.CRIT != 0)
				{
					TextMeshProUGUI componentInChildren5 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren5.text = string.Concat(new string[]
					{
						componentInChildren5.text,
						"\n",
						LocalizationMgr.Instance.GetLocalizationWord("T_暴击率"),
						" ",
						(cardData.CRIT > 0) ? ("+" + cardData.CRIT.ToString()) : cardData.CRIT.ToString(),
						"%"
					});
				}
				if (cardData.EXATK != 0)
				{
					TextMeshProUGUI componentInChildren5 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren5.text = string.Concat(new string[]
					{
						componentInChildren5.text,
						"\n",
						LocalizationMgr.Instance.GetLocalizationWord("T_攻击力加成"),
						" ",
						(cardData.EXATK > 0) ? ("+" + cardData.EXATK.ToString()) : cardData.EXATK.ToString(),
						"%"
					});
				}
				if (cardData.AttackTimes > 1)
				{
					TextMeshProUGUI componentInChildren5 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren5.text = string.Concat(new string[]
					{
						componentInChildren5.text,
						"\n",
						LocalizationMgr.Instance.GetLocalizationWord("T_攻击频次"),
						" +",
						(cardData.AttackTimes - 1).ToString()
					});
				}
				if (cardData.ATKRange > 0)
				{
					TextMeshProUGUI componentInChildren5 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren5.text = string.Concat(new string[]
					{
						componentInChildren5.text,
						"\n",
						LocalizationMgr.Instance.GetLocalizationWord("T_攻击距离"),
						" +",
						cardData.ATKRange.ToString()
					});
				}
				float preferredHeight2 = this.LogicLabelList[num].GetComponentInChildren<TextMeshProUGUI>().preferredHeight;
				this.LogicLabelList[num].sizeDelta = new Vector2(this.LogicLabelList[num].sizeDelta.x, preferredHeight2 + 5f);
				num++;
			}
			if (num > 0)
			{
				this.SecondPanel.gameObject.SetActive(true);
				return;
			}
			this.SecondPanel.gameObject.SetActive(false);
		}
	}

	private void AddHp(CardData cardData, StringBuilder stringBuilder)
	{
		stringBuilder.Append(string.Concat(new string[]
		{
			"\n",
			LocalizationMgr.Instance.GetLocalizationWord("T_生命"),
			":",
			cardData.HP.ToString(),
			"/",
			cardData.MaxHP.ToString()
		}));
	}

	private void AddMp(CardData cardData, StringBuilder stringBuilder)
	{
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("T_能量") + ":" + cardData.MP.ToString());
	}

	private void AddPrice(CardData cardData, StringBuilder stringBuilder)
	{
		stringBuilder.Append("\n" + LocalizationMgr.Instance.GetLocalizationWord("T_售价") + ":" + Mathf.CeilToInt((float)cardData.Price / 3f).ToString());
	}

	private void AddArmor(CardData cardData)
	{
		this.m_StringBuilder.Append(string.Concat(new string[]
		{
			"\n",
			LocalizationMgr.Instance.GetLocalizationWord("T_护甲"),
			":",
			cardData.Armor.ToString(),
			"/",
			cardData.MaxArmor.ToString()
		}));
	}

	private void AddHpChange(CardData cardData, CardData copyCard, StringBuilder stringBuilder)
	{
		if (copyCard.HP <= 0)
		{
			this.AddRedFontStart(stringBuilder);
		}
		else
		{
			this.AddGreenFontStart(stringBuilder);
		}
		this.AddHp(cardData, stringBuilder);
		stringBuilder.Append("→" + copyCard.HP.ToString());
		stringBuilder.Append("      " + ((copyCard.HP == 0) ? "死亡" : "存活"));
		this.AddColorFontEnd(this.m_StringBuilder);
	}

	private void AddLevel(CardData cardData)
	{
		this.m_StringBuilder.Append("\n等级:" + cardData.Level.ToString());
	}

	private void AddManaConsume(CardData cardData)
	{
	}

	private void AddNameAndDesc(CardData cardData)
	{
		this.NamePanel.GetComponentInChildren<TextMeshProUGUI>().text = "";
		if (cardData.PreNameList.Count > 0)
		{
			foreach (string key in cardData.PreNameList)
			{
				TextMeshProUGUI componentInChildren = this.NamePanel.GetComponentInChildren<TextMeshProUGUI>();
				componentInChildren.text += LocalizationMgr.Instance.GetLocalizationWord(key);
			}
		}
		TextMeshProUGUI componentInChildren2 = this.NamePanel.GetComponentInChildren<TextMeshProUGUI>();
		componentInChildren2.text += LocalizationMgr.Instance.GetLocalizationWord(cardData.Name);
		if (!string.IsNullOrEmpty(cardData.PersonName) && GameController.ins.GameData.isInDungeon)
		{
			if (GlobalController.Instance.GameSettingController.info.language != LanguageType.ZH_CN)
			{
				TextMeshProUGUI componentInChildren3 = this.NamePanel.GetComponentInChildren<TextMeshProUGUI>();
				componentInChildren3.text = componentInChildren3.text + " " + cardData.PersonName;
			}
			else
			{
				TextMeshProUGUI componentInChildren4 = this.NamePanel.GetComponentInChildren<TextMeshProUGUI>();
				componentInChildren4.text = componentInChildren4.text + " " + cardData.PersonName;
			}
		}
		if (cardData.CharactorTag != (CharacterTag)0UL && GameController.ins.GameData.isInDungeon)
		{
			if (GlobalController.Instance.GameSettingController.info.language != LanguageType.ZH_CN)
			{
				this.m_StringBuilder.Append("<size=18><color=#FFFFFF>[" + ((CharacterTag_EN)cardData.CharactorTag).ToString().Replace(',', '|') + "]</color></size>\n");
			}
			else
			{
				this.m_StringBuilder.Append("<size=18><color=#FFFFFF>[" + cardData.CharactorTag.ToString().Replace(',', '|') + "]</color></size>\n");
			}
		}
		if (GlobalController.Instance.GameSettingController.info.language != LanguageType.ZH_CN)
		{
			StringBuilder stringBuilder = this.m_StringBuilder;
			string str = "<size=15><color=#6BBBF3>[";
			TagMapDisplay_EN cardTags = (TagMapDisplay_EN)cardData.CardTags;
			stringBuilder.Append(str + cardTags.ToString().Replace(',', '|') + "]</color></size>\n");
		}
		else
		{
			StringBuilder stringBuilder2 = this.m_StringBuilder;
			string str2 = "<size=15><color=#6BBBF3>[";
			TagMap cardTags2 = (TagMap)cardData.CardTags;
			stringBuilder2.Append(str2 + cardTags2.ToString().Replace(',', '|') + "]</color></size>\n");
		}
		if (cardData.HasTag(TagMap.装备))
		{
			this.m_StringBuilder.Append("<size=15><color=red>把它放在随从");
			int num = 0;
			if ((cardData.ArmsUsagePosition & ArmsUsagePositionType.Top) == ArmsUsagePositionType.Top)
			{
				num++;
				this.m_StringBuilder.Append(" 下方");
			}
			if ((cardData.ArmsUsagePosition & ArmsUsagePositionType.Bottom) == ArmsUsagePositionType.Bottom)
			{
				num++;
				if (num > 1)
				{
					this.m_StringBuilder.Append("或");
				}
				this.m_StringBuilder.Append(" 上方");
			}
			if ((cardData.ArmsUsagePosition & ArmsUsagePositionType.Left) == ArmsUsagePositionType.Left)
			{
				num++;
				if (num > 1)
				{
					this.m_StringBuilder.Append("或");
				}
				this.m_StringBuilder.Append(" 右侧");
			}
			if ((cardData.ArmsUsagePosition & ArmsUsagePositionType.Right) == ArmsUsagePositionType.Right)
			{
				num++;
				if (num > 1)
				{
					this.m_StringBuilder.Append("或");
				}
				this.m_StringBuilder.Append(" 左侧");
			}
			this.m_StringBuilder.Append(" 来使用武器</color></size>\n");
		}
		if (!string.IsNullOrEmpty(cardData.desc))
		{
			this.m_StringBuilder.Append("<size=17>" + LocalizationMgr.Instance.GetLocalizationWord(cardData.desc) + "</size>\n");
		}
		int num2 = cardData.Rare * 30;
		if (cardData.Rare > 10)
		{
			num2 = 30;
		}
		if (cardData.HasTag(TagMap.特殊))
		{
			num2 = cardData.Price;
		}
		this.m_StringBuilder.Append(string.Concat(new string[]
		{
			"\n<size=17>",
			LocalizationMgr.Instance.GetLocalizationWord("T_出售获得"),
			num2.ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("T_金币"),
			"</size>\n"
		}));
		if (cardData.MergedCardModIDs != null)
		{
			this.m_StringBuilder.Append("\n<color=red>" + LocalizationMgr.Instance.GetLocalizationWord("T_曾吞噬") + "</color>");
			foreach (string key2 in cardData.MergedCardModIDs)
			{
				this.m_StringBuilder.Append("<color=red> " + LocalizationMgr.Instance.GetLocalizationWord(key2) + "</color>");
			}
		}
	}

	private void AddDividingLineToFirst()
	{
		this.m_StringBuilder.Append("\n---------------  ");
	}

	private void AddDividingLIneToSecond()
	{
		this.m_SecondStringBuilder.Append("\n---------------  ");
	}

	private void AddRedFontSetting(StringBuilder stringBuilder, string str)
	{
		this.AddRedFontStart(stringBuilder);
		stringBuilder.Append(str);
		this.AddColorFontEnd(stringBuilder);
	}

	private void AddGreenFontSetting(StringBuilder stringBuilder, string str)
	{
		this.AddGreenFontStart(stringBuilder);
		stringBuilder.Append(str);
		this.AddColorFontEnd(stringBuilder);
	}

	private void AddGreenFontStart(StringBuilder stringBuilder)
	{
		stringBuilder.Append("<color=green>");
	}

	private void AddRedFontStart(StringBuilder stringBuilder)
	{
		stringBuilder.Append("<color=red>");
	}

	private void AddColorFontEnd(StringBuilder stringBuilder)
	{
		stringBuilder.Append("</color>");
	}

	public RectTransform HPBar;

	public RectTransform Panel;

	public RectTransform SecondPanel;

	public RectTransform NamePanel;

	public GameObject StructPanel;

	public Image StructImage;

	public Image StructMask;

	public List<RectTransform> LogicLabelList;

	private StringBuilder m_StringBuilder = new StringBuilder();

	private StringBuilder m_SecondStringBuilder = new StringBuilder();

	private CardData m_CurrentTipsCardData;

	private CardData p_CurrentTipsCardData;

	private const string c_Arrow = "→";

	private const string c_LineFeed = "\n";

	private int affixCount;
}
