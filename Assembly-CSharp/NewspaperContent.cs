using System;
using TMPro;
using UnityEngine;

public class NewspaperContent : MonoBehaviour
{
	private void Start()
	{
		this.TitleText.text = this.Title;
		if (!GlobalController.Instance.GetHaveReadNewspapersData().Contains(this.PrefabName))
		{
			this.TitleText.text = "<color=red>New</color> " + this.Title;
		}
	}

	public TMP_Text TitleText;

	public string Title;

	public string PrefabName;
}
