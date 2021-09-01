using System;

public class MinionTempData
{
	public MinionTempData(CardData cd)
	{
		this.Armor = cd.Armor;
		this.HP = cd.HP;
		this.ATK = cd.ATK;
		this.AttackTimes = cd.AttackTimes;
	}

	public int Armor;

	public int HP;

	public int ATK;

	public int AttackTimes;
}
