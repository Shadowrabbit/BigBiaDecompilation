using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using VoxelBuilder;

public class OACCController : MonoBehaviour
{
	private void Start()
	{
		this.curMoney = GameController.getInstance().GameData.Money;
		TicketController.Instance.CheckGameDateEquals();
	}

	public void AddItem(string guid, Action<bool> callBack)
	{
		if (Card.FindPutableSlotOnPlayerTable(0UL) != null)
		{
			WWWForm wwwform = new WWWForm();
			wwwform.AddField("status", this.status.ToString());
			wwwform.AddField("guid", guid);
			base.StartCoroutine(this.SendPost(OACCController.URL + "pixelAction_queryAll", wwwform, delegate(string x)
			{
				MatchItem matchItem = JsonConvert.DeserializeObject<MatchItem>(x);
				if (this.curMoney < matchItem.price)
				{
					Debug.Log("玩家金币不足，不能购买当前物品！");
					callBack(false);
					return;
				}
				callBack(true);
				this.CheckItemInShoppingCart(matchItem);
			}));
		}
	}

	public bool CheckHasPutableSlot()
	{
		return GameController.getInstance().HasEmptCardSlotOnPlayerTable() > this.ShoppingCart.Count;
	}

	public bool CheckEnoughMoney(int itemPrice)
	{
		return this.curMoney >= itemPrice;
	}

	public void AddItemToShoppingCart(MatchItem item)
	{
		this.CheckItemInShoppingCart(item);
	}

	private void CheckItemInShoppingCart(MatchItem item)
	{
		foreach (object[] array in this.ShoppingCart)
		{
			if (((MatchItem)array[0]).guid.Equals(item.guid))
			{
				array[1] = (int)array[1] + 1;
				this.curMoney -= item.price;
				return;
			}
		}
		if (this.CheckHasPutableSlot())
		{
			object[] item2 = new object[]
			{
				item,
				1
			};
			this.ShoppingCart.Add(item2);
			this.curMoney -= item.price;
			return;
		}
		GameController.getInstance().CreateSubtitle("当前没有足够的空间装载卡牌！购买失败！", 1f, 2f, 1f, 1f);
	}

	public void ViewDetails(string guid)
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("GUID", guid);
		base.StartCoroutine(this.SendPost("", wwwform, delegate(string x)
		{
		}));
	}

	public void CheckOut()
	{
		int num = 0;
		foreach (object[] array in this.ShoppingCart)
		{
			MatchItem matchItem = (MatchItem)array[0];
			this.CreateNewCustomCardFromOACC(matchItem);
			CardData customCardFile = new CustomCard().GetCustomCardFile(matchItem.guid, "这是一张自定义卡牌", (int)array[1], "DefaultCustomCard");
			if (!GameController.getInstance().CardDataModMap.Cards.Contains(customCardFile))
			{
				GameController.getInstance().CardDataModMap.Cards.Add(customCardFile);
			}
			Card.InitACardDataToPlayerTable(customCardFile);
			num += matchItem.price * (int)array[1];
		}
		GameController.getInstance().GameData.Money -= num;
		GameController.getInstance().GameEventManager.MoneyChange(GameController.getInstance().GameData.Money);
	}

	public void Vote(string guid, int id, int type = 0)
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("id", id);
		wwwform.AddField("steamID", SteamConstant.GetUserID().ToString());
		wwwform.AddField("status", this.status.ToString());
		if (type != 0)
		{
			if (type == 1)
			{
				wwwform.AddField("vote", 1);
			}
		}
		else
		{
			wwwform.AddField("vote", 0);
		}
		base.StartCoroutine(this.SendPost("http://59.110.49.146/PixelMatch/pixelAction_voteItem", wwwform, delegate(string x)
		{
			TicketController.Instance.AddTicket(guid);
		}));
	}

	private void CreateNewCustomCardFromOACC(MatchItem item)
	{
		VoxelBuilderCardData cardMessage = item.cardMessage;
		BuilderHelper.SaveFile(cardMessage.Name, cardMessage.Type, item.pixelContent, item.snapshot);
	}

	private IEnumerator SendPost(string _url, WWWForm _wForm, OACCController.WebRequestCallBack call)
	{
		UnityWebRequest request = UnityWebRequest.Post(_url, _wForm);
		yield return request.SendWebRequest();
		if (request.isHttpError || request.isNetworkError)
		{
			Debug.Log(request.error);
		}
		else
		{
			Debug.Log(request.downloadHandler.text);
			call(request.downloadHandler.text);
		}
		yield break;
	}

	public static string URL = "http://192.168.0.104:8080/PixelMatch/";

	private List<object[]> ShoppingCart = new List<object[]>();

	private int curMoney;

	public bool status;

	private delegate void WebRequestCallBack(string content);
}
