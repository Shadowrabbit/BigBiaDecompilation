using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VoxelBuilder;

public class TestSub : MonoBehaviour
{
	public void Start()
	{
	}

	private void TestNextConversation()
	{
	}

	private void FixedUpdate()
	{
	}

	public IEnumerator ShowModel()
	{
		GameObject[] allMod = Resources.LoadAll<GameObject>("Area/");
		GameObject go = null;
		for (;;)
		{
			if (go != null)
			{
				UnityEngine.Object.Destroy(go);
			}
			go = UnityEngine.Object.Instantiate<GameObject>(allMod[UnityEngine.Random.Range(0, allMod.Length)]);
			go.transform.position = this.ShowPoint.position;
			go.transform.rotation = this.ShowPoint.rotation;
			yield return new WaitForSeconds(0.05f);
		}
		yield break;
	}

	private IEnumerator TestThrowMethod()
	{
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			yield return this.TestThrow();
			Debug.Log(i);
			num = i;
		}
		yield break;
	}

	private IEnumerator TestThrow()
	{
		yield return 0;
		Debug.Log("".Split(new char[]
		{
			'a'
		})[1]);
		yield break;
	}

	private IEnumerator FadeCoroutine()
	{
		yield return new WaitForSeconds(1f);
		GameObject copyGo = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
		UnityEngine.Object.Destroy(copyGo.GetComponent<TestSub>());
		new FadeModel(copyGo, 0.5f).HideModel();
		copyGo.transform.DOScale(Vector3.one * 1.2f, 0.5f).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(copyGo);
		});
		yield break;
	}

	private void Update()
	{
	}

	public void OnButtonShow(string name)
	{
		((GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/LogCanvas"))).GetComponent<LogPanel>().InitPanel(name);
	}

	public void AddLogContent(string name, string content)
	{
		LogBean logBean = new LogBean();
		logBean.Type = 3;
		logBean.CurName = name;
		logBean.LogContent = content;
		logBean.LogFormat = "<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>{2}";
		logBean.Day = 1;
		LoggerWriter.Instance.LogCache.Add(logBean);
	}

	public void AddLogContent(string name, string targetName, string content)
	{
		LogBean logBean = new LogBean();
		logBean.Type = 1;
		logBean.CurName = name;
		logBean.TarName = targetName;
		logBean.LogContent = content;
		logBean.LogFormat = "<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>{3}";
		logBean.Day = 1;
		LoggerWriter.Instance.LogCache.Add(logBean);
	}

	public void AddLogContent(string name, object target, string content)
	{
		LogBean logBean = new LogBean();
		logBean.Type = 2;
		logBean.CurName = name;
		logBean.TarName = ((Customer)target).name;
		logBean.LogContent = content;
		logBean.LogFormat = "<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>{3}";
		logBean.Day = 1;
		LoggerWriter.Instance.LogCache.Add(logBean);
	}

	public void AddLogContent(string name, string targetName, string itemname, int count, int coin)
	{
		LogBean logBean = new LogBean();
		logBean.Type = 0;
		logBean.CurName = name;
		logBean.TarName = targetName;
		logBean.ItemName = itemname;
		logBean.Count = count;
		logBean.Coin = coin;
		logBean.Day = 1;
		logBean.LogFormat = "<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>交易了{3:d}个{4}，获得了{5:d}个金币。";
		LoggerWriter.Instance.LogCache.Add(logBean);
	}

	public void AddLogs(int count)
	{
		for (int i = 0; i < count; i++)
		{
			LogBean logBean = new LogBean();
			logBean.Type = UnityEngine.Random.Range(0, 4);
			switch (logBean.Type)
			{
			case 0:
				logBean.Day = GameController.getInstance().GameData.Days;
				logBean.CurName = this.names[UnityEngine.Random.Range(0, this.names.Count)];
				logBean.TarName = this.names[UnityEngine.Random.Range(0, this.names.Count)];
				logBean.LogFormat = this.formats[0][UnityEngine.Random.Range(0, 2)];
				logBean.ItemName = this.items[UnityEngine.Random.Range(0, this.items.Count)];
				logBean.Count = UnityEngine.Random.Range(5, 10);
				logBean.Coin = logBean.Count * UnityEngine.Random.Range(5, 10);
				break;
			case 1:
			case 2:
			{
				logBean.Day = GameController.getInstance().GameData.Days;
				logBean.CurName = this.names[UnityEngine.Random.Range(0, this.names.Count)];
				logBean.TarName = this.names[UnityEngine.Random.Range(0, this.names.Count)];
				logBean.LogFormat = this.formats[1][0];
				List<string> list = this.contents[1];
				logBean.LogContent = list[UnityEngine.Random.Range(0, list.Count)];
				break;
			}
			case 3:
			{
				logBean.Day = GameController.getInstance().GameData.Days;
				logBean.CurName = this.names[UnityEngine.Random.Range(0, this.names.Count)];
				logBean.LogFormat = this.formats[3][0];
				List<string> list = this.contents[2];
				logBean.LogContent = list[UnityEngine.Random.Range(0, list.Count)];
				break;
			}
			}
			GameController.getInstance().GameEventManager.LogUpdate(logBean);
		}
		LoggerWriter.Instance.CreateAndWriteLogFile();
	}

	private void TestInitCustomCard(string cardName)
	{
		CardData customCardFile = new CustomCard().GetCustomCardFile(cardName, "这是一张自定义卡牌", 0, "DefaultCustomCard");
		CardSlot cardSlot = CardSlot.InitCardSlot(new CardSlotData
		{
			DisplayPositionX = 0f,
			DisplayPositionZ = 0f,
			SlotOwnerType = CardSlotData.OwnerType.Act
		}, 0.111f);
		cardSlot.transform.SetParent(base.transform, false);
		cardSlot.CardSlotData.SetChildCardData(customCardFile);
	}

	public void TestSubtitle()
	{
		GameController.getInstance().CreateSubtitle(this.contents[1][UnityEngine.Random.Range(0, this.contents[1].Count)], 1f, 2f, 1f, 1f);
	}

	public void TestGuide()
	{
		GameController.getInstance().ShowGuideCanvas(0, 12);
	}

	public void OpenList()
	{
		GameUIController.Instance.OpenUI(typeof(IllustratedScreen), UIPathConstant.IllustratedCanvas, 0, null);
	}

	public void PicMatch()
	{
		this.flag = 0;
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnterToPlayTheGame(new VoxelBuilderType[]
		{
			VoxelBuilderType.SmallPic,
			VoxelBuilderType.BigPic
		}));
	}

	public void CarvingMatch()
	{
		this.flag = 0;
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnterToPlayTheGame(new VoxelBuilderType[]
		{
			VoxelBuilderType.SmallStatue,
			VoxelBuilderType.BigStatue
		}));
	}

	public void MediumCarving()
	{
		this.flag = 1;
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnter(VoxelBuilderType.SmallStatue));
	}

	public void LargeCarving()
	{
		this.flag = 1;
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnter(VoxelBuilderType.BigStatue));
	}

	public void Pic()
	{
		this.flag = 1;
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnter(VoxelBuilderType.SmallPic));
	}

	private void OnDiyFinish(string fileName)
	{
		if (this.flag == 1)
		{
			if (fileName != null)
			{
				CardData customCardFile = new CustomCard().GetCustomCardFile(fileName, "这是一张自定义卡牌", 0, "DefaultCustomCard");
				GameController.getInstance().CardDataModMap.Cards.Add(customCardFile);
				Card.InitACardDataToPlayerTable(customCardFile);
			}
			UIController.LockLevel = UIController.UILevel.None;
		}
		GameController.getInstance().GameEventManager.CurrentActEnd();
	}

	[Header("要加载的自定义模型名")]
	public string CustomModelName;

	public VoxelBuilderMgr mgr;

	public Transform ShowPoint;

	private List<string> names = new List<string>
	{
		"未归城铁匠",
		"渔夫",
		"全体成员",
		"商人贾富",
		"不华镇长老"
	};

	private List<string> items = new List<string>
	{
		"矿石",
		"鱼钩",
		"柜子",
		"鲑鱼",
		"油",
		"铁剑",
		"床"
	};

	private Dictionary<int, List<string>> formats = new Dictionary<int, List<string>>
	{
		{
			0,
			new List<string>
			{
				"<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>交易了{3:d}个{4}，获得了{5:d}个金币。",
				"<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>在<color=red>[{2}]</color>购买了{3:d}个{4}，花费了{5:d}个金币。"
			}
		},
		{
			1,
			new List<string>
			{
				"<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>{3}"
			}
		},
		{
			2,
			new List<string>
			{
				"<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>{3}"
			}
		},
		{
			3,
			new List<string>
			{
				"<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>{2}"
			}
		}
	};

	private Dictionary<int, List<string>> contents = new Dictionary<int, List<string>>
	{
		{
			1,
			new List<string>
			{
				"就面貌丑陋的问题进行了深入的探讨，并借此无故羞辱了对方。",
				"互相打成一团。",
				"放学一起回家，并探讨明天考试的内容。",
				"组织了一个聚会",
				"共同喜欢上了同一个女孩，并为此大打出手。",
				"惬意地躺在夕阳的余晖之下，同时感叹逝去的青春。",
				"碰在一起窃窃私语，依稀可以听见他们要搞波大的。",
				"愉快地分手，并承诺下次见面必定杀死对方。",
				"决定去自杀，一个人终归会略显寂寞。",
				"合伙开了一家小卖部。",
				"发生了强烈的肢体冲突，因对方让其看到了真实的自我。"
			}
		},
		{
			2,
			new List<string>
			{
				"欢乐度+1。",
				"气势提升。",
				"掉进了井盖。",
				"正在无聊的乱逛。",
				"正在钓鱼。",
				"正在喝大酒。",
				"正在回家的路上。",
				"即兴创作了一首歌，并大声地唱了出来，这简直糟透了。",
				"对路过的女孩吹了声口哨。",
				"正在畅快地挖鼻子。",
				"失恋了。",
				"努力发散自己的脑电波并成功接通了阿尔法星球。",
				"在拉屎。"
			}
		}
	};

	private string path = Application.streamingAssetsPath + "/Mods/CustomCards/";

	private int flag;
}
