using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class KeXueJiaCardLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_研究");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_研究"), this.CurrentP, this.TargetP);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_研究");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_研究"), this.CurrentP, this.TargetP);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (this.CardData.HasTag(TagMap.英雄))
		{
			base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_生物学家1"));
			yield break;
		}
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (DungeonOperationMgr.Instance.CheckCardDead(defaultTarget))
		{
			yield break;
		}
		if (defaultTarget.DizzyLayer <= 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_它还活蹦乱跳的呢"));
			yield break;
		}
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, 1, 0.2f, false, 0, null, null);
		this.CurrentP++;
		if (this.CurrentP >= this.TargetP)
		{
			CardSlotData targetSlot = GameController.ins.GetEmptySlotDataByCardTag(TagMap.工具);
			if (targetSlot == null)
			{
				base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_生物学家2"));
				this.CurrentP--;
				yield break;
			}
			this.CurrentP = 0;
			this.Level++;
			if (this.Level <= 3)
			{
				this.TargetP = 2 * this.Level + 1;
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_生物学家3"));
				CardData unit = null;
				switch (SYNCRandom.Range(0, 3))
				{
				case 0:
					unit = Card.InitCardDataByID("智能模块");
					break;
				case 1:
					unit = Card.InitCardDataByID("升级模块");
					break;
				case 2:
					unit = Card.InitCardDataByID("复合模块");
					break;
				}
				if (targetSlot == null || !GameController.ins.PlayerSlotSets.Contains(targetSlot))
				{
					yield break;
				}
				GameObject tempCard = Card.InitWithOutData(unit, true);
				tempCard.transform.position = this.CardData.CardGameObject.transform.position;
				yield return tempCard.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
				UnityEngine.Object.DestroyImmediate(tempCard);
				unit.PutInSlotData(targetSlot, true);
				unit = null;
				tempCard = null;
			}
			else
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_生物学家4"));
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_生物学家5"));
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_生物学家6"));
				this.CardData.CardTags = 34494021634UL;
				this.CardData.IsAttacked = false;
				yield return this.CardData.CardGameObject.JumpToSlot(targetSlot.CardSlotGameObject, 0.2f, true);
				ModelPoolManager.Instance.UnSpawnModel(this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable);
				ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = targetSlot.CardSlotGameObject.transform.position;
				this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/道具/工具/终极模块");
				this.CardData.Model = "Card/道具/工具/终极模块";
				this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.SetParent(this.CardData.CardGameObject.transform, false);
				this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.localPosition += new Vector3(0f, 0.0625f, 0f);
				this.CardData.CharactorTag = (CharacterTag)0UL;
				CardLogic logic = base.GetLogic(this.CardData, typeof(MinionLogic));
				this.CardData.RemoveLogic(logic);
				if (this.CardData.CardLogics.Count > 0)
				{
					for (int i = 0; i < this.CardData.CardLogics.Count; i++)
					{
						CardLogic cardLogic = this.CardData.CardLogics[i];
						if (cardLogic is TwoPeopleCardLogic || cardLogic is PersonCardLogic)
						{
							this.CardData.RemoveLogic(cardLogic);
						}
					}
				}
				this.CardData.RemoveLogic(this);
				this.CardData.AddLogic("ZhongJiMoKuaiCardLogic", 0);
			}
			targetSlot = null;
		}
		else
		{
			base.ShowMe();
		}
		yield break;
	}

	public int CurrentP;

	public int TargetP = 1;

	public int Level;
}
