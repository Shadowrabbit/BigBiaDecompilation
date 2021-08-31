using System;
using UnityEngine;

public class DodgingStartButton : MonoBehaviour
{
	private void Start()
	{
		this.spriterenderer = base.GetComponent<SpriteRenderer>();
		this.origincolor = this.spriterenderer.color;
	}

	private void OnMouseEnter()
	{
		this.spriterenderer.color = new Color(0.5677f, 0.8207f, 0.3657f);
	}

	private void OnMouseExit()
	{
		this.spriterenderer.color = this.origincolor;
	}

	private void OnMouseDown()
	{
		this.spriterenderer.color = Color.white;
	}

	private void OnMouseUp()
	{
		base.gameObject.SetActive(false);
		this.DodgingMainPart.OnStartButton();
	}

	public DodgingMainPart DodgingMainPart;

	public SpriteRenderer spriterenderer;

	private Color origincolor;
}
