using System;
using System.Collections;

public class Logic_BaiShi : TwoPeopleCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_157");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_157");
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		CardData cardByID = base.GetCardByID(this.TargetID);
		bool isAttack = this.CardData.IsAttacked;
		if (cardByID == user)
		{
			if (cardByID == this.CardData)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_拜师1"));
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
			CardLogic logic = this.AddLogic(origin.GetType().Name, origin.Layers);
			if (logic is FaithCardLogic)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_拜师2"));
				yield break;
			}
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_46"));
			yield return logic.OnUseSkill();
			this.CardData.CardLogics.Remove(logic);
			yield return logic.Terminate(this.CardData.CurrentCardSlotData);
			logic = null;
		}
		this.CardData.IsAttacked = isAttack;
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target != null && target == base.GetCardByID(this.TargetID))
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_拜师3"));
			this.CardData.RemoveCardLogic(this);
		}
		yield break;
	}

	private CardLogic AddLogic(string logicName, int layer = 0)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.CardData = this.CardData;
		cardLogic.Layers = layer;
		cardLogic.Init();
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
		return cardLogic;
	}
}
