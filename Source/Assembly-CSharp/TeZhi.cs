using System;

public class TeZhi
{
	public TeZhi.TezhiType Type;

	public string Reason;

	public string TargetID;

	public int RemainTime;

	public enum TezhiType
	{
		狡猾 = 10001,
		勇敢,
		贪心,
		弱智,
		胆小,
		疯狂,
		不高兴,
		不忠,
		自残,
		拉肚子,
		发疯,
		高兴,
		崇拜 = 20001,
		兄弟,
		拜师,
		爱上了,
		暗恋,
		讨厌
	}
}
