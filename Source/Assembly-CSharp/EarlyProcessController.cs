using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class EarlyProcessController : MonoBehaviour
{
	private void Start()
	{
		Lua.RegisterFunction("StartConver", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.StartConver()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("InTheForest", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.InTheForest()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("InTheRiver", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.InTheRiver()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("InTheGrassland", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.InTheGrassland()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("InTheMine", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.InTheMine()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("MobileUp", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.MobileUp()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("RecruitSuccess", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(EarlyProcessController)), methodof(EarlyProcessController.RecruitSuccess(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent += this.Collected;
		GameController.getInstance().GameEventManager.OnEarlyProcessTaskEvent += this.EarlyProcessTask;
		GameController.getInstance().GameEventManager.OnEnterAreaEvent += this.OnEnterArea;
		if (PlayerPrefs.GetInt(this.GuideProcess[0]) == 0)
		{
			GameController.getInstance().ShowGuideCanvas(0, 2);
			PlayerPrefs.SetInt(this.GuideProcess[0], 1);
		}
		base.StartCoroutine(this.StartMobileAnimation(""));
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit);
			if (raycastHit.collider == this.MobileCollider)
			{
				if (!this.isAnimation)
				{
					return;
				}
				this.MobileDown();
				if (GameController.getInstance().GetTask(this.earlyTaskList[this.taskIndex]) != null)
				{
					if (GameController.getInstance().GetTask(this.earlyTaskList[this.taskIndex]).State == TaskState.ACTIVE)
					{
						DialogueManager.StartConversation(this.earlyTaskList[this.taskIndex]);
					}
					else if (GameController.getInstance().GetTask(this.earlyTaskList[this.taskIndex]).State == TaskState.SUCCESS)
					{
						if (this.taskIndex < this.earlyTaskList.Count)
						{
							GameController.getInstance().GetTask(this.earlyTaskList[this.taskIndex]).State = TaskState.INACTIVE;
							DialogueManager.StartConversation(this.earlyTaskList[this.taskIndex]);
						}
						else
						{
							DialogueManager.StartConversation(this.randomTalkList[UnityEngine.Random.Range(0, this.randomTalkList.Count)]);
						}
					}
					else
					{
						DialogueManager.StartConversation(this.randomTalkList[UnityEngine.Random.Range(0, this.randomTalkList.Count)]);
					}
				}
				else
				{
					if (!this.doNotProcess)
					{
						DialogueManager.StartConversation(this.randomTalkList[UnityEngine.Random.Range(0, this.randomTalkList.Count)]);
						return;
					}
					DialogueManager.StartConversation(this.earlyTaskList[this.taskIndex]);
					this.taskIndex++;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			GameController.getInstance().ShowGuideCanvas(0, GameController.getInstance().GuideCanvas.SpriteList.Count - 1);
		}
	}

	private IEnumerator StartThread()
	{
		yield return null;
		yield break;
	}

	private IEnumerator StartMobileAnimation(string conversationName = "")
	{
		yield return new WaitForSeconds(1f);
		this.MobileUp();
		if (!conversationName.Equals(""))
		{
			DialogueManager.StartConversation(conversationName);
		}
		yield break;
	}

	private void StartConver()
	{
		GameController.getInstance().GiveACard("工具台");
	}

	private void MobileUp()
	{
		this.isAnimation = true;
		this.MobileTrans.GetComponent<Animator>().SetBool("OnCalling", true);
		this.isCalling = true;
	}

	private void MobileDown()
	{
		if (!this.isCalling)
		{
			return;
		}
		this.isAnimation = false;
		this.MobileTrans.GetComponent<Animator>().SetBool("OnCalling", false);
		this.isCalling = false;
	}

	private void InTheForest()
	{
		if (PlayerPrefs.GetInt(this.GuideProcess[1]) == 0)
		{
			GameController.getInstance().ShowGuideCanvas(3, 5);
			PlayerPrefs.SetInt(this.GuideProcess[1], 1);
		}
		GameController.getInstance().GiveACard("树林");
	}

	private void InTheRiver()
	{
		GameController.getInstance().GiveACard("小溪");
	}

	private void InTheGrassland()
	{
		GameController.getInstance().GiveACard("空地");
	}

	private void InTheMine()
	{
		GameController.getInstance().GiveACard("矿山");
	}

	private void RecruitSuccess(string modID)
	{
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(modID);
		GameController.getInstance().GameEventManager.RoleBeRecruit(cardDataByModID);
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent -= this.Collected;
		GameController.getInstance().GameEventManager.OnEarlyProcessTaskEvent -= this.EarlyProcessTask;
		GameController.getInstance().GameEventManager.OnEnterAreaEvent -= this.OnEnterArea;
		Lua.UnregisterFunction("InTheMine");
		Lua.UnregisterFunction("InTheGrassland");
		Lua.UnregisterFunction("InTheRiver");
		Lua.UnregisterFunction("InTheForest");
		Lua.UnregisterFunction("StartConver");
		Lua.UnregisterFunction("MobileUp");
	}

	private CardData GetCardData(string fileName)
	{
		string text = Application.streamingAssetsPath + "/Mods/Cards/空间";
		if (Directory.Exists(text))
		{
			string value = File.ReadAllText(text + "/" + fileName + ".json", Encoding.UTF8);
			CardData cardData = JsonConvert.DeserializeObject(value, new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.All
			}) as CardData;
			if (cardData == null)
			{
				cardData = (JsonConvert.DeserializeObject(value, typeof(CardData)) as CardData);
			}
			return cardData;
		}
		return null;
	}

	private void Collected(CardSlot oldCardSlot, CardSlot newCardSlot, Card card)
	{
		GameController.getInstance().GameEventManager.ItemBeCollectied(card.CardData.Name, card.CardData.Count);
	}

	private void EarlyProcessTask(TaskData task)
	{
		if (this.taskIndex <= this.earlyTaskList.Count)
		{
			if (!string.IsNullOrEmpty(task.Conversations[task.State].Conversation))
			{
				DialogueManager.StartConversation(task.Conversations[task.State].Conversation);
			}
			if (this.taskIndex == this.earlyTaskList.Count)
			{
				this.doNotProcess = false;
				this.isAnimation = true;
				this.taskIndex = 0;
				return;
			}
			base.StartCoroutine(this.StartMobileAnimation(""));
		}
	}

	public void CreateNewTasks(List<string> taskNames)
	{
		this.doNotProcess = true;
		this.taskIndex = 0;
		this.earlyTaskList = taskNames;
		base.StartCoroutine(this.StartMobileAnimation(""));
	}

	public void ResetGuideProcess()
	{
		PlayerPrefs.DeleteAll();
	}

	private void OnEnterArea(string areaId)
	{
		if (areaId != null)
		{
			if (!(areaId == "篝火"))
			{
				if (!(areaId == "小溪"))
				{
					if (!(areaId == "情境战斗空间"))
					{
						if (!(areaId == "蛇国"))
						{
							return;
						}
						if (PlayerPrefs.GetInt("蛇国") == 0)
						{
							GameController.getInstance().ShowGuideCanvas(18, 18);
							PlayerPrefs.SetInt("蛇国", 1);
						}
					}
					else if (PlayerPrefs.GetInt("情境战斗空间") == 0)
					{
						GameController.getInstance().ShowGuideCanvas(17, 17);
						PlayerPrefs.SetInt("情境战斗空间", 1);
						return;
					}
				}
				else if (PlayerPrefs.GetInt("小溪") == 0)
				{
					GameController.getInstance().ShowGuideCanvas(16, 16);
					PlayerPrefs.SetInt("小溪", 1);
					return;
				}
			}
			else if (PlayerPrefs.GetInt("篝火") == 0)
			{
				GameController.getInstance().ShowGuideCanvas(15, 15);
				PlayerPrefs.SetInt("篝火", 1);
				return;
			}
		}
	}

	private IEnumerator CardFly(string name)
	{
		CardData cardData = Card.InitCardDataByID(name);
		GameObject cardBottom = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(this.GetRare(cardData)));
		cardBottom.transform.position = base.transform.position + new Vector3(0f, 3f, 0f);
		GameObject cardModel = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(cardData.Model));
		cardModel.transform.SetParent(cardBottom.transform, false);
		yield return null;
		cardModel.transform.DOMove(new Vector3(-0.4f, 3f, -1.54f), 1f, false).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(cardBottom);
			Card.InitACardDataToPlayerTable(cardData);
		});
		yield break;
	}

	public string GetRare(CardData data)
	{
		string result = "CardBottom/NBottom";
		switch (data.Rare)
		{
		case 2:
			result = "CardBottom/RBottom";
			break;
		case 3:
			result = "CardBottom/SRBottom";
			break;
		case 4:
			result = "CardBottom/SSRBottom";
			break;
		case 5:
			result = "CardBottom/SSSRBottom";
			break;
		}
		return result;
	}

	public BoxCollider MobileCollider;

	public Transform MobileTrans;

	private List<string> earlyTaskList = new List<string>
	{
		"探索树林",
		"制作鱼竿",
		"制作烤鱼",
		"招募随从",
		"初试战斗"
	};

	private List<string> randomTalkList = new List<string>
	{
		"大哥大",
		"闲谈"
	};

	private List<string> GuideProcess = new List<string>
	{
		"初入游戏",
		"接完第一通电话",
		"第一次打开工具桌",
		"伐木",
		"第一次打开制图机",
		"篝火",
		"小溪",
		"情境战斗空间"
	};

	private int taskIndex;

	private bool doNotProcess = true;

	private bool isAnimation;

	private bool isCalling;
}
