using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[CardLogicRequireRare(4)]
public class HuoJianTongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 4, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_火箭筒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_火箭筒"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_火箭筒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_火箭筒"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		CardData target = base.GetDefaultTarget();
		this.CardData.IsAttacked = true;
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		CardSlotData targetSlot = target.CurrentCardSlotData;
		DisplayModel RPG = ModelPoolManager.Instance.SpawnModel("Prefabs/火箭筒");
		RPG.GameObject.transform.position = this.CardData.CardGameObject.transform.position;
		RPG.GameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		yield return RPG.GameObject.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).WaitForCompletion();
		yield return new WaitForSeconds(0.5f);
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_后会有期了宝贝"));
		DisplayModel fire = ModelPoolManager.Instance.SpawnModel("Effect/吹火球");
		fire.GameObject.transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0f, 0.6f);
		yield return new WaitForSeconds(1f);
		fire.GameObject.transform.DOScale(2.5f, 0.3f).SetEase(Ease.OutQuad);
		DisplayModel Bullet = ModelPoolManager.Instance.SpawnModel("Prefabs/火箭弹药");
		Bullet.GameObject.transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0f, 0.6f);
		RPG.GameObject.transform.DOLocalMoveZ(this.CardData.CardGameObject.transform.position.z - 0.5f, 0.5f, false).SetEase(Ease.OutExpo);
		yield return Bullet.GameObject.transform.DOLocalMoveZ(targetSlot.CardSlotGameObject.transform.position.z, 0.5f, false).SetEase(Ease.InQuad).WaitForCompletion();
		ModelPoolManager.Instance.UnSpawnModel(Bullet);
		ModelPoolManager.Instance.UnSpawnModel(RPG);
		ModelPoolManager.Instance.UnSpawnModel(fire);
		Dictionary<CardData, int> targets = new Dictionary<CardData, int>();
		int num = -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
		targets.Add(target, num);
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		list.Add(Vector3Int.down);
		list.Add(Vector3Int.up);
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(target.CurrentCardSlotData.GridPositionX, target.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData))
			{
				targets.Add(ralitiveCardSlotData.ChildCardData, Mathf.CeilToInt((float)num * 0.5f));
			}
		}
		foreach (KeyValuePair<CardData, int> keyValuePair in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair.Key))
			{
				string name = "Effect/捶胸大吼命中";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = keyValuePair.Key.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			}
		}
		yield return new WaitForSeconds(0.3f);
		foreach (KeyValuePair<CardData, int> keyValuePair2 in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair2.Key))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(keyValuePair2.Key, keyValuePair2.Value, this.CardData, false, 0, true, false);
			}
		}
		Dictionary<CardData, int>.Enumerator enumerator3 = default(Dictionary<CardData, int>.Enumerator);
		yield break;
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 2.5f;
}
