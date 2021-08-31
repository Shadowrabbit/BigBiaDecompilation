using System;
using DG.Tweening;
using UnityEngine;

public class JianGuoDianQi : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (this.IsPower && base.transform.name.Equals("电磁炉") && base.transform.GetChild(0).childCount > 0 && !this.isDianCiLu)
		{
			base.transform.GetChild(0).GetChild(0).GetChild(0).DOScale(Vector3.one, 1f);
			base.transform.GetChild(0).GetChild(0).GetChild(0).SetParent(base.transform.parent);
			base.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetTrigger("play");
			base.transform.GetChild(0).GetChild(0).SetParent(base.transform.parent.transform.parent);
			this.isDianCiLu = true;
		}
	}

	public bool IsPower;

	private bool isDianCiLu;
}
