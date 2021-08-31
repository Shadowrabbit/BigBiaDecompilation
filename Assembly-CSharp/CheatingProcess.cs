using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CheatingProcess : MonoBehaviour
{
	private void Start()
	{
		if (Process.GetProcessesByName("Big Bia Early Access Plus 12 Trainer.exe").Length != 0)
		{
			UnityEngine.Debug.Log("检测存在！");
		}
		else if (Process.GetProcessesByName("Big Bia Early Access Plus 12 Trainer").Length != 0)
		{
			UnityEngine.Debug.Log("检测存在2！");
		}
		else
		{
			UnityEngine.Debug.Log("无用！");
		}
		if (this.GetPidByProcessName("Big Bia Early Access Plus 12 Trainer.exe") != 0)
		{
			UnityEngine.Debug.Log("检测存在3！");
		}
		else if (this.GetPidByProcessName("Big Bia Early Access Plus 12 Trainer") != 0)
		{
			UnityEngine.Debug.Log("检测存在4！");
		}
		else if (this.GetPidByProcessName("《宇宙大拍扁》Early Access 十二修改器") != 0)
		{
			UnityEngine.Debug.Log("检测存在5！");
		}
		else if (Process.GetProcessesByName("Big Bia Early Access Plus 12 Trainer.exe").Length != 0)
		{
			UnityEngine.Debug.Log("检测存在6！");
		}
		else
		{
			UnityEngine.Debug.Log("无用2！");
		}
		base.StartCoroutine(this.ProcessCorotine());
	}

	private IEnumerator ProcessCorotine()
	{
		List<string> proNames = new List<string>();
		Process[] processes = Process.GetProcesses();
		UnityEngine.Debug.Log("当前进程数：  " + processes.Length.ToString());
		foreach (Process process in processes)
		{
			proNames.Add(process.ProcessName);
			UnityEngine.Debug.Log(process.ProcessName);
		}
		yield return new WaitForSeconds(5f);
		UnityEngine.Debug.Log("请打开程序");
		yield return new WaitForSeconds(5f);
		processes = Process.GetProcesses();
		UnityEngine.Debug.Log("当前进程数：  " + processes.Length.ToString());
		foreach (Process process2 in processes)
		{
			if (!proNames.Contains(process2.ProcessName))
			{
				UnityEngine.Debug.Log("==========> " + process2.ProcessName);
			}
		}
		yield break;
	}

	private IEnumerator CheatingCorotine()
	{
		for (;;)
		{
			if (GameData.CurrentGameType == GameData.GameType.Endless && this.GetPidByProcessName("Big Bia Early Access Plus 12 Trainer.exe") == 0)
			{
				UnityEngine.Debug.Log("检测作弊！程序自动退出！");
				if (GameController.ins != null)
				{
					GameController.ins.GameData.isFake = true;
					YesPanel yesPanel = GameController.ins.UIController.YesPanel;
					yesPanel.MainText.text = LocalizationMgr.Instance.GetLocalizationWord("UI_作弊");
					GameController.ins.StartCoroutine(yesPanel.StartChoosing());
				}
			}
			yield return new WaitForSeconds(1f);
		}
		yield break;
	}

	public int GetPidByProcessName(string processName)
	{
		Process[] processesByName = Process.GetProcessesByName(processName);
		int num = 0;
		if (num >= processesByName.Length)
		{
			return 0;
		}
		return processesByName[num].Id;
	}
}
