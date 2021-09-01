using System;
using System.Collections.Generic;
using PixelGame;
using UnityEngine;

public class ParticlePoolManager : MonoBehaviour
{
	public ParticleObject Spawn(string name, float releaseTime = 3.4028235E+38f)
	{
		ParticleObject particleObject = this.ParticlePool.Spawn(name);
		if (particleObject == null)
		{
			GameObject gameObject = Resources.Load<GameObject>(name);
			if (gameObject == null)
			{
				gameObject = new GameObject("Empty Model");
				Debug.LogError("加载粒子失败： " + name);
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			}
			gameObject.transform.SetParent(base.transform);
			particleObject = new ParticleObject(name, gameObject, releaseTime);
			this.ParticlePool.Register(particleObject, true);
		}
		this.m_CurrentDisplayParticle.Add(particleObject);
		particleObject.OnSpawn();
		particleObject.releaseTime = releaseTime;
		return particleObject;
	}

	public void UnSpawn(ParticleObject particle)
	{
		if (this.m_CurrentDisplayParticle.Remove(particle))
		{
			particle.OnDespawn();
			this.ParticlePool.UnSpawn(particle);
		}
	}

	private void Awake()
	{
		ParticlePoolManager.Instance = this;
		this.ParticlePool = ObjectPoolComponent.Instance.ObjectPoolManager.CreateSingleObjectPool<ParticleObject>("Particle");
	}

	private void Update()
	{
		foreach (ParticleObject particleObject in this.m_CurrentDisplayParticle)
		{
			particleObject.releaseTime -= Time.deltaTime;
			if (particleObject.releaseTime <= 0f)
			{
				this.m_RemoveParticle.Add(particleObject);
			}
		}
		if (this.m_RemoveParticle.Count > 0)
		{
			foreach (ParticleObject particle in this.m_RemoveParticle)
			{
				this.UnSpawn(particle);
			}
			this.m_RemoveParticle.Clear();
		}
	}

	public static ParticlePoolManager Instance;

	public IObjectPool<ParticleObject> ParticlePool;

	private HashSet<ParticleObject> m_CurrentDisplayParticle = new HashSet<ParticleObject>();

	private HashSet<ParticleObject> m_RemoveParticle = new HashSet<ParticleObject>();
}
