using System;
using DG.Tweening;
using UnityEngine;

public class RingShotSpecialTool : MonoBehaviour
{
	private void Start()
	{
		this.isGot = false;
		this.effect = base.GetComponentInChildren<ParticleSystem>();
		this.tweener = base.transform.DOLocalMoveX(2f, 5f, false);
		this.tweener.SetLoops(-1, LoopType.Yoyo);
		this.tweener.SetEase(Ease.InOutCubic);
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!this.isGot && other.gameObject.name == "RingTrigger")
		{
			this.isGot = true;
			this.effect.Play();
			this.RingShotSpecialToy.NeedStay = true;
			this.RingShotSpecialToy.gotNum++;
			this.tweener.Pause<Tweener>();
			DungeonOperationMgr.Instance.ChangeMoney(100);
		}
	}

	public RingShotSpecialToy RingShotSpecialToy;

	private bool isGot;

	private Tweener tweener;

	private ParticleSystem effect;
}
