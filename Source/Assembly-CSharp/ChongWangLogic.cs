using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ChongWangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_89");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_89");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_89");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_89");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in base.GetAllCurrentMinions())
			{
				if (base.GetLogic(cardData, typeof(PoisonCardLogic)) != null)
				{
					list.Add(cardData);
				}
			}
			if (list.Count <= 0)
			{
				yield break;
			}
			CardData target = list[SYNCRandom.Range(0, list.Count)];
			CardLogic cardLogic = null;
			foreach (CardLogic cardLogic2 in target.CardLogics)
			{
				if (cardLogic2.GetType() == typeof(PoisonCardLogic))
				{
					cardLogic = cardLogic2;
				}
			}
			base.ShowMe();
			int recovery = Mathf.CeilToInt((float)target.MaxHP * 0.02f * (float)cardLogic.Layers * 2f);
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, 0, 0.2f, true, 0, "", "Effect/animal_scratch_1");
			this.CardData.HP = ((this.CardData.HP + recovery > this.CardData.MaxHP) ? this.CardData.MaxHP : (this.CardData.HP + recovery));
			Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
			this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one * 0.5f, 0.5f).SetEase(Ease.OutBack);
			yield return new WaitForSeconds(0.8f);
			this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f);
			yield return new WaitForSeconds(0.2f);
			ParticlePoolManager.Instance.Spawn("Effect/HealHp", 3f).transform.position = this.CardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
			base.RemoveCardLogic(target, typeof(PoisonCardLogic), "PoisonCardLogic");
			target = null;
			oldScale = default(Vector3);
		}
		yield break;
	}

	private void RemoveLogic(string logicName, CardData target)
	{
		Activator.CreateInstance(Type.GetType(logicName));
		foreach (CardLogic cardLogic in target.CardLogics)
		{
			if (cardLogic.GetType().Name.Equals(logicName))
			{
				for (int i = target.CardLogicClassNames.Count - 1; i >= 0; i--)
				{
					if (target.CardLogicClassNames[i].Split(new char[]
					{
						' '
					})[0].Equals(logicName))
					{
						target.CardLogicClassNames.Remove(target.CardLogicClassNames[i]);
					}
				}
				target.CardLogics.Remove(cardLogic);
				break;
			}
		}
	}
}
