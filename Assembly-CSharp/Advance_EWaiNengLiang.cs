using System;
using System.Collections.Generic;
using System.Linq;

public class Advance_EWaiNengLiang : AdvanceUIBase
{
	private void Start()
	{
		if (GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() > 0)
		{
			SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhufu);
		}
		this.InitDic();
		if (GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() >= 3)
		{
			GlobalController.Instance.AdvanceDataController.SetEWaiNengLiang(2);
		}
		if (GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() < 3)
		{
			if (GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() == 2)
			{
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() - 1).Key;
				this.ContentText.text = this.Content;
				this.PriceText.text = "";
				this.ButtonImage.sprite = this.Images[1];
				this.BuyButton.interactable = false;
				return;
			}
			this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang()).Key;
			this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang()).Value;
			this.ContentText.text = this.Content;
			this.PriceText.text = (this.Price.ToString() ?? "");
		}
	}

	private void InitDic()
	{
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_49"), 100);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_50"), 200);
	}

	public override void OnButtonClick()
	{
		if (GlobalController.Instance.GlobalData.Money >= this.Price)
		{
			GlobalController.Instance.ChangeGlobalMoney(-this.Price);
			SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhufu);
			if (GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() + 1 < 3)
			{
				GlobalController.Instance.AdvanceDataController.SetEWaiNengLiang(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() + 1);
				if (GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() == 2)
				{
					this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() - 1).Key;
					this.ContentText.text = this.Content;
					this.PriceText.text = "";
					this.ButtonImage.sprite = this.Images[1];
					this.BuyButton.interactable = false;
					return;
				}
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang()).Key;
				this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang()).Value;
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
