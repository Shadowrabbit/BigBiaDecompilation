using System;
using TMPro;
using UnityEngine;

public class NoBoundarySpecialToy : MonoBehaviour
{
	private void Start()
	{
		this.IsStart = false;
		this.IsEnd = false;
		this.Gold = 100;
		this.originColor = this.TipText.color;
	}

	private void Update()
	{
		if (this.IsStart && !this.IsEnd)
		{
			this.DuringTime = Time.time - this.statTime;
			this.TimeText.text = this.DuringTime.ToString("0.00") + "s";
		}
		this.rand = UnityEngine.Random.Range(0f, 0.2f);
		this.TipText.color = this.originColor + new Color(0f, 0f, 0f, -this.rand);
		this.rand = UnityEngine.Random.Range(0f, 0.2f);
		this.GoldText.color = this.originColor + new Color(0f, 0f, 0f, -this.rand);
		this.GoldText.text = this.Gold.ToString();
	}

	public void OnGameFail()
	{
		this.IsEnd = true;
		this.Gold = 0;
		this.TipText.text = "糟糕！你输了^_^\n按下红色按钮空手离开吧~";
	}

	public void OnGameWin()
	{
		this.IsEnd = true;
		this.TipText.text = string.Concat(new string[]
		{
			"恭喜你完成了挑战！\n基础的得分：",
			this.Gold.ToString(),
			"；时间奖励：",
			((int)(37f - this.DuringTime)).ToString(),
			"；共可以获得",
			(this.Gold + (int)(37f - this.DuringTime)).ToString(),
			"个金币的奖励，按下红色按钮拿钱走人吧~"
		});
		this.Gold += (int)(37f - this.DuringTime);
	}

	public void OnEnd()
	{
		DungeonOperationMgr.Instance.ChangeMoney(this.Gold);
		AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
		GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
		GameController.getInstance().OnTableChange(parentArea, true);
	}

	public bool IsStart;

	public bool IsEnd;

	public TextMeshProUGUI TipText;

	public float statTime;

	public float DuringTime;

	public TextMeshProUGUI TimeText;

	public int Gold;

	public TextMeshProUGUI GoldText;

	private float rand;

	private Color originColor;
}
