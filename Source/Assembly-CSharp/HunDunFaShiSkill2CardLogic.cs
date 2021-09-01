using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[CardLogicRequireRare(4)]
public class HunDunFaShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_终极弹幕");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_终极弹幕");
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_终极弹幕");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_终极弹幕");
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		base.ShowMe();
		CardData target = base.GetDefaultTarget();
		if (target == null)
		{
			yield break;
		}
		CardLogic Logic = base.GetLogic(this.CardData, typeof(DanMuCardLogic));
		if (Logic != null)
		{
			int num3;
			for (int i = 0; i < Logic.Layers * 4; i = num3 + 1)
			{
				if (DungeonOperationMgr.Instance.CheckCardDead(target))
				{
					yield break;
				}
				CardData SelectedMonster = target;
				if (!DungeonOperationMgr.Instance.CheckCardDead(SelectedMonster) && this.CardData.CardGameObject != null)
				{
					ParticleObject partical = ParticlePoolManager.Instance.Spawn("Particles/飞弹", float.MaxValue);
					partical.gameObject.transform.position = this.CardData.CardGameObject.transform.position;
					float num;
					if (i % 2 == 0)
					{
						num = 1f;
					}
					else
					{
						num = -1f;
					}
					Sequence sequence = DOTween.Sequence();
					float num2 = 1f - (float)(i / 4) * 0.2f;
					if (num2 < 0.3f)
					{
						num2 = 0.3f;
					}
					sequence.Append(partical.gameObject.transform.DOMoveZ(SelectedMonster.CardGameObject.transform.position.z, 0.3f * num2, false).SetEase(Ease.InQuad));
					sequence.Insert(0f, partical.gameObject.transform.DOMoveX(SelectedMonster.CardGameObject.transform.position.x + num, 0.15f * num2, false).SetEase(Ease.OutQuad));
					sequence.Insert(0.15f, partical.gameObject.transform.DOMoveX(SelectedMonster.CardGameObject.transform.position.x, 0.15f * num2, false).SetEase(Ease.InQuad));
					yield return sequence.Play<Sequence>().WaitForCompletion();
					ParticlePoolManager.Instance.UnSpawn(partical);
					ParticlePoolManager.Instance.Spawn("Effect/风暴教主02", 0.2f).transform.position = SelectedMonster.CardGameObject.transform.position;
					Camera.main.transform.DOShakePosition(0.1f, 0.2f, 10, 90f, false, true);
					SelectedMonster.CardGameObject.transform.DOPunchRotation(new Vector3(10f, 0f, 0f), 0.1f, 10, 1f);
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(SelectedMonster, -1, this.CardData, false, 0, true, false);
					partical = null;
				}
				SelectedMonster = null;
				num3 = i;
			}
		}
		yield break;
	}
}
