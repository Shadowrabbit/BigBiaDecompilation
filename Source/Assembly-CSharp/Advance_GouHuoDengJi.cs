using System;
using System.Collections.Generic;
using System.Linq;

public class Advance_GouHuoDengJi : AdvanceUIBase
{
	private void Start()
	{
		this.InitDic();
		if (GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() < 4)
		{
			if (GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() == 3)
			{
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() - 1).Key;
				this.ContentText.text = this.Content;
				this.PriceText.text = "";
				this.ButtonImage.sprite = this.Images[1];
				this.BuyButton.interactable = false;
				return;
			}
			this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi()).Key;
			this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi()).Value;
			this.ContentText.text = this.Content;
			this.PriceText.text = (this.Price.ToString() ?? "");
		}
	}

	private void InitDic()
	{
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_52"), 200);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_53"), 200);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_54"), 500);
	}

	public override void OnButtonClick()
	{
		if (GlobalController.Instance.GlobalData.Money >= this.Price)
		{
			GlobalController.Instance.ChangeGlobalMoney(-this.Price);
			SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhufu);
			if (GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() + 1 < 4)
			{
				GlobalController.Instance.AdvanceDataController.SetGouHuoDengJi(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() + 1);
				if (GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() == 3)
				{
					this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi() - 1).Key;
					this.ContentText.text = this.Content;
					this.PriceText.text = "";
					this.ButtonImage.sprite = this.Images[1];
					this.BuyButton.interactable = false;
					return;
				}
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi()).Key;
				this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi()).Value;
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
