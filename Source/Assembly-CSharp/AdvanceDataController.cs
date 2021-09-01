using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class AdvanceDataController
{
	public void Init()
	{
		if (!File.Exists(this.settingPath))
		{
			this.CreateAdvanceDataInfo();
			return;
		}
		this.LoadAdvanceDataInfo();
	}

	public void CreateAdvanceDataInfo()
	{
		this.info = new AdvanceData();
		this.SaveAdvanceDataInfo();
	}

	public void LoadAdvanceDataInfo()
	{
		string value = File.ReadAllText(this.settingPath);
		this.info = (JsonConvert.DeserializeObject(value, typeof(AdvanceData)) as AdvanceData);
		if (this.info == null)
		{
			this.CreateAdvanceDataInfo();
		}
	}

	public void SaveAdvanceDataInfo()
	{
		if (File.Exists(this.settingPath))
		{
			File.Delete(this.settingPath);
		}
		string contents = JsonConvert.SerializeObject(this.info, Formatting.Indented);
		File.WriteAllText(this.settingPath, contents);
	}

	public int GetYaoShuiDengJi()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return 0;
		}
		return this.info.YaoShuiDengJi;
	}

	public void SetYaoShuiDengJi(int value)
	{
		this.info.YaoShuiDengJi = value;
		this.SaveAdvanceDataInfo();
	}

	public int GetHuoBa()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return 0;
		}
		return this.info.HuoBa;
	}

	public void SetHuoBa(int value)
	{
		this.info.HuoBa = value;
		this.SaveAdvanceDataInfo();
	}

	public int GetEWaiJinBi()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return 0;
		}
		return this.info.EWaiJinBi;
	}

	public void SetEWaiJinBi(int value)
	{
		this.info.EWaiJinBi = value;
		this.SaveAdvanceDataInfo();
	}

	public int GetEWaiNengLiang()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return 1;
		}
		return this.info.EWaiNengLiang;
	}

	public void SetEWaiNengLiang(int value)
	{
		this.info.EWaiNengLiang = value;
		this.SaveAdvanceDataInfo();
	}

	public int GetGouHuoDengJi()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return 0;
		}
		return this.info.GouHuoDengJi;
	}

	public void SetGouHuoDengJi(int value)
	{
		this.info.GouHuoDengJi = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetWuMingZhiBei()
	{
		return GameData.CurrentGameType != GameData.GameType.Endless && this.info.WuMingZhiBei;
	}

	public void SetWuMingZhiBei(bool value)
	{
		this.info.WuMingZhiBei = value;
		this.SaveAdvanceDataInfo();
	}

	public int GetWuMingZhiBeiCount()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return 0;
		}
		return this.info.WuMingZhiBeiCount;
	}

	public void SetWuMingZhiBeiCount(int value)
	{
		this.info.WuMingZhiBeiCount = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetEWaiWuQi()
	{
		return GameData.CurrentGameType != GameData.GameType.Endless && this.info.EWaiWuQi;
	}

	public void SetEWaiWuQi(bool value)
	{
		this.info.EWaiWuQi = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetHuiFuShengMing()
	{
		return GameData.CurrentGameType != GameData.GameType.Endless && this.info.HuiFuShengMing;
	}

	public void SetHuiFuShengMing(bool value)
	{
		this.info.HuiFuShengMing = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetBossShouJi()
	{
		return this.info.BossShouJi;
	}

	public void SetBossShouJi(bool value)
	{
		this.info.BossShouJi = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetFuHuo()
	{
		return GameData.CurrentGameType != GameData.GameType.Endless && this.info.FuHuo;
	}

	public void SetFuHuo(bool value)
	{
		this.info.FuHuo = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetChaoJiHuoBa()
	{
		return GameData.CurrentGameType != GameData.GameType.Endless && this.info.ChaoJiHuoBa;
	}

	public void SetChaoJiHuoBa(bool value)
	{
		this.info.ChaoJiHuoBa = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetShangDianDaZhe()
	{
		return GameData.CurrentGameType != GameData.GameType.Endless && this.info.ShangDianDaZhe;
	}

	public void SetShangDianDaZhe(bool value)
	{
		this.info.ShangDianDaZhe = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetWuYongZhiShi()
	{
		return this.info.WuYongZhiShi;
	}

	public void SetWuYongZhiShi(bool value)
	{
		this.info.WuYongZhiShi = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetChouWaZi()
	{
		return this.info.ChouWaZi;
	}

	public void SetChouWaZi(bool value)
	{
		this.info.ChouWaZi = value;
		this.SaveAdvanceDataInfo();
	}

	public bool GetXiangSuTang()
	{
		return this.info.XiangSuTang;
	}

	public void SetXiangSuTang(bool value)
	{
		this.info.XiangSuTang = value;
		this.SaveAdvanceDataInfo();
	}

	private AdvanceData info;

	public string settingPath = Path.Combine(Application.persistentDataPath, "AdvanceData.json");
}
