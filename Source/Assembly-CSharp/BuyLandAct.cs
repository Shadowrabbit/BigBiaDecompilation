using System;
using UnityEngine;

public class BuyLandAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (GameController.getInstance().GameData.Money >= 5)
		{
			GameController.getInstance().GameData.Money -= 5;
			GameController.getInstance().GameEventManager.MoneyChange(GameController.getInstance().GameData.Money);
			Toy toy = this.Source as Toy;
			if (toy.ParentArea.Attrs.ContainsKey("Owner"))
			{
				toy.ParentArea.Attrs["Owner"] = "Player";
			}
			else
			{
				toy.ParentArea.Attrs.Add("Owner", "Player");
			}
			UnityEngine.Object.Destroy((this.Source as Toy).transform.parent.parent.GetComponentInChildren<InvaliBuildButton>().gameObject, 0f);
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/建造"));
			gameObject.transform.position = new Vector3(13.21f, 0f, -9f);
			gameObject.transform.SetParent(this.Source.transform.parent.parent.transform, false);
			toy.transform.parent.parent.GetComponentInChildren<ChooseAreaButton>().SetValid(true);
			GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].Toys.Remove((this.Source as Toy).CardData);
			toy.DeleteCard();
		}
		else
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_20"), 1f, 2f, 1f, 1f);
		}
		UIController.LockLevel = UIController.UILevel.None;
		this.ActEnd();
	}

	private void Update()
	{
	}
}
