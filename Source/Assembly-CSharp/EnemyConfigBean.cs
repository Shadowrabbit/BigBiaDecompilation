using System;
using System.Collections.Generic;

public class EnemyConfigBean
{
	public string EnemyConfigName;

	public string EnemyTheme = "Normal";

	public string IsElite = "False";

	public List<string> Rewards = new List<string>();

	public List<float> RewardsRatio = new List<float>();

	public List<string> EnemiesModID = new List<string>();

	public List<float> DifficultRatio = new List<float>();
}
