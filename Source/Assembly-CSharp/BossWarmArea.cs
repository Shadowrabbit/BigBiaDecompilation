using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class BossWarmArea : MonoBehaviour
{
	private void Start()
	{
		BGMusicManager.Instance.PlayBGMusic(3, 0, null);
		this.OldEyeColor = this.WarmEyeMaterial.GetColor("_EmissionColor");
		base.StartCoroutine(this.StartApear());
	}

	private IEnumerator StartApear()
	{
		yield return new WaitForSeconds(1f);
		yield return this.BossApear();
		yield break;
	}

	private IEnumerator BossApear()
	{
		BGMusicManager.Instance.PlayBGMusic(4, 0, null);
		this.Boss.SetActive(true);
		this.Boss.GetComponent<Animator>().SetTrigger("Apear");
		this.BossEye.GetComponent<Animator>().SetTrigger("Apear");
		base.StartCoroutine(Camera.main.GetComponent<CameraEffect>().ShowBoss());
		Vector3 oriPos = Camera.main.transform.position;
		Quaternion oriRot = Camera.main.transform.rotation;
		Vector3 endValue = new Vector3(0f, -14.44136f, 7.151902f);
		Vector3 endValue2 = new Vector3(-51.106f, 0f, 0f);
		DOTween.Sequence();
		Camera.main.transform.DOLocalMove(endValue, 1f, false);
		yield return Camera.main.transform.DOLocalRotate(endValue2, 1f, RotateMode.Fast).WaitForCompletion();
		yield return new WaitForSeconds(1f);
		Camera.main.GetComponent<CameraEffect>().NameText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_N_白胖");
		Camera.main.GetComponent<CameraEffect>().DescText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_D_白胖");
		Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
		Time.timeScale = 0.2f;
		yield return new WaitForSeconds(0.5f);
		Time.timeScale = 1f;
		Camera.main.transform.DOMove(oriPos, 1f, false);
		Camera.main.transform.DORotateQuaternion(oriRot, 1f);
		yield return null;
		this.InitCard();
		yield break;
	}

	private void InitCard()
	{
		CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("BossWormCard"), true);
		cardData.PutInSlotData(DungeonOperationMgr.Instance.BattleArea[1], true);
		for (int i = cardData.CardLogics.Count - 1; i >= 0; i--)
		{
			GameController.getInstance().StartCoroutine(cardData.CardLogics[i].OnEnterArea("BossWorm"));
		}
		DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.StartBattle(false));
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志28"), null, null, null, null, null, null));
	}

	private IEnumerator AttackShuPen()
	{
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/大虫子攻击", 0.5f);
			particleObject.transform.position = this.CardSlot.transform.position;
			Vector3 tarPos = DungeonOperationMgr.Instance.PlayerBattleArea[8].CardSlotGameObject.transform.position;
			tarPos = new Vector3(tarPos.x, tarPos.y, tarPos.z + 0.5f);
			tarPos = new Vector3(tarPos.x, tarPos.y, tarPos.z - (float)(3 * i) / 10f);
			particleObject.transform.DOMove(tarPos, 0.5f, false).OnComplete(delegate
			{
				ParticlePoolManager.Instance.Spawn("Effect/大虫子命中", 2f).transform.position = tarPos;
			});
			yield return new WaitForSeconds(0.05f);
			num = i;
		}
		yield return null;
		yield break;
	}

	private IEnumerator AttackHengPen()
	{
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/大虫子攻击", 0.5f);
			particleObject.transform.position = this.CardSlot.transform.position;
			Vector3 tarPos = DungeonOperationMgr.Instance.PlayerBattleArea[5].CardSlotGameObject.transform.position;
			tarPos = new Vector3(tarPos.x + 0.5f, tarPos.y, tarPos.z);
			tarPos = new Vector3(tarPos.x - (float)(3 * i) / 10f, tarPos.y, tarPos.z);
			particleObject.transform.DOMove(tarPos, 0.5f, false).OnComplete(delegate
			{
				ParticlePoolManager.Instance.Spawn("Effect/大虫子命中", 2f).transform.position = tarPos;
			});
			yield return new WaitForSeconds(0.05f);
			num = i;
		}
		yield return null;
		yield break;
	}

	public GameObject Boss;

	public GameObject BossEye;

	private bool isStart;

	public CardSlot CardSlot;

	public Material WarmEyeMaterial;

	public Color OldEyeColor;
}
