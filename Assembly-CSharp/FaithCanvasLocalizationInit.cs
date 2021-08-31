using System;

public class FaithCanvasLocalizationInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福提示");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福点");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷1");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷2");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷3");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明1");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明2");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明3");
		this.InitComponents[12].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[13].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅");
		this.InitComponents[14].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅1");
		this.InitComponents[15].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅2");
		this.InitComponents[16].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅3");
		this.InitComponents[17].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[18].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺");
		this.InitComponents[19].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺1");
		this.InitComponents[20].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺2");
		this.InitComponents[21].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺3");
		this.InitComponents[22].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[23].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒");
		this.InitComponents[24].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒1");
		this.InitComponents[25].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒2");
		this.InitComponents[26].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒3");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福提示");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福点");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷1");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷2");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_迅捷3");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明1");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明2");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_精明3");
		this.InitComponents[12].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[13].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅");
		this.InitComponents[14].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅1");
		this.InitComponents[15].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅2");
		this.InitComponents[16].text = LocalizationMgr.Instance.GetLocalizationWord("UI_坚毅3");
		this.InitComponents[17].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[18].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺");
		this.InitComponents[19].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺1");
		this.InitComponents[20].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺2");
		this.InitComponents[21].text = LocalizationMgr.Instance.GetLocalizationWord("UI_掠夺3");
		this.InitComponents[22].text = LocalizationMgr.Instance.GetLocalizationWord("UI_祈福等级");
		this.InitComponents[23].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒");
		this.InitComponents[24].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒1");
		this.InitComponents[25].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒2");
		this.InitComponents[26].text = LocalizationMgr.Instance.GetLocalizationWord("UI_暴怒3");
	}
}
