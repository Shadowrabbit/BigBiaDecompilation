using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TicketController
{
	public static TicketController Instance
	{
		get
		{
			TicketController result;
			if ((result = TicketController.instance) == null)
			{
				result = (TicketController.instance = new TicketController());
			}
			return result;
		}
	}

	private void CreateAndWriteTicketFile()
	{
		FileInfo fileInfo = new FileInfo(this.path + "//" + this.fileName + ".curlog");
		StreamWriter streamWriter;
		if (!fileInfo.Exists)
		{
			streamWriter = fileInfo.CreateText();
		}
		else
		{
			streamWriter = fileInfo.AppendText();
		}
		foreach (string value in this.TicketCache)
		{
			streamWriter.WriteLine(value);
		}
		streamWriter.Close();
		streamWriter.Dispose();
		this.ClearTicketCache();
	}

	private List<string> LoadAllTicket()
	{
		List<string> list = new List<string>();
		foreach (string item in this.havedTickets)
		{
			list.Add(item);
		}
		foreach (string item2 in this.TicketCache)
		{
			list.Add(item2);
		}
		return list;
	}

	private void ClearTicketCache()
	{
		this.TicketCache.Clear();
		this.havedTickets.Clear();
	}

	private void ClearTicketFileText()
	{
		StreamWriter streamWriter = new StreamWriter(this.path + "//" + this.fileName + ".curlog");
		streamWriter.Write("");
		streamWriter.Close();
		this.ClearTicketCache();
	}

	public void InitTicketContent()
	{
		if (!File.Exists(this.path + "//" + this.fileName + ".curlog"))
		{
			Debug.LogError("文件不存在");
			return;
		}
		string[] array = File.ReadAllLines(this.path + "//" + this.fileName + ".curlog");
		this.havedTickets = new List<string>();
		foreach (string item in array)
		{
			this.havedTickets.Add(item);
		}
	}

	public void AddTicket(string ticketContent)
	{
		if (this.LoadAllTicket().Contains(ticketContent))
		{
			Debug.Log("已经为该作品投过票");
			return;
		}
		this.TicketCache.Add(ticketContent);
		this.CreateAndWriteTicketFile();
	}

	public void CheckGameDateEquals()
	{
		if (string.IsNullOrEmpty(PlayerPrefs.GetString("TheLastGameDate")))
		{
			PlayerPrefs.SetString("TheLastGameDate", DateTime.Now.ToString("yyyyMMdd"));
			return;
		}
		if (DateTime.Now.ToString("yyyyMMdd").Equals(PlayerPrefs.GetString("TheLastGameDate")))
		{
			this.CreateAndWriteTicketFile();
			return;
		}
		this.ClearTicketFileText();
		this.CreateAndWriteTicketFile();
	}

	private static TicketController instance;

	private List<string> TicketCache = new List<string>();

	private List<string> havedTickets = new List<string>();

	private string path = Application.streamingAssetsPath + "/Log/";

	private string fileName = "ticket";
}
