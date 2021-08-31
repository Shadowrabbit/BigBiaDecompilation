using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BossCSLArea : MonoBehaviour
{
	private void Start()
	{
		BGMusicManager.Instance.PlayBGMusic(3, 0, null);
		this.Board.GetComponent<Animator>().speed = 0f;
		this.Boss.SetActive(false);
		this.OldEyeColor = this.CTLeMaterial.GetColor("_EmissionColor");
	}

	private void Update()
	{
		RaycastHit raycastHit;
		if (!this.isStart && Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && raycastHit.collider == this.StartButton)
		{
			this.isStart = true;
			base.StartCoroutine(this.BossApear());
		}
	}

	private IEnumerator BossApear()
	{
		BGMusicManager.Instance.PlayBGMusic(5, 0, null);
		this.Boss.SetActive(true);
		this.Board.GetComponent<Animator>().speed = 1f;
		this.Boss.GetComponent<Animator>().SetTrigger("Apear");
		base.StartCoroutine(Camera.main.GetComponent<CameraEffect>().ShowBoss());
		Camera.main.GetComponent<CameraEffect>().NameText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_N_克总");
		Camera.main.GetComponent<CameraEffect>().DescText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_D_克总");
		Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
		Vector3 oriPos = Camera.main.transform.position;
		Quaternion oriRot = Camera.main.transform.rotation;
		int num;
		for (int i = 0; i < 120; i = num + 1)
		{
			if (i == 20)
			{
				this.Board.SetActive(false);
			}
			Camera.main.transform.LookAt(this.CameraAim, Vector3.up);
			if (i == 50)
			{
				Time.timeScale = 0.3f;
			}
			if (i == 90)
			{
				Time.timeScale = 1f;
			}
			yield return new WaitForSeconds(0.016666668f);
			num = i;
		}
		Camera.main.transform.DOMove(oriPos, 0.2f, false);
		Camera.main.transform.DORotateQuaternion(oriRot, 0.2f);
		yield return null;
		this.Boss.transform.localPosition = new Vector3(1.67f, this.Boss.transform.localPosition.y, this.Boss.transform.localPosition.z);
		this.InitCard();
		yield break;
	}

	private void InitCard()
	{
		CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("克苏鲁"), true);
		cardData.PutInSlotData(DungeonOperationMgr.Instance.BattleArea[1], true);
		this.BossCard = cardData;
		for (int i = cardData.CardLogics.Count - 1; i >= 0; i--)
		{
			GameController.getInstance().StartCoroutine(cardData.CardLogics[i].OnEnterArea("BossCthulhu"));
		}
		DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.StartBattle(false));
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志3"), null, null, null, null, null, null));
	}

	public Collider StartButton;

	public GameObject Boss;

	public GameObject Board;

	public Transform CameraAim;

	private bool isStart;

	public CardSlot CardSlot;

	public CardData BossCard;

	public Material CTLeMaterial;

	public Color OldEyeColor;
}
