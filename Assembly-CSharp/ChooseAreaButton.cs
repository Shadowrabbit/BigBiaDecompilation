using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseAreaButton : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (this.m_Time > 0f)
		{
			this.m_Time -= Time.deltaTime;
		}
	}

	public void SetAreaMessage(string areaID, bool valid)
	{
		this.m_AreaID = areaID;
		this.valid = valid;
		this.SetMaterial();
	}

	public void SetValid(bool valid)
	{
		this.valid = valid;
		this.SetMaterial();
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.AreaTable) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		if (!this.valid)
		{
			if (this.m_Time <= 0f)
			{
				this.m_Time = this.m_CoolDown;
				GameController.getInstance().CreateSubtitle("你必须先拥有这处房产", 1f, 2f, 1f, 1f);
			}
			return;
		}
		GameUIController.Instance.OpenUI(typeof(ChooseAreaScreen), UIPathConstant.ChooseAreaScreen, 0, null);
	}

	private void SetMaterial()
	{
		if (this.material != null)
		{
			this.material.SetColor("_Color", this.valid ? Color.white : ChooseAreaButton.GrayColor);
		}
	}

	public static Color GrayColor = new Color(0.38039216f, 0.38039216f, 0.38039216f, 1f);

	public Material material;

	public bool valid;

	private float m_CoolDown = 2f;

	private float m_Time;

	private string m_AreaID;
}
