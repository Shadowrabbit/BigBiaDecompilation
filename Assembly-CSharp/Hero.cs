using System;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public GameEventManager GameEventManager
	{
		get
		{
			return this.GameController.GameEventManager;
		}
	}

	public CardData HeroCard
	{
		get
		{
			return this.GameController.GameData.PlayerCardData;
		}
	}

	public bool IsUseDirectionSkill
	{
		get
		{
			return this.CurrentDirectionSkill != null;
		}
	}

	public bool IsReleaseSkill { get; set; }

	private void Start()
	{
		this.InitSkillLine();
		this.RegistEvent();
	}

	private void InitSkillLine()
	{
		this.SkillLine = base.gameObject.AddComponent<LineRenderer>();
		if (this.SkillLine == null)
		{
			return;
		}
		this.SkillLine.startWidth = 0.1f;
		this.SkillLine.endWidth = 0f;
		this.SkillLine.startColor = Color.white;
		this.SkillLine.endColor = new Color(1f, 1f, 1f, 0f);
		this.SkillLine.positionCount = 0;
		this.SkillLine.SetPositions(new Vector3[0]);
		this.SkillLine.sortingOrder = 100;
		Material material = Resources.Load<Material>("Materials/SkillLine");
		if (material != null)
		{
			this.SkillLine.sharedMaterial = material;
		}
	}

	public void RegistEvent()
	{
		GameEventManager gameEventManager = this.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.PlayerGetCard));
		GameEventManager gameEventManager2 = this.GameEventManager;
		gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.PlayerRemoveCard));
	}

	public void UnRegistEvent()
	{
		GameEventManager gameEventManager = this.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.PlayerGetCard));
		GameEventManager gameEventManager2 = this.GameEventManager;
		gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.PlayerRemoveCard));
	}

	private void Update()
	{
		this.HandleSkill();
		this.UpdateSkillState();
	}

	private void UpdateSkillState()
	{
		this.WasInSkillTime = this.IsInSkillTime;
		this.IsInSkillTime = (this.IsUseDirectionSkill || this.IsReleaseSkill);
		if (this.IsInSkillTime)
		{
			this.skillState = SkillState.Releasing;
			return;
		}
		if (this.WasInSkillTime && !this.IsInSkillTime)
		{
			this.skillState = SkillState.Released;
			return;
		}
		this.skillState = SkillState.None;
	}

	public void HandleSkill()
	{
		if (this.CurrentDirectionSkill != null && !this.IsReleaseSkill)
		{
			this.HandleDirectionalSkill();
		}
	}

	public void HandleDirectionalSkill()
	{
		if (this.CurrentDirectionSkill.CardData == null)
		{
			this.ClearSkillLine();
			this.ClearMask();
			this.CurrentDirectionSkill = null;
			this.IsReleaseSkill = false;
			return;
		}
		Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Vector3.Distance(CameraUtils.MainCamera.transform.position, base.transform.position) - 4f);
		Vector3 endPos = CameraUtils.MainCamera.ScreenToWorldPoint(position);
		List<Vector3> bezierListAndDrawBezier = Bezier.GetBezierListAndDrawBezier(this.CurrentDirectionSkill.transform.position, endPos, 50, 0.2f, 5f, false);
		this.SkillLine.positionCount = bezierListAndDrawBezier.Count;
		this.SkillLine.SetPositions(bezierListAndDrawBezier.ToArray());
		RaycastHit hit;
		Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100f, 1 << LayerMask.NameToLayer("Slot"));
		if (hit.collider != null)
		{
			Vector3 centerPos = hit.collider.transform.position + new Vector3(0f, 0.5f, 0f);
			using (List<CardLogic>.Enumerator enumerator = this.CurrentDirectionSkill.CardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardLogic cardLogic = enumerator.Current;
					List<Vector3Int> attackExtraRange = this.CurrentDirectionSkill.CardData.AttackExtraRange;
					if (attackExtraRange != null)
					{
						GridIndicate.Instance.ShowGird(centerPos, attackExtraRange, 1f, true);
					}
				}
				goto IL_191;
			}
		}
		GridIndicate.Instance.HideGird();
		IL_191:
		if (Input.GetMouseButtonDown(1))
		{
			this.CancelDirectionalSkill();
		}
		if (Input.GetMouseButtonDown(0) && hit.collider != null)
		{
			this.ReleaseSkill(hit);
		}
	}

	private void OnGUI()
	{
	}

	public void PlayerGetCard(CardSlotData sourceSlot, CardData card)
	{
		if (this.GameController.IsPlayerCardSlotData(sourceSlot))
		{
			return;
		}
		if (!this.GameController.IsPlayerCardSlotData(card.CurrentCardSlotData))
		{
			return;
		}
		foreach (CardLogic cardLogic in card.CardLogics)
		{
			cardLogic.OnGetCard(this.HeroCard);
		}
		foreach (CardLogic cardLogic2 in this.HeroCard.CardLogics)
		{
			cardLogic2.OnPlayerGetCard(this.HeroCard, card);
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic3 in cardSlotData.ChildCardData.CardLogics)
				{
					cardLogic3.OnPlayerGetCard(this.HeroCard, card);
				}
			}
		}
	}

	public void PlayerRemoveCard(CardSlotData sourceSlot, CardData card)
	{
		if (!this.GameController.IsPlayerCardSlotData(sourceSlot))
		{
			return;
		}
		if (this.GameController.IsPlayerCardSlotData(card.CurrentCardSlotData))
		{
			return;
		}
		foreach (CardLogic cardLogic in card.CardLogics)
		{
			cardLogic.OnLoseCard(this.HeroCard);
		}
		foreach (CardLogic cardLogic2 in this.HeroCard.CardLogics)
		{
			cardLogic2.OnPlayerLoseCard(this.HeroCard, card);
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic3 in cardSlotData.ChildCardData.CardLogics)
				{
					cardLogic3.OnPlayerLoseCard(this.HeroCard, card);
				}
			}
		}
	}

	public void SetDirectionalSkill(CardData cardData)
	{
		if (this.CurrentDirectionSkill != null)
		{
			this.CancelDirectionalSkill();
		}
		if (!TagMapUtil.HasSkillTag(cardData))
		{
			return;
		}
		this.CurrentDirectionSkill = cardData.CardGameObject;
	}

	public void CancelDirectionalSkill()
	{
		if (this.CurrentDirectionSkill == null)
		{
			return;
		}
		foreach (CardLogic cardLogic in this.CurrentDirectionSkill.CardData.CardLogics)
		{
			cardLogic.OnCalcelUse();
		}
		this.ClearSkillLine();
		this.ClearMask();
		this.CurrentDirectionSkill = null;
		this.IsReleaseSkill = false;
	}

	public void ClearSkillLine()
	{
		this.SkillLine.positionCount = 0;
		this.SkillLine.SetPositions(new Vector3[0]);
		GridIndicate.Instance.HideGird();
	}

	public void ClearMask()
	{
		int num = 0;
		while (DungeonOperationMgr.Instance.BattleArea != null && num < DungeonOperationMgr.Instance.BattleArea.Count)
		{
			if (DungeonOperationMgr.Instance.BattleArea[num].ChildCardData != null)
			{
				DungeonOperationMgr.Instance.BattleArea[num].ChildCardData.CardGameObject.CanBeSelected = true;
			}
			num++;
		}
	}

	public void ReleaseSkill(RaycastHit hit)
	{
		CardSlot component = hit.collider.GetComponent<CardSlot>();
		this.TargetSlot = component;
		if (this.TargetSlot.ChildCard != null)
		{
			this.Target = this.TargetSlot.ChildCard.CardData;
		}
		bool flag = false;
		foreach (CardLogic cardLogic in this.CurrentDirectionSkill.CardData.CardLogics)
		{
			flag |= cardLogic.OnUse(null);
		}
		if (flag)
		{
			this.ClearSkillLine();
			this.ClearMask();
		}
	}

	public List<ExtraAttackData> GetExtraAttackDatas(CardData center)
	{
		List<ExtraAttackData> list = new List<ExtraAttackData>();
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
				{
					List<ExtraAttackData> extraAttackDatas = cardLogic.GetExtraAttackDatas(center, this.HeroCard);
					if (extraAttackDatas != null)
					{
						list.AddRange(extraAttackDatas);
					}
				}
			}
		}
		return list;
	}

	public void killEnemy(CardData cardData)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
				{
					cardLogic.OnKillEnemy(cardData);
				}
			}
		}
	}

	public void OnReleasedSkill()
	{
		this.CurrentDirectionSkill = null;
		this.IsReleaseSkill = false;
		this.Target = null;
		this.TargetSlot = null;
	}

	public bool IsEnoughMp(int mp)
	{
		return !this.ConsumeMp || this.HeroCard.MP >= mp;
	}

	private void OnDestroy()
	{
		this.UnRegistEvent();
	}

	public Card CurrentDirectionSkill;

	public LineRenderer SkillLine;

	public CardSlot TargetSlot;

	public CardData Target;

	public SkillState skillState;

	public bool ConsumeMp = true;

	private bool IsInSkillTime;

	private bool WasInSkillTime;
}
