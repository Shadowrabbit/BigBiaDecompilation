using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class BuildingCanvas : MonoBehaviour
{
	public void OnBianJi()
	{
		if (this.m_IsBianJi)
		{
			return;
		}
		this.m_IsBianJi = true;
		this.ShowItemsTrans.DOLocalMoveY(-540f, 0.5f, false);
		this.OnBuilding();
	}

	public void OnYunXing()
	{
		if (!this.m_IsBianJi)
		{
			return;
		}
		this.m_IsBianJi = false;
		this.ShowItemsTrans.DOLocalMoveY(-750f, 0.5f, false);
		this.BuildingArea.ChangeStateToBuidingElse();
		Cursor.SetCursor(this.DefaultCursor, Vector2.zero, CursorMode.Auto);
	}

	public void OnChongZhi()
	{
		if (this.m_IsBianJi)
		{
			return;
		}
		this.BuildingArea.ResetAnimation();
	}

	public void OnTuiChu()
	{
		GameController.ins.UIController.OnClickBackToHomeButton();
	}

	public void OnNext()
	{
		this.BuildingArea.NextPage();
	}

	public void OnPre()
	{
		this.BuildingArea.PrePage();
	}

	public void OnBuilding()
	{
		Cursor.SetCursor(this.DefaultCursor, Vector2.zero, CursorMode.Auto);
		this.BuildingArea.ChangeStateToBuilding();
		this.ShowItemsPanel.SetActive(true);
	}

	public void OnMove()
	{
		Cursor.SetCursor(this.MoveCursor, Vector2.zero, CursorMode.Auto);
		this.BuildingArea.ChangeStateToMove();
		this.ShowItemsPanel.SetActive(false);
	}

	public void OnBuildingDestroy()
	{
		Cursor.SetCursor(this.DestroyCursor, Vector2.zero, CursorMode.Auto);
		this.BuildingArea.ChangeStateToDestroy();
		this.ShowItemsPanel.SetActive(false);
	}

	public void ChangeTypeToQuanBu()
	{
		this.BuildingArea.LoadCards(8521215115264UL, 0);
		this.OnBuilding();
	}

	public void ChangeTypeToDiXing()
	{
		this.BuildingArea.LoadCards(274877906944UL, 0);
	}

	public void ChangeTypeToDaoLu()
	{
		this.BuildingArea.LoadCards(549755813888UL, 0);
	}

	public void ChangeTypeToJianZhu()
	{
		this.BuildingArea.LoadCards(1099511627776UL, 0);
	}

	public void ChangeTypeToJingGuan()
	{
		this.BuildingArea.LoadCards(2199023255552UL, 0);
	}

	public void ChangeTypeToTeShu()
	{
		this.BuildingArea.LoadCards(4398046511104UL, 0);
	}

	public void ChangeTypeToSuiCong()
	{
		this.BuildingArea.LoadCards(128UL, 0);
	}

	public void CloseTipPanel()
	{
		this.TipPanel.SetActive(false);
	}

	public TMP_Text MoneyText;

	public TMP_Text WealthText;

	public TMP_Text PersonText;

	public GameObject ShowItemsPanel;

	public Transform ShowItemsTrans;

	public BuildingArea BuildingArea;

	public List<BuildingDesc> Buildings;

	private bool m_IsBianJi;

	public Texture2D MoveCursor;

	public Texture2D DestroyCursor;

	public Texture2D DefaultCursor;

	public GameObject TipPanel;
}
