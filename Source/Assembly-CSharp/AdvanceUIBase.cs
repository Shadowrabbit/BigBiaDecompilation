using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceUIBase : MonoBehaviour
{
	public virtual void OnButtonClick()
	{
	}

	public string Content;

	public int Price;

	public Button BuyButton;

	public List<Sprite> Images;

	public Text ContentText;

	public Text PriceText;

	public Image ButtonImage;
}
