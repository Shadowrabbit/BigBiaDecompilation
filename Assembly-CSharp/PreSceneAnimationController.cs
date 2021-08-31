using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSceneAnimationController : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.AnimationThread());
	}

	private void Update()
	{
	}

	private IEnumerator AnimationThread()
	{
		yield return new WaitForSeconds(1f);
		this.Player.GetComponent<Animator>().SetBool("Run", true);
		yield return base.StartCoroutine(this.PlayerMove());
		this.Player.GetComponent<Animator>().SetBool("Run", false);
		this.Player.GetComponent<Animator>().SetTrigger("Jump");
		yield break;
	}

	private IEnumerator PlayerMove()
	{
		while (!this.isPoint)
		{
			this.moveforward();
			yield return null;
		}
		yield break;
	}

	private void moveforward()
	{
		Quaternion b = Quaternion.LookRotation(this.TarPorts[this.PortsIndex] - base.transform.position);
		base.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.speed);
		this.IsInTarPort();
	}

	private void IsInTarPort()
	{
		if (Vector3.Distance(this.TarPorts[this.PortsIndex], base.transform.position) < 0.2f)
		{
			this.PortsIndex++;
			this.isPoint = true;
		}
	}

	[Header("主角")]
	public Transform Player;

	[Header("目标点")]
	public List<Vector3> TarPorts;

	[Header("动画名称")]
	public List<string> AniName;

	[Header("相关物品列表")]
	public List<GameObject> Items;

	private bool isPoint;

	private int PortsIndex;

	private float speed = 2f;
}
