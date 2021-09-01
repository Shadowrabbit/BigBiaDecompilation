using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionInstance : MonoBehaviour
{
	private void Start()
	{
		this.part = base.GetComponent<ParticleSystem>();
	}

	private void OnParticleCollision(GameObject other)
	{
		int num = this.part.GetCollisionEvents(other, this.collisionEvents);
		for (int i = 0; i < num; i++)
		{
			GameObject[] effectsOnCollision = this.EffectsOnCollision;
			for (int j = 0; j < effectsOnCollision.Length; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(effectsOnCollision[j], this.collisionEvents[i].intersection + this.collisionEvents[i].normal * this.Offset, default(Quaternion));
				if (this.UseFirePointRotation)
				{
					gameObject.transform.LookAt(base.transform.position);
				}
				else
				{
					gameObject.transform.LookAt(this.collisionEvents[i].intersection + this.collisionEvents[i].normal);
				}
				if (!this.UseWorldSpacePosition)
				{
					gameObject.transform.parent = base.transform;
				}
				UnityEngine.Object.Destroy(gameObject, this.DestroyTimeDelay);
			}
		}
		UnityEngine.Object.Destroy(base.gameObject, this.DestroyTimeDelay + 0.5f);
	}

	public GameObject[] EffectsOnCollision;

	public float Offset;

	public float DestroyTimeDelay = 5f;

	public bool UseWorldSpacePosition;

	public bool UseFirePointRotation;

	private ParticleSystem part;

	private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

	private ParticleSystem ps;
}
