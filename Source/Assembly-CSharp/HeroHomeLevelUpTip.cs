using System;
using UnityEngine;

public class HeroHomeLevelUpTip : MonoBehaviour
{
	private void Start()
	{
		this.m_CardData = new CardData();
		this.m_CardData.Name = LocalizationMgr.Instance.GetLocalizationWord("T_" + this.Name);
		this.m_CardData.desc = LocalizationMgr.Instance.GetLocalizationWord("T_" + this.DESC) + "+" + this.Rate;
	}

	public void OnMouseEnter()
	{
		GameUIController.Instance.OpenTips(this.m_CardData, base.transform.position, Camera.main);
	}

	public void OnMouseExit()
	{
		GameUIController.Instance.CloseTips();
	}

	public HeroHomeArea HeroHomeArea;

	public string Name;

	public string DESC;

	public string Rate;

	private CardData m_CardData;
}
