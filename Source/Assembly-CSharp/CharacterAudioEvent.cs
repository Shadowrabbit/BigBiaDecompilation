using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/CharacterAudioEvent")]
public class CharacterAudioEvent : CharacterEvent
{
	public override void Play(AudioSource source, int index, float pitch)
	{
		if (this.Clips.Length == 0)
		{
			return;
		}
		if (index != 2147483647)
		{
			source.clip = this.Clips[index];
		}
		else
		{
			source.clip = this.Clips[UnityEngine.Random.Range(0, this.Clips.Length)];
		}
		source.volume = 0.5f;
		source.pitch = pitch;
		source.Play();
	}

	public AudioClip[] Clips;

	public RangedFloat volume;

	[MinMaxRange(0f, 2f)]
	public RangedFloat pitch;
}
