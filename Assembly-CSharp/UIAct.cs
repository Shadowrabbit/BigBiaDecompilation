using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAct : MonoBehaviour
{
	private void Start()
	{
		GameController.getInstance().GameEventManager.OnCurrentActEndEvent += this.OnActEnd;
		GameController.getInstance().GameEventManager.OnCurrentActStartEvent += this.OnActStart;
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.AreaTable) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		if (this.m_Open)
		{
			return;
		}
		GameController.getInstance().EventalTable = (GameObject)UnityEngine.Object.Instantiate(Resources.Load(this.ActType));
		try
		{
			((GameObject)UnityEngine.Object.Instantiate(Resources.Load(this.ActModel))).transform.SetParent(GameController.getInstance().EventalTable.transform, false);
			this.m_Open = true;
		}
		catch
		{
			Debug.Log("当前ActTable加载失败");
		}
		GameController.getInstance().EventalTable.transform.SetParent(GameController.getInstance().Evental.transform, false);
	}

	private void OnActEnd()
	{
		this.m_Open = false;
	}

	private void OnActStart()
	{
		this.m_Open = true;
	}

	public string ActType;

	public string ActModel;

	private bool m_Open;
}
