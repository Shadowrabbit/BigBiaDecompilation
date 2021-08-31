using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowToyMgr : MonoBehaviour
{
	private ShowToyMgr()
	{
		ShowToyMgr.Instance = this;
		this.m_currentIndex = 0;
	}

	public void InitShowScene(int type = 0)
	{
		EventTriggerListener.Get(this.NextToy).onClick = new EventTriggerListener.VoidDelegate(this.OnNextToy);
		EventTriggerListener.Get(this.PreToy).onClick = new EventTriggerListener.VoidDelegate(this.OnPreToy);
		EventTriggerListener.Get(this.UnLock).onClick = new EventTriggerListener.VoidDelegate(this.OnUnLockToy);
		EventTriggerListener.Get(this.Cancel).onClick = new EventTriggerListener.VoidDelegate(this.OnCancel);
		EventTriggerListener.Get(this.SelectHero).onClick = new EventTriggerListener.VoidDelegate(this.OnSelectHero);
		EventTriggerListener.Get(this.ContentDragArea).onDrag = new EventTriggerListener.VoidDelegate(this.OnDragAreaEnter);
		this.m_showContent = new List<CardData>();
		this.UnLockToys = new List<CardData>();
		this.m_ShowType = type;
		switch (type)
		{
		case 0:
			this.UnLock.SetActive(false);
			this.SelectHero.SetActive(false);
			using (List<string>.Enumerator enumerator = GlobalController.Instance.GlobalData.UnLockedToysModID.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string modId = enumerator.Current;
					this.m_showContent.Add(GameController.getInstance().CardDataModMap.getCardDataByModID(modId));
				}
				goto IL_241;
			}
			break;
		case 1:
			break;
		case 2:
			goto IL_1BC;
		case 3:
			this.UnLock.SetActive(false);
			this.SelectHero.SetActive(false);
			foreach (string modId2 in GlobalController.Instance.GlobalData.UnLockedItemsModID)
			{
				this.m_showContent.Add(GameController.getInstance().CardDataModMap.getCardDataByModID(modId2));
			}
			goto IL_241;
		default:
			goto IL_241;
		}
		this.UnLock.SetActive(true);
		this.SelectHero.SetActive(false);
		using (List<string>.Enumerator enumerator = GlobalController.Instance.GlobalData.LockedToysModID.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				string modId3 = enumerator.Current;
				this.m_showContent.Add(GameController.getInstance().CardDataModMap.getCardDataByModID(modId3));
			}
			goto IL_241;
		}
		IL_1BC:
		this.UnLock.SetActive(false);
		this.SelectHero.SetActive(true);
		IL_241:
		this.ShowContent(0, 0);
	}

	private void OnDragAreaEnter(GameObject go)
	{
		if (go == this.ContentDragArea)
		{
			float axis = Input.GetAxis("Mouse X");
			this.m_currentTrans.Rotate(new Vector3(0f, -axis, 0f) * 5f, Space.Self);
		}
	}

	private void ShowContent(int index = 0, int dir = 0)
	{
		this.m_currentIndex = index;
		if (this.m_showContent.Count <= 0)
		{
			this.ShowContentNameText.text = "";
			this.ShowContentText.text = "暂未拥有可解锁内容！";
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Stage);
		gameObject.SetActive(true);
		gameObject.transform.SetParent(this.ShowContentParent);
		gameObject.transform.localRotation = Quaternion.Euler(this.m_StageRotation.x, this.m_StageRotation.y, this.m_StageRotation.z);
		gameObject.transform.localScale = Vector3.zero;
		this.m_currentStage = gameObject.transform;
		GameObject gameObject2 = null;
		int showType = this.m_ShowType;
		if (showType > 1)
		{
			if (showType - 2 <= 1)
			{
				gameObject2 = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(this.m_showContent[index].Model));
				gameObject2.transform.SetParent(this.ShowContentParent);
				gameObject2.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				gameObject2.transform.localScale = Vector3.zero;
			}
		}
		else
		{
			gameObject2 = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(GameController.getInstance().AreaDataModMap.getAreaDataByModID(this.m_showContent[index].ModID).TableModel + "模型"));
			gameObject2.transform.SetParent(this.ShowContentParent);
			gameObject2.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			gameObject2.transform.localScale = Vector3.zero;
		}
		this.m_currentTrans = gameObject2.transform;
		switch (dir)
		{
		case 0:
			gameObject.transform.localPosition = this.m_ShowPoint;
			gameObject2.transform.localPosition = this.m_ToyPoint;
			break;
		case 1:
			gameObject.transform.localPosition = this.m_NextPoint;
			gameObject2.transform.localPosition = this.m_ToyNextPoint;
			break;
		case 2:
			gameObject.transform.localPosition = this.m_PrePoint;
			gameObject2.transform.localPosition = this.m_ToyPrePoint;
			break;
		}
		base.StartCoroutine(this.ShowToyAnimate(this.m_currentStage, this.m_currentTrans));
		this.ShowContentNameText.text = this.m_showContent[index].Name;
		this.ShowContentText.text = this.m_showContent[index].desc;
	}

	public void OnNextToy(GameObject go)
	{
		float oldY = go.transform.localPosition.y;
		EffectAudioManager.Instance.PlayEffectAudio(7, null);
		go.transform.DOLocalMoveY(0.55f, 0.05f, false).OnComplete(delegate
		{
			go.transform.DOLocalMoveY(oldY, 0.05f, false);
		});
		if (this.m_showContent.Count > 1 && this.isCanClick)
		{
			Transform currentTrans = this.m_currentTrans;
			Transform currentStage = this.m_currentStage;
			this.ShowContent((this.m_currentIndex + 1) % this.m_showContent.Count, 2);
			base.StartCoroutine(this.ChangeToyAnimate(currentStage, currentTrans, this.m_currentStage, this.m_currentTrans, 1));
		}
	}

	public void OnPreToy(GameObject go)
	{
		float oldY = go.transform.localPosition.y;
		EffectAudioManager.Instance.PlayEffectAudio(7, null);
		go.transform.DOLocalMoveY(0.55f, 0.05f, false).OnComplete(delegate
		{
			go.transform.DOLocalMoveY(oldY, 0.05f, false);
		});
		if (this.m_showContent.Count > 1 && this.isCanClick)
		{
			Transform currentTrans = this.m_currentTrans;
			Transform currentStage = this.m_currentStage;
			this.ShowContent(((this.m_currentIndex - 1 < 0) ? 5 : (this.m_currentIndex - 1)) % this.m_showContent.Count, 1);
			base.StartCoroutine(this.ChangeToyAnimate(currentStage, currentTrans, this.m_currentStage, this.m_currentTrans, 2));
		}
	}

	public void OnSelectHero(GameObject go)
	{
		if (go == this.SelectHero)
		{
			float oldY = go.transform.localPosition.y;
			EffectAudioManager.Instance.PlayEffectAudio(8, null);
			go.transform.DOLocalMoveY(0.45f, 0.05f, false).OnComplete(delegate
			{
				go.transform.DOLocalMoveY(oldY, 0.05f, false);
			});
		}
	}

	public void OnRefresh()
	{
		if (this.m_showContent.Count > 0)
		{
			this.ShowContent(this.m_currentIndex % this.m_showContent.Count, 0);
			return;
		}
		this.ShowContent(0, 0);
	}

	public void OnUnLockToy(GameObject go)
	{
		if (go == this.UnLock)
		{
			float oldY = go.transform.localPosition.y;
			EffectAudioManager.Instance.PlayEffectAudio(8, null);
			TweenCallback <>9__1;
			go.transform.DOLocalMoveY(0.45f, 0.05f, false).OnComplete(delegate
			{
				TweenerCore<Vector3, Vector3, VectorOptions> t = go.transform.DOLocalMoveY(oldY, 0.05f, false);
				TweenCallback action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate()
					{
						this.UnLock.SetActive(false);
					});
				}
				t.OnComplete(action);
			});
			base.StartCoroutine("UnLockAnimate");
		}
	}

	private IEnumerator UnLockAnimate()
	{
		yield return null;
		for (int i = this.m_showContent.Count - 1; i >= 0; i--)
		{
			if (i == this.m_currentIndex)
			{
				this.UnLockToys.Add(this.m_showContent[i]);
				Debug.Log(this.m_showContent[i].ModID + "  : 已解锁！！！！");
				GlobalController.Instance.GlobalData.LockedToysModID.Remove(this.m_showContent[i].ModID);
				this.m_showContent.RemoveAt(i);
				break;
			}
		}
		yield return base.StartCoroutine(this.CloseToyAnimate());
		this.OnRefresh();
		yield break;
	}

	public void OnCancel(GameObject go)
	{
		if (go == this.Cancel)
		{
			EffectAudioManager.Instance.PlayEffectAudio(15, null);
			SceneManager.UnloadSceneAsync("ShowToyScene");
		}
	}

	private IEnumerator ChangeToyAnimate(Transform changeStage, Transform changeToy, Transform targetStage, Transform targetToy, int dir)
	{
		this.isCanClick = false;
		switch (dir)
		{
		case 0:
			yield return base.StartCoroutine(this.CloseToyAnimate());
			break;
		case 1:
			changeStage.DOLocalMove(this.m_NextPoint, 0.5f, false);
			changeToy.DOLocalMove(this.m_ToyNextPoint, 0.5f, false);
			targetStage.DOLocalMove(this.m_ShowPoint, 0.5f, false);
			targetToy.DOLocalMove(this.m_ToyPoint, 0.5f, false).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(changeStage.gameObject);
				UnityEngine.Object.Destroy(changeToy.gameObject);
			});
			break;
		case 2:
			changeStage.DOLocalMove(this.m_PrePoint, 0.5f, false);
			changeToy.DOLocalMove(this.m_ToyPrePoint, 0.5f, false);
			targetStage.DOLocalMove(this.m_ShowPoint, 0.5f, false);
			targetToy.DOLocalMove(this.m_ToyPoint, 0.5f, false).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(changeStage.gameObject);
				UnityEngine.Object.Destroy(changeToy.gameObject);
			});
			break;
		}
		yield return 0;
		this.isCanClick = true;
		yield break;
	}

	private IEnumerator ShowToyAnimate(Transform curStage, Transform curToy)
	{
		this.isCanClick = false;
		curStage.DOScale(this.m_StageScale, 0.5f);
		curToy.DOScale(this.m_ToyScale, 0.5f).OnComplete(delegate
		{
			if (this.m_ShowType == 1)
			{
				this.UnLock.SetActive(true);
			}
		});
		yield return new WaitForSeconds(1f);
		this.isCanClick = true;
		yield break;
	}

	private IEnumerator CloseToyAnimate()
	{
		this.isCanClick = false;
		if (this.m_currentTrans != null)
		{
			this.m_currentTrans.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(this.m_currentTrans.gameObject);
				this.m_currentTrans = null;
			});
		}
		if (this.m_currentStage != null)
		{
			this.m_currentStage.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(this.m_currentStage.gameObject);
				this.m_currentStage = null;
			});
		}
		yield return new WaitForSeconds(1.5f);
		this.isCanClick = true;
		yield break;
	}

	public static ShowToyMgr Instance;

	public Camera SceneCamera;

	public Transform ShowContentParent;

	public TMP_Text ShowContentText;

	public TMP_Text ShowContentNameText;

	public GameObject NextToy;

	public GameObject PreToy;

	public GameObject UnLock;

	public GameObject SelectHero;

	public GameObject Cancel;

	public GameObject Stage;

	public GameObject ContentDragArea;

	public bool isShowToy;

	[NonSerialized]
	public List<CardData> UnLockToys = new List<CardData>();

	private int m_currentIndex;

	private List<CardData> m_showContent = new List<CardData>();

	private Vector3 m_PrePoint = new Vector3(0.06072588f, -0.9697945f, 5.76f);

	private Vector3 m_NextPoint = new Vector3(0.06072588f, -0.9697945f, -5.76f);

	private Vector3 m_ShowPoint = new Vector3(0.06072588f, -0.9697945f, 0.04799824f);

	private Vector3 m_StageRotation = new Vector3(-3.133f, 90f, 0f);

	private Vector3 m_StageScale = new Vector3(0.552f, 0.5519998f, 0.552f);

	private Vector3 m_ToyPrePoint = new Vector3(0f, 0f, 5.712012f);

	private Vector3 m_ToyNextPoint = new Vector3(0f, 0f, -5.712012f);

	private Vector3 m_ToyPoint = Vector3.zero;

	private float m_ToyScale = 1f;

	private int m_ShowType;

	private Transform m_currentTrans;

	private Transform m_currentStage;

	private bool isCanClick = true;
}
