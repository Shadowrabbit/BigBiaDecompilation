using System;
using TMPro;
using UnityEngine;

public class DodgingSpecialToy : MonoBehaviour
{
	private void Start()
	{
		this.StartMouseControl = false;
		this.PointText.text = GlobalController.Instance.GlobalData.HighestPointsOfDodging.ToString("0.00") + "s";
		this.originColor = this.PointTipText.color;
	}

	private void Update()
	{
		this.TimeText.text = this.DodgingMainPart.DuringTime.ToString("0.00") + "s";
		float num = UnityEngine.Random.Range(0f, 0.2f);
		this.TimeTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		this.TimeText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		this.StartTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		num = UnityEngine.Random.Range(0f, 0.2f);
		this.PointTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		this.PointText.color = this.originColor + new Color(0f, 0f, 0f, -num);
	}

	public void OnDodgingEndButton()
	{
		if (this.DodgingMainPart.isEnd && !this.isCompleted)
		{
			this.isCompleted = true;
			DungeonOperationMgr.Instance.ChangeMoney(Mathf.CeilToInt(5f * this.DodgingMainPart.DuringTime));
			AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
			GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
			GameController.getInstance().OnTableChange(parentArea, true);
		}
	}

	public DodgingMainPart DodgingMainPart;

	public bool StartMouseControl;

	public bool isCompleted;

	public TextMeshProUGUI PointTipText;

	public TextMeshProUGUI PointText;

	public TextMeshProUGUI TimeTipText;

	public TextMeshProUGUI TimeText;

	public TextMeshProUGUI StartTipText;

	private Color originColor;
}
