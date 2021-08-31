using System;
using UnityEngine;

public class EffectAudioManager : MonoBehaviour
{
	private void Awake()
	{
		EffectAudioManager.Instance = this;
	}

	private void Start()
	{
		GlobalController.Instance.SetAudioSourceOutPutAudioGroup(this.AudioSource, AudioGroup.EFFECT);
	}

	public void PlayEffectAudio(int index = 2147483647, AudioSource source = null)
	{
		if (source == null)
		{
			this.EffectAudioEvent.Play(this.AudioSource, index);
			return;
		}
		this.EffectAudioEvent.Play(source, index);
	}

	public static EffectAudioManager Instance;

	public AudioSource AudioSource;

	public AudioEvent EffectAudioEvent;
}
