using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieTest : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.zouni());
	}

	private IEnumerator zouni()
	{
		yield return new WaitForSeconds(2f);
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			Card card = null;
			try
			{
				card = Card.InitCard(cardData);
			}
			catch
			{
			}
			if (!(card == null))
			{
				card.transform.position = this.start.transform.position;
				card.gameObject.AddComponent<BoxCollider>().size = new Vector3(1f, 0.2f, 1f);
				card.gameObject.AddComponent<Rigidbody>();
				yield return new WaitForSeconds(0.05f);
			}
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield return null;
		yield break;
		yield break;
	}

	public Transform start;
}
