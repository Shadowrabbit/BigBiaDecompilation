using System;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallLogic : CardLogic
{
	public SnowBallLogic()
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
		if (!CardUtils.IsUserCard(this.CardData))
		{
			return;
		}
		base.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>().SetDirectionalSkill(this.CardData);
	}

	public override bool OnUse(List<Vector2[]> res)
	{
		if (!CardUtils.IsUserCard(this.CardData))
		{
			return false;
		}
		Hero component = base.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
		if (component.Target == null || !component.Target.HasTag(TagMap.怪物) || component.Target.HasTag(TagMap.BOSS))
		{
			return false;
		}
		base.CallOnBeforeUseMagic(component.HeroCard);
		Transform transform = component.Target.CardGameObject.transform;
		Transform transform2 = component.gameObject.transform;
		ParticlePoolManager.Instance.Spawn(this.particleName, 1f).transform.position = component.Target.CardGameObject.transform.position + new Vector3(0f, 0.2f, 0f);
		ParticlePoolManager.Instance.Spawn(this.particleName1, 2f).transform.position = component.HeroCard.CardGameObject.transform.position + new Vector3(0f, 2.5f, 0f);
		component.Target.DizzyLayer++;
		this.CardData.RemainTime = this.CardData.TotalTime;
		this.CardData.IsAttacked = true;
		base.CallOnAfterUseMagic(component.HeroCard);
		component.OnReleasedSkill();
		return true;
	}

	public override List<Vector2Int> GetSkillScope()
	{
		return SnowBallLogic.SkillRangeList;
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
