using System;
using UnityEngine;

public class MinionMouth : MonoBehaviour
{
	private void Awake()
	{
		this.MaxDecibes /= this.VolumeCurme.Evaluate(this.MusicSource.volume);
	}

	private void Update()
	{
		this.AnalyzeSound(Time.deltaTime);
	}

	private bool AnalyzeSound(float time)
	{
		if (!this.MusicSource.isPlaying)
		{
			return false;
		}
		float[] array = new float[this.SampleSize];
		float[] array2 = new float[this.SampleSize];
		float[] array3 = new float[this.SampleSize];
		this.MusicSource.GetOutputData(array, 0);
		this.MusicSource.GetOutputData(array2, 1);
		array3 = this.CombineChannels(array, array2);
		float num = 0f;
		for (int i = 0; i < array3.Length; i++)
		{
			num += array3[i] * array3[i];
		}
		this.RMS = Mathf.Sqrt(num / (float)this.SampleSize);
		this.Decibels = 20f * Mathf.Log10(this.RMS / this.DecibelRef);
		if (this.Decibels < this.MinDecibes)
		{
			this.Decibels = this.MinDecibes;
		}
		this.CurrentTime += time;
		if (this.CurrentTime < this.MouseChangeTime / 2f)
		{
			this.SetSprite(this.Decibels);
		}
		else if (this.CurrentTime < this.MouseChangeTime)
		{
			this.SetSprite(0);
		}
		else
		{
			this.CurrentTime = 0f;
		}
		return true;
	}

	private float[] CombineChannels(float[] Left, float[] Right)
	{
		float[] array = new float[Left.Length];
		for (int i = 0; i < Left.Length; i++)
		{
			array[i] = (Left[i] + Right[i]) / 2f / 32768f;
		}
		return array;
	}

	private void SetSprite(float Decibels)
	{
		Mathf.Clamp(Decibels, this.MinDecibes, this.MaxDecibes);
		float num = Mathf.Clamp01(0.0125f * Decibels + 2f);
		float num2 = 1f / (float)(this.sprites.Length - 1);
		int sprite = Mathf.CeilToInt(num / num2);
		this.SetSprite(sprite);
	}

	private void SetSprite(int index)
	{
		this.spriteRenderer.sprite = this.sprites[index];
	}

	public AnimationCurve VolumeCurme;

	public AudioSource MusicSource;

	public SpriteRenderer spriteRenderer;

	public Sprite[] sprites;

	public float DecibelRef = 0.1f;

	private float RMS;

	private float Decibels;

	private int SampleSize = 1024;

	private float[] Samples;

	private float[] Spectrum;

	private float MaxDecibes = -80f;

	private float MinDecibes = -160f;

	private float MouseChangeTime = 0.6f;

	private float CurrentTime;
}
