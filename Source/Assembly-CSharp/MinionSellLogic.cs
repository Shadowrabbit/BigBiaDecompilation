using System;
using System.Collections.Generic;
using UnityEngine;

public class MinionSellLogic : CardLogic
{
	public MinionSellLogic()
	{
		this.exploreGirdHpEffect = -1;
	}

	public override void OnGetCard(object data)
	{
		base.OnGetCard(data);
	}

	public override void OnLoseCard(object data)
	{
		base.OnLoseCard(data);
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		base.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>().SetDirectionalSkill(this.CardData);
	}

	public override bool OnUse(List<Vector2[]> res)
	{
		Hero component = base.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
		if (component.Target == null || component.Target == this.CardData)
		{
			return false;
		}
		base.CallOnBeforeUseMagic(component.HeroCard);
		bool flag = false;
		if (component.Target.HasTag(TagMap.随从) || component.Target.HasTag(TagMap.道具) || component.Target.HasTag(TagMap.衍生物))
		{
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null && !GameController.getInstance().PlayerSlotSets[i].ChildCardData.Name.Equals("卡槽锁") && GameController.getInstance().PlayerSlotSets[i].ChildCardData == component.Target)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			if (component.Target.HasTag(TagMap.英雄))
			{
				GameController.ins.StartCoroutine(DungeonController.Instance.GameOver(false));
			}
			int num = (component.Target.Rare > 5) ? 30 : (component.Target.Rare * 30);
			if (component.Target.HasTag(TagMap.特殊))
			{
				num = component.Target.Price;
			}
			if (component.Target.ModID.Equals("坨坨") && component.Target.Rare == 1)
			{
				SteamController.Instance.SteamAchievementsController.SetAchievementStatus(AchievementType.NEW_ACHIEVEMENT_qinlaofajia, num);
			}
			GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.GetMoneyAnimate(Mathf.CeilToInt((float)num), component.Target.CardGameObject.transform.position, Vector3.zero));
			ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 2f).transform.position = component.Target.CardGameObject.transform.position;
			component.Target.DeleteCardData();
		}
		this.CardData.RemainTime = 0;
		this.CardData.IsAttacked = false;
		base.CallOnAfterUseMagic(component.HeroCard);
		component.OnReleasedSkill();
		return true;
	}

	public override List<Vector2Int> GetSkillScope()
	{
		return MinionSellLogic.SkillRangeList;
	}

	public override float GetSkillDmg()
	{
		return 4f;
	}

	public string particleName = "Effect/snowball";

	public string particleName1 = "Effect/snowball_hero";

	public static List<Vector2Int> SkillRangeList = new List<Vector2Int>
	{
		Vector2Int.zero
	};
}
