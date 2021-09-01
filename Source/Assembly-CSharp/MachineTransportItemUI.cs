using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MachineTransportItemUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.chooseCardData.Attrs.ContainsKey("TargetItem"))
		{
			this.chooseCardData.Attrs["TargetItem"] = this.CardData.ModID;
		}
		else
		{
			this.chooseCardData.Attrs.Add("TargetItem", this.CardData.ModID);
		}
		GameUIController.Instance.CloseUI(typeof(MachineTransportScreen));
		GameController.getInstance().GameEventManager.CurrentActEnd();
		UnityEngine.Object.DestroyImmediate(GameController.getInstance().CurrentAct.gameObject);
	}

	public CardData CardData;

	public CardData chooseCardData;
}
