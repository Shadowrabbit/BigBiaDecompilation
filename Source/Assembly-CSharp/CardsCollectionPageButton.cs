using System;
using UnityEngine;

public class CardsCollectionPageButton : MonoBehaviour
{
	public void OnMouseDown()
	{
		CardsCollectionMgr.Instance.UpdateCards(this.direction);
	}

	public CardsCollectionPageButton.Direction direction;

	public enum Direction
	{
		Left,
		Right
	}
}
