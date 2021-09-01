using System;
using System.Collections;

public class LostMemoryRobotCardLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
	}

	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		if (this.CardData.HasTag(TagMap.英雄))
		{
			yield break;
		}
		if (GameController.ins.GameData.EventStep != this.m_preStep)
		{
			this.step++;
			this.m_preStep = GameController.ins.GameData.EventStep;
		}
		if (this.step % 5 == 0 && !this.HasEnd)
		{
			CardData hero = base.GetHero();
			JournalsConversation journalsConversation = new JournalsConversation();
			JournalsConversationManager.role1 = this.CardData;
			JournalsConversationManager.role2 = hero;
			switch (this.count)
			{
			case 0:
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人1"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人2"), null));
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人3"), null));
				break;
			case 1:
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人4"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人5"), null));
				break;
			case 2:
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人6"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人7"), null));
				break;
			case 3:
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人8"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人9"), null));
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人10"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人11"), null));
				break;
			}
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
			ActData actData = new ActData();
			actData.Type = "Act/RobotRewards";
			actData.Model = "ActTable/营地商店";
			RobotRewardsAct robotRewardsAct = GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData) as RobotRewardsAct;
			switch (this.count)
			{
			case 0:
				robotRewardsAct.OptionNames.Add("坚固的身体");
				robotRewardsAct.OptionNames.Add("柔韧的身体");
				robotRewardsAct.OptionNames.Add("灵巧的身体");
				break;
			case 1:
				robotRewardsAct.OptionNames.Add("巨锤装置手臂");
				robotRewardsAct.OptionNames.Add("圆锯装置手臂");
				robotRewardsAct.OptionNames.Add("风扇装置手臂");
				break;
			case 2:
				robotRewardsAct.OptionNames.Add("防滑装置腿部");
				robotRewardsAct.OptionNames.Add("利刃装置腿部");
				robotRewardsAct.OptionNames.Add("滑轮装置腿部");
				break;
			case 3:
				robotRewardsAct.OptionNames.Add("路障核心");
				robotRewardsAct.OptionNames.Add("战斗核心");
				robotRewardsAct.OptionNames.Add("侦察核心");
				robotRewardsAct.OptionNames.Add("扫地核心");
				break;
			}
			this.count++;
			while (GameController.ins.CurrentAct != null)
			{
				yield return null;
			}
			if (this.count > 3)
			{
				this.HasEnd = true;
			}
		}
		yield break;
	}

	private int yellowBuff = 20;

	private int redBuff = 10;

	private int blueBuff1 = 6;

	private int blueBuff2 = 12;

	public int step;

	public int count;

	public bool HasEnd;

	public int m_preStep;
}
