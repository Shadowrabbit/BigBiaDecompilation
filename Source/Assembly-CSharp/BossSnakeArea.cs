using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossSnakeArea : MonoBehaviour
{
	private void Start()
	{
		BGMusicManager.Instance.PlayBGMusic(3, 0, null);
		this.OldEyeColor = this.SnakeEyeMaterial.GetColor("_EmissionColor");
	}

	private void Update()
	{
		RaycastHit raycastHit;
		if (!this.isStart && Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && raycastHit.collider == this.StartButton)
		{
			this.isStart = true;
			this.StartTip.SetActive(false);
			base.StartCoroutine(this.BossApear());
		}
	}

	private IEnumerator BossApear()
	{
		BGMusicManager.Instance.PlayBGMusic(4, 0, null);
		this.Boss.SetActive(true);
		this.Boss.GetComponent<Animator>().SetTrigger("Apear");
		base.StartCoroutine(Camera.main.GetComponent<CameraEffect>().ShowBoss());
		Vector3 oriPos = Camera.main.transform.position;
		Quaternion oriRot = Camera.main.transform.rotation;
		Vector3 endValue = new Vector3(0f, -14.44136f, 7.151902f);
		Vector3 endValue2 = new Vector3(-51.106f, 0f, 0f);
		DOTween.Sequence();
		Camera.main.transform.DOLocalMove(endValue, 1f, false);
		yield return Camera.main.transform.DOLocalRotate(endValue2, 1f, RotateMode.Fast).WaitForCompletion();
		yield return new WaitForSeconds(7f);
		if (GameController.ins.GameData.Agreenment < 4)
		{
			Camera.main.GetComponent<CameraEffect>().NameText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_N_蛇1");
			Camera.main.GetComponent<CameraEffect>().DescText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_D_蛇1");
		}
		else if (GameController.ins.GameData.Agreenment >= 4 && GameController.ins.GameData.Agreenment < 7)
		{
			Camera.main.GetComponent<CameraEffect>().NameText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_N_蛇2");
			Camera.main.GetComponent<CameraEffect>().DescText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_D_蛇2");
		}
		else if (GameController.ins.GameData.Agreenment >= 7)
		{
			Camera.main.GetComponent<CameraEffect>().NameText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_N_蛇3");
			Camera.main.GetComponent<CameraEffect>().DescText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_D_蛇3");
		}
		Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
		Time.timeScale = 0.2f;
		yield return new WaitForSeconds(0.5f);
		Time.timeScale = 1f;
		Camera.main.transform.DOMove(oriPos, 1f, false);
		Camera.main.transform.DORotateQuaternion(oriRot, 1f);
		yield return new WaitForSeconds(1f);
		this.FadeBone1.material = this.FadeMaterial;
		this.FadeBone2.material = this.FadeMaterial;
		this.FadeBone3.material = this.FadeMaterial;
		yield return this.FadeMaterial.DOColor(new Color32(106, 38, 38, 13), 1f).WaitForCompletion();
		yield return null;
		this.InitCard();
		yield break;
	}

	private void InitCard()
	{
		CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("BossSnakeCard"), true);
		cardData.PutInSlotData(DungeonOperationMgr.Instance.BattleArea[1], true);
		for (int i = cardData.CardLogics.Count - 1; i >= 0; i--)
		{
			GameController.getInstance().StartCoroutine(cardData.CardLogics[i].OnEnterArea("BossSnake"));
		}
		DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.StartBattle(false));
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志4"), null, null, null, null, null, null));
	}

	public Collider StartButton;

	public GameObject Boss;

	public GameObject Board;

	public Transform CameraAim;

	public List<GameObject> BossObjs;

	private bool isStart;

	public CardSlot CardSlot;

	public GameObject StartTip;

	public SkinnedMeshRenderer FadeBone1;

	public SkinnedMeshRenderer FadeBone2;

	public SkinnedMeshRenderer FadeBone3;

	public Material FadeMaterial;

	public Material SnakeEyeMaterial;

	public Color OldEyeColor;
}
