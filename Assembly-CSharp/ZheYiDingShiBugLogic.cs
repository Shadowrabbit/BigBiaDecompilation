using System;
using System.Collections;
using UnityEngine;

public class ZheYiDingShiBugLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = "这一定是BUG！";
		this.Desc = "交换当前列所有敌人的攻击力和HP。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "这一定是BUG！";
		this.Desc = "交换当前列所有敌人的攻击力和HP。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.ShowMe();
		foreach (CardData cardData in base.GetAllCurrentMonsters())
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && (int)cardData.CurrentCardSlotData.Attrs["Col"] == (int)this.CardData.CurrentCardSlotData.Attrs["Col"])
			{
				int atk = cardData._ATK;
				int hp = cardData.HP;
				cardData._ATK = hp;
				cardData.HP = atk;
				ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 2f).transform.position = cardData.CardGameObject.transform.position;
				if (cardData.HP <= 0)
				{
					cardData.DeleteCardData();
				}
			}
		}
		this.CardData.IsAttacked = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "这一定是BUG释放";
	}
}
