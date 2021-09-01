using System;
using DG.Tweening;
using UnityEngine;

public class SharkTooth : MonoBehaviour
{
	private void OnMouseUp()
	{
		if (this.IsPushed)
		{
			return;
		}
		if (this.Num == this.Shark.SelectedToothNum)
		{
			this.Shark.OnSelected();
		}
		else
		{
			this.Shark.Gold += this.Shark.NextGold[this.Shark.Point];
			this.Shark.GoldText.text = this.Shark.Gold.ToString();
			this.Shark.Point++;
			this.Shark.NextGoldText.text = this.Shark.NextGold[this.Shark.Point].ToString();
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.07f, 0f), 0.1f, false);
		this.IsPushed = true;
	}

	public Shark Shark;

	public int Num;

	public bool IsPushed;
}
