using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BaBaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_正义执行");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_正义执行");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_正义执行");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_正义执行");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn && !this.Run)
		{
			if (!this.CardData.Attrs.ContainsKey("Son"))
			{
				yield break;
			}
			string b = this.CardData.Attrs["Son"].ToString();
			CardData Son = null;
			foreach (CardData cardData in base.GetAllCurrentMonsters())
			{
				if (cardData.ID == b)
				{
					Son = cardData;
				}
			}
			if (Son != null)
			{
				List<CardSlotData> path = base.GetPath(DungeonOperationMgr.Instance.BattleArea, this.CardData.CurrentCardSlotData, Son.CurrentCardSlotData);
				if (path.Count == 1)
				{
					float num = Mathf.Pow((float)(Son.CurrentCardSlotData.GridPositionX - this.CardData.CurrentCardSlotData.GridPositionX), 2f);
					float num2 = Mathf.Pow((float)(Son.CurrentCardSlotData.GridPositionY - this.CardData.CurrentCardSlotData.GridPositionY), 2f);
					if (num + num2 == 1f)
					{
						yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_爸爸1"));
						Vector3 vector = new Vector3(-9.53f, 0f, 5.14f);
						this.Taken = true;
						this.CardData.CurrentCardSlotData.ClearCardData();
						Son.CurrentCardSlotData.ClearCardData();
						this.CardData.CardGameObject.transform.DOJump(vector + this.CardData.CardGameObject.transform.position - Son.CardGameObject.transform.position, 0.5f, 5, 2f, false);
						yield return Son.CardGameObject.transform.DOJump(vector, 0.5f, 5, 2f, false).WaitForCompletion();
						yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(Son, -9999, null, true, 0, true, false);
						yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, null, true, 0, true, false);
						if (base.GetAllCurrentMonsters().Count > 0)
						{
							foreach (CardData cd in base.GetAllCurrentMonsters())
							{
								if (cd.Attrs.ContainsKey("Son"))
								{
									if (cd.Attrs["Son"].ToString() == this.CardData.ID.ToString())
									{
										yield return cd.CardLogics[0].ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_爸爸2"));
										yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cd, -9999, null, true, 0, true, false);
									}
									cd = null;
								}
							}
							List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
						}
					}
				}
				else if (!this.Jumped)
				{
					yield return this.CardData.CardGameObject.JumpToSlot(path[0].CardSlotGameObject, 0.2f, true);
					this.Jumped = true;
				}
			}
			else
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_爸爸3"));
				Vector3 endValue = new Vector3(-9.53f, 0f, 5.14f);
				yield return this.CardData.CardGameObject.transform.DOJump(endValue, 0.5f, 5, 2f, false).WaitForCompletion();
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, null, true, 0, true, false);
			}
			Son = null;
		}
		yield break;
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (!this.CardData.Attrs.ContainsKey("Son"))
		{
			yield break;
		}
		string b = this.CardData.Attrs["Son"].ToString();
		if (target.ID == b && !this.Taken)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_爸爸4"));
			yield return base.ShowXuLiEffect("居合释放", false);
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
			yield return base.Cure(this.CardData, 999, this.CardData);
			this.CardData.MaxArmor += 3;
			this.CardData.Armor += 3;
			this.CardData._ATK += 15;
			this.CardData.CardTags = 32768UL;
			this.Run = true;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.Jumped = false;
		yield break;
	}

	private bool Jumped = true;

	private bool Run;

	private bool Taken;
}
