using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LogDataController
{
	public void Init()
	{
		if (!Directory.Exists(this.settingPath))
		{
			Debug.LogError("目标文件夹不存在 ——>：" + this.settingPath);
			Directory.CreateDirectory(this.settingPath);
			Debug.LogError("创建文件夹 ——>：" + this.settingPath);
		}
	}

	public void CreateLogDataInfo(string fileName, List<JournalsBean> data = null)
	{
		this.path = this.settingPath + fileName + ".log";
		if (!File.Exists(this.path))
		{
			this.info = new LogData();
			if (data != null)
			{
				this.info.Content = data;
			}
			this.SaveLogDataInfo(this.info);
			return;
		}
		Debug.LogError("当前日志文件已存在！");
	}

	public LogData LoadAdvanceDataInfo(string fileName)
	{
		string value = File.ReadAllText(this.settingPath + fileName);
		this.info = (JsonConvert.DeserializeObject(value, typeof(LogData)) as LogData);
		Debug.LogError("读取日志文件 ——> ：" + this.settingPath + fileName);
		return this.info;
	}

	public void SaveLogDataInfo(LogData data = null)
	{
		if (data == null)
		{
			data = this.info;
		}
		string contents = JsonConvert.SerializeObject(data, Formatting.Indented);
		File.WriteAllText(this.path, contents);
		Debug.LogError("生成或保存日志文件 ——> ：" + this.path);
	}

	public void DeleteLogFile(string logFile = null)
	{
		if (string.IsNullOrEmpty(logFile))
		{
			logFile = this.path;
		}
		if (File.Exists(logFile))
		{
			Debug.LogError("删除日志文件 ——> ：" + logFile);
			File.Delete(logFile);
		}
	}

	public FileInfo[] GetFiles(string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories)
	{
		if (Directory.Exists(this.settingPath))
		{
			return new DirectoryInfo(this.settingPath).GetFiles(searchPattern, searchOption);
		}
		return null;
	}

	public bool DeleteAllFile()
	{
		if (Directory.Exists(this.settingPath))
		{
			FileInfo[] files = new DirectoryInfo(this.settingPath).GetFiles("*", SearchOption.AllDirectories);
			Debug.Log(files.Length);
			for (int i = 0; i < files.Length; i++)
			{
				if (!files[i].Name.EndsWith(".meta"))
				{
					File.Delete(this.settingPath + "/" + files[i].Name);
				}
			}
			return true;
		}
		return false;
	}

	private LogData info;

	public string settingPath = Application.persistentDataPath + "/Log/";

	private string path;
}
