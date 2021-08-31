using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHiveCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	private new void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (base.GetLogic(target, typeof(ShaChongJiCardLogic)) != null)
		{
			List<CardData> allMinions = base.GetAllCurrentMinions();
			if (allMinions.Count == 0)
			{
				yield break;
			}
			yield return GameController.ins.UIController.TabooUIPunchEffect();
			foreach (CardData cardData in allMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), cardData.CardGameObject.transform.position, 1);
					base.AddLogic("PoisonCardLogic", 1, cardData);
				}
			}
			allMinions = null;
		}
		yield break;
	}

	private float debuff = 0.2f;

	private float buff = 0.05f;

	private Dictionary<CardData, int> CardList = new Dictionary<CardData, int>();
}
