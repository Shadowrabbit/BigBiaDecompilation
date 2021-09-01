using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class HeroHomeLevelUpTipBox : MonoBehaviour
{
	private void Start()
	{
		EventTriggerListener.Get(base.gameObject).onClick = new EventTriggerListener.VoidDelegate(this.OnGoClicked);
		this.m_CardData = new CardData();
		this.m_CardData.Name = (this.Price.ToString() ?? "");
		this.m_CardData.desc = LocalizationMgr.Instance.GetLocalizationWord("T_" + this.DESC) + "+" + this.Rate;
	}

	public void OnMouseEnter()
	{
		GameUIController.Instance.OpenTips(this.m_CardData, base.transform.position, Camera.main);
	}

	public void OnMouseExit()
	{
		GameUIController.Instance.CloseTips();
	}

	private void OnGoClicked(GameObject go)
	{
		if (go == base.gameObject)
		{
			this.HeroHomeArea.CheckHaveUnlockedPanel();
			Transform trans = UnityEngine.Object.Instantiate<Transform>(Resources.Load<Transform>("UI/HeroHomeUnLockPanel"));
			HeroHomeUnLockPanel component = trans.GetComponent<HeroHomeUnLockPanel>();
			component.UnlockBtn.onClick.AddListener(delegate()
			{
				this.UnLock(this, trans.gameObject);
			});
			component.CloseBtn.onClick.AddListener(delegate()
			{
				this.CloseUnLockPanel(trans.gameObject);
			});
			trans.SetParent(this.HeroHomeArea.Canvas);
			trans.localScale = Vector3.zero;
			trans.position = Camera.main.WorldToScreenPoint(base.gameObject.transform.position);
			trans.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
			this.HeroHomeArea.AllUnlockedPanel.Add(trans.gameObject);
		}
	}

	private void UnLock(HeroHomeLevelUpTipBox target, GameObject ui)
	{
		if (GlobalController.Instance.GlobalData.Money < this.Price)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
			return;
		}
		GlobalController.Instance.ChangeGlobalMoney(-this.Price);
		this.HeroHomeArea.AllUnlockedPanel.Remove(ui);
		UnityEngine.Object.Destroy(ui);
		TweenCallback <>9__1;
		base.gameObject.transform.DOScale(0f, 0.2f).SetEase(Ease.InBack).OnComplete(delegate
		{
			TweenerCore<Vector3, Vector3, VectorOptions> t = this.ShowContent.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
			TweenCallback action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate()
				{
					this.HeroHomeArea.AddHeroLevel(this.HeroHomeArea.ShowContents.IndexOf(target));
					UnityEngine.Object.Destroy(this.gameObject);
				});
			}
			t.OnComplete(action);
		});
	}

	private void CloseUnLockPanel(GameObject target)
	{
		this.HeroHomeArea.AllUnlockedPanel.Remove(target);
		UnityEngine.Object.Destroy(target);
	}

	public HeroHomeArea HeroHomeArea;

	public int Price;

	public string DESC;

	public string Rate;

	public GameObject ShowContent;

	private CardData m_CardData;
}
