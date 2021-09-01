using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationMgr : MonoBehaviour
{
	private void Awake()
	{
		LocalizationMgr.Instance = this;
	}

	public void GetLocalizationDic(LanguageType type)
	{
		this.CurLangDic = new Dictionary<string, string>();
		string[] array = Resources.Load<TextAsset>("Localization/" + type.ToString().ToLower()).text.Split(new char[]
		{
			'\n'
		});
		for (int i = 1; i < array.Length - 1; i++)
		{
			string[] array2 = array[i].Split(new char[]
			{
				','
			});
			if (array2.Length > 2)
			{
				string text = "";
				for (int j = 1; j < array2.Length; j++)
				{
					text = text + array2[j] + ",";
				}
				text = text.Substring(0, text.Length - 2);
				text = text.Replace("\\n", "\n");
				this.CurLangDic.Add(array2[0], text);
			}
			else
			{
				string text2 = array2[1].Substring(0, array2[1].Length - 1);
				text2 = text2.Replace("\\n", "\n");
				this.CurLangDic.Add(array2[0], text2);
			}
		}
	}

	public string GetLocalizationWord(string key)
	{
		if (!this.CurLangDic.ContainsKey(key))
		{
			return key;
		}
		return this.CurLangDic[key];
	}

	public static LocalizationMgr Instance;

	public Dictionary<string, string> CurLangDic = new Dictionary<string, string>();
}
