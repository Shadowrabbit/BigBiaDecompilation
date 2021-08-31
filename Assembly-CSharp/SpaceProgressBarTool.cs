using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceProgressBarTool : MonoBehaviour
{
	public void SetProgress(float value, string content)
	{
		this.ProgressImg.fillAmount = value;
		this.ProgressText.text = content + "%";
	}

	public Image ProgressImg;

	public TMP_Text ProgressText;
}
