using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DengShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.target = null;
		this.line = null;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇2");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		base.ShowMe();
		yield return this.ChangeColorN();
		yield return this.ChangeColorB();
		this.StoneFlag = true;
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		this.target = allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)];
		if (this.line != null)
		{
			UVChainLightning component = this.line.GetComponent<UVChainLightning>();
			component.target = this.target;
			component.gameObject.SetActive(true);
		}
		else
		{
			this.line = this.GetChainLighting(this.CardData, this.target);
		}
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleEnd();
		base.ShowMe();
		yield return this.ChangeColorN();
		yield return this.ChangeColorB();
		this.StoneFlag = true;
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		this.target = allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)];
		if (this.line != null)
		{
			UVChainLightning component = this.line.GetComponent<UVChainLightning>();
			component.target = this.target;
			component.gameObject.SetActive(true);
		}
		else
		{
			this.line = this.GetChainLighting(this.CardData, this.target);
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0)
		{
			this.changeCount++;
			GameController.ins.UIController.AreaTabooDesc.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("T_37"),
				" - ",
				LocalizationMgr.Instance.GetLocalizationWord("T_大蛇禁忌1"),
				"\n<size=16>\n",
				string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_大蛇禁忌3"), (3 - this.changeCount < 1) ? 1 : (3 - this.changeCount), 10 - this.dizzyCount),
				"</size>"
			});
			if (this.changeCount >= 3 && from != null && from != this.target)
			{
				this.changeCount = 0;
				this.target = from;
				if (this.line != null)
				{
					base.ShowLogic("！！！");
					this.StoneFlag = false;
					this.line.GetComponent<UVChainLightning>().target = this.target;
				}
				this.dizzyCount++;
				GameController.ins.UIController.AreaTabooDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_37"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord("T_大蛇禁忌1"),
					"\n<size=16>\n",
					string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_大蛇禁忌3"), (3 - this.changeCount < 1) ? 1 : (3 - this.changeCount), 10 - this.dizzyCount),
					"</size>"
				});
			}
			if (this.dizzyCount >= 10)
			{
				this.dizzyCount = 0;
				this.CardData.DizzyLayer = 1;
			}
		}
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CheckCardDead(this.target))
		{
			if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
			{
				yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
			}
		}
		else
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, this.target.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (this.line != null && !isPlayerTurn)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(this.target) && this.StoneFlag)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("SM_大蛇3"));
				this.target.AddAffix(DungeonAffix.dizzy, 3);
			}
			UnityEngine.Object.DestroyImmediate(this.line);
			this.line = null;
			yield break;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		if (this.line != null)
		{
			UnityEngine.Object.DestroyImmediate(this.line);
			this.line = null;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.target && this.target != null)
		{
			this.target = null;
			this.line = null;
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

	private IEnumerator ChangeColorN()
	{
		float intensity = 0f;
		Color c = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().OldEyeColor;
		Material i = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().SnakeEyeMaterial;
		while (intensity < 20f)
		{
			float num = Mathf.Pow(2f, intensity);
			Color value = new Color(c.r * num, c.g * num, c.b * num);
			i.SetColor("_EmissionColor", value);
			intensity += 1f;
			yield return new WaitForSeconds(0.025f);
		}
		Color value2 = new Color(c.r * Mathf.Pow(2f, 20f), c.g * Mathf.Pow(2f, 20f), c.b * Mathf.Pow(2f, 20f));
		i.SetColor("_EmissionColor", value2);
		yield break;
	}

	private IEnumerator ChangeColorB()
	{
		float intensity = 20f;
		Color c = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().OldEyeColor;
		Material i = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().SnakeEyeMaterial;
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

	private int changeCount;

	private int dizzyCount;

	private CardData target;

	private bool StoneFlag = true;

	private GameObject line;
}
