using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class SteamStatsAchievements : MonoBehaviour
{
	private GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	private void Start()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		this.InitAchievement();
		this.m_GameID = new CGameID(SteamUtils.GetAppID());
		this.m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(new Callback<UserStatsReceived_t>.DispatchDelegate(this.OnUserStatsReceived));
		this.m_UserStatsStored = Callback<UserStatsStored_t>.Create(new Callback<UserStatsStored_t>.DispatchDelegate(this.OnUserStatsStored));
		this.m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(new Callback<UserAchievementStored_t>.DispatchDelegate(this.OnAchievementStored));
		this.m_bRequestedStats = false;
		this.m_bStatsValid = false;
	}

	private void InitAchievement()
	{
		this.AchievementList.Add(this.ACHIEVEMENT_FirstBlood);
	}

	public void AddEvent()
	{
	}

	public void RemoveEvent()
	{
	}

	private void OnGUI()
	{
	}

	private void Update()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (!this.m_bRequestedStats)
		{
			if (!SteamManager.Initialized)
			{
				this.m_bRequestedStats = true;
				return;
			}
			bool bRequestedStats = SteamUserStats.RequestCurrentStats();
			this.m_bRequestedStats = bRequestedStats;
		}
		if (!this.m_bStatsValid)
		{
			return;
		}
		if (this.m_bStoreStats)
		{
			SteamUserStats.SetStat("KilledEnemy", this.m_nTotalKillEnemy);
			SteamUserStats.SetStat("MaxLiveRound", this.m_nMaxPlayRound);
			SteamUserStats.SetStat("SellFishCount", this.m_nSellFishCount);
			SteamUserStats.GetStat("KilledEnemy", out this.m_nTotalKillEnemy);
			bool flag = SteamUserStats.StoreStats();
			this.m_bStoreStats = !flag;
		}
	}

	public SteamStatsAchievements.Achievement_t GetAchievement(SteamStatsAchievements.Achievement type)
	{
		foreach (SteamStatsAchievements.Achievement_t achievement_t in this.AchievementList)
		{
			if (achievement_t.m_eAchievementID == type)
			{
				return achievement_t;
			}
		}
		return null;
	}

	private void ClearAllAchievement()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		for (int i = 0; i < this.AchievementList.Count; i++)
		{
			this.ClearAchievement(this.AchievementList[i]);
		}
	}

	private void ClearAchievement(SteamStatsAchievements.Achievement_t achievement)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		SteamUserStats.ClearAchievement(achievement.m_eAchievementID.ToString());
	}

	public void UnlockAchievement(SteamStatsAchievements.Achievement_t achievement)
	{
		achievement.m_bAchieved = true;
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());
		this.m_bStoreStats = true;
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("Received stats and achievements from steam/n");
				this.m_bStatsValid = true;
				for (int i = 0; i < this.AchievementList.Count; i++)
				{
					SteamStatsAchievements.Achievement_t achievement_t = this.AchievementList[i];
					if (SteamUserStats.GetAchievement(achievement_t.m_eAchievementID.ToString(), out achievement_t.m_bAchieved))
					{
						achievement_t.m_strName = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "name");
						achievement_t.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "desc");
					}
					else
					{
						Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + achievement_t.m_eAchievementID.ToString() + "\nIs it registered in the Steam Partner site?");
					}
				}
				SteamUserStats.GetStat("KilledEnemy", out this.m_nTotalKillEnemy);
				SteamUserStats.GetStat("MaxLiveRound", out this.m_nMaxPlayRound);
				SteamUserStats.GetStat("SellFishCount", out this.m_nSellFishCount);
				return;
			}
			Debug.Log("RequestStats - failed, " + pCallback.m_eResult.ToString());
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("StoreStats - success");
				return;
			}
			if (EResult.k_EResultInvalidParam == pCallback.m_eResult)
			{
				Debug.Log("StoreStats - some failed to validate");
				this.OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)this.m_GameID
				});
				return;
			}
			Debug.Log("StoreStats - failed, " + pCallback.m_eResult.ToString());
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_nMaxProgress == 0U)
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
				return;
			}
			Debug.Log(string.Concat(new string[]
			{
				"Achievement '",
				pCallback.m_rgchAchievementName,
				"' progress callback, (",
				pCallback.m_nCurProgress.ToString(),
				",",
				pCallback.m_nMaxProgress.ToString(),
				")"
			}));
		}
	}

	private void OnGoodSellEvent(string modID)
	{
		modID.Contains("鱼");
	}

	public bool CheckSteamInitAndAchieve(SteamStatsAchievements.Achievement_t achievement)
	{
		return SteamManager.Initialized && this.m_bStatsValid && achievement.m_bAchieved;
	}

	public List<SteamStatsAchievements.Achievement_t> AchievementList = new List<SteamStatsAchievements.Achievement_t>(32);

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_FirstBlood = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_FirstBlood, "FirstBlood", "Kill First Monster");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_busheren = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_busheren, "捕蛇人", "击败大蛇初级形态");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_zhongjibusheren = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_zhongjibusheren, "终极捕蛇人", "击败大蛇完全体形态");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_famugong = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_famugong, "伐木工", "击败大树");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_shenhualieshou = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_shenhualieshou, "神话猎手", "击败克苏鲁初级形态");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_zhongjishenhualieshou = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_zhongjishenhualieshou, "总计神话终结者", "击败克苏鲁完全体形态");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_dashi = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_dashi, "大师", "完成任意英雄契约10难度的地下城");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_guaiwujiaorouji = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_guaiwujiaorouji, "怪物绞肉机", "击杀1000只怪物");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_jiqiaodashi = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_jiqiaodashi, "技巧大师", "使用100次技能");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_jinsechuanshuo = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_jinsechuanshuo, "金色传说", "将任意一名随从升级成金色品质");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_zhuangxiudashi = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_zhuangxiudashi, "装修大师", "解锁任意一名英雄的全部家具");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_zhufu = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_zhufu, "祝福", "解锁任意一项祝福小屋的祝福");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_licaigaoshou = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_licaigaoshou, "理财高手", "在银行里总共存入5000金币");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_qinlaofajia = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_qinlaofajia, "勤劳发家", "依靠售卖褐色坨坨赚取1000金币");

	public SteamStatsAchievements.Achievement_t ACHIEVEMENT_guabiren = new SteamStatsAchievements.Achievement_t(SteamStatsAchievements.Achievement.ACHIEVEMENT_guabiren, "挂壁人", "找到挂壁人");

	private CGameID m_GameID;

	private bool m_bRequestedStats;

	private bool m_bStatsValid;

	private bool m_bStoreStats;

	private float m_flGameFeetTraveled;

	private float m_ulTickCountGameStart;

	private double m_flGameDurationSeconds;

	private int m_nTotalKillEnemy;

	private int m_nMaxPlayRound;

	private int m_nSellFishCount;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	protected Callback<UserStatsStored_t> m_UserStatsStored;

	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	private bool pause;

	public enum Achievement
	{
		ACHIEVEMENT_FirstBlood,
		ACHIEVEMENT_busheren,
		ACHIEVEMENT_zhongjibusheren,
		ACHIEVEMENT_famugong,
		ACHIEVEMENT_shenhualieshou,
		ACHIEVEMENT_zhongjishenhualieshou,
		ACHIEVEMENT_dashi,
		ACHIEVEMENT_guaiwujiaorouji,
		ACHIEVEMENT_jiqiaodashi,
		ACHIEVEMENT_jinsechuanshuo,
		ACHIEVEMENT_zhuangxiudashi,
		ACHIEVEMENT_zhufu,
		ACHIEVEMENT_licaigaoshou,
		ACHIEVEMENT_qinlaofajia,
		ACHIEVEMENT_guabiren
	}

	public class Achievement_t
	{
		public Achievement_t(SteamStatsAchievements.Achievement achievementID, string name, string desc)
		{
			this.m_eAchievementID = achievementID;
			this.m_strName = name;
			this.m_strDescription = desc;
			this.m_bAchieved = false;
		}

		public SteamStatsAchievements.Achievement m_eAchievementID;

		public string m_strName;

		public string m_strDescription;

		public bool m_bAchieved;
	}
}
