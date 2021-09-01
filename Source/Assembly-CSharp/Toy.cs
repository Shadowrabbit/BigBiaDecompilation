using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Toy : Card
{
	public override void Init()
	{
		base.Init();
		this.AlwaysShowTipsPanel.gameObject.SetActive(false);
		GameController.getInstance().GameEventManager.OnDayPassEvent += this.OnDayPass;
	}

	public void Init(CardData data)
	{
		base.SetCardData(data);
		this.Init();
	}

	public override void OnClick()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.AreaTable) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		if (this.CurrentCardSlot.CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Area)
		{
			return;
		}
		GameUIController.Instance.CloseTips();
		if (base.CardData.HasConversation())
		{
			GameController.getInstance().GameEventManager.OpenGameUI();
			this.StartDialogue("");
		}
	}

	public void UpdateAlwaysShowTips(string Content)
	{
		if (!string.IsNullOrEmpty(Content))
		{
			this.AlwaysShowTipsPanel.SetActive(true);
			this.AlwaysShowTipsPanel.GetComponentInChildren<TextMeshProUGUI>().SetText(Content, true);
			RectTransform[] componentsInChildren = this.AlwaysShowTipsPanel.GetComponentsInChildren<RectTransform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[i]);
			}
			return;
		}
		this.AlwaysShowTipsPanel.SetActive(false);
	}

	public void StartDialogue(string conversation = "")
	{
		if (string.IsNullOrEmpty(conversation))
		{
			conversation = base.CardData.Name;
		}
		GameController.getInstance().DialogueController.Actor = GameController.getInstance().PlayerToy;
		GameController.getInstance().DialogueController.Conversant = this;
		DialogueLua.SetVariable("CurrentCharacterID", base.CardData.Name);
		DialogueManager.StartConversation(conversation, GameController.getInstance().GetComponent<Transform>(), base.GetComponent<Transform>());
	}

	public void OnConversationEnd(Transform actor)
	{
		Debug.Log(string.Format("Ending conversation with {0}", actor.name));
	}

	public static Toy CreateToy(CardData cardData, CardSlot cardSlot = null)
	{
		Toy component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Toy")).GetComponent<Toy>();
		component.Init(cardData);
		if (cardSlot != null)
		{
			component.PutInSlot(cardSlot);
		}
		return component;
	}

	private void OnDayPass()
	{
		using (Dictionary<string, object>.KeyCollection.Enumerator enumerator = base.CardData.Attrs.Keys.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Equals("Gifted"))
				{
					base.CardData.Attrs["Gifted"] = false;
					break;
				}
			}
		}
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnDayPassEvent -= this.OnDayPass;
	}

	public Text DisplayName;

	[NonSerialized]
	public AreaData ParentArea;

	public GameObject AlwaysShowTipsPanel;
}
