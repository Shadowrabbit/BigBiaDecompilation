using System;
using UnityEngine;

public abstract class CharacterEvent : ScriptableObject
{
	public abstract void Play(AudioSource source, int index, float picth);
}
