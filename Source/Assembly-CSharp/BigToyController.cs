using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BigToyController : MonoBehaviour
{
	private void Start()
	{
		this.AnimatorGO[UnityEngine.Random.Range(0, this.AnimatorGO.Count)].SetActive(true);
		this.ShowNiuDan();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (UIController.LockLevel == UIController.UILevel.All)
			{
				return;
			}
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null && this.Buildings.Contains(raycastHit.collider.transform))
			{
				if (raycastHit.collider.transform.name.Equals("地下城生成器5") && UIController.LockLevel != UIController.UILevel.All)
				{
					EffectAudioManager.Instance.PlayEffectAudio(8, null);
					GameController.ins.UIController.ShowBlackMask(delegate
					{
						AreaData areaData = GameController.getInstance().GameData.AreaMap["英雄之家"];
						areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
						GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
						GameController.getInstance().OnTableChange(areaData, true);
						BGMusicManager.Instance.PlayBGMusic(3, 0, null);
					}, 0.5f);
				}
				if (raycastHit.collider.transform.name.Equals("图鉴") && UIController.LockLevel != UIController.UILevel.All)
				{
					EffectAudioManager.Instance.PlayEffectAudio(8, null);
					GameController.ins.UIController.ShowBlackMask(delegate
					{
						AreaData areaData = GameController.getInstance().GameData.AreaMap["图鉴"];
						areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
						GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
						GameController.getInstance().OnTableChange(areaData, true);
					}, 0.5f);
				}
				if (raycastHit.collider.transform.name.Equals("英雄之家") && UIController.LockLevel != UIController.UILevel.All)
				{
					EffectAudioManager.Instance.PlayEffectAudio(8, null);
					GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("UI/Canvas/HeroHome")) as GameObject;
					gameObject.transform.SetParent(Camera.main.transform);
					gameObject.transform.localPosition = new Vector3(0f, 0.1f, 4.92f);
					gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				}
				if (raycastHit.collider.transform.name.Equals("祝福小屋") && UIController.LockLevel != UIController.UILevel.All)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("UI/Canvas/ShangDianJieSuoCanvas")) as GameObject;
					gameObject2.transform.SetParent(Camera.main.transform);
					gameObject2.transform.localPosition = new Vector3(0f, 0.1f, 4.92f);
					gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				}
				if (raycastHit.collider.transform.name.Equals("祝福小屋退出"))
				{
					UIController.UILevel lockLevel = UIController.LockLevel;
				}
				if (raycastHit.collider.transform.name.Equals("扭蛋机") && UIController.LockLevel != UIController.UILevel.All)
				{
					if (this.m_IsRoll)
					{
						return;
					}
					if (GlobalController.Instance.GlobalData.TwistedEggCoupon <= 0)
					{
						GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_3"), 1f, 2f, 1f, 1f);
						return;
					}
					EffectAudioManager.Instance.PlayEffectAudio(8, null);
					raycastHit.collider.transform.GetComponent<BigToy>().BigToyTitle.hide();
					base.StartCoroutine(this.NiuDanCorotine(raycastHit.collider.gameObject));
				}
				if (raycastHit.collider.transform.name.Equals("冒险碑") && UIController.LockLevel != UIController.UILevel.All)
				{
					EffectAudioManager.Instance.PlayEffectAudio(8, null);
					UIController.LockLevel = UIController.UILevel.All;
					GameController.ins.UIController.ShowBlackMask(delegate
					{
						UnityEngine.Object.Instantiate(Resources.Load("UI/Canvas/NewLogCanvas"));
					}, 0.5f);
					raycastHit.collider.transform.GetComponent<BigToy>().BigToyTitle.hide();
				}
				if (raycastHit.collider.transform.name.Equals("挂壁人") && UIController.LockLevel != UIController.UILevel.All)
				{
					SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_guabiren);
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_18"), 1f, 2f, 1f, 1f);
				}
				if (raycastHit.collider.transform.name.Equals("玩具箱") && UIController.LockLevel != UIController.UILevel.All)
				{
					GameController.ins.UIController.ShowBlackMask(delegate
					{
						AreaData areaData = null;
						if (GameController.getInstance().CardDataModMap.getCardDataByModID("建造场景") != null)
						{
							areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().CardDataModMap.getCardDataByModID("建造场景").GetAttr("AreaDataID")];
						}
						if (areaData == null)
						{
							areaData = GameController.getInstance().AreaDataModMap.getAreaDataByModID("建造场景");
						}
						areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
						GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
						GameController.getInstance().OnTableChange(areaData, true);
					}, 0.5f);
				}
			}
		}
	}

	private IEnumerator ShowZhuFu(GameObject go)
	{
		this.m_isMoveCamera = true;
		go.GetComponent<BoxCollider>().enabled = false;
		this.m_CameraPos = Camera.main.transform.localPosition;
		this.m_CameraRotate = Camera.main.transform.localRotation;
		Camera.main.GetComponent<CameraEffect>().PostProcessVolume.profile.GetSetting<DepthOfField>().active = false;
		Camera.main.transform.DOLocalMove(new Vector3(7.601001f, -0.3219948f, 20.3822f), 0.5f, false);
		Camera.main.transform.DOLocalRotate(new Vector3(-50.957f, 29.151f, -25.919f), 0.5f, RotateMode.Fast);
		yield return new WaitForSeconds(0.5f);
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("UI/Canvas/ShangDianJieSuoCanvas")) as GameObject;
		gameObject.transform.position = new Vector3(10.29f, 1.5f, 10.55f);
		gameObject.transform.rotation = Quaternion.Euler(9.416f, 13.496f, 0.797f);
		this.m_isMoveCamera = false;
		yield break;
	}

	private IEnumerator HideZhuFu(GameObject go)
	{
		this.m_isMoveCamera = true;
		GameObject item = GameObject.Find("ShangDianJieSuoCanvas(Clone)");
		item.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack);
		yield return new WaitForSeconds(0.5f);
		UnityEngine.Object.Destroy(item);
		Camera.main.transform.DOLocalMove(this.m_CameraPos, 0.5f, false);
		Camera.main.transform.DOLocalRotate(this.m_CameraRotate.eulerAngles, 0.5f, RotateMode.Fast);
		yield return new WaitForSeconds(0.5f);
		GameObject.Find("祝福小屋").GetComponent<BoxCollider>().enabled = true;
		this.m_isMoveCamera = false;
		yield break;
	}

	private IEnumerator NiuDanCorotine(GameObject go)
	{
		UIController.LockLevel = UIController.UILevel.All;
		CardData targetCard = null;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.神器) && !cardData.ModID.Equals(GlobalController.Instance.GetStartGameItem()))
			{
				list.Add(CardData.CopyCardData(cardData, true));
			}
		}
		string startGameString = "";
		if (list.Count > 0)
		{
			SYNCRandom.Rebuild(DateTime.Now.Millisecond);
			targetCard = list[SYNCRandom.Range(0, list.Count)];
			GlobalController.Instance.SetStartGameItem(targetCard.ModID);
			GlobalController.Instance.ChangeTwistedEggCoupon(-1);
		}
		else
		{
			Debug.LogError("开局物品数据读取错误！");
		}
		this.m_IsRoll = true;
		this.m_CameraPos = Camera.main.transform.localPosition;
		this.m_CameraRotate = Camera.main.transform.localRotation;
		Camera.main.GetComponent<CameraEffect>().PostProcessVolume.profile.GetSetting<DepthOfField>().active = false;
		Camera.main.transform.DOLocalMove(new Vector3(0.4299996f, -1.940005f, 10.59004f), 0.5f, false);
		Camera.main.transform.DOLocalRotate(new Vector3(-35.492f, -24.852f, 24.929f), 0.5f, RotateMode.Fast);
		yield return new WaitForSeconds(0.5f);
		Animator animator = go.GetComponent<Animator>();
		Transform uianchorPoint = go.GetComponent<BigToy>().UIAnchorPoint;
		GameObject myCard = Card.InitWithOutData(targetCard, true);
		myCard.transform.SetParent(uianchorPoint);
		myCard.transform.localScale = Vector3.one * 0.8f;
		myCard.transform.localRotation = Quaternion.Euler(2.524f, -73.423f, -89.249f);
		myCard.transform.localPosition = new Vector3(0.01f, -0.008f, 0.163f);
		animator.SetTrigger("start");
		yield return new WaitForSeconds(5f);
		if (string.IsNullOrEmpty(startGameString))
		{
			GameController.ins.CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_19"), LocalizationMgr.Instance.GetLocalizationWord(targetCard.Name)), 1f, 2f, 1f, 1f);
		}
		else
		{
			GameController.ins.CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_19"), startGameString), 1f, 2f, 1f, 1f);
		}
		yield return new WaitForSeconds(2f);
		Camera.main.transform.DOLocalMove(this.m_CameraPos, 0.5f, false);
		Camera.main.transform.DOLocalRotate(this.m_CameraRotate.eulerAngles, 0.5f, RotateMode.Fast);
		yield return new WaitForSeconds(0.5f);
		animator.SetTrigger("end");
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(0.5f);
		UnityEngine.Object.Destroy(myCard);
		this.m_IsRoll = false;
		this.NiuDan.SetActive(false);
		if (this.NiuDanParent.childCount > 0)
		{
			UnityEngine.Object.DestroyImmediate(this.NiuDanParent.GetChild(0).gameObject);
		}
		this.ShowNiuDan();
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	public void ShowNiuDan()
	{
		this.NiuDan.transform.localScale = Vector3.zero;
		this.NiuDan.SetActive(true);
		if (!string.IsNullOrEmpty(GlobalController.Instance.GetStartGameItem()))
		{
			if (GameController.ins.CardDataModMap.getCardDataByModID(GlobalController.Instance.GetStartGameItem()) == null)
			{
				List<CardData> list = new List<CardData>();
				foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
				{
					if (cardData.HasTag(TagMap.神器))
					{
						list.Add(CardData.CopyCardData(cardData, true));
					}
				}
				CardData cardData2 = CardData.CopyCardData(list[SYNCRandom.Range(0, list.Count)], true);
				GameObject gameObject = Card.InitWithOutData(cardData2, true);
				gameObject.transform.SetParent(this.NiuDanParent);
				gameObject.transform.localScale = Vector3.one * 0.8f;
				gameObject.transform.localRotation = Quaternion.Euler(2.524f, -73.423f, -89.249f);
				gameObject.transform.localPosition = new Vector3(0.01f, -0.008f, 0.163f);
				gameObject.AddComponent<CardsCollectionInfo>().cardData = cardData2;
				gameObject.AddComponent<BoxCollider>();
			}
			else
			{
				CardData cardData3 = Card.InitCardDataByID(GlobalController.Instance.GetStartGameItem());
				GameObject gameObject2 = Card.InitWithOutData(cardData3, true);
				gameObject2.transform.SetParent(this.NiuDanParent);
				gameObject2.transform.localScale = Vector3.one * 0.8f;
				gameObject2.transform.localRotation = Quaternion.Euler(2.524f, -73.423f, -89.249f);
				gameObject2.transform.localPosition = new Vector3(0.01f, -0.008f, 0.163f);
				gameObject2.AddComponent<CardsCollectionInfo>().cardData = cardData3;
				gameObject2.AddComponent<BoxCollider>();
			}
			this.NiuDan.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
			return;
		}
		this.NiuDan.SetActive(false);
		if (this.NiuDanParent.childCount > 0)
		{
			UnityEngine.Object.DestroyImmediate(this.NiuDanParent.GetChild(0).gameObject);
		}
	}

	public List<Transform> Buildings;

	public List<GameObject> AnimatorGO;

	public GameObject NiuDan;

	public Transform NiuDanParent;

	private Vector3 m_CameraPos = new Vector3(0f, -8.400002f, -0.3699999f);

	private Quaternion m_CameraRotate = Quaternion.Euler(-23f, 0f, 0f);

	private bool m_isMoveCamera;

	private bool m_IsRoll;
}
