using System;
using TMPro;
using UnityEngine;

public class COOPRoomPanel : MonoBehaviour
{
	private void Start()
	{
	}

	public void CancelRoom()
	{
		base.gameObject.SetActive(false);
	}

	public void StartGame()
	{
	}

	public void CreateRoom(MultiPlayerController.LobbyMsg p1)
	{
		this.P1 = p1;
		this.P1Name.text = this.P1.CreatorName;
		this.P1Image.SetActive(true);
	}

	public void JoinRoom(MultiPlayerController.LobbyMsg p1, MultiPlayerController.LobbyMsg p2)
	{
		this.P1 = p1;
		this.P1Name.text = this.P1.CreatorName;
		this.P1Image.SetActive(true);
		this.P2 = p2;
		this.P2Name.text = this.P2.CreatorName;
		this.P2Image.SetActive(true);
	}

	public TMP_Text P1Name;

	public TMP_Text P2Name;

	public GameObject P1Image;

	public GameObject P2Image;

	private MultiPlayerController.LobbyMsg P1;

	private MultiPlayerController.LobbyMsg P2;
}
