using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneBooth : MonoBehaviour
{
	private void Start()
	{
		this.oldCameraPos = new Vector3(-411.02f, 5.2f, 0.77f);
		this.oldCameraRotation = new Vector3(48.367f, 0.378f, 0f);
		this.GetToys = new List<CardData>();
		SceneManager.sceneLoaded += this.SceneLoadedCallBack;
		SceneManager.sceneUnloaded += this.SceneUnloadedCallBack;
		BGMusicManager.Instance.PlayBGMusic(1, 2, null);
		this.AnimatorGO[UnityEngine.Random.Range(0, this.AnimatorGO.Count)].SetActive(true);
		this.ShowGetedLockedObjs();
		this.ShowGetedUnLockedObjs();
		if (MultiPlayerController.Instance != null)
		{
			CSteamID currentLobbyID = MultiPlayerController.Instance.CurrentLobbyID;
			EffectAudioManager.Instance.PlayEffectAudio(8, null);
			DungeonController.Instance.StartCOOPDungeon();
			BGMusicManager.Instance.PlayBGMusic(3, 0, null);
			AreaData areaData = GameController.ins.GameData.AreaMap["合作模式"];
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
			base.StartCoroutine(this.EnterDungeon());
			return;
		}
		if (VSModeController.Instance != null)
		{
			CSteamID currentLobbyID2 = VSModeController.Instance.CurrentLobbyID;
			EffectAudioManager.Instance.PlayEffectAudio(8, null);
			DungeonController.Instance.StartVSDungeon();
			BGMusicManager.Instance.PlayBGMusic(3, 0, null);
			AreaData areaData2 = GameController.ins.GameData.AreaMap["对战模式"];
			areaData2.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData2.Name);
			GameController.getInstance().OnTableChange(areaData2, true);
			base.StartCoroutine(this.EnterDungeon());
		}
	}

	private IEnumerator EnterDungeon()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.UnloadSceneAsync("Home");
		yield break;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			bool flag = this.isShowMenu;
		}
		if (this.isShowMenu || UIController.LockLevel == UIController.UILevel.All)
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out raycastHit))
		{
			Collider collider = raycastHit.collider;
			if (!collider.enabled)
			{
				return;
			}
			if (collider.transform.name.Equals("电话亭") && UIController.LockLevel != UIController.UILevel.All)
			{
				UIController.LockLevel = UIController.UILevel.All;
				this.CameraDir.isFoward = false;
				Vector3 endValue = new Vector3(-416.87f, 1.06f, 7.88f);
				EffectAudioManager.Instance.PlayEffectAudio(11, null);
				this.CameraTrans.DOMove(endValue, 1f, false);
				this.CameraTrans.DORotate(new Vector3(48.56f, -33.889f, 0f), 1f, RotateMode.Fast).OnComplete(delegate
				{
					this.isShowMenu = true;
					base.StartCoroutine("ShowToyScene");
				});
			}
		}
	}

	private void ShowItems()
	{
		int count = this.GetToys.Count;
		float num = 0.017453292f * Mathf.Round((float)(360 / count));
		float num2 = 0.8f;
		List<UnLockItemBean> list = new List<UnLockItemBean>();
		for (int i = 0; i < count; i++)
		{
			float x = Mathf.Sin(num * (float)i) * num2;
			float y = Mathf.Cos(num * (float)i) * num2;
			GameObject gameObject = Card.InitWithOutData(this.GetToys[i], true);
			gameObject.transform.SetParent(this.ShowPoint);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.DOLocalMove(new Vector3(x, y, 0f), 0.5f, false).SetEase(Ease.OutBack);
			list.Add(new UnLockItemBean(this.GetToys[i], gameObject.transform));
		}
		base.StartCoroutine(this.ToyFlyIE(list));
	}

	private IEnumerator ToyFlyIE(List<UnLockItemBean> toys)
	{
		yield return new WaitForSeconds(1.5f);
		int num;
		for (int i = 0; i < toys.Count; i = num + 1)
		{
			EffectAudioManager.Instance.PlayEffectAudio(9, null);
			if ((toys[i].Data.CardTags & 1048576UL) > 0UL)
			{
				GlobalController.Instance.RemoveLockedToy(toys[i].Data);
				if (!this.ToyBox.GetCurrentAnimatorStateInfo(0).IsName("ToyBox"))
				{
					this.ToyBox.Rebind();
					this.ToyBox.SetTrigger("open");
					EffectAudioManager.Instance.PlayEffectAudio(2, null);
				}
				Vector3 endValue = new Vector3(this.ToyBoxPoint.position.x + 0.5f * UnityEngine.Random.Range(-2f, 2.5f), this.ToyBoxPoint.position.y + 0.5f * UnityEngine.Random.Range(-1f, 1f), this.ToyBoxPoint.position.z + 0.3f * UnityEngine.Random.Range(-1f, 1f));
				UnLockItemBean toy = toys[i];
				TweenCallback <>9__1;
				toy.Trans.DOMove(endValue, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
				{
					toy.Trans.DOMove(this.ToyBox.transform.position, 0.5f, false).SetEase(Ease.InBack);
					TweenerCore<Vector3, Vector3, VectorOptions> t = toy.Trans.DOScale(Vector3.one * 0.5f, 0.5f);
					TweenCallback action;
					if ((action = <>9__1) == null)
					{
						action = (<>9__1 = delegate()
						{
							UnityEngine.Object.Destroy(toy.Trans.gameObject);
						});
					}
					t.OnComplete(action);
				});
			}
			if ((toys[i].Data.CardTags & 65536UL) > 0UL)
			{
				GlobalController.Instance.RemoveLockedMedicine(toys[i].Data);
				UnLockItemBean toy = toys[i];
				TweenCallback <>9__3;
				toy.Trans.DOMove(this.BooksPoint.position, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t = toy.Trans.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
					TweenCallback action;
					if ((action = <>9__3) == null)
					{
						action = (<>9__3 = delegate()
						{
							UnityEngine.Object.Destroy(toy.Trans.gameObject);
						});
					}
					t.OnComplete(action);
				});
			}
			if ((toys[i].Data.CardTags & 1024UL) > 0UL && (toys[i].Data.CardTags & 512UL) > 0UL)
			{
				GlobalController.Instance.RemoveLockedSpacee(toys[i].Data);
				UnLockItemBean toy = toys[i];
				TweenCallback <>9__5;
				toy.Trans.DOMove(this.MySpacePoint.position, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t = toy.Trans.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
					TweenCallback action;
					if ((action = <>9__5) == null)
					{
						action = (<>9__5 = delegate()
						{
							UnityEngine.Object.Destroy(toy.Trans.gameObject);
						});
					}
					t.OnComplete(action);
				});
			}
			yield return new WaitForSeconds(0.3f);
			num = i;
		}
		yield return new WaitForSeconds(1f);
		this.ToyBox.SetTrigger("close");
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	private IEnumerator ShowToyScene()
	{
		yield return SceneManager.LoadSceneAsync("PhoneBoothScene", LoadSceneMode.Additive);
		yield break;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= this.SceneLoadedCallBack;
		SceneManager.sceneUnloaded -= this.SceneUnloadedCallBack;
	}

	private void ShowGetedLockedObjs()
	{
		UIController.LockLevel = UIController.UILevel.All;
		int count = GlobalController.Instance.TempLockedObjs.Count;
		if (count <= 0)
		{
			UIController.LockLevel = UIController.UILevel.None;
			return;
		}
		float num = 0.017453292f * Mathf.Round((float)(360 / count));
		float num2 = 1.5f;
		List<UnLockItemBean> list = new List<UnLockItemBean>();
		for (int i = 0; i < count; i++)
		{
			float x = Mathf.Sin(num * (float)i) * num2;
			float y = Mathf.Cos(num * (float)i) * num2;
			GameObject gameObject = Card.InitWithOutData(GlobalController.Instance.TempLockedObjs[i], true);
			gameObject.transform.SetParent(this.GameShowPoint);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.DOLocalMove(new Vector3(x, y, 0f), 0.5f, false).SetEase(Ease.OutBack);
			list.Add(new UnLockItemBean(GlobalController.Instance.TempLockedObjs[i], gameObject.transform));
		}
		base.StartCoroutine(this.ObjFlyToPhoneBoothIE(list));
	}

	private IEnumerator ObjFlyToPhoneBoothIE(List<UnLockItemBean> objs)
	{
		yield return new WaitForSeconds(1.5f);
		int num;
		for (int i = 0; i < objs.Count; i = num + 1)
		{
			EffectAudioManager.Instance.PlayEffectAudio(9, null);
			if ((objs[i].Data.CardTags & 1048576UL) > 0UL)
			{
				GlobalController.Instance.RemoveFromAllToys(new List<CardData>
				{
					objs[i].Data
				});
			}
			else if ((objs[i].Data.CardTags & 65536UL) > 0UL)
			{
				GlobalController.Instance.RemoveFromAllItems(new List<CardData>
				{
					objs[i].Data
				});
			}
			UnLockItemBean obj = objs[i];
			TweenCallback <>9__1;
			obj.Trans.DOMove(this.PhoneBoothPoint.position, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
			{
				TweenerCore<Vector3, Vector3, VectorOptions> t = obj.Trans.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
				TweenCallback action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate()
					{
						UnityEngine.Object.Destroy(obj.Trans.gameObject);
					});
				}
				t.OnComplete(action);
			});
			yield return new WaitForSeconds(0.3f);
			num = i;
		}
		yield return new WaitForSeconds(1f);
		GlobalController.Instance.TempLockedObjs = new List<CardData>();
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	private void ShowGetedUnLockedObjs()
	{
		UIController.LockLevel = UIController.UILevel.All;
		int count = GlobalController.Instance.TempUnLockedObjs.Count;
		if (count <= 0)
		{
			UIController.LockLevel = UIController.UILevel.None;
			return;
		}
		float num = 0.017453292f * Mathf.Round((float)(360 / count));
		float num2 = 1.5f;
		List<UnLockItemBean> list = new List<UnLockItemBean>();
		for (int i = 0; i < count; i++)
		{
			float x = Mathf.Sin(num * (float)i) * num2;
			float y = Mathf.Cos(num * (float)i) * num2;
			GameObject gameObject = Card.InitWithOutData(GlobalController.Instance.TempUnLockedObjs[i], true);
			gameObject.transform.SetParent(this.GameShowPoint);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.DOLocalMove(new Vector3(x, y, 0f), 0.5f, false).SetEase(Ease.OutBack);
			list.Add(new UnLockItemBean(GlobalController.Instance.TempUnLockedObjs[i], gameObject.transform));
		}
		base.StartCoroutine(this.ObjFlyToEveryRoomIE(list));
	}

	private IEnumerator ObjFlyToEveryRoomIE(List<UnLockItemBean> objs)
	{
		yield return new WaitForSeconds(1.5f);
		int num;
		for (int i = 0; i < objs.Count; i = num + 1)
		{
			EffectAudioManager.Instance.PlayEffectAudio(9, null);
			if ((objs[i].Data.CardTags & 1048576UL) > 0UL)
			{
				GlobalController.Instance.RemoveFromAllToysToUnLocked(new List<CardData>
				{
					objs[i].Data
				});
				if (!this.ToyBox.GetCurrentAnimatorStateInfo(0).IsName("ToyBox"))
				{
					this.ToyBox.Rebind();
					this.ToyBox.SetTrigger("open");
					EffectAudioManager.Instance.PlayEffectAudio(2, null);
				}
				Vector3 endValue = new Vector3(this.ToyBoxPoint.position.x + 0.5f * UnityEngine.Random.Range(-2f, 2.5f), this.ToyBoxPoint.position.y + 0.5f * UnityEngine.Random.Range(-1f, 1f), this.ToyBoxPoint.position.z + 0.3f * UnityEngine.Random.Range(-1f, 1f));
				UnLockItemBean toy = objs[i];
				TweenCallback <>9__1;
				toy.Trans.DOMove(endValue, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
				{
					toy.Trans.DOMove(this.ToyBox.transform.position, 0.5f, false).SetEase(Ease.InBack);
					TweenerCore<Vector3, Vector3, VectorOptions> t = toy.Trans.DOScale(Vector3.one * 0.5f, 0.5f);
					TweenCallback action;
					if ((action = <>9__1) == null)
					{
						action = (<>9__1 = delegate()
						{
							UnityEngine.Object.Destroy(toy.Trans.gameObject);
						});
					}
					t.OnComplete(action);
				});
			}
			if ((objs[i].Data.CardTags & 128UL) > 0UL)
			{
				UnLockItemBean toy = objs[i];
				TweenCallback <>9__3;
				toy.Trans.DOMove(this.HeroHomePoint.position, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t = toy.Trans.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
					TweenCallback action;
					if ((action = <>9__3) == null)
					{
						action = (<>9__3 = delegate()
						{
							UnityEngine.Object.Destroy(toy.Trans.gameObject);
						});
					}
					t.OnComplete(action);
				});
			}
			if ((objs[i].Data.CardTags & 65536UL) > 0UL)
			{
				GlobalController.Instance.RemoveFromAllItemsToUnLocked(new List<CardData>
				{
					objs[i].Data
				});
				UnLockItemBean toy = objs[i];
				TweenCallback <>9__5;
				toy.Trans.DOMove(this.BooksPoint.position, 1f, false).SetEase(Ease.InBack).OnComplete(delegate
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t = toy.Trans.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
					TweenCallback action;
					if ((action = <>9__5) == null)
					{
						action = (<>9__5 = delegate()
						{
							UnityEngine.Object.Destroy(toy.Trans.gameObject);
						});
					}
					t.OnComplete(action);
				});
			}
			yield return new WaitForSeconds(0.3f);
			num = i;
		}
		yield return new WaitForSeconds(1f);
		this.ToyBox.SetTrigger("close");
		GlobalController.Instance.TempUnLockedObjs = new List<CardData>();
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	private void SceneLoadedCallBack(Scene scene, LoadSceneMode sceneType)
	{
		if (scene.name.Equals("ShowToyScene"))
		{
			this.CameraTrans.gameObject.SetActive(false);
		}
		if (scene.name.Equals("ShowHeroHome"))
		{
			this.CameraTrans.gameObject.SetActive(false);
		}
		if (scene.name.Equals("PhoneBoothScene"))
		{
			this.CameraTrans.gameObject.SetActive(false);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("PhoneBoothScene"));
		}
		if (scene.name.Equals("CardsCollection"))
		{
			CardsCollectionMgr.Instance.Init("All");
			this.isShowMenu = true;
			this.CameraTrans.gameObject.SetActive(false);
		}
	}

	private void SceneUnloadedCallBack(Scene scene)
	{
		if (scene.name.Equals("ShowToyScene"))
		{
			this.CameraTrans.gameObject.SetActive(true);
			this.GetToys = ShowToyMgr.Instance.UnLockToys;
			this.CameraTrans.DOMove(this.oldCameraPos, 1f, false);
			this.CameraTrans.DORotate(this.oldCameraRotation, 1f, RotateMode.Fast).OnComplete(delegate
			{
				this.isShowMenu = false;
				this.CameraDir.isFoward = true;
				if (this.GetToys.Count > 0)
				{
					this.ShowItems();
					return;
				}
				UIController.LockLevel = UIController.UILevel.None;
			});
			Debug.Log("ShowToyScene卸载！");
		}
		if (scene.name.Equals("ShowHeroHome"))
		{
			this.CameraTrans.gameObject.SetActive(true);
			UIController.LockLevel = UIController.UILevel.None;
			Debug.Log("ShowHeroHome卸载！");
		}
		if (scene.name.Equals("PhoneBoothScene"))
		{
			this.CameraTrans.gameObject.SetActive(true);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("Home"));
			this.GetToys = PhoneBoothController.Instance.UnLockCards;
			this.CameraTrans.DOMove(this.oldCameraPos, 1f, false);
			this.CameraTrans.DORotate(this.oldCameraRotation, 1f, RotateMode.Fast).OnComplete(delegate
			{
				this.isShowMenu = false;
				this.CameraDir.isFoward = true;
				if (this.GetToys.Count > 0)
				{
					this.ShowItems();
					return;
				}
				UIController.LockLevel = UIController.UILevel.None;
			});
			Debug.Log("ShowToyScene卸载！");
		}
		if (scene.name.Equals("CardsCollection"))
		{
			this.CameraTrans.gameObject.SetActive(true);
			this.isShowMenu = false;
			this.CameraDir.isFoward = true;
			UIController.LockLevel = UIController.UILevel.None;
			Debug.Log("CardsCollection卸载！");
		}
	}

	public Transform CameraTrans;

	public CameraDir CameraDir;

	private Vector3 oldCameraPos;

	private Vector3 oldCameraRotation;

	private bool isShowMenu;

	public Transform ShowPoint;

	private List<CardData> GetToys = new List<CardData>();

	public Animator ToyBox;

	public Transform ToyBoxPoint;

	public Transform HeroHomePoint;

	public Transform BooksPoint;

	public Transform MySpacePoint;

	public Transform GameShowPoint;

	public Transform PhoneBoothPoint;

	public List<GameObject> AnimatorGO;
}
