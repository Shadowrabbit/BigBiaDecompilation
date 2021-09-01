using System;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CancelGameButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		if ((UIController.UILevel.PlayerSlot & UIController.LockLevel) > UIController.UILevel.None)
		{
			return;
		}
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		this.CancelGamePanel.SetActive(true);
	}

	public void ClosePanel()
	{
		this.CancelGamePanel.SetActive(false);
		UIController.LockLevel = this.m_Lock;
	}

	public void TrueBtn()
	{
		if (VSModeController.Instance != null)
		{
			CSteamID currentLobbyID = VSModeController.Instance.CurrentLobbyID;
			EffectAudioManager.Instance.PlayEffectAudio(6, null);
			VSModeController.Instance.LeaveLobby();
			UnityEngine.Object.DestroyImmediate(VSModeController.Instance.gameObject);
			UnityEngine.Object.DestroyImmediate(VSModeController.Instance);
			SceneManager.LoadScene("Battle");
			UIController.LockLevel = UIController.UILevel.None;
			return;
		}
		this.CancelGamePanel.SetActive(false);
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				cardSlotData.ChildCardData.UnHappy += 50;
				if (cardSlotData.ChildCardData.UnHappy > 100)
				{
					cardSlotData.ChildCardData.UnHappy = 100;
				}
			}
		}
		GameController.ins.StartCoroutine(DungeonController.Instance.GameOver(false));
	}

	public GameObject CancelGamePanel;

	private UIController.UILevel m_Lock;
}
