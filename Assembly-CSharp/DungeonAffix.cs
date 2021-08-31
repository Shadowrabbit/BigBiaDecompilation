using System;

public enum DungeonAffix
{
	[DungeonAffixInfo("中毒", "回合结束时失去等于层数的生命值", "每回合减少一层", "Textures/中毒")]
	poisoning,
	[DungeonAffixInfo("流血", "回合结束时失去等于层数的生命值", "每回合减少一层", "Textures/流血")]
	bleeding,
	[DungeonAffixInfo("愈合", "回合结束时回复相应层数的生命值", "每回合减少一层", "Textures/活力")]
	heal,
	[DungeonAffixInfo("力量", "获得等于力量层数的临时攻击力", "每回合减少一层", "Textures/狂热")]
	strength,
	[DungeonAffixInfo("麻痹", "拥有麻痹的单位不能移动", "每回合减少一层", "Textures/麻痹")]
	paralysis,
	[DungeonAffixInfo("眩晕", "拥有眩晕的单位不能行动", "每回合减少一层", "Textures/晕眩")]
	dizzy,
	[DungeonAffixInfo("反伤", "受到普通攻击时,对来源造成等于层数的伤害", "每回合减少一层", "Textures/反伤")]
	beatBack,
	[DungeonAffixInfo("虚弱", "减少等于层数的临时攻击力", "每回合减少一层", "Textures/诅咒")]
	weak,
	[DungeonAffixInfo("易伤", "受到伤害时，额外受到等于层数的伤害", "每回合减少一层", "Textures/暗杀")]
	frail,
	[DungeonAffixInfo("防御", "受到伤害时，减少等于层数的伤害", "每回合减少一层", "Textures/物理抗性")]
	def,
	[DungeonAffixInfo("霜冻", "累计至10层时，清空层数并眩晕", "每回合减少一层", "Textures/霜冻")]
	frozen,
	[DungeonAffixInfo("守护", "同排友军受伤超过层数时，转移层数的伤害到自身", "每回合减少一层", "Textures/庇护")]
	guard,
	[DungeonAffixInfo("会心", "每层获得5%的临时暴击率", "每回合减少一层", "Textures/先攻")]
	crit,
	[DungeonAffixInfo("活力", "累计至10层时，清空层数并重置行动", "每回合减少一层", "Textures/新活力")]
	vitality
}
