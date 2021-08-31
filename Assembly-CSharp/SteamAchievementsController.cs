using System;
using Steamworks;
using UnityEngine;

public class SteamAchievementsController : MonoBehaviour
{
	public void InitSteamAchievementStatus()
	{
		if (!SteamManager.Initialized)
		{
			Debug.Log("Steam连接失败！");
			return;
		}
		SteamUserStats.GetStat("stat_JiShaGuaiWu", out this.m_JiShaGuaiWu);
		SteamUserStats.GetStat("stat_ShiYongJiNeng", out this.m_ShiYongJiNeng);
		SteamUserStats.GetStat("stat_CunQian", out this.m_CunQian);
		SteamUserStats.GetStat("stat_MaiTuoTuo", out this.m_MaiTuoTuo);
		Debug.Log(string.Concat(new string[]
		{
			"Steam成就初始数据： 击杀：",
			this.m_JiShaGuaiWu.ToString(),
			" 技能：",
			this.m_ShiYongJiNeng.ToString(),
			" 存钱：",
			this.m_CunQian.ToString(),
			" 坨坨：",
			this.m_MaiTuoTuo.ToString()
		}));
	}

	public void SetAchievementStatus(AchievementType type, int value)
	{
		if (!SteamManager.Initialized)
		{
			Debug.Log("Steam连接失败！");
			return;
		}
		switch (type)
		{
		case AchievementType.NEW_ACHIEVEMENT_guaiwujiaorouji:
			this.m_JiShaGuaiWu += value;
			SteamUserStats.SetStat("stat_JiShaGuaiWu", this.m_JiShaGuaiWu);
			break;
		case AchievementType.NEW_ACHIEVEMENT_jiqiaodashi:
			this.m_ShiYongJiNeng += value;
			SteamUserStats.SetStat("stat_ShiYongJiNeng", this.m_ShiYongJiNeng);
			break;
		case AchievementType.NEW_ACHIEVEMENT_licaigaoshou:
			this.m_CunQian += value;
			SteamUserStats.SetStat("stat_CunQian", this.m_CunQian);
			break;
		case AchievementType.NEW_ACHIEVEMENT_qinlaofajia:
			this.m_MaiTuoTuo += value;
			SteamUserStats.SetStat("stat_MaiTuoTuo", this.m_MaiTuoTuo);
			break;
		}
		SteamUserStats.StoreStats();
		this.CheckIsCanUnlock(type, value);
	}

	private void CheckIsCanUnlock(AchievementType type, int currentStatus)
	{
		if (!SteamManager.Initialized)
		{
			Debug.Log("Steam连接失败！");
			return;
		}
		switch (type)
		{
		case AchievementType.NEW_ACHIEVEMENT_guaiwujiaorouji:
			if (currentStatus >= 1000)
			{
				this.UnlockAchievement(type);
				return;
			}
			break;
		case AchievementType.NEW_ACHIEVEMENT_jiqiaodashi:
			if (currentStatus >= 100)
			{
				this.UnlockAchievement(type);
				return;
			}
			break;
		case AchievementType.NEW_ACHIEVEMENT_jinsechuanshuo:
		case AchievementType.NEW_ACHIEVEMENT_zhuangxiudashi:
		case AchievementType.NEW_ACHIEVEMENT_zhufu:
			break;
		case AchievementType.NEW_ACHIEVEMENT_licaigaoshou:
			if (currentStatus >= 5000)
			{
				this.UnlockAchievement(type);
				return;
			}
			break;
		case AchievementType.NEW_ACHIEVEMENT_qinlaofajia:
			if (currentStatus >= 1000)
			{
				this.UnlockAchievement(type);
			}
			break;
		default:
			return;
		}
	}

	private bool GetAchievement(AchievementType type)
	{
		bool result;
		SteamUserStats.GetAchievement(type.ToString(), out result);
		return result;
	}

	public void UnlockAchievement(AchievementType type)
	{
		if (!SteamManager.Initialized)
		{
			Debug.Log("Steam连接失败！");
			return;
		}
		bool flag;
		SteamUserStats.GetAchievement(type.ToString(), out flag);
		if (!flag)
		{
			if (!SteamUserStats.SetAchievement(type.ToString()))
			{
				Debug.LogError("成就解锁失败，未初始化Steam或未收到Steam响应回调！");
				return;
			}
			SteamUserStats.StoreStats();
		}
	}

	[NonSerialized]
	public int m_JiShaGuaiWu;

	[NonSerialized]
	public int m_ShiYongJiNeng;

	[NonSerialized]
	public int m_CunQian;

	[NonSerialized]
	public int m_MaiTuoTuo;
}
