using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InfinityEnemyRefreshLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnEnterArea(string areaID)
	{
		if (areaID.Equals("Infinity"))
		{
			GameController.GameSavingSyncLock = true;
			GameController.ins.SaveGame();
			this.infinityArea = UnityEngine.Object.FindObjectOfType<InfinityArea>();
			this.infinityArea.LevelText.text = (GameController.ins.GameData.level.ToString() ?? "");
			if (this.m_EnmeyArea.Count > 0)
			{
				yield break;
			}
			InfinityAreaLogic infinityAreaLogic = GameController.ins.GetCurrentAreaData().Logics[0] as InfinityAreaLogic;
			this.m_EnmeyArea = infinityAreaLogic.EnemyCardArea;
			this.m_EnmeyArea[0].SlotType = CardSlotData.Type.Freeze;
			using (List<CardSlotData>.Enumerator enumerator = this.m_EnmeyArea.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ChildCardData != null)
					{
						yield break;
					}
				}
			}
			for (int i = 0; i < this.m_EnmeyArea.Count; i++)
			{
				if (i % 3 == 1)
				{
					this.CreateInitEnemyCard(this.m_EnmeyArea[i]);
				}
			}
		}
		yield break;
	}

	private void CreateInitEnemyCard(CardSlotData slot)
	{
		CardData.CopyCardData(Card.InitCardDataByID("战斗卡"), true).PutInSlotData(slot, true);
	}

	public override IEnumerator OnMoveOnMap()
	{
		while (GameController.getInstance().CurrentAct != null)
		{
			yield return 0;
		}
		if (this.infinityArea == null)
		{
			this.infinityArea = UnityEngine.Object.FindObjectOfType<InfinityArea>();
		}
		GameController.ins.GameData.step++;
		this.m_Step++;
		this.infinityArea.SceneAnimator.SetTrigger("machine");
		int j;
		for (int i = 1; i < this.m_EnmeyArea.Count; i = j + 1)
		{
			if (this.m_EnmeyArea[i].ChildCardData != null)
			{
				yield return this.m_EnmeyArea[i].ChildCardData.CardGameObject.transform.DOJump(this.m_EnmeyArea[i - 1].CardSlotGameObject.transform.position, 1f, 1, 0.5f, false).WaitForCompletion();
				this.m_EnmeyArea[i].ChildCardData.PutInSlotData(this.m_EnmeyArea[i - 1], true);
			}
			j = i;
		}
		if (this.m_Step % 3 == 1)
		{
			this.infinityArea.SceneAnimator.Rebind();
			CardData enemy = CardData.CopyCardData(Card.InitCardDataByID("战斗卡"), true);
			Card.InitCard(enemy);
			this.infinityArea.SceneAnimator.SetTrigger("do");
			enemy.CardGameObject.transform.SetParent(this.infinityArea.ShowPoint);
			enemy.CardGameObject.transform.localPosition = Vector3.zero;
			yield return new WaitForSeconds(0.3f);
			this.infinityArea.TipGo.SetActive(false);
			yield return new WaitForSeconds(3f);
			enemy.CardGameObject.transform.position = this.m_EnmeyArea[this.m_EnmeyArea.Count - 1].CardSlotGameObject.transform.position;
			enemy.CardGameObject.transform.localScale = Vector3.one;
			enemy.PutInSlotData(this.m_EnmeyArea[this.m_EnmeyArea.Count - 1], true);
			enemy = null;
		}
		if (this.m_EnmeyArea[0].ChildCardData != null)
		{
			if (this.m_SceneLogics.Count > 0)
			{
				foreach (CardLogic cl in this.m_SceneLogics)
				{
					this.CardData.RemoveCardLogic(cl);
				}
			}
			this.m_SceneLogics = new List<CardLogic>();
			if (this.m_EnmeyArea[0].ChildCardData.Attrs.ContainsKey("Theme"))
			{
				if (this.m_EnmeyArea[0].ChildCardData.Attrs.ContainsKey("JieJieName"))
				{
					string[] array = this.m_EnmeyArea[0].ChildCardData.Attrs["Theme"].ToString().Split(new char[]
					{
						','
					});
					string text = "";
					foreach (string text2 in array)
					{
						if (text2 != null)
						{
							uint num = <PrivateImplementationDetails>.ComputeStringHash(text2);
							if (num <= 822911587U)
							{
								if (num <= 501951850U)
								{
									if (num != 468396612U)
									{
										if (num != 485174231U)
										{
											if (num == 501951850U)
											{
												if (text2 == "12")
												{
													text += "画室_";
												}
											}
										}
										else if (text2 == "11")
										{
											text += "雪地_";
										}
									}
									else if (text2 == "10")
									{
										text += "颓废街头_";
									}
								}
								else if (num != 518729469U)
								{
									if (num != 806133968U)
									{
										if (num == 822911587U)
										{
											if (text2 == "4")
											{
												text += "枫林_";
											}
										}
									}
									else if (text2 == "5")
									{
										text += "地牢_";
									}
								}
								else if (text2 == "13")
								{
									text += "健身房_";
								}
							}
							else if (num <= 873244444U)
							{
								if (num != 839689206U)
								{
									if (num != 856466825U)
									{
										if (num == 873244444U)
										{
											if (text2 == "1")
											{
												text += "森林_";
											}
										}
									}
									else if (text2 == "6")
									{
										text += "游戏公司_";
									}
								}
								else if (text2 == "7")
								{
									text += "火山_";
								}
							}
							else if (num <= 923577301U)
							{
								if (num != 906799682U)
								{
									if (num == 923577301U)
									{
										if (text2 == "2")
										{
											text += "沙漠_";
										}
									}
								}
								else if (text2 == "3")
								{
									text += "虫巢_";
								}
							}
							else if (num != 1007465396U)
							{
								if (num == 1024243015U)
								{
									if (text2 == "8")
									{
										text += "马戏团_";
									}
								}
							}
							else if (text2 == "9")
							{
								text += "网吧_";
							}
						}
					}
					this.ShowTabooAndDesc(text);
					foreach (string logicName in this.m_EnmeyArea[0].ChildCardData.Attrs["JieJieName"].ToString().Split(new char[]
					{
						','
					}))
					{
						CardLogic item = this.AddLogic(logicName);
						this.m_SceneLogics.Add(item);
					}
				}
				else
				{
					GameController.ins.UIController.AreaAdvocateDesc.transform.parent.parent.DOMoveX(-300f, 0.5f, false);
				}
			}
			if (this.m_EnmeyArea[0].ChildCardData.ModID.Equals("战斗卡"))
			{
				this.curPoints = (int)Mathf.Pow(2f, (float)this.m_EnmeyArea[0].ChildCardData.Rare) - 1;
			}
			this.infinityArea.TipGo.SetActive(true);
			yield return DungeonController.Instance.GetAndPickTheFlipedCards(new List<CardData>
			{
				this.m_EnmeyArea[0].ChildCardData
			}, true);
		}
		yield break;
	}

	private CardLogic AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
		return cardLogic;
	}

	private void ShowTabooAndDesc(string sceneModID)
	{
		string[] array = sceneModID.Split(new char[]
		{
			'_'
		});
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		foreach (string text5 in array)
		{
			if (!string.IsNullOrEmpty(text5))
			{
				AreaData areaDataByModID = GameController.ins.AreaDataModMap.getAreaDataByModID(text5);
				if (!string.IsNullOrEmpty(areaDataByModID.AdvocateName))
				{
					text = text + LocalizationMgr.Instance.GetLocalizationWord(areaDataByModID.AdvocateName) + " ";
					text2 = text2 + "\n● " + LocalizationMgr.Instance.GetLocalizationWord(areaDataByModID.AdvocateDESC) + "\n";
				}
				if (!string.IsNullOrEmpty(areaDataByModID.TabooName))
				{
					text3 = text3 + LocalizationMgr.Instance.GetLocalizationWord(areaDataByModID.TabooName) + " ";
					text4 = text4 + "\n● " + LocalizationMgr.Instance.GetLocalizationWord(areaDataByModID.TabooDESC) + "\n";
				}
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			GameController.ins.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("T_36"),
				" - ",
				text,
				"\n<size=16>\n",
				text2,
				"</size>"
			});
			GameController.ins.UIController.AreaAdvocateDesc.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			GameController.ins.UIController.AreaAdvocateDesc.transform.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
		}
		if (!string.IsNullOrEmpty(text3))
		{
			GameController.ins.UIController.AreaTabooDesc.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("T_37"),
				" - ",
				text3,
				"\n<size=16>\n",
				text4,
				"</size>"
			});
			GameController.ins.UIController.AreaTabooDesc.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			GameController.ins.UIController.AreaTabooDesc.transform.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
		}
		GameController.ins.UIController.AreaAdvocateDesc.transform.parent.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
		GameController.ins.UIController.AreaAdvocateDesc.transform.parent.parent.DOMoveX(0f, 0.5f, false);
	}

	public override IEnumerator OnBattleEnd()
	{
		GameController.ins.GameData.level += this.curPoints;
		this.curPoints = 0;
		this.infinityArea.LevelText.text = (GameController.ins.GameData.level.ToString() ?? "");
		yield break;
	}

	private InfinityArea infinityArea;

	private List<CardSlotData> m_EnmeyArea = new List<CardSlotData>();

	public int m_Step;

	private List<CardLogic> m_SceneLogics = new List<CardLogic>();

	private int curPoints;
}
