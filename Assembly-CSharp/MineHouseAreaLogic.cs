using System;
using System.Collections;
using UnityEngine;

public class MineHouseAreaLogic : AreaLogic
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
		base.Data.CardSlotDatas[0].ChildCardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("铜矿"), true);
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
		UIController.LockLevel = this.m_Lock;
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && card.ModID.Equals("时间卡片"))
		{
			this.m_StartTimer = this.StartTimer(card);
			GameController.getInstance().StartCoroutine(this.StartTimer(card));
		}
		if (newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && card.ModID.Equals("时间卡片") && this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
			base.Data.Attrs["Percent"] = int.Parse(base.Data.Attrs["Percent"].ToString()) - int.Parse(base.Data.Attrs["Percent"].ToString()) % 10;
		}
	}

	private IEnumerator StartTimer(CardData card)
	{
		int t = 0;
		for (;;)
		{
			int num = t;
			t = num + 1;
			if (card.Count <= 0)
			{
				goto IL_13C;
			}
			if (base.Data.Attrs.ContainsKey("Percent"))
			{
				base.Data.Attrs["Percent"] = int.Parse(base.Data.Attrs["Percent"].ToString()) + 1;
				string str = "$$$$$$$$$$$$$$$$$$$$$$========> 鱼屋进度：";
				object obj = base.Data.Attrs["Percent"];
				Debug.Log(str + ((obj != null) ? obj.ToString() : null));
				if (int.Parse(base.Data.Attrs["Percent"].ToString()) > 99)
				{
					break;
				}
			}
			if (t % 10 == 0)
			{
				card.Count--;
			}
			yield return new WaitForSeconds(0.1f);
		}
		card.Count--;
		this.StartGiftAct("寿司,披萨,汉堡,生命药水", card.CardGameObject);
		yield break;
		IL_13C:
		Debug.Log("$$$$$$$$$$$$$$$$$$$$$$========> 鱼屋删除");
		card.DeleteCardData();
		yield break;
		yield break;
	}

	private void StartGiftAct(string Values, Card card)
	{
		GiftAct giftAct = card.StartAct(new ActData
		{
			Type = "Act/Gift",
			Model = "ActTable/Gift"
		}) as GiftAct;
		if (Values != "")
		{
			string[] array = Values.Split(new char[]
			{
				','
			});
			if (array.Length != 0)
			{
				int num = UnityEngine.Random.Range(0, array.Length);
				giftAct.GiftNames.Add(array[num]);
				Debug.Log("$$$$$$$$$$$$$$$$$$$$$$========> 鱼屋赠礼：" + array[num]);
			}
		}
	}

	private CardSlotData GetEmptySlotFromPlayerTable()
	{
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (i % 13 < 9 && GameController.getInstance().PlayerSlotSets[i].ChildCardData == null && GameController.getInstance().PlayerSlotSets[i].TagWhiteList == 128UL)
			{
				return GameController.getInstance().PlayerSlotSets[i];
			}
		}
		return null;
	}

	private CardSlotData m_SlotData;

	private UIController.UILevel m_Lock = UIController.UILevel.All;

	private IEnumerator m_StartTimer;
}
