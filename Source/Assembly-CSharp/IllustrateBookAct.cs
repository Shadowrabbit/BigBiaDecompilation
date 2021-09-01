using System;
using UnityEngine.SceneManagement;

public class IllustrateBookAct : GameAct
{
	private void Start()
	{
		EffectAudioManager.Instance.PlayEffectAudio(8, null);
		SceneManager.LoadScene("CardsCollection", LoadSceneMode.Additive);
		this.ActEnd();
	}

	private void Update()
	{
	}
}
