using System;
using UnityEngine;

public class SuiJiShuXingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "属性提升";
		if (this.CardData != null)
		{
			Debug.Log(this.CardData.GetAttr("ShuXing"));
			this.SuiJiShuXing = (SuiJiShuXingCardLogic.SuiJiShuXingType)int.Parse(this.CardData.GetAttr("ShuXing"));
			if (this.SuiJiShuXing == SuiJiShuXingCardLogic.SuiJiShuXingType.atk)
			{
				this.Desc = "吞噬时获得" + int.Parse(this.CardData.GetAttr("ATKFrom")).ToString() + "-" + int.Parse(this.CardData.GetAttr("ATKTo")).ToString();
				this.Desc += "攻击力";
				return;
			}
			if (this.SuiJiShuXing == SuiJiShuXingCardLogic.SuiJiShuXingType.hp)
			{
				this.Desc = "吞噬时获得" + int.Parse(this.CardData.GetAttr("HPFrom")).ToString() + "-" + int.Parse(this.CardData.GetAttr("HPTo")).ToString();
				this.Desc += "生命上限";
				return;
			}
			if (this.SuiJiShuXing == SuiJiShuXingCardLogic.SuiJiShuXingType.percentageAtk)
			{
				this.Desc = "吞噬时获得" + int.Parse(this.CardData.GetAttr("ATKPercentage")).ToString();
				this.Desc += "%攻击力";
			}
		}
	}

	public override void OnMerge(CardData mergeBy)
	{
		this.CardData.HasTag(TagMap.食物);
		if (!this.CardData.HasTag(TagMap.随从))
		{
			return;
		}
		if (this.SuiJiShuXing == SuiJiShuXingCardLogic.SuiJiShuXingType.atk)
		{
			this.CardData._ATK += SYNCRandom.Range(int.Parse(this.CardData.GetAttr("MinValue")), int.Parse(this.CardData.GetAttr("MaxValue")));
		}
		else if (this.SuiJiShuXing == SuiJiShuXingCardLogic.SuiJiShuXingType.hp)
		{
			float num = (float)this.CardData.HP / (float)this.CardData.MaxHP;
			this.CardData.MaxHP += SYNCRandom.Range(int.Parse(this.CardData.GetAttr("MinValue")), int.Parse(this.CardData.GetAttr("MaxValue")));
			this.CardData.HP = Mathf.FloorToInt((float)this.CardData.MaxHP * num);
		}
		else if (this.SuiJiShuXing == SuiJiShuXingCardLogic.SuiJiShuXingType.percentageAtk)
		{
			this.CardData._ATK += Mathf.CeilToInt((float)this.CardData.ATK * ((float)int.Parse(this.CardData.GetAttr("Percentage")) / 100f));
		}
		this.CardData.CardLogics.Remove(this);
	}

	public SuiJiShuXingCardLogic.SuiJiShuXingType SuiJiShuXing;

	public enum SuiJiShuXingType
	{
		hp,
		atk,
		percentageAtk = 3
	}
}
