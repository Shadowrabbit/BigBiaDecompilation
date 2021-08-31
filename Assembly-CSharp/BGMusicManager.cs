using System;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
	private void Awake()
	{
		BGMusicManager.Instance = this;
	}

	private void Start()
	{
		GlobalController.Instance.SetAudioSourceOutPutAudioGroup(this.AudioSource, AudioGroup.BG);
	}

	public void PlayBGMusic(int index = 2147483647, int endIndex = 0, AudioSource source = null)
	{
		if (source == null)
		{
			this.BGAudioEvent.Play(this.AudioSource, index, endIndex);
			this.m_AudioSource = this.AudioSource;
		}
		else
		{
			this.BGAudioEvent.Play(source, index, endIndex);
			this.m_AudioSource = source;
		}
		this.m_StartIndex = index;
		this.m_EndIndex = endIndex;
	}

	private void FixedUpdate()
	{
		if (this.m_AudioSource != null && !this.m_AudioSource.isPlaying)
		{
			this.PlayBGMusic(this.m_StartIndex, this.m_EndIndex, this.m_AudioSource);
		}
	}

	public static BGMusicManager Instance;

	public AudioSource AudioSource;

	public BGAudioEvent BGAudioEvent;

	private int m_StartIndex;

	private int m_EndIndex;

	private AudioSource m_AudioSource;
}
