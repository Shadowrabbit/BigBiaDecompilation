using System;
using System.Text;

public static class AreaDataUtil
{
	public static bool IsPlayerArea(AreaData data)
	{
		return data.Attrs.ContainsKey("Owner") && data.Attrs["Owner"] as string == "Player";
	}

	public static string CombineAreaID(params string[] strs)
	{
		AreaDataUtil.sb.Clear();
		foreach (string value in strs)
		{
			AreaDataUtil.sb.Append(value);
			AreaDataUtil.sb.Append("/");
		}
		if (AreaDataUtil.sb.Length > 0)
		{
			AreaDataUtil.sb.Length = AreaDataUtil.sb.Length - 1;
		}
		return AreaDataUtil.sb.ToString();
	}

	public static StringBuilder sb = new StringBuilder(1024);

	public const string BackSlash = "/";
}
