using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TimeMachineUIChontroller : MonoBehaviour
{
	private void Start()
	{
		base.transform.GetComponent<Canvas>().worldCamera = Camera.main;
	}

	private void Update()
	{
	}

	public void InitPanel()
	{
		this.RefreshPanel();
		if (GlobalController.Instance.GlobalData.CurrentUnlockLevel == 0)
		{
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Clear();
			GlobalController.Instance.GlobalData.HadMinions.Clear();
			GlobalController.Instance.AddHadMinions("醉鬼");
			GlobalController.Instance.AddHadMinions("乞丐");
			GlobalController.Instance.AddHadMinions("小混混");
			GlobalController.Instance.AddHadMinions("流浪狗");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("地下城生成器2");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("娱乐室");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("酒馆");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("医院");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("森林");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("枫林");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("沙漠");
			GlobalController.Instance.GlobalData.CurrentUnlockLevel = 1;
		}
		if (GlobalController.Instance.GlobalData.CurrentUnlockLevel == 1)
		{
			GlobalController.Instance.GlobalData.CurrentUnlockLevel = 2;
		}
		if (GlobalController.Instance.GlobalData.CurrentUnlockLevel == 2)
		{
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("办公室");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("虫巢");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("火山");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("马戏团");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("网吧");
			GlobalController.Instance.GlobalData.CurrentUnlockLevel = 3;
		}
		if (GlobalController.Instance.GlobalData.CurrentUnlockLevel == 3)
		{
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("BossTree");
			GlobalController.Instance.GetGlobalToysModIDToTimeMachine().Add("BossSnake");
			GlobalController.Instance.GlobalData.CurrentUnlockLevel = 4;
		}
		if (GlobalController.Instance.GlobalData.CurrentUnlockLevel == 4)
		{
			GlobalController.Instance.GlobalData.CurrentUnlockLevel = 5;
		}
		this.m_List = GlobalController.Instance.GetGlobalToysModIDToTimeMachine();
		if (this.m_List.Count > 0)
		{
			this.TipPanel.SetActive(false);
		}
		else
		{
			this.TipPanel.SetActive(true);
		}
		using (List<string>.Enumerator enumerator = this.m_List.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				string tar = enumerator.Current;
				Transform cardGo = UnityEngine.Object.Instantiate<Transform>(this.CardDescPanel);
				cardGo.transform.SetParent(this.CardDescPanel.parent);
				cardGo.localScale = this.CardDescPanel.localScale;
				cardGo.localPosition = this.CardDescPanel.localPosition;
				cardGo.localRotation = Quaternion.Euler(Vector3.zero);
				cardGo.GetChild(0).GetComponent<Text>().text = GameController.getInstance().CardDataModMap.getCardDataByModID(tar).Name;
				cardGo.name = tar;
				Button componentInChildren = cardGo.transform.GetComponentInChildren<Button>();
				int price = GameController.getInstance().CardDataModMap.getCardDataByModID(tar).Price;
				componentInChildren.transform.GetComponentInChildren<Text>().text = (price.ToString() ?? "");
				componentInChildren.onClick.AddListener(delegate()
				{
					this.OngetCardBtn(tar, price, cardGo);
				});
				cardGo.gameObject.SetActive(true);
				this.m_DescList.Add(cardGo.gameObject);
			}
		}
	}

	private void OngetCardBtn(string tar, int price, Transform go)
	{
		Debug.Log(tar + "点击！");
		if (this.m_IsGetCard)
		{
			return;
		}
		if (this.TimeMachineController.SlotData.ChildCardData != null)
		{
			GameController.getInstance().CreateSubtitle("请先处理已有卡牌！右键屏幕退出。", 1f, 2f, 1f, 1f);
			return;
		}
		if (GlobalController.Instance.GlobalData.Money >= price)
		{
			base.StartCoroutine(this.GetCardCorotine(tar, price, go));
			return;
		}
		GameController.getInstance().CreateSubtitle("很抱歉，您的体素不足，请继续努力！", 1f, 2f, 1f, 1f);
	}

	public void RefreshPanel()
	{
		for (int i = this.m_DescList.Count - 1; i >= 0; i--)
		{
			UnityEngine.Object.DestroyImmediate(this.m_DescList[i]);
		}
		this.m_DescList = new List<GameObject>();
	}

	private IEnumerator GetCardCorotine(string tar, int price, Transform go)
	{
		this.m_IsGetCard = true;
		Camera.main.transform.DOMove(this.TimeMachineController.CameraPoint1.position, 0.2f, false);
		Camera.main.transform.DORotate(this.TimeMachineController.CameraPoint1.rotation.eulerAngles, 0.2f, RotateMode.Fast);
		Camera.main.GetComponent<CameraEffect>().PostProcessVolume.profile.GetSetting<DepthOfField>().active = true;
		yield return new WaitForSeconds(0.2f);
		GlobalController.Instance.ChangeGlobalMoney(-price);
		go.transform.DOLocalMoveX(-2000f, 0.3f, false).SetEase(Ease.InBack);
		this.TimeMachineController.transform.DOShakeRotation(0.3f, 0.5f, 10, 50f, true);
		yield return new WaitForSeconds(0.5f);
		this.m_DescList.Remove(go.gameObject);
		UnityEngine.Object.DestroyImmediate(go.gameObject);
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(tar);
		CardData myCardData = CardData.CopyCardData(cardDataByModID, true);
		Card card = Card.InitCard(myCardData);
		card.transform.SetParent(this.TimeMachineController.SlotData.CardSlotGameObject.transform);
		card.transform.localScale = Vector3.one;
		card.SwitchModelToCard();
		card.transform.position = this.TimeMachineController.SlotPoint.position + new Vector3(0f, 0f, 2f);
		card.transform.DOMove(this.TimeMachineController.SlotPoint.position, 0.5f, false).SetEase(Ease.OutBack);
		yield return new WaitForSeconds(0.5f);
		myCardData.PutInSlotData(this.TimeMachineController.SlotData, true);
		this.m_List.Remove(tar);
		GlobalController.Instance.SetGlobalToysModIDToTimeMachine(this.m_List);
		this.m_IsGetCard = false;
		this.TimeMachineController.PlayAnimation_Close();
		yield break;
	}

	public TimeMachineController TimeMachineController;

	public Transform CardDescPanel;

	public GameObject TipPanel;

	private List<string> m_List = new List<string>();

	private List<GameObject> m_DescList = new List<GameObject>();

	private bool m_IsGetCard;
}
