using System;
using System.Collections;

public class ShaKengCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "沙坑";
		this.Desc = base.Layers.ToString() + "回合后消失。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			if (base.Layers == 1)
			{
				this.CardData.CurrentCardSlotData.SlotType = CardSlotData.Type.Normal;
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, this.CardData, true, 0, true, false);
				yield break;
			}
			int layers = base.Layers;
			base.Layers = layers - 1;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData)
		{
			this.CardData.CurrentCardSlotData.SlotType = CardSlotData.Type.Normal;
			yield break;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		this.CardData.CurrentCardSlotData.SlotType = CardSlotData.Type.Normal;
		yield break;
	}

	private float debuff = 0.1f;
}
