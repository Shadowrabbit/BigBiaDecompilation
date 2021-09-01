using System;
using System.Collections;
using System.Collections.Generic;

public class BreakArmourAttackLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "陷阵";
		this.Desc = "对玩家黄格单位造成 3 倍伤害，同时承受目标攻击力伤害。";
		this.CardData.ShotEffect = "";
		this.CardData.HitEffect = "Effect/dizzy";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		CardData targetCardData = target.ChildCardData;
		int AttackTimes = this.CardData.AttackTimes;
		int num2;
		for (int q = 0; q < AttackTimes; q = num2 + 1)
		{
			if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData) || DungeonOperationMgr.Instance.CheckCardDead(targetCardData))
			{
				yield break;
			}
			yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, targetCardData, 1f, null, null, null);
			if (!DungeonOperationMgr.Instance.CheckCardDead(targetCardData))
			{
				List<CardSlotData> PlayerCardSlots = GameController.getInstance().PlayerSlotSets;
				for (int i = 0; i < PlayerCardSlots.Count; i = num2 + 1)
				{
					if (PlayerCardSlots[i].ChildCardData == targetCardData)
					{
						if (i + PlayerCardSlots.Count / 3 < PlayerCardSlots.Count)
						{
							yield return this.DungeonHandler.ChangeHp(targetCardData, -this.CardData.ATK, this.CardData, false, 0, true, false);
						}
						else
						{
							yield return this.DungeonHandler.ChangeHp(targetCardData, -this.CardData.ATK * 3, this.CardData, false, 0, true, false);
							int num = (this.CardData.HP - targetCardData.ATK > 0) ? (-targetCardData.ATK) : (-this.CardData.HP);
							this.CardData.HP += num;
							if (this.CardData.HP <= 0)
							{
								yield return this.DungeonHandler.Die(this.CardData, num, targetCardData);
							}
						}
					}
					num2 = i;
				}
				PlayerCardSlots = null;
			}
			num2 = q;
		}
		yield break;
	}

	public DungeonHandler DungeonHandler = new DungeonHandler();

	private const float c_MonsterShakeTime = 0.1f;
}
