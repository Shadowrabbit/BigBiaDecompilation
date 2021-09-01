using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangYinShaoNianLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_105");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_105");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_105");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_105");
	}

	public override IEnumerator OnTurnStart()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		this.m_target = allCurrentMinions[UnityEngine.Random.Range(0, allCurrentMinions.Count)];
		if (this.m_ChainGo != null)
		{
			UnityEngine.Object.Destroy(this.m_ChainGo);
		}
		this.m_ChainGo = this.GetChainLighting(this.CardData, this.m_target);
		GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_6"), UnityEngine.Color.white, 0, false, false);
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		this.m_target = allCurrentMinions[UnityEngine.Random.Range(0, allCurrentMinions.Count)];
		if (this.m_ChainGo != null)
		{
			UnityEngine.Object.Destroy(this.m_ChainGo);
		}
		this.m_ChainGo = this.GetChainLighting(this.CardData, this.m_target);
		GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_6"), UnityEngine.Color.white, 0, false, false);
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn && this.m_target != null)
		{
			List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
			CardSlotData cardSlotData = base.GetMyBattleArea()[enemiesBattleArea.IndexOf(this.m_target.CurrentCardSlotData)];
			if (cardSlotData.ChildCardData == null)
			{
				yield return this.TryJump(this.CardData, cardSlotData);
			}
			if (this.m_ChainGo != null)
			{
				UnityEngine.Object.Destroy(this.m_ChainGo);
			}
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

	public IEnumerator TryJump(CardData jumpO, CardSlotData target)
	{
		base.ShowMe();
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	private GameObject m_ChainGo;

	private CardData m_target;
}
