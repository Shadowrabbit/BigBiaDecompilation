using System;
using System.Collections;
using UnityEngine;

public class SceneForestCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player.HasTag(TagMap.植物) && changedValue < 0 && player != from)
		{
			yield return GameController.ins.UIController.TabooUIPunchEffect();
			if (!DungeonOperationMgr.Instance.CheckCardDead(from))
			{
				this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), from.CardGameObject.transform.position, 1);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(from, -Mathf.CeilToInt((float)from.MaxHP * 0.1f), null, false, 0, true, false);
			}
		}
		yield break;
	}

	private new void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (value.value > 0)
		{
			yield return GameController.ins.UIController.AdvocateUIPunchEffect();
			value.value = Mathf.CeilToInt((float)value.value * 1.2f);
		}
		yield break;
	}
}
