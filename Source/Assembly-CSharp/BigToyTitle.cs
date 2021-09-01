using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BigToyTitle : MonoBehaviour
{
	private void Start()
	{
	}

	public void show()
	{
		this.isShow = true;
	}

	public void hide()
	{
		this.isShow = false;
	}

	private void Update()
	{
		if (this.isShow)
		{
			if (this.frame <= 100)
			{
				this.frame += 2;
			}
		}
		else if (this.frame >= 0)
		{
			this.frame -= 2;
		}
		this.Circle.color = new Color(255f, 255f, 255f, (float)this.frame / 30f);
		float size;
		if (this.frame < 20)
		{
			size = 0f;
		}
		else if (this.frame > 40)
		{
			size = 3f;
		}
		else
		{
			size = (float)(this.frame - 20) / 8f;
		}
		this.Line.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
		this.NameText.alpha = ((float)this.frame - 60f) / 20f;
		this.DescText.alpha = ((float)this.frame - 70f) / 20f;
	}

	public Image Circle;

	public Image Line;

	public TextMeshProUGUI NameText;

	public TextMeshProUGUI DescText;

	private int frame;

	private bool isShow;
}
