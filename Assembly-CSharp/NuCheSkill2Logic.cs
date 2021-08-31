using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[CardLogicRequireRare(4)]
public class NuCheSkill2Logic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_166");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_166");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_166");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_166");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		CardData target = null;
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 3 < myBattleArea.Count && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 3].ChildCardData != null)
		{
			target = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 3].ChildCardData;
		}
		if (target == null)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_55"), UnityEngine.Color.white, 0, false, false);
			yield break;
		}
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		base.ShowMe();
		Transform tarTrans = target.CardGameObject.transform.GetChild(3);
		tarTrans.DOMoveZ(this.CardData.CardGameObject.transform.position.z, 0.5f, false);
		this.CardData.CardGameObject.transform.DOScale(1.5f, 0.5f);
		yield return new WaitForSeconds(0.5f);
		this.CardData.CardGameObject.transform.DOShakePosition(1f, new Vector3(0.1f, 0f, 0.1f), 100, 90f, false, true).SetEase(Ease.OutCubic);
		yield return new WaitForSeconds(1f);
		GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_56"), UnityEngine.Color.white, 0, false, false);
		this.CardData.CardGameObject.transform.DOScale(1f, 0.1f).SetEase(Ease.InBack);
		tarTrans.DOLocalMoveZ(6.5f, 0.5f, false);
		tarTrans.DORotate(new Vector3(0f, 710f, 0f), 1f, RotateMode.FastBeyond360);
		yield return new WaitForSeconds(0.5f);
		List<CardSlotData> tmpList = new List<CardSlotData>();
		int num;
		for (int i = CardSlots.Count - 1; i >= 0; i = num - 1)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				string name = "Effect/Hit_Soft";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = CardSlots[i].ChildCardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
				CardSlots[i].ChildCardData.CardGameObject.transform.GetChild(3).DOLocalMoveX(SYNCRandom.Range(-0.5f, 0.5f), 0.2f, false);
				CardSlots[i].ChildCardData.CardGameObject.transform.GetChild(3).DOLocalRotate(new Vector3(0f, (float)SYNCRandom.Range(-90, 90), 0f), 0.2f, RotateMode.Fast);
				tmpList.Add(CardSlots[i]);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(CardSlots[i].ChildCardData, -target.HP, this.CardData, false, 0, true, false);
			}
			num = i;
		}
		this.CardData.IsAttacked = true;
		yield return new WaitForSeconds(1f);
		tarTrans.localRotation = Quaternion.Euler(Vector3.zero);
		tarTrans.DOLocalMoveZ(0f, 0.5f, false);
		foreach (CardSlotData cardSlotData in tmpList)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData))
			{
				cardSlotData.ChildCardData.CardGameObject.transform.GetChild(3).localRotation = Quaternion.Euler(Vector3.zero);
				cardSlotData.ChildCardData.CardGameObject.transform.GetChild(3).DOLocalMoveX(0f, 0.2f, false);
			}
		}
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "神引箭释放";
	}
}
