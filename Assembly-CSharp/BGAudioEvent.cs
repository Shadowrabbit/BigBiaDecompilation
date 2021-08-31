using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/BGMusicEvent")]
public class BGAudioEvent : ScriptableObject
{
	public void Play(AudioSource source, int startIndex, int endIndex = 0)
	{
		if (this.Clips.Length == 0)
		{
			return;
		}
		if (endIndex != 0)
		{
			source.clip = this.Clips[UnityEngine.Random.Range(startIndex, endIndex + 1)];
		}
		else
		{
			source.clip = this.Clips[startIndex];
		}
		source.volume = 0.5f;
		source.Play();
	}

	public AudioClip[] Clips;
}
