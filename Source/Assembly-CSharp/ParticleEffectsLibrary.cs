using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectsLibrary : MonoBehaviour
{
	private void Awake()
	{
		ParticleEffectsLibrary.GlobalAccess = this;
		this.currentActivePEList = new List<Transform>();
		this.TotalEffects = this.ParticleEffectPrefabs.Length;
		this.CurrentParticleEffectNum = 1;
		if (this.ParticleEffectSpawnOffsets.Length != this.TotalEffects)
		{
			Debug.LogError("ParticleEffectsLibrary-ParticleEffectSpawnOffset: Not all arrays match length, double check counts.");
		}
		if (this.ParticleEffectPrefabs.Length != this.TotalEffects)
		{
			Debug.LogError("ParticleEffectsLibrary-ParticleEffectPrefabs: Not all arrays match length, double check counts.");
		}
		this.effectNameString = string.Concat(new string[]
		{
			this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name,
			" (",
			this.CurrentParticleEffectNum.ToString(),
			" of ",
			this.TotalEffects.ToString(),
			")"
		});
	}

	private void Start()
	{
	}

	public string GetCurrentPENameString()
	{
		return string.Concat(new string[]
		{
			this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name,
			" (",
			this.CurrentParticleEffectNum.ToString(),
			" of ",
			this.TotalEffects.ToString(),
			")"
		});
	}

	public void PreviousParticleEffect()
	{
		if (this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex] == 0f && this.currentActivePEList.Count > 0)
		{
			for (int i = 0; i < this.currentActivePEList.Count; i++)
			{
				if (this.currentActivePEList[i] != null)
				{
					UnityEngine.Object.Destroy(this.currentActivePEList[i].gameObject);
				}
			}
			this.currentActivePEList.Clear();
		}
		if (this.CurrentParticleEffectIndex > 0)
		{
			this.CurrentParticleEffectIndex--;
		}
		else
		{
			this.CurrentParticleEffectIndex = this.TotalEffects - 1;
		}
		this.CurrentParticleEffectNum = this.CurrentParticleEffectIndex + 1;
		this.effectNameString = string.Concat(new string[]
		{
			this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name,
			" (",
			this.CurrentParticleEffectNum.ToString(),
			" of ",
			this.TotalEffects.ToString(),
			")"
		});
	}

	public void NextParticleEffect()
	{
		if (this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex] == 0f && this.currentActivePEList.Count > 0)
		{
			for (int i = 0; i < this.currentActivePEList.Count; i++)
			{
				if (this.currentActivePEList[i] != null)
				{
					UnityEngine.Object.Destroy(this.currentActivePEList[i].gameObject);
				}
			}
			this.currentActivePEList.Clear();
		}
		if (this.CurrentParticleEffectIndex < this.TotalEffects - 1)
		{
			this.CurrentParticleEffectIndex++;
		}
		else
		{
			this.CurrentParticleEffectIndex = 0;
		}
		this.CurrentParticleEffectNum = this.CurrentParticleEffectIndex + 1;
		this.effectNameString = string.Concat(new string[]
		{
			this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name,
			" (",
			this.CurrentParticleEffectNum.ToString(),
			" of ",
			this.TotalEffects.ToString(),
			")"
		});
	}

	public void SpawnParticleEffect(Vector3 positionInWorldToSpawn)
	{
		this.spawnPosition = positionInWorldToSpawn + this.ParticleEffectSpawnOffsets[this.CurrentParticleEffectIndex];
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex], this.spawnPosition, this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].transform.rotation);
		UnityEngine.Object @object = gameObject;
		string str = "PE_";
		GameObject gameObject2 = this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex];
		@object.name = str + ((gameObject2 != null) ? gameObject2.ToString() : null);
		if (this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex] == 0f)
		{
			this.currentActivePEList.Add(gameObject.transform);
		}
		this.currentActivePEList.Add(gameObject.transform);
		if (this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex] != 0f)
		{
			UnityEngine.Object.Destroy(gameObject, this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex]);
		}
	}

	public static ParticleEffectsLibrary GlobalAccess;

	public int TotalEffects;

	public int CurrentParticleEffectIndex;

	public int CurrentParticleEffectNum;

	public Vector3[] ParticleEffectSpawnOffsets;

	public float[] ParticleEffectLifetimes;

	public GameObject[] ParticleEffectPrefabs;

	private string effectNameString = "";

	private List<Transform> currentActivePEList;

	private Vector3 spawnPosition = Vector3.zero;
}
