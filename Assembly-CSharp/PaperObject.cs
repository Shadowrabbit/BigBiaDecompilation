using System;
using DG.Tweening;
using UnityEngine;

public class PaperObject : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseEnter()
	{
		if (BaoKanController.ins.currentPaperObjuct == this)
		{
			return;
		}
		if (NewspaperItem.isDoing)
		{
			return;
		}
		base.GetComponent<SpriteRenderer>().color = new Color32(220, 220, 220, 220);
	}

	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().color = new Color32(183, 183, 183, byte.MaxValue);
	}

	private void OnMouseDown()
	{
		if (NewspaperItem.isDoing)
		{
			return;
		}
		BaoKanController.ins.currentPaperObjuct = this;
		Camera.main.transform.DOMoveX(base.transform.position.x, 1f, false);
	}
}
