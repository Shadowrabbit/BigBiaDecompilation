using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/SimpleAudioEvent")]
public class SimpleAudioEvent : AudioEvent
{
	public override void Play(AudioSource source, int index)
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
		source.volume = UnityEngine.Random.Range(this.volume.MinValue, this.volume.MaxValue);
		source.pitch = UnityEngine.Random.Range(this.pitch.MinValue, this.pitch.MaxValue);
		source.Play();
	}

	public AudioClip[] Clips;

	public RangedFloat volume;

	[MinMaxRange(0f, 2f)]
	public RangedFloat pitch;
}
