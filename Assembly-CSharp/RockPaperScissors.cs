using System;
using TMPro;
using UnityEngine;

public class RockPaperScissors : MonoBehaviour
{
	private void Start()
	{
		this.RockButton = base.GetComponentInChildren<RockButton>();
		this.RockButton.RockPaperScissors = this;
		this.PaperButton = base.GetComponentInChildren<PaperButton>();
		this.PaperButton.RockPaperScissors = this;
		this.ScissorsButton = base.GetComponentInChildren<ScissorsButton>();
		this.ScissorsButton.RockPaperScissors = this;
		this.Gold = 0;
		this.originColor = this.TipText.color;
		this.isStart = false;
		this.isEnd = false;
	}

	private void Update()
	{
		if (this.isStart && !this.isEnd)
		{
			this.DuringTime = Time.time - this.statTime;
			this.TimeText.text = this.DuringTime.ToString("0.00") + "s";
		}
		float num = UnityEngine.Random.Range(0f, 0.2f);
		this.TipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		if (this.DuringTime >= 10f && !this.isEnd)
		{
			this.isEnd = true;
			this.TimeText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_石头剪刀布2");
			this.GameSprite.sprite = null;
			this.TipText.text = string.Format(LocalizationMgr.Instance.GetLocalizationWord("WJ_石头剪刀布3"), this.Gold);
		}
	}

	public void OnButtonDown(int buttonNum)
	{
		this.ClickAudio.Play();
		if (!this.isStart)
		{
			this.currentNum = UnityEngine.Random.Range(0, 3);
			this.GameSprite.sprite = this.Sprites[this.currentNum];
			this.statTime = Time.time;
			this.isStart = true;
			return;
		}
		if (this.isEnd && !this.isBtnDown)
		{
			DungeonOperationMgr.Instance.ChangeMoney(this.Gold);
			this.OnRockPaperScissorsEnd();
			this.isBtnDown = true;
		}
		if ((this.currentNum == 0 && buttonNum == 2) || (this.currentNum == 1 && buttonNum == 0) || (this.currentNum == 2 && buttonNum == 1))
		{
			this.Gold += 12;
			this.GoldText.text = this.Gold.ToString();
			int num;
			for (num = UnityEngine.Random.Range(0, 3); num == this.currentNum; num = UnityEngine.Random.Range(0, 3))
			{
			}
			this.currentNum = num;
			this.GameSprite.sprite = this.Sprites[this.currentNum];
			return;
		}
		this.isEnd = true;
		this.Gold = 0;
		this.TimeText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_石头剪刀布2");
		this.GameSprite.sprite = null;
		this.TipText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_石头剪刀布4");
	}

	public void OnRockPaperScissorsEnd()
	{
		AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
		GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
		GameController.getInstance().OnTableChange(parentArea, true);
	}

	public RockButton RockButton;

	public PaperButton PaperButton;

	public ScissorsButton ScissorsButton;

	public TextMeshProUGUI TipText;

	public float DuringTime;

	public TextMeshProUGUI TimeText;

	public int Gold;

	public TextMeshProUGUI GoldText;

	public Sprite[] Sprites;

	public SpriteRenderer GameSprite;

	public AudioSource ClickAudio;

	private bool isStart;

	private bool isEnd;

	private float statTime;

	private int currentNum;

	private Color originColor;

	private bool isBtnDown;
}
