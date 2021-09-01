using System;
using System.Collections.Generic;

public class AttackMsg
{
	public AttackMsg(CardData target, int dmg, bool isRealDmg = false, bool isWeakUpAttack = true, int reduceArmor = 0, int isDizzyArmor = 0, List<KeyValuePair<string, object>> addAttr = null)
	{
		this.Target = target;
		this.Dmg = dmg;
		this.IsRealDmg = isRealDmg;
		this.IsWakeUpAttack = isWeakUpAttack;
		this.reduceArmor = reduceArmor;
		this.IsDizzyArmor = isDizzyArmor;
		this.AddAttr = addAttr;
	}

	public CardData Target;

	public int Dmg;

	public bool IsRealDmg;

	public bool IsWakeUpAttack = true;

	public int reduceArmor;

	public int IsDizzyArmor;

	public List<KeyValuePair<string, object>> AddAttr;
}
