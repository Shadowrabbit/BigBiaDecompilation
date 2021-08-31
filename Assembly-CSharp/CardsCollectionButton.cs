using System;
using UnityEngine;

public class CardsCollectionButton : MonoBehaviour
{
	public void OnMouseDown()
	{
		CardsCollectionMgr.Instance.UpdateCards((TagMap)((long)this.DisplayTagMap), 0);
	}

	public int DisplayTagMap;
}
