using System;
using System.Collections.Generic;
using PixelGame;
using UnityEngine;

public class ParticleObject : ObjectBase
{
	public GameObject gameObject
	{
		get
		{
			return (GameObject)this.target;
		}
	}

	public ParticleSystem ParticleSystem
	{
		get
		{
			if (this.m_ParticleSystem == null)
			{
				this.m_ParticleSystem = this.gameObject.GetComponent<ParticleSystem>();
			}
			return this.m_ParticleSystem;
		}
	}

	public Transform transform
	{
		get
		{
			if (this.m_Transform == null)
			{
				this.m_Transform = this.gameObject.transform;
			}
			return this.m_Transform;
		}
	}

	public ParticleObject(string name, object target, float releaseTime = 3.4028235E+38f)
	{
		this.Name = name;
		this.target = target;
		this.releaseTime = releaseTime;
	}

	public void AddCallBack(Action action)
	{
		if (this.m_DeSpawnAction == null)
		{
			this.m_DeSpawnAction = new List<Action>();
		}
		this.m_DeSpawnAction.Add(action);
	}

	public void OnSpawn()
	{
		if (this.m_DeSpawnAction != null)
		{
			this.m_DeSpawnAction.Clear();
		}
		this.gameObject.SetActive(true);
		if (this.ParticleSystem != null)
		{
			this.ParticleSystem.Play();
		}
	}

	public void OnDespawn()
	{
		if (this.m_DeSpawnAction != null && this.m_DeSpawnAction.Count > 0)
		{
			foreach (Action action in this.m_DeSpawnAction)
			{
				action();
			}
		}
		this.gameObject.SetActive(false);
	}

	public override void Release()
	{
		UnityEngine.Object.Destroy(this.target as GameObject);
	}

	public float releaseTime;

	private Transform m_Transform;

	private ParticleSystem m_ParticleSystem;

	private List<Action> m_DeSpawnAction;
}
