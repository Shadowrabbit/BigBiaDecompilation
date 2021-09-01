using System;
using UnityEngine;

public class GameEffectManager : MonoBehaviour
{
	private GameEffectManager()
	{
		GameEffectManager.Instance = this;
	}

	private void Start()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			this.CheckSlotPositionAndShowLogic(newCardSlot, card);
		}
	}

	public void CheckSlotPositionAndShowLogic(CardSlotData cardSlotData, CardData cardData)
	{
		int num = GameController.getInstance().PlayerSlotSets.Count / 3;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (GameController.getInstance().PlayerSlotSets[i] == cardSlotData)
			{
				int num2 = i / num;
				if (cardData.HasTag(TagMap.随从))
				{
					int num3 = 0;
					foreach (CardLogic cardLogic in cardData.CardLogics)
					{
						if (!string.IsNullOrEmpty(cardLogic.displayName))
						{
							num3++;
							if ((cardLogic.Color == (CardLogicColor)num2 || cardLogic.Color > CardLogicColor.yellow) && !string.IsNullOrEmpty(cardLogic.displayName))
							{
								string value;
								if (cardLogic.Color == CardLogicColor.blue)
								{
									value = "\n<color=#00d7ff>" + cardLogic.displayName + "</color>";
									string name = "Effect/Insight_blue";
									ParticlePoolManager.Instance.Spawn(name, 1f).transform.position = cardData.CardGameObject.transform.position;
								}
								else
								{
									string text = cardLogic.Color.ToString();
									if (text != null)
									{
										if (!(text == "red"))
										{
											if (text == "yellow")
											{
												string name2 = "Effect/Insight_yellow";
												ParticlePoolManager.Instance.Spawn(name2, 1f).transform.position = cardData.CardGameObject.transform.position;
											}
										}
										else
										{
											string name3 = "Effect/Insight_red";
											ParticlePoolManager.Instance.Spawn(name3, 1f).transform.position = cardData.CardGameObject.transform.position;
										}
									}
									value = string.Concat(new string[]
									{
										"\n<color=",
										cardLogic.Color.ToString(),
										">",
										cardLogic.displayName,
										"</color>"
									});
								}
								if (cardData != null && cardData.CardGameObject != null)
								{
									GameController.getInstance().ShowAmountText(cardData.CardGameObject.transform.position, value, Color.white, num3, false, false);
								}
							}
						}
					}
				}
			}
		}
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
	}

	public static GameEffectManager Instance;
}
