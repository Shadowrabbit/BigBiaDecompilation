using System;
using System.Text;
using Steamworks;

public static class SteamEResultUtil
{
	public static bool CheckEResult(EResult result)
	{
		SteamEResultUtil.ResultMessage.Clear();
		if (result == EResult.k_EResultOK)
		{
			return true;
		}
		SteamEResultUtil.ResultMessage.Append("Steam错误");
		return false;
	}

	public static StringBuilder ResultMessage = new StringBuilder();
}
