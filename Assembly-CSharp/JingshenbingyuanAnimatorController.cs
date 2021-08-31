using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class JingshenbingyuanAnimatorController : MonoBehaviour
{
	private void Start()
	{
		this.Animators[0].SetTrigger("Sitting");
		Lua.RegisterFunction("SetFalse", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(JingshenbingyuanAnimatorController)), methodof(JingshenbingyuanAnimatorController.SetFalse(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		string @string = PlayerPrefs.GetString("PatientName");
		if (!string.IsNullOrEmpty(@string))
		{
			this.SetFalse(@string);
		}
	}

	public void RemoveActor()
	{
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.PlayerSlot) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
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
			for (int i = 0; i < this.Animators.Count; i++)
			{
				if (collider == this.Animators[i].GetComponent<BoxCollider>())
				{
					GameController.getInstance().DialogueController.Actor = GameController.getInstance().PlayerToy;
					GameController.getInstance().DialogueController.Conversant = GameController.getInstance().PlayerToy;
					DialogueManager.StartConversation(this.Animators[i].gameObject.name, GameController.getInstance().GetComponent<Transform>(), base.GetComponent<Transform>());
				}
			}
		}
	}

	public void SetFalse(string name)
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (child.name.Equals(name))
			{
				child.gameObject.SetActive(false);
				PlayerPrefs.SetString("PatientName", name);
				return;
			}
		}
	}

	private void OnDestroy()
	{
		Lua.UnregisterFunction("SetFalse");
	}

	public List<Animator> Animators;
}
