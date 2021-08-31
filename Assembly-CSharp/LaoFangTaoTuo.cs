using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HighlightingSystem;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

public class LaoFangTaoTuo : MonoBehaviour
{
	private void Start()
	{
		PlayerPrefs.SetInt("牢房", 0);
		foreach (Collider key in this.DengList)
		{
			this.dengState.Add(key, false);
		}
		if (PlayerPrefs.GetInt("牢房") != 0)
		{
			this.TarCharacter.gameObject.SetActive(false);
			return;
		}
		base.StartCoroutine(this.StartThread());
	}

	private IEnumerator StartThread()
	{
		yield return new WaitForSeconds(1f);
		DialogueManager.StartConversation("牢房前置");
		yield break;
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("牢房") != 0)
		{
			return;
		}
		this.CheckLuosi();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			if (this.dragTrans != null)
			{
				this.dragTrans.GetComponent<Highlighter>().constant = false;
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				Collider collider = raycastHit.collider;
				if (!collider.enabled)
				{
					return;
				}
				if (collider == this.Lajitong.GetComponent<Collider>() && !this.isLajitong)
				{
					base.StartCoroutine(this.OnLajitongPlay());
				}
				else if (collider == this.Xiangzi.GetComponent<Collider>())
				{
					if (!this.isXinagzi)
					{
						this.OnXiangziPush();
					}
					else if (this.dragTrans == this.QiaoGun)
					{
						this.Xiangzi.GetComponent<Animator>().SetTrigger("play");
						this.Xiangzi.GetComponent<Collider>().enabled = false;
					}
					else
					{
						base.StartCoroutine(this.TarTalk(0));
					}
				}
				else if (collider == this.Zhentou.GetComponent<Collider>() && !this.isZhenTou)
				{
					this.Zhentou.DOLocalJump(new Vector3(-3.791f, 0.26f, 0.251f), 1f, 1, 1f, false);
					this.Zhentou.DORotate(new Vector3(0f, 23.227f, 0f), 1f, RotateMode.Fast).OnComplete(delegate
					{
						this.isZhenTou = true;
					});
				}
				else if (collider == this.MenBashou.GetComponent<Collider>() && !this.canOpen)
				{
					if (this.dragTrans == this.Bashou)
					{
						this.Bashou.SetParent(this.MenBashou);
						this.Bashou.DOLocalMove(new Vector3(0f, 0.023f, -0.035f), 1f, false).OnComplete(delegate
						{
							this.Bashou.GetComponent<Collider>().enabled = false;
							this.MenBashou.GetComponent<Collider>().enabled = false;
							this.canOpen = true;
						});
						this.Bashou.DORotate(Vector3.zero, 1f, RotateMode.Fast);
					}
					else
					{
						base.StartCoroutine(this.TarTalk(0));
					}
				}
				else if (collider == this.TarCharacter.GetComponent<Collider>())
				{
					if (this.dragTrans == null)
					{
						DialogueManager.StartConversation("牢房前置");
					}
					else if (this.dragTrans == this.Yingbi)
					{
						DialogueManager.StartConversation("牢房硬币");
					}
					else if (this.dragTrans == this.QiaoGun)
					{
						DialogueManager.StartConversation("牢房撬棍");
					}
					else if (this.dragTrans == this.Chuizi)
					{
						DialogueManager.StartConversation("牢房锤子");
					}
					else if (this.dragTrans == this.Bashou)
					{
						DialogueManager.StartConversation("牢房把手");
					}
				}
				else if (collider == this.Men.GetComponent<Collider>())
				{
					if (this.canOpen && this.CheckDeng())
					{
						base.StartCoroutine(this.EndThread());
					}
					else
					{
						base.StartCoroutine(this.TarTalk(0));
					}
				}
				else if (collider == this.Qiang.GetComponent<Collider>())
				{
					if (this.dragTrans == this.Chuizi)
					{
						this.Qiang.gameObject.SetActive(false);
						this.Qiang.position = Vector3.one * 10000f;
					}
					else
					{
						base.StartCoroutine(this.TarTalk(0));
					}
				}
				else if (collider == this.Yingbi.GetComponent<Collider>() && this.isLajitong)
				{
					if (this.Bags.Contains(this.Yingbi.parent))
					{
						this.dragTrans = this.Yingbi;
						this.Yingbi.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一枚普通的硬币，或许也不是那么普通，因为它是方的。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						base.StartCoroutine(this.TarTalk(1));
						return;
					}
					this.Yingbi.SetParent(this.GetEmptyBag());
					this.Yingbi.DOLocalJump(Vector3.zero, 0.1f, 1, 1f, false);
					this.Yingbi.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (collider == this.Chuizi.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.Chuizi.parent))
					{
						this.dragTrans = this.Chuizi;
						this.Chuizi.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一把锤子，很难想象这个东西是怎么带进牢房里来的。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						base.StartCoroutine(this.TarTalk(1));
						return;
					}
					this.Chuizi.SetParent(this.GetEmptyBag());
					this.Chuizi.DOLocalJump(Vector3.zero, 0.1f, 1, 1f, false);
					this.Chuizi.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (collider == this.QiaoGun.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.QiaoGun.parent))
					{
						this.dragTrans = this.QiaoGun;
						this.QiaoGun.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "看似一根铁管，但其实它是一根撬棍，没想到吧？";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						base.StartCoroutine(this.TarTalk(1));
						return;
					}
					this.QiaoGun.SetParent(this.GetEmptyBag());
					this.QiaoGun.DOLocalJump(Vector3.zero, 0.1f, 1, 1f, false);
					this.QiaoGun.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (collider == this.Bashou.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.Bashou.parent))
					{
						this.dragTrans = this.Bashou;
						this.Bashou.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "虽然看起来不知道是什么，但我想应该可以把它安装到什么地方。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						base.StartCoroutine(this.TarTalk(1));
						return;
					}
					this.Bashou.SetParent(this.GetEmptyBag());
					this.Bashou.DOLocalJump(Vector3.zero, 0.1f, 1, 1f, false);
					this.Bashou.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (this.LuosiList.Contains(collider))
				{
					if (this.dragTrans == this.Yingbi)
					{
						collider.gameObject.SetActive(false);
						this.LuosiList.Remove(collider);
					}
					else
					{
						base.StartCoroutine(this.TarTalk(0));
					}
				}
				else if (this.DengList.Contains(collider))
				{
					if (this.dengState[collider])
					{
						collider.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
						this.dengState[collider] = false;
					}
					else
					{
						collider.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
						this.dengState[collider] = true;
					}
					if (this.CheckDeng())
					{
						this.Zhishideng.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					else
					{
						this.Zhishideng.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					}
				}
				if (this.dragTrans != null)
				{
					this.dragTrans.GetComponent<Highlighter>().constant = false;
					this.dragTrans = null;
					this.Tip.text = "";
					this.Tip.transform.parent.parent.gameObject.SetActive(false);
					base.StartCoroutine(this.TarTalk(0));
				}
			}
		}
	}

	private IEnumerator OnLajitongPlay()
	{
		this.Lajitong.GetComponent<Animator>().SetTrigger("play");
		yield return new WaitForSeconds(0.8f);
		this.OnYingbiPush();
		yield break;
	}

	public void OnYingbiPush()
	{
		this.Yingbi.SetParent(this.Parent);
		this.Yingbi.DOLocalJump(new Vector3(0.944f, 0.277f, 0.119f), 0.05f, 3, 1f, false);
		this.Yingbi.DORotate(Vector3.zero, 1f, RotateMode.Fast).OnComplete(delegate
		{
			this.isLajitong = true;
		});
	}

	private void OnXiangziPush()
	{
		this.Xiangzi.DOLocalMoveX(-2.31f, 1f, false).OnComplete(delegate
		{
			this.isXinagzi = true;
		});
	}

	private Transform GetEmptyBag()
	{
		foreach (Transform transform in this.Bags)
		{
			if (transform.childCount == 0)
			{
				return transform;
			}
		}
		return null;
	}

	private void CheckLuosi()
	{
		if (this.LuosiList.Count == 0)
		{
			this.Dianxiang_gai.GetComponent<Animator>().SetTrigger("play");
			foreach (Collider collider in this.DengList)
			{
				collider.gameObject.SetActive(true);
			}
		}
	}

	private bool CheckDeng()
	{
		List<bool> list = new List<bool>(this.dengState.Values);
		for (int i = 0; i < this.dengAnswer.Count; i++)
		{
			if (this.dengAnswer[i] != list[i])
			{
				return false;
			}
		}
		return true;
	}

	private IEnumerator EndThread()
	{
		this.Men.GetComponent<Animator>().SetTrigger("play");
		yield return new WaitForSeconds(2f);
		DialogueManager.StartConversation("密室结束");
		this.TarCharacter.gameObject.SetActive(false);
		PlayerPrefs.SetInt("牢房", 1);
		yield break;
	}

	private IEnumerator TarTalk(int flag = 0)
	{
		if (!this.isTalk)
		{
			this.Talk.transform.parent.parent.gameObject.SetActive(true);
			this.isTalk = true;
			if (flag != 0)
			{
				if (flag == 1)
				{
					this.Talk.text = this.TalkList2[UnityEngine.Random.Range(0, this.TalkList2.Count)];
				}
			}
			else
			{
				this.Talk.text = this.TalkList1[UnityEngine.Random.Range(0, this.TalkList1.Count)];
			}
			yield return new WaitForSeconds(3f);
			this.Talk.transform.parent.parent.gameObject.SetActive(false);
			this.Talk.text = "";
			this.isTalk = false;
		}
		yield break;
	}

	public Transform Parent;

	public List<Transform> Bags;

	public Transform Lajitong;

	private bool isLajitong;

	public Transform Yingbi;

	public List<Collider> LuosiList;

	public Transform Dianxiang_gai;

	public List<Collider> DengList;

	private Dictionary<Collider, bool> dengState = new Dictionary<Collider, bool>();

	private List<bool> dengAnswer = new List<bool>
	{
		false,
		false,
		true,
		false,
		true,
		false,
		false,
		true,
		true
	};

	public Transform Xiangzi;

	private bool isXinagzi;

	public Transform QiaoGun;

	public Transform Bashou;

	public Transform Zhentou;

	private bool isZhenTou;

	public Transform Chuizi;

	public Transform Qiang;

	public Transform MenBashou;

	public Transform Men;

	private bool canOpen;

	public Transform Zhishideng;

	public Transform TarCharacter;

	public TMP_Text Tip;

	public TMP_Text Talk;

	private Transform dragTrans;

	private List<string> TalkList1 = new List<string>
	{
		"垃圾！",
		"菜！",
		"错的！",
		"不对！",
		"用点子智慧！",
		"Noob！",
		"啧啧~",
		"唉~"
	};

	private List<string> TalkList2 = new List<string>
	{
		"好好看！",
		"好好学！",
		"睁大眼睛！",
		"看清楚了！",
		"这都不知道？"
	};

	private bool isTalk;
}
