using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherRoomAnimationController : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.StartAnimation());
	}

	private IEnumerator StartAnimation()
	{
		for (;;)
		{
			yield return new WaitForSeconds((float)UnityEngine.Random.Range(4, 8));
			int index = UnityEngine.Random.Range(0, this.Animators.Count);
			this.Animators[index].Rebind();
			this.Animators[index].SetTrigger("play");
		}
		yield break;
	}

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out raycastHit))
		{
			Collider collider = raycastHit.collider;
			if (!collider.enabled)
			{
				return;
			}
			if (collider != null)
			{
				if (collider.transform.parent == null)
				{
					return;
				}
				if (collider.transform.parent.GetComponent<Animator>())
				{
					collider.transform.parent.GetComponent<Animator>().Rebind();
					collider.transform.parent.GetComponent<Animator>().SetTrigger("play");
				}
				if (collider.transform.GetComponent<Animator>())
				{
					collider.transform.GetComponent<Animator>().Rebind();
					collider.transform.GetComponent<Animator>().SetTrigger("play");
				}
			}
		}
	}

	public List<Animator> Animators;
}
