using System;
using UnityEngine;

public class ExitPageBtn : MonoBehaviour
{
	private void OnMouseUp()
	{
		UnityEngine.Object.DestroyImmediate(this.NewspaperController.gameObject);
	}

	public NewspaperController NewspaperController;
}
