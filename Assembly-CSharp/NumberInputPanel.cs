using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class NumberInputPanel : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		this.Text.text = this.Slider.value.ToString() + " (" + GameController.getInstance().GameData.Money.ToString() + ")";
	}

	private void OnEnable()
	{
		this.Slider.maxValue = (float)GameController.getInstance().GameData.Money;
		this.Slider.minValue = 0f;
	}

	public void SendToDialogSystem()
	{
		DialogueLua.SetVariable("InputMoney", this.Slider.value);
		Debug.Log(DialogueLua.GetVariable("InputMoney").asString);
		Sequencer.Message("InputMoney");
	}

	public Text Text;

	public Slider Slider;
}
