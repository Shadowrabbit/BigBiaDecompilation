using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class LogController : MonoBehaviour
{
	private void Start()
	{
		LoggerWriter.Instance.InitLogContent();
		GameController.getInstance().GameEventManager.OnLogUpdateEvent += this.OnLogUpdate;
		Lua.RegisterFunction("ShowLogPanel", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(LogController)), methodof(LogController.ShowLogPanel()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
	}

	private void OnDestroy()
	{
		LoggerWriter.Instance.ClearLogCache();
		GameController.getInstance().GameEventManager.OnLogUpdateEvent -= this.OnLogUpdate;
		Lua.UnregisterFunction("ShowLogPanel");
	}

	private void ShowLogPanel()
	{
		GameUIController.Instance.OpenUI(typeof(LogPanelScreen), UIPathConstant.LogCanvas, 0, null);
	}

	private void OnLogUpdate(LogBean log)
	{
		LoggerWriter.Instance.LogCache.Add(log);
	}

	public void AddNewLog(string originName, string targetName, string content, TeZhi.TezhiType type)
	{
		LogBean logBean = new LogBean();
		if (type < (TeZhi.TezhiType)20000)
		{
			logBean.Type = 3;
		}
		else
		{
			logBean.Type = 2;
		}
		int type2 = logBean.Type;
		if (type2 > 2)
		{
			if (type2 == 3)
			{
				logBean.Day = GameController.getInstance().GameData.Days;
				logBean.CurName = originName;
				logBean.LogFormat = "<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>{2}";
				logBean.LogContent = content + this.extraContents[2][SYNCRandom.Range(0, this.extraContents[2].Count)];
			}
		}
		else
		{
			logBean.Day = GameController.getInstance().GameData.Days;
			logBean.CurName = originName;
			logBean.TarName = targetName;
			logBean.LogFormat = "<color=blue>[第{0}天]</color>:<color=green>[{1}]</color>与<color=red>[{2}]</color>{3}";
			logBean.LogContent = content;
		}
		GameController.getInstance().GameEventManager.LogUpdate(logBean);
		LoggerWriter.Instance.CreateAndWriteLogFile();
	}

	public void ClearCurLog()
	{
		LoggerWriter.Instance.ClearLog();
	}

	private Dictionary<int, List<string>> extraContents = new Dictionary<int, List<string>>
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
}
