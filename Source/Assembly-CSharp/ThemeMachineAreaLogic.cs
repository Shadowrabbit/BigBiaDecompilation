using System;
using System.Collections;
using System.Collections.Generic;

public class ThemeMachineAreaLogic : AreaLogic
{
	public object GetCardAttr(CardData cs, string name)
	{
		if (cs.Attrs.ContainsKey(name))
		{
			if (cs.Attrs[name] != null)
			{
				return cs.Attrs[name];
			}
			if (cs.HiddenAttrs[name] != null)
			{
				return cs.HiddenAttrs[name];
			}
		}
		return 1;
	}

	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		UIController.LockLevel = UIController.UILevel.None;
		using (List<CardSlotData>.Enumerator enumerator = base.Data.CardSlotDatas.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cardSlotData = enumerator.Current;
				cardSlotData.CardSlotGameObject.SetBorder(1);
				cardSlotData.CardSlotGameObject.SetIcon(9);
				cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
			}
			yield break;
		}
		yield break;
	}
}
