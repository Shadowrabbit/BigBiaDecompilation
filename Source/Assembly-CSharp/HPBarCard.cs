using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarCard : MonoBehaviour
{
	private void Start()
	{
		this.DeltaAmount = 0.0012f;
		this.HpBar.fillAmount = 1f;
		this.HpCacheBar.fillAmount = 1f;
	}

	private void Update()
	{
		if (GameController.ins != null && GameController.ins.GameData != null && GameController.ins.GameData.PlayerCardData != null)
		{
			this.HpBar.fillAmount = (float)GameController.ins.GameData.PlayerCardData.HP / (float)GameController.ins.GameData.PlayerCardData.MaxHP;
			if (this.HpCacheBar.fillAmount > this.HpBar.fillAmount)
			{
				this.HpCacheBar.fillAmount -= this.DeltaAmount;
			}
			else if (this.HpCacheBar.fillAmount < this.HpBar.fillAmount)
			{
				this.HpCacheBar.fillAmount += this.DeltaAmount;
			}
			if (Mathf.Abs(this.HpCacheBar.fillAmount - this.HpBar.fillAmount) <= this.DeltaAmount)
			{
				this.HpCacheBar.fillAmount = this.HpBar.fillAmount;
			}
			this.HpText.text = GameController.ins.GameData.PlayerCardData.HP.ToString() + "/" + GameController.ins.GameData.PlayerCardData.MaxHP.ToString();
		}
	}

	public Image HpBar;

	public Image HpCacheBar;

	public TextMeshProUGUI HpText;

	private float DeltaAmount = 0.0012f;
}
