using System;
using UnityEngine;

public class LastPage : MonoBehaviour
{
	private void OnMouseUp()
	{
		this.NewspaperController.LastPage();
	}

	public NewspaperController NewspaperController;
}
