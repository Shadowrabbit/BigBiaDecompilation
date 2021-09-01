using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LoggerWriter : MonoBehaviour
{
	private void Awake()
	{
		LoggerWriter.Instance = this;
		this.path = Path.Combine(Application.persistentDataPath, "CurLog.curlog");
	}

	public void InitLogContent()
	{
		if (!File.Exists(this.path))
		{
			return;
		}
		string[] array = File.ReadAllLines(this.path);
		this.ExsitContents = new List<LogBean>();
		foreach (string value in array)
		{
			this.ExsitContents.Add(JsonConvert.DeserializeObject<LogBean>(value));
		}
	}

	public void CreateAndWriteLogFile()
	{
		FileInfo fileInfo = new FileInfo(this.path);
		StreamWriter streamWriter;
		if (!fileInfo.Exists)
		{
			streamWriter = fileInfo.CreateText();
		}
		else
		{
			streamWriter = fileInfo.AppendText();
		}
		foreach (LogBean value in this.LogCache)
		{
			streamWriter.WriteLine(JsonConvert.SerializeObject(value));
		}
		streamWriter.Close();
		streamWriter.Dispose();
	}

	public ArrayList LoadLog()
	{
		ArrayList arrayList = new ArrayList();
		foreach (LogBean value in this.ExsitContents)
		{
			arrayList.Add(value);
		}
		foreach (LogBean value2 in this.LogCache)
		{
			arrayList.Add(value2);
		}
		return arrayList;
	}

	public void ClearLogCache()
	{
		this.LogCache.Clear();
		this.ExsitContents.Clear();
	}

	public void ClearLog()
	{
		this.ClearLogCache();
		File.Delete(this.path);
	}

	public static LoggerWriter Instance;

	public List<LogBean> LogCache = new List<LogBean>();

	public List<LogBean> ExsitContents = new List<LogBean>();

	public string path = "";
}
