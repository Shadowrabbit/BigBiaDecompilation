using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewspaperItem : MonoBehaviour
{
	private void Start()
	{
		this.i = UnityEngine.Random.Range(0f, 4.9f);
		switch (this.Type)
		{
		case NewspaperItem.NewspaperItemType.Card:
			if (GlobalController.Instance.GlobalData.UnlockDataPathFromNewspaper.Contains(this.ModPath))
			{
				base.gameObject.SetActive(false);
				return;
			}
			break;
		case NewspaperItem.NewspaperItemType.CharacterTag:
			if ((GlobalController.Instance.GlobalData.UnLockCharacterTag & (CharacterTag)this.CharacterTag) != (CharacterTag)0UL)
			{
				base.gameObject.SetActive(false);
				return;
			}
			break;
		case NewspaperItem.NewspaperItemType.PersonEvent:
			if (GlobalController.Instance.GlobalData.UnLockedPersonEventID == null)
			{
				GlobalController.Instance.GlobalData.UnLockedPersonEventID = new List<int>();
			}
			if (GlobalController.Instance.GlobalData.UnLockedPersonEventID.Contains(this.PersonEventID))
			{
				base.gameObject.SetActive(false);
			}
			break;
		default:
			return;
		}
	}

	private void Update()
	{
		this.i += Time.deltaTime;
		if (this.i >= 5f)
		{
			base.transform.DOShakeRotation(0.3f, 10f, 10, 90f, true);
			this.i = 0f;
		}
	}

	private void OnMouseDown()
	{
		if (!NewspaperItem.isDoing)
		{
			base.StartCoroutine(this.onDo());
		}
	}

	public IEnumerator onDo()
	{
		NewspaperItem.isDoing = true;
		base.GetComponent<BoxCollider>().enabled = false;
		base.transform.DOMoveZ(0.3f, 0.3f, false);
		yield return base.transform.DOLocalRotate(new Vector3(3f, 0f, 0f), 0.31f, RotateMode.Fast).WaitForCompletion();
		yield return base.transform.DOJump(new Vector3(0f, -10f, 0f), 1f, 1, 1f, false);
		switch (this.Type)
		{
		case NewspaperItem.NewspaperItemType.Card:
			ModManager.SetLockModWorking(this.ModPath);
			GlobalController.Instance.GlobalData.UnlockDataPathFromNewspaper.Add(this.ModPath);
			break;
		case NewspaperItem.NewspaperItemType.CharacterTag:
			GlobalController.Instance.GlobalData.UnLockCharacterTag = (GlobalController.Instance.GlobalData.UnLockCharacterTag | (CharacterTag)this.CharacterTag);
			break;
		case NewspaperItem.NewspaperItemType.PersonEvent:
			if (GlobalController.Instance.GlobalData.UnLockedPersonEventID == null)
			{
				GlobalController.Instance.GlobalData.UnLockedPersonEventID = new List<int>();
			}
			GlobalController.Instance.GlobalData.UnLockedPersonEventID.Add(this.PersonEventID);
			break;
		}
		GlobalController.Instance.SaveGlobalData();
		yield return null;
		NewspaperItem.isDoing = false;
		base.StartCoroutine(BaoKanController.ins.ShowTitle(this.Title));
		yield break;
	}

	public static bool isDoing;

	public NewspaperItem.NewspaperItemType Type;

	public string ModPath;

	public ulong CharacterTag;

	public int PersonEventID;

	public string Title;

	private float i;

	public enum NewspaperItemType
	{
		Card = 1,
		CharacterTag,
		PersonEvent
	}
}
