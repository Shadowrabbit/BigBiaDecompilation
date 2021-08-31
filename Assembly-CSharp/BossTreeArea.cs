using System;
using System.Collections;
using UnityEngine;

public class BossTreeArea : MonoBehaviour
{
	private void Start()
	{
		this.Boss.SetActive(false);
		base.StartCoroutine(this.BossApear());
	}

	private void Update()
	{
	}

	private IEnumerator BossApear()
	{
		BGMusicManager.Instance.PlayBGMusic(19, 0, null);
		yield return new WaitForSeconds(1f);
		this.Boss.SetActive(true);
		base.StartCoroutine(Camera.main.GetComponent<CameraEffect>().ShowBoss());
		Camera.main.GetComponent<CameraEffect>().NameText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_N_树");
		Camera.main.GetComponent<CameraEffect>().DescText.text = LocalizationMgr.Instance.GetLocalizationWord("BOSS_D_树");
		Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
		yield return null;
		this.InitCard();
		yield break;
	}

	private void InitCard()
	{
		CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("BossTreeCard"), true);
		cardData.PutInSlotData(DungeonOperationMgr.Instance.BattleArea[1], true);
		for (int i = cardData.CardLogics.Count - 1; i >= 0; i--)
		{
			GameController.getInstance().StartCoroutine(cardData.CardLogics[i].OnEnterArea("BossTree"));
		}
		DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.StartBattle(false));
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志5"), null, null, null, null, null, null));
	}

	public Collider StartButton;

	public GameObject Boss;

	public Transform CameraAim;

	private bool isStart;

	public CardSlot CardSlot;
}
