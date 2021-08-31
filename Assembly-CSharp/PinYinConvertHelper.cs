using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.International.Converters.PinYinConverter;
using UnityEngine;

public class PinYinConvertHelper : MonoBehaviour
{
	private PinYinConvertHelper()
	{
		PinYinConvertHelper.Instance = this;
	}

	private void Start()
	{
		this.m_AudioSource = base.transform.GetComponent<AudioSource>();
	}

	private List<string> GetPinYin(string[] contents)
	{
		List<string> list = new List<string>();
		foreach (string text in contents)
		{
			string text2 = "";
			string text3 = text;
			for (int j = 0; j < text3.Length; j++)
			{
				string text4 = new ChineseChar(text3[j]).Pinyins[0].ToString();
				text4 = text4.Substring(text4.Length);
				text2 += text4;
			}
			list.Add(text2);
		}
		return list;
	}

	public string GetPinYin(string content)
	{
		string text = "";
		for (int i = 0; i < content.Length; i++)
		{
			string text2 = new ChineseChar(content[i]).Pinyins[0].ToString();
			text2 = text2.Substring(0, text2.Length - 1);
			text += text2;
		}
		Debug.Log(text.ToLower());
		return text.ToLower();
	}

	public string GetNamePinYin(string content)
	{
		if (string.IsNullOrEmpty(content))
		{
			return "";
		}
		string text = content.Substring(0, 1);
		string text2 = content.Substring(1, content.Length - 1);
		string str = "";
		string text3 = text;
		for (int i = 0; i < text3.Length; i++)
		{
			string text4 = new ChineseChar(text3[i]).Pinyins[0].ToString();
			text4.ToLower();
			text4 = text4[0].ToString().ToUpper() + text4.Substring(1, text4.Length - 2).ToLower();
			str += text4;
		}
		string text5 = "";
		text3 = text2;
		for (int i = 0; i < text3.Length; i++)
		{
			string text6 = new ChineseChar(text3[i]).Pinyins[0].ToString();
			text6.ToLower();
			text6 = text6.Substring(0, text6.Length - 1);
			text5 += text6;
		}
		text5 = text5[0].ToString().ToUpper() + text5.Substring(1, text5.Length - 1).ToLower();
		return str + " " + text5;
	}

	public void GetContentVoice(string content)
	{
		string[] contents = content.Split(new char[]
		{
			'_'
		});
		List<string> pinYin = this.GetPinYin(contents);
		if (this.m_VoiceCorotine != null)
		{
			base.StopCoroutine(this.m_VoiceCorotine);
		}
		this.m_VoiceCorotine = this.ContentVoiceCorotine(pinYin);
		base.StartCoroutine(this.m_VoiceCorotine);
	}

	private IEnumerator ContentVoiceCorotine(List<string> voiceNumbs)
	{
		CharacterAudioEvent c = this.CAudios[SYNCRandom.Range(0, this.CAudios.Count)];
		float picth = SYNCRandom.Range(0.8f, 1.5f);
		foreach (string text in voiceNumbs)
		{
			foreach (char c2 in text)
			{
				c.Play(this.m_AudioSource, int.Parse(c2.ToString()) % 5, picth);
				yield return new WaitForSeconds(this.Duration);
			}
			string text2 = null;
			yield return new WaitForSeconds(0.5f);
		}
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		yield break;
		yield break;
	}

	public static PinYinConvertHelper Instance;

	public List<CharacterAudioEvent> CAudios;

	private AudioSource m_AudioSource;

	private IEnumerator m_VoiceCorotine;

	public float Duration = 0.2f;
}
