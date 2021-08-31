using System;
using System.Collections;
using UnityEngine;

public class MenuSceneInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		if (obj != LanguageType.ZH_CN)
		{
			if (obj == LanguageType.EN)
			{
				this.Title_EN.SetActive(true);
				this.Title_ZH.SetActive(false);
			}
		}
		else
		{
			this.Title_EN.SetActive(false);
			this.Title_ZH.SetActive(true);
		}
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_3");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_4");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_5");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_6");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_宇宙大报刊");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_续连");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_英文版提示");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
	}

	public override void Start()
	{
		base.Start();
		base.StartCoroutine(this.InitMenu());
	}

	private IEnumerator InitMenu()
	{
		yield return null;
		LanguageType language = GlobalController.Instance.GameSettingController.info.language;
		if (language != LanguageType.ZH_CN)
		{
			if (language == LanguageType.EN)
			{
				this.Title_EN.SetActive(true);
				this.Title_ZH.SetActive(false);
			}
		}
		else
		{
			this.Title_EN.SetActive(false);
			this.Title_ZH.SetActive(true);
		}
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_3");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_4");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_5");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_6");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_宇宙大报刊");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_续连");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_英文版提示");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
		yield break;
	}

	public GameObject Title_ZH;

	public GameObject Title_EN;
}
