using System;
using TMPro;
using UnityEngine;

public class JudgeMissionPanel : MonoBehaviour
{
	public void ClearPanel()
	{
		this.MissionText.text = "";
		this.YellowText.text = "";
		this.RedText.text = "";
		this.BlueText.text = "";
		this.TipText.text = "";
		this.MissionContent = Vector3.zero;
	}

	public TMP_Text MissionText;

	public TMP_Text YellowText;

	public TMP_Text RedText;

	public TMP_Text BlueText;

	public TMP_Text TipText;

	[NonSerialized]
	public Vector3 MissionContent;
}
