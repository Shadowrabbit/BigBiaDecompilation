using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenePoopQTEController : MonoBehaviour
{
	private void Start()
	{
		this.PoopCharacter.Rebind();
		base.StartCoroutine("Recovery");
		base.StartCoroutine("FullPreYield");
		this.Shits = new List<Transform>();
		this.QTEClickBgList = new List<Transform>();
		for (int i = 0; i < this.QTEClickPanel.childCount; i++)
		{
			this.QTEClickBgList.Add(this.QTEClickPanel.GetChild(i));
		}
	}

	private void StartQTEClick()
	{
		this.isStartGame = true;
		this.isClick = true;
		this.QTEClickGo.SetActive(true);
		this.isMove = true;
		List<int> indexs = new List<int>();
		this.ProduceShit();
		this.ClearColor();
		if (this.round < 6)
		{
			for (int i = (int)((float)this.QTEClickBgList.Count * 0.5f); i >= 0; i--)
			{
				int index = this.GetIndex(indexs, this.QTEClickBgList.Count);
				this.QTEClickBgList[index].GetComponent<Image>().color = new Color(0.99f, 0.32f, 0.37f);
			}
			for (int j = (int)((float)this.QTEClickBgList.Count * 0.1f); j >= 0; j--)
			{
				int index2 = this.GetIndex(indexs, this.QTEClickBgList.Count);
				this.QTEClickBgList[index2].GetComponent<Image>().color = new Color(0.36f, 0.86f, 0.29f);
			}
			return;
		}
		for (int k = (int)((float)this.QTEClickBgList.Count * 0.1f); k >= 0; k--)
		{
			int index3 = this.GetIndex(indexs, this.QTEClickBgList.Count);
			this.QTEClickBgList[index3].GetComponent<Image>().color = new Color(0.36f, 0.86f, 0.29f);
		}
		for (int l = (int)((float)this.QTEClickBgList.Count * 0.1f); l >= 0; l--)
		{
			int index4 = this.GetIndex(indexs, this.QTEClickBgList.Count);
			this.QTEClickBgList[index4].GetComponent<Image>().color = new Color(0.99f, 0.32f, 0.37f);
		}
		for (int m = (int)((float)this.QTEClickBgList.Count * 0.2f); m >= 0; m--)
		{
			int index5 = this.GetIndex(indexs, this.QTEClickBgList.Count);
			this.QTEClickBgList[index5].GetComponent<Image>().color = new Color(0.32f, 0.41f, 0.8f);
		}
	}

	private IEnumerator EndRound(float yie)
	{
		if (yie > 0f)
		{
			this.CheckEnd();
		}
		yield return new WaitForSeconds(yie);
		if (this.round < 6)
		{
			this.round++;
			this.StartQTEClick();
		}
		else
		{
			if (this.isStay)
			{
				yield break;
			}
			this.time = 0f;
			this.round = 1;
			this.isClick = false;
			this.QTEClickGo.SetActive(false);
			Debug.Log("输出结束！");
			this.ReleaseShit();
		}
		yield break;
	}

	private void CheckEnd()
	{
		foreach (Transform transform in this.QTEClickBgList)
		{
			if (transform.position.x - transform.GetComponent<RectTransform>().rect.width / 2f < this.QTEClickIndex.position.x && transform.position.x + transform.GetComponent<RectTransform>().rect.width / 2f > this.QTEClickIndex.position.x)
			{
				if (transform.GetComponent<Image>().color == new Color(0.36f, 0.86f, 0.29f))
				{
					this.QTEClickTipText.text = "分流成功！";
					this.ReleaseShit();
				}
				else if (transform.GetComponent<Image>().color == new Color(0.99f, 0.32f, 0.37f))
				{
					base.StopCoroutine("EndRound");
					this.QTEClickTipText.text = "全体起立！";
					this.m_Cle = ((this.m_Cle - (6 - this.round) * 5 > 0) ? (this.m_Cle - (6 - this.round) * 5) : 0);
					this.time = 0f;
					this.round = 1;
					this.isClick = false;
					this.ReleaseShit();
					base.StartCoroutine("StandUp");
					this.PoopCharacter.SetTrigger("up");
					this.AudioManager.clip = this.AudioClips[UnityEngine.Random.Range(0, 4)];
					this.AudioManager.Play();
				}
				else if (transform.GetComponent<Image>().color == new Color(0.32f, 0.41f, 0.8f))
				{
					this.QTEClickTipText.text = "开冲！";
					base.StopCoroutine("EndRound");
					this.time = 0f;
					this.round = 1;
					this.isClick = false;
					base.StartCoroutine("StartStay");
					this.AudioManager.clip = this.AudioClips[8];
					this.AudioManager.Play();
				}
				else
				{
					this.QTEClickTipText.text = "糟糕！";
				}
			}
		}
	}

	private int GetIndex(List<int> indexs, int value)
	{
		int num = UnityEngine.Random.Range(1, value);
		while (indexs.Contains(num))
		{
			num = UnityEngine.Random.Range(1, value);
		}
		indexs.Add(num);
		return num;
	}

	private IEnumerator StandUp()
	{
		yield return new WaitForSeconds(1f);
		this.QTEClickGo.SetActive(false);
		yield break;
	}

	private void ClearColor()
	{
		this.QTEClickTipText.text = "";
		this.clickStartX = -445.8f;
		this.clickEndX = 445.6f;
		this.QTEClickIndex.localPosition = new Vector3(this.clickStartX, 0f, 0f);
		this.time = 0f;
		foreach (Transform transform in this.QTEClickBgList)
		{
			transform.GetComponent<Image>().color = Color.white;
		}
	}

	private void FixedUpdate()
	{
		if (this.isStay)
		{
			float num = Mathf.Lerp(this.stayOldManCurrentX, this.stayOldManEndX, this.time / (this.stayOldManMoveSpeed * 10f) * (0.1f * (float)this.QTEClickIndexSpeed));
			if (num == this.stayOldManEndX)
			{
				float num2 = this.stayOldManEndX;
				this.stayOldManCurrentX = num2;
				this.stayOldManEndX = UnityEngine.Random.Range(this.stayOldManMinX, this.stayOldManMaxX);
				this.stayOldManMoveSpeed = (float)UnityEngine.Random.Range(10, 15);
				this.time = 0f;
				this.AudioManager.clip = this.AudioClips[7];
				this.AudioManager.Play();
			}
			if (this.stayOldManEndX > this.stayOldManCurrentX)
			{
				this.OldMan.GetComponent<Animator>().SetFloat("Direct", 1f);
			}
			else
			{
				this.OldMan.GetComponent<Animator>().SetFloat("Direct", 0f);
			}
			this.OldMan.localPosition = new Vector3(num, 0f, 0f);
			if (Input.GetMouseButton(0))
			{
				this.canSlow = true;
				if (this.QTEStayGround.localPosition.x > this.stayGroundStartX)
				{
					this.dir = new Vector3(-1f, 0f, 0f);
					this.QTEStayGround.localPosition += this.dir * this.stayGroundMoveSpeed;
				}
				else
				{
					this.canSlow = false;
				}
				if (this.stayGroundMoveSpeed < 10f)
				{
					this.stayGroundMoveSpeed += 0.1f;
				}
			}
			else if (Input.GetMouseButton(1))
			{
				this.canSlow = true;
				if (this.QTEStayGround.localPosition.x < this.stayGroundEndX)
				{
					this.dir = new Vector3(1f, 0f, 0f);
					this.QTEStayGround.localPosition += this.dir * this.stayGroundMoveSpeed;
				}
				else
				{
					this.canSlow = false;
				}
				if (this.stayGroundMoveSpeed < 10f)
				{
					this.stayGroundMoveSpeed += 0.1f;
				}
			}
			else
			{
				if (this.stayGroundMoveSpeed > 0f && this.canSlow && this.QTEStayGround.localPosition.x > this.stayGroundStartX && this.QTEStayGround.localPosition.x < this.stayGroundEndX)
				{
					if (this.stayGroundMoveSpeed > 0.2f)
					{
						this.stayGroundMoveSpeed -= 0.2f;
					}
					else
					{
						this.stayGroundMoveSpeed -= 0.1f;
					}
				}
				else
				{
					this.stayGroundMoveSpeed = 0f;
				}
				this.QTEStayGround.localPosition += this.dir * this.stayGroundMoveSpeed;
			}
			if (this.OldMan.position.x + this.OldMan.GetComponent<RectTransform>().rect.width / 2f < this.QTEStayGround.position.x - this.QTEStayGround.GetComponent<RectTransform>().rect.width / 2f || this.OldMan.position.x - this.OldMan.GetComponent<RectTransform>().rect.width / 2f > this.QTEStayGround.position.x + this.QTEStayGround.GetComponent<RectTransform>().rect.width / 2f)
			{
				this.isStay = false;
				base.StopCoroutine("HoldOnYield");
				this.AudioManager.clip = this.AudioClips[9];
				this.AudioManager.Play();
				this.OldMan.DOLocalJump(new Vector3(this.OldMan.localPosition.x, -569f, 0f), 0.3f, 1, 1f, false).OnComplete(delegate
				{
					Debug.Log("持续结束！");
					this.QTEStayGo.SetActive(false);
					this.isStayEnd = true;
					this.ReleaseShit();
				});
			}
		}
		this.time += 1f;
		if (!this.isMove)
		{
			return;
		}
		if (this.isClick)
		{
			float num3 = Mathf.Lerp(this.clickStartX, this.clickEndX, this.time / 80f * (0.1f * (float)this.QTEClickIndexSpeed));
			if (num3 == this.clickEndX)
			{
				float num4 = this.clickStartX;
				this.clickStartX = this.clickEndX;
				this.clickEndX = num4;
				this.time = 0f;
				if (this.isBack)
				{
					this.isMove = false;
					this.isBack = false;
					base.StartCoroutine("EndRound", 0);
					return;
				}
				this.isBack = true;
			}
			this.QTEClickIndex.localPosition = new Vector3(num3, 0f, 0f);
		}
	}

	private void Update()
	{
		this.Hap_Text.text = (this.m_Hap.ToString() ?? "");
		this.Hap_Image.fillAmount = (float)this.m_Hap / 100f;
		this.Cle_Text.text = (this.m_Cle.ToString() ?? "");
		this.Cle_Image.fillAmount = (float)this.m_Cle / 100f;
		this.Str_Text.text = (((int)this.m_Str).ToString() ?? "");
		this.Str_Image.fillAmount = this.m_Str / 10f;
		this.Pre_Text.text = (this.m_Pre.ToString() ?? "");
		this.Pre_Image.fillAmount = (float)this.m_Pre / 100f;
		if (this.m_Pre <= 100 && this.m_Pre > 60)
		{
			this.Pre_Image.color = new Color(0.77f, 0f, 0.13f);
		}
		else if (this.m_Pre <= 60 && this.m_Pre > 30)
		{
			this.Pre_Image.color = new Color(0.94f, 0.95f, 0f);
		}
		else if (this.m_Pre <= 30 && this.m_Pre > 0)
		{
			this.Pre_Image.color = new Color(0.06f, 0.95f, 0f);
		}
		if (this.isGameOver)
		{
			return;
		}
		if (this.m_Pre == 100 && !this.isClick && !this.isStay)
		{
			this.isFullPre = true;
		}
		else
		{
			this.isFullPre = false;
		}
		if (this.isClick)
		{
			if (Input.GetMouseButtonDown(0))
			{
				this.isMove = false;
				this.isBack = false;
				this.AudioManager.clip = this.AudioClips[10];
				this.AudioManager.Play();
				base.StartCoroutine("EndRound", 0.5f);
			}
		}
		else if (Input.GetMouseButtonDown(1) && !this.isStay && this.isStayEnd)
		{
			if (this.IsHand)
			{
				base.StartCoroutine("HandYield");
			}
			else if (!this.IsHand && this.isHandOver)
			{
				this.round = 1;
				this.StartQTEClick();
			}
		}
		bool flag = this.isStay;
	}

	private IEnumerator StartStay()
	{
		this.isStayEnd = false;
		this.stayOldManCurrentX = 0f;
		this.stayOldManEndX = 0f;
		this.OldMan.localPosition = new Vector3(0f, 11.1f, 0f);
		this.QTEStayGround.localPosition = new Vector3(0f, -52f, 0f);
		yield return new WaitForSeconds(1f);
		this.QTEClickGo.SetActive(false);
		this.QTEStayGo.SetActive(true);
		this.isStay = true;
		this.time = 0f;
		this.stayOldManEndX = UnityEngine.Random.Range(this.stayOldManMinX, this.stayOldManMaxX);
		this.stayOldManMoveSpeed = (float)UnityEngine.Random.Range(10, 15);
		base.StartCoroutine("HoldOnYield");
		yield break;
	}

	private IEnumerator HoldOnYield()
	{
		while (this.isStay)
		{
			yield return new WaitForSeconds(3f);
			if (this.m_Str > 0f)
			{
				this.ProduceShit();
				this.m_Str -= 1f;
			}
		}
		yield break;
	}

	private void ProduceShit()
	{
		this.PoopCharacter.SetTrigger("startHold");
		if (this.Shits.Count > 0)
		{
			for (int i = 0; i < this.Shits.Count; i++)
			{
				this.Shits[i].DOMoveY(this.Shits[i].position.y - 0.3f, 0.1f, false);
			}
		}
		Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Shit);
		transform.position = new Vector3(2.4f, 5.11f, -0.29f);
		this.Shits.Add(transform);
		this.AudioManager.clip = this.AudioClips[4];
		this.AudioManager.Play();
	}

	private void ReleaseShit()
	{
		this.AudioManager.clip = this.AudioClips[5];
		this.AudioManager.Play();
		foreach (Transform transform in this.Shits)
		{
			transform.gameObject.AddComponent<Rigidbody>();
			UnityEngine.Object.Destroy(transform.gameObject, 2f);
		}
		if (this.Shits.Count > 0)
		{
			if (this.Shits.Count < 7)
			{
				this.m_Hap = ((this.m_Hap - (this.Shits.Count - 1) * 5 > 0) ? (this.m_Hap - (-1 + this.Shits.Count) * 5) : 0);
				this.m_Cle = ((this.m_Cle - (this.Shits.Count - 1) * 5 > 0) ? (this.m_Cle - (-1 + this.Shits.Count) * 5) : 0);
				if (-1 + this.Shits.Count > 0)
				{
					this.Water.WaterCount = this.Shits.Count - 1;
				}
				else
				{
					this.Water.WaterCount = 0;
				}
			}
			else
			{
				this.m_Hap = ((this.m_Hap - (25 - (this.Shits.Count - 6) * 5) > 0) ? ((this.m_Hap - (25 - (this.Shits.Count - 6) * 5) > 100) ? 100 : (this.m_Hap - (25 - (this.Shits.Count - 6) * 5))) : 0);
				this.m_Cle = ((this.m_Cle - (25 - (this.Shits.Count - 6) * 5) > 0) ? ((this.m_Cle - (25 - (this.Shits.Count - 6) * 5) > 100) ? 100 : (this.m_Cle - (25 - (this.Shits.Count - 6) * 5))) : 0);
				if (25 - (this.Shits.Count - 6) * 5 > 0)
				{
					this.Water.WaterCount = (25 - (this.Shits.Count - 6) * 5) / 5;
				}
				else
				{
					this.Water.WaterCount = 0;
				}
			}
		}
		if (this.m_Hap <= 0)
		{
			this.GameOverTip.text = "猝于心情低落";
			this.GameOver.SetActive(true);
			this.isGameOver = true;
			return;
		}
		if (this.m_Cle <= 0)
		{
			this.GameOverTip.text = "猝于清洁过低";
			this.GameOver.SetActive(true);
			this.isGameOver = true;
			return;
		}
		this.m_Pre = ((this.m_Pre - 2 * this.Shits.Count > 0) ? (this.m_Pre - 2 * this.Shits.Count) : 0);
		if (this.m_Pre <= 0)
		{
			Debug.Log("############### 恭喜通关！###############");
			this.GameWin.SetActive(true);
			this.isGameOver = true;
			return;
		}
		this.PoopCharacter.Rebind();
		this.Shits = new List<Transform>();
	}

	private IEnumerator Recovery()
	{
		for (;;)
		{
			if (!this.isStay && !this.isClick && !this.IsHand && this.isHandOver)
			{
				yield return new WaitForSeconds(1f);
				this.m_Pre = ((this.m_Pre + 1 > 100) ? 100 : (this.m_Pre + 1));
				this.m_Str = ((this.m_Str + 0.2f > 10f) ? 10f : (this.m_Str + 0.2f));
			}
			yield return 1;
		}
		yield break;
	}

	private IEnumerator RandomAnimation()
	{
		for (;;)
		{
			if (!this.isStay && !this.isClick)
			{
				this.PoopCharacter.SetTrigger("move");
				yield return new WaitForSeconds((float)UnityEngine.Random.Range(5, 10));
			}
			yield return 1;
		}
		yield break;
	}

	private IEnumerator FullPreYield()
	{
		for (;;)
		{
			if (this.isFullPre && this.isStartGame && !this.isStay && !this.isClick && !this.IsHand && this.isHandOver)
			{
				this.m_Hap = ((this.m_Hap - 1 > 0) ? (this.m_Hap - 1) : 0);
				yield return new WaitForSeconds(1f);
				if (this.m_Hap <= 0)
				{
					break;
				}
			}
			yield return 1;
		}
		this.GameOverTip.text = "猝于心情低落";
		this.GameOver.SetActive(true);
		this.isGameOver = true;
		yield break;
		yield break;
	}

	private IEnumerator HandYield()
	{
		this.IsHand = false;
		this.isHandOver = false;
		int num;
		for (int i = 0; i < 6; i = num + 1)
		{
			this.ProduceShit();
			yield return new WaitForSeconds(0.5f);
			num = i;
		}
		yield return new WaitForSeconds(1f);
		foreach (Transform transform in this.Shits)
		{
			transform.SetParent(this.Hand.transform);
			transform.gameObject.AddComponent<Rigidbody>();
			UnityEngine.Object.Destroy(transform.gameObject, 5f);
		}
		this.PoopCharacter.SetTrigger("endHold");
		this.m_Pre = ((this.m_Pre - 12 > 0) ? (this.m_Pre - 12) : 0);
		yield return new WaitForSeconds(3f);
		this.Hand.transform.DOLocalMove(new Vector3(9.88f, 3.68f, -12.7f), 1f, false);
		this.PoopCharacter.Rebind();
		this.PoopCharacter.SetTrigger("take");
		this.HandShit.SetActive(true);
		yield return new WaitForSeconds(4f);
		this.HandShit.SetActive(false);
		yield return new WaitForSeconds(1f);
		this.Shits = new List<Transform>();
		this.m_Hap = ((this.m_Hap - 30 > 0) ? (this.m_Hap - 30) : 0);
		if (this.m_Hap <= 0)
		{
			this.GameOverTip.text = "这触感，这色泽，就是这个味儿！";
			this.isGameOver = true;
			this.GameOver.SetActive(true);
		}
		this.isHandOver = true;
		yield break;
	}

	public void OnHand()
	{
		if (this.isStay || this.isClick || !this.isStayEnd)
		{
			return;
		}
		if (!this.IsHand)
		{
			this.AudioManager.clip = this.AudioClips[6];
			this.AudioManager.Play();
			this.IsHand = true;
			this.Hand.transform.DOLocalMove(new Vector3(5.48f, 3.68f, -5.47f), 1f, false).OnComplete(delegate
			{
				this.HandImage.color = Color.green;
				this.Hand.SetTrigger("open");
			});
			return;
		}
		this.IsHand = false;
		this.Hand.transform.DOLocalMove(new Vector3(9.88f, 3.68f, -12.7f), 1f, false).OnComplete(delegate
		{
			this.HandImage.color = Color.red;
			this.Hand.Rebind();
		});
	}

	public GameObject QTEClickGo;

	public RectTransform QTEClickIndex;

	public RectTransform QTEClickPanel;

	[Range(1f, 10f)]
	public int QTEClickIndexSpeed = 1;

	public TMP_Text QTEClickTipText;

	private List<Transform> QTEClickBgList = new List<Transform>();

	private bool isMove;

	private bool isBack;

	private float clickStartX = -445.8f;

	private float clickEndX = 445.6f;

	private float time;

	private int round = 1;

	private bool isClick;

	public GameObject QTEStayGo;

	public Transform QTEStayGround;

	public Transform OldMan;

	private float stayGroundStartX = -390f;

	private float stayGroundEndX = 390f;

	private float stayOldManMinX = -464f;

	private float stayOldManMaxX = 464f;

	private float stayOldManCurrentX;

	private float stayOldManEndX;

	private float stayOldManMoveSpeed;

	public float stayGroundMoveSpeed;

	private Vector3 dir = Vector3.zero;

	private bool isStay;

	private bool isStayEnd = true;

	public Transform Shit;

	private List<Transform> Shits;

	public Animator PoopCharacter;

	public ScenePoopWater Water;

	public GameObject GameOver;

	public TMP_Text GameOverTip;

	public GameObject GameWin;

	public Image HandImage;

	public AudioSource AudioManager;

	public List<AudioClip> AudioClips;

	private int m_Hap = 100;

	private float m_Str = 10f;

	private int m_Cle = 100;

	private int m_Pre = 100;

	public TMP_Text Hap_Text;

	public TMP_Text Cle_Text;

	public TMP_Text Str_Text;

	public TMP_Text Pre_Text;

	public Image Hap_Image;

	public Image Cle_Image;

	public Image Str_Image;

	public Image Pre_Image;

	public bool IsHand;

	private bool isStartGame;

	private bool canSlow = true;

	private bool isFullPre;

	private bool isHandOver = true;

	public GameObject HandShit;

	private bool isGameOver;

	public Animator Hand;
}
