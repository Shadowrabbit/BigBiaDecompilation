using System;
using UnityEngine;

public class NextPage : MonoBehaviour
{
	private void OnMouseUp()
	{
		this.NewspaperController.NextPage();
	}

	public NewspaperController NewspaperController;
}
