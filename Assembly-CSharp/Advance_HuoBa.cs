using System;
using System.Collections.Generic;
using System.Linq;

public class Advance_HuoBa : AdvanceUIBase
{
	private void Start()
	{
		this.InitDic();
		if (GlobalController.Instance.AdvanceDataController.GetHuoBa() < 5)
		{
			if (GlobalController.Instance.AdvanceDataController.GetHuoBa() == 4)
			{
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() - 1).Key;
				this.ContentText.text = this.Content;
				this.PriceText.text = "";
				this.ButtonImage.sprite = this.Images[1];
				this.BuyButton.interactable = false;
				return;
			}
			this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetHuoBa()).Key;
			this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetHuoBa()).Value;
			this.ContentText.text = this.Content;
			this.PriceText.text = (this.Price.ToString() ?? "");
		}
	}

	private void InitDic()
	{
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_41"), 50);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_42"), 100);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_43"), 150);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_44"), 200);
	}

	public override void OnButtonClick()
	{
		if (GlobalController.Instance.GlobalData.Money >= this.Price)
		{
			GlobalController.Instance.ChangeGlobalMoney(-this.Price);
			SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhufu);
			if (GlobalController.Instance.AdvanceDataController.GetHuoBa() + 1 < 5)
			{
				GlobalController.Instance.AdvanceDataController.SetHuoBa(GlobalController.Instance.AdvanceDataController.GetHuoBa() + 1);
				if (GlobalController.Instance.AdvanceDataController.GetHuoBa() == 4)
				{
					this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetHuoBa() - 1).Key;
					this.ContentText.text = this.Content;
					this.PriceText.text = "";
					this.ButtonImage.sprite = this.Images[1];
					this.BuyButton.interactable = false;
					return;
				}
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetHuoBa()).Key;
				this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetHuoBa()).Value;
				this.ContentText.text = this.Content;
				this.PriceText.text = (this.Price.ToString() ?? "");
				return;
			}
		}
		else
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
		}
	}

	private Dictionary<string, int> m_ContentAndPrice = new Dictionary<string, int>();
}
