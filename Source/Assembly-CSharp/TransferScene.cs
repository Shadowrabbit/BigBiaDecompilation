using System;
using UnityEngine;
using UnityEngine.Playables;

public class TransferScene : MonoBehaviour
{
	private void Start()
	{
		this.playableDirector.stopped += this.UnloadScene;
	}

	private void Update()
	{
	}

	private void UnloadScene(PlayableDirector director)
	{
		Debug.Log("222");
	}

	private void OnDestroy()
	{
		this.playableDirector.stopped -= this.UnloadScene;
	}

	public PlayableDirector playableDirector;
}
